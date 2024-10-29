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
    public partial class EditSelectionForm : Form
    {
        public string SelectedProperty { get; private set; }

        public EditSelectionForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (radioButtonType.Checked)
                SelectedProperty = "Type";
            else if (radioButtonTitle.Checked)
                SelectedProperty = "Title";
            else if (radioButtonAuthor.Checked)
                SelectedProperty = "Author";
            else if (radioButtonGenre.Checked)
                SelectedProperty = "Genre";
            else if (radioButtonYear.Checked)
                SelectedProperty = "Year";
            else if (radioButtonDescription.Checked)
                SelectedProperty = "Description";

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
