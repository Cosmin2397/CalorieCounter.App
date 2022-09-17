using CalorieCounter.Data.Enums;
using CalorieCounter.Dto;

namespace CalorieCounter.Models
{
    public class FoodDash
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Expected ExpectedValues { get; set; } = new Expected();

        public double TotalWeight { get; set; }

        public double TotalKcal { get; set; }

        public double TotalProtein { get; set; }

        public double TotalCarbs { get; set; }

        public double TotalFats { get; set; }

        public double TotalFibers { get; set; }

        public int UserId { get; set; }

        public IEnumerable<FoodToAdd> Foods { get; set; } = new List<FoodToAdd>();


    }
}
