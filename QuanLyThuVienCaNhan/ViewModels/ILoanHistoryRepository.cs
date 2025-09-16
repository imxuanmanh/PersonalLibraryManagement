using QuanLyThuVienCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.ViewModels
{
    public interface ILoanHistoryRepository
    {
        Task LoadAsync();
        Dictionary<int, LoanHistory> GetAllLoanHistories();
        string GetStatusByBookId(int bookId);
    }
}
