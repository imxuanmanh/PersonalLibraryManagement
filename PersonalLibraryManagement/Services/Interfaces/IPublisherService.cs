using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.Services
{
    public interface IPublisherService
    {
        Task<bool> AddPublisherAsync(Publisher publisher);
        Dictionary<int, Publisher> GetAllPublishers();
    }
}
