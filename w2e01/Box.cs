using System;

namespace w2e01
{
    internal class Box
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public ConsoleColor color;
            
        public Box(int w, int h, int left, int top, ConsoleColor c)
        {
            this.width = w;
            this.height = h;
            this.x = left;
            this.y = top;
            this.color = c;
        }
        public Box(int w, int h, int left, int top) : this(w, h, left, top, ConsoleColor.White) {}
        public Box(int w, int h, ConsoleColor c) : this(w, h, 0, 0, c) {}
        public Box(int w, int h) : this(w, h, 0, 0, ConsoleColor.White) {}
        public Box(ConsoleColor c) : this(1, 1, 0, 0, c) {}
        public Box() : this(1, 1, 0, 0, ConsoleColor.White) {}

        public void Draw()
        {
            Box.Draw(this.width, this.height, this.x, this.y, this.color);
        }
        public void Draw(ConsoleColor c)
        {
            Box.Draw(this.width, this.height, this.x, this.y, c);
        }
        public void Draw(int left, int top)
        {
            Box.Draw(this.width, this.height, left, top, this.color);
        }
        public void Draw(int left, int top, ConsoleColor c)
        {
            Box.Draw(this.width, this.height, left, top, c);
        }
        public void Draw(int w, int h, int left, int top)
        {
            Box.Draw(w, h, left, top, this.color);
        }

        public static void Draw(int w, int h, int left, int top, ConsoleColor c)
        {
            for(int y = top; y < top + h; y++)
            {
                Console.SetCursorPosition(left, y);
                Console.BackgroundColor = c;
                Console.Write(new String(' ', w));
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }
    }
}
