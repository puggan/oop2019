using System;

namespace w1e9
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int count = countTypeOnMap(map(args[0]), '#');
            Console.WriteLine($"found {count}");
        }

        public static string[] map(string filename)
        {
            return System.IO.File.ReadAllLines(@filename);
        }

        public static int countTypeOnMap(string[] haystack, char needle)
        {
            int found = 0;
            foreach(string line in haystack)
            {
                foreach(char c in line)
                {
                    if (c == needle)
                    {
                        found++;
                    }
                }
            }

            return found;
        }
    }
}
