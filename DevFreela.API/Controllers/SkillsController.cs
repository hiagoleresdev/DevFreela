using DevFreela.Application.Models;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infraestucture.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
        private readonly DevFreelaDbContext _context;
        private readonly ISkillService _skillService;
        public SkillsController(DevFreelaDbContext context, ISkillService skillService)
        {
            _context = context;
            _skillService = skillService;   
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var result = _skillService.GetAll();

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(CreateSkillInputModel model)
        {
            var result = _skillService.Post(model);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
