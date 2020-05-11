using System;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Figure[] f = new Figure[2];
            f[0] = new Square(2, 5, '*');
            f[1] = new Stick(6, 6, '*');

            foreach (Figure figure in f)
            {
                figure.Draw();
            }

            Thread.Sleep(3000);

            foreach (Figure figure in f)
            {
                figure.Hide();
                figure.Move(Direction.RIGHT);
                figure.Draw();
            }


            Thread.Sleep(3000);

            foreach (Figure figure in f)
            {
                figure.Hide();
                figure.Move(Direction.DOWN);
                figure.Draw();
            }

            Thread.Sleep(3000);

            foreach (Figure figure in f)
            {
                figure.Hide();
                figure.Move(Direction.LEFT);
                figure.Draw();
            }


            Console.ReadLine();
        }
    }
}
