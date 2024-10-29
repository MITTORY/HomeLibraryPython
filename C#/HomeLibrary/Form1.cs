using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace HomeLibrary
{
    public partial class Form1 : Form
    {
        private SQLiteConnection connection;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
            LoadData();
            InitializeComboBox();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void InitializeDatabase()
        {
            connection = new SQLiteConnection("Data Source=library.db;Version=3;");
            connection.Open();

            string createTableQuery = @"CREATE TABLE IF NOT EXISTS Books (
                                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                                        title TEXT NOT NULL,
                                        author TEXT NOT NULL,
                                        genre TEXT NOT NULL,
                                        year INTEGER NOT NULL,
                                        type TEXT NOT NULL,
                                        description TEXT
                                      );";

            SQLiteCommand command = new SQLiteCommand(createTableQuery, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }

        private void LoadData()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT id, title, author, genre, year, type, description FROM Books";
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(query, connection);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void InitializeComboBox()
        {
            comboBox1.Items.Add("Название");
            comboBox1.Items.Add("Автор");
            comboBox1.Items.Add("Жанр");
            comboBox1.SelectedIndex = 0;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchType = comboBox1.SelectedItem.ToString();
            SearchData(searchBox.Text, searchType);
        }

        private void SearchData(string searchTerm, string searchType)
        {
            try
            {
                connection.Open();

                string column;
                if (searchType == "Название")
                {
                    column = "title";
                }
                else if (searchType == "Автор")
                {
                    column = "author";
                }
                else if (searchType == "Жанр")
                {
                    column = "genre";
                }
                else
                {
                    column = "title";
                }

                string query = $"SELECT id, title, author, genre, year, type, description FROM Books WHERE {column} LIKE @searchTerm";

                SQLiteCommand command = new SQLiteCommand(query, connection);
                command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при поиске данных: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var addBookForm = new AddBookForm())
            {
                if (addBookForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        string insertQuery = "INSERT INTO Books (title, author, genre, year, type, description) " +
                                             "VALUES (@title, @author, @genre, @year, @type, @description)";

                        using (var command = new SQLiteCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@title", addBookForm.BookTitle);
                            command.Parameters.AddWithValue("@author", addBookForm.Author);
                            command.Parameters.AddWithValue("@genre", addBookForm.Genre);
                            command.Parameters.AddWithValue("@year", addBookForm.Year);
                            command.Parameters.AddWithValue("@type", addBookForm.BookType);
                            command.Parameters.AddWithValue("@description", addBookForm.Description);

                            command.ExecuteNonQuery();
                        }

                        MessageBox.Show("Книга успешно добавлена!");

                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при добавлении книги: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                int bookId = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["id"].Value);

                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();

                    string deleteQuery = "DELETE FROM Books WHERE id = @id";

                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@id", bookId);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Книга успешно удалена!");

                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при удалении книги: " + ex.Message);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите книгу для удаления.");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
                return;
            }

            var selectedRow = dataGridView.SelectedRows[0];
            string selectedProperty = string.Empty;
            int bookId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            using (var editSelectionForm = new EditSelectionForm())
            {
                if (editSelectionForm.ShowDialog() == DialogResult.OK)
                {
                    selectedProperty = editSelectionForm.SelectedProperty;

                    switch (selectedProperty)
                    {
                        case "Author":
                            using (var editAuthorForm = new EditAuthorForm(selectedRow.Cells["Author"].Value.ToString()))
                            {
                                if (editAuthorForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedRow.Cells["Author"].Value = editAuthorForm.EditedAuthor;
                                    UpdateDatabase(bookId, "Author", editAuthorForm.EditedAuthor);
                                    MessageBox.Show("Автор успешно изменён.");
                                }
                            }
                            break;

                        case "Title":
                            using (var editTitleForm = new EditTitleForm(selectedRow.Cells["Title"].Value.ToString()))
                            {
                                if (editTitleForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedRow.Cells["Title"].Value = editTitleForm.EditedTitle;
                                    UpdateDatabase(bookId, "Title", editTitleForm.EditedTitle);
                                    MessageBox.Show("Название успешно изменено.");
                                }
                            }
                            break;

                        case "Type":
                            using (var editTypeForm = new EditTypeForm(selectedRow.Cells["Type"].Value.ToString()))
                            {
                                if (editTypeForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedRow.Cells["Type"].Value = editTypeForm.SelectedType;
                                    UpdateDatabase(bookId, "Type", editTypeForm.SelectedType);
                                    MessageBox.Show("Тип успешно изменён.");
                                }
                            }
                            break;

                        case "Genre":
                            using (var editGenreForm = new EditGenreForm(selectedRow.Cells["Genre"].Value.ToString()))
                            {
                                if (editGenreForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedRow.Cells["Genre"].Value = editGenreForm.EditedGenre;
                                    UpdateDatabase(bookId, "Genre", editGenreForm.EditedGenre);
                                    MessageBox.Show("Жанр успешно изменён.");
                                }
                            }
                            break;

                        case "Year":
                            using (var editYearForm = new EditYearForm(Convert.ToInt32(selectedRow.Cells["Year"].Value)))
                            {
                                if (editYearForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedRow.Cells["Year"].Value = editYearForm.EditedYear;
                                    UpdateDatabase(bookId, "Year", editYearForm.EditedYear);
                                    MessageBox.Show("Год успешно изменён.");
                                }
                            }
                            break;

                        case "Description":
                            using (var editDescriptionForm = new EditDescriptionForm(selectedRow.Cells["Description"].Value.ToString()))
                            {
                                if (editDescriptionForm.ShowDialog() == DialogResult.OK)
                                {
                                    selectedRow.Cells["Description"].Value = editDescriptionForm.EditedDescription;
                                    UpdateDatabase(bookId, "Description", editDescriptionForm.EditedDescription);
                                    MessageBox.Show("Описание успешно изменено.");
                                }
                            }
                            break;

                        default:
                            MessageBox.Show("Неизвестный параметр.");
                            break;
                    }
                }
            }
        }

        private void UpdateDatabase(int bookId, string columnName, object newValue)
        {
            string query = $"UPDATE Books SET {columnName} = @newValue WHERE Id = @bookId";

            using (var connection = new SQLiteConnection("Data Source=library.db;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@newValue", newValue);
                    command.Parameters.AddWithValue("@bookId", bookId);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                openFileDialog.Title = "Выберите CSV файл для импорта";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                        {
                            string headerLine = reader.ReadLine();

                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                if (values.Length == 7) 
                                {
                                    string insertQuery = "INSERT INTO Books (title, author, genre, year, type, description) " +
                                                         "VALUES (@title, @author, @genre, @year, @type, @description)";

                                    using (var command = new SQLiteCommand(insertQuery, connection))
                                    {
                                        command.Parameters.AddWithValue("@title", values[1]);
                                        command.Parameters.AddWithValue("@author", values[2]);
                                        command.Parameters.AddWithValue("@genre", values[3]);
                                        command.Parameters.AddWithValue("@year", Convert.ToInt32(values[4]));
                                        command.Parameters.AddWithValue("@type", values[5]);
                                        command.Parameters.AddWithValue("@description", values[6]);

                                        if (connection.State == ConnectionState.Closed)
                                            connection.Open();

                                        command.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Импорт завершен успешно.");
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при импорте: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                            connection.Close();
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить как CSV файл";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine("ID,Title,Author,Genre,Year,Type,Description");

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cells = row.Cells;
                                    writer.WriteLine(string.Join(",", cells[0].Value, cells[1].Value, cells[2].Value,
                                                                    cells[3].Value, cells[4].Value, cells[5].Value,
                                                                    cells[6].Value));
                                }
                            }
                        }
                        MessageBox.Show("Экспорт завершен успешно.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при экспорте: " + ex.Message);
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var saveFormatForm = new SaveFormatForm())
            {
                if (saveFormatForm.ShowDialog() == DialogResult.OK)
                {
                    string format = saveFormatForm.SelectedFormat;

                    switch (format)
                    {
                        case "txt":
                            SaveAsTxt();
                            break;
                        case "excel":
                            SaveAsExcel();
                            break;
                        case "html":
                            SaveAsHtml();
                            break;
                    }
                }
            }
        }

        private void SaveAsTxt()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить библиотеку как TXT файл";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine("📚 Ваша домашняя библиотека:");
                            writer.WriteLine(new string('-', 80));

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cells = row.Cells;
                                    writer.WriteLine($"📖 \"{cells[1].Value}\"");
                                    writer.WriteLine($"   Автор: {cells[2].Value} | Жанр: {cells[3].Value} | Год: {cells[4].Value} | Тип: {cells[5].Value}");
                                    writer.WriteLine($"   Описание: {cells[6].Value ?? "Нет описания"}");
                                    writer.WriteLine(new string('-', 80));
                                }
                            }
                        }
                        MessageBox.Show("Библиотека успешно сохранена в TXT формате.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                    }
                }
            }
        }

        private void SaveAsExcel()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить библиотеку как Excel файл";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var package = new ExcelPackage())
                        {
                            var worksheet = package.Workbook.Worksheets.Add("Library");

                            worksheet.Cells[1, 1].Value = "Название книги";
                            worksheet.Cells[1, 2].Value = "Автор";
                            worksheet.Cells[1, 3].Value = "Жанр";
                            worksheet.Cells[1, 4].Value = "Год";
                            worksheet.Cells[1, 5].Value = "Тип";
                            worksheet.Cells[1, 6].Value = "Описание";

                            using (var headerRange = worksheet.Cells[1, 1, 1, 6])
                            {
                                headerRange.Style.Font.Bold = true;
                                headerRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                headerRange.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                                headerRange.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            }

                            worksheet.Column(1).Width = 30;
                            worksheet.Column(2).Width = 20;
                            worksheet.Column(3).Width = 15;
                            worksheet.Column(4).Width = 10;
                            worksheet.Column(5).Width = 10;
                            worksheet.Column(6).Width = 50;

                            int row = 2; 
                            foreach (DataGridViewRow dataRow in dataGridView.Rows)
                            {
                                if (!dataRow.IsNewRow)
                                {
                                    worksheet.Cells[row, 1].Value = dataRow.Cells[1].Value;
                                    worksheet.Cells[row, 2].Value = dataRow.Cells[2].Value;
                                    worksheet.Cells[row, 3].Value = dataRow.Cells[3].Value;
                                    worksheet.Cells[row, 4].Value = dataRow.Cells[4].Value;
                                    worksheet.Cells[row, 5].Value = dataRow.Cells[5].Value;
                                    worksheet.Cells[row, 6].Value = dataRow.Cells[6].Value ?? "Нет описания";

                                    worksheet.Cells[row, 1, row, 6].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                                    row++;
                                }
                            }

                            package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        }

                        MessageBox.Show("Библиотека успешно сохранена в формате Excel.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                    }
                }
            }
        }

        private void SaveAsHtml()
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "HTML files (*.html)|*.html|All files (*.*)|*.*";
                saveFileDialog.Title = "Сохранить библиотеку как HTML файл";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                        {
                            writer.WriteLine("<html>");
                            writer.WriteLine("<head><title>Ваша домашняя библиотека</title></head>");
                            writer.WriteLine("<body>");
                            writer.WriteLine("<h1>📚 Ваша домашняя библиотека:</h1>");
                            writer.WriteLine("<hr/>");

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {
                                if (!row.IsNewRow)
                                {
                                    var cells = row.Cells;
                                    writer.WriteLine($"<p>📖 <strong>\"{cells[1].Value}\"</strong></p>");
                                    writer.WriteLine($"<p>   Автор: {cells[2].Value} | Жанр: {cells[3].Value} | Год: {cells[4].Value} | Тип: {cells[5].Value}</p>");
                                    writer.WriteLine($"<p>   Описание: {cells[6].Value ?? "Нет описания"}</p>");
                                    writer.WriteLine("<hr/>");
                                }
                            }

                            writer.WriteLine("</body>");
                            writer.WriteLine("</html>");
                        }
                        MessageBox.Show("Библиотека успешно сохранена в формате HTML.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message);
                    }
                }
            }
        }

        private void leaveButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}