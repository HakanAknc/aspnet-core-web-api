using foodDemo.Models;

namespace foodDemo.Data
{
    public class ApplicationContext
    {
        public static List<FoodItem> MenuItems { get; set; } = new List<FoodItem>();
    }
}
