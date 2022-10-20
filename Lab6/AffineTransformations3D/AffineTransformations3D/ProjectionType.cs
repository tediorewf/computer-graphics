using System;

namespace AffineTransformations3D
{
    public enum ProjectionType
    {
        Perspective, Axonometric
    }

    public static class ProjectionTypeExtensionMethods
    {
        public static Matrix GetMatrix(this ProjectionType projectionType)
        {
            switch (projectionType)
            {
                case ProjectionType.Perspective:
                    return AffineTransformationMatrices.MakePerspectiveProjectionMatrix(1500);
                case ProjectionType.Axonometric:
                    return AffineTransformationMatrices.MakeAxonometricProjectionMatrix();
                default:
                    throw new ArgumentException("Unknown projection type");
            }
        }

        public static ProjectionType GetNext(this ProjectionType projectionType)
        {
            switch (projectionType)
            {
                case ProjectionType.Perspective:
                    return ProjectionType.Axonometric;
                case ProjectionType.Axonometric:
                    return ProjectionType.Perspective;
                default:
                    throw new ArgumentException("Unknown projection type");
            }
        }

        public static string GetText(this ProjectionType projectionType)
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
