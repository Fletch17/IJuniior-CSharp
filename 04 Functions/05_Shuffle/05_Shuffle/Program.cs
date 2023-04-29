namespace _05_Shuffle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {1,2,3,4,5,6,7,8,9 };

            numbers = Shuffle(numbers);

            foreach (int number in numbers) 
            {
                Console.Write(number+" ");
            }
        }

        static int []Shuffle(int[] array)
        {
            Random random = new Random();
            int[] tempArray = new int [array.Length];
            int index;

            for (int i = 0; i < array.Length; i++)
            {
                tempArray[i] = array[i];
            }

            for (int i = 0; i < array.Length; i++) 
            {
                index = random.Next(tempArray.Length);
                array[i] = tempArray[index];
                tempArray=DeleteElement(tempArray,index);
            }

            return array;
        }

        static int[]DeleteElement(int[]array,int index)
        {
            int[] temparray = new int[array.Length-1];

            for (int i = 0;i < index;i++) 
            {
                temparray[i] = array[i];
            }

            for (int i = index + 1; i < array.Length; i++)
            {
                temparray[i-1] = array[i];
            }

            return temparray;
        }
    }
}