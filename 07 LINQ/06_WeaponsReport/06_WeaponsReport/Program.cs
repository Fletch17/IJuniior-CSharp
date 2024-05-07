namespace _06_WeaponsReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldiers = new List<Soldier>() {
            new Soldier("Jack", "AK-47", "Captain", 36),
            new Soldier("John", "AK-47", "Captain", 52),
            new Soldier("Ben", "Grenade", "Major", 72),
            new Soldier("Alex", "Pen", "General", 400),
            new Soldier("Bob", "Makharov", "Lieutenant", 6),
            };

            var filteredSoldiers = soldiers.Select(soldier => new
            {
                soldier.Name,
                soldier.Rank
            }).ToList();

            foreach (var soldier in filteredSoldiers)
            {
                Console.WriteLine(soldier.Name + " - " + soldier.Rank);
            }
        }
    }

    public class Soldier
    {
        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int LengthOfMilitaryService { get; private set; }

        public Soldier(string name, string weapon, string rank, int lengthOfMilitaryService)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            LengthOfMilitaryService = lengthOfMilitaryService;
        }
    }
}