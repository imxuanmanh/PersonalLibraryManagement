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
    public partial class LendForm : Form
    {
        public string BorrowerName { get; private set; } = string.Empty;

        public LendForm()
        {
            InitializeComponent();
        }

        private void OnConfirmButtonClick(object sender, EventArgs e)
        {
            BorrowerName = txtBorrowerName.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
