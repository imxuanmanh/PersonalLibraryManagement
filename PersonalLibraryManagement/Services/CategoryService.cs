using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public Dictionary<int, Category> GetAllCategories()
        {
            return _categoryRepository.GetAllCategories();
        }
    }
}
