namespace _09_SuperMarket
{
    /*
     АДминистрирование кафе
    В супермаркете есть очередь клиентов
    У каждого клиента в корзине есть товары, также у клиентов есть деньги.
    Клиент, когда подходит на кассу, получает итоговую сумму покупки и старается ее оплатить.
    Если оплатить клиент не может, то он рандомный товар из корзины выкидывает до тех пор, пока его денег не хватит для оплаты.
    Клиентов можно делать ограниченное число на старте программы.
    Супермаркет содержит список товаров, из которых клиент выбирает товары для покупки.
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            new SuperMarket(5);
        }
    }

    public class SuperMarket
    {
        private Queue<Client> _clients;
        private Random _random;

        public SuperMarket(int clientCount) 
        {
            int min = 150;
            int max = 300;
            int money;
            _clients = new Queue<Client>();
            _random = new Random();

            for (int i = 0; i < clientCount; i++)
            {
                money= _random.Next(min,max);
                _clients.Enqueue(new Client(min=money));
            }
        }

        public void Run()
        {
            while(_clients.Count > 0) 
            {
                Console.WriteLine($"Людей в очереди: {_clients.Count}");

            }
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

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product) 
        {
        _products.Remove(product);
        }

        public bool IsEnoughMoney(int price)
        {
            return Money - price > 0;
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