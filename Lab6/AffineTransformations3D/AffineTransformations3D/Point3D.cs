using System;
using System.Drawing;

namespace AffineTransformations3D
{
public class Point3D : IIdentifiable<long>, ICloneable
{
    private static int nextIdentifier = 0;
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

    public Vector3D ToVector3D()
    {
        return new Vector3D(X, Y, Z, 1);
    }

    public Vector3D ToVector3D(Point3D C)
    {
        return new Vector3D(X - C.X, Y - C.Y, Z - C.Z, 1);
    }

    public Point ToPoint()
    {
        return new Point((int)X, (int)Y);
    }

    public object Clone()
    {
        return new Point3D(X, Y, Z, _identifier);
    }
}
}
