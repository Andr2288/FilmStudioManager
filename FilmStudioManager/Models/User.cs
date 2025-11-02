namespace FilmStudioManager.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Login { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public User()
        {
        }

        public User(string login, string password, string email)
        {
            Login = login;
            Password = password;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   UserID == user.UserID &&
                   Login == user.Login &&
                   Password == user.Password &&
                   Email == user.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserID, Login, Password, Email);
        }
    }
}