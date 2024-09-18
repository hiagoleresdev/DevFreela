using DevFreela.API.Entities;
using DevFreela.API.Models;
using DevFreela.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        public ProjectsController(DevFreelaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string search = "", int page = 0, int size = 3)
        {
            var projects = _context.Projects
                .Include(t=> t.Client)
                .Include(t=> t.Freelancer)
                .Where(t => !t.IsDeleted && (search == "" || t.Title.Contains(search)))
                .Skip(page * size)
                .Take(size)
                .ToList();

            var model = projects.Select(ProjectItemViewModel.FromEntity).ToList();
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var projects = _context.Projects
                .Include(t => t.Client)
                .Include(t => t.Freelancer)
                .Include(t => t.Comments)
                .SingleOrDefault(t => t.Id == id);
            
            var model = ProjectViewModel.FromEntity(projects);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            var project = model.ToEntity();

            _context.Projects.Add(project);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = 1 }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(t=> t.Id == id);

            if (project == null)
                return NotFound();

            project.Update(model.Title, model.Description, model.TotalCost);
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return NotFound();

            project.SetAsDeleted();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return NotFound();

            project.Start();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return NotFound();

            project.Complete();
            _context.Projects.Update(project);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            var project = _context.Projects.SingleOrDefault(t => t.Id == id);

            if (project == null)
                return NotFound();

            var comment = new ProjectComment(model.Content, model.IdProject, model.IdUser);
            _context.Projects.Update(project);
            _context.SaveChanges();

            return Ok();
        }
       
    }
}
