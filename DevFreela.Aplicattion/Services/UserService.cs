using DevFreela.Application.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infraestucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public class UserService : IUserService
    {

        private readonly DevFreelaDbContext _context;
        public UserService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel<List<UserViewModel>> GetAll()
        {
            var users = _context.Users.ToList();
            
            var model = users.Select(UserViewModel.FromEntity).ToList();

            return ResultViewModel<List<UserViewModel>>.Success(model);
        }
        public ResultViewModel<UserViewModel> GetById(int id)
        {
            var user = _context.Users.Include(u => u.Skills).ThenInclude(u => u.Skill).SingleOrDefault(u => u.Id == id);

            if (user is null)
                return ResultViewModel<UserViewModel>.Error("Usuário não encontrado.");

            var model = UserViewModel.FromEntity(user);

            return ResultViewModel<UserViewModel>.Success(model);
        }

        public ResultViewModel Post(CreateUserInputModel model)
        {
            var user = new User(model.FullName, model.Email, model.BirthDate);

            _context.Users.Add(user);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel PostSkills(int id, UserSkillsInputModel model)
        {
            var userSkills = model.SkillsId.Select(s => new UserSkill(id, s)).ToList();

            _context.UserSkills.AddRange(userSkills);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
