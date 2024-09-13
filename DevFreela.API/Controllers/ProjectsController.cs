﻿using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly FreelanceTotalCostConfig _config;
        public ProjectsController(IOptions<FreelanceTotalCostConfig> options)
        {
            _config = options.Value;
        }

        [HttpGet]
        public IActionResult Index(string search)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById()
        {
            throw new Exception();
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(CreateProjectInputModel model)
        {
            if(model.TotalCost < _config.Minimum || model.TotalCost > _config.Maximum)
                return BadRequest("Número fora dos limites!");

            return CreatedAtAction(nameof(GetById), new { }, model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectInputModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public IActionResult Complete(int id)
        {
            return NoContent();
        }

        [HttpPost("{id}/comments")]
        public IActionResult PostComment(int id, CreateProjectCommentInputModel model)
        {
            return Ok();
        }
       

    }
}
