using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
    public class Vector2D
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2D(Point2D p) : this(p.X, p.Y)
        {
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

        public static Vector2D operator +(Vector2D lhs, Vector2D rhs)
            => new Vector2D(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static Vector2D operator -(Vector2D lhs, Vector2D rhs)
            => new Vector2D(lhs.X - rhs.X, lhs.Y - rhs.Y);

        public static Vector2D operator /(Vector2D vector, int scalar)
            => new Vector2D(vector.X / scalar, vector.Y / scalar);

        public static Vector2D operator *(int scalar, Vector2D vector)
            => new Vector2D(scalar * vector.X, scalar * vector.Y);

        public Point2D ToPoint2D() => new Point2D(X, Y);
    }
}
