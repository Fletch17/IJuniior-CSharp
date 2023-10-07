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
        private int _clientCount;
        private Queue<Client> _clients;
        private string message;

        public Autoservice(int clientCount, int detailsCount)
        {
            _clients = new Queue<Client>();
            _clientCount = clientCount;
            _storage = new Storage();
            _money = 1000;
            FillStorage(detailsCount);
            FillClientQueue();
        }

        public void Work()
        {
            const string ServeCommand = "1";
            const string RefuseCommand = "2";
            const string ExitCommand = "3";
            string userInput;
            bool isWork = true;

            while (_clients.Count > 0 && isWork)
            {
                Console.Clear();
                Console.WriteLine(message);
                Console.WriteLine($"Ваш баланс: {_money}");
                _storage.ShowInfo();
                Console.WriteLine($"Клиентов в очереди: {_clients.Count}");
                Console.WriteLine($"У клиента поломка: {_clients.Peek().DefectDetail.Name}, цена детали {_clients.Peek().DefectDetail.Price}, цена работы {_clients.Peek().DefectDetail.WorkPrice}.\n");
                Console.WriteLine($"{ServeCommand}. Обслужить клиента.");
                Console.WriteLine($"{RefuseCommand}. Отказать клиенту.");
                Console.WriteLine($"{ExitCommand}. Выйти из приложения.");
                Console.Write("Ваш выбор: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case ServeCommand:
                        Serve();
                        break;

                    case RefuseCommand:
                        Refuse();
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

        private void Refuse()
        {
            message = $"Вы отказали клиенту, клиент ушел недовольным, а вы заплатили штраф {_clients.Peek().DefectDetail.WorkPrice}.";
            _money -= _clients.Peek().DefectDetail.WorkPrice;

            _clients.Dequeue();
        }

        private bool TryChooseDetail(out int index)
        {
            bool isChossing = true;
            string userInput;
            index = 0;

            while (isChossing)
            {
                Console.Write($"Выберите номер детали:");
                userInput = Console.ReadLine();

                if (int.TryParse(userInput, out index))
                {
                    index--;

                    if (index >= 0 && index < _storage.Count)
                    {
                        isChossing = false;
                    }
                    else
                    {
                        Console.WriteLine("Такого номера нету.");
                    }
                }
                else
                {
                    Console.WriteLine("Введите целое число!");
                }
            }

            return _clients.Peek().DefectDetail.Name == _storage.GetDetail(index).Detail.Name ? true : false;
        }

        private void Serve()
        {
            if (TryChooseDetail(out int index))
            {
                message = $"Вы заменили правильную деталь и заработали: {_storage.GetDetail(index).Detail.Price} за деталь,{_storage.GetDetail(index).Detail.WorkPrice} за работу.";
                _money += _clients.Peek().DefectDetail.WorkPrice + _clients.Peek().DefectDetail.Price;
            }
            else
            {
                message = message = $"Вы ошибочно заменили не ту деталь, разозлив клиента. Ваш штраф: {_storage.GetDetail(index).Detail.WorkPrice + _clients.Peek().DefectDetail.WorkPrice}";
                _money -= _storage.GetDetail(index).Detail.WorkPrice + _clients.Peek().DefectDetail.WorkPrice;
            }

            _storage.RemoveDetail(_storage.GetDetail(index).Detail);
            _clients.Dequeue();
        }

        private void FillClientQueue()
        {
            for (int i = 0; i < _clientCount; i++)
            {
                _clients.Enqueue(new Client());
            }
        }

        private void FillStorage(int count)
        {
            for (int i = 0; i < count; i++)
            {
                int index = UserUtils.GenerateRandomNumber(AllDetails.Count);

                _storage.AddDetail(AllDetails.GetGetail(index));
            }
        }
    }

    public class Client
    {
        public Client()
        {
            DefectDetail = AllDetails.GetGetail(UserUtils.GenerateRandomNumber(AllDetails.Count));
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

    public static class AllDetails
    {
        private static List<Detail> _details = new List<Detail>
            {
            new Detail("АККП", 200),
            new Detail("МККП", 200),
            new Detail("ГРМ", 50),
            new Detail("Свечи", 10),
            new Detail("Двигатель", 1000),
            new Detail("Колодки", 30),
        };

        public static int Count => _details.Count;

        public static Detail GetGetail(int index) => _details[index];
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
        public Detail(string name, int price)
        {
            Name = name;
            Price = price;
            WorkPrice = price / 2;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }
        public int WorkPrice { get; private set; }
    }

    public class UserUtils
    {
        public static int GenerateRandomNumber(int maxValue)
        {
            return new Random().Next(maxValue);
        }
    }
}