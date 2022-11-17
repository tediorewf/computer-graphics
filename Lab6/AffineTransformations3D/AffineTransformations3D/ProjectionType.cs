using System;

namespace AffineTransformations3D
{
    public enum ProjectionType
    {
        Perspective, Axonometric
    }

    public static class ProjectionTypeExtensionMethods
    {
        public static Matrix CreateMatrix(this ProjectionType projectionType)
        {
            switch (projectionType)
            {
                case ProjectionType.Perspective:
                    return AffineTransformationMatrices.MakePerspectiveProjectionMatrix(1000);
                case ProjectionType.Axonometric:
                    return AffineTransformationMatrices.MakeAxonometricProjectionMatrix();
                default:
                    throw new ArgumentException("Unknown projection type");
            }
        }

        public static string GetProjectionName(this ProjectionType projectionType)
        {
            switch (projectionType)
            {
                case ProjectionType.Perspective:
                    return "Перспективная";
                case ProjectionType.Axonometric:
                    return "Аксонометрическая";
                default:
                    throw new ArgumentException("Unknown projection type");
            }
        }
    }
}
