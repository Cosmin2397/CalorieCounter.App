using CalorieCounter.Dto;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodsToAdd
{
    public class DetailsModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;

        public FoodToAdd FoodToAdd { get; set; }

        public DetailsModel(IFoodToAddService foodToAddService)
        {
            this.foodToAddService = foodToAddService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var foodToAdd = foodToAddService.GetFoodToAddById(id);
            if (foodToAdd == null)
            {
                return NotFound();
            }
            else
            {
                FoodToAdd = await foodToAdd;
                return Page();
            }
        }
    }
}
