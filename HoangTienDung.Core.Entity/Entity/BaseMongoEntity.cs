using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HoangTienDung.Core.Entity.Entity
{
    public class BaseMongoEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}
