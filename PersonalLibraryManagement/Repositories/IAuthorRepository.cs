using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public interface IAuthorRepository
    {
        Task LoadAsync();
        Dictionary<int, Author> GetAllAuthors();
    }
}
