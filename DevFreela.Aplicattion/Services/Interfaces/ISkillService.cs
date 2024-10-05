using DevFreela.Application.Models;

namespace DevFreela.Application.Services.Interfaces
{
    public interface ISkillService
    {
        public ResultViewModel<List<GetSkillsViewModel>> GetAll();

        public ResultViewModel Post(CreateSkillInputModel model);
    }
}
