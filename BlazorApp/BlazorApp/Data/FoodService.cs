namespace BlazorApp.Data
{
    public class Food
    {
        public string Nmae { get; set; }
        public string Price { get; set; }
    }

    public interface IFoodService
    {
        IEnumerable<Food> GetFoods();
    }
    
    public class FoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            return new List<Food>
            {
                new Food() { Nmae="A", Price="10000" },
                new Food() { Nmae="B", Price="15000" },
                new Food() { Nmae="C", Price="20000" },
            };
        }
    }

    public class FastFoodService : IFoodService
    {
        public IEnumerable<Food> GetFoods()
        {
            return new List<Food>
            {
                new Food() { Nmae="FastA", Price="10000" },
                new Food() { Nmae="FastB", Price="20000" },
                new Food() { Nmae="FastC", Price="30000" },
            };
        }
    }


    public class PaymentService 
    {
        IFoodService _foodService;
        public PaymentService(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public int Calculate()
        {
            var foods = _foodService.GetFoods();
            var foodsPrice = foods.Select(f => Int32.Parse(f.Price));
            return foodsPrice.Sum();
        }
    }

    public class SingletonService : IDisposable
    {
        public Guid ID { get; set; }

        public SingletonService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("Singleton Service Disposed");
        }
    }

    public class TransientService : IDisposable
    {
        public Guid ID { get; set; }

        public TransientService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("Singleton Service Disposed");
        }
    }

    public class ScopedService : IDisposable
    {
        public Guid ID { get; set; }

        public ScopedService()
        {
            ID = Guid.NewGuid();
        }

        public void Dispose()
        {
            Console.WriteLine("Singleton Service Disposed");
        }
    }
}
