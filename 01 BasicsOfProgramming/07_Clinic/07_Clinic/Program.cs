using System;

namespace _07_Clinic
{
    class Program
    {
        static void Main(string[] args)
        {
            int minutesForOnePatient = 10;
            int patients;
            int minutesForWaiting;
            int hoursForWaiting;
            int minutesPerHour = 60;
            int timeForAllPatients;

            Console.Write("Введите кол-во людей в очереди: ");
            patients = Convert.ToInt16(Console.ReadLine());

            timeForAllPatients = patients * minutesForOnePatient;
            minutesForWaiting = timeForAllPatients % minutesPerHour;
            hoursForWaiting = timeForAllPatients / minutesPerHour;

            Console.WriteLine($"Вы должны отстоять в очереди:  {hoursForWaiting} часа и {minutesForWaiting} минут.");
        }
    }
}
