using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.Services
{
    public interface ICirculationService
    {
        Task<int> AddCirculationAsync(Circulation Circulation);
        Task<bool> RecallBookAsync(int bookId);
        Task<bool> ReturnBookAsync(int bookId);

        Dictionary<int, Circulation> GetAllCirculations();

        Task<int> LendBookAsync(int bookId, string borrowerName);
    }
}
