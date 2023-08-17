namespace _09_SuperMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product("Хлеб", 15));
            products.Add(new Product("Квас", 45));
            products.Add(new Product("Колбаса", 85));
            products.Add(new Product("Молоко", 25));
            products.Add(new Product("Картошка", 10));
            products.Add(new Product("Макароны", 20));
            products.Add(new Product("Апельсины", 30));
            products.Add(new Product("Гречка", 15));
            products.Add(new Product("Майонез", 20));
            products.Add(new Product("Сметана", 20));

            new SuperMarket(5, products).Run();
        }
    }

    public class SuperMarket
    {
        private static Random _random;
        private List<Product> _products;
        private Queue<Client> _clients;

        public SuperMarket(int clientCount, List<Product> products)
        {
            int min = 150;
            int max = 300;
            int money;
            _clients = new Queue<Client>();
            _random = new Random();
            _products = products;

            for (int i = 0; i < clientCount; i++)
            {
                money = _random.Next(min, max);
                _clients.Enqueue(new Client(money, products));
            }
        }

        public void Run()
        {
            Client client;
            int summPrice = 0;

            while (_clients.Count > 0)
            {
                client = _clients.Peek();
                summPrice = client.GetSummPrice();

                Console.WriteLine($"Людей в очереди: {_clients.Count}");
                Console.WriteLine($"У покупателя в корзине: ");
                client.ShowInfo();
                Console.WriteLine($"На сумму: {summPrice}");

                if (client.IsEnoughMoney(summPrice))
                {
                    Console.WriteLine("Клиент обслужен.");
                    _clients.Dequeue();
                    Console.WriteLine("Нажмите любую кнопку для продолжения.");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("У покупателя не хватает денег.");
                    Console.WriteLine("Нажмите любую кнопку для удаления рандомного предмета.");
                    Console.ReadKey();
                    client.RemoveRandomProduct();
                }
            }

            Console.WriteLine("Все клиенты обслужены.");
        }
    }

    public class Client
    {
        private static Random _random;
        private List<Product> _products;

        public Client(int money, List<Product> products)
        {
            _products = new List<Product>();
            _random = new Random();
            int productInCart = _random.Next(1, products.Count + 1);
            int index;

            for (int i = 0; i < productInCart; i++)
            {
                index = _random.Next(products.Count);
                _products.Add(products[index]);
            }

            Money = money;
        }

        public int Money { get; private set; }

        public bool IsEnoughMoney(int price) => Money - price > 0;

        public void RemoveRandomProduct()
        {
            int index = _random.Next(_products.Count);
            Console.WriteLine($"Убран: {_products[index].Name}");
            _products.RemoveAt(index);
        }

        public void ShowInfo()
        {
            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Name}");
            }

            Console.WriteLine($"Денег: {Money}");
        }

        public int GetSummPrice()
        {
            int summ = 0;

            foreach (var product in _products)
            {
                summ += product.Price;
            }

            return summ;
        }
    }

    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
    }
}