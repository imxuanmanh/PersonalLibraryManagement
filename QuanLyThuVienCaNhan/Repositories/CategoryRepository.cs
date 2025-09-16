using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, Category> _categories;

        public CategoryRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }
        public async Task LoadAsync()
        {
            _categories = await _dbManager.ExecuteQueryAsync<Category>(
                @"SELECT Id, Name FROM Category"
                );
        }

        public Dictionary<int, Category> GetAllCategories()
        {
            return _categories;
        }
    }
}
