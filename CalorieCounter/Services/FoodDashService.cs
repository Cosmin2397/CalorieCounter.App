using CalorieCounter.Data;
using CalorieCounter.Dto;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CalorieCounter.Services
{
    public class FoodDashService : IFoodDashService
    {
        private readonly AppDbContext context;

        public HttpClient http;

        public int FoodId = 231997;

        public FoodDashService(AppDbContext context, HttpClient http)
        {
            this.context = context;
            this.http = http;
        }

        public async Task<FoodDash> CreateDash(DateTime date)
        {
            if (!DateExist(date))
            {
                FoodDash dash = new()
                {
                    Date = date,
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
            if (string.IsNullOrEmpty(search) || search == "Search for Food")
            {
                return await this.context.Foods.ToListAsync();

            }
            var apiFoods = await GetApiFoodsBySearch(search);
            var foods = await this.context.Foods.Where(c => c.Name.Contains(search)).ToListAsync();
            foods.AddRange(apiFoods);
            return foods;
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


        public async Task<Food> GetFoodFromList(int id, IEnumerable<Food> foods)
        {
            var food = foods.FirstOrDefault(f => f.Id == id);
            return food;
        }


        public async Task<Expected> GetExpectedByUserId(int id)
        {
            var expected = await this.context.Expected.FirstOrDefaultAsync(d => d.Id == id);
            return expected;
        }

        public async  Task<IEnumerable<Food>> GetApiFoodsBySearch(string search)
        {
            var response = await this.http.GetAsync($"https://api.edamam.com/api/food-database/v2/parser?app_id=f7ddac39&app_key=991510835ceb452fcaa496620665c61c%09&ingr={search}&nutrition-type=cooking");
            var result = await response.Content.ReadAsStringAsync();
            Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(result);
            List<Food> apiFoods = new List<Food>();
            foreach (var food in myDeserializedClass.Hints)
            {
                apiFoods.Add(new Food()
                {
                    Name = food.Food.Label,
                    Calories = Math.Round(food.Food.Nutrients.ENERCKCAL, 2),
                    Carbo = Math.Round(food.Food.Nutrients.CHOCDF, 2),
                    Protein = Math.Round(food.Food.Nutrients.PROCNT, 2),
                    Fats = Math.Round(food.Food.Nutrients.FAT, 2),
                    Fibers = Math.Round(food.Food.Nutrients.FIBTG, 2)
                }
                );
            };
            return apiFoods;
        }
    }
}
