using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
