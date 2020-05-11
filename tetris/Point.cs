using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    class Point
    {
        public int x;
        public int y;
        public char c;

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}
