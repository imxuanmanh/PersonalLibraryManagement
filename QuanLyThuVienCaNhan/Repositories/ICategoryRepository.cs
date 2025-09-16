using QuanLyThuVienCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Repositories
{
    public interface ICategoryRepository
    {
        Task LoadAsync();
        Dictionary<int, Category> GetAllCategories();
    }
}
