using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using System;
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
