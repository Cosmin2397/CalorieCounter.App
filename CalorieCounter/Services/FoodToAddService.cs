using CalorieCounter.Data;
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

        public async Task<FoodToAdd> AddFoodToAdd(FoodToAdd foodToAdd, Food food, int id)
        {
                FoodToAdd foodToAdd1 = new FoodToAdd()
                {
                    Food = food,
                    Servings = foodToAdd.Servings,
                    ServingWeight = foodToAdd.ServingWeight,
                    TotalWeight = foodToAdd.Servings * foodToAdd.ServingWeight,
                    TotalKcalFood = foodToAdd.Servings * food.Calories,
                    TotalCarbsFood = foodToAdd.Servings * food.Carbo,
                    TotalProteinFood = foodToAdd.Servings * food.Protein,
                    TotalFatsFood = foodToAdd.Servings * food.Fats,
                    TotalFibersFood = foodToAdd.Servings * food.Fibers,
                    MealTypeId = foodToAdd.MealTypeId,
                    FoodDashId = id
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
                return default;
            }

        }

        public async Task<IEnumerable<FoodToAdd>> GetFoodToAddByDashId(int id)
        {
            var foodToAdd = await this.context.FoodsToAdd.Include(f => f.Food).Where(m => m.FoodDashId == id).ToListAsync();
            return foodToAdd;

        }
    }
}
