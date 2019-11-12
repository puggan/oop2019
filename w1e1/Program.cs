using System;

namespace w1e1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int firstNumber = ReadInt("Type a number");
            int lastNumber = ReadInt("Type another number");

            Console.WriteLine();
            Console.WriteLine($"{firstNumber} + {lastNumber} = {firstNumber + lastNumber}");            
        }

        private static int ReadInt(string question)
        {
            while (true)
            {
                Console.Write(question);
                Console.WriteLine(": ");
                var a = Console.ReadLine();
                try
                {
                    return Int32.Parse(a);
                }
                catch (FormatException)
                {
                    Console.Write("That's not a number, try again");
                }
            }
        }
    }
}
