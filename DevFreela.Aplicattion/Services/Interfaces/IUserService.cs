using DevFreela.Application.Models;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        public ResultViewModel<List<UserViewModel>> GetAll();
        public ResultViewModel<UserViewModel> GetById(int id);
        public ResultViewModel Post(CreateUserInputModel model);
        public ResultViewModel PostSkills(int id, UserSkillsInputModel model);
    }
}
