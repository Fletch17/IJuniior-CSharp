using System;

namespace _03_WorkWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string age;
            string city;
            string profession;

            Console.WriteLine("Как Вас зовут?");
            name = Console.ReadLine();
            Console.WriteLine("Сколько Вам лет?");
            age = Console.ReadLine();
            Console.WriteLine("Где Вы живете?");
            city = Console.ReadLine();
            Console.WriteLine("Кем работаете?");
            profession = Console.ReadLine();

            Console.WriteLine("Вас зовут " + name + ", Вам " + age + " лет, живете в городе " + city + ", работаете " + profession + ".");
        }
    }
}
