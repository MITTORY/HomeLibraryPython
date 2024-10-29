using System;
using System.Windows.Forms;

namespace HomeLibrary
{
    public partial class SaveFormatForm : Form
    {
        public string SelectedFormat { get; private set; }

        public SaveFormatForm()
        {
            InitializeComponent();

            saveButton.Click += (sender, e) => {
                if (txtCheckBox.Checked) SelectedFormat = "txt";
                else if (excelCheckBox.Checked) SelectedFormat = "excel";
                else if (htmlCheckBox.Checked) SelectedFormat = "html";

                if (SelectedFormat != null)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите хотя бы один формат.");
                }
            };

            this.Controls.Add(txtCheckBox);
            this.Controls.Add(excelCheckBox);
            this.Controls.Add(htmlCheckBox);
            this.Controls.Add(saveButton);
        }
    }
}