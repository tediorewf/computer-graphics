using System;
using System.Collections.Generic;
using System.Drawing;

namespace AffineTransformations3D
{
    public class Facet3D : ICloneable
    {
        public List<Point3D> Points { get; set; }
        public List<Edge3D> Edges { get; set; }
        public List<List<Point>> Texture { get; set; }
        public Vector3D Normal { get; set; }

        // Создает пустую поверхность
        public Facet3D() : this(new List<Point3D>(), new List<Edge3D>())
        {
        }

        public Facet3D(List<Point3D> points, List<Edge3D> edges)
        {
            Points = points;
            Edges = edges;
            Texture = new List<List<Point>>();
            Normal = ComputeNormal(edges[0], edges[1]);
            Normal.NormalizeInplace();
            foreach (var p in Points)
            {
                p.Normal.Add(Normal);
            }
        }

        private static Vector3D ComputeNormal(Edge3D edge1, Edge3D edge2)
        {
            var v1 = edge1.ToVector3D();
            var v2 = edge2.ToVector3D();
            return v1.CrossProduct(v2);
        }

        public void AddPoint(Point3D p)
        {
            Points.Add(p);
        }

        public void AddEdge(Edge3D edge)
        {
            Edges.Add(edge);
        }

        public void LoadTexture(string path)
        {
            var texture = Bitmap.FromFile(path);
            Texture = new List<List<Point>>();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
