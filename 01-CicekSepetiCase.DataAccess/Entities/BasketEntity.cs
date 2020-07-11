using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace CicekSepetiCase.DataAccess.Entities
{
    public class BasketEntity : BaseEntity
    {
        public List<string> ProductIds { get; set; }
    }
}
