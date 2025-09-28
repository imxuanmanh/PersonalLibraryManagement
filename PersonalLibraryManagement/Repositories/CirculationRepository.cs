using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System.Data.SqlClient;

namespace PersonalLibraryManagement.Repositories
{
    public class CirculationRepository : ICirculationRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, Circulation> _circulation;

        public CirculationRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task LoadAsync()
        {
            _circulation = await _dbManager.ExecuteQueryAsync<Circulation>(
                @"SELECT Id, BookId, BookTitleSnapshot, BorrowerName, LenderName, CirculationDate, ReturnDate FROM Circulation"
                );
        }

        public async Task<int> AddAsync(Circulation circulation)
        {
            int insertedCirculationId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                INSERT INTO 
                    Circulation(BookId, BorrowerName, LenderName, CirculationDate, ReturnDate)

                VALUES (@bookId, @borrowerName, @lenderName, @circulationDate, @returnDate);

                SELECT last_insert_rowid();
                ",
                new SqliteParameter("@bookId", circulation.BookId),
                new SqliteParameter("@borrowerName", circulation.BorrowerName),
                new SqliteParameter("@lenderName", circulation.LenderName),
                new SqliteParameter("@circulationDate", circulation.CirculationDate),
                new SqliteParameter("@returnDate", circulation.ReturnDate)
            );

            if (insertedCirculationId > 0)
            {
                circulation.Id = insertedCirculationId;
                _circulation[insertedCirculationId] = circulation;
                return insertedCirculationId;
            }

            return -1;
        }

        public Dictionary<int, Circulation> GetAllCirculations()
        {
            return _circulation;
        }

        public string GetStatusByBookId(int bookId)
        {
            if (_circulation.TryGetValue(bookId, out var circulation))
            {
                if (circulation.CirculationDate == null)
                {
                    return "Có sẵn"; // sách chưa ai mượn
                }
                else if (!string.IsNullOrEmpty(circulation.BorrowerName))
                {
                    return $"Đang cho {circulation.BorrowerName} mượn"; // sách đang được mượn
                }
                else if (!string.IsNullOrEmpty(circulation.LenderName))
                {
                    return $"Mượn của {circulation.LenderName}"; // sách mượn về thủ thư
                }
            }

            // nếu không có lịch sử hoặc không thỏa điều kiện nào → mặc định có sẵn
            return "Có sẵn";
        }

    }
}
