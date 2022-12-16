using System;

namespace CornishRoom
{
public class Vector3D
{
    public double X {
        get;
    }
    public double Y {
        get;
    }
    public double Z {
        get;
    }

    public Vector3D(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3D Normalize()
    {
        double length = ComputeLength();
        return this / length;
    }

    public static Vector3D operator -(Vector3D lhs, Vector3D rhs)
    => new Vector3D(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);

    public static Vector3D operator +(Vector3D lhs, Vector3D rhs)
    => new Vector3D(lhs.X + rhs.X, lhs.Y + rhs.Y, lhs.Z + rhs.Z);

    public static Vector3D operator *(Vector3D v, double d)
    => new Vector3D(v.X * d, v.Y * d, v.Z * d);

    public static Vector3D operator *(double d, Vector3D v)
    => new Vector3D(v.X * d, v.Y * d, v.Z * d);

    public static Vector3D operator /(Vector3D v, double d)
    => new Vector3D(v.X / d, v.Y / d, v.Z / d);

    public static Vector3D operator -(Vector3D v) => new Vector3D(-v.X, -v.Y, -v.Z);

    public double ComputeLength() => Math.Sqrt(X * X + Y * Y + Z * Z);

    public double ComputeDotProduct(Vector3D other) => X * other.X + Y * other.Y + Z * other.Z;
}
}
