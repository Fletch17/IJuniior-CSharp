namespace _05_MergeIntoOneCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] firstNumbers = { "1", "2", "1" };
            string[] secondNumbers = { "3", "2" };
            List<string> resultNumbers = new List<string>();

            FillList(firstNumbers,resultNumbers);
            FillList(secondNumbers,resultNumbers);

            foreach (string number in resultNumbers) 
            {
                Console.Write(number + " ");
            }
        }

        static void FillList(string[]array, List<string> list)
        {
            foreach (string arrayElement in array)
            {
                if (list.Contains(arrayElement) == false)
                {
                    list.Add(arrayElement);
                }
            }
        }
    }
}