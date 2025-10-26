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
        private readonly IBookRepository _bookRepository;
        private readonly ICirculationRepository _circulationRepository;

        public CirculationService(IBookRepository bookRepository, ICirculationRepository circulationRepository)
        {
            _bookRepository = bookRepository;
            _circulationRepository = circulationRepository;
        }

        public Dictionary<int, Circulation> GetAllCirculations()
        {
            return _circulationRepository.GetAllCirculations();
        }

        public async Task<int> AddCirculationAsync(Circulation Circulation)
        {
            return await _circulationRepository.AddAsync(Circulation);
        }

        public async Task<bool> RecallBookAsync(int bookId)
        {
            return await _circulationRepository.RecallAsync(bookId);
        }
        public async Task<bool> ReturnBookAsync(int bookId)
        {
            bool circulationOk = await _circulationRepository.ReturnAsync(bookId);
            bool deleteOk = await _bookRepository.DeleteAsync(bookId);

            return circulationOk && deleteOk;
        }

        public async Task<int> LendBookAsync(int bookId, string borrowerName)
        {

            Circulation lendCirculation = new Circulation
            {
                BookId = bookId,
                BorrowerName = borrowerName,
                CirculationDate = DateTime.Now
            };

            return await _circulationRepository.AddAsync(lendCirculation);
        }
    }
}
