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

        public Task<FoodDash> CreateDash(FoodDash foodDash, IEnumerable<FoodToAdd> foodToAdds, DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<FoodDash> GetDashByDateId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FoodToAdd>> GetFoodsToAdd(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Food>> GetSearchedFoods(string search)
        {
            throw new NotImplementedException();
        }
    }
}
