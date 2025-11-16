using PersonalLibraryManagement.Models;
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

namespace PersonalLibraryManagement.Controls
{
    public partial class UcLendBorrowManager : UserControl
    {
        private readonly ICirculationService _circulationService;

        // private Dictionary<int, Circulation> _allCirculationBooks;
        public UcLendBorrowManager(ICirculationService circulationService)
        {
            InitializeComponent();
            _circulationService = circulationService;
        }

        private void OnLendBorrowManagerUCLoad(object sender, EventArgs e)
        {
            LoadCirculationData();
        }

        private void LoadCirculationData()
        {
            LoadBorrowBooks();
            LoadLendBooks();
            LoadHistory();
        }

        private void LoadBorrowBooks()
        {
            var borrowBooks = _circulationService.GetAllCirculations().Values
                                            .Where(c=>
                                                    string.IsNullOrEmpty(c.BorrowerName) &&
                                                    c.ReturnDate == null)
                                            .ToList();

            lvBorrowBook.BeginUpdate();
            lvBorrowBook.Items.Clear();

            int stt = 1;

            foreach(var book in borrowBooks)
            {
                ListViewItem item = new ListViewItem(stt.ToString());

                item.SubItems.Add(book.BookTitleSnapshot);
                item.SubItems.Add(book.LenderName);
                item.SubItems.Add(book.CirculationDate.ToString("dd/MM/yyyy"));

                item.Tag = book;

                lvBorrowBook.Items.Add(item);

                stt++;
            }

            lvBorrowBook.EndUpdate();
        }

        private void LoadLendBooks()
        {
            var lendBooks = _circulationService.GetAllCirculations().Values
                                            .Where(c =>
                                                    string.IsNullOrEmpty(c.LenderName) &&
                                                    c.ReturnDate == null)
                                            .ToList();

            lvLendBook.BeginUpdate();
            lvLendBook.Items.Clear();

            int stt = 1;

            foreach (var book in lendBooks)
            {
                ListViewItem item = new ListViewItem(stt.ToString());

                item.SubItems.Add(book.BookTitleSnapshot);
                item.SubItems.Add(book.BorrowerName);
                item.SubItems.Add(book.CirculationDate.ToString("dd/MM/yyyy"));

                item.Tag = book;

                lvLendBook.Items.Add(item);

                stt++;
            }

            lvLendBook.EndUpdate();
        }

        private void LoadHistory()
        {
            var histories = _circulationService.GetAllCirculations().Values
                                            .Where(c =>
                                                    (!string.IsNullOrEmpty(c.BorrowerName) || !string.IsNullOrEmpty(c.LenderName)) &&
                                                    c.ReturnDate != null)

                                            .ToList();

            lvHistory.BeginUpdate();
            lvHistory.Items.Clear();

            int stt = 1;

            foreach (var book in histories)
            {
                ListViewItem item = new ListViewItem((book.BorrowerName == null) ? "Mượn" : "Cho mượn");

                item.SubItems.Add(book.BookTitleSnapshot);
                item.SubItems.Add(book.BorrowerName ?? book.LenderName ?? "");
                item.SubItems.Add(book.CirculationDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(((DateTime)book.ReturnDate).ToString("dd/MM/yyyy"));


                item.Tag = book;

                lvHistory.Items.Add(item);

                stt++;
            }

            lvHistory.EndUpdate();
        }

        private void OnLvBooksColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            ListView lv = sender as ListView;
            e.NewWidth = lv.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }
        public void OnSearchKeywordChanged(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                // Nếu rỗng, load lại toàn bộ
                LoadCirculationData();
                return;
            }

            string lowerKeyword = keyword.ToLower();

            // Lọc BorrowBooks
            var borrowBooks = _circulationService.GetAllCirculations().Values
                .Where(c => string.IsNullOrEmpty(c.BorrowerName) && c.ReturnDate == null)
                .Where(c => (c.BookTitleSnapshot ?? "").ToLower().Contains(lowerKeyword) ||
                            (c.LenderName ?? "").ToLower().Contains(lowerKeyword))
                .ToList();

            lvBorrowBook.BeginUpdate();
            lvBorrowBook.Items.Clear();
            int stt = 1;
            foreach (var book in borrowBooks)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(book.BookTitleSnapshot);
                item.SubItems.Add(book.LenderName);
                item.SubItems.Add(book.CirculationDate.ToString("dd/MM/yyyy"));
                item.Tag = book;
                lvBorrowBook.Items.Add(item);
                stt++;
            }
            lvBorrowBook.EndUpdate();

            // Lọc LendBooks
            var lendBooks = _circulationService.GetAllCirculations().Values
                .Where(c => string.IsNullOrEmpty(c.LenderName) && c.ReturnDate == null)
                .Where(c => (c.BookTitleSnapshot ?? "").ToLower().Contains(lowerKeyword) ||
                            (c.BorrowerName ?? "").ToLower().Contains(lowerKeyword))
                .ToList();

            lvLendBook.BeginUpdate();
            lvLendBook.Items.Clear();
            stt = 1;
            foreach (var book in lendBooks)
            {
                ListViewItem item = new ListViewItem(stt.ToString());
                item.SubItems.Add(book.BookTitleSnapshot);
                item.SubItems.Add(book.BorrowerName);
                item.SubItems.Add(book.CirculationDate.ToString("dd/MM/yyyy"));
                item.Tag = book;
                lvLendBook.Items.Add(item);
                stt++;
            }
            lvLendBook.EndUpdate();

            /*
            // Lọc History
            var histories = _circulationService.GetAllCirculations().Values
                .Where(c => (!string.IsNullOrEmpty(c.BorrowerName) || !string.IsNullOrEmpty(c.LenderName)) &&
                            c.ReturnDate != null)
                .Where(c => (c.BookTitleSnapshot ?? "").ToLower().Contains(lowerKeyword) ||
                            (c.BorrowerName ?? "").ToLower().Contains(lowerKeyword) ||
                            (c.LenderName ?? "").ToLower().Contains(lowerKeyword))
                .ToList();

            lvHistory.BeginUpdate();
            lvHistory.Items.Clear();
            stt = 1;
            foreach (var book in histories)
            {
                ListViewItem item = new ListViewItem((book.BorrowerName == null) ? "Mượn" : "Cho mượn");
                item.SubItems.Add(book.BookTitleSnapshot);
                item.SubItems.Add(book.BorrowerName ?? book.LenderName ?? "");
                item.SubItems.Add(book.CirculationDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(((DateTime)book.ReturnDate).ToString("dd/MM/yyyy"));
                item.Tag = book;
                lvHistory.Items.Add(item);
                stt++;
            }
            lvHistory.EndUpdate();
            */
        }
    }

}
