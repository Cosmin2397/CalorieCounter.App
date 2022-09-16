using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodService
    {
        Task<IEnumerable<Food>> GetSearchedFoods(string search);

        Task<IEnumerable<Food>> GetFoods();

        Task<Food> GetFoodById(int id);

        Task AddFood(Food food);

        Task<Food> UpdateFood(Food food);

        Task<Food> DeleteFood(int id);
    }
}
