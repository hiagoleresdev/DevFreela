using DevFreela.Application.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infraestucture.Persistence;

namespace DevFreela.Application.Services
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelaDbContext _context;
        public SkillService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<GetSkillsViewModel>> GetAll()
        {
            var skills = _context.Skills.ToList();
            var model = skills.Select(GetSkillsViewModel.ToEntity).ToList();

            return ResultViewModel<List<GetSkillsViewModel>>.Success(model);
        }

        public ResultViewModel Post(CreateSkillInputModel model)
        {
            var skill = new Skill(model.Description);

            _context.Skills.Add(skill);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
