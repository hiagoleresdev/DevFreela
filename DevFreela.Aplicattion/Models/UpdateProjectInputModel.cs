﻿namespace DevFreela.Application.Models
{
    public class UpdateProjectInputModel
    {
        public int idProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
