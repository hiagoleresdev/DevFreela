namespace DevFreela.Core.Entities
{
    public class Skill : BaseEntity
    {
        public Skill(string description)
            :base()
        {
            Description = description;
        }

        public string Description { get; set; }
        public List<UserSkill> UserSkills { get; private set; }
    }
}
