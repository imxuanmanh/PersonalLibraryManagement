namespace PersonalLibraryManagement
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.panelLeftMenu = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnBookManager = new System.Windows.Forms.Button();
            this.btnLendBorrowCtrl = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.gbCategoryList = new System.Windows.Forms.GroupBox();
            this.pnCategoryList = new System.Windows.Forms.Panel();
            this.panelRightView = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.panelLeftMenu.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbCategoryList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.txtSearchBox);
            this.panel1.Location = new System.Drawing.Point(16, 85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1342, 39);
            this.panel1.TabIndex = 1;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchBox.Location = new System.Drawing.Point(11, 5);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(279, 29);
            this.txtSearchBox.TabIndex = 1;
            this.txtSearchBox.TabStop = false;
            this.txtSearchBox.Enter += new System.EventHandler(this.OnSearchBoxEnter);
            this.txtSearchBox.Leave += new System.EventHandler(this.OnSearchBoxLeave);
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panelHeader.Controls.Add(this.lblHeader);
            this.panelHeader.Location = new System.Drawing.Point(16, 31);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1342, 50);
            this.panelHeader.TabIndex = 2;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Times New Roman", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(3, 2);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(835, 45);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN CÁ NHÂN";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.Color.Transparent;
            this.splitContainerMain.Location = new System.Drawing.Point(12, 128);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.panelLeftMenu);
            this.splitContainerMain.Panel1.ForeColor = System.Drawing.Color.DarkCyan;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.panelRightView);
            this.splitContainerMain.Size = new System.Drawing.Size(1346, 520);
            this.splitContainerMain.SplitterDistance = 293;
            this.splitContainerMain.TabIndex = 3;
            // 
            // panelLeftMenu
            // 
            this.panelLeftMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLeftMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLeftMenu.Controls.Add(this.groupBox2);
            this.panelLeftMenu.Controls.Add(this.gbCategoryList);
            this.panelLeftMenu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelLeftMenu.Location = new System.Drawing.Point(4, 0);
            this.panelLeftMenu.Name = "panelLeftMenu";
            this.panelLeftMenu.Size = new System.Drawing.Size(292, 520);
            this.panelLeftMenu.TabIndex = 4;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox2.Controls.Add(this.btnStats);
            this.groupBox2.Controls.Add(this.btnBookManager);
            this.groupBox2.Controls.Add(this.btnLendBorrowCtrl);
            this.groupBox2.Controls.Add(this.btnAddBook);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(265, 255);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng chính";
            // 
            // btnStats
            // 
            this.btnStats.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStats.Image = global::PersonalLibraryManagement.Properties.Resources.stats;
            this.btnStats.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.Location = new System.Drawing.Point(2, 193);
            this.btnStats.Name = "btnStats";
            this.btnStats.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnStats.Size = new System.Drawing.Size(261, 49);
            this.btnStats.TabIndex = 1;
            this.btnStats.Text = "Thống kê";
            this.btnStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStats.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.OnBtnStatsClick);
            // 
            // btnBookManager
            // 
            this.btnBookManager.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBookManager.Image = global::PersonalLibraryManagement.Properties.Resources.book;
            this.btnBookManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookManager.Location = new System.Drawing.Point(2, 28);
            this.btnBookManager.Name = "btnBookManager";
            this.btnBookManager.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBookManager.Size = new System.Drawing.Size(261, 49);
            this.btnBookManager.TabIndex = 0;
            this.btnBookManager.Text = "Quản lý sách";
            this.btnBookManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookManager.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBookManager.UseVisualStyleBackColor = true;
            this.btnBookManager.Click += new System.EventHandler(this.OnBtnBookManagerClick);
            // 
            // btnLendBorrowCtrl
            // 
            this.btnLendBorrowCtrl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLendBorrowCtrl.Image = global::PersonalLibraryManagement.Properties.Resources.around;
            this.btnLendBorrowCtrl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLendBorrowCtrl.Location = new System.Drawing.Point(2, 138);
            this.btnLendBorrowCtrl.Name = "btnLendBorrowCtrl";
            this.btnLendBorrowCtrl.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLendBorrowCtrl.Size = new System.Drawing.Size(261, 49);
            this.btnLendBorrowCtrl.TabIndex = 0;
            this.btnLendBorrowCtrl.Text = "Quản lý mượn - cho mượn";
            this.btnLendBorrowCtrl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLendBorrowCtrl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLendBorrowCtrl.UseVisualStyleBackColor = true;
            this.btnLendBorrowCtrl.Click += new System.EventHandler(this.OnBtnLendBorrowCtrlClick);
            // 
            // btnAddBook
            // 
            this.btnAddBook.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBook.Image = global::PersonalLibraryManagement.Properties.Resources.add;
            this.btnAddBook.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddBook.Location = new System.Drawing.Point(2, 83);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAddBook.Size = new System.Drawing.Size(261, 49);
            this.btnAddBook.TabIndex = 0;
            this.btnAddBook.Text = "Thêm sách";
            this.btnAddBook.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddBook.UseVisualStyleBackColor = true;
            this.btnAddBook.Click += new System.EventHandler(this.OnBtnAddBookClick);
            // 
            // gbCategoryList
            // 
            this.gbCategoryList.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.gbCategoryList.Controls.Add(this.pnCategoryList);
            this.gbCategoryList.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCategoryList.Location = new System.Drawing.Point(10, 280);
            this.gbCategoryList.Name = "gbCategoryList";
            this.gbCategoryList.Size = new System.Drawing.Size(265, 226);
            this.gbCategoryList.TabIndex = 2;
            this.gbCategoryList.TabStop = false;
            this.gbCategoryList.Text = "Thể loại";
            // 
            // pnCategoryList
            // 
            this.pnCategoryList.AutoScroll = true;
            this.pnCategoryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCategoryList.Location = new System.Drawing.Point(3, 28);
            this.pnCategoryList.Name = "pnCategoryList";
            this.pnCategoryList.Size = new System.Drawing.Size(259, 195);
            this.pnCategoryList.TabIndex = 0;
            // 
            // panelRightView
            // 
            this.panelRightView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRightView.Location = new System.Drawing.Point(0, 0);
            this.panelRightView.Margin = new System.Windows.Forms.Padding(0);
            this.panelRightView.Name = "panelRightView";
            this.panelRightView.Size = new System.Drawing.Size(1049, 520);
            this.panelRightView.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(16, 654);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1342, 39);
            this.panel2.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1370, 702);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1491, 802);
            this.MinimumSize = new System.Drawing.Size(1364, 721);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý thư viện cá nhân";
            this.Load += new System.EventHandler(this.OnMainFormLoad);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.panelLeftMenu.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbCategoryList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtSearchBox;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Button btnBookManager;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnLendBorrowCtrl;
        private System.Windows.Forms.Button btnAddBook;
        private System.Windows.Forms.Panel panelLeftMenu;
        private System.Windows.Forms.Panel panelRightView;
        private System.Windows.Forms.GroupBox gbCategoryList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnCategoryList;
    }
}

