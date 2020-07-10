using CicekSepetiCase.DataAccess.Repositories;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace CicekSepetiCase.Service.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository ProductRepository;
        private const int NoStock = 0;

        public ProductService(IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }

        public async Task<bool> ProductStockExist(ObjectId productId)
        {
            var product = await ProductRepository.GetById(productId);
            return product.InStock > NoStock;
        }
    }
}
