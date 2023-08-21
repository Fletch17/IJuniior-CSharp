namespace _09_SuperMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product("Хлеб", 15),
                new Product("Квас", 45),
                new Product("Колбаса", 85),
                new Product("Молоко", 25),
                new Product("Картошка", 10),
                new Product("Макароны", 20),
                new Product("Апельсины", 30),
                new Product("Гречка", 15),
                new Product("Майонез", 20),
                new Product("Сметана", 20)
            };

            new SuperMarket(5, products).Run();
        }
    }

    public class SuperMarket
    {
        private List<Product> _products;
        private Queue<Client> _clients;

        public SuperMarket(int clientCount, List<Product> products)
        {
            _clients = new Queue<Client>();
            _products = new List<Product>();

            foreach (var product in products)
            {
                Product tempProduct = new Product(product.Name, product.Price);
                _products.Add(tempProduct);
            }

            FillQueue(clientCount, _products);
        }

        public void Run()
        {
            Client client;

            while (_clients.Count > 0)
            {
                client = _clients.Peek();
                Console.WriteLine($"Людей в очереди: {_clients.Count}");
                Console.WriteLine($"У покупателя в корзине: ");
                client.ShowInfo();
                Console.WriteLine($"На сумму: {client.GetSummPrice()}");
                ServeClient(client);
            }

            Console.WriteLine("Все клиенты обслужены.");
        }

        private void ServeClient(Client client)
        {
            if (client.IsEnoughMoney(client.GetSummPrice()))
            {
                RemoveClient("Клиент обслужен.");
            }
            else if (client.ProductInCart == 0)
            {
                RemoveClient("Клиент ничего не купил. Не хватило денег.");
            }
            else
            {
                Console.WriteLine("У покупателя не хватает денег.");
                Console.WriteLine("Нажмите любую кнопку для удаления рандомного предмета.");
                Console.ReadKey();
                client.RemoveRandomProduct();
            }
        }

        private void RemoveClient(string message)
        {
            Console.WriteLine(message);
            _clients.Dequeue();
            Console.WriteLine("Нажмите любую кнопку для продолжения.");
            Console.ReadKey();
        }

        private void FillClientsCarts()
        {
            int productsInCart;
            int index;

            foreach (var client in _clients)
            {
                productsInCart = UserUtils.GenerateRandomNumber(1, _products.Count + 1);

                for (int i = 0; i < productsInCart; i++)
                {
                    index = UserUtils.GenerateRandomNumber(_products.Count);
                    client.AddProduct(_products[index]);
                }
            }
        }

        private void FillQueue(int clientCount, List<Product> products)
        {
            int minMoneyCount = 110;
            int maxMoneyCount = 250;
            int money;

            for (int i = 0; i < clientCount; i++)
            {
                money = UserUtils.GenerateRandomNumber(minMoneyCount, maxMoneyCount);
                _clients.Enqueue(new Client(money));
            }

            FillClientsCarts();
        }
    }

    public class Client
    {
        private List<Product> _products;

        public Client(int money)
        {
            _products = new List<Product>();
            Money = money;
        }

        public int Money { get; private set; }
        public int ProductInCart => _products.Count;

        public bool IsEnoughMoney(int price) => Money >= price;

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveRandomProduct()
        {
            int index = UserUtils.GenerateRandomNumber(_products.Count);
            Console.WriteLine($"Убран: {_products[index].Name}");
            _products.Remove(_products[index]);
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

    public class UserUtils
    {
        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue);
        }
        public static int GenerateRandomNumber(int maxValue)
        {
            return new Random().Next(maxValue);
        }
    }
}