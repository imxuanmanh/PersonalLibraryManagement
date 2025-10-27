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
using System.Threading.Tasks;

namespace PersonalLibraryManagement.Controls
{
    public partial class UcBookList : UserControl, ISearchable
    {
        private readonly IBookService _bookService;
        private readonly ICirculationService _circulationService;

        private Dictionary<int, BookViewModel> _allBookViewModels;

        private ListViewItem _selectedItem;
        private ContextMenuStrip contextMenu;
        public UcBookList(IBookService service, ICirculationService circulationService)
        {
            InitializeComponent();
            _bookService = service;
            _circulationService = circulationService;

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

            switch (book.Status)
            {
                case Enums.CirculationStatus.Avaiable:
                    txtLoanStatus.Text = "Có sẵn";
                    break;

                case Enums.CirculationStatus.Borrowed:
                    txtLoanStatus.Text = "Đang mượn";
                    break;

                case Enums.CirculationStatus.Lent:
                    txtLoanStatus.Text = "Đang cho mượn";
                    break;
            }
            
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

            contextMenu = new ContextMenuStrip();
            contextMenu.Opening += OnContextMenuOpenning;

            lvBooks.ContextMenuStrip = contextMenu;
            lvBooks.MouseDown += OnBookListViewMouseDown;
        }

        private void OnBookListViewMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                _selectedItem = lvBooks.GetItemAt(e.X, e.Y);
            }
        }

        private void OnContextMenuOpenning(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextMenu.Items.Clear();

            if (_selectedItem == null)
            {
                e.Cancel = true;
                return;
            }

            BookViewModel selectedBook = _selectedItem.Tag as BookViewModel;

            if (selectedBook == null)
            {
                return;
            }

            switch (selectedBook.Status)
            {
                case Enums.CirculationStatus.Avaiable:
                    contextMenu.Items.Add(CreateMenuItem("Cho mượn sách", async (s, args) => await LendBook(selectedBook.Id)));
                    break;

                case Enums.CirculationStatus.Borrowed:
                    contextMenu.Items.Add(CreateMenuItem("Trả sách", async (s, args) => await ReturnBook(selectedBook.Id)));
                    break;

                case Enums.CirculationStatus.Lent:
                    contextMenu.Items.Add(CreateMenuItem("Thu hồi sách", async (s, args) => await RecallBook(selectedBook.Id)));
                    break;
            }

        }

        private async Task LendBook(int bookId)
        {
            using (LendForm lendForm = new LendForm())
            {
                if (lendForm.ShowDialog() == DialogResult.OK)
                {
                    int insertId = await _circulationService.LendBookAsync(bookId, lendForm.BorrowerName);

                    if (insertId > 0)
                    {
                        if (_allBookViewModels.TryGetValue(bookId, out var book))
                        {
                            book.Status = Enums.CirculationStatus.Lent;
                        }

                        LoadBooksToListView();

                        if (_selectedItem?.Tag is BookViewModel selectedBook && selectedBook.Id == bookId)
                        {
                            ShowBookDetails(selectedBook);
                        }

                        MessageBox.Show("Cho mượn sách thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Đã xảy ra lỗi");
                    }
                }
            }
        }

        private async Task RecallBook(int bookId)
        {
            bool result = await _circulationService.RecallBookAsync(bookId);

            if (result)
            {
                if (_allBookViewModels.TryGetValue(bookId, out var book))
                {
                    book.Status = Enums.CirculationStatus.Avaiable;
                }

                LoadBooksToListView();

                if (_selectedItem?.Tag is BookViewModel selectedBook && selectedBook.Id == bookId)
                {
                    ShowBookDetails(selectedBook);
                }

                MessageBox.Show("Thu hồi sách thành công!");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi thu hồi sách.");
            }
        }

        private async Task ReturnBook(int bookId)
        {
            bool result = await _circulationService.ReturnBookAsync(bookId);
            if (result)
            {
                _allBookViewModels.Clear();
                LoadAllBookViewModels();
                LoadBooksToListView();

                MessageBox.Show("Trả sách thành công!");
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi trả sách.");
            }
        }

        private ToolStripMenuItem CreateMenuItem(string text, EventHandler onClick)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            item.Click += onClick;
            return item;
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
