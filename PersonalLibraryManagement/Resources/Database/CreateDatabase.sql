-- Bật FK trong SQLite (phải bật trước khi thực hiện thao tác phụ thuộc)
PRAGMA foreign_keys = ON;

-- ---------- Bảng tham chiếu ----------
CREATE TABLE Author (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE Category (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE Publisher (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE Room (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

CREATE TABLE Shelf (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    RoomId INTEGER NOT NULL,
    Ordinal INTEGER NOT NULL,              -- số thứ tự kệ trong phòng
    FOREIGN KEY (RoomId) REFERENCES Room(Id) ON DELETE RESTRICT ON UPDATE CASCADE,
    UNIQUE (RoomId, Ordinal)               -- đảm bảo không trùng số kệ trong cùng phòng
);

CREATE TABLE ShelfRow (  
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ShelfId INTEGER NOT NULL,
    Ordinal INTEGER NOT NULL,              -- số thứ tự hàng trong kệ
    FOREIGN KEY (ShelfId) REFERENCES Shelf(Id) ON DELETE RESTRICT ON UPDATE CASCADE,
    UNIQUE (ShelfId, Ordinal)               -- đảm bảo không trùng số hàng trong cùng kệ
);

-- ---------- Bảng chính ----------
CREATE TABLE Book (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    AuthorId INTEGER,                      
    CategoryId INTEGER,
    PublisherId INTEGER,
    PublishYear INTEGER,
    Description TEXT,
    StorageLocationId INTEGER,             -- FK tới ShelfRow.Id (vị trí sách)
    ImagePath TEXT,

    FOREIGN KEY (AuthorId) REFERENCES Author(Id) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (CategoryId) REFERENCES Category(Id) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (PublisherId) REFERENCES Publisher(Id) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (StorageLocationId) REFERENCES ShelfRow(Id) ON DELETE SET NULL ON UPDATE CASCADE
);

-- ---------- Bảng lưu giao dịch (Circulation) ----------
-- BorrowerName NULL => là "sách mượn của người khác" (lender tồn tại)
-- LenderName NULL => là "sách cho ngườu khác mượn" (borrower tồn tại)
CREATE TABLE Circulation (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    BookId INTEGER,
    BookTitleSnapshot TEXT DEFAULT '' NOT NULL,
    BorrowerName TEXT,        -- tên người mượn 
    LenderName   TEXT,        -- tên người cho mượn 
    CirculationDate    TEXT NOT NULL, -- ngày bắt đầu giao dịch
    ReturnDate   TEXT,         -- ngày trả (NULL nếu chưa trả)

    FOREIGN KEY (BookId) REFERENCES Book(Id) ON DELETE SET NULL ON UPDATE CASCADE,

    -- bắt buộc có 1 trong 2: BorrowerName OR LenderName (không được cả 2 NULL, không được cả 2 NOT NULL)
    CHECK (
        (BorrowerName IS NULL AND LenderName IS NOT NULL)
        OR
        (BorrowerName IS NOT NULL AND LenderName IS NULL)
    ),
	
    -- đảm bảo ReturnDate nếu có thì không trước CirculationDate
    CHECK (ReturnDate IS NULL OR ReturnDate >= CirculationDate)
);

-- ---------- Indexes hữu dụng để tăng hiệu năng join / thống kê ----------
CREATE INDEX IF NOT EXISTS IX_Book_StorageLocationId ON Book(StorageLocationId);
CREATE INDEX IF NOT EXISTS IX_ShelfRow_ShelfId ON ShelfRow(ShelfId);
CREATE INDEX IF NOT EXISTS IX_Shelf_RoomId ON Shelf(RoomId);
CREATE INDEX IF NOT EXISTS IX_Circulation_BookId ON Circulation(BookId);
CREATE INDEX IF NOT EXISTS IX_Circulation_ReturnDate ON Circulation(ReturnDate);

-- Trigger: khi thêm circulation mới thì tự động copy tên sách
CREATE TRIGGER trg_Circulation_Insert
AFTER INSERT ON Circulation
FOR EACH ROW
WHEN NEW.BookId IS NOT NULL
BEGIN
    UPDATE Circulation
    SET BookTitleSnapshot = (
        SELECT Title FROM Book WHERE Id = NEW.BookId
    )
    WHERE Id = NEW.Id;
END;

