using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RasterAlgorithms
{
    using FastBitmap;
    using static Helpers;

    public static class BresenhamAlgoritm
    {
        public static void DrawBresenhamLine(this Bitmap source, ColoredPoint p1, ColoredPoint p2)
        {
            using (var fastSource = new FastBitmap(source))
                fastSource.DrawBresenhamLine(p1, p2);
        }

        public static void DrawBresenhamLine(this FastBitmap fastSource, ColoredPoint p1, ColoredPoint p2)
        {
            fastSource.DrawBresenhamLine(p1.X, p1.Y, p1.Color, p2.X, p2.Y, p2.Color);
        }

        public static void DrawBresenhamLine(this FastBitmap source, int x1, int y1, Color c1, int x2, int y2, Color c2)
        {
            int deltaX = x2 - x1;
            int deltaY = y2 - y1;

            double m = deltaX == 0 ? deltaY : (double)deltaY / deltaX;
            SwapDrawingAxisIfNeeded(m, out bool swappedDrawingAxis, out int growthDirection);
            if (!swappedDrawingAxis)
            {
                SwapPointsIfNeeded(ref x1, ref y1, ref x2, ref y2);
            }
            else
            {
                SwapPointsIfNeeded(ref y1, ref x1, ref y2, ref x2);
            }

            deltaX = Math.Abs(deltaX);
            deltaY = Math.Abs(deltaY);

            int decision;
            if (!swappedDrawingAxis)
            {
                decision = 2 * deltaY - deltaX;
            }
            else
            {
                decision = 2 * deltaX - deltaY;
            }

            int currentX = x1;
            int currentY = y1;

            if (!swappedDrawingAxis)
            {
                while (currentX <= x2)
                {
                    source[currentX, currentY] = c1;
                    MoveBresenhamPixel(ref currentX, ref currentY, ref decision, deltaX, deltaY, growthDirection);
                }
            }
            else
            {
                while (currentY <= y2)
                {
                    source[currentX, currentY] = c1;
                    MoveBresenhamPixel(ref currentY, ref currentX, ref decision, deltaY, deltaX, growthDirection);
                }
            }
        }

        private static void SwapDrawingAxisIfNeeded(double m, out bool swappedDrawingAxis, out int growthDirection)
        {
            swappedDrawingAxis = Math.Abs(m) >= 1;
            if (swappedDrawingAxis)
            {
                growthDirection = m >= 1 ? 1 : -1;
            }
            else
            {
                growthDirection = 0 < m && m < 1 ? 1 : -1;
            }
        }

        private static void SwapPointsIfNeeded(ref int x1, ref int y1, ref int x2, ref int y2)
        {
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }
        }

        private static void MoveBresenhamPixel(ref int currentX, ref int currentY, ref int decision, int deltaX, int deltaY, int growthDirection)
        {
            currentX += 1;

            if (decision < 0)
            {
                decision += 2 * deltaY;
            }
            else
            {
                currentY += growthDirection;
                decision += 2 * (deltaY - deltaX);
            }
        }
    }
}
