namespace FilmStudioManager.Models
{
    public class Worker
    {
        public int WorkerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }

        public Worker()
        {
        }

        public Worker(string firstName, string lastName, string position, string? phone, string? email, DateTime hireDate, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Position = position;
            Phone = phone;
            Email = email;
            HireDate = hireDate;
            Salary = salary;
        }

        public override bool Equals(object obj)
        {
            return obj is Worker worker &&
                   WorkerID == worker.WorkerID &&
                   FirstName == worker.FirstName &&
                   LastName == worker.LastName &&
                   Position == worker.Position &&
                   Phone == worker.Phone &&
                   Email == worker.Email &&
                   HireDate == worker.HireDate &&
                   Salary == worker.Salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(WorkerID, FirstName, LastName, Position, Phone, Email, HireDate, Salary);
        }
    }
}
