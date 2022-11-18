using System;
using System.Drawing;

namespace AffineTransformations3D
{
public class Point3D : IIdentifiable<long>, ICloneable, IEquatable<Point3D>
{
    private static long nextIdentifier = 0;
    public double X {
        get;
        set;
    }
    public double Y {
        get;
        set;
    }
    public double Z {
        get;
        set;
    }
    private long _identifier;
    public long Identifier => _identifier;

    public Point3D(Point3D other) : this(other.X, other.Y, other.Z)
    {
    }

    public Point3D(double x, double y, double z) : this(x, y, z, nextIdentifier)
    {
        nextIdentifier += 1;
    }

    private Point3D(double x, double y, double z, long identifier)
    {
        X = x;
        Y = y;
        Z = z;
        _identifier = identifier;
    }

    public Vector3D ToVector3D() => new Vector3D(X, Y, Z, 1);

    public Point ToPoint() => new Point((int)X, (int)Y);

    public object Clone() => new Point3D(X, Y, Z, _identifier);

    public bool Equals(Point3D other) => Identifier == other.Identifier;

    public override int GetHashCode() => Identifier.GetHashCode();
}
}
