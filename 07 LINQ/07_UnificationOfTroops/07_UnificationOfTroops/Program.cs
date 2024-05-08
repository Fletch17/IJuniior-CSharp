namespace _07_UnificationOfTroops
{
    internal class Program
    {
        static void Main(string[] args)
        {
           string firstLetter = "Б";
           List<Soldier> firstArmy = new List<Soldier>() {
           new Soldier("Бородин"),
           new Soldier("Шанушкин"),
           new Soldier("Пельменев"),
           new Soldier("Батонов"),
           new Soldier("Сосиский")};
           List<Soldier> secondArmy = new List<Soldier>() {
           new Soldier("Тушенкин"),
           new Soldier("Шашлыков"),
           new Soldier("Хмельнов"),
           new Soldier("Колбасов"),
           new Soldier("Огурцов")};

            var tempList = firstArmy.Where(soldier => soldier.Name.StartsWith(firstLetter));

            secondArmy = secondArmy.Union(tempList).ToList();
            firstArmy = firstArmy.Except(tempList).ToList();
            ShowInfo("Перый отряд:", firstArmy);
            Console.WriteLine();
            ShowInfo("Второй отряд:", secondArmy);
        }

        static void ShowInfo(string message, List<Soldier> army)
        {
            Console.WriteLine(message);

            foreach (var soldier in army)
            {
                Console.WriteLine(soldier.Name);
            }
        }
    }

    public class Soldier
    {
        public Soldier(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}