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
        Dictionary<int, Publisher> GetAllPublishers();

    }
}
