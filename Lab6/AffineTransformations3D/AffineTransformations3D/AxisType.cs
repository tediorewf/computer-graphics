using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public enum AxisType
    {
        OX, 
        OY, 
        OZ
    }

    public static class AxisTypeExtensionMethods
    {
        public static string GetAxisName(this AxisType axisType)
        {
            switch (axisType)
            {
                case AxisType.OX:
                    return "OX";
                case AxisType.OY:
                    return "OY";
                case AxisType.OZ:
                    return "OZ";
                default:
                    throw new ArgumentException("Unknown axis type");
            }
        }

        public static Matrix CreateRotationMatrix(this AxisType axisType, double degrees)
        {
            switch (axisType)
            {
                case AxisType.OX:
                    return AffineTransformationMatrices.MakeXRotationMatrix(degrees);
                case AxisType.OY:
                    return AffineTransformationMatrices.MakeYRotationMatrix(degrees);
                case AxisType.OZ:
                    return AffineTransformationMatrices.MakeZRotationMatrix(degrees);
                default:
                    throw new ArgumentException("Unknown axis type");
            }
        }
    }
}
