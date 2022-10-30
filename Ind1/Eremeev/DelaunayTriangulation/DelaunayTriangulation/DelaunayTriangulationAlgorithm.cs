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

            var aliveEdges = new SortedSet<Edge2D>();
            aliveEdges.Add(initialEdge);

            while (aliveEdges.Count != 0)
            {
                var currentEdge = aliveEdges.Min();
                aliveEdges.Remove(currentEdge);

                Point2D mostSuitablePoint = null;
                double mostSuitableT = double.MaxValue;

                var edge0 = currentEdge.Rotate();

                foreach (var point in points)
                {
                    if (currentEdge.IsOnRight(point))
                    {
                        var edge1 = new Edge2D(edge0.End, point).Rotate();
                        double t = edge0.ExtractIntersectionParameter(edge1);

                        if (t < mostSuitableT)
                        {
                            mostSuitableT = t;
                            mostSuitablePoint = point;
                        }
                    }
                }

                if (mostSuitablePoint != null)
                {
                    MakeAlive(aliveEdges, mostSuitablePoint, currentEdge.Begin);
                    MakeAlive(aliveEdges, currentEdge.End, mostSuitablePoint);
                    triangles.Add(new Triangle2D(currentEdge.Begin, currentEdge.End, mostSuitablePoint));
                }
            }

            return triangles;
        }

        private static void MakeAlive(SortedSet<Edge2D> alives, Point2D p1, Point2D p2)
        {
            var edge = new Edge2D(p1, p2);
            if (alives.Contains(edge))
            {
                alives.Remove(edge);
            }
            else
            {
                edge.Flip();
                alives.Add(edge);
            }
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
                if (currentPoint < initialPoint)
                {
                    initialPoint = currentPoint;
                }
            }
            return initialPoint;
        }
    }
}
