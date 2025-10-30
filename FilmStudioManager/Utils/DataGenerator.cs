using BookcrossingApp.Models;
using BookcrossingApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Utils
{
    public static class DataGenerator
    {
        public static async Task ClearDatabaseAsync()
        {
            try
            {
                await Neo4jQueryExecutor.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync("MATCH (n) DETACH DELETE n");
                });
                Console.WriteLine("База даних успішно очищена");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під час очищення бази даних: {ex.Message}");
                throw;
            }
        }

        public static async void CreateTestData()
        {
            try
            {
                await ClearDatabaseAsync();

                var user1 = new User("ivan_koval", "12345678", "ivan@ukr.net");
                var user2 = new User("olena_shevchenko", "1234567890", "olena@ukr.net");

                var genre1 = new Genre("Художня література");
                var genre2 = new Genre("Нехудожня література");
                var genre3 = new Genre("Наука");
                var genre4 = new Genre("Історія");

                var location1 = new Location("Міська бібліотека", "Бібліотека");
                var location2 = new Location("Кав'ярня", "Кафе");
                var location3 = new Location("Університет", "Освітній заклад");

                var book1 = new Book("Великий Гетсбі", "Ф. Скотт Фіцджеральд", "Класичний роман", "Доступна");
                var book2 = new Book("Сапієнс", "Юваль Ной Харарі", "Коротка історія людства", "Позичена");
                var book3 = new Book("1984", "Джордж Орвелл", "Антиутопічний роман", "Доступна");
                var book4 = new Book("Коротка історія часу", "Стівен Гокінг", "Популярна наукова книга", "Доступна");
                var book5 = new Book("Володар перснів", "Дж.Р.Р. Толкін", "Фентезійна епопея", "Позичена");

                var records = new List<Record>
        {
            new Record(DateTime.Now.AddDays(-30), null),
            new Record(DateTime.Now.AddDays(-25), DateTime.Now.AddDays(-15)),
            new Record(DateTime.Now.AddDays(-20), null),
            new Record(DateTime.Now.AddDays(-18), DateTime.Now.AddDays(-10)),
            new Record(DateTime.Now.AddDays(-15), null),
            new Record(DateTime.Now.AddDays(-12), DateTime.Now.AddDays(-5)),
            new Record(DateTime.Now.AddDays(-10), null),
            new Record(DateTime.Now.AddDays(-8), DateTime.Now.AddDays(-2)),
            new Record(DateTime.Now.AddDays(-5), null),
            new Record(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1))
        };

                await Neo4jQueryExecutor.ExecuteWriteAsync(async tx =>
                {
                    await tx.RunAsync(
                        "CREATE (u1:User {UniqueIdentifier: $u1Id, Login: $u1Login, Password: $u1Password, Email: $u1Email})",
                        new { u1Id = user1.UniqueIdentifier, u1Login = user1.Login, u1Password = user1.Password, u1Email = user1.Email });
                    await tx.RunAsync(
                        "CREATE (u2:User {UniqueIdentifier: $u2Id, Login: $u2Login, Password: $u2Password, Email: $u2Email})",
                        new { u2Id = user2.UniqueIdentifier, u2Login = user2.Login, u2Password = user2.Password, u2Email = user2.Email });

                    await tx.RunAsync(
                        "CREATE (g1:Genre {UniqueIdentifier: $g1Id, Name: $g1Name})",
                        new { g1Id = genre1.UniqueIdentifier, g1Name = genre1.Name });
                    await tx.RunAsync(
                        "CREATE (g2:Genre {UniqueIdentifier: $g2Id, Name: $g2Name})",
                        new { g2Id = genre2.UniqueIdentifier, g2Name = genre2.Name });
                    await tx.RunAsync(
                        "CREATE (g3:Genre {UniqueIdentifier: $g3Id, Name: $g3Name})",
                        new { g3Id = genre3.UniqueIdentifier, g3Name = genre3.Name });
                    await tx.RunAsync(
                        "CREATE (g4:Genre {UniqueIdentifier: $g4Id, Name: $g4Name})",
                        new { g4Id = genre4.UniqueIdentifier, g4Name = genre4.Name });

                    await tx.RunAsync(
                        "CREATE (l1:Location {UniqueIdentifier: $l1Id, Name: $l1Name, Type: $l1Type})",
                        new { l1Id = location1.UniqueIdentifier, l1Name = location1.Name, l1Type = location1.Type });
                    await tx.RunAsync(
                        "CREATE (l2:Location {UniqueIdentifier: $l2Id, Name: $l2Name, Type: $l2Type})",
                        new { l2Id = location2.UniqueIdentifier, l2Name = location2.Name, l2Type = location2.Type });
                    await tx.RunAsync(
                        "CREATE (l3:Location {UniqueIdentifier: $l3Id, Name: $l3Name, Type: $l3Type})",
                        new { l3Id = location3.UniqueIdentifier, l3Name = location3.Name, l3Type = location3.Type });

                    await tx.RunAsync(
                        "CREATE (b1:Book {UniqueIdentifier: $b1Id, Title: $b1Title, Author: $b1Author, Description: $b1Desc, Status: $b1Status })",
                        new { b1Id = book1.UniqueIdentifier, b1Title = book1.Title, b1Author = book1.Author, b1Desc = book1.Description, b1Status = book1.Status });
                    await tx.RunAsync(
                        "CREATE (b2:Book {UniqueIdentifier: $b2Id, Title: $b2Title, Author: $b2Author, Description: $b2Desc, Status: $b2Status })",
                        new { b2Id = book2.UniqueIdentifier, b2Title = book2.Title, b2Author = book2.Author, b2Desc = book2.Description, b2Status = book2.Status });
                    await tx.RunAsync(
                        "CREATE (b3:Book {UniqueIdentifier: $b3Id, Title: $b3Title, Author: $b3Author, Description: $b3Desc, Status: $b3Status })",
                        new { b3Id = book3.UniqueIdentifier, b3Title = book3.Title, b3Author = book3.Author, b3Desc = book3.Description, b3Status = book3.Status });
                    await tx.RunAsync(
                        "CREATE (b4:Book {UniqueIdentifier: $b4Id, Title: $b4Title, Author: $b4Author, Description: $b4Desc, Status: $b4Status })",
                        new { b4Id = book4.UniqueIdentifier, b4Title = book4.Title, b4Author = book4.Author, b4Desc = book4.Description, b4Status = book4.Status });
                    await tx.RunAsync(
                        "CREATE (b5:Book {UniqueIdentifier: $b5Id, Title: $b5Title, Author: $b5Author, Description: $b5Desc, Status: $b5Status })",
                        new { b5Id = book5.UniqueIdentifier, b5Title = book5.Title, b5Author = book5.Author, b5Desc = book5.Description, b5Status = book5.Status });

                    for (int i = 0; i < records.Count; i++)
                    {
                        await tx.RunAsync(
                            "CREATE (r:Record {UniqueIdentifier: $rId, BorrowDate: $rBorrow, ReturnDate: $rReturn})",
                            new { rId = records[i].UniqueIdentifier, rBorrow = records[i].BorrowDate, rReturn = records[i].ReturnDate });
                    }

                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b1Id}), (u:User {UniqueIdentifier: $u1Id}) CREATE (b)-[:ADDED_BY]->(u)",
                        new { b1Id = book1.UniqueIdentifier, u1Id = user1.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b2Id}), (u:User {UniqueIdentifier: $u2Id}) CREATE (b)-[:ADDED_BY]->(u)",
                        new { b2Id = book2.UniqueIdentifier, u2Id = user2.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b3Id}), (u:User {UniqueIdentifier: $u1Id}) CREATE (b)-[:ADDED_BY]->(u)",
                        new { b3Id = book3.UniqueIdentifier, u1Id = user1.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b4Id}), (u:User {UniqueIdentifier: $u2Id}) CREATE (b)-[:ADDED_BY]->(u)",
                        new { b4Id = book4.UniqueIdentifier, u2Id = user2.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b5Id}), (u:User {UniqueIdentifier: $u1Id}) CREATE (b)-[:ADDED_BY]->(u)",
                        new { b5Id = book5.UniqueIdentifier, u1Id = user1.UniqueIdentifier });

                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b1Id}), (g:Genre {UniqueIdentifier: $g1Id}) CREATE (b)-[:HAS_GENRE]->(g)",
                        new { b1Id = book1.UniqueIdentifier, g1Id = genre1.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b2Id}), (g:Genre {UniqueIdentifier: $g2Id}) CREATE (b)-[:HAS_GENRE]->(g)",
                        new { b2Id = book2.UniqueIdentifier, g2Id = genre2.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b3Id}), (g:Genre {UniqueIdentifier: $g1Id}) CREATE (b)-[:HAS_GENRE]->(g)",
                        new { b3Id = book3.UniqueIdentifier, g1Id = genre1.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b4Id}), (g:Genre {UniqueIdentifier: $g3Id}) CREATE (b)-[:HAS_GENRE]->(g)",
                        new { b4Id = book4.UniqueIdentifier, g3Id = genre3.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b5Id}), (g:Genre {UniqueIdentifier: $g1Id}) CREATE (b)-[:HAS_GENRE]->(g)",
                        new { b5Id = book5.UniqueIdentifier, g1Id = genre1.UniqueIdentifier });

                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b1Id}), (l:Location {UniqueIdentifier: $l1Id}) CREATE (b)-[:LOCATED_AT]->(l)",
                        new { b1Id = book1.UniqueIdentifier, l1Id = location1.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b2Id}), (l:Location {UniqueIdentifier: $l2Id}) CREATE (b)-[:LOCATED_AT]->(l)",
                        new { b2Id = book2.UniqueIdentifier, l2Id = location2.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b3Id}), (l:Location {UniqueIdentifier: $l1Id}) CREATE (b)-[:LOCATED_AT]->(l)",
                        new { b3Id = book3.UniqueIdentifier, l1Id = location1.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b4Id}), (l:Location {UniqueIdentifier: $l3Id}) CREATE (b)-[:LOCATED_AT]->(l)",
                        new { b4Id = book4.UniqueIdentifier, l3Id = location3.UniqueIdentifier });
                    await tx.RunAsync(
                        "MATCH (b:Book {UniqueIdentifier: $b5Id}), (l:Location {UniqueIdentifier: $l2Id}) CREATE (b)-[:LOCATED_AT]->(l)",
                        new { b5Id = book5.UniqueIdentifier, l2Id = location2.UniqueIdentifier });

                    var books = new[] { book1, book2, book3, book4, book5 };
                    var users = new[] { user1, user2 };

                    for (int i = 0; i < records.Count; i++)
                    {
                        var book = books[i % books.Length];
                        var user = users[i % users.Length];

                        await tx.RunAsync(
                            "MATCH (r:Record {UniqueIdentifier: $rId}), (u:User {UniqueIdentifier: $uId}) CREATE (r)-[:MADE_BY]->(u)",
                            new { rId = records[i].UniqueIdentifier, uId = user.UniqueIdentifier });

                        await tx.RunAsync(
                            "MATCH (r:Record {UniqueIdentifier: $rId}), (b:Book {UniqueIdentifier: $bId}) CREATE (r)-[:REFERS_TO]->(b)",
                            new { rId = records[i].UniqueIdentifier, bId = book.UniqueIdentifier });
                    }
                });

                Console.WriteLine("Тестові дані успішно створено!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка під час створення тестових даних: {ex.Message}");
            }
        }
    }
}