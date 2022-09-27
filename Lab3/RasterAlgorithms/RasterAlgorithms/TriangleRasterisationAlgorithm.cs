using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RasterAlgorithms
{
    using FastBitmap;

    public class TriangleRasterisationException : RasterAlgorithmException
    {
        public TriangleRasterisationException(string message) : base(message)
        {
        }
    }

    public class NearestOrdinateComparer : IComparer<ColoredPoint>
    {
        public int Compare(ColoredPoint lhs, ColoredPoint rhs)
        {
            return lhs.Y.CompareTo(rhs.Y);
        }
    }
    public class PointsPair
    {
        public PointsPair(ColoredPoint left, ColoredPoint right)
        {
            Left = left;
            Right = right;
        }

        public ColoredPoint Left { get; set; }
        public ColoredPoint Right { get; set; }
    }

    public static class TriangleRasterisationAlgorithm
    {
        public static void RasteriseTriangle(this Bitmap drawingSurface, ColoredPoint v1, ColoredPoint v2, ColoredPoint v3)
        {
            EnsureVerticesAreDifferent(v1, v2, v3);

            var vertices = new ColoredPoint[] { v1, v2, v3 };
            Array.Sort(vertices, new NearestOrdinateComparer());

            using (var fastDrawingsurface = new FastBitmap(drawingSurface))
            {
                var pointsPairs = MakeBresenhamMovement(vertices[0], vertices[1])
                    .Concat(MakeBresenhamMovement(vertices[1], vertices[2]))
                    .Zip(MakeBresenhamMovement(vertices[0], vertices[2]), (pLeft, pRight) => new PointsPair(pLeft, pRight));
                foreach (var pointsPair in pointsPairs)
                {
                    var pLeft = pointsPair.Left;
                    var pRight = pointsPair.Right;
                    int coordinateDeltaX = Math.Abs(pLeft.X - pRight.X);
                    fastDrawingsurface[pLeft.X, pLeft.Y] = pLeft.Color;
                    for (int x = pLeft.X + 1; x < pRight.X; x += 1)
                    {
                        var currentCOlor = ApplyLinearInterpolation(pLeft.Color, pRight.Color, x, pRight.X, coordinateDeltaX);
                        fastDrawingsurface[x, pLeft.Y] = currentCOlor;
                    }
                    fastDrawingsurface[pRight.X, pRight.Y] = pRight.Color;
                }
            }
        }

        private static void EnsureVerticesAreDifferent(ColoredPoint v1, ColoredPoint v2, ColoredPoint v3)
        {
            if (v1.X == v2.X && v1.Y == v2.Y || v2.X == v3.X && v2.Y == v3.Y)
            {
                throw new TriangleRasterisationException("Есть вершины с совпадающими координататми");
            }

            if (v1.Color == v2.Color || v2.Color == v3.Color)
            {
                throw new TriangleRasterisationException("Есть вершины с совпадающими цветами");
            }
        }

        private static IEnumerable<ColoredPoint> MakeBresenhamMovement(ColoredPoint v1, ColoredPoint v2)
        {
            int x1 = v1.X, x2 = v2.X;
            int y1 = v1.Y, y2 = v2.Y;
            Color c1 = v1.Color, c2 = v2.Color;

            int diffX = x2 - x1;
            int diffY = y2 - y1;

            int growthDirectionX = diffX > 0 ? 1 : -1;
            int growthDirectionY = diffY > 0 ? 1 : -1;

            int deltaX = Math.Abs(diffX);
            int deltaY = Math.Abs(diffY);

            int xCurrent = x1;
            int yCurrent = y1;

            // Определяем gradient <= 1 или gradient > 1
            int axisGrowthDirection = deltaX > deltaY ? 1 : -1;

            int decision = 2 * axisGrowthDirection * (deltaY - deltaX);

            int refereeY = Math.Max(axisGrowthDirection, 0);
            int refereeX = Math.Min(axisGrowthDirection, 0);

            int interpolationEndCoordinate = x2 * refereeY - y2 * refereeX;
            int interpolationCoordinateDelta = deltaX * refereeY - deltaY * refereeX;

            while (xCurrent != x2 || yCurrent != y2)
            {
                var colorCurrent = ApplyLinearInterpolation(c1, c2, xCurrent * refereeY - yCurrent * refereeX, interpolationEndCoordinate, interpolationCoordinateDelta);
                var nextVertex = new ColoredPoint(xCurrent, yCurrent, colorCurrent);

                xCurrent += growthDirectionX * refereeY;  // gradient <= 1
                yCurrent -= growthDirectionY * refereeX;  // gradient > 1

                if (decision < 0)
                {
                    decision += 2 * (deltaY * refereeY - deltaX * refereeX);
                }
                else
                {
                    yCurrent += growthDirectionY * refereeY;  // gradient <= 1
                    xCurrent -= growthDirectionX * refereeX;  // gradient > 1
                    decision += 2 * axisGrowthDirection * (deltaY - deltaX);
                }

                yield return nextVertex;
            }
        }

        private static Color ApplyLinearInterpolation(Color beginColor, Color endColor, int currentCoordinate, int endCoordinate, int coordinateDelta)
        {
            int coordinateDeltaCurrent = Math.Abs(currentCoordinate - endCoordinate);
            int red = InterpolateColorComponent(beginColor.R, endColor.R, coordinateDelta, coordinateDeltaCurrent);
            int green = InterpolateColorComponent(beginColor.G, endColor.G, coordinateDelta, coordinateDeltaCurrent);
            int blue = InterpolateColorComponent(beginColor.B, endColor.B, coordinateDelta, coordinateDeltaCurrent);
            var interpolatedColor = Color.FromArgb(red, green, blue);
            return interpolatedColor;
        }

        private static int InterpolateColorComponent(int colorComponentBegin, int colorComponentEnd, int coordinateDelta, int coordinateDeltaCurrent)
        {
            return colorComponentBegin * coordinateDeltaCurrent / coordinateDelta + colorComponentEnd * (coordinateDelta - coordinateDeltaCurrent) / coordinateDelta;
        }
    }
}
