using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Foods
{
    public class IndexModel : PageModel
    {
        private readonly IFoodService foodService;

        public IEnumerable<Food> FoodsList { get; set; } = default!;

        public IndexModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public async Task OnGet()
        {
            if(foodService.GetFoods != null)
            {
                FoodsList = await foodService.GetFoods();
            }
        }
    }
}
