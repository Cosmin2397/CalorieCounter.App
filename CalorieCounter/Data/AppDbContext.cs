using CalorieCounter.Dto;
using CalorieCounter.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieCounter.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }

        public DbSet<FoodDash> FoodDashes { get; set; }

        public DbSet<Expected> Expected { get; set; }

        public DbSet<FoodToAdd> FoodsToAdd { get; set; }
    }
}
