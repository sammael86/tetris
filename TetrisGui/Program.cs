using System;
using System.Threading;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new object();


        static Figure currentFigure;
        static FigureGenerator generator;

        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();

            SetTimer();

            generator = new FigureGenerator(Field.Width / 2, 0);
            currentFigure = generator.GetNewFigure();

            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;
        }

        private static void GraphicsWindow_KeyDown()
        {
            Monitor.Enter(_lockObject);
            var result = HandleKey(currentFigure, GraphicsWindow.LastKey);

            if (GraphicsWindow.LastKey == "Down")
                ProcessResult(result, ref currentFigure);

            Monitor.Exit(_lockObject);
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    DrawerProvider.Drawer.WriteGameOver();
                    timer.Elapsed -= Timer_Elapsed;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }
            }
            else
                return false;
        }

        private static Result HandleKey(Figure fig, string key)
        {
            switch (key)
            {
                case "Left":
                    return fig.TryMove(Direction.LEFT);
                case "Right":
                    return fig.TryMove(Direction.RIGHT);
                case "Down":
                    return fig.TryMove(Direction.DOWN);
                case "Space":
                    return fig.TryRotate();
            }
            return Result.SUCCESS;
        }

        private static void Test()
        {
            DrawerProvider.Drawer.DrawPoint(5, 6);
        }
    }
}
