using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBApiExemplo.Models
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Street { get; set; }
        public string CEP { get; set; }
    }
}
