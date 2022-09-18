using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Foods
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodService foodService;

        public DeleteModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [BindProperty]
        public Food FoodToDelete { get; set; } = new Food();

        public async Task<IActionResult> OnGet(int id)
        {
            FoodToDelete = await foodService.GetFoodById(id);
            if(FoodToDelete == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await foodService.DeleteFood(FoodToDelete.Id);

            return RedirectToPage("./Index");

        }
    }
}
