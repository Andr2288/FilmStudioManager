using FilmStudioManager.Models;
using FilmStudioManager.Services;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace FilmStudioManager.Repositories
{
    public class ProjectRepository
    {
        public async Task<List<Project>> GetAllProjectsAsync()
        {
            var projects = new List<Project>();

            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                SELECT ProjectID, ProjectName, ProjectTypeID, Budget, StartDate, EndDate, Status 
                FROM Projects
                ORDER BY StartDate DESC";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var project = new Project
                {
                    ProjectID = reader.GetInt32("ProjectID"),
                    ProjectName = reader.GetString("ProjectName"),
                    ProjectTypeID = reader.GetInt32("ProjectTypeID"),
                    Budget = reader.GetDecimal("Budget"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.IsDBNull("EndDate") ? null : reader.GetDateTime("EndDate"),
                    Status = reader.GetString("Status")
                };
                projects.Add(project);
            }

            return projects;
        }

        public async Task<Project> GetProjectByIdAsync(int projectId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                SELECT ProjectID, ProjectName, ProjectTypeID, Budget, StartDate, EndDate, Status 
                FROM Projects 
                WHERE ProjectID = @ProjectID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectID", projectId);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new Project
                {
                    ProjectID = reader.GetInt32("ProjectID"),
                    ProjectName = reader.GetString("ProjectName"),
                    ProjectTypeID = reader.GetInt32("ProjectTypeID"),
                    Budget = reader.GetDecimal("Budget"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.IsDBNull("EndDate") ? null : reader.GetDateTime("EndDate"),
                    Status = reader.GetString("Status")
                };
            }

            return null;
        }

        public async Task<int> CreateProjectAsync(Project project)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                INSERT INTO Projects (ProjectName, ProjectTypeID, Budget, StartDate, EndDate, Status)
                OUTPUT INSERTED.ProjectID
                VALUES (@ProjectName, @ProjectTypeID, @Budget, @StartDate, @EndDate, @Status)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
            command.Parameters.AddWithValue("@ProjectTypeID", project.ProjectTypeID);
            command.Parameters.AddWithValue("@Budget", project.Budget);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", (object)project.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@Status", project.Status);

            return (int)await command.ExecuteScalarAsync();
        }

        public async Task UpdateProjectAsync(Project project)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                UPDATE Projects 
                SET ProjectName = @ProjectName, ProjectTypeID = @ProjectTypeID, Budget = @Budget,
                    StartDate = @StartDate, EndDate = @EndDate, Status = @Status
                WHERE ProjectID = @ProjectID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectID", project.ProjectID);
            command.Parameters.AddWithValue("@ProjectName", project.ProjectName);
            command.Parameters.AddWithValue("@ProjectTypeID", project.ProjectTypeID);
            command.Parameters.AddWithValue("@Budget", project.Budget);
            command.Parameters.AddWithValue("@StartDate", project.StartDate);
            command.Parameters.AddWithValue("@EndDate", (object)project.EndDate ?? DBNull.Value);
            command.Parameters.AddWithValue("@Status", project.Status);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteProjectAsync(int projectId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "DELETE FROM Projects WHERE ProjectID = @ProjectID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectID", projectId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task AssignWorkerToProjectAsync(int projectId, int workerId, string role)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                INSERT INTO ProjectWorkers (ProjectID, WorkerID, Role)
                VALUES (@ProjectID, @WorkerID, @Role)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectID", projectId);
            command.Parameters.AddWithValue("@WorkerID", workerId);
            command.Parameters.AddWithValue("@Role", role);

            await command.ExecuteNonQueryAsync();
        }

        public async Task RemoveWorkerFromProjectAsync(int projectId, int workerId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "DELETE FROM ProjectWorkers WHERE ProjectID = @ProjectID AND WorkerID = @WorkerID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectID", projectId);
            command.Parameters.AddWithValue("@WorkerID", workerId);

            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Project>> GetProjectsByStatusAsync(string status)
        {
            var projects = new List<Project>();

            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = @"
                SELECT ProjectID, ProjectName, ProjectTypeID, Budget, StartDate, EndDate, Status 
                FROM Projects
                WHERE Status = @Status
                ORDER BY StartDate DESC";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Status", status);

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var project = new Project
                {
                    ProjectID = reader.GetInt32("ProjectID"),
                    ProjectName = reader.GetString("ProjectName"),
                    ProjectTypeID = reader.GetInt32("ProjectTypeID"),
                    Budget = reader.GetDecimal("Budget"),
                    StartDate = reader.GetDateTime("StartDate"),
                    EndDate = reader.IsDBNull("EndDate") ? null : reader.GetDateTime("EndDate"),
                    Status = reader.GetString("Status")
                };
                projects.Add(project);
            }

            return projects;
        }
    }
}
