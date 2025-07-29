using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models
{
    public class Workout
    {

        [BsonId]
        [BsonElement("Id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? UserId { get; set; }

        public string? Name { get; set; }

        public DateTime Date { get; set; }

    }
}