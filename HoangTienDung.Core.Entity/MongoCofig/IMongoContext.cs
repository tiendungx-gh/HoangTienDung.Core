using MongoDB.Driver;

namespace HoangTienDung.Core.Entity.Constant
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }
}
