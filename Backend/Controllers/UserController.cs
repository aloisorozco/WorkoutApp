using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Backend.Data;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMongoCollection<User> _Users;

        public UserController(MongoDbService mongoDbService)
        {
            _Users = mongoDbService.Database?.GetCollection<User>("User");
        }

        /*
        TODO: disabled until we enable admin routes
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _Users.Find(FilterDefinition<User>.Empty).ToListAsync();
        }
        */

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetById(string id)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);
            var User = _Users.Find(filter).FirstOrDefault();
            return User is not null ? Ok(User) : NotFound(); 
        }

        [HttpPost]
        public async Task<ActionResult> Post(User User)
        {
            await _Users.InsertOneAsync(User);
            return CreatedAtAction(nameof(GetById), new { id = User.Id}, User);
        }

        [HttpPatch]
        public async Task<ActionResult> Update(User User)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, User.Id);

            await _Users.ReplaceOneAsync(filter, User);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var filter = Builders<User>.Filter.Eq(x => x.Id, id);

            await _Users.DeleteOneAsync(filter);
            return Ok();
        }


    }
}