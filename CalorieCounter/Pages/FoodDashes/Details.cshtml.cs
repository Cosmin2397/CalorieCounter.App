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
        private readonly IExpectedService expectedService;

        public DetailsModel(IFoodDashService foodDashService, IExpectedService expectedService)
        {
            this.foodDashService = foodDashService;
            this.expectedService = expectedService;
        }

        [BindProperty]
        public FoodDash FoodDash { get; set; } = new FoodDash();

        public Expected Expected { get; set; } = new Expected();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Expected = await GetExpected();
            var foodDash = await foodDashService.GetDash(id, GetUser());
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
            Expected = await GetExpected();
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
            if (foodDash.TotalKcal > expected.ExpectedKcal)
            {
                return true;
            }
            return false;

        }

        private string GetUser()
        {
            var user = User.Identity.Name;
            if (string.IsNullOrEmpty(user))
            {
                return string.Empty;
            }
            return user;
        }


        public async Task<Expected> GetExpected()
        {
            var user = await this.expectedService.GetExpectedByUser(GetUser());
            if (user == null)
            {
                var defaultUser = await this.expectedService.GetExpectedById(1);
            }
            return user;
        }
    }
}
