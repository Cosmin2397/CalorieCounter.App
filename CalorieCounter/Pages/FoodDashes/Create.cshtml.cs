using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class CreateModel : PageModel
    {
        private readonly IFoodDashService foodDashService;

        public CreateModel(IFoodDashService foodDashService)
        {
            this.foodDashService = foodDashService;
        }

        public FoodDash FoodDash { get; set; } = new FoodDash();

        DateTime Day { get; set; } = DateTime.Now;

        public async Task<IActionResult> OnGet()
        {
            var dash = await this.foodDashService.CreateDash(Day);

            return RedirectToPage("./Details", new { id = dash.Id });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dash = await this.foodDashService.CreateDash(FoodDash.Date);

            return RedirectToPage("./Details", new { id = dash.Id });
        }
    }
}
