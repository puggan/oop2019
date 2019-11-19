using System;
using w2e01;

namespace w2e02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // create two boxes
            Box box1 = new Box();
            Box box2 = new Box();

            // set some values on them
            box1.x = 3;
            box1.y = 2;
            box1.width = 7;
            box1.height = 4;
            box1.color = ConsoleColor.Red;

            box2.x = 17;
            box2.y = 4;
            box2.width = 13;
            box2.height = 8;
            box2.color = ConsoleColor.Blue;

            // draw both on the screen
            Console.Clear();
            box1.Draw();
            box2.Draw();
            Console.WriteLine();
        }
    }
}
