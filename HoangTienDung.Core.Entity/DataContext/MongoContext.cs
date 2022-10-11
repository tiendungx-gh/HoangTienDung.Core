using HoangTienDung.Core.Entity.Constant;
using MongoDB.Driver;

namespace HoangTienDung.Core.Entity.DataContext
{
    public class MongoContext : IMongoContext
    {
        protected MongoContext(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            Database = client.GetDatabase(mongoDbSettings.DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }
}
