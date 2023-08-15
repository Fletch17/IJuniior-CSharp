namespace _07_Trains
{
    //У вас есть программа, коротая помогает пользователю составить план поезда.
    //    Есть 4 основных шага в создании: 
    //    -Создать направление - создает направление для поезда (к примеру Бийск-Барнаул)
    //    -Продать билеты - вы получаете рандомное кол-во пассажиров, которые купили билеты на это направление.
    //    -Сформировать поезд - вы создаете поезд и добавляете ему столько вагонов(вагоны могут быть разные по вместимости),
    //    сколько хватит для перевозки всех пассажиров.
    //    -Отправить поезд - вы отправляете поезд, после чего можете снова создать направление.
    //В верхней части программы должна выводиться полная информация о текущем рейсе или его отсутствии.
    internal class Program
    {
        static void Main(string[] args)
        {
            new Station().Run();
        }
    }

    public class Station
    {
        private List <string> _destinations;
        private Train _train;

        public Station()
        {
            List<string> cities= new List<string> { "Москва", "Сочи", "Хабаровск", "Новосибирск" };
            CreateDestinations(cities);
        }

        public void Run()
        {
            int trainCountMax = 5;
            int currentTrain = 0;
            int min = 150;
            int max = 250;
            int index;
            Random random= new Random();

            while(currentTrain!= trainCountMax)
            {
                index=random.Next(_destinations.Count);
                _train = new Train(min,max);

                Console.WriteLine($"\tНаправление: {_destinations[index]}.");
                Console.WriteLine($"Кол-во пассажиров: {_train.PasengersCount}.");
                Console.WriteLine($"Кол-во вагонов: {_train.CarriagesCount}.");
                Console.WriteLine("Вместимость вагонов:");

                for (int i = 0; i < _train.CarriagesCount; i++)
                {
                    Console.WriteLine($"{i+1} вагон: {_train.GetCarriage(i).Capacity}.");
                }

                currentTrain++;
                Console.Write("Для отправления поезда нажмите любую кнопку...\n");
                Console.ReadKey();
            }
        }

        private void CreateDestinations(List<string> cities)
        {
            _destinations = new List<string>();

            for (int i = 0; i < cities.Count; i++)
            {
                for (int j = 0; j < cities.Count; j++)
                {
                    if (cities[i] != cities[j])
                    {
                        _destinations.Add($"{cities[i]} - {cities[j]}");
                    }
                }
            }
        }
    }

    public class Train
    {
        private List<Carriage> _carriages;

        public Train(int min,int max)
        {
            Random random= new Random();
            PasengersCount=random.Next(min,max);
            _carriages = new List<Carriage>();
            FillVagon();
        }
        
        public int PasengersCount { get; private set; }
        public int CarriagesCount=>_carriages.Count;

        public Carriage GetCarriage(int index)
        {
            return _carriages[index];
        }
        
        private void FillVagon()
        {
            int min = 15;
            int max = 30;
            int people = PasengersCount;

            while(people>0)
            {
                Carriage vagon=new Carriage(min,max);
                _carriages.Add(vagon);
                people -= vagon.Capacity;
            }
        }
    }

    public class Carriage
    {
        public Carriage(int min,int max)
        {
            Random random= new Random();
            Capacity=random.Next(min,max);
        }

        public int Capacity { get; private set; }
    }
}