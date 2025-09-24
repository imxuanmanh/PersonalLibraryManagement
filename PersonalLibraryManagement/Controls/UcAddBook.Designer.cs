namespace PersonalLibraryManagement.Controls
{
    partial class UcAddBook
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.cboAuthor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIsBorrowed = new System.Windows.Forms.CheckBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpExpectedReturnDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLender = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTittle = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.txtPublishYear = new System.Windows.Forms.TextBox();
            this.cboPublisher = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.comboBox6 = new System.Windows.Forms.ComboBox();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboRow = new System.Windows.Forms.ComboBox();
            this.cboShelf = new System.Windows.Forms.ComboBox();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cboCategory);
            this.panel2.Controls.Add(this.cboAuthor);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(99, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(557, 47);
            this.panel2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(323, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Thể loại";
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(407, 11);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(135, 27);
            this.cboCategory.TabIndex = 2;
            this.cboCategory.Tag = "Category";
            // 
            // cboAuthor
            // 
            this.cboAuthor.FormattingEnabled = true;
            this.cboAuthor.Location = new System.Drawing.Point(139, 11);
            this.cboAuthor.Name = "cboAuthor";
            this.cboAuthor.Size = new System.Drawing.Size(161, 27);
            this.cboAuthor.TabIndex = 1;
            this.cboAuthor.Tag = "Author";
            this.cboAuthor.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxSelectedIndexChange);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 22);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tác giả";
            // 
            // chkIsBorrowed
            // 
            this.chkIsBorrowed.AutoSize = true;
            this.chkIsBorrowed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkIsBorrowed.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsBorrowed.Location = new System.Drawing.Point(10, 12);
            this.chkIsBorrowed.Name = "chkIsBorrowed";
            this.chkIsBorrowed.Size = new System.Drawing.Size(121, 26);
            this.chkIsBorrowed.TabIndex = 2;
            this.chkIsBorrowed.Text = "Sách mượn";
            this.chkIsBorrowed.UseVisualStyleBackColor = true;
            this.chkIsBorrowed.CheckedChanged += new System.EventHandler(this.OnIsBorrowedCheckBoxCheckedChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel5.Controls.Add(this.txtDescription);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(25, 202);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(557, 107);
            this.panel5.TabIndex = 1;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(139, 5);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(403, 96);
            this.txtDescription.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 22);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mô tả";
            // 
            // btnAddBook
            // 
            this.btnAddBook.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.Image = global::PersonalLibraryManagement.Properties.Resources.add;
            this.btnAddBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBook.Location = new System.Drawing.Point(589, 317);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Padding = new System.Windows.Forms.Padding(85, 0, 0, 0);
            this.btnAddBook.Size = new System.Drawing.Size(300, 41);
            this.btnAddBook.TabIndex = 2;
            this.btnAddBook.Text = "Thêm sách";
            this.btnAddBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.OnAddBookButtonClick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel6.Controls.Add(this.chkIsBorrowed);
            this.panel6.Controls.Add(this.dtpExpectedReturnDate);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.txtLender);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Location = new System.Drawing.Point(25, 310);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(557, 48);
            this.panel6.TabIndex = 1;
            // 
            // dtpExpectedReturnDate
            // 
            this.dtpExpectedReturnDate.CustomFormat = "dd/MM/yyyy";
            this.dtpExpectedReturnDate.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpExpectedReturnDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpExpectedReturnDate.Location = new System.Drawing.Point(437, 11);
            this.dtpExpectedReturnDate.Name = "dtpExpectedReturnDate";
            this.dtpExpectedReturnDate.Size = new System.Drawing.Size(105, 29);
            this.dtpExpectedReturnDate.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(358, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 22);
            this.label7.TabIndex = 2;
            this.label7.Text = "Ngày trả";
            // 
            // txtLender
            // 
            this.txtLender.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLender.Location = new System.Drawing.Point(228, 11);
            this.txtLender.Name = "txtLender";
            this.txtLender.Size = new System.Drawing.Size(124, 29);
            this.txtLender.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(138, 13);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 22);
            this.label6.TabIndex = 0;
            this.label6.Text = "Chủ sách";
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Location = new System.Drawing.Point(703, 141);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(87, 34);
            this.btnSelectImage.TabIndex = 4;
            this.btnSelectImage.Text = "Chọn hình\r\n";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Click += new System.EventHandler(this.OnSelectedImageButtonClick);
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.Control;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(589, 13);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(300, 300);
            this.pbImage.TabIndex = 3;
            this.pbImage.TabStop = false;
            this.pbImage.Click += new System.EventHandler(this.OnSelectedImageButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tựa đề";
            // 
            // txtTittle
            // 
            this.txtTittle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTittle.Location = new System.Drawing.Point(139, 9);
            this.txtTittle.Name = "txtTittle";
            this.txtTittle.Size = new System.Drawing.Size(403, 29);
            this.txtTittle.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.txtTittle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(99, 78);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 45);
            this.panel1.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel7.Controls.Add(this.txtPublishYear);
            this.panel7.Controls.Add(this.cboPublisher);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.label8);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Location = new System.Drawing.Point(25, 107);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(557, 48);
            this.panel7.TabIndex = 1;
            // 
            // txtPublishYear
            // 
            this.txtPublishYear.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublishYear.Location = new System.Drawing.Point(453, 11);
            this.txtPublishYear.Name = "txtPublishYear";
            this.txtPublishYear.Size = new System.Drawing.Size(89, 29);
            this.txtPublishYear.TabIndex = 3;
            // 
            // cboPublisher
            // 
            this.cboPublisher.FormattingEnabled = true;
            this.cboPublisher.Location = new System.Drawing.Point(139, 10);
            this.cboPublisher.Name = "cboPublisher";
            this.cboPublisher.Size = new System.Drawing.Size(161, 27);
            this.cboPublisher.TabIndex = 2;
            this.cboPublisher.Tag = "Publisher";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(320, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 22);
            this.label11.TabIndex = 0;
            this.label11.Text = "Năm xuất bản";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 11);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 22);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nhà xuất bản";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.comboBox5);
            this.panel8.Controls.Add(this.comboBox6);
            this.panel8.Controls.Add(this.comboBox7);
            this.panel8.Controls.Add(this.label9);
            this.panel8.Location = new System.Drawing.Point(0, 45);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(425, 48);
            this.panel8.TabIndex = 1;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(339, 11);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(73, 27);
            this.comboBox5.TabIndex = 1;
            this.comboBox5.Text = "Hàng";
            // 
            // comboBox6
            // 
            this.comboBox6.FormattingEnabled = true;
            this.comboBox6.Location = new System.Drawing.Point(241, 11);
            this.comboBox6.Name = "comboBox6";
            this.comboBox6.Size = new System.Drawing.Size(73, 27);
            this.comboBox6.TabIndex = 1;
            this.comboBox6.Text = "Kệ";
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(99, 11);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(117, 27);
            this.comboBox7.TabIndex = 1;
            this.comboBox7.Text = "Phòng";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 22);
            this.label9.TabIndex = 0;
            this.label9.Text = "Vị trí";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel9.Controls.Add(this.panel5);
            this.panel9.Controls.Add(this.panel3);
            this.panel9.Controls.Add(this.btnSelectImage);
            this.panel9.Controls.Add(this.panel7);
            this.panel9.Controls.Add(this.btnAddBook);
            this.panel9.Controls.Add(this.pbImage);
            this.panel9.Controls.Add(this.panel6);
            this.panel9.Location = new System.Drawing.Point(74, 65);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(908, 370);
            this.panel9.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel3.Controls.Add(this.cboRow);
            this.panel3.Controls.Add(this.cboShelf);
            this.panel3.Controls.Add(this.cboRoom);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(25, 156);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(557, 45);
            this.panel3.TabIndex = 1;
            // 
            // cboRow
            // 
            this.cboRow.FormattingEnabled = true;
            this.cboRow.Location = new System.Drawing.Point(421, 7);
            this.cboRow.Name = "cboRow";
            this.cboRow.Size = new System.Drawing.Size(121, 27);
            this.cboRow.TabIndex = 1;
            this.cboRow.Tag = "Row";
            // 
            // cboShelf
            // 
            this.cboShelf.FormattingEnabled = true;
            this.cboShelf.Location = new System.Drawing.Point(279, 7);
            this.cboShelf.Name = "cboShelf";
            this.cboShelf.Size = new System.Drawing.Size(121, 27);
            this.cboShelf.TabIndex = 1;
            this.cboShelf.Tag = "Shelf";
            // 
            // cboRoom
            // 
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(139, 7);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(121, 27);
            this.cboRoom.TabIndex = 1;
            this.cboRoom.Tag = "Room";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "Vị trí lưu trữ";
            // 
            // UcAddBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel9);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UcAddBook";
            this.Size = new System.Drawing.Size(1049, 520);
            this.Load += new System.EventHandler(this.OnAddBookUCLoad);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIsBorrowed;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txtLender;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpExpectedReturnDate;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTittle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cboPublisher;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.ComboBox comboBox6;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPublishYear;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.ComboBox cboAuthor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboRow;
        private System.Windows.Forms.ComboBox cboShelf;
        private System.Windows.Forms.ComboBox cboRoom;
    }
}
