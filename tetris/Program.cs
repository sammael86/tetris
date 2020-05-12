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
            Figure s;

            while (true)
            {
                FigureFall(out s, generator);
                s.Draw();
            }
        }

        static void FigureFall(out Figure figure, FigureGenerator generator)
        {
            figure = generator.GetNewFigure();
            figure.Draw();

            for (int i = 0; i < 15; i++)
            {
                figure.Hide();
                figure.Move(Direction.DOWN);
                figure.Draw();
                Thread.Sleep(200);
            }
        }
    }
}
