using PersonalLibraryManagement.Repositories;
using PersonalLibraryManagement.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PersonalLibraryManagement.Controls
{
    public partial class UcStats : UserControl
    {
        private readonly IBookService _bookService;
        private readonly ICirculationService _circulationService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        public UcStats(IBookService bookService, ICirculationService circulationService, IAuthorService authorService, ICategoryService categoryService)
        {
            InitializeComponent();

            _bookService = bookService;
            _circulationService = circulationService;
            _authorService = authorService;
            _categoryService = categoryService;

            LoadStatistics();
            LoadCategoryChart();
            LoadAuthorChart();
        }

        private void LoadStatistics()
        {
            var books = _bookService.GetAllBooks().ToList();
            var circulations = _circulationService.GetAllCirculations();
            var authors = _authorService.GetAllAuthors();
            var categories = _categoryService.GetAllCategories();

            int totalBooks = books.Count;

            int totalLent = circulations.Values.Count(c =>
                c.ReturnDate == null &&
                !string.IsNullOrEmpty(c.BorrowerName)
            );

            int totalBorrowed = circulations.Values.Count(c =>
                c.ReturnDate == null &&
                !string.IsNullOrEmpty(c.LenderName)
            );

            int totalAuthors = authors.Values.Count;
            int totalCategories = categories.Values.Count;


            txtTotalBook.Text = totalBooks.ToString();
            txtLendBook.Text = totalLent.ToString();
            txtBorrowBook.Text = totalBorrowed.ToString();
            txtAuthor.Text = authors.Count.ToString();
            txtCategory.Text = categories.Count.ToString();

        }
        public void LoadAuthorChart()
        {
            var data = GetAuthorStats();

            pieChartAuthor.Series.Clear();
            pieChartAuthor.ChartAreas.Clear();

            pieChartAuthor.ChartAreas.Add(new ChartArea("ChartArea1"));
            var series = new Series("Authors");
            series.ChartType = SeriesChartType.Pie;

            pieChartAuthor.Series.Add(series);

            foreach (var item in data)
            {
                series.Points.AddXY(item.Label, item.Count);
            }

            series.Label = "#PERCENT";
            series.LegendText = "#VALX";

            pieChartAuthor.Legends.Clear();
            pieChartAuthor.Legends.Add(new Legend("Legend1"));

            pieChartAuthor.Titles.Clear();

            Title authorTitle = new Title();
            authorTitle.Text = "Phân bố sách theo tác giả";
            authorTitle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            authorTitle.Docking = Docking.Bottom;
            authorTitle.Alignment = ContentAlignment.MiddleCenter;

            pieChartAuthor.Titles.Add(authorTitle);
        }

        public void LoadCategoryChart()
        {
            var data = GetCategoryStats();

            pieChartCategory.Series.Clear();
            pieChartCategory.ChartAreas.Clear();

            pieChartCategory.ChartAreas.Add(new ChartArea("ChartArea1"));
            var series = new Series("Categories");
            series.ChartType = SeriesChartType.Pie;

            pieChartCategory.Series.Add(series);

            foreach (var item in data)
            {
                series.Points.AddXY(item.Label, item.Count);
            }

            series.Label = "#PERCENT";
            series.LegendText = "#VALX";

            pieChartCategory.Legends.Clear();
            pieChartCategory.Legends.Add(new Legend("Legend1"));

            pieChartCategory.Titles.Clear();
            Title categoryTitle = new Title();
            categoryTitle.Text = "Phân bố sách theo thể loại";
            categoryTitle.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            categoryTitle.Docking = Docking.Bottom;
            categoryTitle.Alignment = ContentAlignment.MiddleCenter;

            pieChartCategory.Titles.Add(categoryTitle);
        }

        public List<(string Label, int Count)> GetAuthorStats()
        {
            var books = _bookService.GetAllBooks();
            var authors = _authorService.GetAllAuthors();

            var stats = books
                .Where(b => b.AuthorId != null)
                .GroupBy(b => b.AuthorId)
                .Select(g => new
                {
                    AuthorId = g.Key.Value,
                    Count = g.Count()
                })
                .OrderByDescending(a => a.Count)
                .ToList();

            int authorCount = stats.Count;

            if (authorCount <= 5)
            {
                return stats.Select(a => (
                    Label: authors.ContainsKey(a.AuthorId) ? authors[a.AuthorId].Name : "Không rõ",
                    Count: a.Count
                )).ToList();
            }

            var top5 = stats.Take(5)
                .Select(a => (
                    Label: authors.ContainsKey(a.AuthorId) ? authors[a.AuthorId].Name : "Không rõ",
                    Count: a.Count
                )).ToList();

            int othersCount = stats.Skip(5).Sum(a => a.Count);

            top5.Add(("Khác", othersCount));

            return top5;
        }


        public List<(string Label, int Count)> GetCategoryStats()
        {
            var books = _bookService.GetAllBooks();
            var categories = _categoryService.GetAllCategories();

            var stats = books
                .Where(b => b.CategoryId != null)
                .GroupBy(b => b.CategoryId)
                .Select(g => new
                {
                    CategoryId = g.Key.Value,
                    Count = g.Count()
                })
                .OrderByDescending(c => c.Count)
                .ToList();

            int categoryCount = stats.Count;

            if (categoryCount <= 5)
            {
                return stats.Select(c => (
                    Label: categories.ContainsKey(c.CategoryId) ? categories[c.CategoryId].Name : "Không rõ",
                    Count: c.Count
                )).ToList();
            }

            var top5 = stats.Take(5)
                .Select(c => (
                    Label: categories.ContainsKey(c.CategoryId) ? categories[c.CategoryId].Name : "Không rõ",
                    Count: c.Count
                ))
                .ToList();

            int othersCount = stats.Skip(5).Sum(c => c.Count);

            top5.Add(("Khác", othersCount));

            return top5;
        }

    }
}
