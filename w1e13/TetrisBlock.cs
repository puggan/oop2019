using System;
using System.Collections.Generic;
using System.Linq;

namespace w1e13
{
    internal class TetrisBlock
    {
        private byte[,] pixels;
        private ConsoleColor color;
        private int dir = 0;

        public TetrisBlock(byte[,] pixels, ConsoleColor color)
        {
            this.pixels = pixels;
            this.color = color;
        }

        public void RotateCW()
        {
            dir = (dir + 1) % 4;
        }

        public void RotateCCW()
        {
            dir = (dir + 3) % 4;
        }

        private byte[,] getRotated()
        {
            int height;
            int width;
            byte[,] copy;
            if(dir % 2 > 1)
            {
                height = pixels.GetLength(1);
                width = pixels.GetLength(0);
            }
            else
            {
                height = pixels.GetLength(0);
                width = pixels.GetLength(1);
            }

            copy = new byte[height, width];
            switch(dir)
            {
                case 3:
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            copy[y, x] = pixels[x, height - 1 - y];
                        }
                    }
                    return copy;

                case 2:
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            copy[y, x] = pixels[height - 1 - y, width - 1 - x];
                        }
                    }
                    return copy;

                case 1:
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            copy[y, x] = pixels[width - 1 - x, y];
                        }
                    }
                    return copy;

                case 0:
                default:
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            copy[y, x] = pixels[y, x];
                        }
                    }
                    return copy;
            }
        }

        public void Print(int xStart, int yStart)
        {
            bool restart;
            byte[,] part = getRotated();
            int height = pixels.GetLength(0);
            int width = pixels.GetLength(1);

            Console.BackgroundColor = color;
            for(int y = 0; y < height; y++)
            {
                restart = true;
                for(int x = 0; x < width; x++)
                {
                    if(part[y, x] > 0) {
                        if(restart) {
                            Console.SetCursorPosition(2 * (xStart + x), yStart + y);
                        }
                        Console.Write("  ");
                    } else {
                       restart = true;
                    }
                }
            }
            Console.ResetColor();
        }

    }
}
