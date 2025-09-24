using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public Dictionary<int, Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public async Task AddAuthorAsync(Author author)
        {
            await _authorRepository.AddAsync(author);
        }
    }
}
