using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, int idClient, int idFreelancer, string description, string clientName, string freelancerName, decimal totalCost, List<ProjectComent> comments)
        {
            Id = id;
            Title = title;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            Description = description;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
            Comments = comments.Select(t=> t.Content).ToList();
        }
        public int Id { get; set; }

        public string Title { get; set; }
        public int IdClient { get; private set; }
        public int IdFreelancer { get; private set; }
        public string Description { get; set; }

        public string ClientName { get; set; }
        public string FreelancerName { get; set; }

        public decimal TotalCost { get; set; }

        public List<string> Comments { get; set; }

        // Com esse método, não é necessário mapear o objeto
        public static ProjectViewModel FromEntity(Project entity)
            => new ProjectViewModel(entity.Id, entity.Title, entity.IdClient, entity.IdFreelancer, entity.Description, entity.Client.FullName, entity.Freelancer.FullName, entity.TotalCost, entity.Comments);
    }
}
