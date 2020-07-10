using CicekSepetiCase.DataAccess.Entities;
using System.Threading.Tasks;

namespace CicekSepetiCase.DataAccess.Repositories
{
    public interface IBasketRepository : IRepository<BasketEntity>
    {
        Task<string> Create(BasketEntity basket);
        Task<string> Update(BasketEntity basket);
    }
}
