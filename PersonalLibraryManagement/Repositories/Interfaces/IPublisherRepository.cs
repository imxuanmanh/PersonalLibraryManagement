using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.Repositories
{
    public interface IPublisherRepository
    {
        Task LoadAsync();
        Task<int> AddAsync(Publisher publisher);
        Dictionary<int, Publisher> GetAllPublishers();
    }
}
