using StoreManagementSystem.Models;

namespace StoreManagementSystem.Data
{
    public class ApplicationContext
    {
        // Ürünlerin tutulduğu geçici liste
        public static List<Product> Products { get; set; } = new List<Product>();
    }
}
