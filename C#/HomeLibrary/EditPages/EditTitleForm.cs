using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeLibrary
{
    public partial class EditTitleForm : Form
    {
        public string EditedTitle { get; private set; }

        public EditTitleForm(string currentTitle)
        {
            InitializeComponent();
            textBoxTitle.Text = currentTitle;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EditedTitle = textBoxTitle.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
