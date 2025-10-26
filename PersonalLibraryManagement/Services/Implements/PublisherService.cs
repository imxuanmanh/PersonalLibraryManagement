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

        public Dictionary<int, Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAllPublishers();
        }
    }
}
