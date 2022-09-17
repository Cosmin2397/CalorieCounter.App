using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class DetailsModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;
        private readonly IFoodDashService foodDashService;

        public DetailsModel(IFoodToAddService foodToAddService, IFoodDashService foodDashService)
        {
            this.foodToAddService = foodToAddService;
            this.foodDashService = foodDashService;
        }

        [BindProperty]
        public FoodDash FoodDash { get; set; } = default!;

        public IEnumerable<FoodToAdd> FoodAdded{ get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var foodDash = await foodDashService.GetDashByDateId(id);

            if (!ModelState.IsValid || FoodDash == null)
            {
                return Page();
            }

            FoodAdded = await foodToAddService.GetFoodToAddByDashId(foodDash.Id);
            FoodDash = foodDash;
            return Page();
        }
    }
}
