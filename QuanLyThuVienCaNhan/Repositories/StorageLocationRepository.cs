using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThuVienCaNhan.Repositories
{
    public class StorageLocationRepository : IStorageLocationRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, StorageLocation> _storageLocations;

        public StorageLocationRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task LoadAsync()
        {
            _storageLocations = await _dbManager.ExecuteQueryAsync<StorageLocation>(
                @"SELECT Id, Room, Shelf, Row FROM StorageLocation
            ");
        }

        public Dictionary<int, StorageLocation> GetAllStorageLocations()
        {
            return _storageLocations;
        }
    }
}
