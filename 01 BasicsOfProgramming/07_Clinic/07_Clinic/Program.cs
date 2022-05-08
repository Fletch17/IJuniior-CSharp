using System;

namespace _07_Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesForOneHuman = 10;
            int humans;
            int minutes;
            int hours;
            int minutesPerHour = 60;

            Console.Write("Введите кол-во людей в очереди: ");
            humans = Convert.ToInt16(Console.ReadLine());

            minutes = humans * minutesForOneHuman % minutesPerHour;
            hours = humans * minutesForOneHuman / minutesPerHour;

            Console.WriteLine($"Вы должны отстоять в очереди:  {hours} часа и {minutes} минут.");
        }
    }
}
