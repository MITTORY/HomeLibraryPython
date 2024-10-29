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
    public partial class EditDescriptionForm : Form
    {
        public string EditedDescription { get; private set; }

        public EditDescriptionForm(string currentDescription)
        {
            InitializeComponent();
            textBoxDescription.Text = currentDescription;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EditedDescription = textBoxDescription.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
