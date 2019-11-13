using System;
using System.Threading;

namespace w1e10
{
    internal class Program
    {
        string[] invader;
        private int width;
        private int height;
        private int posx;
        private int posy;
        private int maxx;
        private int maxy;

        public static void Main(string[] args)
        {
            Program me = new Program();
            while (me.draw())
            {
                Thread.Sleep(100);
            }
        }

        public Program()
        {
            invader = invaderRows();
            height = invader.Length;
            width = invader[0].Length;
            posx = 0;
            posy = 0;
            maxx = Console.LargestWindowWidth/2 - width;
            maxy = Console.LargestWindowHeight - height;
            /*
            Console.WriteLine($"Size: {maxx} x {maxy}");
            Thread.Sleep(10000);
            */
        }

        public bool draw()
        {
            if (posy % 2 > 0)
            {
                if (posx <= 0)
                {
                    posy++;
                }
                else
                {
                    posx--;
                }
            }
            else
            {
                if (posx >= maxx)
                {
                    posy++;
                }
                else
                {
                    posx++;
                }
            }

            Console.Clear();
            print(posx, posy);
            return (posy <= maxy);
        }

        public void print(int startx, int starty)
        {
            int y = starty;
            foreach (string row in invader)
            {
                Console.SetCursorPosition(startx * 2, y++);
                Console.WriteLine(row);
            }
        }

        public static string[] invaderRows()
        {
            int[,] invaderInts = henrikql.Invader.invader();
            int height = invaderInts.GetLength(0);
            int width = invaderInts.GetLength(1);
            string[] result = new String[height];
            
            for(var y = 0; y < height; y++)
            {
                char[] charRow = new char[2*width];
                for (var x = 0; x < width; x++)
                {
                    charRow[2*x] = invaderInts[y,x] > 0 ? '*' : ' ';
                    charRow[2*x+1] = invaderInts[y,x] > 0 ? '*' : ' ';
                }

                result[y] = new String(charRow);
            }

            return result;
        }
    }
}
