using CalorieCounter.Dto;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodsToAdd
{
    public class IndexModel : PageModel
    {
        private readonly IFoodToAddService foodToAddService;

        public IEnumerable<FoodToAdd> FoodsToAdd { get; set; } = default!;

        public IndexModel(IFoodToAddService foodToAddService)
        {
            this.foodToAddService = foodToAddService;
        }

        public async Task OnGet()
        {
            if (foodToAddService.GetFoodsToAdd != null)
            {
                FoodsToAdd = await foodToAddService.GetFoodsToAdd();
            }
        }
    }
}
