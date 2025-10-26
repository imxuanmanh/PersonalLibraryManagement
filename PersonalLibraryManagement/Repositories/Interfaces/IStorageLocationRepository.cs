using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public interface IStorageLocationRepository
    {
        Task LoadAsync();
        Dictionary<int, Room> GetAllRooms();
        Dictionary<int, Shelf> GetAllShelfByRoomId(int roomId);
        Dictionary<int, ShelfRow> GetAllShelfRowByShelfId(int shelfId);

        string GetStorageLocationById(int shelfRowId);
        Task<int> AddRoomAsync(Room room);
        Task<int> AddShelfAsync(Shelf shelf);
        Task<int> AddShelfRowAsync(ShelfRow shelfRow);
    
    }
}
