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

            var aliveEdges = new List<Edge2D>();
            aliveEdges.Add(initialEdge);

            var deadEdges = new List<Edge2D>();

            while (aliveEdges.Count != 0)
            {
                var currentEdge = aliveEdges.FetchFirst();

                Point2D mostSuitablePoint = null;
                double mostSuitableParameter = double.MaxValue;

                var edge0 = currentEdge.Rotate();

                foreach (var point in points)
                {
                    if (currentEdge.IsOnRight(point))
                    {
                        var edge1 = new Edge2D(currentEdge.End, point).Rotate();
                        double t = edge0.ExtractIntersectionParameter(edge1);

                        if (t < mostSuitableParameter)
                        {
                            mostSuitableParameter = t;
                            mostSuitablePoint = point;
                        }
                    }
                }

                if (mostSuitablePoint == null)
                {
                    deadEdges.Add(currentEdge);
                    continue;
                }

                MakeAlive(aliveEdges, deadEdges, currentEdge.Begin, mostSuitablePoint);
                MakeAlive(aliveEdges, deadEdges, mostSuitablePoint, currentEdge.End);
                triangles.Add(new Triangle2D(currentEdge.Begin, currentEdge.End, mostSuitablePoint));
            }

            return triangles;
        }

        private static void MakeAlive(List<Edge2D> alives, List<Edge2D> deads, Point2D p1, Point2D p2)
        {
            var edge = new Edge2D(p1, p2);

            var deadIndex = deads.FindIndex(e => e.Equals(edge));
            if (deadIndex != -1)
            {
                return;
            }

            var aliveIndex = alives.FindIndex(e => e.Equals(edge));
            if (aliveIndex != -1)
            {
                alives.RemoveAt(aliveIndex);
                deads.Add(edge);
                return;
            }

            alives.Add(edge);
        }

        private static Edge2D FindInitialJarvisEdge(List<Point2D> points)
        {
            int minXCoordinate = int.MaxValue;
            var initialPoint = FindInitialJarvisPoint(points);
            Point2D nextPoint = null;

            foreach (var currentPoint in points)
            {
                if (initialPoint < currentPoint && currentPoint.X < minXCoordinate)
                {
                    minXCoordinate = currentPoint.X;
                    nextPoint = currentPoint;
                }

                //int currentDotProduct = initialPoint.ToVector() * currentPoint.ToVector();
                //if (currentDotProduct < minDotProduct)
                //{
                  //  minDotProduct = currentDotProduct;
                   // nextPoint = currentPoint;
                //}
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
