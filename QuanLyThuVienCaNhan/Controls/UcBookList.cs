using QuanLyThuVienCaNhan.Models;
using QuanLyThuVienCaNhan.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyThuVienCaNhan.Manager;
using System.IO;
using QuanLyThuVienCaNhan.ViewModels;

namespace QuanLyThuVienCaNhan.Controls
{
    public partial class UcBookList : UserControl
    {
        private readonly IBookService _bookService;
        public UcBookList(IBookService service)
        {
            InitializeComponent();
            _bookService = service;
        }

        public void LoadBooksToListView()
        {
            Dictionary<int, BookViewModel> bookViewModels = _bookService.GetAllBookViewModels();

            lvBooks.Items.Clear();
            lvBooks.BeginUpdate();

            foreach (BookViewModel bvm in bookViewModels.Values)
            { 
                ListViewItem item = new ListViewItem(bvm.Title);
                item.SubItems.Add(bvm.Author);
                item.SubItems.Add(bvm.Category);
                item.Tag = bvm;
                lvBooks.Items.Add(item);
            }
            lvBooks.EndUpdate();
        }

        public void ShowBookDetails(BookViewModel book)
        {
            string image = PathManager.GetImagePath(book.ImagePath);
            if (File.Exists(image))
            {
                pbBookImage.Image = Image.FromFile(image);
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh: " + image);
            }

            txtPublisher.Text = book.Publisher;
            txtPublishYear.Text = book.PublishYear.ToString();
            txtDescription.Text = book.Description;
            txtLoanStatus.Text = book.Status;
        }

        // Khóa kích thước cho cột của ListView bằng cách đặt lại kích thước và hủy sự kiện
        private void OnLvBooksColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = lvBooks.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBooks.SelectedItems.Count == 0)
                return;

            BookViewModel item = lvBooks.SelectedItems[0].Tag as BookViewModel;

            if (item != null)
            {
                ShowBookDetails(item);
            }
        }
    }
}
