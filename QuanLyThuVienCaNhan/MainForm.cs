using QuanLyThuVienCaNhan.Controls;
using QuanLyThuVienCaNhan.Manager;
using QuanLyThuVienCaNhan.Repositories;
using QuanLyThuVienCaNhan.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVienCaNhan
{
    public partial class MainForm : Form
    {
        private readonly IBookService _service;
        public MainForm(IBookService service)
        {
            InitializeComponent();

            _service = service;
        }

        private void ShowUserControl(UserControl uc)
        {
            panelRightView.Controls.Clear();

            panelRightView.Controls.Add(uc);
        }

        private void LoadCategoryGroupBox()
        {
            //List<string> categories = _service.GetAllCategorys();
            //int x = 5; // vị trí bắt đầu theo trục X
            //int y = 5; // vị trí bắt đầu theo trục Y
            //int count = 0; // đếm số nút trong 1 hàng

            //int buttonWidth = 110; // chiều rộng nút
            //int buttonHeight = 30; // chiều cao nút
            //int spacing = 7; // khoảng cách giữa các nút

            //foreach (string c in categories)
            //{
            //    Button btn = new Button();
            //    btn.Text = c;
            //    btn.Size = new Size(buttonWidth, buttonHeight);
            //    btn.Location = new Point(x, y);
            //    btn.Font = new Font("Time New Roman", 10);
            //    btn.Click += OnCategoryButtonClick;

            //    pnCategoryList.Controls.Add(btn);

            //    count++;

            //    if (count % 2 == 0) // đủ 2 nút thì xuống dòng
            //    {
            //        x = 5;
            //        y += buttonHeight + spacing;
            //    }
            //    else
            //    {
            //        x += buttonWidth + spacing; // đặt nút tiếp theo bên phải
            //    }
            //}
        }


        private void OnBtnLendBorrowCtrlClick(object sender, EventArgs e)
        {
            ShowUserControl(new UcLendBorrowManager());
        }

        private void OnBtnBookManagerClick(object sender, EventArgs e)
        {
            UcBookList uc = new UcBookList(_service);
            uc.LoadBooksToListView();

            ShowUserControl(uc);
        }

        private void OnBtnAddBookClick(object sender, EventArgs e)
        {
            ShowUserControl(new UcAddBook(_service));
        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // MessageBox.Show(PathManager.ImageDir);
            LoadCategoryGroupBox();
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

    }
}
