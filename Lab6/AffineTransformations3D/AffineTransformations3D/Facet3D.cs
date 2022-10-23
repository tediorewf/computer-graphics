using System;
using System.Collections.Generic;

namespace AffineTransformations3D
{
    public class Facet3D : ICloneable
    {
        public List<Point3D> Points { get; set; }
        public List<Edge3D> Edges { get; set; }

        // Создает пустую поверхность
        public Facet3D() : this(new List<Point3D>(), new List<Edge3D>())
        {
        }

        public Facet3D(List<Point3D> points, List<Edge3D> edges)
        {
            Points = points;
            Edges = edges;
        }

        public void AddPoint(Point3D p)
        {
            Points.Add(p);
        }

        public void AddEdge(Edge3D edge)
        {
            Edges.Add(edge);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
