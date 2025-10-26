using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace PersonalLibraryManagement.Repositories
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

        public async Task AddAsync(Author author)
        {
            int insertedAuthorId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                INSERT INTO Author(Name) VALUES (@name);
                SELECT last_insert_rowid();
                ",
                new SqliteParameter("@name", author.Name)
            );

            if (insertedAuthorId > 0)
            {
                author.Id = insertedAuthorId;

                if (_authors == null)
                    _authors = new Dictionary<int, Author>();


                _authors[insertedAuthorId] = author;
            }
        }

        public Dictionary<int, Author> GetAllAuthors()
        {
            return _authors;
        }

    }
}
