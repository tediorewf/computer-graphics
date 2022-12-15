using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom
{
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public double ComputeLength() => Math.Sqrt(X * X + Y * Y + Z * Z);

        public Vector3D Normalize()
        {
            double length = ComputeLength();
            var x = X / length;
            var y = Y / length;
            var z = Z / length;
            return new Vector3D(x, y, z);
        }

        public double ComputeDotProduct(Vector3D other) => ComputeDotProduct(this, other);

        public double ComputeDotProduct(Vector3D lhs, Vector3D rhs) 
            => lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;

        public Vector3D ComputeCrossProduct(Vector3D other) => ComputeCrossProduct(this, other);

        public static Vector3D ComputeCrossProduct(Vector3D lhs, Vector3D rhs)
        {
            double x = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            double y = lhs.Z * rhs.X - lhs.X * rhs.Z;
            double z = lhs.X * rhs.Y - lhs.Y * rhs.X;
            return new Vector3D(x, y, z);
        }
    }
}
