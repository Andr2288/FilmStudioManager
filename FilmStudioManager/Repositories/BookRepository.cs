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
    public class BookRepository
    {

        public async Task<List<Book>> GetAllBooksAsync()
        {
            var query = "MATCH (b:Book) RETURN b";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query);
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

        public async Task CreateOrUpdateBookAsync(Book book)
        {
            await Neo4jQueryExecutor.MergeNode("Book", "UniqueIdentifier", book);
        }

        public async Task AddBookToGenreRelationshipAsync(string bookUniqueIdentifier, string genreUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(genreUniqueIdentifier))
                throw new ArgumentException("Genre UniqueIdentifier is required.", nameof(genreUniqueIdentifier));

            var query = @"
                MATCH (b:Book {UniqueIdentifier: $bookUniqueIdentifier})
                MATCH (g:Genre {UniqueIdentifier: $genreUniqueIdentifier})
                MERGE (b)-[:HAS_GENRE]->(g)
                RETURN b, g";

            var parameters = new
            {
                bookUniqueIdentifier,
                genreUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }

        public async Task AddBookToLocationRelationshipAsync(string bookUniqueIdentifier, string locationUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(locationUniqueIdentifier))
                throw new ArgumentException("Location UniqueIdentifier is required.", nameof(locationUniqueIdentifier));

            var query = @"
                MATCH (b:Book {UniqueIdentifier: $bookUniqueIdentifier})
                MATCH (l:Location {UniqueIdentifier: $locationUniqueIdentifier})
                MERGE (b)-[:LOCATED_AT]->(l)
                RETURN b, l";

            var parameters = new
            {
                bookUniqueIdentifier,
                locationUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }

        public async Task<bool> IsBookAddedByUserAsync(string bookUniqueIdentifier, string userUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                throw new ArgumentException("User UniqueIdentifier is required.", nameof(userUniqueIdentifier));

            var query = @"
                MATCH (u:User {UniqueIdentifier: $userUniqueIdentifier})-[:ADDED]->(b:Book {UniqueIdentifier: $bookUniqueIdentifier})
                RETURN count(b) > 0 AS exists";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, new { userUniqueIdentifier, bookUniqueIdentifier });
                if (await cursor.FetchAsync())
                {
                    return cursor.Current["exists"].As<bool>();
                }
                return false;
            });
        }

        public async Task DeleteBookAsync(string bookUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            var query = @"
                MATCH (b:Book {UniqueIdentifier: $bookUniqueIdentifier})
                OPTIONAL MATCH (r:Record)-[:REFERS_TO]->(b)
                DETACH DELETE r, b";

            var parameters = new
            {
                bookUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }
    }
}