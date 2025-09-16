using QuanLyThuVienCaNhan.Models;
using QuanLyThuVienCaNhan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Services
{
    public interface IBookService
    {
        IEnumerable<Book> GetAllBooks();
        Dictionary<int, BookViewModel> GetAllBookViewModels();
        Book GetBookById(int id);

    }
}
