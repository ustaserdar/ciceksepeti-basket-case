using MongoDB.Bson;
using System.Threading.Tasks;

namespace CicekSepetiCase.Service
{
    public interface IProductService
    {
        Task<bool> ProductStockExist(ObjectId productId);
    }
}
