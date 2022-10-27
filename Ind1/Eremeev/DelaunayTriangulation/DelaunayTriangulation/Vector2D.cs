using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
public class Vector2D
{
    public int X {
        get;
        set;
    }
    public int Y {
        get;
        set;
    }

    public Vector2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Скалярное произведение
    /// </summary>
    /// <param name="lhs"></param>
    /// <param name="rhs"></param>
    /// <returns></returns>
    public static int operator*(Vector2D lhs, Vector2D rhs)
    {
        int x = lhs.X * rhs.X;
        int y = lhs.Y * rhs.Y;
        return x + y;
    }
}
}
