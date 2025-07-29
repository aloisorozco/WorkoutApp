using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class WorkoutTemplateService
    {

        private readonly IMongoCollection<WorkoutTemplate> _workoutTemplates;

        public WorkoutTemplateService(MongoDbService mongoDbService)
        {
            _workoutTemplates = mongoDbService.Database?.GetCollection<WorkoutTemplate>("WorkoutTemplate");
        }

        public async Task<IEnumerable<WorkoutTemplate>> Get(string userId)
        {
            if (userId is "")
            {
                return await _workoutTemplates.Find(FilterDefinition<WorkoutTemplate>.Empty).ToListAsync();
            }
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.UserId, userId);
            return await _workoutTemplates.Find(filter).ToListAsync();
        }

        public async Task<WorkoutTemplate> GetById(string id)
        {
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.Id, id);
            return _workoutTemplates.Find(filter).FirstOrDefault();
        }

        public async Task Post(WorkoutTemplate workoutTemplate)
        {
            await _workoutTemplates.InsertOneAsync(workoutTemplate);
        }

        public async Task Update(WorkoutTemplate workoutTemplate)
        {
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.Id, workoutTemplate.Id);
            await _workoutTemplates.ReplaceOneAsync(filter, workoutTemplate);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<WorkoutTemplate>.Filter.Eq(x => x.Id, id);
            await _workoutTemplates.DeleteOneAsync(filter);
        }

    }
}