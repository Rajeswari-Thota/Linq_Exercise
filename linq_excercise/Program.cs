namespace linq_excercise
{

    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
    }

    public class Program
    {
        static List<Product> productList = new List<Product>();

        public void SeedData()
        {
            productList.Add(new Product { ProductId = "P001", ProductName = "Laptop", Brand = "Dell", Quantity = 5, Price = 35000 });
            productList.Add(new Product { ProductId = "P002", ProductName = "Camera", Brand = "Canon", Quantity = 8, Price = 28500 });
            productList.Add(new Product { ProductId = "P003", ProductName = "Tablet", Brand = "Lenovo", Quantity = 4, Price = 15000 });
            productList.Add(new Product { ProductId = "P004", ProductName = "Mobile", Brand = "Apple", Quantity = 9, Price = 65000 });
            productList.Add(new Product { ProductId = "P005", ProductName = "Earphones", Brand = "Boat", Quantity = 2, Price = 1500 });
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.SeedData();


            var productsInRange = from p in productList where p.Price >= 20000 && p.Price <= 40000 select p.ProductName;
            Console.WriteLine("Product names where price is between 20000 and 40000:");
            foreach (var x in productsInRange)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine();


            var productsWithA = from p in productList where p.ProductName.Contains("a") select p;
            Console.WriteLine("Products with name containing letter 'a':");
            foreach (var product in productsWithA)
            {
                Console.WriteLine($"{product.ProductName}, {product.Brand}, {product.Quantity}, {product.Price}");
            }
            Console.WriteLine();


            var productsSortedByName = from p in productList orderby p.ProductName select p;
            Console.WriteLine("Products sorted by name:");
            foreach (var product in productsSortedByName)
            {
                Console.WriteLine($"{product.ProductName}, {product.Brand}, {product.Quantity}, {product.Price}");
            }
            Console.WriteLine();


            var highestPrice = productList.Max(p => p.Price);
            Console.WriteLine($"Highest price: {highestPrice}");
            Console.WriteLine();

            
            var productExists = productList.Any(p => p.ProductId == "P003");
            Console.WriteLine($"Product with id 'P003' exists: {productExists}");
        }
    }
}
