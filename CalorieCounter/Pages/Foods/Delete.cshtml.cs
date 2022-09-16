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
        public Food FoodToDelete { get; set; }

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
            var deletedFood = await foodService.DeleteFood(FoodToDelete.Id);
            if(deletedFood == null)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");

        }
    }
}
