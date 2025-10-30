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
    public class RecordRepository
    {
        public async Task CreateOrUpdateRecordAsync(Record record)
        {
            await Neo4jQueryExecutor.MergeNode("Record", "UniqueIdentifier", record);
        }

        public async Task AddRecordToUserRelationshipAsync(string recordUniqueIdentifier, string userUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(recordUniqueIdentifier))
                throw new ArgumentException("Record UniqueIdentifier is required.", nameof(recordUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(userUniqueIdentifier))
                throw new ArgumentException("User UniqueIdentifier is required.", nameof(userUniqueIdentifier));

            var query = @"
                MATCH (r:Record {UniqueIdentifier: $recordUniqueIdentifier})
                MATCH (u:User {UniqueIdentifier: $userUniqueIdentifier})
                MERGE (r)-[:MADE_BY]->(u)
                RETURN r, u";

            var parameters = new
            {
                recordUniqueIdentifier,
                userUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }

        public async Task AddRecordToBookRelationshipAsync(string recordUniqueIdentifier, string bookUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(recordUniqueIdentifier))
                throw new ArgumentException("Record UniqueIdentifier is required.", nameof(recordUniqueIdentifier));

            if (string.IsNullOrWhiteSpace(bookUniqueIdentifier))
                throw new ArgumentException("Book UniqueIdentifier is required.", nameof(bookUniqueIdentifier));

            var query = @"
                MATCH (r:Record {UniqueIdentifier: $recordUniqueIdentifier})
                MATCH (b:Book {UniqueIdentifier: $bookUniqueIdentifier})
                MERGE (r)-[:REFERS_TO]->(b)
                RETURN r, b";

            var parameters = new
            {
                recordUniqueIdentifier,
                bookUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }

        public async Task DeleteRecordAsync(string recordUniqueIdentifier)
        {
            if (string.IsNullOrWhiteSpace(recordUniqueIdentifier))
                throw new ArgumentException("Record UniqueIdentifier is required.", nameof(recordUniqueIdentifier));

            var query = @"
                MATCH (r:Record {UniqueIdentifier: $recordUniqueIdentifier})
                DETACH DELETE r";

            var parameters = new
            {
                recordUniqueIdentifier
            };

            await Neo4jQueryExecutor.ExecuteWriteAsync(async queryRunner =>
            {
                var cursor = await queryRunner.RunAsync(query, parameters);
                await cursor.ConsumeAsync();
            });
        }
    }
}