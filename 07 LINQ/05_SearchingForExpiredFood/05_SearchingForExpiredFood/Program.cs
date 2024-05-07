namespace _05_SearchingForExpiredFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int year = 2024;
            List<Product> products = new List<Product>() {
            new Product("Московская", 2005, 20),
            new Product("Томская", 2010, 20),
            new Product("Хабаровская", 1995, 15),
            new Product("Новосибирская", 1998, 25),
            new Product("Тульская", 2001, 10)
            };
            List<Product> expiredFood = new List<Product>();

            expiredFood = products.Where(product => product.Year + product.ExpirationDate <= year).ToList();
            Console.WriteLine("Просрочка:");

            foreach (var product in expiredFood)
            {
                Console.WriteLine(product.Name);
            }
        }
    }

    class Product
    {
        public string Name { get; private set; }
        public int Year { get; private set; }
        public int ExpirationDate { get; private set; }

        public Product(string name, int year, int srokGodnosti)
        {
            Name = name;
            Year = year;
            ExpirationDate = srokGodnosti;
        }
    }
}