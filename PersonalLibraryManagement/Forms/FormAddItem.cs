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
    public partial class FormAddItem : Form
    {
        public string Result {  get; set; } = string.Empty;
        public FormAddItem(string title, string header)
        {
            InitializeComponent();
            this.Text = title;
            this.lblHeader.Text = header;
        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInput.Text))
            {
                MessageBox.Show("Không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Result = txtInput.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
