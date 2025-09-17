using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Repositories
{
    public class InMemoryBookStorage : IBookStorage
    {
        private readonly Dictionary<int, Book> _books = new Dictionary<int, Book>();
        private int _nextId = 1; // auto-increment Id

        public InMemoryBookStorage()
        {
            // Thêm dữ liệu giả để test nhanh
            Insert(new Book("Clean Code", "Robert C. Martin", "Programming")
            {
                Description = "A Handbook of Agile Software Craftsmanship",
                ImagePath = PathManager.GetImagePath("clean-code.jpg") // tùy chọn
            });


            Insert(new Book("The Pragmatic Programmer", "Andrew Hunt", "Programming")
            {

                Description = "Your Journey to Mastery",
            });

            Insert(new Book("Design Patterns", "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides", "Programming")
            {
                Description = "Elements of Reusable Object-Oriented Software",
                ImagePath = PathManager.GetImagePath("design-patterns.png")
            });

            Insert(new Book("Bạn trẻ đời thường", "Tác giả A", "Novel"));
            Insert(new Book("Lịch sử Việt Nam", "Tác giả B", "History"));
            Insert(new Book("Cơ sở dữ liệu", "Tác giả C", "Database"));
            Insert(new Book("Lập trình C# nâng cao", "Tác giả D", "Programming"));
            Insert(new Book("Toán học rèn luyện tư duy", "Tác giả E", "Mathematics"));
            Insert(new Book("Văn hóa Đông Nam Á", "Tác giả F", "Culture"));
            Insert(new Book("Thiết kế web cơ bản", "Tác giả G", "Web Development"));
            Insert(new Book("Kỹ năng giao tiếp hiệu quả", "Tác giả H", "Self-Help"));
            Insert(new Book("Truyện ngắn hiện đại", "Tác giả I", "Fiction"));
            Insert(new Book("Khoa học máy tính cho người mới", "Tác giả J", "Computer Science"));
            Insert(new Book("Du lịch Việt Nam", "Tác giả K", "Travel"));
            Insert(new Book("Âm nhạc cổ điển", "Tác giả L", "Music"));

        }

        public Dictionary<int, Book> LoadData()
        {
            // Trả về bản sao để tránh sửa trực tiếp ngoài ý muốn
            return new Dictionary<int, Book>(_books);
        }

        public void Insert(Book book)
        {
            if (book.Id == 0) // nếu chưa có Id thì tự gán
            {
                book.Id = _nextId++;
            }
            else if (_books.ContainsKey(book.Id))
            {
                throw new InvalidOperationException($"Book with Id {book.Id} already exists.");
            }

            _books[book.Id] = book;
        }

        public void Update(Book book)
        {
            if (!_books.ContainsKey(book.Id))
            {
                throw new KeyNotFoundException($"Book with Id {book.Id} not found.");
            }
            _books[book.Id] = book;
        }

        public void Delete(int bookId)
        {
            if (!_books.ContainsKey(bookId))
            {
                throw new KeyNotFoundException($"Book with Id {bookId} not found.");
            }
            _books.Remove(bookId);
        }
    }
}
