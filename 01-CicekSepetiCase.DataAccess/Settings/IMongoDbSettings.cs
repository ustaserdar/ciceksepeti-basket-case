namespace CicekSepetiCase.DataAccess.Settings
{
    public interface IMongoDbSettings
    {
        public string Database { get; set; }
        public string ConnectionString { get; set; }
    }
}
