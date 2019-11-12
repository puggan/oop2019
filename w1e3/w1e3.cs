using System;
using System.Text.RegularExpressions;

namespace w1e3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            foreach(string arg in args)
            {
                if (IsPalindrome(arg))
                {
                    Console.WriteLine($"✔ {arg}");
                }
                else
                {
                    Console.WriteLine($"❌ {arg}");
                }
            }
        }

        private static bool IsPalindrome(String text)
        {
            string noSpaceText = Regex.Replace(text.ToLower(), @"\s+", "");
            for (int position = 0; position * 2 < noSpaceText.Length; position++)
            {
                if (noSpaceText[position] != noSpaceText[noSpaceText.Length - 1 - position])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
