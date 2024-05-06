namespace _02_Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string crime = "Антиправительственное";
            List<Criminal> criminals = new List<Criminal>()
            {new Criminal("Гоша", "Воровство"),
            new Criminal("Тоша", "Антиправительственное"),
            new Criminal("Артем", "Воровство"),
            new Criminal("Андрей", "Антиправительственное"),
            new Criminal("Дмитрий", "Убийство") };

            ShowInfo("До амнистии:", criminals);
            criminals = criminals.Where(criminal => criminal.Crime != crime).ToList();
            Console.WriteLine();
            ShowInfo("После амнистии:", criminals);
        }

        static void ShowInfo(string message, IEnumerable<Criminal> criminals)
        {
            Console.WriteLine(message);

            foreach (var criminal in criminals)
            {
                Console.WriteLine(criminal.Name);
            }
        }
    }

    public class Criminal
    {
        public string Name { get; private set; }
        public string Crime { get; private set; }

        public Criminal(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}