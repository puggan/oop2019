using System;

namespace w1e08
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ResetColor();
            int size = ReadInt("Please input size of tree");
            if (size < 2)
            {
                Console.Error.WriteLine("Sorry, the smalles I can draw is a size 2.");
                return;
            }

            for (int row = 0; row < size; row++)
            {
                int offset = size - row;
                if (offset > 0)
                {
                    Console.Write(new String(' ', size - row));
                }
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(new String('*', 2 * row + 1));
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.Write(new String(' ', size - 1));
            Console.BackgroundColor = ConsoleColor.DarkYellow; //Brown;
            Console.Write(new String("[ ]"));
            Console.ResetColor();
            Console.WriteLine();
        }

        private static int ReadInt(string question)
        {
            while (true)
            {
                Console.Write(question);
                Console.WriteLine(": ");
                try
                {
                    return Int32.Parse(Console.ReadLine() ?? throw new FormatException());
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("That's not a number, try again");
                }
            }
        }
    }
}
