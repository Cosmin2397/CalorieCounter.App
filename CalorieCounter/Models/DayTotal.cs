namespace CalorieCounter.Models
{
    public class DayTotal
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public FoodDash DayFoods { get; set; } = new FoodDash();

        public Expected ExpectedValues { get; set; } = new Expected();

        public int UserId { get; set; }
    }

}
