namespace HoangTienDung.Core.Entity.Constant
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public MongoDbSettings(string CollectionName,string ConnectionString,string DatabaseName)
        {
            this.CollectionName = CollectionName;
            this.ConnectionString = ConnectionString;
            this.DatabaseName = DatabaseName;
        }
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
