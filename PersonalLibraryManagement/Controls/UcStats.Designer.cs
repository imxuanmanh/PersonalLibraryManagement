namespace PersonalLibraryManagement.Controls
{
    partial class UcStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcStats));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbStats = new System.Windows.Forms.Label();
            this.txtLendBook = new System.Windows.Forms.TextBox();
            this.txtBorrowBook = new System.Windows.Forms.TextBox();
            this.txtTotalBook = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pieChartAuthor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pieChartCategory = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartAuthor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1049, 520);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // lbStats
            // 
            this.lbStats.AutoSize = true;
            this.lbStats.BackColor = System.Drawing.Color.White;
            this.lbStats.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStats.Font = new System.Drawing.Font("Segoe UI Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStats.Location = new System.Drawing.Point(596, 238);
            this.lbStats.Name = "lbStats";
            this.lbStats.Size = new System.Drawing.Size(314, 83);
            this.lbStats.TabIndex = 5;
            this.lbStats.Text = "Thống kê";
            // 
            // txtLendBook
            // 
            this.txtLendBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLendBook.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLendBook.Location = new System.Drawing.Point(562, 140);
            this.txtLendBook.Name = "txtLendBook";
            this.txtLendBook.ReadOnly = true;
            this.txtLendBook.Size = new System.Drawing.Size(108, 69);
            this.txtLendBook.TabIndex = 6;
            this.txtLendBook.Text = "9999";
            this.txtLendBook.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBorrowBook
            // 
            this.txtBorrowBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBorrowBook.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBorrowBook.Location = new System.Drawing.Point(700, 141);
            this.txtBorrowBook.Name = "txtBorrowBook";
            this.txtBorrowBook.ReadOnly = true;
            this.txtBorrowBook.Size = new System.Drawing.Size(97, 69);
            this.txtBorrowBook.TabIndex = 6;
            this.txtBorrowBook.Text = "9999";
            this.txtBorrowBook.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotalBook
            // 
            this.txtTotalBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalBook.Font = new System.Drawing.Font("Segoe UI", 33.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalBook.Location = new System.Drawing.Point(814, 131);
            this.txtTotalBook.Name = "txtTotalBook";
            this.txtTotalBook.ReadOnly = true;
            this.txtTotalBook.Size = new System.Drawing.Size(140, 82);
            this.txtTotalBook.TabIndex = 6;
            this.txtTotalBook.Text = "99999";
            this.txtTotalBook.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Aqua;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(563, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Cho mượn";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Aqua;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(712, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 37);
            this.label2.TabIndex = 7;
            this.label2.Text = "Mượn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Aqua;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(813, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 37);
            this.label3.TabIndex = 7;
            this.label3.Text = "Tổng số sách";
            // 
            // txtAuthor
            // 
            this.txtAuthor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAuthor.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAuthor.Location = new System.Drawing.Point(630, 425);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.ReadOnly = true;
            this.txtAuthor.Size = new System.Drawing.Size(108, 69);
            this.txtAuthor.TabIndex = 6;
            this.txtAuthor.Text = "9999";
            this.txtAuthor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCategory
            // 
            this.txtCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCategory.Font = new System.Drawing.Font("Segoe UI", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategory.Location = new System.Drawing.Point(751, 417);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.ReadOnly = true;
            this.txtCategory.Size = new System.Drawing.Size(108, 79);
            this.txtCategory.TabIndex = 6;
            this.txtCategory.Text = "9999";
            this.txtCategory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Aqua;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(638, 391);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 41);
            this.label4.TabIndex = 7;
            this.label4.Text = "Tác giả";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Aqua;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(753, 379);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 41);
            this.label5.TabIndex = 7;
            this.label5.Text = "Thể loại";
            // 
            // pieChartAuthor
            // 
            this.pieChartAuthor.BorderlineColor = System.Drawing.Color.Black;
            chartArea1.Name = "ChartArea1";
            this.pieChartAuthor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pieChartAuthor.Legends.Add(legend1);
            this.pieChartAuthor.Location = new System.Drawing.Point(72, 17);
            this.pieChartAuthor.Name = "pieChartAuthor";
            this.pieChartAuthor.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.pieChartAuthor.Series.Add(series1);
            this.pieChartAuthor.Size = new System.Drawing.Size(332, 185);
            this.pieChartAuthor.TabIndex = 8;
            title1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title1.Name = "Title1";
            title1.Text = "Title 1";
            this.pieChartAuthor.Titles.Add(title1);
            // 
            // pieChartCategory
            // 
            chartArea2.Name = "ChartArea1";
            this.pieChartCategory.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.pieChartCategory.Legends.Add(legend2);
            this.pieChartCategory.Location = new System.Drawing.Point(69, 226);
            this.pieChartCategory.Name = "pieChartCategory";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.pieChartCategory.Series.Add(series2);
            this.pieChartCategory.Size = new System.Drawing.Size(338, 260);
            this.pieChartCategory.TabIndex = 9;
            title2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "Title 2";
            this.pieChartCategory.Titles.Add(title2);
            // 
            // UcStats
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.pieChartCategory);
            this.Controls.Add(this.pieChartAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTotalBook);
            this.Controls.Add(this.txtBorrowBook);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtLendBook);
            this.Controls.Add(this.lbStats);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "UcStats";
            this.Size = new System.Drawing.Size(1049, 520);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartAuthor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieChartCategory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbStats;
        private System.Windows.Forms.TextBox txtLendBook;
        private System.Windows.Forms.TextBox txtBorrowBook;
        private System.Windows.Forms.TextBox txtTotalBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChartAuthor;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChartCategory;
    }
}
