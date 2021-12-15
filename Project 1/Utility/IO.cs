using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_1.Utility
{
	public class IO
	{

        public static void Writexy(string s, int x, int y, ConsoleColor maunen, ConsoleColor mauchu)
        {
            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = maunen;
            Console.ForegroundColor = mauchu;
            Console.Write(s);
        }
        public static void Writexy(string s, int x, int y, int len)
        {
            Console.SetCursorPosition(x, y);
            if (s.Length > len)
                Console.Write(s.Substring(0, len));
            else
                Console.Write(s);
        }
        public static void Clear(int x, int y, int length, ConsoleColor maunen)
        {
            ConsoleColor mn = Console.BackgroundColor;
            ConsoleColor mc = Console.ForegroundColor;
            int i = x; int j = y; int d = 0;
            while (d < length)
            {
                if (i == 79) { i = 0; j = j + 1; } else i = i + 1;
                Writexy(" ", i, j, maunen, maunen);
                d++;
            }
            Console.BackgroundColor = mn;
            Console.ForegroundColor = mc;
        }
        public static void Writexy(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

    }
}
