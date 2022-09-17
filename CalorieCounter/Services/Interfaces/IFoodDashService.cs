using CalorieCounter.Dto;
using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodDashService
    {
        Task<FoodDash> GetDashByDateId(int id);

        Task<IEnumerable<FoodToAdd>> GetFoodsToAdd(int id);

        Task<FoodDash> CreateDash(FoodDash foodDash, IEnumerable<FoodToAdd> foodToAdds, DateTime date);

        Task<IEnumerable<Food>> GetSearchedFoods(string search);
    }
}
