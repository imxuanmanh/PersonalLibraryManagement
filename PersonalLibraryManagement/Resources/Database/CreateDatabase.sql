PRAGMA foreign_keys = ON;

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

CREATE TABLE StorageLocation (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Room TEXT NOT NULL,
    Shelf TEXT NOT NULL,
    Row TEXT NOT NULL
);

CREATE TABLE Book (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Title TEXT NOT NULL,
    AuthorId INTEGER,
    CategoryId INTEGER,
    PublisherId INTEGER,
    PublishYear INTEGER,
    Description TEXT,
    StorageLocationId INTEGER NOT NULL,
    ImagePath TEXT,
    FOREIGN KEY (AuthorId) REFERENCES Author(Id),
    FOREIGN KEY (CategoryId) REFERENCES Category(Id),
    FOREIGN KEY (PublisherId) REFERENCES Publisher(Id),
    FOREIGN KEY (StorageLocationId) REFERENCES StorageLocation(Id)
);

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
