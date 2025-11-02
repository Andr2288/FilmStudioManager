using FilmStudioManager.Models;
using FilmStudioManager.Repositories;
using FilmStudioManager.Services;

namespace FilmStudioManager.Forms
{
    public partial class LoginForm: Form
    {
        public LoginForm()
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

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        private async void Login()
        {
            Cursor = Cursors.WaitCursor;
            loginButton.Enabled = false;

            if (!await CheckDatabaseConnection())
            {
                Cursor = Cursors.Default;
                loginButton.Enabled = true;
                return;
            }

            string loginField = LoginTextBox.Text.Trim();
            string passwordField = PasswordTextBox.Text.Trim();

            UserRepository userRepository = new UserRepository();
            List<User> users = await userRepository.GetAllUsersAsync();

            User findedUser = users.FirstOrDefault(user => user.Login == loginField && user.Password == passwordField);

            if (findedUser != null)
            {
                CurrentState.GetInstance().User = findedUser;

                this.Hide();

                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Веедено невірний логін або пароль");
            }

            Cursor = Cursors.Default;
            loginButton.Enabled = true;
        }

        private void registerLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }
    }
}