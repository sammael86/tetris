using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    class Figure
    {
        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point point in points)
            {
                point.Draw();
            }
        }
    }
}
