-- Bảng tác giả
CREATE TABLE Author (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

-- Bảng thể loại
CREATE TABLE Category (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

-- Bảng nhà xuất bản
CREATE TABLE Publisher (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL
);

-- Bảng vị trí lưu trữ
CREATE TABLE StorageLocation (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Room TEXT,
    Shelf TEXT,
    Row TEXT
);

-- Bảng sách
CREATE TABLE Book (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    AuthorId INTEGER,
    CategoryId INTEGER,
    PublisherId INTEGER,
    PublishYear INTEGER,
    Description TEXT,
    StorageLocationId INTEGER,
    ImagePath TEXT,
    FOREIGN KEY (AuthorId) REFERENCES Author(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id),
    FOREIGN KEY (PublisherId) REFERENCES Publisher(Id),
    FOREIGN KEY (StorageLocationId) REFERENCES StorageLocation(Id)
);

--Bảng lịch sử mượn sách
CREATE TABLE LoanHistory (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    BookId INTEGER NOT NULL,
    BorrowerName TEXT,
    LenderName TEXT,
    LoanDate DATE NOT NULL,
    MustReturnDate DATE,
    ActualReturnDate DATE,
    FOREIGN KEY (BookId) REFERENCES Book(Id),
    CHECK (BorrowerName IS NOT NULL OR LenderName IS NOT NULL)
);
