using CicekSepetiCase.DataAccess.Entities;
using MongoDB.Driver;
using System;

namespace CicekSepetiCase.DataAccess.Contexts
{
    public interface IMongoContext
    {
        IMongoCollection<ProductEntity> Products { get; }
        IMongoCollection<BasketEntity> Baskets { get; }
    }
}
