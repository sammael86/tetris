﻿using System;
using System.Collections.Generic;
using System.Text;

namespace tetris
{
    abstract class Figure
    {
        const int LENGTH = 4;
        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point point in points)
                point.Draw();
        }

        public void Hide()
        {
            foreach (Point p in points)
                p.Hide();
        }

        public abstract void Rotate(Point[] clone);

        internal void TryMove(Direction dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone))
                points = clone;
            Draw();
        }

        private bool VerifyPosition(Point[] pList)
        {
            foreach (var p in pList)
            {
                if (p.x < 0 || p.y < 0 || p.x >= 40 || p.y >= 30)
                    return false;
            }
            return true;
        }

        private void Move(Point[] pList, Direction dir)
        {
            foreach (var p in pList)
            {
                p.Move(dir);
            }
        }

        internal void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone))
                points = clone;
            Draw();
        }

        private Point[] Clone()
        {
            var newPoints = new Point[LENGTH];
            for (int i = 0; i < LENGTH; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }
    }
}
