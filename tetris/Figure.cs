using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Tetris
{
    abstract class Figure
    {
        const int LENGTH = 4;
        public Point[] Points = new Point[LENGTH];

        public void Draw()
        {
            foreach (Point point in Points)
                point.Draw();
        }

        public void Hide()
        {
            foreach (Point point in Points)
                point.Hide();
        }

        public abstract void Rotate();

        internal Result TryMove(Direction dir)
        {
            Hide();
            Move(dir);

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(dir));

            Draw();
            return result;
        }

        private Direction Reverse(Direction dir)
        {
            return dir switch
            {
                Direction.DOWN => Direction.UP,
                Direction.LEFT => Direction.RIGHT,
                Direction.RIGHT => Direction.LEFT,
                Direction.UP => Direction.DOWN
            };
        }

        private Result VerifyPosition()
        {
            foreach (var p in Points)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;

                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;

                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
        }
        private void Move(Direction dir)
        {
            foreach (var p in Points)
            {
                p.Move(dir);
            }
        }
        internal Result TryRotate()
        {
            Hide();
            Rotate();

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Rotate();

            Draw();

            return result;
        }
        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }
    }
}
