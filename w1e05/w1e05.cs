﻿using System;

namespace w1e05
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const int MIN = 0;
            const int MAX = 100;
            int points = 0;
            int min = MIN;
            int max = MAX;
            int goal = (new Random()).Next(MIN, MAX + 1);
            int guess = MAX + 1;
            Console.WriteLine($"The hidden number is between {min} and {max}.");
            while (guess != goal)
            {
                points++;
                guess = takeGuess(min, max);
                if (guess < goal)
                {
                    Console.WriteLine($"The hidden number is greater then {guess}.");
                    min = guess + 1;
                } 
                else if (guess > goal)
                {
                    Console.WriteLine($"The hidden number is lesser then {guess}.");
                    max = guess - 1;
                }
            }

            Console.WriteLine($"Good jobb, you solved it in {points} tries.");
        }

        private static int takeGuess(int min, int max)
        {
            while (true)
            {
                int number = ReadInt("Guess a number");
                if (number < min)
                {
                    Console.Error.WriteLine($"You already know the number is greater then {min - 1}");
                    continue;
                }

                if (number > max)
                {
                    Console.Error.WriteLine($"You already know the number is lesser then {max + 1}");
                    continue;
                }

                return number;
            }
        }

        private static int ReadInt(string question)
        {
            while (true)
            {
                Console.Write(question);
                Console.WriteLine(": ");
                try
                {
                    return Int32.Parse(Console.ReadLine() ?? throw new FormatException());
                }
                catch (FormatException)
                {
                    Console.Error.WriteLine("That's not a number, try again");
                }
            }
        }
    }
}
