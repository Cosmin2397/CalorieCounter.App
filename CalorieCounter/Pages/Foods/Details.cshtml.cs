using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Foods
{
    public class DetailsModel : PageModel
    {
        private readonly IFoodService foodService;

        public Food Food { get; set; } = new Food();

        public DetailsModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var food = foodService.GetFoodById(id);
            if(food == null)
            {
                return NotFound();
            }
            else
            {
                Food = await food;
                return Page();
            }
        }
    }
}
