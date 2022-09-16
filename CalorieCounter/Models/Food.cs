namespace CalorieCounter.Models
{
    public class Food
    {
        public int Id { get; set; }

        public string Name { get; set; } = String.Empty;

        public double Calories { get; set; }

        public double Protein { get; set; }

        public double Carbo { get; set; }

        public double Fats { get; set; }

        public double Fibers { get; set; }
    }
}
