namespace PersonalLibraryManagement.Controls
{
    partial class UcBookList
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
            this.lvBooks = new System.Windows.Forms.ListView();
            this.Title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Author = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Category = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelBookProperties = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtPublishYear = new System.Windows.Forms.TextBox();
            this.txtPublisher = new System.Windows.Forms.TextBox();
            this.txtStorageLocation = new System.Windows.Forms.TextBox();
            this.txtLoanStatus = new System.Windows.Forms.TextBox();
            this.lblStorageLocation = new System.Windows.Forms.Label();
            this.lblPublishYear = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCloseBookProperties = new System.Windows.Forms.Button();
            this.pbBookImage = new System.Windows.Forms.PictureBox();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.panelBookProperties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // lvBooks
            // 
            this.lvBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lvBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Title,
            this.Author,
            this.Category});
            this.lvBooks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBooks.FullRowSelect = true;
            this.lvBooks.GridLines = true;
            this.lvBooks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvBooks.HideSelection = false;
            this.lvBooks.Location = new System.Drawing.Point(3, 2);
            this.lvBooks.MultiSelect = false;
            this.lvBooks.Name = "lvBooks";
            this.lvBooks.Size = new System.Drawing.Size(697, 514);
            this.lvBooks.TabIndex = 1;
            this.lvBooks.UseCompatibleStateImageBehavior = false;
            this.lvBooks.View = System.Windows.Forms.View.Details;
            this.lvBooks.ColumnWidthChanging += new System.Windows.Forms.ColumnWidthChangingEventHandler(this.OnLvBooksColumnWidthChanging);
            this.lvBooks.SelectedIndexChanged += new System.EventHandler(this.OnSelectedIndexChanged);
            // 
            // Title
            // 
            this.Title.Text = "Tựa đề";
            this.Title.Width = 300;
            // 
            // Author
            // 
            this.Author.Text = "Tác giả";
            this.Author.Width = 195;
            // 
            // Category
            // 
            this.Category.Text = "Thể loại";
            this.Category.Width = 198;
            // 
            // panelBookProperties
            // 
            this.panelBookProperties.BackColor = System.Drawing.SystemColors.Window;
            this.panelBookProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBookProperties.Controls.Add(this.btnCloseBookProperties);
            this.panelBookProperties.Controls.Add(this.txtDescription);
            this.panelBookProperties.Controls.Add(this.txtPublishYear);
            this.panelBookProperties.Controls.Add(this.txtPublisher);
            this.panelBookProperties.Controls.Add(this.txtStorageLocation);
            this.panelBookProperties.Controls.Add(this.txtLoanStatus);
            this.panelBookProperties.Controls.Add(this.lblStorageLocation);
            this.panelBookProperties.Controls.Add(this.lblPublishYear);
            this.panelBookProperties.Controls.Add(this.lblStatus);
            this.panelBookProperties.Controls.Add(this.lblPublisher);
            this.panelBookProperties.Controls.Add(this.label3);
            this.panelBookProperties.Controls.Add(this.pbBookImage);
            this.panelBookProperties.Controls.Add(this.lblDetails);
            this.panelBookProperties.Location = new System.Drawing.Point(715, 2);
            this.panelBookProperties.Name = "panelBookProperties";
            this.panelBookProperties.Size = new System.Drawing.Size(331, 514);
            this.panelBookProperties.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescription.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(107, 385);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(208, 70);
            this.txtDescription.TabIndex = 3;
            // 
            // txtPublishYear
            // 
            this.txtPublishYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPublishYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPublishYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublishYear.Location = new System.Drawing.Point(107, 360);
            this.txtPublishYear.Name = "txtPublishYear";
            this.txtPublishYear.ReadOnly = true;
            this.txtPublishYear.Size = new System.Drawing.Size(208, 19);
            this.txtPublishYear.TabIndex = 3;
            this.txtPublishYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPublisher
            // 
            this.txtPublisher.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtPublisher.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPublisher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPublisher.Location = new System.Drawing.Point(107, 335);
            this.txtPublisher.Name = "txtPublisher";
            this.txtPublisher.ReadOnly = true;
            this.txtPublisher.Size = new System.Drawing.Size(208, 19);
            this.txtPublisher.TabIndex = 3;
            this.txtPublisher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStorageLocation
            // 
            this.txtStorageLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtStorageLocation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStorageLocation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStorageLocation.Location = new System.Drawing.Point(107, 461);
            this.txtStorageLocation.Name = "txtStorageLocation";
            this.txtStorageLocation.ReadOnly = true;
            this.txtStorageLocation.Size = new System.Drawing.Size(208, 19);
            this.txtStorageLocation.TabIndex = 3;
            this.txtStorageLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtLoanStatus
            // 
            this.txtLoanStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.txtLoanStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLoanStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoanStatus.Location = new System.Drawing.Point(107, 486);
            this.txtLoanStatus.Name = "txtLoanStatus";
            this.txtLoanStatus.ReadOnly = true;
            this.txtLoanStatus.Size = new System.Drawing.Size(208, 19);
            this.txtLoanStatus.TabIndex = 3;
            this.txtLoanStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStorageLocation
            // 
            this.lblStorageLocation.AutoSize = true;
            this.lblStorageLocation.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorageLocation.Location = new System.Drawing.Point(11, 461);
            this.lblStorageLocation.Name = "lblStorageLocation";
            this.lblStorageLocation.Size = new System.Drawing.Size(84, 19);
            this.lblStorageLocation.TabIndex = 2;
            this.lblStorageLocation.Text = "Vị trí lưu trữ";
            // 
            // lblPublishYear
            // 
            this.lblPublishYear.AutoSize = true;
            this.lblPublishYear.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishYear.Location = new System.Drawing.Point(11, 360);
            this.lblPublishYear.Name = "lblPublishYear";
            this.lblPublishYear.Size = new System.Drawing.Size(94, 19);
            this.lblPublishYear.TabIndex = 2;
            this.lblPublishYear.Text = "Năm xuất bản";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(11, 486);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(68, 19);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublisher.Location = new System.Drawing.Point(11, 335);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Size = new System.Drawing.Size(90, 19);
            this.lblPublisher.TabIndex = 2;
            this.lblPublisher.Text = "Nhà xuất bản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả:";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(82, 0);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(149, 22);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "Thông tin chi tiết";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(707, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(2, 513);
            this.panel1.TabIndex = 6;
            // 
            // btnCloseBookProperties
            // 
            this.btnCloseBookProperties.BackColor = System.Drawing.SystemColors.Window;
            this.btnCloseBookProperties.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCloseBookProperties.Image = global::PersonalLibraryManagement.Properties.Resources.close;
            this.btnCloseBookProperties.Location = new System.Drawing.Point(300, -1);
            this.btnCloseBookProperties.Name = "btnCloseBookProperties";
            this.btnCloseBookProperties.Size = new System.Drawing.Size(30, 30);
            this.btnCloseBookProperties.TabIndex = 7;
            this.btnCloseBookProperties.UseVisualStyleBackColor = false;
            this.btnCloseBookProperties.Click += new System.EventHandler(this.OnCloseBookPropertiesBtnClick);
            // 
            // pbBookImage
            // 
            this.pbBookImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbBookImage.Location = new System.Drawing.Point(15, 29);
            this.pbBookImage.Name = "pbBookImage";
            this.pbBookImage.Size = new System.Drawing.Size(300, 300);
            this.pbBookImage.TabIndex = 1;
            this.pbBookImage.TabStop = false;
            // 
            // pbBackground
            // 
            this.pbBackground.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbBackground.Image = global::PersonalLibraryManagement.Properties.Resources.bookshelf;
            this.pbBackground.Location = new System.Drawing.Point(715, 2);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(331, 514);
            this.pbBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBackground.TabIndex = 5;
            this.pbBackground.TabStop = false;
            // 
            // UcBookList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelBookProperties);
            this.Controls.Add(this.lvBooks);
            this.Controls.Add(this.pbBackground);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UcBookList";
            this.Size = new System.Drawing.Size(1049, 520);
            this.Load += new System.EventHandler(this.OnBookListUCLoad);
            this.panelBookProperties.ResumeLayout(false);
            this.panelBookProperties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBookImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListView lvBooks;
        private System.Windows.Forms.Panel panelBookProperties;
        private System.Windows.Forms.ColumnHeader Title;
        private System.Windows.Forms.ColumnHeader Author;
        private System.Windows.Forms.ColumnHeader Category;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.PictureBox pbBookImage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtLoanStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.TextBox txtPublishYear;
        private System.Windows.Forms.TextBox txtPublisher;
        private System.Windows.Forms.TextBox txtStorageLocation;
        private System.Windows.Forms.Label lblStorageLocation;
        private System.Windows.Forms.Label lblPublishYear;
        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCloseBookProperties;
    }
}
