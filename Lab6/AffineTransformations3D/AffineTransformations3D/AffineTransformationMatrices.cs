using System;
using static AffineTransformations3D.MathConstants;

namespace AffineTransformations3D
{
    public static class AffineTransformationMatrices
    {
        public static Matrix MakeXRotationMatrix(double degrees)
        {
            double radians = degrees * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var elements = new double[,] {
                { 1, 0, 0, 0},
                { 0, angleCos, -angleSin, 0},
                { 0, angleSin, angleCos, 0},
                { 0, 0, 0, 1}
            };
            return new Matrix(elements);
        }

        public static Matrix MakeEdgeRotationMatrix(double l, double m, double n, double angle)
        {
            double rad_angle = (angle / 180.0 * Math.PI);
            double cos_ang = Math.Cos(rad_angle);
            double sin_ang = Math.Sin(rad_angle);

            double[,] afin_matrix = new double[4, 4];
            afin_matrix[0, 0] = l * l + cos_ang * (1 - l * l);
            afin_matrix[0, 1] = l * (1 - cos_ang) * m + n * sin_ang;
            afin_matrix[0, 2] = l * (1 - cos_ang) * n - m * sin_ang;
            afin_matrix[1, 0] = l * (1 - cos_ang) * m - n * sin_ang;
            afin_matrix[1, 1] = m * m + cos_ang * (1 - m * m);
            afin_matrix[1, 2] = m * (1 - cos_ang) * n + l * sin_ang;
            afin_matrix[2, 0] = l * (1 - cos_ang) * n + m * sin_ang;
            afin_matrix[2, 1] = m * (1 - cos_ang) * n - l * sin_ang;
            afin_matrix[2, 2] = n * n + cos_ang * (1 - n * n);
            for (int i = 0; i < 3; ++i)
            {
                afin_matrix[i, 3] = 0;
                afin_matrix[3, i] = 0;
            }
            afin_matrix[3, 3] = 1;
            return new Matrix(afin_matrix);
        }

        public static Matrix MakeYRotationMatrix(double degrees)
        {
            double radians = degrees * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var elements = new double[,] {
                { angleCos, 0, angleSin, 0},
                { 0, 1, 0, 0},
                { -angleSin, 0, angleCos, 0},
                { 0, 0, 0, 1}
            };
            return new Matrix(elements);
        }

        public static Matrix MakeZRotationMatrix(double degrees)
        {
            double radians = degrees * Math.PI / 180;

            double angleCos = Math.Cos(radians);
            double angleSin = Math.Sin(radians);

            var elements = new double[,] {
                { angleCos, -angleSin, 0, 0},
                { angleSin,  angleCos, 0, 0},
                {  0, 0, 1, 0},
                { 0, 0, 0, 1}
            };
            return new Matrix(elements);
        }

        public static Matrix MakeScalingMatrix(double d)
        {
            var elements = new double[,] {
                { d, 0, 0, 0 },
                { 0, d, 0, 0 },
                { 0, 0, d, 0 },
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
        public static Matrix MakeIsometricProjectionMatrix()
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
