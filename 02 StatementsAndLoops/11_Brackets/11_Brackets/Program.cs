using System;

//Дана строка из символов '(' и ')'. Определить, является ли она корректным скобочным выражением.
//Определить максимальную глубину вложенности скобок.

//Пример “(()(()))” -строка корректная и максимум глубины равняется 3.
//Пример не верных строк: "(()", "())", ")(", "(()))(()"

//Для перебора строки по символам можно использовать цикл foreach, к примеру будет так foreach (var symbol in text)
//Или цикл for(int i = 0; i < text.Length; i++) и дальше обращаться к каждому символу внутри цикла как text[i]
//Цикл нужен для перебора всех символов в строке. 

namespace _11_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "(((()(()))"; 
            int depth = 0; 
            int maxDepth = 0; 

            foreach (char symbol in text)
            {
                if (symbol == '(')
                {
                    depth++;

                    if (depth > maxDepth)
                    {
                        maxDepth = depth;
                    }
                }
                else if (symbol == ')')
                {
                    depth--;

                    if (depth < 0)
                    {
                        Console.WriteLine("Ошибка: неправильно расставлены скобки!");
                        return;
                    }
                }
            }

            if (depth != 0)
            {
                Console.WriteLine("Ошибка: неправильно расставлены скобки!");
                return;
            }

            Console.WriteLine("Строка является корректным скобочным выражением.");
            Console.WriteLine("Максимальная глубина вложенности: " + maxDepth);
        }
    }
}
