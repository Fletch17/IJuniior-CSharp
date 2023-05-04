namespace _02_WorkingWithProperties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PlayerDrawer playerDrawer = new PlayerDrawer(new Player(3, 8));

            playerDrawer.DrawPlayer();
        }
    }

    class Player
    {
        private int _positionX;
        private int _positionY;

        public int PositionX => _positionX;
        public int PositionY => _positionY;

        public Player(int positionX, int positionY)
        {
            _positionX = positionX;
            _positionY = positionY;
        }
    }

    class PlayerDrawer
    {
        Player _player;

        public PlayerDrawer(Player player)
        {
            _player = player;
        }

        public void DrawPlayer()
        {
            Console.WriteLine($"Отрисовал игрока по координатам X:Y - {_player.PositionX}:{_player.PositionY}");
        }
    }
}