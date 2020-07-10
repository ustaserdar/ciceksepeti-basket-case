using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace CicekSepetiCase.DataAccess.Entities
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        ObjectId Id { get; set; }

        [BsonRepresentation(BsonType.DateTime)]
        DateTime CreatedAt { get; }
    }
}
