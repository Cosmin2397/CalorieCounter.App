﻿using CalorieCounter.Data;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Services
{
    public class FoodService : IFoodService
    {
        private readonly AppDbContext context;

        public FoodService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddFood(Food food)
        {
                this.context.Add(food);
                await this.context.SaveChangesAsync();
        }

        public async Task DeleteFood(int id)
        {
            var food = await this.context.Foods.FirstOrDefaultAsync(e => e.Id == id);
            if (food != null)
            {
                this.context.Foods.Remove(food);
                await this.context.SaveChangesAsync();
            }
        }

        public async Task<Food> GetFoodById(int id)
        {
          var food = await this.context.Foods.FirstOrDefaultAsync(m => m.Id == id);
          if (food != null)
            {
                return food;
            }
          else
            {
                return new Food();
            }

        }

        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await this.context.Foods.ToListAsync();
        }

        public async Task UpdateFood(Food food)
        {
            var databaseFood = await this.context.Foods.FirstOrDefaultAsync(e => e.Id == food.Id);
            if(databaseFood != null)
            {
                databaseFood.Id = food.Id;
                databaseFood.Name = food.Name;
                databaseFood.Calories = food.Calories;
                databaseFood.Carbo = food.Carbo;
                databaseFood.Protein = food.Protein;
                databaseFood.Fibers = food.Fibers;
                databaseFood.Fats = food.Fats;
            }
            await this.context.SaveChangesAsync();
        }
    }
}
