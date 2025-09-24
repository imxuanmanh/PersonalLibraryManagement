-- Thêm dữ liệu cho Author
INSERT INTO Author (Name) VALUES
('J.K. Rowling'),
('George Orwell'),
('Harper Lee'),
('F. Scott Fitzgerald'),
('Jane Austen'),
('Mark Twain'),
('Ernest Hemingway'),
('Leo Tolstoy'),
('Charles Dickens'),
('Agatha Christie');

-- Thêm dữ liệu cho Category
INSERT INTO Category (Name) VALUES
('Fantasy'),
('Dystopian'),
('Classic'),
('Romance'),
('Adventure'),
('Mystery'),
('Historical'),
('Fiction');

-- Thêm dữ liệu cho Publisher
INSERT INTO Publisher (Name) VALUES
('Penguin Random House'),
('HarperCollins'),
('Simon & Schuster'),
('Macmillan Publishers'),
('Hachette Livre');

-- Thêm dữ liệu cho StorageLocation (ghi chú: tất cả trường NOT NULL nên phải nhập đủ)
INSERT INTO StorageLocation (Room, Shelf, Row) VALUES
('Room A', 'Shelf 1', 'Row 1'),
('Room A', 'Shelf 1', 'Row 2'),
('Room A', 'Shelf 2', 'Row 1'),
('Room B', 'Shelf 1', 'Row 1'),
('Room B', 'Shelf 2', 'Row 3');

INSERT INTO Book (Title, AuthorId, CategoryId, PublisherId, PublishYear, Description, StorageLocationId, ImagePath) VALUES
('Harry Potter and the Sorcerer\'s Stone', 1, 1, 1, 1997, 'Fantasy novel about a young wizard.', 1, 'hp1.png'),
('1984', 2, 2, 2, 1949, 'Dystopian social science fiction novel.', 2, '1984.png'),
('To Kill a Mockingbird', 3, 3, 3, 1960, 'Novel about racial injustice.', 3, 'mockingbird.png'),
('The Great Gatsby', 4, 3, 4, 1925, 'Novel set in the Jazz Age.', 4, 'gatsby.png'),
('Pride and Prejudice', 5, 4, 1, 1813, 'Romantic novel.', 5, 'pride.png'),
('Adventures of Huckleberry Finn', 6, 5, 2, 1884, 'Adventure novel.', 1, 'huckfinn.png'),
('The Old Man and the Sea', 7, 3, 3, 1952, 'Novel about an old fisherman.', 2, 'oldmansea.png'),
('War and Peace', 8, 7, 4, 1869, 'Historical novel.', 3, 'warpeace.png'),
('Great Expectations', 9, 3, 5, 1861, 'Coming-of-age novel.', 4, 'expectations.png'),
('Murder on the Orient Express', 10, 6, 1, 1934, 'Detective novel featuring Hercule Poirot.', 5, 'orientexpress.png');

-- Thêm dữ liệu mẫu cho LoanHistory (optional)
INSERT INTO LoanHistory (BookId, BorrowerName, LenderName, LoanDate, MustReturnDate, ActualReturnDate) VALUES
(1, 'Alice', NULL, '2025-09-01', '2025-09-15', NULL),
(3, 'Bob', NULL, '2025-08-20', '2025-09-05', '2025-09-04'),
(5, NULL, 'Charlie', '2025-09-10', '2025-09-20', NULL);
