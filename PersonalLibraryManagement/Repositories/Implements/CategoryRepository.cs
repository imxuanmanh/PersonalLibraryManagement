using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
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

        public async Task<int> AddAsync(Category category)
        {
            int insertedCategoryId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                    INSERT INTO 
                        Category(Name)
        
                    VALUES
                        (@name);

                    SELECT last_insert_rowid();
                ",
                new SqliteParameter("@name", category.Name)
                );

            if ( insertedCategoryId > 0 )
            {
                category.Id = insertedCategoryId;
                _categories[insertedCategoryId] = category;
                return insertedCategoryId;
            }

            return -1;
        }

        public Dictionary<int, Category> GetAllCategories()
        {
            return _categories;
        }
    }
}
