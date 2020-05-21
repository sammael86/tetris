using System;
using System.Collections.Generic;
using System.Text;

namespace Tetris
{
    static class Field
    {
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                Console.SetWindowSize(value, Field.Height);
                Console.SetBufferSize(value, Field.Height);
            }
        }

        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                Console.SetWindowSize(Field.Width, value);
                Console.SetBufferSize(Field.Width, value);
            }
        }

        private static int _width = 40;
        private static int _height = 30;
    }
}
