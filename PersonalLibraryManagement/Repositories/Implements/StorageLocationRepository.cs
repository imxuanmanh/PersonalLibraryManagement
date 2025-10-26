using Microsoft.Data.Sqlite;
using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalLibraryManagement.Repositories
{
    public class StorageLocationRepository : IStorageLocationRepository
    {
        private readonly IDbManager _dbManager;
        private Dictionary<int, StorageLocationViewModel> _storageLocations;

        private Dictionary<int, Room> _rooms = new Dictionary<int, Room>();
        private Dictionary<int, Shelf> _shelves = new Dictionary<int, Shelf>();
        private Dictionary<int, ShelfRow> _shelfRows = new Dictionary<int, ShelfRow>();

        public StorageLocationRepository(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public async Task LoadAsync()
        {
            _rooms = await LoadRoomAsync();
            _shelves = await LoadShelfAsync();
            _shelfRows = await LoadShelfRowAsync();
        }

        public Dictionary<int, Room> GetAllRooms()
        {
            return _rooms;
        }
        public Dictionary<int, Shelf> GetAllShelfByRoomId(int roomId)
        {
            return _shelves.Where(s=>s.Value.RoomId == roomId)
                            .ToDictionary(s=>s.Key, s=>s.Value);
        }
        public Dictionary<int, ShelfRow> GetAllShelfRowByShelfId(int shelfId)
        {
            return _shelfRows.Where(r => r.Value.ShelfId == shelfId)
                            .ToDictionary(r => r.Key, r => r.Value);
        }

        public string GetStorageLocationById(int shelfRowId)
        {
            if (!_shelfRows.TryGetValue(shelfRowId, out var shelfRow))
                return "Không xác định";

            if (!_shelves.TryGetValue(shelfRow.ShelfId, out var shelf))
                return "Không xác định";

            if (!_rooms.TryGetValue(shelf.RoomId, out var room))
                return "Không xác định";

            return $"{room.Name} - Kệ {shelf.Ordinal} - Hàng {shelfRow.Ordinal}";
        }

        public async Task<int> AddRoomAsync(Room room)
        {
            int insertedRoomId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                INSERT INTO 
                    Room (Name)
                VALUES
                    (@name);

                SELECT last_insert_rowid();
                ",
                new SqliteParameter("@name", room.Name)
                );

            if (insertedRoomId > 0)
            {
                room.Id = insertedRoomId;
                _rooms[insertedRoomId] = room;
                return insertedRoomId;
            }
            return -1;
        }
        public async Task<int> AddShelfAsync(Shelf shelf)
        {
            int insertedShelfId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                INSERT INTO 
                    Shelf (RoomId, Ordinal)
                VALUES
                    (@roomId, @ordinal);

                SELECT last_insert_rowid();
                ",
                new SqliteParameter("@roomId", shelf.RoomId),
                new SqliteParameter("@ordinal", shelf.Ordinal)
                );

            if (insertedShelfId > 0)
            {
                shelf.Id = insertedShelfId;
                _shelves[insertedShelfId] = shelf;
                return insertedShelfId;
            }
            return -1;
        }
        public async Task<int> AddShelfRowAsync(ShelfRow shelfRow)
        {
            int insertedShelfRowId = await _dbManager.ExecuteScalarAsync<int>(
                @"
                INSERT INTO 
                    ShelfRow (ShelfId, Ordinal)
                VALUES
                    (@shelfId, @ordinal);

                SELECT last_insert_rowid();
                ",
                new SqliteParameter("@shelfId", shelfRow.ShelfId),
                new SqliteParameter("@ordinal", shelfRow.Ordinal)
                );

            if (insertedShelfRowId > 0)
            {
                shelfRow.Id = insertedShelfRowId;
                _shelfRows[insertedShelfRowId] = shelfRow;
                return insertedShelfRowId;
            }
            return -1;
        }

        private async Task<Dictionary<int, Room>> LoadRoomAsync()
        {
            return await _dbManager.ExecuteQueryAsync<Room>(
                @"SELECT Id, Name FROM Room;"
                );
        }

        private async Task<Dictionary<int, Shelf>> LoadShelfAsync()
        {
            return await _dbManager.ExecuteQueryAsync<Shelf>(
                @"SELECT Id, RoomId, Ordinal FROM Shelf;"
                );
        }

        private async Task<Dictionary<int, ShelfRow>> LoadShelfRowAsync()
        {
            return await _dbManager.ExecuteQueryAsync<ShelfRow>(
                @"SELECT Id, ShelfId, Ordinal FROM ShelfRow;"
                );
        }
    }
}
