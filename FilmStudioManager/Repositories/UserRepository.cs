using BookcrossingApp.Models;
using BookcrossingApp.Services;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Repositories
{
    public class UserRepository
    {

        public async Task<List<User>> GetAllUsersAsync()
        {
            var query = "MATCH (u:User) RETURN u";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query);
                var users = new List<User>();

                while (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    var user = new User
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Login = node.Properties["Login"].As<string>(),
                        Password = node.Properties["Password"].As<string>(),
                        Email = node.Properties["Email"].As<string>()
                    };
                    users.Add(user);
                }

                return users;
            });
        }

        public async Task CreateUserAsync(User user)
        {
            var query = @"
                CREATE (u:User { 
                    UniqueIdentifier: $UniqueIdentifier,
                    Login: $Login,
                    Password: $Password,
                    Email: $Email
                })
            ";

            var parameters = new Dictionary<string, object>
            {
                { "UniqueIdentifier", user.UniqueIdentifier },
                { "Login", user.Login },
                { "Password", user.Password },
                { "Email", user.Email }
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                await queryRunner.RunAsync(query, parameters);
            });
        }

        public async Task AddUserAddedBookRelationshipAsync(string userUniqueIdentifier, string bookUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                throw new ArgumentException("User UniqueIdentifier is required.", nameof(userUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            var query = @"
                MATCH (u:User {UniqueIdentifier: $userUniqueIdentifier})
                MATCH (b:Book {UniqueIdentifier: $bookUniqueIdentifier})
                MERGE (u)-[:ADDED]->(b)
                RETURN u, b";

            var parameters = new
            {
                userUniqueIdentifier,
                bookUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }

        public async Task<List<Book>> GetBooksAddedByUserAsync(string userUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                throw new ArgumentException("User UniqueIdentifier is required.", nameof(userUniqueIdentifier));

            var query = @"
                MATCH (u:User {UniqueIdentifier: $userUniqueIdentifier})-[:ADDED]->(b:Book)
                RETURN b";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, new { userUniqueIdentifier });
                var books = new List<Book>();

                while (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    var book = new Book
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Title = node.Properties["Title"].As<string>(),
                        Author = node.Properties["Author"].As<string>(),
                        Description = node.Properties["Description"].As<string>(),
                        Status = node.Properties["Status"].As<string>()
                    };
                    books.Add(book);
                }

                return books;
            });
        }

        public async Task<List<Book>> GetBooksReferencedByUserRecordsAsync(string userUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                throw new ArgumentException("User UniqueIdentifier is required.", nameof(userUniqueIdentifier));

            var query = @"
                MATCH (u:User {UniqueIdentifier: $userUniqueIdentifier})<-[:MADE_BY]-(r:Record)-[:REFERS_TO]->(b:Book)
                RETURN b";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, new { userUniqueIdentifier });
                var books = new List<Book>();

                while (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    var book = new Book
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Title = node.Properties["Title"].As<string>(),
                        Author = node.Properties["Author"].As<string>(),
                        Description = node.Properties["Description"].As<string>(),
                        Status = node.Properties["Status"].As<string>()
                    };
                    books.Add(book);
                }

                return books;
            });
        }

        public async Task<Record> GetRecordAddedByUserAsync(string userUniqueIdentifier, string bookUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                throw new ArgumentException("User UniqueIdentifier is required.", nameof(userUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            var query = @"
        MATCH (u:User {UniqueIdentifier: $userUniqueIdentifier})<-[:MADE_BY]-(r:Record)-[:REFERS_TO]->(b:Book {UniqueIdentifier: $bookUniqueIdentifier})
        RETURN r
        LIMIT 1";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, new { userUniqueIdentifier, bookUniqueIdentifier });
                if (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    return new Record
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        BorrowDate = node.Properties["BorrowDate"].As<DateTime>(),
                        ReturnDate = node.Properties.ContainsKey("ReturnDate") && node.Properties["ReturnDate"] != null
                            ? (DateTime?)node.Properties["ReturnDate"].As<DateTime>()
                            : null
                    };
                }
                return null;
            });
        }
    }
}