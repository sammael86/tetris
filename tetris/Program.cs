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

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s = generator.GetNewFigure();

            s.Draw();

            Figure[] f = new Figure[2];
            f[0] = new Square(2, 5, '*');
            f[1] = new Stick(6, 6, '*');

            foreach (Figure figure in f)
            {
                figure.Draw();
            }

            Thread.Sleep(200);

            foreach (Figure figure in f)
            {
                figure.Hide();
                figure.Rotate();
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
