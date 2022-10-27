using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DelaunayTriangulation
{
public class Point2D
{
    public int X {
        get;
        set;
    }
    public int Y {
        get;
        set;
    }

    public Point2D(Point p) : this(p.X, p.Y)
    {
    }

    public Point2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Создает точку с координатами (0;0)
    /// </summary>
    public Point2D() : this(0, 0)
    {
    }

    public Vector2D ToVector() => new Vector2D(X, Y);

    public override int GetHashCode() => (X.GetHashCode() + Y).GetHashCode();
}
}
