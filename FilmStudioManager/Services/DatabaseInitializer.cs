using Microsoft.Data.SqlClient;

namespace FilmStudioManager.Services
{
    public class DatabaseInitializer
    {
        private const string MasterConnectionString =
            "Server=localhost;Database=master;Integrated Security=True;TrustServerCertificate=True;";

        private const string DatabaseConnectionString =
            "Server=localhost;Database=FilmStudioManager;Integrated Security=True;TrustServerCertificate=True;";

        public static async Task InitializeDatabaseAsync()
        {
            try
            {
                Console.WriteLine("=== Початок створення бази даних ===\n");

                await CreateDatabaseAsync();
                await CreateTablesAsync();
                await InsertTestDataAsync();

                Console.WriteLine("\n=== База даних успішно створена! ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ПОМИЛКА: {ex.Message}");
                Console.WriteLine($"Деталі: {ex.StackTrace}");
                throw;
            }
        }

        private static async Task CreateDatabaseAsync()
        {
            using var connection = new SqlConnection(MasterConnectionString);
            await connection.OpenAsync();
            Console.WriteLine("✓ Підключення до SQL Server успішне");

            string checkDbQuery = @"
                IF EXISTS (SELECT name FROM sys.databases WHERE name = 'FilmStudioManager')
                BEGIN
                    ALTER DATABASE FilmStudioManager SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    DROP DATABASE FilmStudioManager;
                END";

            using var checkCommand = new SqlCommand(checkDbQuery, connection);
            await checkCommand.ExecuteNonQueryAsync();

            string createDbQuery = "CREATE DATABASE FilmStudioManager;";
            using var createCommand = new SqlCommand(createDbQuery, connection);
            await createCommand.ExecuteNonQueryAsync();
            Console.WriteLine("✓ База даних FilmStudioManager створена");
        }

        private static async Task CreateTablesAsync()
        {
            using var connection = new SqlConnection(DatabaseConnectionString);
            await connection.OpenAsync();

            string createTablesQuery = @"
                -- Таблиця: Працівники
                CREATE TABLE Workers (
                    WorkerID INT PRIMARY KEY IDENTITY(1,1),
                    FirstName NVARCHAR(50) NOT NULL,
                    LastName NVARCHAR(50) NOT NULL,
                    Position NVARCHAR(50) NOT NULL,
                    Phone NVARCHAR(20),
                    Email NVARCHAR(100),
                    HireDate DATE NOT NULL,
                    Salary DECIMAL(10,2)
                );

                -- Таблиця: Типи проектів
                CREATE TABLE ProjectTypes (
                    ProjectTypeID INT PRIMARY KEY IDENTITY(1,1),
                    TypeName NVARCHAR(50) NOT NULL UNIQUE
                );

                -- Таблиця: Проекти
                CREATE TABLE Projects (
                    ProjectID INT PRIMARY KEY IDENTITY(1,1),
                    ProjectName NVARCHAR(200) NOT NULL,
                    ProjectTypeID INT NOT NULL,
                    Budget DECIMAL(15,2),
                    StartDate DATE NOT NULL,
                    EndDate DATE,
                    Status NVARCHAR(50) DEFAULT 'В роботі',
                    FOREIGN KEY (ProjectTypeID) REFERENCES ProjectTypes(ProjectTypeID)
                );

                -- Таблиця: Зв'язок працівників і проектів
                CREATE TABLE ProjectWorkers (
                    ProjectWorkerID INT PRIMARY KEY IDENTITY(1,1),
                    ProjectID INT NOT NULL,
                    WorkerID INT NOT NULL,
                    Role NVARCHAR(50) NOT NULL,
                    FOREIGN KEY (ProjectID) REFERENCES Projects(ProjectID) ON DELETE CASCADE,
                    FOREIGN KEY (WorkerID) REFERENCES Workers(WorkerID) ON DELETE CASCADE
                );

                -- Таблиця: Користувачі системи
                CREATE TABLE Users (
                    UserID INT PRIMARY KEY IDENTITY(1,1),
                    Login NVARCHAR(50) NOT NULL UNIQUE,
                    Password NVARCHAR(50) NOT NULL,
                    Email NVARCHAR(100) NOT NULL UNIQUE
                );
            ";

            using var command = new SqlCommand(createTablesQuery, connection);
            await command.ExecuteNonQueryAsync();
            Console.WriteLine("✓ Всі таблиці створені");
        }

