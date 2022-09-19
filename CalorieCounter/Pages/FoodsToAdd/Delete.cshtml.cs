using CalorieCounter.Dto;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodsToAdd
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;

        public DeleteModel(IFoodToAddService foodToAddService)
        {
            this.foodToAddService = foodToAddService;
        }

        [BindProperty]
        public FoodToAdd FoodToDelete { get; set; } = new FoodToAdd();

        public async Task<IActionResult> OnGet(int id)
        {
            FoodToDelete = await this.foodToAddService.GetFoodToAddById(id);
            if (FoodToDelete == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            await this.foodToAddService.DeleteFoodAdded(FoodToDelete.Id);

            return Redirect("~/");

        }
    }
}
