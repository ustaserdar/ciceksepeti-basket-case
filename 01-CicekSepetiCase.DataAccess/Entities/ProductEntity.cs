using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CicekSepetiCase.DataAccess.Entities
{
    public class ProductEntity : BaseEntity
    {
        [BsonRepresentation(BsonType.String)]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.String)]
        public string Description { get; set; }

        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonRepresentation(BsonType.Int32)]
        public int InStock { get; set; }
    }
}
