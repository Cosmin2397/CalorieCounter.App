using CalorieCounter.Data;
using CalorieCounter.Models;
using CalorieCounter.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Services
{
    public class ExpectedService : IExpectedService
    {
        private readonly AppDbContext context;

        public ExpectedService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task AddExpected(Expected expected)
        {
            this.context.Add(expected);
            await this.context.SaveChangesAsync();
        }

        public async Task<Expected> GetExpectedByUser(string user)
        {
            var expected = await this.context.Expected.FirstOrDefaultAsync(m => m.User == user);
            if (expected != null)
            {
                return expected;
            }
            else
            {
                return await this.context.Expected.FirstOrDefaultAsync(m => m.User == string.Empty);
            }
        }


        public async Task<Expected> GetExpectedById(int id)
        {
            var expected =  await this.context.Expected.FirstOrDefaultAsync(m => m.Id == id);
            if (expected != null)
            {
                return expected;
            }
            else
            {
                return await this.context.Expected.FirstOrDefaultAsync(m => m.User == string.Empty);
            }
        }


        public async Task UpdateExpected(Expected expected)
        {
            var expectedDb = await this.context.Expected.FirstOrDefaultAsync(e => e.User == expected.User);
            if (expectedDb != null)
            {
                expectedDb.Id = expected.Id;
                expectedDb.ExpectedFibers = expected.ExpectedFibers;
                expectedDb.ExpectedFats = expected.ExpectedFats;
                expectedDb.ExpectedCarbs = expected.ExpectedCarbs;
                expectedDb.ExpectedKcal =   expected.ExpectedKcal;
                expectedDb.ExpectedProtein = expected.ExpectedProtein;
                expectedDb.User = expected.User;
            }
            await this.context.SaveChangesAsync();
        }
    }
}
