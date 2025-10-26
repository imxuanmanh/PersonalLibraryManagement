using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Repositories;
using PersonalLibraryManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PersonalLibraryManagement.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _repository;
        public BookService(IBookRepository bookRepository)
        {
            _repository = bookRepository;
        }

        public async Task<int> AddBookAsync(Book book)
        {
            return await _repository.AddAsync(book); 
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
