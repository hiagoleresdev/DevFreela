using DevFreela.API.Entities;

namespace DevFreela.API.Models
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title, int idClient, int idFreelancer, string description, string clientName, string freelancerName, decimal totalCost, List<ProjectComent> comments)
        {
            Id = id;
            ClientName = clientName;
            FreelancerName = freelancerName;
            TotalCost = totalCost;
        }

        public int Id { get; set; }

        public string ClientName { get; set; }
        public string FreelancerName { get; set; }

        public decimal TotalCost { get; set; }

    }
}
