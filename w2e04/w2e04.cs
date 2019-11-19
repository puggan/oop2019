using System;
using System.Threading;
using w2e01;

namespace w2e04
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Random random = new Random();
            while (true)
            {
                // Re-fetch, incase they changed
                int vh = Console.WindowHeight;
                int vw  = Console.WindowWidth;
                ConsoleColor color = (ConsoleColor) random.Next(0,16);
                int x1 = random.Next(0, vw);
                int x2 = random.Next(0, vw);
                int y1 = random.Next(0, vh);
                int y2 = random.Next(0, vh);
                int left = Math.Min(x1, x2);
                int top = Math.Min(y1, y2);
                int width = Math.Max(x1, x2) + 1 - left;
                int height = Math.Max(y1, y2) + 1 - top;
                Box.Draw(width, height, left, top, color);
                Thread.Sleep(100);
            }
        }
    }
}
