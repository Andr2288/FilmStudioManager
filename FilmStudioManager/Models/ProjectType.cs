namespace FilmStudioManager.Models
{
    public class ProjectType
    {
        public int ProjectTypeID { get; set; }
        public string TypeName { get; set; } = string.Empty;

        public ProjectType()
        {
        }

        public ProjectType(string typeName)
        {
            TypeName = typeName;
        }

        public override bool Equals(object obj)
        {
            return obj is ProjectType projectType &&
                   ProjectTypeID == projectType.ProjectTypeID &&
                   TypeName == projectType.TypeName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProjectTypeID, TypeName);
        }
    }
}
