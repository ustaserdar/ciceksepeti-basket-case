using CicekSepetiCase.DataAccess.Entities;
using CicekSepetiCase.DataAccess.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CicekSepetiCase.DataAccess.Contexts
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase Database;
        private readonly MongoDbSettings MongoDbSettings;

        public MongoContext(IOptions<MongoDbSettings> options)
        {
            MongoDbSettings = options.Value;
            Database = new MongoClient(MongoDbSettings.ConnectionString).GetDatabase(MongoDbSettings.Database);
        }

        public IMongoCollection<ProductEntity> Products => Database.GetCollection<ProductEntity>("Products");
        public IMongoCollection<BasketEntity> Baskets => Database.GetCollection<BasketEntity>("Baskets"); 
    }
}
