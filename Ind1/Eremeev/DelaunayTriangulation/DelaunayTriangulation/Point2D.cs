using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DelaunayTriangulation
{
    public class Point2D : ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point2D(Point p) : this(p.X, p.Y)
        {
        }

        public Point2D(Point2D other) : this(other.X, other.Y)
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

        public Point ToPoint() => new Point(X, Y);

        public object Clone() => new Point2D(this);

        public Point2D Copy() => Clone() as Point2D;

        public static Point2D operator +(Point2D lhs, Point2D rhs) 
            => new Point2D(lhs.X + rhs.X, lhs.Y + rhs.Y);

        public static Point2D operator -(Point2D lhs, Point2D rhs)
            => new Point2D(lhs.X - rhs.X, lhs.Y - rhs.Y);

        public static Point2D operator /(Point2D lhs, int scalar)
            => new Point2D(lhs.X / scalar, lhs.Y / scalar);

        public static bool operator <(Point2D lhs, Point2D rhs) 
            => lhs.X < rhs.X || lhs.X == rhs.X && lhs.Y < rhs.Y;

        public static bool operator >(Point2D lhs, Point2D rhs) 
            => lhs.X > rhs.X || lhs.X == rhs.X && lhs.Y > rhs.Y;

        public override bool Equals(object obj)
        {
            if ((obj == null) || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var p = (Point2D)obj;
            return X == p.X && Y == p.Y;
        }
    }
}
