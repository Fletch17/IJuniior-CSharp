namespace _02_WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(4,7);
            PlayerDrawer playerDrawer = new PlayerDrawer();

            playerDrawer.Draw(player.PositionX, player.PositionY);
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;
        
        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }

        public int PositionX => _positionX;
        public int PositionY => _positionY;
    }

    class PlayerDrawer
    {
        public void Draw(int positionX, int positionY)
        {
            Console.WriteLine($"Отрисовал игрока по координатам X:Y - {positionX}:{positionY}");
        }
    }
}