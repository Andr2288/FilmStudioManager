using FilmStudioManager.Models;
using FilmStudioManager.Services;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FilmStudioManager.Repositories
{
    public class UserRepository
    {
        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = new List<User>();

            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "SELECT UserID, Login, Password, Email FROM Users";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var user = new User
                {
                    UserID = reader.GetInt32("UserID"),
                    Login = reader.GetString("Login"),
                    Password = reader.GetString("Password"),
                    Email = reader.GetString("Email")
                };
                users.Add(user);
            }

            return users;
        }

        public async Task<User?> GetUserByLoginAsync(string login)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "SELECT UserID, Login, Password, Email FROM Users WHERE Login = @Login";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", login);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new User
                {
                    UserID = reader.GetInt32("UserID"),
                    Login = reader.GetString("Login"),
                    Password = reader.GetString("Password"),
                    Email = reader.GetString("Email")
                };
            }

            return null;
        }

        public async Task CreateUserAsync(User user)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                INSERT INTO Users (Login, Password, Email)
                VALUES (@Login, @Password, @Email)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", user.Login);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@Email", user.Email);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<bool> UserExistsAsync(string login, string email)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login OR Email = @Email";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Login", login);
            command.Parameters.AddWithValue("@Email", email);

            int count = (int)await command.ExecuteScalarAsync();
            return count > 0;
        }
    }
}