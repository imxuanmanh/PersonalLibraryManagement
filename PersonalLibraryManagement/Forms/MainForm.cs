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
        private readonly ICirculationService _circulationService;

        private UserControl _currentControl;
        private Timer _debounceTimer;

        private string PlaceholderText = "Nhập từ khóa ...";
        private string _currentKeyword = "";
        private string _currentCategory = "";
        private string _currentAuthor = "";

        public event EventHandler<string> SearchTextChanged;

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
            _circulationService = CirculationService;
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

            Dictionary<int, string> categoryNames = categories.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.Name
            );

            int x = 5;
            int y = 5;
            int count = 0;

            int buttonWidth = 110;
            int buttonHeight = 30;
            int spacing = 7;

            // --- Nút "Tất cả"
            Button btnAll = new Button();
            btnAll.Text = "Tất cả";
            btnAll.Size = new Size(buttonWidth, buttonHeight);
            btnAll.Location = new Point(x, y);
            btnAll.Font = new Font("Times New Roman", 10);
            btnAll.Click += (s, e) =>
            {
                _currentCategory = "";
                if (_currentControl is UcBookList ucBookList)
                {
                    ucBookList.Filter(_currentKeyword, _currentCategory, null);
                }
            };
            pnCategoryList.Controls.Add(btnAll);

            // Cập nhật toạ độ sau khi thêm nút "Tất cả"
            count = 1;
            x += buttonWidth + spacing;

            // --- Thêm các nút thể loại
            foreach (var pair in categoryNames)
            {
                Button btn = new Button();
                btn.Text = pair.Value;
                btn.Tag = pair.Key;
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
                    x += buttonWidth + spacing;
                }
            }
        }

        private void OnBtnLendBorrowCtrlClick(object sender, EventArgs e)
        {
            gbCategoryList.Visible = false;
            txtSearchBox.Enabled = true;
            ShowUserControl(new UcLendBorrowManager(_circulationService));
        }

        private void OnBtnBookManagerClick(object sender, EventArgs e)
        {
            UcBookList uc = new UcBookList(_bookService, _circulationService);
            uc.LoadBooksToListView();
            gbCategoryList.Visible = true;
            txtSearchBox.Enabled = true;
            ShowUserControl(uc);
        }

        private void OnBtnAddBookClick(object sender, EventArgs e)
        {
            gbCategoryList.Visible = false;
            txtSearchBox.Enabled = false;
            ShowUserControl(new UcAddBook(_bookService, _categoryService, _authorService, _publisherService, _storageLocationService, _circulationService));
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            LoadCategoryGroupBox();
            this.ActiveControl = null;
            SetSearchBoxPlaceHolder();
            txtSearchBox.TextChanged += OnSearchBoxTextChanged;

            OnBtnBookManagerClick(null, EventArgs.Empty);
        }

        private void OnBtnStatsClick(object sender, EventArgs e)
        {
            ShowUserControl(new UcStats(_bookService, _circulationService, _authorService, _categoryService));
            gbCategoryList.Visible = false;
            txtSearchBox.Enabled = false;
        }

        private void OnCategoryButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null) return;

            _currentCategory = btn.Text;

            string category = btn.Text;
            // MessageBox.Show("Bạn đã chọn thể loại: " + category);

            if (_currentControl is UcBookList ucBookList)
            {
                ucBookList.Filter(_currentKeyword, _currentCategory, _currentAuthor);
            }
        }

        private void OnSearchBoxTextChanged(object sender, EventArgs e)
        {
            if (txtSearchBox.ForeColor == Color.Gray) return;

            if (_currentControl is UcLendBorrowManager ucLendBorrow)
            {
                ucLendBorrow.OnSearchKeywordChanged(txtSearchBox.Text.Trim());
            }

            if (_debounceTimer == null)
            {
                _debounceTimer = new System.Windows.Forms.Timer();
                _debounceTimer.Interval = 300; // 300ms
                _debounceTimer.Tick += (s, args) =>
                {
                    _debounceTimer.Stop();

                    // ❌ Bỏ qua khi text là placeholder
                    if (txtSearchBox.Text == PlaceholderText) return;

                    _currentKeyword = txtSearchBox.Text.Trim();

                    SearchTextChanged?.Invoke(this, _currentKeyword);

                    if (_currentControl is UcBookList ucBookList)
                    {
                        ucBookList.Filter(_currentKeyword, _currentCategory, _currentAuthor);
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
