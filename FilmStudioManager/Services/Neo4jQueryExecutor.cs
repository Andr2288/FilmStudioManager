using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookcrossingApp.Services
{
    public static class Neo4jQueryExecutor
    {

        public static async Task ExecuteWriteAsync(Func<IAsyncQueryRunner, Task> action)
        {
            var session = DatabaseService.GetDriver().AsyncSession();
            try
            {
                await session.ExecuteWriteAsync(action);
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public static async Task<T> ExecuteReadAsync<T>(Func<IAsyncQueryRunner, Task<T>> action)
        {
            var session = DatabaseService.GetDriver().AsyncSession();
            try
            {
                return await session.ExecuteReadAsync(action);
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public static async Task MergeNode<T>(string label, string keyProperty, T node)
        {
            var session = DatabaseService.GetDriver().AsyncSession();

            try
            {
                var properties = new Dictionary<string, object>();
                object keyValue = null;

                foreach (var prop in typeof(T).GetProperties())
                {
                    var value = prop.GetValue(node);

                    if (value != null && prop.PropertyType.IsEnum)
                    {
                        properties[prop.Name] = value.ToString();
                    }
                    else
                    {
                        properties[prop.Name] = value;
                    }

                    if (prop.Name == keyProperty)
                    {
                        keyValue = value;
                    }
                }

                if (keyValue == null)
                {
                    throw new ArgumentException($"Key property '{keyProperty}' not found or is null.");
                }

                await session.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync(
                        $"MERGE (n:{label} {{{keyProperty}: $keyValue}}) " +
                        "SET n += $properties",
                        new { keyValue, properties }
                    );
                });
            }
            finally
            {
                await session.CloseAsync();
            }
        }

        public static async Task ExecuteCreatingRelationshipAsync(string fromNodeLabel, string fromNodeId, string toNodeLabel, string toNodeId, string relationName)
        {
            var session = DatabaseService.GetDriver().AsyncSession();
            try
            {
                await session.ExecuteWriteAsync(async tx =>
                {
                    var query = $"MATCH (fromNode:{fromNodeLabel} {{UniqueIdentifier: $fromNodeId}}), (toNode:{toNodeLabel} {{UniqueIdentifier: $toNodeId}}) " +
                                $"MERGE (fromNode)-[:{relationName}]->(toNode)";

                    await tx.RunAsync(query, new { fromNodeId, toNodeId });
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating relationship: {ex.Message}");
            }
            finally
            {
                await session.CloseAsync();
            }
        }
    }
}