using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalLibraryManagement.Enums;
using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.ViewModels;
using Microsoft.Data.Sqlite;

namespace PersonalLibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbManager _dbManager;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IStorageLocationRepository _storageLocationRepository;
        private readonly ICirculationRepository _CirculationRepository;

        private Dictionary<int, Book> _books;
        public IReadOnlyDictionary<int, Book> Books => _books;

        public BookRepository(
            IDbManager dbManager,
            IAuthorRepository authorRepository,
            ICategoryRepository categoryRepository,
            IPublisherRepository publisherRepository,
            IStorageLocationRepository storageLocationRepository,
            ICirculationRepository CirculationRepository
            )
        {
            _dbManager = dbManager;
            _authorRepository = authorRepository;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _storageLocationRepository = storageLocationRepository;
            _CirculationRepository = CirculationRepository;

            _books = new Dictionary<int, Book>();
        }

        public Book GetBookById(int id)
        {
            return _books.ContainsKey(id) ? _books[id] : null;
        }

        public async Task<int> AddAsync(Book book)
        {
            string query = @"
                INSERT INTO Book (Title, AuthorId, CategoryId, PublisherId, PublishYear, Description, StorageLocationId, ImagePath)
                VALUES (@Title, @AuthorId, @CategoryId, @PublisherId, @PublishYear, @Description, @StorageLocationId, @ImagePath);

                SELECT last_insert_rowid();
            ";

            var parameters = new[]
            {
                new SqliteParameter("@Title", book.Title),
                new SqliteParameter("@AuthorId", book.AuthorId ?? (object)DBNull.Value),
                new SqliteParameter("@CategoryId", book.CategoryId ?? (object)DBNull.Value),
                new SqliteParameter("@PublisherId", book.PublisherId ?? (object)DBNull.Value),
                new SqliteParameter("@PublishYear", book.PublishYear?? (object)DBNull.Value),
                new SqliteParameter("@Description", book.Description ?? (object)DBNull.Value),
                new SqliteParameter("@StorageLocationId", book.StorageLocationId),
                new SqliteParameter("@ImagePath", book.ImagePath ?? (object)DBNull.Value)
            };

            int newId = await _dbManager.ExecuteScalarAsync<int>(query, parameters);

            if (newId > 0)
            {   
                book.Id = newId;
                _books[newId] = book;
                return newId;
            }
            return -1;
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

            int affectedRows = await _dbManager.ExecuteNonQueryAsync(query, parameters);

            if (affectedRows > 0)
            {
                _books[book.Id] = book;
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(int bookId)
        {

            int affectedRows = await _dbManager.ExecuteNonQueryAsync(@"DELETE FROM Book WHERE Id = @Id", new SqliteParameter("@Id", bookId));
           
            if (affectedRows > 0)
            {
                _books.Remove(bookId);
                return true;
            }

            return false;
        }

        public async Task LoadAsync()
        {
            _books = await _dbManager.ExecuteQueryAsync<Book>("SELECT * FROM Book");
            System.Diagnostics.Debug.WriteLine($"Tong {_books.Count} cuon sach");
        }

        public IEnumerable<Book> GetAll()
        {
            return _books.Values.ToList();
        }

        public Dictionary<int, BookViewModel> GetAllBookViewModels()
        {
            var authors = _authorRepository.GetAllAuthors();
            var categories = _categoryRepository.GetAllCategories();
            var publishers = _publisherRepository.GetAllPublishers();

            return _books.ToDictionary(
                pair => pair.Key,
                pair =>
                {
                    var book = pair.Value;

                    string authorName = authors.TryGetValue(book.AuthorId ?? -1, out var author) ? author.Name : "Không rõ";
                    string categoryName = categories.TryGetValue(book.CategoryId ?? -1, out var category) ? category.Name : "Không rõ";
                    string publisherName = publishers.TryGetValue(book.PublisherId ?? -1, out var publisher) ? publisher.Name : "Không rõ";
                    string storageLocationName = _storageLocationRepository.GetStorageLocationById(book.StorageLocationId);
                    CirculationStatus status = _CirculationRepository.GetStatusByBookId(book.Id);

                    return new BookViewModel(
                        book.Id,
                        book.Title,
                        authorName,
                        categoryName,
                        publisherName,
                        book.PublishYear, 
                        book.ImagePath,
                        book.Description,
                        status,
                        storageLocationName
                    );
                }
            );
        }

    }
}
