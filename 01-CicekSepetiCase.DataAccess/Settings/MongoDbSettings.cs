namespace CicekSepetiCase.DataAccess.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}
