using System;
using System.Collections.Generic;
using System.Drawing;

namespace AffineTransformations
{
    using IterationPair = Pair<Edge, int>;

    public static class MidpointDisplacementAlgorithm
    {
        public static IEnumerable<List<Edge>> GetMidpointDisplacementEdgesStepByStep(Point begin, Point end, double roughness, int iterations)
        {
            var random = new Random();
            var q = new Queue<IterationPair>();
            int i = 0;
            q.Enqueue(new IterationPair(new Edge(begin, end), i));
            for (; i < iterations; i++)
            {
                var currentStepEdges = new List<Edge>();
                while (q.Count != 0 && q.Peek().Second == i)
                {
                    var currentEdge = q.Dequeue().First;
                    currentStepEdges.Add(currentEdge);

                    int nextI = i + 1;
                    if (nextI < iterations)
                    {
                        var midPoint = CalculateMidPoint(currentEdge, roughness, random);

                        var leftEdge = new Edge(currentEdge.Begin, midPoint);
                        var rightEdge = new Edge(midPoint, currentEdge.End);
                        q.Enqueue(new IterationPair(leftEdge, nextI));
                        q.Enqueue(new IterationPair(rightEdge, nextI));
                    }
                }
                yield return currentStepEdges;
            }
        }

        private static Point CalculateMidPoint(Edge edge, double roughness, Random random)
        {
            int limit = (int)(edge.Length * roughness);
            int x = edge.Mid.X;
            int y = edge.Mid.Y + random.Next(-limit, limit);
            return new Point(x, y);
        }
    }
}
