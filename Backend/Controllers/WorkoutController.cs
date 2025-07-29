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
    public class WorkoutController : ControllerBase
    {

        private readonly WorkoutService _workoutService;

        public WorkoutController(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        [HttpGet]
        public async Task<IEnumerable<Workout>> Get(string userId = "")
        {
            return await _workoutService.Get(userId);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workout?>> GetById(string id)
        {
            var workout = await _workoutService.GetById(id);
            return workout is not null ? Ok(workout) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(WorkoutTemplate workoutTemplate)
        {
            var workout = await _workoutService.Post(workoutTemplate);
            return CreatedAtAction(nameof(GetById), new { id = workout.Id }, workout);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(Workout workout)
        {
            await _workoutService.Update(workout);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            await _workoutService.Delete(id);
            return Ok();
        }


    }
}