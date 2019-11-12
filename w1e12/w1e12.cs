using System;
using System.Collections.Generic;

namespace w1e12
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<byte[,]> parts = new List<byte[,]>();
            // @see https://pradeep1210.files.wordpress.com/2010/02/tetrisshapes5b35d.jpg
            parts.Add(new byte[,] { { 1, 1, 1, 1 } }); // I
            parts.Add(new byte[,] { { 1, 0, 0 }, { 1, 1, 1 } }); // J
            parts.Add(new byte[,] { { 1, 1, 1 }, { 1, 0, 0 } }); // L
            parts.Add(new byte[,] { { 1, 1 }, { 1, 1 } }); // O
            parts.Add(new byte[,] { { 0, 1, 1 }, { 1, 1, 0 } }); // S
            parts.Add(new byte[,] { { 1, 1, 1 }, { 0, 1, 0 } }); // T
            parts.Add(new byte[,] { { 1, 1, 0 }, { 0, 1, 1 } }); // Z
            
            foreach(byte[,] part in parts)
            {
                print(part);
                byte[,] view = part;
                for (int r = 0; r < 4; r++)
                {
                    view = rotateCW(view);
                    //view = rotateCCW(view);
                    Console.WriteLine();
                    print(view);
                }
                Console.WriteLine();
                Console.WriteLine("--");
                Console.WriteLine();
            }
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

        public static void print(byte[,] part)
        {
            for(int y = 0; y < part.GetLength(0); y++)
            {
                char[] row = new char[part.GetLength(1)];
                for(int x = 0; x < part.GetLength(1); x++)
                {
                    row[x] = part[y, x] > 0 ? 'X' : '.';
                }

                Console.WriteLine(row);
            }
        }
    }
}
