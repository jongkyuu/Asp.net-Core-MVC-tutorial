namespace BlazorApp.Data
{
    public class Food
    {
        public string Nmae { get; set; }
        public string Price { get; set; }
    }

    public class FoodService
    {
        public List<Food> GetFoods()
        {
            return new List<Food>
            {
                new Food() { Nmae="A", Price="10000" },
                new Food() { Nmae="B", Price="15000" },
                new Food() { Nmae="C", Price="20000" },
            };
        }
    }
}
