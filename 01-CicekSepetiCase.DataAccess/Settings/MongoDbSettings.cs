using CicekSepetiCase.DataAccess.Entities;
using System.Collections.Generic;

namespace CicekSepetiCase.DataAccess.Settings
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
        public List<ProductEntity> Products { get; set; }
    }
}
