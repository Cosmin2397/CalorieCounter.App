using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class AddFoodModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;
        private readonly IFoodService foodService;

        public AddFoodModel(IFoodToAddService foodToAddService, IFoodService foodService)
        {
            this.foodToAddService = foodToAddService;
            this.foodService = foodService;
        }

        [BindProperty]
        public FoodToAdd FoodAdded { get; set; } = default!;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int DashId { get; set; }

        public Food Food { get; set; } = new Food();

        public async Task<IActionResult> OnGet(int id, int dashId)
        {
            Food = await foodService.GetFoodById(id);
            DashId = dashId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid || FoodAdded == null)
            {
                return Page();
            }
            Food = await foodService.GetFoodById(id);
            var foodAdded = await this.foodToAddService.AddFoodToAdd(FoodAdded, Food, DashId);
            FoodAdded = foodAdded;
            return RedirectToPage("./Details", new { id = DashId });

        }
    }
}
