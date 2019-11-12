using System;

namespace w1e4
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int FROM = 1;
            const int TO = 100;
            const int FIZZ = 3;
            const int BUZZ = 5;
            for (int number = FROM; number <= TO; number++)
            {
                bool found = false;
                if (number % FIZZ == 0)
                {
                    Console.Write("Fizz");
                    found = true;
                }
                if (number % BUZZ == 0)
                {
                    Console.Write("Buzz");
                    found = true;
                }

                Console.WriteLine(found ? "" : $"{number}");
            }
        }
    }
}
