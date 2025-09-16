using QuanLyThuVienCaNhan.Models;
using QuanLyThuVienCaNhan.Repositories;
using QuanLyThuVienCaNhan.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyThuVienCaNhan.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _repository;
        public BookService(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }

        public Dictionary<int, BookViewModel> GetAllBookViewModels()
        {
            return _repository.GetAllBookViewModels();
        }


        public Book GetBookById(int id)
        {
            return new Book();
        }

    }
}
