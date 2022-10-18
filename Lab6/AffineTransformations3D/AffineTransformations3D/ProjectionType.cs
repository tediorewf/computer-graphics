using System;

namespace AffineTransformations3D
{
    public enum ProjectionType
    {
        Perspective, Isometric
    }

    public static class ProjectionTypeExtensionMethods
    {
        public static Matrix GetMatrix(this ProjectionType projectionType)
        {
            switch (projectionType)
            {
                case ProjectionType.Perspective:
                    return AffineTransformationMatrices.MakePerspectiveProjectionMatrix(500);
                case ProjectionType.Isometric:
                    return AffineTransformationMatrices.MakeIsometricProjectionMatrix();
                default:
                    throw new ArgumentException("Unknown projection type");
            }
        }

        public static ProjectionType GetNext(this ProjectionType projectionType)
        {
            switch (projectionType)
            {
                case ProjectionType.Perspective:
                    return ProjectionType.Isometric;
                case ProjectionType.Isometric:
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
                case ProjectionType.Isometric:
                    return "Изометрическая";
                default:
                    throw new ArgumentException("Unknown projection type");
            }
        }
    }
}
