using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class CreateModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;
        private readonly IFoodDashService foodDashService;

        public CreateModel(IFoodToAddService foodToAddService, IFoodDashService foodDashService)
        {
            this.foodToAddService = foodToAddService;
            this.foodDashService = foodDashService;
        }

        [BindProperty]
        public FoodDash FoodDash { get; set; } = default!;

        public IEnumerable<FoodToAdd> FoodsToAdd { get; set; }

        public async Task<IActionResult> OnGet(int id)
        {
            FoodsToAdd = await foodDashService.GetFoodsToAdd(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid || FoodDash == null)
            {
                return Page();
            }
            FoodsToAdd = await foodDashService.GetFoodsToAdd(id);
            await this.foodDashService.CreateDash(FoodDash, FoodsToAdd);

            return RedirectToPage("./Index");

        }
    }
}
