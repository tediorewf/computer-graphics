using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
    using static Utils;

    public class Edge2D : ICloneable, IComparable<Edge2D>
    {
        private Point2D _begin;
        public Point2D Begin => _begin;
        private Point2D _end;
        public Point2D End => _end;
        public Point2D Mid => (Begin + End) / 2;
        public Vector2D Vector => new Vector2D(End - Begin);
        public Vector2D Normal => ComputeNormal();

        public Edge2D(Point2D begin, Point2D end)
        {
            _begin = begin;
            _end = end;
        }

        public Vector2D ComputeNormal()
        {
            var vector = Vector;
            var normal = new Vector2D(vector.Y, -vector.X);
            return normal;
        }

        public Edge2D Rotate()
        {
            var mid = Mid;
            var normal = Normal;
            var begin = (mid - _begin) / 2;
            var end = (mid + normal.ToPoint2D()) / 2;
            return new Edge2D(begin, end);
        }

        public double ExtractIntersectionParameter(Edge2D other)
        {
            var a = Begin;
            var b = End;

            var c = other.Begin;
            var d = other.End;

            return ExtractIntersectionParameter(a, b, c, d);
        }

        public static double ExtractIntersectionParameter(Point2D a, Point2D b, Point2D c, Point2D d)
        {
            var n = new Vector2D(d.Y - c.Y, c.X - d.X);

            int denominator = n * new Edge2D(b, a).Vector;

            int numerator = -1 * n * new Edge2D(a, c).Vector;

            double t = (double)numerator / denominator;

            return t;
        }

        public void Flip() => Swap(ref _begin, ref _end);

        public bool IsOnRight(Point2D p) => Equate(p) > 0;

        public bool IsOnRightOrOnEdge(Point2D p) => Equate(p) >= 0;

        private int Equate(Point2D p) => Equate(Begin, End, p);

        private static int Equate(Point2D p1, Point2D p2, Point2D p)
        {
            var a = p1 - p;
            var b = p2 - p;
            return a.X * b.Y - b.X * a.Y;
        }

        public object Clone() => new Edge2D(Begin.Copy(), End.Copy());

        public Edge2D Copy() => Clone() as Edge2D;

        public int CompareTo(Edge2D other)
        {
            int result = 0;

            if (Begin < other.Begin || End < other.End)
            {
                result = -1;
            }

            if (Begin > other.Begin || End > other.End)
            {
                result = 1;
            }

            return result;
        }
    }
}
