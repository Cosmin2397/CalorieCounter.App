using CalorieCounter.Dto;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class EditFoodModel : PageModel
    {
        private readonly IFoodToAddService foodService;

        public EditFoodModel(IFoodToAddService foodService)
        {
            this.foodService = foodService;
        }

        [BindProperty]
        public FoodToAdd Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Food = await foodService.GetFoodToAddById(id);
            if (Food == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(FoodToAdd food, int id)
        {
            Food = await foodService.GetFoodToAddById(id);
            food.Food = Food.Food;
            await foodService.UpdateFood(food);

            return Redirect("~/");

        }
    }
}
