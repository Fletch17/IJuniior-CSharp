namespace _04_BraveNewWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ConsoleKey KeyMoveUp = ConsoleKey.W;
            const ConsoleKey KeyMoveDown = ConsoleKey.S;
            const ConsoleKey KeyMoveLeft = ConsoleKey.A;
            const ConsoleKey KeyMoveRight = ConsoleKey.D;

            char playerSymbol = '&';
            int positionX = 0;
            int positionY = 0;
            char[,] map = {
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

            while (true)
            {
                DrawMap(map);
                FindPlayerPosition(ref positionX, ref positionY, map, playerSymbol);
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case KeyMoveUp:
                        Move(0, -1, ref positionX, ref positionY, map);
                        break;

                    case KeyMoveDown:
                        Move(0, 1, ref positionX, ref positionY, map);
                        break;

                    case KeyMoveLeft:
                        Move(-1, 0, ref positionX, ref positionY, map);
                        break;

                    case KeyMoveRight:
                        Move(1, 0, ref positionX, ref positionY, map);
                        break;
                }

                Console.Clear();
            }
        }

        static void Move(int deltaX, int deltaY, ref int positionX, ref int positionY, char[,] map)
        {
            char playerSymbol = '&';
            char wallSymbol = '#';
            char empySymbol = ' ';

            if (map[positionY + deltaY, positionX + deltaX] != wallSymbol)
            {
                map[positionY + deltaY, positionX + deltaX] = playerSymbol;
                map[positionY, positionX] = empySymbol;
                positionX += deltaX;
                positionY += deltaY;
            }
        }

        static void FindPlayerPosition(ref int x, ref int y, char[,] map, char playerSymbol)
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

        static void DrawMap(char[,] map)
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