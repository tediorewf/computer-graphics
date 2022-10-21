using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
public enum CoordinatePlaneType
{
    XY,
    YZ,
    ZX,
}

public static class CoordinatePlaneTypeExtensionMethods
{
    public static Matrix CreateMatrix(this CoordinatePlaneType coordinatePlaneType)
    {
        switch (coordinatePlaneType)
        {
        case CoordinatePlaneType.XY:
            return AffineTransformationMatrices.MakeXYReflectionMatrix();
        case CoordinatePlaneType.YZ:
            return AffineTransformationMatrices.MakeYZReflectionMatrix();
        case CoordinatePlaneType.ZX:
            return AffineTransformationMatrices.MakeZXReflectionMatrix();
        default:
            throw new ArgumentException("Unknown coordinate plane type");
        }
    }

    public static string GetCoordinatePlaneName(this CoordinatePlaneType coordinatePlaneType)
    {
        switch (coordinatePlaneType)
        {
        case CoordinatePlaneType.XY:
            return "XY";
        case CoordinatePlaneType.YZ:
            return "YZ";
        case CoordinatePlaneType.ZX:
            return "ZX";
        default:
            throw new ArgumentException("Unknown coordinate plane type");
        }
    }
}
}
