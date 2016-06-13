using System;

namespace RecipeCalculator.Helpers
{
    public static class FancyConsole
    {
        public static void Write(string text, int x, bool endLine = false)
        {
            Console.CursorLeft = x;

            if (!endLine)
            {
                Console.Write(text);
            }
            else
            {
                Console.WriteLine(text);
            }
        }
    }
}
