using System;
using System.Windows.Forms;

namespace HomeLibrary
{
    public partial class AddBookForm : Form
    {
        public string BookTitle => titleTextBox.Text;
        public string Author => authorTextBox.Text;
        public string Genre => genreTextBox.Text;
        public int Year => int.TryParse(yearTextBox.Text, out var year) ? year : 0;
        public string Description => descriptionTextBox.Text;
        public string BookType
        {
            get
            {
                if (radioButtonBook.Checked)
                    return "Книга";
                else if (radioButtonComic.Checked)
                    return "Комикс";
                else if (radioButtonManga.Checked)
                    return "Манга";
                return "Неизвестно";
            }
        }

        public AddBookForm()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(BookTitle) || string.IsNullOrWhiteSpace(Author) ||
                string.IsNullOrWhiteSpace(Genre) || Year == 0 || string.IsNullOrWhiteSpace(BookType))
            {
                MessageBox.Show("Заполните все обязательные поля.");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}