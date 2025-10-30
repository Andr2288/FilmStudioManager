using BookcrossingApp.Utils;
using System.Collections.Generic;

namespace BookcrossingApp.Models
{
    public class User : INodeModel
    {
        public string UniqueIdentifier { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User()
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();
        }

        public User(string login, string password, string email)
        {
            UniqueIdentifier = IdGenerator.GenerateUniqueId();

            Login = login;
            Password = password;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UniqueIdentifier == user.UniqueIdentifier &&
                   Login == user.Login &&
                   Password == user.Password &&
                   Email == user.Email;
        }

        public override int GetHashCode()
        {
            int hashCode = 483917726;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(UniqueIdentifier);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Login);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
            return hashCode;
        }
    }
}