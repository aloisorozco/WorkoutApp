using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutTemplateController : ControllerBase
    {

        private readonly IMongoCollection<WorkoutTemplate> _workoutTemplates;

        public WorkoutTemplateController(MongoDbService mongoDbService)
        {
            _workoutTemplates = mongoDbService.Database?.GetCollection<WorkoutTemplate>("WorkoutTemplate");
        }

        [HttpGet]
        public async Task<IEnumerable<WorkoutTemplate>> Get()
        {
            return await _workoutTemplates.Find(FilterDefinition<WorkoutTemplate>.Empty).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutTemplate?>> GetById(string id)
        {
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.Id, id);
            var workoutTemplate = _workoutTemplates.Find(filter).FirstOrDefault();
            return workoutTemplate is not null ? Ok(workoutTemplate) : NotFound(); 
        }

        [HttpPost]
        public async Task<ActionResult> Post(WorkoutTemplate workoutTemplate)
        {
            await _workoutTemplates.InsertOneAsync(workoutTemplate);
            return CreatedAtAction(nameof(GetById), new { id = workoutTemplate.Id}, workoutTemplate);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(WorkoutTemplate workoutTemplate)
        {
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.Id, workoutTemplate.Id);

            await _workoutTemplates.ReplaceOneAsync(filter, workoutTemplate);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.Id, id);

            await _workoutTemplates.DeleteOneAsync(filter);
            return Ok();
        }


    }
}