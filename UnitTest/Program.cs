using System;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int sumResult = Add(5, 6);

            Console.WriteLine(sumResult);
            Console.WriteLine(IsOdd(sumResult));
        }

        public static int Add(int x, int y)
        {
            return x + y;
        }
        
        public static bool IsOdd(int value)
        {
            return value % 2 == 1;
        }
    }
}
