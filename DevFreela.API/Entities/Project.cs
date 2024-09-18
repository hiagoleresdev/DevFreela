﻿using DevFreela.API.Enums;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace DevFreela.API.Entities
{
    public class Project : BaseEntity
    {
        public Project(string title, string description, int idClient, int idFreelancer, decimal totalCost)
            :base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;
            Status = ProjectStatusEnum.Created;
            Comments = [];
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int IdClient { get; private set; }

        public User Client {  get; private set; }

        public int IdFreelancer { get; private set; }

        public User Freelancer { get; private set; }

        public decimal TotalCost { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? CompletedAt { get; set; }

        public ProjectStatusEnum Status { get; set; }

        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
                Status = ProjectStatusEnum.Cancelled;
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
                Status = ProjectStatusEnum.InProgress;
            CompletedAt = DateTime.Now;
        }

        public void Complete()
        {
            if(Status == ProjectStatusEnum.PaymentPending || Status ==  ProjectStatusEnum.InProgress)
                Status = ProjectStatusEnum.Completed;
            CompletedAt = DateTime.Now; 
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectStatusEnum.InProgress)
                Status = ProjectStatusEnum.PaymentPending;
        }

        public void Update(string titulo, string description, decimal totalCosta)
        {
            Title = titulo;
            Description = description;  
            TotalCost = totalCosta;
        }




    }
}
