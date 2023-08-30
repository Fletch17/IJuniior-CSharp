namespace _12_Zoopark
{
    /*
     * Пользователь запускает приложение и перед ним находится меню, в котором он может выбрать к какому вольеру подойти.
     * При приближении к вольеру, пользователю выводится информация о том, что это за вольер, сколько животных там обитает, 
     * их пол и какой звук издает животное.
     * Вольеров в зоопарке может быть много, в решении нужно создать минимум 4 вольера.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Volier vlo = new Volier(5,new Tiger());
        }
    }

    public class Volier
    {
        private List<Animal> _animals;

        public Volier(int animalsCount, Animal animal)
        {
            _animals = new List<Animal>();
            Animal animalTemp;

            for (int i = 0; i < animalsCount; i++)
            {
                animalTemp = animal;
                _animals.Add(animalTemp);
            }
        }
    }

    public class Cow:Animal
    {
        public Cow():base()
        {
            Name = "Корова";
            Voice = "Муууу..";
        }
    }

    public class Tiger:Animal
    {
        public Tiger():base()
        {
            Name = "Тигр";
            Voice = "РРРрррр..";
        }
    }

    public class Animal
    {
        protected static Random s_random;

        protected string[] SexArray;

        public string Name { get; protected set; }
        public string Sex { get; protected set; }
        public string Voice { get; protected set; }

        public Animal ()
        {
            s_random = new Random();
            SexArray = new string []{ "М", "Ж"};
            Sex = GetRandomSex();
        }

        protected string GetRandomSex()
        {
            int index = s_random.Next(SexArray.Length);
            return SexArray[index];
        }
    }
}