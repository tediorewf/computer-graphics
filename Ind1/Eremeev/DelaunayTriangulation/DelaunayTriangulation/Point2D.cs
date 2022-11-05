using System.Drawing;
using System.Collections.Generic;

namespace DelaunayTriangulation
{
public class Point2D
{
    public int X {
        get;
    }
    public int Y {
        get;
    }
    public HashSet<Triangle2D> AdjacentTriangles {
        get;
        private set;
    }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
        AdjacentTriangles = new HashSet<Triangle2D>();
    }

    public Point2D(Point p) : this(p.X, p.Y)
    {
    }

    public Point ToPoint() => new Point(X, Y);

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var point = obj as Point2D;

        return point.X == X && point.Y == Y;
    }

    public override int GetHashCode() => X ^ Y;

    public int ComputeDistanceSquared(Point2D other)
    => ComputeDistanceSquared(this, other);

    public static int ComputeDistanceSquared(Point2D lhs, Point2D rhs)
    {
        int diffX = lhs.X - rhs.X;
        int diffY = lhs.Y - rhs.Y;
        return diffX * diffX + diffY * diffY;
    }
}
}
