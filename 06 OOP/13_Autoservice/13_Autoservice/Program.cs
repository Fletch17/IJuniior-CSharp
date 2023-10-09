namespace _13_Autoservice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Autoservice(10, 10).Work();
        }
    }

    public class Autoservice
    {
        private int _money;
        private Storage _storage;
        private Queue<Client> _clients;
        private string _message;

        public Autoservice(int clientCount, int detailsCount)
        {
            _clients = new Queue<Client>();
            _storage = new Storage();
            _money = 1000;
            FillStorage(detailsCount);
            FillClientQueue(clientCount);
        }

        public void Work()
        {
            const string ServeCommand = "1";
            const string RefuseCommand = "2";
            const string ExitCommand = "3";

            string userInput;
            bool isWork = true;
            Client client;

            while (_clients.Count > 0 && isWork)
            {
                client = _clients.Peek();
                Console.Clear();
                Console.WriteLine(_message);
                Console.WriteLine($"Ваш баланс: {_money}");
                _storage.ShowInfo();
                Console.WriteLine($"Клиентов в очереди: {_clients.Count}");
                Console.WriteLine($"У клиента поломка: {client.DefectDetail.Name}, цена детали {client.DefectDetail.Price}, цена работы {client.DefectDetail.WorkPrice}.\n");
                Console.WriteLine($"{ServeCommand}. Обслужить клиента.");
                Console.WriteLine($"{RefuseCommand}. Отказать клиенту.");
                Console.WriteLine($"{ExitCommand}. Выйти из приложения.");
                Console.Write("Ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ServeCommand:
                        Serve(client);
                        break;

                    case RefuseCommand:
                        Refuse(client);
                        break;

                    case ExitCommand:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Нет такой команды!");
                        break;
                }

                if (_money < 0)
                {
                    Console.WriteLine("Вы проиграли. Вы в долгах.");
                    isWork = false;
                }
            }
        }

        private void Refuse(Client client)
        {
            _message = $"Вы отказали клиенту, клиент ушел недовольным, а вы заплатили штраф {client.DefectDetail.WorkPrice}.";
            _money -= client.DefectDetail.WorkPrice;

            _clients.Dequeue();
        }

        private bool TryGetDetail(Detail detail, out int index)
        {
            index = 0;
            for (int i = 0; i < _storage.Count; i++)
            {
                if (_storage.GetDetail(i).Detail.Name == detail.Name)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }

        private void Serve(Client client)
        {
            if (TryGetDetail(client.DefectDetail, out int index))
            {
                _message = $"Вы заменили  {client.DefectDetail.Name} и заработали: {client.DefectDetail.Price} за деталь,{client.DefectDetail.WorkPrice} за работу.";
                _money += client.DefectDetail.WorkPrice + client.DefectDetail.Price;
            }
            else
            {
                _message = $"У Вас нет {client.DefectDetail.Name}, поэтому Вы платите клиенту неутойку {client.DefectDetail.WorkPrice}. Клиент уезжает в автосервис, написанный другим учеником.";
                _money += client.DefectDetail.WorkPrice;
            }

            _storage.RemoveDetail(_storage.GetDetail(index).Detail);
            _clients.Dequeue();
        }

        private void FillClientQueue(int clientCount)
        {
            for (int i = 0; i < clientCount; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        private void FillStorage(int count)
        {
            AllDetails allDetails = new AllDetails();

            for (int i = 0; i < count; i++)
            {
                int index = UserUtils.GenerateRandomNumber(allDetails.Count);

                _storage.AddDetail(allDetails.GetGetail(index));
            }
        }
    }

    public class Client
    {
        public Client()
        {
            DefectDetail = new AllDetails().GetDefectRandomDetail;
        }

        public Detail DefectDetail { get; private set; }
    }

    public class Storage
    {
        private List<Stack> _storage;

        public Storage()
        {
            _storage = new List<Stack>();
        }

        public int Count => _storage.Count;

        public Stack GetDetail(int index) => _storage[index];

        public void ShowInfo()
        {
            Console.WriteLine("На складе:");

            for (int i = 0; i < _storage.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_storage[i].Detail.Name} - {_storage[i].Count} шт., цена: {_storage[i].Detail.Price}");
            }
        }

        public void AddDetail(Detail detail)
        {
            if (IsContains(detail, out int index))
            {
                _storage[index].IncreaseDetail();
            }
            else
            {
                _storage.Add(new Stack(detail, 1));
            }
        }

        public void RemoveDetail(Detail detail)
        {
            if (IsContains(detail, out int index))
            {
                _storage[index].DecreaseDetail();

                if (_storage[index].Count == 0)
                {
                    _storage.RemoveAt(index);
                }
            }
        }

        private bool IsContains(Detail detail, out int index)
        {
            index = 0;

            for (int i = 0; i < _storage.Count; i++)
            {
                if (_storage[i].Detail == detail)
                {
                    index = i;
                    return true;
                }
            }

            return false;
        }
    }

    public class AllDetails
    {
        private List<Detail> _details = new List<Detail>
            {
            new Detail("АККП", 200,2),
            new Detail("МККП", 200,2),
            new Detail("ГРМ", 50,2),
            new Detail("Свечи", 10,2),
            new Detail("Двигатель", 1000,2),
            new Detail("Колодки", 30,2),
        };

        public int Count => _details.Count;

        public Detail GetGetail(int index) => _details[index];
        public Detail GetDefectRandomDetail => _details[UserUtils.GenerateRandomNumber(_details.Count)];
    }

    public class Stack
    {
        public Stack(Detail detail, int count)
        {
            Detail = detail;
            Count = count;
        }

        public Detail Detail { get; private set; }
        public int Count { get; private set; }

        public void IncreaseDetail()
        {
            Count++;
        }

        public void DecreaseDetail()
        {
            Count--;
        }
    }

    public class Detail
    {
        public Detail(string name, int price, int repairRate)
        {
            Name = name;
            Price = price;
            WorkPrice = price / repairRate;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
        public int WorkPrice { get; private set; }
    }

    public class UserUtils
    {
        private static Random s_random = new Random();
        public static int GenerateRandomNumber(int maxValue)
        {
            return s_random.Next(maxValue);
        }
    }
}