using FilmStudioManager.Models;
using FilmStudioManager.Services;
using Microsoft.Data.SqlClient;
using System.Text;

namespace FilmStudioManager.Repositories
{
    public class WorkerRepository
    {
        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            var workers = new List<Worker>();

            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                SELECT WorkerID, FirstName, LastName, Position, Phone, Email, HireDate, Salary 
                FROM Workers
                ORDER BY LastName, FirstName";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var worker = new Worker
                {
                    WorkerID = reader.GetInt32("WorkerID"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Position = reader.GetString("Position"),
                    Phone = reader.IsDBNull("Phone") ? null : reader.GetString("Phone"),
                    Email = reader.IsDBNull("Email") ? null : reader.GetString("Email"),
                    HireDate = reader.GetDateTime("HireDate"),
                    Salary = reader.GetDecimal("Salary")
                };
                workers.Add(worker);
            }

            return workers;
        }

        public async Task<Worker> GetWorkerByIdAsync(int workerId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                SELECT WorkerID, FirstName, LastName, Position, Phone, Email, HireDate, Salary 
                FROM Workers 
                WHERE WorkerID = @WorkerID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@WorkerID", workerId);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Worker
                {
                    WorkerID = reader.GetInt32("WorkerID"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Position = reader.GetString("Position"),
                    Phone = reader.IsDBNull("Phone") ? null : reader.GetString("Phone"),
                    Email = reader.IsDBNull("Email") ? null : reader.GetString("Email"),
                    HireDate = reader.GetDateTime("HireDate"),
                    Salary = reader.GetDecimal("Salary")
                };
            }

            return null;
        }

        public async Task CreateWorkerAsync(Worker worker)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                INSERT INTO Workers (FirstName, LastName, Position, Phone, Email, HireDate, Salary)
                VALUES (@FirstName, @LastName, @Position, @Phone, @Email, @HireDate, @Salary)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", worker.FirstName);
            command.Parameters.AddWithValue("@LastName", worker.LastName);
            command.Parameters.AddWithValue("@Position", worker.Position);
            command.Parameters.AddWithValue("@Phone", (object)worker.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("@Email", (object)worker.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@HireDate", worker.HireDate);
            command.Parameters.AddWithValue("@Salary", worker.Salary);

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateWorkerAsync(Worker worker)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                UPDATE Workers 
                SET FirstName = @FirstName, LastName = @LastName, Position = @Position, 
                    Phone = @Phone, Email = @Email, HireDate = @HireDate, Salary = @Salary
                WHERE WorkerID = @WorkerID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@WorkerID", worker.WorkerID);
            command.Parameters.AddWithValue("@FirstName", worker.FirstName);
            command.Parameters.AddWithValue("@LastName", worker.LastName);
            command.Parameters.AddWithValue("@Position", worker.Position);
            command.Parameters.AddWithValue("@Phone", (object)worker.Phone ?? DBNull.Value);
            command.Parameters.AddWithValue("@Email", (object)worker.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@HireDate", worker.HireDate);
            command.Parameters.AddWithValue("@Salary", worker.Salary);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteWorkerAsync(int workerId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "DELETE FROM Workers WHERE WorkerID = @WorkerID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@WorkerID", workerId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Worker>> GetWorkersByProjectIdAsync(int projectId)
        {
            var workers = new List<Worker>();

            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                SELECT w.WorkerID, w.FirstName, w.LastName, w.Position, w.Phone, w.Email, w.HireDate, w.Salary, pw.Role
                FROM Workers w
                INNER JOIN ProjectWorkers pw ON w.WorkerID = pw.WorkerID
                WHERE pw.ProjectID = @ProjectID
                ORDER BY w.LastName, w.FirstName";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectID", projectId);

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var worker = new Worker
                {
                    WorkerID = reader.GetInt32("WorkerID"),
                    FirstName = reader.GetString("FirstName"),
                    LastName = reader.GetString("LastName"),
                    Position = reader.GetString("Position"),
                    Phone = reader.IsDBNull("Phone") ? null : reader.GetString("Phone"),
                    Email = reader.IsDBNull("Email") ? null : reader.GetString("Email"),
                    HireDate = reader.GetDateTime("HireDate"),
                    Salary = reader.GetDecimal("Salary")
                };
                workers.Add(worker);
            }

            return workers;
        }
    }
}
