using System.Drawing;

namespace _02_UIElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxSymbolCount = 10;
            double currentHP = 50;
            double maxHP = 100;
            double currentMP = 70;
            double maxMP = 200;
            double percentHP=(currentHP/maxHP)*100;
            double percentMP=(currentMP/maxMP)*100;

            DrawBar(percentHP, maxSymbolCount, ConsoleColor.Red);
            Console.WriteLine();
            DrawBar(percentMP, maxSymbolCount, ConsoleColor.Blue);
        }

        static void DrawBar(double percentValue,int maxSymbolCount,ConsoleColor color)
        {
            char symbolValue = '#';
            char symbolNonValue = '_';
            int symbolCount = (int)Math.Ceiling(((double)maxSymbolCount/ 100) * percentValue);            
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.Write("[");
            Console.BackgroundColor = color;

            for (int i = 0; i < symbolCount; i++) 
            {
                Console.Write(symbolValue);
            }

            Console.BackgroundColor = defaultColor;

            for (int i = symbolCount; i < maxSymbolCount; i++)
            {
                Console.Write(symbolNonValue);
            }

            Console.Write("]");
        }
    }
}