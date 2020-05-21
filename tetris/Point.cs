using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        internal void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);
        }

        internal void Move(Direction direction)
        {
            _ = (direction switch
            {
                Direction.DOWN => Y++,
                Direction.LEFT => X--,
                Direction.RIGHT => X++,
                Direction.UP => Y--,
                _ => throw new NotImplementedException()
            });
        }

        internal void Hide()
        {
            DrawerProvider.Drawer.HidePoint(X, Y);
        }

        public Point(int a, int b)
        {
            X = a;
            Y = b;
        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
    }
}
