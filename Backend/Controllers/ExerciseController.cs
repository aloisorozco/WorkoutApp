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
    public class ExerciseController : ControllerBase
    {

        private readonly ExerciseService _exerciseService;

        public ExerciseController(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        [HttpGet]
        public async Task<IEnumerable<Exercise>> Get(string workoutId)
        {
            return await _exerciseService.Get(workoutId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise?>> GetById(string id)
        {
            var Exercise = _exerciseService.GetById(id);
            return Exercise is not null ? Ok(User) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Exercise exercise)
        {
            await _exerciseService.Post(exercise);
            return CreatedAtAction(nameof(GetById), new { id = exercise.Id }, User);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(Exercise exercise)
        {
            await _exerciseService.Update(exercise);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _exerciseService.Delete(id);
            return Ok();
        }


    }
}