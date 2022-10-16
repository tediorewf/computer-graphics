using System.Collections.Generic;

namespace AffineTransformations3D
{
    using static AffineTransformationMatrices;

    public class Polyhedron
    {
        public List<Point3D> Vertices { get; set; }
        public List<Edge3D> Edges { get; set; }
        public List<Facet3D> Facets { get; set; }

        public Polyhedron(List<Point3D> vertices, List<Edge3D> edges, List<Facet3D> facets)
        {
            Vertices = vertices;
            Edges = edges;
            Facets = facets;
        }

        // TODO: мне надо будет доделать это
        public Polyhedron Project()
        {
            var perspectiveProjectionMatrix = MakePerspectiveProjectionMatrix(1000);
            //var newVertices = new List<Point3D>(Vertices.Count);
            for (int i = 0; i < Vertices.Count; i++)
            {
                var product = perspectiveProjectionMatrix * Vertices[i].ToVector3D();
                double x = product[0, 0];
                double y = product[0, 1];
                double z = product[0, 2];
                double w = product[0, 3];
                var transformedPoint = new Point3D(x / w, y / w, z / w);
                Vertices[i].X = transformedPoint.X;
                Vertices[i].Y = transformedPoint.Y;
            }
            return this;
        }

        public void Translate(double dx = 50, double dy = 50, double dz = 50)
        {
            var translationMatrix = MakeTranslationMatrix(dx, dy, dz);
            for (int i = 0; i < Vertices.Count; i++)
            {
                var product = translationMatrix * Vertices[i].ToVector3D();
                double x = product[0, 0];
                double y = product[0, 1];
                double z = product[0, 2];
                double w = product[0, 3];
                var transformedPoint = new Point3D(x / w, y / w, z / w);
                Vertices[i].X = transformedPoint.X;
                Vertices[i].Y = transformedPoint.Y;
            }
        }

        public void RotateX(double degrees)
        {
            var xRotationMatrix = MakeXRotationMatrix(degrees);
            for (int i = 0; i < Vertices.Count; i++)
            {
                var product = xRotationMatrix * Vertices[i].ToVector3D();
                double x = product[0, 0];
                double y = product[0, 1];
                double z = product[0, 2];
                double w = product[0, 3];
                var transformedPoint = new Point3D(x / w, y / w, z / w);
                Vertices[i].X = transformedPoint.X;
                Vertices[i].Y = transformedPoint.Y;
            }
        }

        public void RotateY(double degrees)
        {
            var xRotationMatrix = MakeYRotationMatrix(degrees);
            for (int i = 0; i < Vertices.Count; i++)
            {
                var product = xRotationMatrix * Vertices[i].ToVector3D();
                double x = product[0, 0];
                double y = product[0, 1];
                double z = product[0, 2];
                double w = product[0, 3];
                var transformedPoint = new Point3D(x / w, y / w, z / w);
                Vertices[i].X = transformedPoint.X;
                Vertices[i].Y = transformedPoint.Y;
            }
        }
    }
}
