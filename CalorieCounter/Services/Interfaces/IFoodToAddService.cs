using CalorieCounter.Data.Enums;
using CalorieCounter.Dto;
using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodToAddService
    {

        Task<FoodToAdd> AddFoodToAdd(FoodToAdd foodToAdd, Food food);

        Task<FoodToAdd> GetFoodToAddById(int id);

        Task<IEnumerable<FoodToAdd>> GetFoodsToAdd();
    }
}
