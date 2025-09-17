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
        IEnumerable<Book> GetAllBooks();
        Dictionary<int, BookViewModel> GetAllBookViewModels();
        Book GetBookById(int id);

    }
}
