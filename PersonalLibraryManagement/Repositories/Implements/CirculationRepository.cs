using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PersonalLibraryManagement.Repositories
{
    public class CirculationRepository : ICirculationRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, Circulation> _circulations;

        public CirculationRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task LoadAsync()
        {
            _circulations = await _dbManager.ExecuteQueryAsync<Circulation>(
                @"SELECT Id, BookId, BookTitleSnapshot, BorrowerName, LenderName, CirculationDate, ReturnDate FROM Circulation"
                );
        }

        public async Task<int> AddAsync(Circulation circulation)
        {
            int insertedCirculationId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                INSERT INTO 
                    Circulation(BookId, BorrowerName, LenderName, CirculationDate)

                VALUES (@bookId, @borrowerName, @lenderName, @circulationDate);

                SELECT last_insert_rowid();
                ",
                new SqliteParameter("@bookId", circulation.BookId),
                new SqliteParameter("@borrowerName", circulation.BorrowerName ?? (object)DBNull.Value),
                new SqliteParameter("@lenderName", circulation.LenderName ?? (object)DBNull.Value),
                new SqliteParameter("@circulationDate", circulation.CirculationDate)
            );

            if (insertedCirculationId > 0)
            {
                circulation.Id = insertedCirculationId;
                _circulations[insertedCirculationId] = circulation;
                return insertedCirculationId;
            }

            return -1;
        }

        
        public async Task<bool> RecallAsync(int bookId)
        {
            var active = GetActiveCirculationByBookId(bookId);
            if (active == null)
                return false;

            var now = DateTime.Now;
            int rows = await _dbManager.ExecuteNonQueryAsync(
                @"UPDATE Circulation SET ReturnDate = @returnDate WHERE Id = @circulationId;",
                new SqliteParameter("@returnDate", now),
                new SqliteParameter("@circulationId", active.Id)
            );

            if (rows > 0)
                active.ReturnDate = now;

            return rows > 0;
        }
        
        public async Task<bool> ReturnAsync(int bookId)
        {
                        var active = GetActiveCirculationByBookId(bookId);
            if (active == null)
                return false;

            var now = DateTime.Now;
            int rows = await _dbManager.ExecuteNonQueryAsync(
                @"UPDATE Circulation SET ReturnDate = @returnDate WHERE Id = @circulationId;",
                new SqliteParameter("@returnDate", now),
                new SqliteParameter("@circulationId", active.Id)
            );

            if (rows > 0)
                active.ReturnDate = now;

            return rows > 0;
        }


        public Dictionary<int, Circulation> GetAllCirculations()
        {
            return _circulations;
        }

        public Circulation GetActiveCirculationByBookId(int bookId)
        {
            System.Diagnostics.Debug.WriteLine($"[DEBUG] Tìm circulation chưa hoàn thành cho BookId={bookId}");

            var active = _circulations.Values
                .FirstOrDefault(c => c.BookId == bookId && c.ReturnDate == null);

            if (active == null)
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Không tìm thấy circulation active cho BookId={bookId}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"[DEBUG] Tìm thấy circulation Id={active.Id}, Borrower={active.BorrowerName}, ReturnDate={active.ReturnDate}");
            }

            return active;
        }



        public CirculationStatus GetStatusByBookId(int bookId)
        {
            var circulations = _circulations.Values
                .Where(c => c.BookId == bookId)
                .ToList();

            if (!circulations.Any())
                return CirculationStatus.Avaiable;

            foreach (var c in circulations)
            {
                if (c.ReturnDate == null)
                {
                    if (!string.IsNullOrEmpty(c.BorrowerName))
                        return CirculationStatus.Lent;
                    else if (!string.IsNullOrEmpty(c.LenderName))
                        return CirculationStatus.Borrowed;
                }
            }

            // tất cả đã trả
            return CirculationStatus.Avaiable;
        }

        //public string GetStatusByBookId(int bookId)
        //{
        //    if (_circulations.TryGetValue(bookId, out var circulation))
        //    {
        //        if (circulation.CirculationDate == null)
        //        {
        //            return "Có sẵn"; // sách chưa ai mượn
        //        }
        //        else if (!string.IsNullOrEmpty(circulation.BorrowerName))
        //        {
        //            return $"Đang cho {circulation.BorrowerName} mượn"; // sách đang được mượn
        //        }
        //        else if (!string.IsNullOrEmpty(circulation.LenderName))
        //        {
        //            return $"Mượn của {circulation.LenderName}"; // sách mượn về thủ thư
        //        }
        //    }

        //    // nếu không có lịch sử hoặc không thỏa điều kiện nào → mặc định có sẵn
        //    return "Có sẵn";
        //}

    }
}
