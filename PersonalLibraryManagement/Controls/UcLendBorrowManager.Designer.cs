namespace PersonalLibraryManagement.Controls
{
    partial class UcLendBorrowManager
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvBorrowBook = new System.Windows.Forms.ListView();
            this.chOrdinal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLender = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chBorrowDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvLendBook = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvHistory = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 25);
            this.tabControl1.Location = new System.Drawing.Point(4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1042, 513);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvBorrowBook);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1034, 480);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mượn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvBorrowBook
            // 
            this.lvBorrowBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvBorrowBook.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvBorrowBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOrdinal,
            this.chTitle,
            this.chLender,
            this.chBorrowDate});
            this.lvBorrowBook.FullRowSelect = true;
            this.lvBorrowBook.GridLines = true;
            this.lvBorrowBook.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBorrowBook.HideSelection = false;
            this.lvBorrowBook.Location = new System.Drawing.Point(0, 0);
            this.lvBorrowBook.MultiSelect = false;
            this.lvBorrowBook.Name = "lvBorrowBook";
            this.lvBorrowBook.Size = new System.Drawing.Size(1034, 480);
            this.lvBorrowBook.TabIndex = 0;
            this.lvBorrowBook.UseCompatibleStateImageBehavior = false;
            this.lvBorrowBook.View = System.Windows.Forms.View.Details;
            this.lvBorrowBook.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.OnLvBooksColumnWidthChanging);
            // 
            // chOrdinal
            // 
            this.chOrdinal.Text = "STT";
            this.chOrdinal.Width = 55;
            // 
            // chTitle
            // 
            this.chTitle.Text = "Tiêu đề";
            this.chTitle.Width = 470;
            // 
            // chLender
            // 
            this.chLender.Text = "Người cho mượn";
            this.chLender.Width = 255;
            // 
            // chBorrowDate
            // 
            this.chBorrowDate.Text = "Ngày mượn";
            this.chBorrowDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chBorrowDate.Width = 250;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvLendBook);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1034, 480);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Cho mượn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvLendBook
            // 
            this.lvLendBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvLendBook.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvLendBook.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvLendBook.GridLines = true;
            this.lvLendBook.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLendBook.HideSelection = false;
            this.lvLendBook.Location = new System.Drawing.Point(0, 0);
            this.lvLendBook.Name = "lvLendBook";
            this.lvLendBook.Size = new System.Drawing.Size(1034, 480);
            this.lvLendBook.TabIndex = 1;
            this.lvLendBook.UseCompatibleStateImageBehavior = false;
            this.lvLendBook.View = System.Windows.Forms.View.Details;
            this.lvLendBook.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.OnLvBooksColumnWidthChanging);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tiêu đề";
            this.columnHeader2.Width = 470;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Người mượn";
            this.columnHeader3.Width = 255;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Ngày mượn";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 250;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvHistory);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1034, 480);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Lịch sử";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvHistory
            // 
            this.lvHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lvHistory.FullRowSelect = true;
            this.lvHistory.GridLines = true;
            this.lvHistory.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvHistory.HideSelection = false;
            this.lvHistory.Location = new System.Drawing.Point(0, 0);
            this.lvHistory.Name = "lvHistory";
            this.lvHistory.Size = new System.Drawing.Size(1034, 480);
            this.lvHistory.TabIndex = 1;
            this.lvHistory.UseCompatibleStateImageBehavior = false;
            this.lvHistory.View = System.Windows.Forms.View.Details;
            this.lvHistory.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.OnLvBooksColumnWidthChanging);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Loại";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Tiêu đề";
            this.columnHeader6.Width = 375;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Người mượn / cho mượn";
            this.columnHeader7.Width = 185;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Ngày mượn";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader8.Width = 185;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Ngày trả";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader9.Width = 185;
            // 
            // UcLendBorrowManager
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(1049, 520);
            this.MinimumSize = new System.Drawing.Size(1049, 520);
            this.Name = "UcLendBorrowManager";
            this.Size = new System.Drawing.Size(1049, 520);
            this.Load += new System.EventHandler(this.OnLendBorrowManagerUCLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvBorrowBook;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chLender;
        private System.Windows.Forms.ColumnHeader chBorrowDate;
        private System.Windows.Forms.ColumnHeader chOrdinal;
        private System.Windows.Forms.ListView lvLendBook;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lvHistory;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
    }
}
