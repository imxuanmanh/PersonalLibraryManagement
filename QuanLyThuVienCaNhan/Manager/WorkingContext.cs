using QuanLyThuVienCaNhan.Repositories;
using QuanLyThuVienCaNhan.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Manager
{
    public class WorkingContext
    {
        public IDbManager DbManager { get; }

        public IAuthorRepository Authors { get; }
        public ICategoryRepository Categories { get; }
        public IPublisherRepository Publishers { get; }
        public ILoanHistoryRepository LoanHistories {  get; }
        public IStorageLocationRepository StorageLocations { get; }
        public WorkingContext()
        {
            DbManager = new DbManager($"Data Source={PathManager.DatabasePath}");
            Debug.WriteLine($"Image Path: {PathManager.ImageDir}");
            // Debug.WriteLine($"Database Path: {PathManager.DatabasePath}");
            // string dbPath = @"D:\workspace\projects\QuanLyThuVienCaNhan\QuanLyThuVienCaNhan\Resources\Database\PersonalLibraryManagement.db";
            // DbManager = new DbManager($"Data Source={dbPath}");


            Authors = new AuthorRepository(DbManager);
            Categories = new CategoryRepository(DbManager);
            Publishers = new PublisherRepository(DbManager);
            LoanHistories = new LoanHistoryRepository(DbManager);
            StorageLocations = new StorageLocationRepository(DbManager);
        }

        public async Task LoadAsync()
        {
            await Authors.LoadAsync();
            await Categories.LoadAsync();
            await Publishers.LoadAsync();
            await LoanHistories.LoadAsync();
            await StorageLocations.LoadAsync();
        }
    }
}
