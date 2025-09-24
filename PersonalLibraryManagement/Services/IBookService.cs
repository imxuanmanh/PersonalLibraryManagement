using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public interface IBookService
    {
        Task<int> AddBookAsync(Book book);
        IEnumerable<Book> GetAllBooks();
        Dictionary<int, BookViewModel> GetAllBookViewModels();
        Book GetBookById(int id);

    }
}
