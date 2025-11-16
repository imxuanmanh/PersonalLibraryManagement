using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Repositories;
using PersonalLibraryManagement.Services;

namespace PersonalLibraryManagement
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Chạy async code đồng bộ trước khi start UI
            InitializeAsync().GetAwaiter().GetResult();
        }

        private static async Task InitializeAsync()
        {
            IDbManager dbManager = new DbManager($"Data Source={PathManager.DatabasePath}");

            IAuthorRepository authorRepository = new AuthorRepository(dbManager);
            ICategoryRepository categoryRepository = new CategoryRepository(dbManager);
            IPublisherRepository publisherRepository = new PublisherRepository(dbManager);
            IStorageLocationRepository storageLocationRepository = new StorageLocationRepository(dbManager);
            Repositories.ICirculationRepository circulationRepository = new CirculationRepository(dbManager);

            await Task.WhenAll(
                authorRepository.LoadAsync(),
                categoryRepository.LoadAsync(),
                publisherRepository.LoadAsync(),
                storageLocationRepository.LoadAsync(),
                circulationRepository.LoadAsync()
            );

            Repositories.IBookRepository bookRepository = new BookRepository(
                dbManager, authorRepository,
                categoryRepository,
                publisherRepository,
                storageLocationRepository,
                circulationRepository
            );

            await bookRepository.LoadAsync();

            IAuthorService authorService = new AuthorService(authorRepository);
            Services.IBookService bookService = new BookService(bookRepository);
            ICategoryService categoryService = new CategoryService(categoryRepository);
            IPublisherService publisherService = new PublisherService(publisherRepository);
            IStorageLocationService storageLocationService = new StorageLocationService(storageLocationRepository);
            Services.ICirculationService CirculationService = new CirculationService(bookRepository, circulationRepository);

            MainForm mainForm = new MainForm(
                authorService,
                bookService,
                categoryService,
                publisherService,
                storageLocationService,
                CirculationService
            );

            Application.Run(mainForm);
        }
    }
}