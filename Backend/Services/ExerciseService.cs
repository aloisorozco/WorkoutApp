using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class ExerciseService
    {

        private readonly IMongoCollection<Exercise> _exercises;

        public ExerciseService(MongoDbService mongoDbService)
        {
            _exercises = mongoDbService.Database?.GetCollection<Exercise>("Exercise");
        }

        public async Task<IEnumerable<Exercise>> Get(string workoutId)
        {
            var filter = Builders<Exercise>.Filter.Eq(x => x.WorkoutId, workoutId);
            return await _exercises.Find(filter).ToListAsync();
        }

        public async Task<Exercise> GetById(string id)
        {
            var filter = Builders<Exercise>.Filter.Eq(x => x.Id, id);
            return _exercises.Find(filter).FirstOrDefault();
        }

        public async Task Post(Exercise exercise)
        {
            await _exercises.InsertOneAsync(exercise);
        }

        public async Task Update(Exercise exercise)
        {
            var filter = Builders<Exercise>.Filter.Eq(x => x.Id, exercise.Id);
            await _exercises.ReplaceOneAsync(filter, exercise);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<Exercise>.Filter.Eq(x => x.Id, id);
            await _exercises.DeleteOneAsync(filter);
        }

    }
}