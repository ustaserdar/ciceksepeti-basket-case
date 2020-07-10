using CicekSepetiCase.DataAccess.Contexts;
using CicekSepetiCase.DataAccess.Entities;
using CicekSepetiCase.DataAccess.Repositories;
using CicekSepetiCase.DataAccess.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CicekSepetiCase.DataAccess.Implementations
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IMongoContext MongoContext;

        public BasketRepository(IOptions<MongoDbSettings> settings)
        {
            MongoContext = new MongoContext(settings);
        }

        public async Task<string> Create(BasketEntity basket)
        {
            await MongoContext.Baskets.InsertOneAsync(basket);
            return basket.Id.ToString();
        }

        public async Task<BasketEntity> GetById(ObjectId objectId)
        {
            return await MongoContext.Baskets.Find(Builders<BasketEntity>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();
        }

        public async Task<string> Update(BasketEntity basket)
        {
            await MongoContext.Baskets.ReplaceOneAsync(Builders<BasketEntity>.Filter.Eq(f => f.Id, basket.Id), basket);
            return basket.Id.ToString();
        }
    }
}
