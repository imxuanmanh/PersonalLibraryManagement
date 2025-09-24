using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public interface ILoanHistoryRepository
    {
        Task LoadAsync();
        Task<int> AddAsync(LoanHistory history);
        Dictionary<int, LoanHistory> GetAllLoanHistories();
        string GetStatusByBookId(int bookId);
    }
}
