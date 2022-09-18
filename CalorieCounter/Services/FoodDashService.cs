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

        public async Task<FoodDash> CreateDash(DateTime date)
        {
            if (!DateExist(date))
            {
                FoodDash dash = new()
                {
                    Date = date,
                    UserId = 1,
                    ExpectedValues = await GetExpectedByUserId(1),

                };
                await this.context.AddAsync(dash);
                await this.context.SaveChangesAsync();    
                return dash;
            }
            else
            {
                return await GetDashByDate(date);
            }
        }

        public Task<IEnumerable<FoodToAdd>> GetFoodsToAdd(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Food>> GetSearchedFoods(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await this.context.Foods.ToListAsync();
            }
            return await this.context.Foods.Where(c => c.Name.Contains(search)).ToListAsync();
        }

        public bool DateExist(DateTime date)
        {
            var exists = this.context.FoodDashes.Any(d => d.Date.Date == date.Date);
            return exists;
        }

        public async Task<FoodDash> GetDashByDate(DateTime date)
        {
            var dash = await this.context.FoodDashes.Include(f => f.Foods).Include(e => e.ExpectedValues).FirstOrDefaultAsync(d => d.Date.Date == date.Date);
            return dash;
        }

        public async Task<FoodDash> GetDash(int id)
        {
            var dash = await this.context.FoodDashes.Include(f => f.Foods).Include(e => e.ExpectedValues).FirstOrDefaultAsync(d => d.Id == id);
            dash.Foods = await this.context.FoodsToAdd.Include(f => f.Food).Where(f => f.DashId == dash.Id).ToListAsync();
            return dash;
        }

        public async Task<Expected> GetExpectedByUserId(int id)
        {
            var expected = await this.context.Expected.FirstOrDefaultAsync(d => d.UserId == id);
            return expected;
        }
    }
}
