using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SWIAPI.Models
{
    public class PeopleImage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string SwapiUrl { get; set; }
        public string ImageUrl { get; set; }

        //[BsonElement("Name")] used to define the column name
    }
}
