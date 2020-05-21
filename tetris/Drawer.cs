using Microsoft.VisualBasic;
using System;
using System.Reflection.Metadata;

namespace Tetris
{
    internal static class Drawer
    {
        public const char DEFAULT_SYMBOL = '*';

        public static void DrawPoint(int x, int y, char c = DEFAULT_SYMBOL)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        public static void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}