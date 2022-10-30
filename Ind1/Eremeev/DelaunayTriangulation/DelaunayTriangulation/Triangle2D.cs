using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
    public class Triangle2D
    {
        public Point2D P1 { get; private set; }
        public Point2D P2 { get; private set; }
        public Point2D P3 { get; private set; }

        public Triangle2D(Point2D p1, Point2D p2, Point2D p3)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
        }
    }
}
