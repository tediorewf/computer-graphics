using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
    public class Edge2D
    {
        public Point2D Begin { get; set; }
        public Point2D End { get; set; }

        public Edge2D(Point2D begin, Point2D end)
        {
            Begin = begin;
            End = end;
        }

        public override int GetHashCode() => Begin.GetHashCode() ^ End.GetHashCode();
    }
}
