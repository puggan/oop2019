using System;
using System.Collections.Generic;

namespace w1e13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            Bag<TetrisBlock> bag = new Bag<TetrisBlock>(
                new List<TetrisBlock> {
                    new TetrisBlock(new byte[,] { { 1, 1, 1, 1 } }, ConsoleColor.Cyan),
                    new TetrisBlock(new byte[,] { { 1, 0, 0 }, { 1, 1, 1 } }, ConsoleColor.Blue),
                    new TetrisBlock(new byte[,] { { 1, 1, 1 }, { 1, 0, 0 } }, ConsoleColor.DarkYellow),
                    new TetrisBlock(new byte[,] { { 1, 1 }, { 1, 1 } }, ConsoleColor.Yellow),
                    new TetrisBlock(new byte[,] { { 0, 1, 1 }, { 1, 1, 0 } }, ConsoleColor.Green),
                    new TetrisBlock(new byte[,] { { 1, 1, 1 }, { 0, 1, 0 } }, ConsoleColor.DarkMagenta),
                    new TetrisBlock(new byte[,] { { 1, 1, 0 }, { 0, 1, 1 } }, ConsoleColor.Red),
                }
            );
            for (int r = 0; r < 10; r++)
            {
                for (int c = 0; c < 14; c++)
                {
                    bag.Next().Print(1 + c * 5, 1 + r * 5);
                }
            }
            Console.WriteLine();
        }
    }
}
