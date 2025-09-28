using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public interface ICirculationRepository
    {
        Task LoadAsync();
        Task<int> AddAsync(Circulation circulation);
        Dictionary<int, Circulation> GetAllCirculations();
        string GetStatusByBookId(int bookId);
    }
}
