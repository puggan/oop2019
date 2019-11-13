using System;
using System.Collections.Generic;

namespace w1e12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<ConsoleColor> partColors = new List<ConsoleColor>();
            List<byte[,]> parts = new List<byte[,]>();
            // @see https://en.wikipedia.org/wiki/Tetris#/media/File:Tetrominoes_IJLO_STZ_Worlds.svg
            // @see https://pradeep1210.files.wordpress.com/2010/02/tetrisshapes5b35d.jpg

            partColors.Add(ConsoleColor.Cyan);
            parts.Add(new byte[,] { { 1, 1, 1, 1 } }); // I
            partColors.Add(ConsoleColor.Blue);
            parts.Add(new byte[,] { { 1, 0, 0 }, { 1, 1, 1 } }); // J
            partColors.Add(ConsoleColor.DarkYellow);
            parts.Add(new byte[,] { { 1, 1, 1 }, { 1, 0, 0 } }); // L
            partColors.Add(ConsoleColor.Yellow);
            parts.Add(new byte[,] { { 1, 1 }, { 1, 1 } }); // O
            partColors.Add(ConsoleColor.Green);
            parts.Add(new byte[,] { { 0, 1, 1 }, { 1, 1, 0 } }); // S
            partColors.Add(ConsoleColor.DarkMagenta);
            parts.Add(new byte[,] { { 1, 1, 1 }, { 0, 1, 0 } }); // T
            partColors.Add(ConsoleColor.Red);
            parts.Add(new byte[,] { { 1, 1, 0 }, { 0, 1, 1 } }); // Z

            Console.Clear();
            for(int row = 0; row < parts.Count; row++)
            {
                byte[,] part = parts[row];
                print(part, 1, 1 + 5 * row, partColors[row]);
                for (int col = 0; col < 4; col++)
                {
                    part = rotateCW(part);
                    print(part, 6 + 5 * col, 1 + 5 * row, partColors[row]);
                }
            }
            Console.SetCursorPosition(0, 1 + 5 *parts.Count);
        }

        public static byte[,] rotateCW(byte[,] part)
        {
            int width = part.GetLength(0);
            int height = part.GetLength(1);
            byte[,] partCopy = new byte[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    partCopy[y, x] = part[width - 1 - x, y];
                }
            }

            return partCopy;
        }

        public static byte[,] rotateCCW(byte[,] part)
        {
            int width = part.GetLength(0);
            int height = part.GetLength(1);
            byte[,] partCopy = new byte[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    partCopy[y, x] = part[x, height - 1 - y];
                }
            }

            return partCopy;
        }

        public static void print(byte[,] part, int xStart, int yStart, ConsoleColor c)
        {
            bool restart;
            Console.BackgroundColor = c;
            for(int y = 0; y < part.GetLength(0); y++)
            {
                restart = true;
                for(int x = 0; x < part.GetLength(1); x++)
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
