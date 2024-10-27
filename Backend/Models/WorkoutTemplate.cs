using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class WorkoutTemplate {

        [BsonId]
        [BsonElement("Id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? Name { get; set; }

        public List<string> Exercises { get; set; }

    }
}