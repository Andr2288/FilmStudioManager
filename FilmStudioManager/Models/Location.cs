using BookcrossingApp.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookcrossingApp.Models
{
    public class Location : INodeModel
    {
        public string UniqueIdentifier { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Location()
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();
        }

        public Location(string name, string type)
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();

            Name = name;
            Type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is Location location &&
                   UniqueIdentifier == location.UniqueIdentifier &&
                   Name == location.Name &&
                   Type == location.Type;
        }

        public override int GetHashCode()
        {
            int hashCode = -1611835416;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueIdentifier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Type);
            return hashCode;
        }
    }
}