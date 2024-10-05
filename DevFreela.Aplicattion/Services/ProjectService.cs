using DevFreela.Application.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Core.Entities;
using DevFreela.Infraestucture.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelaDbContext _context;
        public ProjectService(DevFreelaDbContext context)
        {
            _context = context;
        }

        public ResultViewModel Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return ResultViewModel.Error("O projeto não existe! ");

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return ResultViewModel.Error("O projeto não existe! ");

            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel<List<ProjectItemViewModel>> GetAll(string search = "", int page = 0, int size = 3)
        {
            var projects = _context.Projects
                .Include(t => t.Client)
                .Include(t => t.Freelancer)
                .Where(t => !t.IsDeleted && (search == "" || t.Title.Contains(search)))
                .Skip(page * size)
                .Take(size)
                .ToList();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            return  ResultViewModel<List<ProjectItemViewModel>>.Success(model);
        }

        public ResultViewModel<ProjectViewModel> GetById(int id)
        {
            var projects = _context.Projects
                .Include(t => t.Client)
                .Include(t => t.Freelancer)
                .Include(t => t.Comments)
                .SingleOrDefault(t => t.Id == id);

            if(projects is null)
                return ResultViewModel<ProjectViewModel>.Error("O projeto não existe! ");

            var model = ProjectViewModel.FromEntity(projects);
            return ResultViewModel<ProjectViewModel>.Success(model);
        }

        public ResultViewModel<int> Insert(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return ResultViewModel<int>.Success(project.Id);
        }

        public ResultViewModel InsertComment(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return ResultViewModel.Error("O projeto não existe! ");

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.ProjectComments.Update(comment);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return ResultViewModel.Error("O projeto não existe! ");

            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }

        public ResultViewModel Update(UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == model.idProject);

            if (project == null)
                return ResultViewModel.Error("O projeto não existe! ");

            project.Update(model.Title, model.Description, model.TotalCost);
            _context.Projects.Update(project);
            _context.SaveChanges();

            return ResultViewModel.Success();
        }
    }
}
