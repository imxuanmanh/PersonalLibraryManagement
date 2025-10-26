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

        public Dictionary<int, Room> GetAllRooms()
        {
            return _storageLocationRepository.GetAllRooms();
        }

        public Dictionary<int, Shelf> GetAllShelfByRoomId(int roomId)
        {
            return _storageLocationRepository.GetAllShelfByRoomId(roomId);
        }

        public Dictionary<int, ShelfRow> GetAllShelfRowByShelfId(int shelfId)
        {
            return _storageLocationRepository.GetAllShelfRowByShelfId(shelfId);
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            return await _storageLocationRepository.AddRoomAsync(room);
        }
        public async Task<int> AddShelfAsync(Shelf shelf)
        {
            return await _storageLocationRepository.AddShelfAsync(shelf);
        }

        public async Task<int> AddShelfRowAsync(ShelfRow shelfRow)
        {
            return await _storageLocationRepository.AddShelfRowAsync(shelfRow);
        }
    }
}
