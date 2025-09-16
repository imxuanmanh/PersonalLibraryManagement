using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Models;
using QuanLyThuVienCaNhan.ViewModels;
using Microsoft.Data.Sqlite;

namespace QuanLyThuVienCaNhan.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly WorkingContext _context;

        private Dictionary<int, Book> _books;
        public IReadOnlyDictionary<int, Book> Books => _books;

        public BookRepository(WorkingContext context)
        {
            _context = context;

            _books = new Dictionary<int, Book>();
        }

        public Book GetBookById(int id)
        {
            return _books.ContainsKey(id) ? _books[id] : null;
        }

        public async Task<bool> AddAsync(Book book)
        {
            string query = @"
                INSERT INTO Book (Title, AuthorId, CategoryId, PublisherId, PublishYear, Description, StorageLocationId, ImagePath)
                VALUES (@Title, @AuthorId, @CategoryId, @PublisherId, @PublishYear, @Description, @StorageLocationId, @ImagePath);

                SELECT last_insert_rowid();
            ";

            var parameters = new[]
            {
                new SqliteParameter("@Title", book.Title),
                new SqliteParameter("@AuthorId", book.AuthorId),
                new SqliteParameter("@CategoryId", book.CategoryId),
                new SqliteParameter("@PublisherId", book.PublisherId),
                new SqliteParameter("@PublishYear", book.PublishYear),
                new SqliteParameter("@Description", book.Description ?? (object)DBNull.Value),
                new SqliteParameter("@StorageLocationId", book.StorageLocationId),
                new SqliteParameter("@ImagePath", book.ImagePath ?? (object)DBNull.Value)
            };

            int newId = await _context.DbManager.ExecuteScalarAsync<int>(query, parameters);

            if (newId > 0)
            {   
                book.Id = newId;
                _books[newId] = book;
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            string query = @"
                UPDATE Book
                SET 
                    Title = @Title, 
                    AuthorId = @AuthorId, 
                    CategoryId = @CategoryId, 
                    PublisherId = @PublisherId, 
                    PublishYear = @PublishYear, 
                    Description = @Description, 
                    StorageLocationId = @StorageLocationId, 
                    ImagePath = @ImagePath
                WHERE Id = @Id
                ";

            var parameters = new[]
            {
                new SqliteParameter("@Id", book.Id),
                new SqliteParameter("@Title", book.Title),
                new SqliteParameter("@AuthorId", book.AuthorId),
                new SqliteParameter("@CategoryId", book.CategoryId),
                new SqliteParameter("@PublisherId", book.PublisherId),
                new SqliteParameter("@PublishYear", book.PublishYear),
                new SqliteParameter("@Description", book.Description ?? (object)DBNull.Value),
                new SqliteParameter("@StorageLocationId", book.StorageLocationId),
                new SqliteParameter("@ImagePath", book.ImagePath ?? (object)DBNull.Value)
            };

            int affectedRows = await _context.DbManager.ExecuteNonQueryAsync(query, parameters);

            if (affectedRows > 0)
            {
                _books[book.Id] = book;
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int bookId)
        {

            int affectedRows = await _context.DbManager.ExecuteNonQueryAsync(@"DELETE FROM Book WHERE Id = @Id", new SqliteParameter("@Id", bookId));
           
            if (affectedRows > 0)
            {
                _books.Remove(bookId);
                return true;
            }

            return false;
        }

        public async Task LoadAsync()
        {
            _books = await _context.DbManager.ExecuteQueryAsync<Book>("SELECT * FROM Book");
            System.Diagnostics.Debug.WriteLine($"Tong {_books.Count} cuon sach");
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.Values.ToList();
        }

        public Dictionary<int, BookViewModel> GetAllBookViewModels()
        {
            return _books.ToDictionary(
                pair => pair.Key,
                pair => new BookViewModel
                (
                    pair.Value.Id,
                    pair.Value.Title,
                    _context.Authors.GetAllAuthors().TryGetValue(pair.Value.AuthorId, out var author) ? author.Name : "Unknown",
                    _context.Categories.GetAllCategories().TryGetValue(pair.Value.CategoryId, out var category) ? category.Name : "Unknown",
                    _context.Publishers.GetAllPublishers().TryGetValue(pair.Value.PublisherId, out var publisher) ? publisher.Name : "Unknown",
                    pair.Value.PublishYear,
                    pair.Value.ImagePath,
                    pair.Value.Description,
                    _context.LoanHistories.GetStatusByBookId(pair.Value.Id),
                    _context.StorageLocations.GetAllStorageLocations().TryGetValue(pair.Value.StorageLocationId, out var storageLocation) ? storageLocation.ToString() : "Unknown"
                )
             );
        }
    }
}
