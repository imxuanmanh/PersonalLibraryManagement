using PersonalLibraryManagement.Repositories;
using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public class CirculationService : ICirculationService
    {
        private readonly Repositories.IBookRepository _bookRepository;
        private readonly Repositories.ICirculationRepository _circulationRepository;

        public CirculationService(Repositories.IBookRepository bookRepository, Repositories.ICirculationRepository circulationRepository)
        {
            _bookRepository = bookRepository;
            _circulationRepository = circulationRepository;
        }

        public Dictionary<int, Circulation> GetAllCirculations()
        {
            return _circulationRepository.GetAllCirculations();
        }

        // Thêm một giao dịch
        public async Task<int> AddCirculationAsync(Circulation Circulation)
        {
            return await _circulationRepository.AddAsync(Circulation);
        }

        // Cho mượn sách
        public async Task<int> LendBookAsync(int bookId, string borrowerName)
        {
            Book book = _bookRepository.GetBookById(bookId);

            if (book == null)
            {
                return -1;
            }

            Circulation lendCirculation = new Circulation
            {
                BookId = bookId,
                BookTitleSnapshot = book.Title,
                BorrowerName = borrowerName,
                CirculationDate = DateTime.Now
            };

            return await _circulationRepository.AddAsync(lendCirculation);
        }

        // Thu hồi sách
        public async Task<bool> RecallBookAsync(int bookId)
        {
            return await _circulationRepository.RecallAsync(bookId);
        }

        // Trả sách
        public async Task<bool> ReturnBookAsync(int bookId)
        {
            bool circulationOk = await _circulationRepository.ReturnAsync(bookId);
            bool deleteOk = await _bookRepository.DeleteAsync(bookId);

            return circulationOk && deleteOk;
        }
    }
}
