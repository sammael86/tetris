using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    public class Point
    {
        public int x;
        public int y;
        public char c;

        internal void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        internal void Move(Direction direction)
        {
            _ = (direction switch
            {
                Direction.DOWN => y++,
                Direction.LEFT => x--,
                Direction.RIGHT => x++,
                _ => throw new NotImplementedException()
            });
        }

        internal void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public Point(int a, int b, char sym)
        {
            x = a;
            y = b;
            c = sym;
        }

        public Point() { }
    }
}
