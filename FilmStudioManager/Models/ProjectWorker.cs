namespace FilmStudioManager.Models
{
    public class ProjectWorker
    {
        public int ProjectWorkerID { get; set; }
        public int ProjectID { get; set; }
        public int WorkerID { get; set; }
        public string Role { get; set; } = string.Empty;

        public ProjectWorker()
        {
        }

        public ProjectWorker(int projectID, int workerID, string role)
        {
            ProjectID = projectID;
            WorkerID = workerID;
            Role = role;
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectWorker projectWorker &&
                   ProjectWorkerID == projectWorker.ProjectWorkerID &&
                   ProjectID == projectWorker.ProjectID &&
                   WorkerID == projectWorker.WorkerID &&
                   Role == projectWorker.Role;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProjectWorkerID, ProjectID, WorkerID, Role);
        }
    }
}
