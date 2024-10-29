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
    public partial class EditAuthorForm : Form
    {
        public string EditedAuthor { get; private set; }

        public EditAuthorForm(string currentAuthor)
        {
            InitializeComponent();
            textBoxAuthor.Text = currentAuthor;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EditedAuthor = textBoxAuthor.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
