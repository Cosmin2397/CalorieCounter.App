using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Foods
{
    public class GetSearchedFoodModel : PageModel
    {
        private readonly IFoodService foodService;

        public IEnumerable<Food> FoodsList { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchFood { get; set; }

        public GetSearchedFoodModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public async Task OnGet()
        {
            if (foodService.GetFoods != null)
            {
                FoodsList = await foodService.GetSearchedFoods(SearchFood);
            }
        }
    }
}
