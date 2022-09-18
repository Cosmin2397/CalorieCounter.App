using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalorieCounter.Pages.FoodDashes
{
    public class GetFoodsModel : PageModel
    {
        private readonly IFoodDashService foodDashService;

        public IEnumerable<Food> FoodsList { get; set; } = new List<Food>();

        [BindProperty(SupportsGet = true)]
        public string SearchFood { get; set; } = String.Empty;

        public int DashId { get; set; }

        public GetFoodsModel(IFoodDashService foodDashService)
        {
            this.foodDashService = foodDashService;
        }

        public async Task OnGet(int id)
        {
           FoodsList = await foodDashService.GetSearchedFoods(SearchFood);
           DashId = id;
        }
    }
}
