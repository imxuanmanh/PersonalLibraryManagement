using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Repositories;
using QuanLyThuVienCaNhan.Services;

namespace QuanLyThuVienCaNhan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            WorkingContext context = new WorkingContext();
            await context.LoadAsync();

            IBookRepository bookRepository = new BookRepository(context);
            await bookRepository.LoadAsync();

            IBookService bookService = new BookService(bookRepository);

            Application.Run(new MainForm(bookService));


        }
    }
}
