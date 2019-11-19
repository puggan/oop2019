using System;
using w2e01;

namespace w2e03
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BoxManager<Box> manager = new BoxManager<Box>();

            // add a box to the list
            manager.Add(new Box(20, 10, ConsoleColor.Red));

            // and another one
            manager.Add(new Box(12, 6, ConsoleColor.Blue));

            // tell the manager to center and draw all boxes
			Console.Clear();
            manager.DrawInCenter();            
			Console.SetCursorPosition(0, Console.WindowHeight - 1);
        }
    }
}
