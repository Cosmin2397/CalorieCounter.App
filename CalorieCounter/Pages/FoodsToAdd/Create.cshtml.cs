using CalorieCounter.Data;
using CalorieCounter.Data.Enums;
using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodsToAdd
{
    public class CreateModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;
        private readonly IFoodService foodService;

        public CreateModel(IFoodToAddService foodToAddService, IFoodService foodService)
        {
            this.foodToAddService = foodToAddService;
            this.foodService = foodService;
        }

        [BindProperty]
        public FoodToAdd FoodAdded { get; set;  } = default!;

        [BindProperty]
        public int Id { get; set; }

        public Food Food { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            Food = await foodService.GetFoodById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid  || FoodAdded == null)
            {
                return Page();
            }
            Food = await foodService.GetFoodById(id);
            await this.foodToAddService.AddFoodToAdd(FoodAdded, Food, Id);

            return RedirectToPage("/FoodDashes/Details?id=1");

        }
    }
}
