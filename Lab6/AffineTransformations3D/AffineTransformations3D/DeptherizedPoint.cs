using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public class DeptherizedPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Depth { get; set; }
        public double Intensivity { get; set; }

        public DeptherizedPoint(int x, int y, double depth, double intensivity)
        {
            X = x;
            Y = y;
            Depth = depth;
            Intensivity = intensivity;
        }

        public static DeptherizedPoint FromPoint3D(Point3D point3D, Point3D lightViewPoint)
        {
            var p = point3D.ToPoint();
            var intensivity = ComputeIntensivityLambert(point3D, lightViewPoint);
            return new DeptherizedPoint(p.X, p.Y, point3D.Z, intensivity);
        }

        private static double ComputeIntensivityLambert(Point3D direction, Point3D lightViewPoint)
        {
            var lightDirection = new Vector3D(direction.X - lightViewPoint.X, direction.Y - lightViewPoint.Y, direction.Z - lightViewPoint.Z);
            double intensivity = Math.Max(direction.Normal.DotProduct(lightDirection) / (direction.Normal.Length * lightDirection.Length), 0);
            return intensivity;
        }
    }
}
