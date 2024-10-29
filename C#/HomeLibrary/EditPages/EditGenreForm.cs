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
    public partial class EditGenreForm : Form
    {
        public string EditedGenre { get; private set; }

        public EditGenreForm(string currentGenre)
        {
            InitializeComponent();
            textBoxGenre.Text = currentGenre;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            EditedGenre = textBoxGenre.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
