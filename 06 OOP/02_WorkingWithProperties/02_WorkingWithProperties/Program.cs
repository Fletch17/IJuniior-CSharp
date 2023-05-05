namespace _02_WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(5, 3);
            Renderer renderer = new Renderer();

            renderer.Draw(player.PositionX, player.PositionY, '@');
        }
    }

    class Player
    {
        public Player(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }

        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
    }

    class Renderer
    {
        public void Draw(int positionX, int positionY, char symbol)
        {
            if (positionX >= 0 && positionY >= 0)
            {
                Console.SetCursorPosition(positionX, positionY);
                Console.WriteLine(symbol);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}