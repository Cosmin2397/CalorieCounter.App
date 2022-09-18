using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodService
    {

        Task<IEnumerable<Food>> GetFoods();

        Task<Food> GetFoodById(int id);

        Task AddFood(Food food);

        Task UpdateFood(Food food);

        Task DeleteFood(int id);
    }
}
