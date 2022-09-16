using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Foods
{
    public class EditModel : PageModel
    {
        private readonly IFoodService foodService;

        public EditModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Food = await foodService.GetFoodById(id);
            if (Food == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Food food)
        {
            Food = await foodService.UpdateFood(food);

            return RedirectToPage("./Index");

        }

    }
}
