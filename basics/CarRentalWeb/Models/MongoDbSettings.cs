namespace CarRentalWeb.Models
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CarCollection { get; set; }
        public string UserCollection { get; set; }
    }
}
