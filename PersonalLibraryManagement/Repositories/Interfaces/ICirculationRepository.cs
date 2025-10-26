using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Enums;
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
        Task<bool> RecallAsync(int bookId);
        Task<bool> ReturnAsync(int bookId);
        CirculationStatus GetStatusByBookId(int bookId);

        Dictionary<int, Circulation> GetAllCirculations();
        Circulation GetActiveCirculationByBookId(int bookId);
    }
}
