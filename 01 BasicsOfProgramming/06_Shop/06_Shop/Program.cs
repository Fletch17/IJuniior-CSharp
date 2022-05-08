using System;

namespace _06_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            int gold;
            int crystals;
            int price = 10;

            Console.Write("Введиле кол-во золота: ");
            gold = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Сколько кристаллов хотите купить? Цена за 1 кристалл " + price + " золота.");
            crystals = Convert.ToInt32(Console.ReadLine());

            gold -= crystals * price;

            Console.WriteLine("Золото: " + gold);
            Console.WriteLine("Кристаллы: " + crystals);
        }
    }
}
