using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.Services
{
    public interface IAuthorService
    {
        Dictionary<int, Author> GetAllAuthors();
        Task<bool> AddAuthorAsync(Author author);
    }
}
