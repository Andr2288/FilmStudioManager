using FilmStudioManager.Models;
using FilmStudioManager.Services;
using Microsoft.Data.SqlClient;
using System.Text;

namespace FilmStudioManager.Repositories
{
    public class ProjectTypeRepository
    {
        public async Task<List<ProjectType>> GetAllProjectTypesAsync()
        {
            var projectTypes = new List<ProjectType>();

            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "SELECT ProjectTypeID, TypeName FROM ProjectTypes ORDER BY TypeName";

            using var command = new SqlCommand(query, connection);
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var projectType = new ProjectType
                {
                    ProjectTypeID = reader.GetInt32("ProjectTypeID"),
                    TypeName = reader.GetString("TypeName")
                };
                projectTypes.Add(projectType);
            }

            return projectTypes;
        }

        public async Task<ProjectType> GetProjectTypeByIdAsync(int projectTypeId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "SELECT ProjectTypeID, TypeName FROM ProjectTypes WHERE ProjectTypeID = @ProjectTypeID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectTypeID", projectTypeId);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new ProjectType
                {
                    ProjectTypeID = reader.GetInt32("ProjectTypeID"),
                    TypeName = reader.GetString("TypeName")
                };
            }

            return null;
        }

        public async Task<ProjectType> GetProjectTypeByNameAsync(string typeName)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "SELECT ProjectTypeID, TypeName FROM ProjectTypes WHERE TypeName = @TypeName";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TypeName", typeName);

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new ProjectType
                {
                    ProjectTypeID = reader.GetInt32("ProjectTypeID"),
                    TypeName = reader.GetString("TypeName")
                };
            }

            return null;
        }

        public async Task CreateProjectTypeAsync(ProjectType projectType)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "INSERT INTO ProjectTypes (TypeName) VALUES (@TypeName)";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TypeName", projectType.TypeName);

            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateProjectTypeAsync(ProjectType projectType)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "UPDATE ProjectTypes SET TypeName = @TypeName WHERE ProjectTypeID = @ProjectTypeID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectTypeID", projectType.ProjectTypeID);
            command.Parameters.AddWithValue("@TypeName", projectType.TypeName);

            await command.ExecuteNonQueryAsync();
        }

        public async Task DeleteProjectTypeAsync(int projectTypeId)
        {
            using var connection = DatabaseService.GetConnection();
            await connection.OpenAsync();

            string query = "DELETE FROM ProjectTypes WHERE ProjectTypeID = @ProjectTypeID";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ProjectTypeID", projectTypeId);

            await command.ExecuteNonQueryAsync();
        }
    }
}
