using PersonalLibraryManagement.Services;
using PersonalLibraryManagement.Models;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using PersonalLibraryManagement.Manager;
using PersonalLibraryManagement.Interfaces;

namespace PersonalLibraryManagement.Controls
{
    public partial class UcAddBook : UserControl
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _pulisherService;
        private readonly IStorageLocationService _storageLocationService;
        private readonly ILoanHistoryService _loanHistoryService;

        public string SelectedImageName { get; private set; } = null;
        public string SelectedImagePath { get; private set; } = null;
        private List<StorageLocation> _storageLocations;


        public UcAddBook(
            IBookService bookService,
            ICategoryService categoryService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IStorageLocationService storageLocationService,
            ILoanHistoryService loanHistoryService
            )
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _pulisherService = publisherService;
            _storageLocationService = storageLocationService;
            _loanHistoryService = loanHistoryService;
        }

        private void SetupCategoryComboBox()
        {
            var categories = _categoryService.GetAllCategories().Values.ToList();
            categories.Insert(0, new Category { Id = 0, Name = "-- Thể loại --" });
            categories.Add(new Category { Id = -1, Name = "➕Thêm thể loại" });
            cboCategory.DataSource = categories;
            cboCategory.DisplayMember = "Name";
            cboCategory.ValueMember = "Id";

            cboCategory.Tag = "Category";
        }
        private void SetupAuthorComboBox()
        {
            var authors = _authorService.GetAllAuthors().Values.ToList();
            authors.Insert(0, new Author { Id = 0, Name = "-- Tác giả --" });
            authors.Add(new Author { Id = -1, Name = "➕Thêm tác giả" });
            cboAuthor.DataSource = authors;
            cboAuthor.DisplayMember = "Name";
            cboAuthor.ValueMember = "Id";

            cboAuthor.Tag = "Author";
        }
        private void SetupPublisherComboBox()
        {
            var publishers = _pulisherService.GetAllPublishers().Values.ToList();
            publishers.Insert(0, new Publisher { Id = 0, Name = "-- Nhà xuất bản --" });
            publishers.Add(new Publisher { Id = -1, Name = "➕Thêm nhà xuất bản" });
            cboPublisher.DataSource = publishers;
            cboPublisher.DisplayMember = "Name";
            cboPublisher.ValueMember = "Id";

            cboPublisher.Tag = "Publisher";
        }
        private void SetupStorageLocationComboBox()
        {
            var storageLocations = _storageLocationService.GetAllStorageLocations();
            var rooms = storageLocations.Values.Select(r => r.Room).Distinct().ToList();
            var shelves = storageLocations.Values.Select(s => s.Shelf).Distinct().ToList();
            var rows = storageLocations.Values.Select(s => s.Row).Distinct().ToList();

            rooms.Insert(0, "-- Phòng --");
            rooms.Add("➕Thêm phòng");
            shelves.Insert(0, "-- Kệ --");
            shelves.Add("➕Thêm kệ");
            rows.Insert(0, "-- Hàng --");
            rows.Add("➕Thêm hàng");

            cboRoom.DataSource = rooms;
            cboShelf.DataSource = shelves;
            cboRow.DataSource = rows;

            cboRoom.Tag = "Room";
            cboShelf.Tag = "Shelf";
            cboRow.Tag = "Row";
        }

        private void OnAddBookUCLoad(object sender, EventArgs e)
        {
            SetupAuthorComboBox();
            SetupCategoryComboBox();
            SetupPublisherComboBox();
            SetupStorageLocationComboBox();

            OnIsBorrowedCheckBoxCheckedChanged(null, EventArgs.Empty);
        }

        private void OnIsBorrowedCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (chkIsBorrowed.Checked == false)
            {
                txtLender.Enabled = false;
                dtpExpectedReturnDate.Enabled = false;
            }
            else
            {
                txtLender.Enabled = true;
                dtpExpectedReturnDate.Enabled = true;
            }
        }

        private async void OnComboBoxSelectedIndexChange(object sender, EventArgs e)
        {
            ComboBox cbo = sender as ComboBox;
            if (cbo == null)
                return;

            string tag = cbo.Tag?.ToString() ?? "";

            if (cbo.SelectedValue == null)
                return;

            if (cbo.SelectedValue.ToString() != "-1")
                return;

            string title = string.Empty;

            string header = string.Empty;

            switch (tag)
            {
                case "Author":
                    {
                        title = "Thêm tác giả";
                        header = "Tên tác giả";
                    }

                    break;

                case "Category":
                    {
                        title = "Thêm thể loại";
                        header = "Tên thể loại";
                    }
                    break;

                case "Publisher":
                    {
                        title = "Thêm nhà xuất bản";
                        header = "Tên nhà xuất bản";
                    }
                    break;

                case "Room":
                    {
                        title = "Thêm phòng";
                        header = "Tên phòng";
                    }
                    break;

                case "Shelf":
                    {
                        title = "Thêm kệ";
                        header = "Số kệ";
                    }
                    break;

                case "Row":
                    {
                        title = "Thêm hàng";
                        header = "Số hàng";
                    }
                    break;
            }

            using (FormAddItem form = new FormAddItem(title, header))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string value = form.Result;

                    await AddNewItemToComboBoxAsync(tag, form.Result);
                }
            }
        }

        private async Task AddNewItemToComboBoxAsync(string comboBoxTag, string value)
        {
            switch (comboBoxTag)
            {
                case "Author":
                    {
                        await _authorService.AddAuthorAsync(new Author { Name = value });
                        SetupAuthorComboBox();
                    }

                    break;

                case "Category":
                    {

                    }
                    break;

                case "Publisher":
                    {

                    }
                    break;

                case "Room":
                    {

                    }
                    break;

                case "Shelf":
                    {

                    }
                    break;

                case "Row":
                    {

                    }
                    break;
            }
        }

        private /*async */ void OnAddBookButtonClick(object sender, EventArgs e)
        {
            // if (string.IsNullOrEmpty(txtTittle.Text))
            // {
            //     MessageBox.Show("Tiêu đề sách không thể trống!");
            //     return;
            // }

            // if
            // (
            //     cboRoom.SelectedIndex == 0 ||
            //     cboShelf.SelectedIndex == 0 ||
            //     cboRow.SelectedIndex == 0
            // )
            // {
            //     MessageBox.Show("Vị trí lưu trữ không thể trống!");
            //     return;
            // }
            // Book newBook = new Book
            // {
            //     Title = txtTittle.Text,
            //     AuthorId = (int)cboAuthor.SelectedValue,
            //     CategoryId = (int)cboCategory.SelectedValue,
            //     PublisherId = (int)cboPublisher.SelectedValue,
            //     PublishYear = int.TryParse(txtPublishYear.Text, out var result) ? result : (int?)null,
            //     Description = txtDescription.Text,
            //     ImagePath = SelectedImageName,
            //     StorageLocationId = GetSelectedStorageLocationId()
            // };

            // int newBookId = await _bookService.AddBookAsync(newBook);

            // if (newBookId != -1 && chkIsBorrowed.Checked == true)
            // {
            //     LoanHistory newLoanHistory = new LoanHistory
            //     {
            //         BookId = newBookId,
            //         LenderName = txtLender.Text,
            //         MustReturnDate = dtpExpectedReturnDate.Value
            //     };

            //     // Biến vô danh (_) dùng để nhận kết quả, hiện chưa dùng tới
            //     // Dự kiến sẽ dùng để kiểm tra và hủy transaction nếu không thành công (mở rộng sau)
            //     _ = await _loanHistoryService.AddLoanHistoryAsync(newLoanHistory);
            // }
            // try
            // {
            //     if (!File.Exists(SelectedImagePath))
            //     {
            //         MessageBox.Show("Ảnh nguồn không tồn tại!");
            //         return;
            //     }

            //     string destinationPath = Path.Combine(PathManager.ImageDir, SelectedImageName);

            //     if (File.Exists(destinationPath))
            //     {
            //         string nameWithoutExt = Path.GetFileNameWithoutExtension(SelectedImageName);
            //         string ext = Path.GetExtension(SelectedImageName);
            //         string uniqueName = $"{nameWithoutExt}_{DateTime.Now.Ticks}{ext}";

            //         SelectedImageName = uniqueName; // Cập nhật lại tên để lưu vào DB
            //         destinationPath = Path.Combine(PathManager.ImageDir, uniqueName);
            //     }

            //     File.Move(SelectedImagePath, destinationPath);

            //     MessageBox.Show("Ảnh đã được di chuyển!");

            // }
            // catch (Exception ex)
            // {
            //     MessageBox.Show("Lỗi khi di chuyển ảnh: " + ex.Message);
            // }
            var storageLocations = _storageLocationService.GetAllStorageLocations();

            // Tạo dict mới với value là chuỗi đã chuẩn hóa
            Dictionary<int, string> normalizedLocationDict = storageLocations
                .ToDictionary(
                    pair => pair.Key,
                    pair => NormalizeString($"{pair.Value.Room}{pair.Value.Shelf}{pair.Value.Row}")
                );

            string loc = NormalizeString($"{cboRoom.SelectedValue.ToString()}{cboShelf.SelectedValue.ToString()}{cboRow.SelectedValue.ToString()}");
            var matchedEntry = normalizedLocationDict
    .FirstOrDefault(p => p.Value == loc);

            if (matchedEntry.Key == 0 && matchedEntry.Value == null)
                throw new InvalidOperationException("Không tìm thấy vị trí lưu trữ tương ứng.");

            int matchedId = matchedEntry.Key;
            MessageBox.Show(matchedId.ToString());
        }

        private void OnSelectedImageButtonClick(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Chọn hình minh họa";
                openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SelectedImagePath = openFileDialog.FileName;
                    SelectedImageName = Path.GetFileName(SelectedImagePath);

                    pbImage.Image = Image.FromFile(SelectedImagePath);
                    pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            btnSelectImage.Visible = false;

        }

        private int GetSelectedStorageLocationId()
        {
            return 0;
        }

        public static string NormalizeString(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // 1. Loại bỏ khoảng trắng
            string noWhitespace = new string(input
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());

            // 2. Chuyển về chữ thường
            string lowerCased = noWhitespace.ToLowerInvariant();

            // 3. Loại bỏ dấu tiếng Việt (normalize to FormD)
            string normalizedFormD = lowerCased.Normalize(NormalizationForm.FormD);
            string noDiacritics = new string(normalizedFormD
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            // 4. Trả về dạng chuẩn (FormC)
            return noDiacritics.Normalize(NormalizationForm.FormC);
        }

    }
}
