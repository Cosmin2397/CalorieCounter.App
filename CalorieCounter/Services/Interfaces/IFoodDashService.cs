﻿using CalorieCounter.Dto;
using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodDashService
    {
        Task<FoodDash> GetDash(int id, string user);

        Task<FoodDash> GetDashByDate(DateTime date);

        Task<IEnumerable<FoodToAdd>> GetFoodsToAdd(int id);

        Task<FoodDash> CreateDash(DateTime date);

        Task<IEnumerable<Food>> GetSearchedFoods(string search);

        Task<Food> GetFoodFromList(int id, IEnumerable<Food> foods);

    }
}
