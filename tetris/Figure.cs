using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    abstract class Figure
    {
        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point point in points)
                point.Draw();
        }

        public void Move(Direction direction)
        {
            Hide();
            foreach (Point p in points)
                p.Move(direction);
            Draw();
        }

        public void Hide()
        {
            foreach (Point p in points)
                p.Hide();
        }

        public abstract void Rotate();
    }
}
