using BookcrossingApp.Models;
using BookcrossingApp.Repositories;
using BookcrossingApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookcrossingApp.Forms
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();

            DatabaseService.Connect("neo4j://localhost:7687", "neo4j", "1234567890");

            if (CurrentState.GetInstance().User == null)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        public async void LoadHomePage()
        {
            if (!await CheckDatabaseConnection()) return;

            try
            {
                BookRepository bookRepository = new BookRepository();

                Cursor = Cursors.WaitCursor;
                List<Book> books = await bookRepository.GetAllBooksAsync();

                HomeDataGridView.DataSource = books;
                ConfigureDataGridView(HomeDataGridView);
                SetupColumnsProperties(HomeDataGridView);

                returnBookButton.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public async void LoadMyBooksPage()
        {
            if (!await CheckDatabaseConnection()) return;

            try
            {
                UserRepository userRepository = new UserRepository();

                Cursor = Cursors.WaitCursor;
                List<Book> books = await userRepository.GetBooksAddedByUserAsync(CurrentState.GetInstance().User.UniqueIdentifier);

                HomeDataGridView.DataSource = books;
                ConfigureDataGridView(HomeDataGridView);
                SetupColumnsProperties(HomeDataGridView);

                returnBookButton.Enabled = false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        public async void LoadBorrowedPage()
        {
            if (!await CheckDatabaseConnection()) return;

            try
            {
                UserRepository userRepository = new UserRepository();

                Cursor = Cursors.WaitCursor;
                List<Book> books = await userRepository.GetBooksReferencedByUserRecordsAsync(CurrentState.GetInstance().User.UniqueIdentifier);
                List<Book> booksToShow = books.Where(b => b.Status == "Позичена").ToList();

                HomeDataGridView.DataSource = booksToShow;
                ConfigureDataGridView(HomeDataGridView);
                SetupColumnsProperties(HomeDataGridView);

                returnBookButton.Enabled = true;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async Task<bool> CheckDatabaseConnection()
        {
            bool isConnected = await DatabaseService.TestConnectionAsync();

            if (!isConnected)
            {
                MessageBox.Show("Не вдалося підключитися до бази даних. Деякі функції можуть бути недоступні.",
                                "Помилка підключення до бази даних", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isConnected;
        }

        private void UpdateCurrentForm()
        {
            User currentUser = CurrentState.GetInstance().User;

            if (currentUser != null)
            {
                welcomeLabel1.Text = "Вітаємо, " + CurrentState.GetInstance().User.Login + "!";
                myBooksButton.Enabled = true;
                borrowedButton.Enabled = true;
                logoutButton.Enabled = true;

                borrowBookButton.Enabled = true;
                addBookButton.Enabled = true;
            }
            else
            {
                welcomeLabel1.Text = "Спочатку увійдіть, будь ласка!";
                myBooksButton.Enabled = false;
                borrowedButton.Enabled = false;
                logoutButton.Enabled = false;

                borrowBookButton.Enabled = false;
                addBookButton.Enabled = false;
            }
        }

        private void homeButton_Click(object sender, EventArgs e)
        {
            LoadHomePage();
        }

        public static void ConfigureDataGridView(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 185);
            dataGridView.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(35, 75, 175);

            dataGridView.RowsDefaultCellStyle.BackColor = Color.FromArgb(66, 65, 75);
            dataGridView.RowsDefaultCellStyle.ForeColor = Color.WhiteSmoke;
            dataGridView.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(90, 90, 100);

            dataGridView.BackgroundColor = Color.FromArgb(48, 51, 58);
        }

        private void SetupColumnsProperties(DataGridView dataGridView)
        {
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            CurrentState.GetInstance().User = null;
            UpdateCurrentForm();

            this.Hide();

            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            AddBookForm addBookForm = new AddBookForm();
            addBookForm.ShowDialog();
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            UpdateCurrentForm();

            if (HomeDataGridView.SelectedRows.Count <= 0)
            {
                LoadHomePage();
            }
        }

        private async void BorrowBook()
        {
            Cursor = Cursors.WaitCursor;
            borrowBookButton.Enabled = false;

            if (HomeDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = HomeDataGridView.SelectedRows[0];

                var bookToBorrow = new Book
                {
                    UniqueIdentifier = selectedRow.Cells["UniqueIdentifier"].Value?.ToString(),
                    Title = selectedRow.Cells["Title"].Value?.ToString(),
                    Author = selectedRow.Cells["Author"].Value?.ToString(),
                    Description = selectedRow.Cells["Description"].Value?.ToString(),
                    Status = selectedRow.Cells["Status"].Value?.ToString()
                };

                BookRepository bookRepository = new BookRepository();
                bool isMyBook = await bookRepository.IsBookAddedByUserAsync(bookToBorrow.UniqueIdentifier, CurrentState.GetInstance().User.UniqueIdentifier);

                if (bookToBorrow.Status != "Доступна" || isMyBook)
                {
                    MessageBox.Show("Ви не можете позичити дану книгу!");

                    Cursor = Cursors.Default;
                    borrowBookButton.Enabled = true;
                    return;
                }

                bookToBorrow.Status = "Позичена";

                await bookRepository.CreateOrUpdateBookAsync(bookToBorrow);

                Record newRecord = new Record(new DateTime(), new DateTime());
                RecordRepository recordRepository = new RecordRepository();
                await recordRepository.CreateOrUpdateRecordAsync(newRecord);

                await recordRepository.AddRecordToUserRelationshipAsync(newRecord.UniqueIdentifier, CurrentState.GetInstance().User.UniqueIdentifier);
                await recordRepository.AddRecordToBookRelationshipAsync(newRecord.UniqueIdentifier, bookToBorrow.UniqueIdentifier);

                MessageBox.Show($"Ви успішно позичили книгу '{bookToBorrow.Title}'");
            }
            else
            {
                MessageBox.Show("Спочатку оберіть книгу!");
            }

            Cursor = Cursors.Default;
            borrowBookButton.Enabled = true;
        }

        private void borrowBookButton_Click(object sender, EventArgs e)
        {
            BorrowBook();
        }

        private void myBooksButton_Click(object sender, EventArgs e)
        {
            LoadMyBooksPage();
        }

        private void borrowedButton_Click(object sender, EventArgs e)
        {
            LoadBorrowedPage();
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            DeleteBook();
        }

        private async void DeleteBook()
        {
            deleteBookButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            if (HomeDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = HomeDataGridView.SelectedRows[0];

                var bookToDelete = new Book
                {
                    UniqueIdentifier = selectedRow.Cells["UniqueIdentifier"].Value?.ToString(),
                    Title = selectedRow.Cells["Title"].Value?.ToString(),
                    Author = selectedRow.Cells["Author"].Value?.ToString(),
                    Description = selectedRow.Cells["Description"].Value?.ToString(),
                    Status = selectedRow.Cells["Status"].Value?.ToString()
                };

                BookRepository bookRepository = new BookRepository();
                bool isMyBook = await bookRepository.IsBookAddedByUserAsync(bookToDelete.UniqueIdentifier, CurrentState.GetInstance().User.UniqueIdentifier);

                if (isMyBook)
                {
                    await bookRepository.DeleteBookAsync(bookToDelete.UniqueIdentifier);
                    LoadHomePage();
                }
                else
                {
                    MessageBox.Show("Ви не можете видалити книгу, яку ви не добавляли");
                }
            }

            deleteBookButton.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void returnBookButton_Click(object sender, EventArgs e)
        {
            ReturnBook();
        }

        private async void ReturnBook()
        {
            returnBookButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            if (HomeDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = HomeDataGridView.SelectedRows[0];

                var bookToReturn = new Book
                {
                    UniqueIdentifier = selectedRow.Cells["UniqueIdentifier"].Value?.ToString(),
                    Title = selectedRow.Cells["Title"].Value?.ToString(),
                    Author = selectedRow.Cells["Author"].Value?.ToString(),
                    Description = selectedRow.Cells["Description"].Value?.ToString(),
                    Status = selectedRow.Cells["Status"].Value?.ToString()
                };

                bookToReturn.Status = "Доступна";
                BookRepository bookRepository = new BookRepository();
                await bookRepository.CreateOrUpdateBookAsync(bookToReturn);

                UserRepository userRepository = new UserRepository();
                Record findedRecord = await userRepository.GetRecordAddedByUserAsync(CurrentState.GetInstance().User.UniqueIdentifier, bookToReturn.UniqueIdentifier);
                RecordRepository recordRepository = new RecordRepository();
                await recordRepository.DeleteRecordAsync(findedRecord.UniqueIdentifier);

                MessageBox.Show($"Ви успішно повернули книгу '{bookToReturn.Title}'");
            }

            returnBookButton.Enabled = true;
            Cursor = Cursors.Default;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadHomePage();
        }
    }
}