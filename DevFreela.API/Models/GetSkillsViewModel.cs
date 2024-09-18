using DevFreela.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Net.NetworkInformation;

namespace DevFreela.API.Models
{
    public class GetSkillsViewModel
    {
        public GetSkillsViewModel(string description)
        {
            Description = description;
        }
        public string Description { get; set; }

        public static GetSkillsViewModel ToEntity(Skill skill) => new (skill.Description);
    }
}
