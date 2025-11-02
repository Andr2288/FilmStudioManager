using Microsoft.Data.SqlClient;

namespace FilmStudioManager.Services
{
    public static class DatabaseService
    {
        private static string _connectionString;

        public static void Connect(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static async Task<bool> TestConnectionAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("SELECT 1", connection);
                var result = await command.ExecuteScalarAsync();

                return result != null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection test failed: {ex.Message}");
                return false;
            }
        }

        public static SqlConnection GetConnection()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("Database is not connected.");

            return new SqlConnection(_connectionString);
        }

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
                throw new InvalidOperationException("Database is not connected.");

            return _connectionString;
        }
    }
}
