using System;

namespace _05_PermutationInPlacesOfValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "Ivanova";
            string surname = "Kate";
            string tempName = name;
            string tempSurname = surname;

            Console.WriteLine(name + " " + surname);

            name = tempSurname;
            surname = tempName;

            Console.WriteLine(name + " " + surname);
        }
    }
}
