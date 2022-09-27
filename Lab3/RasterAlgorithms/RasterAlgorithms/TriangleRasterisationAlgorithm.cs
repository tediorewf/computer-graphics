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

    public static class TriangleRasterisationAlgorithm
    {
        public static void RasteriseTriangle(this Bitmap drawingSurface, ColoredPoint v1, ColoredPoint v2, ColoredPoint v3)
        {
            using (var fastDrawingsurface = new FastBitmap(drawingSurface))
                fastDrawingsurface.RasteriseTriangle(v1, v2, v3);
        }

        public static void RasteriseTriangle(this FastBitmap fastDrawingSurface, ColoredPoint v1, ColoredPoint v2, ColoredPoint v3)
        {
            EnsureVerticesAreDifferent(v1, v2, v3);

            var vertices = new ColoredPoint[] { v1, v2, v3 };
            Array.Sort(vertices, new NearestOrdinateComparer());

            for (int i = 0; i < vertices.Count(); i++)
            {
                fastDrawingSurface.DrawBresenhamLine(new Point(vertices[i].X, vertices[i].Y), 
                    new Point(vertices[(i + 1) % vertices.Count()].X, vertices[(i + 1) % vertices.Count()].Y), Color.Black);
            }
        }

        private static void EnsureVerticesAreDifferent(ColoredPoint v1, ColoredPoint v2, ColoredPoint v3)
        {
            if (v1.X == v2.X && v1.Y == v2.Y || v2.X == v3.X && v2.Y == v3.Y)
            {
                throw new TriangleRasterisationException("Есть вершины с совпадающими координататми");
            }

            /*if (v1.Color == v2.Color || v2.Color == v3.Color)
            {
                throw new TriangleRasterisationException("Есть вершины с совпадающими цветами");
            }*/
        }

        private static void MakeBresenhamMovement()
        {

        }
    }
}
