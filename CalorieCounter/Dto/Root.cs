using Newtonsoft.Json;

namespace CalorieCounter.Dto
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FoodDto
    {
        [JsonProperty("foodId")]
        public string FoodId { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("knownAs")]
        public string KnownAs { get; set; }

        [JsonProperty("nutrients")]
        public Nutrients Nutrients { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("categoryLabel")]
        public string CategoryLabel { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("foodContentsLabel")]
        public string FoodContentsLabel { get; set; }
    }

    public class Hint
    {
        [JsonProperty("food")]
        public FoodDto Food { get; set; }

        [JsonProperty("measures")]
        public List<Measure> Measures { get; set; }
    }

    public class Links
    {
        [JsonProperty("next")]
        public Next Next { get; set; }
    }

    public class Measure
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }

        [JsonProperty("qualified")]
        public List<Qualified> Qualified { get; set; }
    }

    public class Next
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }
    }

    public class Nutrients
    {
        [JsonProperty("ENERC_KCAL")]
        public double ENERCKCAL { get; set; }

        [JsonProperty("PROCNT")]
        public double PROCNT { get; set; }

        [JsonProperty("FAT")]
        public double FAT { get; set; }

        [JsonProperty("CHOCDF")]
        public double CHOCDF { get; set; }

        [JsonProperty("FIBTG")]
        public double FIBTG { get; set; }
    }

    public class Parsed
    {
        [JsonProperty("food")]
        public FoodDto Food { get; set; }
    }

    public class Qualified
    {
        [JsonProperty("qualifiers")]
        public List<Qualifier> Qualifiers { get; set; }

        [JsonProperty("weight")]
        public double Weight { get; set; }
    }

    public class Qualifier
    {
        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }

    public class Root
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("parsed")]
        public List<Parsed> Parsed { get; set; }

        [JsonProperty("hints")]
        public List<Hint> Hints { get; set; }

        [JsonProperty("_links")]
        public Links Links { get; set; }
    }


}
