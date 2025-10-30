using BookcrossingApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Models
{

    public class Genre
    {

        public string UniqueIdentifier { get; set; }

        public string Name { get; set; }

        public Genre()
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();
        }

        public Genre(string name)
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();

            Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj is Genre genre &&
                   UniqueIdentifier == genre.UniqueIdentifier &&
                   Name == genre.Name;
        }

        public override int GetHashCode()
        {
            int hashCode = 2047100931;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueIdentifier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            return hashCode;
        }
    }
}