using System;

namespace w1e02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int firstYear = ReadInt("First year");
            int lastYear = ReadInt("Last year");

            if(lastYear < firstYear)
            {
                Console.Error.WriteLine("Backwards counting not supported");
                return;
            }

            if (firstYear < 1582)
            {
                Console.Error.WriteLine("Can't calculate leap-years before they was invented in the Gregorian calendar at 1582");
                firstYear = 1582;
            }

            if(lastYear <= 9999)
            {
                Console.Error.WriteLine("I'm not sure we going to use the Gregorian calendar for that long...");
                return;
            }
            
            for (int year = firstYear; year <= lastYear; year++)
            {
                if (year % 4 > 0 || year % 100 == 0 && year % 400 > 0)
                {
                    Console.WriteLine($"❌ {year}");
                }
                else
                {
                    Console.WriteLine($"✔ {year}");
                }
            }
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
