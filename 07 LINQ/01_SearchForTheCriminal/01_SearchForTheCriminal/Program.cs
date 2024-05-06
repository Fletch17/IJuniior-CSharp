namespace _01_SearchForTheCriminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int height;
            int weight;
            string nationality;
            bool isProrammWork = true;
            List<Criminal> criminals = new List<Criminal>()
            {
            new Criminal("Олег", false, 180,100,"русский"),
            new Criminal("Андрей", true, 150,50,"русский"),
            new Criminal("Геннадий", true, 170,70,"русский"),
            new Criminal("Дмитрий", true, 200,120,"белорус"),
            new Criminal("Антон", true, 180,90,"белорус"),
            new Criminal("Артем", false, 160,80,"белорус"),
            };

            while (isProrammWork)
            {
                Console.WriteLine("Введите данные");
                Console.Write("Рост: ");
                height = GetInt();
                Console.Write("Вес: ");
                weight = GetInt();
                Console.Write("Национальность: ");
                nationality = Console.ReadLine();

                var filteredCriminals = criminals.Where(criminal => criminal.Height.Equals(height) && criminal.Weight.Equals(weight) &&
                criminal.Nationality.Equals(nationality) && !criminal.IsImprisoned);

                foreach (var criminal in filteredCriminals)
                {
                    Console.WriteLine($"ФИО - {criminal.Name}. Рост - {criminal.Height}. Вес - {criminal.Weight}. Национальность - {criminal.Nationality}.");
                }
            }
        }

        static int GetInt()
        {
            bool isInt = false;

            while (isInt == false)
            {
                if (int.TryParse(Console.ReadLine(), out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Введите число!");
                }
            }

            return 0;
        }
    }

    public class Criminal
    {
        public Criminal(string name, bool isImprisoned, int height, int weight, string nationality)
        {
            Name = name;
            IsImprisoned = isImprisoned;
            Height = height;
            Weight = weight;
            Nationality = nationality;
        }

        public string Name { get; private set; }
        public bool IsImprisoned { get; private set; }
        public int Height { get; private set; }
        public int Weight { get; private set; }
        public string Nationality { get; private set; }
    }
}