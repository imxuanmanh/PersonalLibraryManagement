using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Models;

namespace PersonalLibraryManagement.Services
{
    public interface IStorageLocationService
    {
        Dictionary<int, Room> GetAllRooms();
        Dictionary<int, Shelf> GetAllShelfByRoomId(int roomId);
        Dictionary<int, ShelfRow> GetAllShelfRowByShelfId(int shelfId);
        Task<int> AddRoomAsync(Room room);
        Task<int> AddShelfAsync(Shelf shelf);
        Task<int> AddShelfRowAsync(ShelfRow shelfRow);
    }
}
