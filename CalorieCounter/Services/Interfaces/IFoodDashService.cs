using CalorieCounter.Dto;
using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodDashService
    {
        Task<FoodDash> GetDash(int id);

        Task<FoodDash> GetDashByDate(DateTime date);

        Task<IEnumerable<FoodToAdd>> GetFoodsToAdd(int id);

        Task<FoodDash> CreateDash(DateTime date);

        Task<IEnumerable<Food>> GetSearchedFoods(string search);

        Task<Expected> GetExpectedByUserId(int id);

        Task<Food> GetFoodFromList(int id, IEnumerable<Food> foods);

    }
}
