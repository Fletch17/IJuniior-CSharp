using System;

namespace _04_Pictures
{
    class Program
    {
        static void Main(string[] args)
        {
            int pictureCount = 52;
            int picturesInRow = 3;
            int completedRows = pictureCount / picturesInRow;
            int remainingPictures = pictureCount % picturesInRow;
            Console.WriteLine("Заполненных рядов - "+completedRows);
            Console.WriteLine("Оставшиеся картинки - "+remainingPictures);
        }
    }
}
