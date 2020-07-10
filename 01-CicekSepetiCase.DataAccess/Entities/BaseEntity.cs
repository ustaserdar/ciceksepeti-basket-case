using MongoDB.Bson;
using System;

namespace CicekSepetiCase.DataAccess.Entities
{
    public class BaseEntity : IEntity
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => DateTime.UtcNow;
    }
}
