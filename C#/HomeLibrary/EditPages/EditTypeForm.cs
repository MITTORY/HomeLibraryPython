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
    public partial class EditTypeForm : Form
    {
        public string SelectedType { get; private set; }

        public EditTypeForm(string currentType)
        {
            InitializeComponent();

            // Предустановим значение
            switch (currentType)
            {
                case "Книга":
                    radioButtonBook.Checked = true;
                    break;
                case "Комикс":
                    radioButtonComic.Checked = true;
                    break;
                case "Манга":
                    radioButtonManga.Checked = true;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (radioButtonBook.Checked)
                SelectedType = "Книга";
            else if (radioButtonComic.Checked)
                SelectedType = "Комикс";
            else if (radioButtonManga.Checked)
                SelectedType = "Манга";

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
