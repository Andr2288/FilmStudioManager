using BookcrossingApp.Models;
using BookcrossingApp.Repositories;
using BookcrossingApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookcrossingApp.Forms
{
    public partial class AddBookForm: Form
    {
        public AddBookForm()
        {
            InitializeComponent();

            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                GenreRepository genreRepository = new GenreRepository();
                List<Genre> genres = await genreRepository.GetAllGenresAsync();

                genreComboBox.DataSource = genres;
                genreComboBox.DisplayMember = "Name";
                genreComboBox.ValueMember = "UniqueIdentifier";

                LocationRepository locationRepository = new LocationRepository();
                List<Location> locations = await locationRepository.GetAllLocationsAsync();

                locationComboBox.DataSource = locations;
                locationComboBox.DisplayMember = "Name";
                locationComboBox.ValueMember = "UniqueIdentifier";
            }
            catch (InvalidOperationException ex) when (ex.Message?.Contains("Database is not connected") == true)
            {
                MessageBox.Show("Помилка з'єднання з базою даних: база даних не підключена.",
                                "Помилка бази даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}",
                                "Помилка бази даних", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            AddBook();
        }

        private async void AddBook()
        {
            addBookButton.Enabled = false;
            Cursor = Cursors.WaitCursor;

            string titleField = titleTextBox.Text.Trim();
            string authorField = authorTextBox.Text.Trim();
            string descriptionField = descriptionTextBox.Text.Trim();
            string genreField = genreComboBox.Text.Trim();
            string locationField = locationComboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(titleField))
            {
                MessageBox.Show("Назва книги є обов'язковою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(authorField))
            {
                MessageBox.Show("Автор книги є обов'язковим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(descriptionField))
            {
                MessageBox.Show("Опис книги є обов'язковим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(genreField))
            {
                MessageBox.Show("Жанр книги є обов'язковим!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(locationField))
            {
                MessageBox.Show("Локація книги є обов'язковою!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Book newBook = new Book(titleField, authorField, descriptionField, "Доступна");
                BookRepository bookRepository = new BookRepository();
                await bookRepository.CreateOrUpdateBookAsync(newBook);

                GenreRepository genreRepository = new GenreRepository();
                Genre findedGenre = await genreRepository.GetGenreByNameAsync(genreField);
                if (findedGenre == null)
                {
                    MessageBox.Show($"Жанр '{genreField}' не знайдено в базі даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await bookRepository.AddBookToGenreRelationshipAsync(newBook.UniqueIdentifier, findedGenre.UniqueIdentifier);

                LocationRepository locationRepository = new LocationRepository();
                Location findedLocation = await locationRepository.FindLocationByNameAsync(locationField);
                if (findedLocation == null)
                {
                    MessageBox.Show($"Локацію '{locationField}' не знайдено в базі даних!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await bookRepository.AddBookToLocationRelationshipAsync(newBook.UniqueIdentifier, findedLocation.UniqueIdentifier);

                UserRepository userRepository = new UserRepository();
                string userUniqueIdentifier = CurrentState.GetInstance().User?.UniqueIdentifier;
                if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                {
                    MessageBox.Show("Користувач не авторизований!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                await userRepository.AddUserAddedBookRelationshipAsync(userUniqueIdentifier, newBook.UniqueIdentifier);

                MessageBox.Show("Книгу успішно додано!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка при додаванні книги: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            addBookButton.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}