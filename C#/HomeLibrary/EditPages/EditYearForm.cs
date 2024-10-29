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
    public partial class EditYearForm : Form
    {
        public int EditedYear { get; private set; }

        public EditYearForm(int currentYear)
        {
            InitializeComponent();
            textBoxYear.Text = currentYear.ToString();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBoxYear.Text, out int year))
            {
                EditedYear = year;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректный год.");
            }
        }
    }
}
