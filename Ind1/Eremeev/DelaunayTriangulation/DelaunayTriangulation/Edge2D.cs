using System;

namespace DelaunayTriangulation
{
    public class Edge2D
    {
        public Point2D Begin { get; private set; }
        public Point2D End { get; private set; }

        public Edge2D(Point2D begin, Point2D end)
        {
            Begin = begin;
            End = end;
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var edge = obj as Edge2D;

            var pointsAreEqual = Begin.Equals(edge.Begin) && End.Equals(edge.End);
            var pointsAreEqualReversed = Begin.Equals(edge.End) && End.Equals(edge.Begin);
            return pointsAreEqual || pointsAreEqualReversed;
        }

        public override int GetHashCode()
        {
            int pointsHashCode = Begin.GetHashCode() ^ End.GetHashCode();
            return pointsHashCode.GetHashCode();
        }
    }
}
