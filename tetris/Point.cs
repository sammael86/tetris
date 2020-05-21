using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        internal void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }

        internal void Move(Direction direction)
        {
            _ = (direction switch
            {
                Direction.DOWN => Y++,
                Direction.LEFT => X--,
                Direction.RIGHT => X++,
                _ => throw new NotImplementedException()
            });
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' ');
        }

        public Point(int a, int b, char sym)
        {
            X = a;
            Y = b;
            C = sym;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
            C = p.C;
        }
    }
}
