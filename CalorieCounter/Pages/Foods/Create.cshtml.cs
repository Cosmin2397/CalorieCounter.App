using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.Foods
{
    public class CreateModel : PageModel
    {
        private readonly IFoodService foodService;

        public CreateModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || foodService.GetFoods == null || Food == null)
            {
                return Page();
            }

            await foodService.AddFood(Food);

            return RedirectToPage("./Index");

        }
    }
}
