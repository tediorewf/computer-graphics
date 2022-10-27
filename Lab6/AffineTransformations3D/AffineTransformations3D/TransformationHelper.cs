﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public static class TransformationHelper
    {
        public static void ApplyTransformationInplace(Polyhedron polyhedron, Matrix transformation)
        {
            TransformMultiplePointsInplace(polyhedron.Vertices, transformation);
            TransformPointInplace(polyhedron.Center, transformation);
        }

        public static void TransformMultiplePointsInplace(List<Point3D> points, Matrix transformation) 
            => points.ForEach(p => TransformPointInplace(p, transformation));

        public static void TransformPointInplace(Point3D point, Matrix transformation)
        {
            var product = point.ToVector3D() * transformation;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w, y / w, z / w);
            point.X = transformedPoint.X;
            point.Y = transformedPoint.Y;
            point.Z = transformedPoint.Z;
        }
    }
}
