namespace _04_BraveNewWorld
{
    internal class Program
    {
        static char[,] map = {
                {'#', '#','#','#','#','#','#','#','#', '#', '#', '#', '#', '#', '#', '#', '#'},
                {'#', ' ',' ',' ',' ',' ',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ','#','#','#','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ',' ',' ',' ','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', '#','#','#',' ','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ',' ','#',' ','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ',' ','#',' ','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#' },
                {'#', ' ',' ','#',' ','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                {'#', ' ',' ',' ',' ','#',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                {'#', ' ',' ','#','#','#',' ',' ',' ', ' ', ' ', '#', '#', '#', '#', ' ', '#' },
                {'#', '&',' ','#',' ',' ',' ',' ',' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#' },
                {'#', '#','#','#','#','#','#','#','#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };
        static int x;
        static int y;

        static void Main(string[] args)
        {
            char playerSymbol = '&';

            while (true) 
            {
                DrawMap();
                FindPlayerPosition(ref x, ref y, playerSymbol);
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        Move(0, -1);
                        break;

                    case ConsoleKey.S:
                        Move(0, 1);
                        break;

                    case ConsoleKey.A:
                        Move(-1, 0);
                        break;

                    case ConsoleKey.D:
                        Move(1, 0);
                        break;
                }

                Console.Clear();
            }
        }

        static void Move(int deltaX,int deltaY)
        {
            char playerSymbol = '&';
            char wallSymbol = '#';
            char empySymbol = ' ';

            if (map[ y + deltaY, x + deltaX] != wallSymbol)
            {
                map[y + deltaY,x + deltaX] = playerSymbol;
                map[y, x] = empySymbol;
                x += deltaX;
                y += deltaY;
            }
        }

        static void FindPlayerPosition(ref int x, ref int y, char playerSymbol)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == playerSymbol)
                    {
                        x = j;
                        y = i;
                    }
                }
            }
        }

        static void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}