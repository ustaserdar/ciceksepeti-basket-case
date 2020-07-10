using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace CicekSepetiCase.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(ObjectId objectId);
    }
}
