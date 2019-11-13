using System;
using System.Threading;

namespace w1e07
{
    internal class Program
    {
        private Random random;

        public static void Main(string[] args)
        {
            Program me = new Program();
            while (true)
            {
                me.bar();
                Thread.Sleep(200);
            }
        }

        public Program()
        {
            random = new Random();
        }
        
        public void bar()
        {
            Console.BackgroundColor = (ConsoleColor)(8 + random.Next(8));
            // WriteLine paint the hole line in Bash, but seams to have problems in cmd
            Console.WriteLine();
        }
    }
}
