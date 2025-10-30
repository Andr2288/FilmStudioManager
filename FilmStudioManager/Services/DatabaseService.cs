using Neo4j.Driver;
using System;
using System.Threading.Tasks;

namespace BookcrossingApp.Services
{
    public static class DatabaseService
    {

        private static IDriver _driver;

        public static void Connect(string uri, string userName, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(userName, password));
        }

        public static async Task<bool> TestConnectionAsync()
        {
            IAsyncSession session = null;
            try
            {
                var driver = GetDriver();

                session = driver.AsyncSession();

                var readTask = session.ExecuteReadAsync(async tx =>
                {
                    var cursor = await tx.RunAsync("RETURN 1 AS result");
                    await cursor.ConsumeAsync();
                    return true;
                });

                var timeout = TimeSpan.FromSeconds(5);
                var delayTask = Task.Delay(timeout);

                var completedTask = await Task.WhenAny(readTask, delayTask);

                if (completedTask == readTask)
                {
                    return await readTask;
                }
                else
                {
                    Console.WriteLine("Database connection test timed out.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Database connection test failed: {ex.Message}");
                return false;
            }
            finally
            {
                if (session != null)
                {
                    await session.CloseAsync();
                }
            }
        }

        public static IDriver GetDriver()
        {
            if (_driver == null)
                throw new InvalidOperationException("Database is not connected.");

            return _driver;
        }

        public static async Task CloseAsync()
        {
            if (_driver != null)
            {
                await _driver.DisposeAsync();
            }
        }
    }
}