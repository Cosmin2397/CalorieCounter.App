using CalorieCounter.Data;
using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Services
{
    public class FoodDashService : IFoodDashService
    {
        private readonly AppDbContext context;

        public FoodDashService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<FoodDash> CreateDash(FoodDash foodDash, IEnumerable<FoodToAdd> foodToAdds)
        {
            FoodDash foodDash1 = new FoodDash()
            {
                Foods = foodToAdds,
                TotalWeight = foodToAdds.Sum(t => t.TotalWeight),
                TotalCarbs = foodToAdds.Sum(t => t.TotalCarbsFood),
                TotalFats = foodToAdds.Sum(t => t.TotalFatsFood),
                TotalProtein = foodToAdds.Sum(t => t.TotalProteinFood), 
                TotalFibers = foodToAdds.Sum(t => t.TotalFibersFood),
                TotalKcal = foodToAdds.Sum(t => t.TotalKcalFood),
                DayId = 1
            };
            this.context.Add(foodDash1);

            await this.context.SaveChangesAsync();
            return foodDash1;
        }

        public async Task<FoodDash> GetDashByDateId(int id)
        {
            var foodDash = await this.context.FoodDashes.Include(f => f.Foods).FirstOrDefaultAsync(m => m.DayId == id);
            if (foodDash != null)
            {
                return foodDash;
            }
            else
            {
                return default;
            }
        }

        public async Task<IEnumerable<FoodToAdd>> GetFoodsToAdd(int id)
        {
            return await this.context.FoodsToAdd.Where(c => c.DashId == id).ToListAsync();
        }
    }
}
