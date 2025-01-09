using foodDemo.Data;
using foodDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace foodDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        // Tüm menüyü listeleme (GET)
        [HttpGet]
        public IActionResult GetMenu()
        {
            return Ok(ApplicationContext.MenuItems);
        }

        // Yeni yemek ekleme (POST)
        [HttpPost]
        public IActionResult AddFoodItem([FromBody] FoodItem foodItem)
        {
            foodItem.Id = ApplicationContext.MenuItems.Count > 0
                ? ApplicationContext.MenuItems.Max(f => f.Id) + 1
                : 1; // Eğer listede yemek yoksa, Id 1 olacak
            ApplicationContext.MenuItems.Add(foodItem);
            return CreatedAtAction(nameof(GetMenu), new { id = foodItem.Id }, foodItem);
        }

        // Yemek güncelleme (PUT)
        [HttpPut("{id:int}")]
        public IActionResult UpdateFoodItem([FromRoute] int id, [FromBody] FoodItem updatedFoodItem)
        {
            var foodItem = ApplicationContext.MenuItems.FirstOrDefault(f => f.Id == id);

            if (foodItem == null)
                return NotFound("Yemek bulunamadı güncellemek için!");

            foodItem.Name = updatedFoodItem.Name;
            foodItem.Price = updatedFoodItem.Price;

            return Ok(foodItem);
        }

        // Yemek silme (DELETE)
        [HttpDelete("{id:int}")]
        public IActionResult DeleteFoodItem([FromRoute] int id)
        {
            var foodItem = ApplicationContext.MenuItems.FirstOrDefault(f => f.Id == id);

            if (foodItem == null)
                return NotFound("Yemek bulunamadı silmek için!");

            ApplicationContext.MenuItems.Remove(foodItem);

            return Ok($"Yemek (ID: {id}) silindi.");
        }

        [HttpDelete]
        public IActionResult DeleteAllFoods()
        {
            ApplicationContext.MenuItems.Clear();
            //return NoContent();
            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
