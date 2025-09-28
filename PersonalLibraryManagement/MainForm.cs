using PersonalLibraryManagement.Controls;
using PersonalLibraryManagement.Interfaces;
using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Models;
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

namespace PersonalLibraryManagement
{
    public partial class MainForm : Form
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IPublisherService _publisherService;
        private readonly IStorageLocationService _storageLocationService;
        private readonly ICirculationService _CirculationService;

        private UserControl _currentControl;
        private Timer _debounceTimer;

        private string PlaceholderText = "Nhập từ khóa ...";

        public MainForm(IAuthorService authorService,
                        IBookService bookService, 
                        ICategoryService categoryService,
                        IPublisherService publisherService,
                        IStorageLocationService storageLocationService,
                        ICirculationService CirculationService)
        {
            InitializeComponent();

            _authorService = authorService;
            _bookService = bookService;
            _categoryService = categoryService;
            _publisherService = publisherService;
            _storageLocationService = storageLocationService;
            _CirculationService = CirculationService;
        }
        public MainForm( IBookService bookService)
        {
            InitializeComponent();

            _bookService = bookService;
        }

        private void ShowUserControl(UserControl uc)
        {
            if (_currentControl != null)
            {
                panelRightView.Controls.Remove(_currentControl);
                _currentControl.Dispose();
                _currentControl = null;
            }



            _currentControl = uc;
            panelRightView.Controls.Add(_currentControl);

            // Reset search box mỗi lần đổi control
            txtSearchBox.Text = "";
            SetSearchBoxPlaceHolder();
        }

        private void LoadCategoryGroupBox()
        {
            Dictionary<int, Category> categories = _categoryService.GetAllCategories();

            // Chuyển sang Dictionary<int, string> với key là Id, value là Name
            Dictionary<int, string> categoryNames = categories.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Name
            );

            int x = 5; // vị trí bắt đầu theo trục X
            int y = 5; // vị trí bắt đầu theo trục Y
            int count = 0; // đếm số nút trong 1 hàng

            int buttonWidth = 110; // chiều rộng nút
            int buttonHeight = 30; // chiều cao nút
            int spacing = 7; // khoảng cách giữa các nút

            foreach (var pair in categoryNames)
            {
                Button btn = new Button();
                btn.Text = pair.Value; // hiển thị tên category
                btn.Tag = pair.Key;    // lưu Id vào Tag để sử dụng khi click
                btn.Size = new Size(buttonWidth, buttonHeight);
                btn.Location = new Point(x, y);
                btn.Font = new Font("Times New Roman", 10);
                btn.Click += OnCategoryButtonClick;

                pnCategoryList.Controls.Add(btn);

                count++;

                if (count % 2 == 0) // đủ 2 nút thì xuống dòng
                {
                    x = 5;
                    y += buttonHeight + spacing;
                }
                else
                {
                    x += buttonWidth + spacing; // đặt nút tiếp theo bên phải
                }
            }
        }


        private void OnBtnLendBorrowCtrlClick(object sender, EventArgs e)
        {
            ShowUserControl(new UcLendBorrowManager());
        }

        private void OnBtnBookManagerClick(object sender, EventArgs e)
        {
            UcBookList uc = new UcBookList(_bookService);
            uc.LoadBooksToListView();

            ShowUserControl(uc);
        }

        private void OnBtnAddBookClick(object sender, EventArgs e)
        {
            ShowUserControl(new UcAddBook(_bookService, _categoryService, _authorService, _publisherService, _storageLocationService, _CirculationService));
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // MessageBox.Show(PathManager.ImageDir);
            LoadCategoryGroupBox();
            this.ActiveControl = null;
            SetSearchBoxPlaceHolder();
            txtSearchBox.TextChanged += OnSearchBoxTextChanged;

            // Mở mặc định danh sách sách
            OnBtnBookManagerClick(null, EventArgs.Empty);
        }

        private void OnBtnStatsClick(object sender, EventArgs e)
        {
            ShowUserControl(new UcStats());
        }

        private void OnCategoryButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null) return;

            string category = btn.Text;
            MessageBox.Show("Bạn đã chọn thể loại: " + category);
        }

        private void OnSearchBoxTextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.ForeColor == Color.Gray) return;

            if (_debounceTimer == null)
            {
                _debounceTimer = new System.Windows.Forms.Timer();
                _debounceTimer.Interval = 300; // 300ms
                _debounceTimer.Tick += (s, args) =>
                {
                    _debounceTimer.Stop();

                    // ❌ Bỏ qua khi text là placeholder
                    if (txtSearchBox.Text == PlaceholderText) return;

                    if (_currentControl is ISearchable searchable)
                    {
                        searchable.Filter(txtSearchBox.Text);
                    }
                };
            }

            _debounceTimer.Stop();
            _debounceTimer.Start();
        }

        private void SetSearchBoxPlaceHolder()
        {
            txtSearchBox.TextChanged -= OnSearchBoxTextChanged;
            txtSearchBox.Text = PlaceholderText;
            txtSearchBox.ForeColor = Color.Gray;
            txtSearchBox.TextChanged += OnSearchBoxTextChanged;
        }

        private void RemoveSearchBoxPlaceholder()
        {
            txtSearchBox.TextChanged -= OnSearchBoxTextChanged;
            if (txtSearchBox.Text == PlaceholderText)
                txtSearchBox.Text = "";
            txtSearchBox.ForeColor = Color.Black;
            txtSearchBox.TextChanged += OnSearchBoxTextChanged;
        }

        private void OnSearchBoxEnter(object sender, EventArgs e)
        {
            RemoveSearchBoxPlaceholder();
        }

        private void OnSearchBoxLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBox.Text))
            {
                SetSearchBoxPlaceHolder();
            }
        }
    }
}
