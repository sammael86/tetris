using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Tetris
{
    class Square : Figure
    {
        public Square(int x, int y, char c)
        {
            Points[0] = new Point(x, y, c);
            Points[1] = new Point(x + 1, y, c);
            Points[2] = new Point(x, y + 1, c);
            Points[3] = new Point(x + 1, y + 1, c);
            Draw();
        }

        public override void Rotate()
        {
            
        }
    }
}
