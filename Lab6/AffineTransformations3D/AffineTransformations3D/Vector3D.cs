using System;

namespace AffineTransformations3D
{
    public class Vector3D
    {
        private double _x;
        private double _y;
        private double _z; 
        private double? _length;

        public double X { get => _x; set => SetX(value); }
        public double Y { get => _y; set => SetY(value); }
        public double Z { get => _z; set => SetZ(value); }
        public double W { get; set; }
        // Отложенная инициализация длины вектора
        public double Length
        {
            get
            {
                if (_length == null)
                {
                    _length = ComputeLength();
                }
                return _length.Value;
            }
        }

        public Vector3D(double x, double y, double z, double w = 0)
        {
            _x = x;
            _y = y;
            _z = z;
            W = w;
        }

        public Vector3D() : this(0, 0, 0)
        {
        }

        public Matrix ToMatrix()
        {
            var elements = new double[,] { { X, Y, Z, W } };
            return new Matrix(elements);
        }

        public double DotProduct(Vector3D other) => DotProduct(this, other);

        public static double DotProduct(Vector3D lhs, Vector3D rhs)
        {
            double dot = lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
            return dot;
        }

        public static Vector3D operator-(Vector3D lhs, Vector3D rhs) 
            => new Vector3D(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);

        public static Vector3D operator*(Vector3D lhs, double rhs) 
            => new Vector3D(lhs.X * rhs, lhs.Y * rhs, lhs.Z * rhs);

        public static Vector3D operator *(double lhs, Vector3D rhs) 
            => rhs * lhs;

        public void Add(Vector3D other)
        {
            X += other.X;
            Y += other.Y;
            Z += other.Z;
        }

        public Vector3D CrossProduct(Vector3D other) => CrossProduct(this, other);

        public static Vector3D CrossProduct(Vector3D lhs, Vector3D rhs)
        {
            double x = lhs.Y * rhs.Z - lhs.Z * rhs.Y;
            double y = lhs.Z * rhs.X - lhs.X * rhs.Z;
            double z = lhs.X * rhs.Y - lhs.Y * rhs.X;
            var cross = new Vector3D(x, y, z);
            return cross;
        }

        public Vector3D Normalize()
        {
            double length = Length;
            var v = new Vector3D(X / length, Y / length, Z / length);
            v._length = v.ComputeLength();
            return v;
        }

        public void NormalizeInplace()
        {
            var normalized = Normalize();
            X = normalized.X;
            Y = normalized.Y;
            Z = normalized.Z;
            _length = normalized.Length;
        }

        public double ComputeLength() => ComputeLength(this);

        private static double ComputeLength(Vector3D vector3D) => Math.Sqrt(
            vector3D.X*vector3D.X + vector3D.Y*vector3D.Y + vector3D.Z*vector3D.Z);

        private void SetX(double x)
        {
            if (_x != x)
            {
                ResetLength();
            }
            _x = x;
        }

        private void SetY(double y)
        {
            if (_y != y)
            {
                ResetLength();
            }
            _y = y;

        }

        private void SetZ(double z)
        {
            if (_z != z)
            {
                ResetLength();
            }
            _z = z;
        }

        private void ResetLength()
        {
            _length = null;
        }
    }
}
