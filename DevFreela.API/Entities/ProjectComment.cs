namespace DevFreela.API.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
            :base()
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public int Id { get; private set; }
        public string Content { get; set; }

        public int IdProject { get; set; }

        public Project Project { get; set; }

        public int IdUser { get; set; }

        public User User { get; set; }
    }
}
