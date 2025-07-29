using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Backend.Data;
using Backend.Models;
using Backend.Services;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutTemplateController : ControllerBase
    {

        private readonly WorkoutTemplateService _workoutTemplateService;

        public WorkoutTemplateController(WorkoutTemplateService workoutTemplateService)
        {
            _workoutTemplateService = workoutTemplateService;
        }

        [HttpGet]
        public async Task<IEnumerable<WorkoutTemplate>> Get(string userId = "")
        {
            return await _workoutTemplateService.Get(userId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutTemplate?>> GetById(string id)
        {
            var workoutTemplate = await _workoutTemplateService.GetById(id);
            return workoutTemplate is not null ? Ok(workoutTemplate) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(WorkoutTemplate workoutTemplate)
        {
            await _workoutTemplateService.Post(workoutTemplate);
            return CreatedAtAction(nameof(GetById), new { id = workoutTemplate.Id }, workoutTemplate);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(WorkoutTemplate workoutTemplate)
        {
            await _workoutTemplateService.Update(workoutTemplate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _workoutTemplateService.Delete(id);
            return Ok();
        }


    }
}