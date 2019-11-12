using System;

namespace w1e13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Bag<int> bag = new Bag<int>(new int[] {1,2,3,4,5,6,7});

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine(bag.Next());
            }
        }
    }
}
