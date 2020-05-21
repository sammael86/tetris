using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace tetris
{
    class Stick : Figure
    {
        public Stick(int x, int y, char c)
        {
            points[0] = new Point(x, y, c);
            points[1] = new Point(x, y + 1, c);
            points[2] = new Point(x, y + 2, c);
            points[3] = new Point(x, y + 3, c);
            Draw();
        }

        public override void Rotate(Point[] clone)
        {
            if (clone[0].x == clone[1].x)
            {
                RotateHorizontal(clone);
            }
            else
            {
                RotateVertical(clone);
            }
        }

        private void RotateVertical(Point[] clone)
        {
            for (int i = 0; i < clone.Length; i++)
            {
                clone[i].x = clone[0].x;
                clone[i].y = clone[0].y + i;
            }
        }

        private void RotateHorizontal(Point[] clone)
        {
            for (int i = 0; i < clone.Length; i++)
            {
                clone[i].y = clone[0].y;
                clone[i].x = clone[0].x + i;
            }
        }
    }
}
