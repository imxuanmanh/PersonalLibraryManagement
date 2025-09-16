using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Models;
using QuanLyThuVienCaNhan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Repositories
{
    public class LoanHistoryRepository : ILoanHistoryRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, LoanHistory> _loanHistories;

        public LoanHistoryRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task LoadAsync()
        {
            _loanHistories = await _dbManager.ExecuteQueryAsync<LoanHistory>(
                @"SELECT Id, BookId, BorrowerName, LenderName, LoanDate, MustReturnDate, ActualReturnDate FROM LoanHistory"
                );
        }

        public Dictionary<int, LoanHistory> GetAllLoanHistories()
        {
            return _loanHistories;
        }

        public string GetStatusByBookId(int bookId)
        {
            if (_loanHistories.TryGetValue(bookId, out var loan))
            {
                if (loan.LoanDate == null)
                {
                    return "Có sẵn"; // sách chưa ai mượn
                }
                else if (!string.IsNullOrEmpty(loan.BorrowerName))
                {
                    return $"Đang cho {loan.BorrowerName} mượn"; // sách đang được mượn
                }
                else if (!string.IsNullOrEmpty(loan.LenderName))
                {
                    return $"Mượn của {loan.LenderName}"; // sách mượn về thủ thư
                }
            }

            // nếu không có lịch sử hoặc không thỏa điều kiện nào → mặc định có sẵn
            return "Có sẵn";
        }

    }
}
