using System;
using System.Drawing;

namespace AffineTransformations3D
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3D ToVector3D()
        {
            return new Vector3D(X, Y, Z, 1);
        }

        public Point ToPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
}
