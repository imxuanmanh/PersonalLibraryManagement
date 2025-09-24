using PersonalLibraryManagement.Repositories;
using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Services
{
    public class StorageLocationService : IStorageLocationService
    {
        private readonly IStorageLocationRepository _storageLocationRepository;

        public StorageLocationService(IStorageLocationRepository storageLocationRepository)
        {
            _storageLocationRepository = storageLocationRepository;
        }

        public Dictionary<int, StorageLocation> GetAllStorageLocations()
        {
            return _storageLocationRepository.GetAllStorageLocations();
        }
    }
}
