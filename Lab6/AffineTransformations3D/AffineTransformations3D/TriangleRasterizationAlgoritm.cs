using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AffineTransformations3D
{
    using static Utils;

    public class NearestOrdinateComparer : IComparer<DeptherizedPoint>
    {
        public int Compare(DeptherizedPoint lhs, DeptherizedPoint rhs) 
            => lhs.Y.CompareTo(rhs.Y);
    }

    public static class TriangleRasterizationAlgoritm
    {
        public static IEnumerable<DeptherizedPoint> RasterizeTriangle(DeptherizedPoint v1, DeptherizedPoint v2, DeptherizedPoint v3)
        {
            var vertices = new DeptherizedPoint[] { v1, v2, v3 };
            Array.Sort(vertices, new NearestOrdinateComparer());

            int x1 = vertices[0].X;
            int y1 = vertices[0].Y;
            double depth1 = vertices[0].Depth;

            int x2 = vertices[1].X;
            int y2 = vertices[1].Y;
            double depth2 = vertices[1].Depth;

            int x3 = vertices[2].X;
            int y3 = vertices[2].Y;
            double depth3 = vertices[2].Depth;

            int y = vertices[0].Y;

            bool leftIsOnRight = x2 > x3;

            if (leftIsOnRight)
            {
                while (y != y2)
                {
                    int xa = CalculateAbscissa(x1, x3, y1, y3, y);
                    int xb = CalculateAbscissa(x1, x2, y1, y2, y);
                    double za = CalculateDepth(depth1, depth3, y1, y3, y);
                    double zb = CalculateDepth(depth1, depth2, y1, y2, y);
                    for (int x = xa; x <= xb; x += 1)
                    {
                        double z = CalculateDepth(za, zb, xa, xb, x);
                        yield return new DeptherizedPoint(x, y, z);
                    }
                    y += 1;
                }

                while (y != y3)
                {
                    int xa = CalculateAbscissa(x1, x3, y1, y3, y);
                    int xb = CalculateAbscissa(x2, x3, y2, y3, y);
                    double za = CalculateDepth(depth1, depth3, y1, y3, y);
                    double zb = CalculateDepth(depth2, depth3, y2, y3, y);
                    for (int x = xa; x <= xb; x += 1)
                    {
                        double z = CalculateDepth(za, zb, xa, xb, x);
                        yield return new DeptherizedPoint(x, y, z);
                    }
                    y += 1;
                }
            }
            else
            {
                while (y != y2)
                {
                    int xa = CalculateAbscissa(x1, x2, y1, y2, y);
                    int xb = CalculateAbscissa(x1, x3, y1, y3, y);
                    double za = CalculateDepth(depth1, depth2, y1, y2, y);
                    double zb = CalculateDepth(depth1, depth3, y1, y3, y);
                    for (int x = xa; x <= xb; x += 1)
                    {
                        double z = CalculateDepth(za, zb, xa, xb, x);
                        yield return new DeptherizedPoint(x, y, z);
                    }
                    y += 1;
                }

                while (y != y3)
                {
                    int xa = CalculateAbscissa(x2, x3, y2, y3, y);
                    int xb = CalculateAbscissa(x1, x3, y1, y3, y);
                    double za = CalculateDepth(depth2, depth3, y2, y3, y);
                    double zb = CalculateDepth(depth1, depth3, y1, y3, y);
                    for (int x = xa; x <= xb; x += 1)
                    {
                        double z = CalculateDepth(za, zb, xa, xb, x);
                        yield return new DeptherizedPoint(x, y, z);
                    }
                    y += 1;
                }
            }

            yield return vertices[2];
        }

        private static int CalculateAbscissa(int x1, int x2, int y1, int y2, int y)
        {
            int x = x1 + (x2 - x1) * (y - y1) / (y2 - y1);
            return x;
        }

        private static double CalculateDepth(double depth1, double depth2, int y1, int y2, int y)
        {
            double depth = depth1 + (depth2 - depth1) * (y - y1) / (y2 - y1);
            return depth;
        }
    }
}
