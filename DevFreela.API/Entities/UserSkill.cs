namespace DevFreela.API.Entities
{
    public class UserSkill
    {
        public UserSkill(Guid idUser, Guid idSkill)
        {
            IdUsuario = idUser;
            IdSkill = idSkill;
        }

        public Guid IdUsuario { get; set; }
        public Guid IdSkill { get; set; }
        public Skill Skill { get; set; }
       
    }
}
