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
            int numberToRepresentMaxPercent = 100;
            double percentHP=(currentHP/maxHP)* numberToRepresentMaxPercent;
            double percentMP=(currentMP/maxMP)* numberToRepresentMaxPercent;

            DrawBar(percentHP, maxSymbolCount, ConsoleColor.Red);
            Console.WriteLine();
            DrawBar(percentMP, maxSymbolCount, ConsoleColor.Blue);
        }

        static void DrawBar(double percentValue,int maxSymbolCount,ConsoleColor color)
        {
            char symbolValue = '#';
            char symbolNonValue = '_';
            int numberToRepresentMaxPercent = 100;
            int symbolCount = (int)Math.Ceiling(((double)maxSymbolCount/ numberToRepresentMaxPercent) * percentValue);            
            ConsoleColor defaultColor = Console.BackgroundColor;
            Console.Write("[");
            Console.BackgroundColor = color;
            DrawSymbols(symbolValue, 0, symbolCount);
            Console.BackgroundColor = defaultColor;
            DrawSymbols(symbolNonValue, symbolCount, maxSymbolCount);
            Console.Write("]");
        }

        static void DrawSymbols(char symbol, int startIndex,int stopIndex)
        {
            for (int i = startIndex; i < stopIndex; i++)
            {
                Console.Write(symbol);
            }
        }
    }
}