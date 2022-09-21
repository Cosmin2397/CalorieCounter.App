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
        private readonly IFoodDashService foodDashService;

        public AddFoodModel(IFoodToAddService foodToAddService, IFoodDashService foodDashService)
        {
            this.foodToAddService = foodToAddService;
            this.foodDashService = foodDashService;
        }

        [BindProperty]
        public FoodToAdd FoodAdded { get; set; } = default!;

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public int DashId { get; set; }

        public IEnumerable<Food> ListOfFoods { get; set; }

        public Food Food { get; set; } = new Food();

        public async Task<IActionResult> OnGet(int id, int dashId, string search)
        {
            ListOfFoods = await this.foodDashService.GetSearchedFoods(search);
            Food = await foodDashService.GetFoodFromList(id, ListOfFoods);
            DashId = dashId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id, string search)
        {
            ListOfFoods = await this.foodDashService.GetSearchedFoods(search);
            if (!ModelState.IsValid || FoodAdded == null)
            {
                return Page();
            }
            Food = await foodDashService.GetFoodFromList(id, ListOfFoods);
            var foodAdded = await this.foodToAddService.AddFoodToAdd(FoodAdded, Food, DashId);
            FoodAdded = foodAdded;
            return RedirectToPage("./Details", new { id = DashId });

        }


        private string GetUser()
        {
            var user = User.Identity.Name;
            if(string.IsNullOrEmpty(user))
            {
                return string.Empty;
            }
            return user;
        }
    }
}
