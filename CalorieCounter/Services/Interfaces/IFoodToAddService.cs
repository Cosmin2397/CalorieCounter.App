﻿using CalorieCounter.Data.Enums;
using CalorieCounter.Dto;
using CalorieCounter.Models;

namespace CalorieCounter.Services.Interfaces
{
    public interface IFoodToAddService
    {

        Task<FoodToAdd> AddFoodToAdd(FoodToAdd foodToAdd, Food food, int id, string user);

        Task<FoodToAdd> GetFoodToAddById(int id);

        Task UpdateFood(FoodToAdd food);

        Task<IEnumerable<FoodToAdd>> GetFoodToAddByDashId(int id);

        Task<IEnumerable<FoodToAdd>> GetFoodsToAdd();

        Task DeleteFoodAdded(int id);
    }
}
