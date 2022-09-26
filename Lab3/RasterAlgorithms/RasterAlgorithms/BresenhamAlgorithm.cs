using System;
using System.Drawing;

namespace RasterAlgorithms
{
    using FastBitmap;
    using static Helpers;

    public static class BresenhamAlgoritm
    {
        public static void DrawBresenhamLine(this Bitmap drawingSurface, Point p1, Point p2, Color color)
        {
            using (var fastSource = new FastBitmap(drawingSurface))
                fastSource.DrawBresenhamLine(p1, p2, color);
        }

        public static void DrawBresenhamLine(this FastBitmap fastDrawingSurface, Point p1, Point p2, Color color)
        {
            fastDrawingSurface.DrawBresenhamLine(p1.X, p1.Y, p2.X, p2.Y, color);
        }

        public static void DrawBresenhamLine(this FastBitmap fastDrawingSurface, int x1, int y1, int x2, int y2, Color color)
        {
            int diffX = x2 - x1;
            int diffY = y2 - y1;

            int growthDirectionX = diffX > 0 ? 1 : -1;
            int growthDirectionY = diffY > 0 ? 1 : -1;

            int deltaX = Math.Abs(diffX);
            int deltaY = Math.Abs(diffY);

            // Определяем gradient <= 1 или gradient > 1
            int axisGrowthDirection = deltaX > deltaY ? 1 : -1;

            int decision = 2 * axisGrowthDirection * (deltaY - deltaX);

            int currentX = x1;
            int currentY = y1;

            int refereeY = Math.Max(axisGrowthDirection, 0);
            int refereeX = Math.Min(axisGrowthDirection, 0);

            while (currentX != x2)
            {
                fastDrawingSurface[currentX, currentY] = color;
                currentX += growthDirectionX * refereeY;  // gradient <= 1
                currentY -= growthDirectionY * refereeX;  // gradient > 1

                if (decision < 0)
                {
                    decision += 2 * (deltaY * refereeY - deltaX * refereeX);
                }
                else
                {
                    currentY += growthDirectionY * refereeY;  // gradient <= 1
                    currentX -= growthDirectionX * refereeX;  // gradient > 1
                    decision += 2 * axisGrowthDirection * (deltaY - deltaX);
                }
            }
        }
    }
}
