using CicekSepetiCase.DataAccess.Entities;
using CicekSepetiCase.DataAccess.Repositories;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiCase.Service.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository BasketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            BasketRepository = basketRepository;
        }

        public async Task<string> AddProductToCart(BasketEntity basket)
        {
            if (basket.Id == BsonObjectId.Empty)
                return await BasketRepository.Create(basket);
            else
                return await BasketRepository.Update(basket);
        }

        public async Task<List<string>> GetBasketProducts(ObjectId basketId)
        {
            var basket = await BasketRepository.GetById(basketId);
            return basket?.ProductIds;
        }
    }
}