        private static async Task InsertTestDataAsync()
        {
            using var connection = new SqlConnection(DatabaseConnectionString);
            await connection.OpenAsync();

            string insertDataQuery = @"
                -- Додаємо типи проектів
                INSERT INTO ProjectTypes (TypeName) VALUES 
                ('Реклама'),
                ('Серіал'),
                ('Повнометражний фільм');

                -- Додаємо працівників
                INSERT INTO Workers (FirstName, LastName, Position, Phone, Email, HireDate, Salary) VALUES
                ('Олександр', 'Довженко', 'Режисер', '+380501234567', 'dovzhenko@studio.ua', '2020-01-15', 45000.00),
                ('Марія', 'Приймаченко', 'Монтажер', '+380502345678', 'pryimachenko@studio.ua', '2021-03-20', 35000.00),
                ('Іван', 'Франко', 'Сценарист', '+380503456789', 'franko@studio.ua', '2019-06-10', 40000.00),
                ('Оксана', 'Забужко', 'Сценарист', '+380504567890', 'zabuzhko@studio.ua', '2022-02-01', 38000.00),
                ('Андрій', 'Курков', 'Оператор', '+380505678901', 'kurkov@studio.ua', '2020-09-05', 42000.00),
                ('Юрій', 'Іллєнко', 'Оператор', '+380506789012', 'illenko@studio.ua', '2021-07-12', 41000.00),
                ('Катерина', 'Горностай', 'Режисер', '+380507890123', 'hornostai@studio.ua', '2023-01-10', 43000.00),
                ('Сергій', 'Параджанов', 'Монтажер', '+380508901234', 'paradzhanov@studio.ua', '2020-11-22', 36000.00);

                -- Додаємо проекти
                INSERT INTO Projects (ProjectName, ProjectTypeID, Budget, StartDate, EndDate, Status) VALUES
                ('Реклама Київстар', 1, 150000.00, '2024-01-10', '2024-02-15', 'Завершено'),
                ('Серіал Слуга Народу 4', 2, 5000000.00, '2024-03-01', NULL, 'В роботі'),
                ('Фільм Чорний Ворон', 3, 12000000.00, '2023-09-01', '2024-09-30', 'Завершено'),
                ('Реклама Monobank', 1, 180000.00, '2024-06-01', '2024-07-10', 'Завершено'),
                ('Серіал Тіні Києва', 2, 4500000.00, '2024-08-15', NULL, 'В роботі'),
                ('Фільм Марія', 3, 15000000.00, '2024-10-01', NULL, 'В роботі');

                -- Призначаємо працівників на проекти
                INSERT INTO ProjectWorkers (ProjectID, WorkerID, Role) VALUES
                -- Реклама Київстар
                (1, 1, 'Режисер'), (1, 2, 'Монтажер'), (1, 5, 'Оператор'),
                -- Серіал Слуга Народу 4
                (2, 7, 'Режисер'), (2, 3, 'Сценарист'), (2, 8, 'Монтажер'), (2, 6, 'Оператор'),
                -- Фільм Чорний Ворон
                (3, 1, 'Режисер'), (3, 4, 'Сценарист'), (3, 2, 'Монтажер'), (3, 5, 'Оператор'),
                -- Реклама Monobank
                (4, 7, 'Режисер'), (4, 8, 'Монтажер'), (4, 6, 'Оператор'),
                -- Серіал Тіні Києва
                (5, 1, 'Режисер'), (5, 3, 'Сценарист'), (5, 2, 'Монтажер'), (5, 5, 'Оператор'),
                -- Фільм Марія
                (6, 7, 'Режисер'), (6, 4, 'Сценарист'), (6, 8, 'Монтажер'), (6, 6, 'Оператор');

                -- Додаємо тестового користувача
                INSERT INTO Users (Login, Password, Email) VALUES
                ('admin', 'admin123', 'admin@filmstudio.ua'),
                ('manager', 'manager123', 'manager@filmstudio.ua');
            ";

            using var command = new SqlCommand(insertDataQuery, connection);
            await command.ExecuteNonQueryAsync();
            Console.WriteLine("✓ Тестові дані додані");
        }

        public static async Task<bool> TestConnectionAsync()
        {
            try
            {
                using var connection = new SqlConnection(MasterConnectionString);
                await connection.OpenAsync();
                Console.WriteLine("✓ SQL Server доступний");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Помилка підключення до SQL Server: {ex.Message}");
                return false;
            }
        }

        public static string GetConnectionString()
        {
            return DatabaseConnectionString;
        }
    }
}
