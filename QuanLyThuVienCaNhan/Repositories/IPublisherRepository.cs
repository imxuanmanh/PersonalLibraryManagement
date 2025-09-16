using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyThuVienCaNhan.Models;

namespace QuanLyThuVienCaNhan.Repositories
{
    public interface IPublisherRepository
    {
        Task LoadAsync();
        Dictionary<int, Publisher> GetAllPublishers();
    }
}
