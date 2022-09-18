using CalorieCounter.Data.Enums;
using CalorieCounter.Models;
using System.ComponentModel.DataAnnotations;

namespace CalorieCounter.Dto
{
    public class FoodToAdd
    {
        public int Id { get; set; }

        [Required]
        public double Servings { get; set; }

        public int ServingWeight { get; set; } = 100;

        public double TotalWeight { get; set; }

        public double TotalKcalFood { get; set; }

        public double TotalProteinFood { get; set; }

        public double TotalCarbsFood { get; set; }

        public double TotalFatsFood { get; set; }

        public double TotalFibersFood  { get; set; }

        public Food Food { get; set; } = new Food();

        public MealType MealTypeId { get; set; }

        public int DashId { get; set; }
    }
}
