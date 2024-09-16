namespace DevFreela.API.Entities
{
    public class ProjectComent : BaseEntity
    {
        public ProjectComent(string content, int idProject, int idUser)
            :base()
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; set; }

        public int IdProject { get; set; }

        public Project Project { get; set; }

        public int IdUser { get; set; }

        public User User { get; set; }
    }
}
