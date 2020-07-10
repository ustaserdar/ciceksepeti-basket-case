using CicekSepetiCase.DataAccess.Entities;
using CicekSepetiCase.DataAccess.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

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

            FillProductCollectionWithTestEntities();
        }

        private void FillProductCollectionWithTestEntities()
        {
            var products = new List<ProductEntity>
            {
                new ProductEntity()
                {
                    Name = "iPhone 7",
                    Description = "Apple iPhone 7",
                    Price = 3000,
                    InStock = 10
                },
                new ProductEntity()
                {
                    Name = "Macbook Pro",
                    Description = "Apple Macbook Pro",
                    Price = 15000,
                    InStock = 5
                },
                new ProductEntity()
                {
                    Name = "Airpods Pro",
                    Description = "Apple Airpods Pro",
                    Price = 2000,
                    InStock = 8
                },
                new ProductEntity()
                {
                    Name = "iWatch",
                    Description = "Apple iWatch",
                    Price = 4000,
                    InStock = 2
                },
                new ProductEntity()
                {
                    Id = new ObjectId("5f077905c6b57a2132621ce4"),
                    Name = "AppleTV",
                    Description = "Apple TV",
                    Price = 2500,
                    InStock = 0
                },
            };

            Products.InsertMany(products);
        }

        public IMongoCollection<ProductEntity> Products => Database.GetCollection<ProductEntity>("Products");
        public IMongoCollection<BasketEntity> Baskets => Database.GetCollection<BasketEntity>("Baskets"); 
    }
}
