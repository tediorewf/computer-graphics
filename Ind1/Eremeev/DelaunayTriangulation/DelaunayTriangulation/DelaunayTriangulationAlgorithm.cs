using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
public static class DelaunayTriangulationAlgorithm
{
    public static List<Triangle2D> Triangulate(List<Point2D> points)
    {
        var triangles = new List<Triangle2D>();
        var initialEdge = FindInitialJarvisEdge(points);

        var deads = new HashSet<Edge2D>();

        return triangles;
    }

    private static Edge2D FindInitialJarvisEdge(List<Point2D> points)
    {
        int minDotProduct = int.MaxValue;
        var initialPoint = FindInitialJarvisPoint(points);
        var nextPoint = points.FirstOrDefault();

        foreach (var currentPoint in points)
        {
            if (currentPoint == initialPoint)
            {
                continue;
            }

            int currentDotProduct = initialPoint.ToVector() * currentPoint.ToVector();
            if (currentDotProduct < minDotProduct)
            {
                minDotProduct = currentDotProduct;
                nextPoint = currentPoint;
            }
        }

        return new Edge2D(initialPoint, nextPoint);
    }

    private static Point2D FindInitialJarvisPoint(List<Point2D> points)
    {
        var initialPoint = points.FirstOrDefault();
        foreach (var currentPoint in points)
        {
            if (currentPoint.X < initialPoint.X
                    || currentPoint.X == initialPoint.X & currentPoint.Y < initialPoint.Y)
            {
                initialPoint = currentPoint;
            }
        }
        return initialPoint;
    }
}
}
