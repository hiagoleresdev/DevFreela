﻿namespace DevFreela.API.Entities
{
    public class User
    {
        public User(string fullName, string email, DateTime birthDate)
            :base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;

            Skills = [];
            OwnedProject = [];
            FreelanceProjects = [];
            Comments = [];
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public bool Active { get; private set; }

        public List<UserSkill> Skills { get; set; }

        public List<Project> OwnedProject { get; set; } 
        public List<Project> FreelanceProjects { get; set; } 
        public List<ProjectComent> Comments { get; set; }
    }
}
