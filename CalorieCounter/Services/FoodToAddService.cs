﻿using CalorieCounter.Data;
using CalorieCounter.Data.Enums;
using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Services
{
    public class FoodToAddService : IFoodToAddService
    {
        private readonly AppDbContext context;

        public FoodToAddService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<FoodToAdd> AddFoodToAdd(FoodToAdd foodToAdd, Food food, int id, string user)
        {
                var addedFood = await AddApiFood(food);
                FoodToAdd foodToAdd1 = new()
                {
                    Food = addedFood,
                    Servings = foodToAdd.Servings,
                    ServingWeight = foodToAdd.ServingWeight,
                    TotalWeight = foodToAdd.Servings * foodToAdd.ServingWeight,
                    TotalKcalFood = foodToAdd.Servings * food.Calories,
                    TotalCarbsFood = foodToAdd.Servings * food.Carbo,
                    TotalProteinFood = foodToAdd.Servings * food.Protein,
                    TotalFatsFood = foodToAdd.Servings * food.Fats,
                    TotalFibersFood = foodToAdd.Servings * food.Fibers,
                    MealTypeId = foodToAdd.MealTypeId,
                    DashId = id,
                    User = user
                };

                this.context.Add(foodToAdd1);
                await this.context.SaveChangesAsync();
            return foodToAdd1;
        }

        public async Task<IEnumerable<FoodToAdd>> GetFoodsToAdd()
        {
            return await this.context.FoodsToAdd.Include(f => f.Food).ToListAsync();
        }

        public async Task<FoodToAdd> GetFoodToAddById(int id)
        {
            var foodToAdd = await this.context.FoodsToAdd.Include(f => f.Food).FirstOrDefaultAsync(m => m.Id == id);
            if (foodToAdd != null)
            {
                return foodToAdd;
            }
            else
            {
                return new FoodToAdd();
            }

        }

        public async Task<IEnumerable<FoodToAdd>> GetFoodToAddByDashId(int id)
        {
            var foodToAdd = await this.context.FoodsToAdd.Include(f => f.Food).Where(m => m.DashId == id).ToListAsync();
            return foodToAdd;

        }

        public async Task<Food> AddApiFood(Food food)
        {
            var dbFood = await this.context.Foods.FirstOrDefaultAsync(f => f.Id == food.Id);
            if(dbFood == null)
            {
                this.context.Add(food);
                await this.context.SaveChangesAsync();
                return await this.context.Foods.FirstOrDefaultAsync(f => f.Name == food.Name && f.Calories == food.Calories);
            }

            return await this.context.Foods.FirstOrDefaultAsync(f => f.Name == food.Name && f.Calories == food.Calories);
        }

        public async Task DeleteFoodAdded(int id)
        {
            var foodToAdd = await this.context.FoodsToAdd.FirstOrDefaultAsync(e => e.Id == id);
            if (foodToAdd != null)
            {
                this.context.FoodsToAdd.Remove(foodToAdd);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task UpdateFood(FoodToAdd food)
        {
            var databaseFood = await this.context.FoodsToAdd.FirstOrDefaultAsync(e => e.Id == food.Id);
            if (databaseFood != null)
            {
                databaseFood.Food = food.Food;
                databaseFood.Id = food.Id;
                databaseFood.Servings = food.Servings;
                databaseFood.ServingWeight = food.ServingWeight;
                databaseFood.TotalWeight = food.Servings * food.ServingWeight;
                databaseFood.TotalKcalFood = food.Servings * food.Food.Calories;
                databaseFood.TotalCarbsFood = food.Servings * food.Food.Carbo;
                databaseFood.TotalProteinFood = food.Servings * food.Food.Protein;
                databaseFood.TotalFatsFood = food.Servings * food.Food.Fats;
                databaseFood.TotalFibersFood = food.Servings * food.Food.Fibers;
                databaseFood.MealTypeId = food.MealTypeId;
            }
            await this.context.SaveChangesAsync();
        }
    }
}
