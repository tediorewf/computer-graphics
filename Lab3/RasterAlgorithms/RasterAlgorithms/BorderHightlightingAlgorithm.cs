using System.Collections.Generic;
using System.Drawing;

namespace RasterAlgorithms
{
    using FastBitmap;

    public class BorderHightlightingException : RasterAlgorithmException
    {
        public BorderHightlightingException(string message) : base(message)
        {
        }
    }

    public static class BorderHightlightingAlgorithm
    {
        public static void HightlightBorder(this Bitmap imageSurface, Point chosenPoint, Color chosenBorderColor)
        {
            using (var fastImageSurface = new FastBitmap(imageSurface))
                fastImageSurface.HightlightBorder(chosenPoint, chosenBorderColor);
        }

        public static void HightlightBorder(this FastBitmap fastImageSurface, Point chosenPoint, Color chosenBorderColor)
        {
            var startingPoint = DetectStartingPoint(fastImageSurface, chosenPoint);
            var currentPoint = startingPoint;
            var nextPoint = currentPoint;

            var pixels = new List<Point>() { startingPoint };

            var borderColor = fastImageSurface[startingPoint.X, startingPoint.Y];

            var currentDirection = BorderDirection.down;
            BorderDirection nextDirection;
            BorderDirection movingDirection;

            do
            {
                movingDirection = currentDirection.Move90DegreesClockwise();
                var destination = movingDirection;
                do
                {
                    nextPoint = movingDirection.MovePoint(currentPoint);
                    nextDirection = movingDirection;

                    if (nextPoint == startingPoint)
                    {
                        break;
                    }

                    if (fastImageSurface[nextPoint.X, nextPoint.Y] == borderColor)
                    {
                        pixels.Add(nextPoint);
                        currentPoint = nextPoint;
                        currentDirection = nextDirection;
                        break;
                    }

                    movingDirection = movingDirection.MoveNext();
                } while (movingDirection != destination);
            } while (nextPoint != startingPoint);

            pixels.ForEach(p => fastImageSurface[p.X, p.Y] = chosenBorderColor);
        }

        private static Point DetectStartingPoint(FastBitmap fastImageSurface, Point chosenPoint)
        {
            int x = chosenPoint.X, y = chosenPoint.Y;

            var backgroundColor = fastImageSurface[x, y];
            var currentColor = backgroundColor;

            var rgbBackgroundColor = backgroundColor.ToArgb();

            while (x < fastImageSurface.Width - 2 && currentColor.ToArgb() == rgbBackgroundColor)
            {
                x += 1;
                currentColor = fastImageSurface[x, y];
            }

            return new Point(x, y);
        }
    }
}
