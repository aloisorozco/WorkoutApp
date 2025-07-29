using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class Exercise
    {
        [BsonId]
        [BsonElement("Id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? WorkoutId { get; set; }

        public string? Name { get; set; }

        public int NumberOfReps { get; set; }

        public int NumberOfSets { get; set; }

        public double Weight { get; set; }


    }
}