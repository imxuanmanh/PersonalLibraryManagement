using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public interface IBookRepository
    {
        Book GetBookById(int id);
        Task<bool> AddAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(int bookId);
        Task LoadAsync();
        IEnumerable<Book> GetAll();
        Dictionary<int, BookViewModel> GetAllBookViewModels();
    }
}
