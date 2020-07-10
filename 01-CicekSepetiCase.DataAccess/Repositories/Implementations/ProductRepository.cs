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
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoContext MongoContext;

        public ProductRepository(IOptions<MongoDbSettings> settings)
        {
            MongoContext = new MongoContext(settings);
        }

        public async Task<ProductEntity> GetById(ObjectId objectId)
        {
            return await MongoContext.Products.Find(Builders<ProductEntity>.Filter.Eq(f => f.Id, objectId)).FirstOrDefaultAsync();
        }
    }
}
