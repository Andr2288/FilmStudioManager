namespace FilmStudioManager.Models
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public int ProjectTypeID { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; } = "В роботі";

        public Project()
        {
        }

        public Project(string projectName, int projectTypeID, decimal budget, DateTime startDate, DateTime? endDate, string status)
        {
            ProjectName = projectName;
            ProjectTypeID = projectTypeID;
            Budget = budget;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
        }

        public override bool Equals(object obj)
        {
            return obj is Project project &&
                   ProjectID == project.ProjectID &&
                   ProjectName == project.ProjectName &&
                   ProjectTypeID == project.ProjectTypeID &&
                   Budget == project.Budget &&
                   StartDate == project.StartDate &&
                   EndDate == project.EndDate &&
                   Status == project.Status;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProjectID, ProjectName, ProjectTypeID, Budget, StartDate, EndDate, Status);
        }
    }
}
