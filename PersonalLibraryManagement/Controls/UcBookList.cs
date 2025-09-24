using PersonalLibraryManagement.Models;
using PersonalLibraryManagement.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PersonalLibraryManagement.Manager;
using System.IO;
using PersonalLibraryManagement.ViewModels;
using PersonalLibraryManagement.Interfaces;

namespace PersonalLibraryManagement.Controls
{
    public partial class UcBookList : UserControl, ISearchable
    {
        private readonly IBookService _bookService;

        private Dictionary<int, BookViewModel> _allBookViewModels;
        public UcBookList(IBookService service)
        {
            InitializeComponent();
            _bookService = service;
            LoadAllBookViewModels();
        }

        private void LoadAllBookViewModels()
        {
            _allBookViewModels = _bookService.GetAllBookViewModels();
        }

        public void LoadBooksToListView()
        {
            lvBooks.Items.Clear();
            lvBooks.BeginUpdate();

            foreach (BookViewModel bvm in _allBookViewModels.Values)
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
                pbBookImage.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show("Không tìm thấy ảnh: " + image);
            }

            txtPublisher.Text = book.Publisher;
            txtPublishYear.Text = book.PublishYear.ToString();
            txtDescription.Text = book.Description;
            txtStorageLocation.Text = book.StorageLocation;
            txtLoanStatus.Text = book.Status;
        }

        public void Filter(string searchText)
        {
            string keyword = searchText?.Trim().ToLower() ?? "";

            if (string.IsNullOrEmpty(keyword))
            {
                LoadBooksToListView();
            }

            lvBooks.BeginUpdate();
            lvBooks.Items.Clear();

            foreach (BookViewModel bvm in _allBookViewModels.Values)
            {
                if (bvm.Title.ToLower().Contains(keyword))
                {
                    ListViewItem item = new ListViewItem(bvm.Title);
                    item.SubItems.Add(bvm.Author);
                    item.SubItems.Add(bvm.Category);
                    item.Tag = bvm;
                    lvBooks.Items.Add(item);
                }
            }
            lvBooks.EndUpdate();
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
                if (panelBookProperties.Visible == false)
                {
                    panelBookProperties.Visible = true;
                    pbBackground.Visible = false;
                }

                ShowBookDetails(item);
            }
        }

        private void OnBookListUCLoad(object sender, EventArgs e)
        {
            panelBookProperties.Visible = false;
            pbBackground.Visible = true;
        }

        public void HideBookProperties()
        {
            panelBookProperties.Visible = false;
            pbBackground.Visible = true;
        }

        private void OnCloseBookPropertiesBtnClick(object sender, EventArgs e)
        {
            HideBookProperties();
            lvBooks.SelectedItems.Clear();
        }
    }
}
