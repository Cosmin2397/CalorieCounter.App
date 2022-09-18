using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class DetailsModel : PageModel
    {
        private readonly IFoodDashService foodDashService;

        public DetailsModel(IFoodDashService foodDashService)
        {
            this.foodDashService = foodDashService;
        }

        [BindProperty]
        public FoodDash FoodDash { get; set; } = new FoodDash();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var foodDash = await foodDashService.GetDash(id);
            foodDash.TotalWeight = foodDash.Foods.Sum(w => w.TotalWeight);
            foodDash.TotalKcal = foodDash.Foods.Sum(w => w.TotalKcalFood);
            foodDash.TotalCarbs = foodDash.Foods.Sum(w => w.TotalCarbsFood);
            foodDash.TotalProtein = foodDash.Foods.Sum(w => w.TotalProteinFood);
            foodDash.TotalFats = foodDash.Foods.Sum(w => w.TotalFatsFood);
            foodDash.TotalFibers = foodDash.Foods.Sum(w => w.TotalFibersFood);
            if (!ModelState.IsValid || FoodDash == null)
            {
                return Page();
            }

            FoodDash = foodDash;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var foodDash = await foodDashService.CreateDash(FoodDash.Date);
            foodDash.TotalWeight = foodDash.Foods.Sum(w => w.TotalWeight);
            foodDash.TotalKcal = foodDash.Foods.Sum(w => w.TotalKcalFood);
            foodDash.TotalCarbs = foodDash.Foods.Sum(w => w.TotalCarbsFood);
            foodDash.TotalProtein = foodDash.Foods.Sum(w => w.TotalProteinFood);
            foodDash.TotalFats = foodDash.Foods.Sum(w => w.TotalFatsFood);
            foodDash.TotalFibers = foodDash.Foods.Sum(w => w.TotalFibersFood);
            
            return RedirectToPage("./Details", new { id = foodDash.Id });
        }
    }
}
