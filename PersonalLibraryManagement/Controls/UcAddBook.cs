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
using System.Xml.Serialization;
using System.Runtime.InteropServices;

namespace PersonalLibraryManagement.Controls
{
    public partial class UcAddBook : UserControl
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _pulisherService;
        private readonly IStorageLocationService _storageLocationService;
        private readonly ICirculationService _circulationService;

        public string SelectedImageName { get; private set; } = null;
        public string SelectedImagePath { get; private set; } = null;
        private List<StorageLocationViewModel> _storageLocations;


        public UcAddBook(
            IBookService bookService,
            ICategoryService categoryService,
            IAuthorService authorService,
            IPublisherService publisherService,
            IStorageLocationService storageLocationService,
            ICirculationService circulationService
            )
        {
            InitializeComponent();
            _bookService = bookService;
            _categoryService = categoryService;
            _authorService = authorService;
            _pulisherService = publisherService;
            _storageLocationService = storageLocationService;
            _circulationService = circulationService;
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
        private void SetupRoomComboBox()
        {
            var rooms = _storageLocationService.GetAllRooms().Values
                        .Select(r => new ComboBoxItem { Id = r.Id, Name = r.Name })
                        .ToList();

            rooms.Insert(0, new ComboBoxItem { Id = 0, Name = "-- Phòng --" });
            rooms.Add(new ComboBoxItem { Id = -1, Name = "➕Thêm phòng" });

            cboRoom.DataSource = rooms;
            cboRoom.DisplayMember = "Name";
            cboRoom.ValueMember = "Id";

            cboRoom.Tag = "Room";

            cboRoom.SelectedIndexChanged += (s, e) =>
            {
                var selectedRoom = cboRoom.SelectedItem as ComboBoxItem;

                if (selectedRoom == null)
                    return;

                SetupShelfComboBox(selectedRoom.Id);
            };
        }

        private void SetupShelfComboBox(int roomId)
        {
            List<ComboBoxItem> shelves = _storageLocationService.GetAllShelfByRoomId(roomId).Values
                            .Select(s => new ComboBoxItem { Id = s.Id, Name = $"Kệ {s.Ordinal}" })
                            .ToList();

            shelves.Insert(0, new ComboBoxItem { Id = 0, Name = "-- Kệ --" });
            shelves.Add(new ComboBoxItem { Id = -1, Name = "➕Thêm kệ" });

            cboShelf.DataSource = shelves;
            cboShelf.DisplayMember = "Name";
            cboShelf.ValueMember = "Id";

            cboShelf.Tag = "Shelf";

            cboShelf.SelectedIndexChanged += (s, e) =>
            {
                var selectedShelf = cboShelf.SelectedItem as ComboBoxItem;

                if (selectedShelf == null)
                    return;

                SetupShelfRowComboBox(selectedShelf.Id);
            };
        }

        private void SetupShelfRowComboBox(int shelfId)
        {
            List<ComboBoxItem>  shelfRows = _storageLocationService.GetAllShelfRowByShelfId(shelfId).Values
                                            .Select(sr => new ComboBoxItem { Id = sr.Id, Name = $"Hàng {sr.Ordinal}" })
                                            .ToList();


            shelfRows.Insert(0, new ComboBoxItem{ Id = 0, Name = "-- Hàng --" });
            shelfRows.Add(new ComboBoxItem { Id = -1, Name = "➕Thêm hàng" });

            System.Diagnostics.Debug.WriteLine($"Shelf row count: {shelfRows.Count}");

            cboShelfRow.DataSource = shelfRows;
            cboShelfRow.DisplayMember = "Name";
            cboShelfRow.ValueMember = "Id";

            cboShelfRow.Tag = "ShelfRow";
        }

        private void OnAddBookUCLoad(object sender, EventArgs e)
        {
            SetupAuthorComboBox();
            SetupCategoryComboBox();
            SetupPublisherComboBox();

            SetupRoomComboBox();

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

        private async void OnComboBoxSelectedIndexChanged(object sender, EventArgs e)
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

                case "ShelfRow":
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
                        int newRoomId = await _storageLocationService.AddRoomAsync(new Room { Name = value });

                        if (newRoomId > 0)
                        {
                            SetupRoomComboBox();
                            MessageBox.Show("Thêm phòng mới thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm phòng mới thất bại");
                        }

                    }
                    break;

                case "Shelf":
                    {
                        int roomId = (int)cboRoom.SelectedValue;
                        if (!int.TryParse(value, out int ordinal))
                        {
                            MessageBox.Show("Số thứ tự kệ không hợp lệ");
                        }

                        int newShelfId = await _storageLocationService.AddShelfAsync(new Shelf { RoomId = roomId, Ordinal = ordinal });
                        
                        if (newShelfId > 0)
                        {
                            SetupShelfComboBox(roomId);
                            MessageBox.Show("Thêm kệ mới thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm kệ mới thất bại");
                        }
                    }
                    break;

                case "ShelfRow":
                    {
                        int shelfId = (int)cboShelf.SelectedValue;
                        if (!int.TryParse(value, out int ordinal))
                        {
                            MessageBox.Show("Số thứ tự hàng không hợp lệ");
                            return;
                        }

                        int newShelfRowId = await _storageLocationService.AddShelfRowAsync(new ShelfRow { ShelfId = shelfId, Ordinal = ordinal});
                        
                        if (newShelfRowId > 0)
                        {
                            SetupShelfRowComboBox(shelfId);
                            MessageBox.Show("Thêm hàng mới thành công");
                        }
                        else
                        {
                            MessageBox.Show("Thêm hàng mới thất bại");
                        }
                    }
                    break;
            }
        }

        private async void OnAddBookButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTittle.Text))
            {
                MessageBox.Show("Tiêu đề sách không thể trống!");
                return;
            }

            if (cboRoom.SelectedIndex == 0 ||
                cboShelf.SelectedIndex == 0 ||
                cboShelfRow.SelectedIndex == 0)
            {
                MessageBox.Show("Vị trí lưu trữ không thể trống!");
                return;
            }
            Book newBook = new Book
            {
                Title = txtTittle.Text,
                AuthorId = (int)cboAuthor.SelectedValue,
                CategoryId = (int)cboCategory.SelectedValue,
                PublisherId = (int)cboPublisher.SelectedValue,
                PublishYear = int.TryParse(txtPublishYear.Text, out var result) ? result : (int?)null,
                Description = txtDescription.Text,
                ImagePath = SelectedImageName,
                StorageLocationId = (int)cboShelfRow.SelectedValue
            };

            int newBookId = await _bookService.AddBookAsync(newBook);

            if (newBookId == -1)
            {
                MessageBox.Show("Thêm sách thất bại, vui lòng thử lại!");
                return;
            }

            if (chkIsBorrowed.Checked)
            {
                Circulation newCirculation = new Circulation
                {
                    BookId = newBookId,
                    LenderName = txtLender.Text,
                };

                _ = await _circulationService.AddCirculationAsync(newCirculation);
            }

            try
            {
                if (!File.Exists(SelectedImagePath))
                {
                    MessageBox.Show("Ảnh nguồn không tồn tại!");
                    return;
                }

                string destinationPath = Path.Combine(PathManager.ImageDir, SelectedImageName);

                if (File.Exists(destinationPath))
                {
                    string nameWithoutExt = Path.GetFileNameWithoutExtension(SelectedImageName);
                    string ext = Path.GetExtension(SelectedImageName);
                    string uniqueName = $"{nameWithoutExt}_{DateTime.Now.Ticks}{ext}";

                    SelectedImageName = uniqueName; // Cập nhật lại tên để lưu vào DB
                    destinationPath = Path.Combine(PathManager.ImageDir, uniqueName);
                }

                File.Move(SelectedImagePath, destinationPath);

                // MessageBox.Show("Ảnh đã được di chuyển!");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi di chuyển ảnh: " + ex.Message);
            }

            MessageBox.Show("Thêm sách thành công!");
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

                    // Tải ảnh mà không khóa file
                    using (var fs = new FileStream(SelectedImagePath, FileMode.Open, FileAccess.Read))
                    {
                        pbImage.Image = Image.FromStream(fs);
                    }

                    pbImage.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            btnSelectImage.Visible = false;
        }

    }
}
