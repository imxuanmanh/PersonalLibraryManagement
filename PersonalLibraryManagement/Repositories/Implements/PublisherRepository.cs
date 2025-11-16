using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, Publisher> _publishers;

        public PublisherRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task<int> AddAsync(Publisher publisher)
        {
            int insertedPublisherId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                    INSERT INTO
                        Publisher(Name)

                    VALUES
                        (@name);

                    SELECT last_insert_rowid();
                ",
                new SqliteParameter("name", publisher.Name)
                );

            if (insertedPublisherId > 0)
            {
                publisher.Id = insertedPublisherId;
                _publishers[insertedPublisherId] = publisher;
                return insertedPublisherId;
            }

            return -1;
        }

        public async Task LoadAsync()
        {
            _publishers = await _dbManager.ExecuteQueryAsync<Publisher>(
                @"SELECT Id, Name FROM Publisher"
                );
        }

        public Dictionary<int, Publisher> GetAllPublishers()
        {
            return _publishers;
        }
    }
}
