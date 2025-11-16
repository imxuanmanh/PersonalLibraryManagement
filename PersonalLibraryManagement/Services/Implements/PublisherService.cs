using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepository _publisherRepository;

        public PublisherService(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public async Task<bool> AddPublisherAsync(Publisher publisher)
        {
            return await _publisherRepository.AddAsync(publisher) > 0;
        }

        public Dictionary<int, Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAllPublishers();
        }
    }
}
