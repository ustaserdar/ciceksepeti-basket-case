using CicekSepetiCase.DataAccess.Entities;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiCase.Service
{
    public interface IBasketService
    {
        Task<List<string>> GetBasketProducts(ObjectId basketId);
        Task<string> AddProductToCart(BasketEntity basket);
    }
}
