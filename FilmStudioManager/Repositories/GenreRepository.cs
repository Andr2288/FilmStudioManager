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
    public class GenreRepository
    {

        public async Task<List<Genre>> GetAllGenresAsync()
        {
            var query = "MATCH (g:Genre) RETURN g";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query);
                var genres = new List<Genre>();

                while (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    var genre = new Genre
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Name = node.Properties["Name"].As<string>()
                    };
                    genres.Add(genre);
                }

                return genres;
            });
        }

        public async Task<Genre> GetGenreByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Genre name is required.", nameof(name));

            var query = @"
                MATCH (g:Genre {Name: $name})
                RETURN g
                LIMIT 1";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, new { name });
                if (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    return new Genre
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Name = node.Properties["Name"].As<string>()
                    };
                }
                return null;
            });
        }

        public async Task CreateGenreAsync(Genre genre)
        {
            if (genre == null)
                throw new ArgumentNullException(nameof(genre));

            if (string.IsNullOrWhiteSpace(genre.Name))
                throw new ArgumentException("Genre name is required.");

            var query = @"
                CREATE (g:Genre {
                    UniqueIdentifier: $uniqueIdentifier,
                    Name: $name
                })
                RETURN g";

            var parameters = new
            {
                uniqueIdentifier = genre.UniqueIdentifier,
                name = genre.Name
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }
    }
}