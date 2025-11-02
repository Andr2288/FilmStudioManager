using FilmStudioManager.Forms;
using FilmStudioManager.Models;
using FilmStudioManager.Repositories;
using FilmStudioManager.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmStudioManager
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();

            string connectionString = "Server=localhost;Database=FilmStudioManager;Integrated Security=True;TrustServerCertificate=True;";
            DatabaseService.Connect(connectionString);
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

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register();
        }

        private async void Register()
        {
            Cursor = Cursors.WaitCursor;
            registerButton.Enabled = false;

            if (!await CheckDatabaseConnection())
            {
                Cursor = Cursors.Default;
                registerButton.Enabled = true;
                return;
            }

            string emailField = emailTextBox.Text.Trim();
            string loginField = loginTextBox.Text.Trim();
            string passwordField = passwordTextBox.Text.Trim();

            if (createTestDatabaseCheckBox.Checked)
            {
                try
                {
                    await DatabaseInitializer.InitializeDatabaseAsync();
                    MessageBox.Show("Тестову базу даних створено успішно!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Помилка створення тестової БД: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Cursor = Cursors.Default;
                    registerButton.Enabled = true;
                    return;
                }
            }

            if (!ValidateRegistrationFields(emailField, loginField, passwordField))
            {
                Cursor = Cursors.Default;
                registerButton.Enabled = true;
                return;
            }

            try
            {
                UserRepository userRepository = new UserRepository();

                if (await userRepository.UserExistsAsync(loginField, emailField))
                {
                    MessageBox.Show("Користувач з такими даними вже існує.", "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    User newUser = new User(loginField, passwordField, emailField);
                    await userRepository.CreateUserAsync(newUser);

                    // Отримуємо створеного користувача з ID
                    User createdUser = await userRepository.GetUserByLoginAsync(loginField);
                    CurrentState.GetInstance().User = createdUser;

                    MessageBox.Show("Користувача успішно створено!", "Реєстрацію завершено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    MainForm mainForm = new MainForm();
                    mainForm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка під час реєстрації: {ex.Message}",
                    "Помилка реєстрації", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
            registerButton.Enabled = true;
        }

        private bool ValidateRegistrationFields(string email, string login, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Усі поля є обов'язковими для заповнення.",
                    "Помилка перевірки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                System.Text.RegularExpressions.RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Будь ласка, введіть коректну електронну адресу.",
                    "Помилка перевірки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (login.Length < 3 || !System.Text.RegularExpressions.Regex.IsMatch(login, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("Ім'я користувача повинно містити щонайменше 3 символи і складатися лише з літер, цифр та підкреслень.",
                    "Помилка перевірки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasMinimumLength = password.Length >= 6;

            if (!(hasUpperCase && hasLowerCase && hasDigit && hasMinimumLength))
            {
                MessageBox.Show("Пароль має бути не менше 6 символів і містити принаймні одну велику літеру, одну малу літеру та одну цифру.",
                    "Помилка перевірки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void goToLoginLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
