using System;
using static AffineTransformations3D.MathConstants;

namespace AffineTransformations3D
{
    public static class AffineTransformationMatrices
    {
        public static Matrix MakeXYZRotationMatrix(double degreesX, double degreesY, double degreesZ)
        {
            return MakeXRotationMatrix(degreesX) 
                * MakeYRotationMatrix(degreesY) 
                * MakeZRotationMatrix(degreesZ);
        }

        public static Matrix MakeXRotationMatrix(double degrees)
        {
            double radians = degrees * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var elements = new double[,] {
                { 1, 0, 0, 0 },
                { 0, angleCos, -angleSin, 0 },
                { 0, angleSin, angleCos, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeYRotationMatrix(double degrees)
        {
            double radians = degrees * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var elements = new double[,] {
                { angleCos, 0, angleSin, 0 },
                { 0, 1, 0, 0 },
                { -angleSin, 0, angleCos, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeZRotationMatrix(double degrees)
        {
            double radians = degrees * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var elements = new double[,] {
                { angleCos, -angleSin, 0, 0 },
                { angleSin,  angleCos, 0, 0 },
                {  0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeRotateAroundEdgeMatrix(Edge3D edge3D, double angle)
        {
            double radians = angle * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var vector3D = edge3D.ToVector3D();

            double t = vector3D.X / vector3D.Length;  // t - чтобы не путать l с единицей :)
            double m = vector3D.Y / vector3D.Length;
            double n = vector3D.Z / vector3D.Length;

            double tSqr = t * t;  // мелкие оптимизации
            double mSqr = m * m;
            double nSqr = n * n;

            var elements = new double[,]
            {
                { tSqr + angleCos*(1 - tSqr), t*(1 - angleCos)*m + n * angleSin, t*(1 - angleCos)*n - m * angleSin, 0 },
                { t * (1 - angleCos)*m - n*angleSin, mSqr + angleCos*(1 - mSqr), m*(1 - angleCos)*n + t*angleSin, 0 },
                { t*(1 - angleCos)*n+m*angleSin, m*(1 - angleCos)*n - t*angleSin, nSqr + angleCos*(1 - nSqr), 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeScalingMatrix(double mx, double my, double mz)
        {
            var elements = new double[,] {
                { mx, 0, 0, 0 },
                { 0, my, 0, 0 },
                { 0, 0, mz, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeTranslationMatrix(double dx, double dy, double dz)
        {
            var elements = new double[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { dx, dy, dz, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakePerspectiveProjectionMatrix(double c)
        {
            var elements = new double[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 1/c },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        // Изометрическая проекция
        public static Matrix MakeAxonometricProjectionMatrix()
        {
            var elements = new double[,] {
                { 1 / SquareRoot2, 1 / SquareRoot6, 1 / SquareRoot3, 0 },
                { 0, 2 / SquareRoot6, -1 / SquareRoot3, 0 },
                { -1 / SquareRoot2, 1 / SquareRoot6, 1 / SquareRoot3, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeXYReflectionMatrix()
        {
            var elements = new double[,] {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, -1, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeYZReflectionMatrix()
        {
            var elements = new double[,] {
                { -1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }

        public static Matrix MakeZXReflectionMatrix()
        {
            var elements = new double[,] {
                { 1, 0, 0, 0 },
                { 0, -1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };
            return new Matrix(elements);
        }
    }
}
