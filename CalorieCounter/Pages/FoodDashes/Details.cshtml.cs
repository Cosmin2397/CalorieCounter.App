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
            foodDash.TotalWeight = Math.Round(foodDash.Foods.Sum(w => w.TotalWeight), 2);
            foodDash.TotalKcal = Math.Round(foodDash.Foods.Sum(w => w.TotalKcalFood), 2);
            foodDash.TotalCarbs = Math.Round(foodDash.Foods.Sum(w => w.TotalCarbsFood), 2);
            foodDash.TotalProtein = Math.Round(foodDash.Foods.Sum(w => w.TotalProteinFood), 2);
            foodDash.TotalFats = Math.Round(foodDash.Foods.Sum(w => w.TotalFatsFood), 2);
            foodDash.TotalFibers = Math.Round(foodDash.Foods.Sum(w => w.TotalFibersFood), 2);
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
            foodDash.TotalWeight = Math.Round(foodDash.Foods.Sum(w => w.TotalWeight), 2);
            foodDash.TotalKcal = Math.Round(foodDash.Foods.Sum(w => w.TotalKcalFood), 2);
            foodDash.TotalCarbs = Math.Round(foodDash.Foods.Sum(w => w.TotalCarbsFood), 2);
            foodDash.TotalProtein = Math.Round(foodDash.Foods.Sum(w => w.TotalProteinFood), 2);
            foodDash.TotalFats = Math.Round(foodDash.Foods.Sum(w => w.TotalFatsFood), 2);
            foodDash.TotalFibers = Math.Round(foodDash.Foods.Sum(w => w.TotalFibersFood), 2);

            return RedirectToPage("./Details", new { id = foodDash.Id });
        }


        public bool HasExpected(Expected expected, FoodDash foodDash)
        {
            if(foodDash.TotalKcal > expected.ExpectedKcal)
            {
                return true;
            }
            return false;
         
        }
    }
}
