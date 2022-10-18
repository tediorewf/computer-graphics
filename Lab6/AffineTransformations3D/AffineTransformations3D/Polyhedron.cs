using System;
using System.Collections.Generic;
using System.Linq;

namespace AffineTransformations3D
{
    using static AffineTransformationMatrices;

    public class Polyhedron : ICloneable
    {
        public List<Point3D> Vertices { get; set; }
        public List<Edge3D> Edges { get; set; }
        public List<Facet3D> Facets { get; set; }
        private Point3D _center;
        // Отложенная инициализация центра многогранника
        public Point3D Center
        {
            get 
            { 
                if (_center == null)
                {
                    _center = ComputeCenter();
                }
                return _center; 
            }
        }

        public Polyhedron(List<Point3D> vertices, List<Edge3D> edges, List<Facet3D> facets)
        {
            Vertices = vertices;
            Edges = edges;
            Facets = facets;
        }

        // TODO: мне надо будет доделать это
        // Не меняет исходную фигуру, создает копию
        public Polyhedron ComputeProjection(ProjectionType projectionType)
        {
            var clone = Clone() as Polyhedron;
            var perspectiveProjectionMatrix = projectionType.GetMatrix();
            ApplyTransformationInplace(clone, perspectiveProjectionMatrix);
            return clone;
        }

        public void Translate(double dx, double dy, double dz)
        {
            var translationTransformation = MakeTranslationMatrix(dx, dy, dz);
            ApplyTransformationInplace(this, translationTransformation);
        }

        public void RotateXAxis(double degrees) 
        {
            var xAxisRotationTransformation = MakeXRotationMatrix(degrees);
            ApplyTransformationInplace(this, xAxisRotationTransformation);
        }

        public void RotateYAxis(double degrees)
        {
            var yAxisRotationTransformation = MakeYRotationMatrix(degrees);
            ApplyTransformationInplace(this, yAxisRotationTransformation);
        }

        public void RotateZAxis(double degrees)
        {
            var zAxisRotationTransformation = MakeZRotationMatrix(degrees);
            ApplyTransformationInplace(this, zAxisRotationTransformation);
        }

        public void RotateXCenter(double degrees)
        {
            var xCenteredRotationTransformation = MakeTranslationMatrix(-Center.X, -Center.Y, -Center.Z)
                * MakeXRotationMatrix(degrees)
                * MakeTranslationMatrix(Center.X, Center.Y, Center.Z);
            ApplyTransformationInplace(this, xCenteredRotationTransformation);
        }

        public void RotateYCenter(double degrees)
        {
            var yCenteredRotationTransformation = MakeTranslationMatrix(-Center.X, -Center.Y, -Center.Z)
                * MakeYRotationMatrix(degrees)
                * MakeTranslationMatrix(Center.X, Center.Y, Center.Z);
            ApplyTransformationInplace(this, yCenteredRotationTransformation);
        }

        public void RotateZCenter(double degrees)
        {
            var zCenteredRotationTransformation = MakeTranslationMatrix(-Center.X, -Center.Y, -Center.Z) 
                * MakeZRotationMatrix(degrees)
                * MakeTranslationMatrix(Center.X, Center.Y, Center.Z);
            ApplyTransformationInplace(this, zCenteredRotationTransformation);
        }

        public void ScaleCentered(double factor)
        {
            var centeredScalingTransformation = MakeTranslationMatrix(-Center.X, -Center.Y, -Center.Z) 
                * MakeScalingMatrix(factor)
                * MakeTranslationMatrix(Center.X, Center.Y, Center.Z);
            ApplyTransformationInplace(this, centeredScalingTransformation);
        }

        public void ReflectXY()
        {
            var xYReflectionTransformation = MakeXYReflectionMatrix();
            ApplyTransformationInplace(this, xYReflectionTransformation);
        }

        public void ReflectYZ()
        {
            var yZReflectionTransformation = MakeYZReflectionMatrix();
            ApplyTransformationInplace(this, yZReflectionTransformation);
        }

        public void ReflectZX()
        {
            var zXReflectionTransformation = MakeZXReflectionMatrix();
            ApplyTransformationInplace(this, zXReflectionTransformation);
        }

        public object Clone()
        {
            var vertices = Vertices.Select(v => v.Clone() as Point3D).ToList();
            var edges = new List<Edge3D>(Edges.Count);
            for (int i = 0; i < Edges.Count; i++)
            {
                Point3D begin = null, end = null;
                for (int j = 0; j < Vertices.Count; j++)
                {
                    if (begin == null && Edges[i].Begin.Identifier == vertices[j].Identifier)
                    {
                        begin = vertices[j];
                    }
                    if (end == null && Edges[i].End.Identifier == vertices[j].Identifier)
                    {
                        end = vertices[j];
                    }
                    if (begin != null && end != null)
                    {
                        edges.Add(new Edge3D(begin, end));
                        break;
                    }
                }
            }
            // Поверхности пока не нужны в этой лабе. Это так, на будущее
            var facets = new List<Facet3D>(Facets.Count);
            return new Polyhedron(vertices, edges, facets);
        }

        private Point3D ComputeCenter()
        {
            return ComputeCenter(this);
        }

        private static Point3D ComputeCenter(Polyhedron polyhedron)
        {
            double x = 0;
            double y = 0;
            double z = 0;
            int pointsTotal = 0;
            foreach (var vertex in polyhedron.Vertices)
            {
                x += vertex.X;
                y += vertex.Y;
                z += vertex.Z;
                pointsTotal += 1;
            }
            return new Point3D(x / pointsTotal, y / pointsTotal, z / pointsTotal);
        }

        private static void ApplyTransformationInplace(Polyhedron polyhedron, Matrix transformation)
        {
            for (int i = 0; i < polyhedron.Vertices.Count; i++)
            {
                TransformPointInplace(polyhedron.Vertices[i], transformation);
            }
            TransformPointInplace(polyhedron.Center, transformation);
        }

        private static void TransformPointInplace(Point3D point, Matrix transformation)
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
