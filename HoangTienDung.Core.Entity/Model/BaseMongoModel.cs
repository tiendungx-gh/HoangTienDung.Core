using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HoangTienDung.Core.Entity.Model
{
    public class BaseMongoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
    }
}
