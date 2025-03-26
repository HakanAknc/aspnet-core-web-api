namespace TestAPI.Context
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TestUserCollection { get; set; }
    }
}
