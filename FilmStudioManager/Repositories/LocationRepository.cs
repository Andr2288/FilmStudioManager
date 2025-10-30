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
    public class LocationRepository
    {

        public async Task<List<Location>> GetAllLocationsAsync()
        {
            var query = "MATCH (l:Location) RETURN l";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query);
                var locations = new List<Location>();

                while (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    var location = new Location
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Name = node.Properties["Name"].As<string>(),
                        Type = node.Properties["Type"].As<string>()
                    };
                    locations.Add(location);
                }

                return locations;
            });
        }

        public async Task<Location> FindLocationByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Location name is required.", nameof(name));

            var query = @"
                MATCH (l:Location {Name: $name})
                RETURN l
                LIMIT 1";

            return await Neo4jQueryExecutor.ExecuteReadAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, new { name });
                if (await cursor.FetchAsync())
                {
                    var node = cursor.Current[0].As<INode>();
                    return new Location
                    {
                        UniqueIdentifier = node.Properties["UniqueIdentifier"].As<string>(),
                        Name = node.Properties["Name"].As<string>(),
                        Type = node.Properties["Type"].As<string>()
                    };
                }
                return null;
            });
        }

        public async Task CreateLocationAsync(Location location)
        {
            if (location == null)
                throw new ArgumentNullException(nameof(location));

            if (string.IsNullOrWhiteSpace(location.Name) || string.IsNullOrWhiteSpace(location.Type))
                throw new ArgumentException("Location name and type are required.");

            var query = @"
                CREATE (l:Location {
                    UniqueIdentifier: $uniqueIdentifier,
                    Name: $name,
                    Type: $type
                })
                RETURN l";

            var parameters = new
            {
                uniqueIdentifier = location.UniqueIdentifier,
                name = location.Name,
                type = location.Type
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }
    }
}