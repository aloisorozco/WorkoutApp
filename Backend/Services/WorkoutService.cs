using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Backend.Data;
using Backend.Models;

namespace Backend.Services
{
    public class WorkoutService
    {

        private readonly IMongoCollection<Workout> _workouts;

        private readonly WorkoutTemplateService _workoutTemplateService;

        private readonly ExerciseService _exerciseService;


        public WorkoutService(MongoDbService mongoDbService, WorkoutTemplateService workoutTemplateService, ExerciseService exerciseService)
        {
            _workouts = mongoDbService.Database?.GetCollection<Workout>("Workout");
            _workoutTemplateService = workoutTemplateService;
            _exerciseService = exerciseService;
        }

        public async Task<IEnumerable<Workout>> Get(string userId)
        {
            if (userId is "")
            {
                return await _workouts.Find(FilterDefinition<Workout>.Empty).ToListAsync();
            }
            var filter = Builders<Workout>.Filter.Eq(x => x.UserId, userId);
            return await _workouts.Find(filter).ToListAsync();
        }

        public async Task<Workout> GetById(string id)
        {
            var filter = Builders<Workout>.Filter.Eq(x => x.Id, id);
            return _workouts.Find(filter).FirstOrDefault();
        }

        public async Task<Workout> Post(WorkoutTemplate workoutTemplate)
        {
            if (workoutTemplate.Id is null)
            {
                throw new Exception("Missing workout template id to create workout");
            }

            workoutTemplate = await _workoutTemplateService.GetById(workoutTemplate.Id);
            Workout workout = new()
            {
                Name = workoutTemplate.Name,
                UserId = workoutTemplate.UserId,
                Date = DateTime.UtcNow
            };
            await _workouts.InsertOneAsync(workout);

            foreach (string exercise in workoutTemplate.Exercises)
            {
                Exercise exerciseObj = new()
                {
                    WorkoutId = workout.Id,
                    Name = exercise
                };
                await _exerciseService.Post(exerciseObj);
            }

            return workout;
        }

        public async Task Update(Workout workout)
        {
            var filter = Builders<Workout>.Filter.Eq(x => x.Id, workout.Id);
            await _workouts.ReplaceOneAsync(filter, workout);
        }

        public async Task Delete(string id)
        {
            var filter = Builders<Workout>.Filter.Eq(x => x.Id, id);
            await _workouts.DeleteOneAsync(filter);
        }

    }
}