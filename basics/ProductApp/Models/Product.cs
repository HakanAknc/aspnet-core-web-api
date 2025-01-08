namespace ProductApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public String? ProductName { get; set; }   // string? demek "null" bırakılabilir demek
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
