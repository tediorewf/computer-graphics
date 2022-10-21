using System;

namespace AffineTransformations3D
{
public class Vector3D
{
    private double _x;
    private double _y;
    private double _z;
    private double? _length;

    public double X {
        get => _x;
        set => SetX(value);
    }
    public double Y {
        get => _y;
        set => SetY(value);
    }
    public double Z {
        get => _z;
        set => SetZ(value);
    }
    public double W {
        get;
        set;
    }
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

    public Matrix ToMatrix()
    {
        var elements = new double[,] { { X, Y, Z, W } };
        return new Matrix(elements);
    }


    private double ComputeLength() => ComputeLength(this);

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
