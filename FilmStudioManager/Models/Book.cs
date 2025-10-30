using BookcrossingApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Models
{
    public class Book: INodeModel
    {

        public string UniqueIdentifier { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public Book()
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();
        }

        public Book(string title, string author, string description, string status)
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();

            Title = title;
            Author = author;
            Description = description;
            Status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   UniqueIdentifier == book.UniqueIdentifier &&
                   Title == book.Title &&
                   Author == book.Author &&
                   Description == book.Description &&
                   Status == book.Status;
        }

        public override int GetHashCode()
        {
            int hashCode = -2045634740;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueIdentifier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Author);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Status);
            return hashCode;
        }
    }
}