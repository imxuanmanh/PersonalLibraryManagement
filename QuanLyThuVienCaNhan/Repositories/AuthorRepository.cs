using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace QuanLyThuVienCaNhan.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, Author> _authors;

        public AuthorRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task LoadAsync()
        {
            _authors = await _dbManager.ExecuteQueryAsync<Author>(
                @"SELECT Id, Name FROM Author"
                );
        }
        public Dictionary<int, Author> GetAllAuthors()
        {
             return _authors;
        }

    }
}
