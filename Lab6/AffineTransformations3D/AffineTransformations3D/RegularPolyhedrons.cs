using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public static class RegularPolyhedrons
    {
        public static Polyhedron MakeCube()
        {
            var vertices = new List<Point3D>();
            var p0 = new Point3D(0, 100, 100);
            var p1 = new Point3D(0, 100, 0);
            var p2 = new Point3D(100, 100, 0);
            var p3 = new Point3D(100, 100, 100);
            var p4 = new Point3D(0, 0, 100);
            var p5 = new Point3D(0, 0, 0);
            var p6 = new Point3D(100, 0, 0);
            var p7 = new Point3D(100, 0, 100);
            vertices.Add(p0);
            vertices.Add(p1);
            vertices.Add(p2);
            vertices.Add(p3);
            vertices.Add(p4);
            vertices.Add(p5);
            vertices.Add(p6);
            vertices.Add(p7);

            var edges = new List<Edge3D>();
            edges.Add(new Edge3D(p0, p1));
            edges.Add(new Edge3D(p1, p2));
            edges.Add(new Edge3D(p2, p3));
            edges.Add(new Edge3D(p3, p0));

            edges.Add(new Edge3D(p0, p7));
            edges.Add(new Edge3D(p1, p4));
            edges.Add(new Edge3D(p2, p5));
            edges.Add(new Edge3D(p3, p6));

            edges.Add(new Edge3D(p4, p5));
            edges.Add(new Edge3D(p5, p6));
            edges.Add(new Edge3D(p6, p7));
            edges.Add(new Edge3D(p7, p4));

            var facets = new List<Facet3D>();
            var edges0 = new List<Edge3D>();
            edges0.Add(new Edge3D(p0, p1));
            edges0.Add(new Edge3D(p1, p2));
            edges0.Add(new Edge3D(p2, p3));
            edges0.Add(new Edge3D(p3, p0));
            var edges1 = new List<Edge3D>();
            edges1.Add(new Edge3D(p0, p1));
            edges1.Add(new Edge3D(p1, p4));
            edges1.Add(new Edge3D(p4, p7));
            edges1.Add(new Edge3D(p7, p0));
            var edges2 = new List<Edge3D>();
            edges2.Add(new Edge3D(p1, p2));
            edges2.Add(new Edge3D(p2, p5));
            edges2.Add(new Edge3D(p5, p4));
            edges2.Add(new Edge3D(p4, p1));
            var edges3 = new List<Edge3D>();
            edges3.Add(new Edge3D(p7, p4));
            edges3.Add(new Edge3D(p4, p5));
            edges3.Add(new Edge3D(p5, p6));
            edges3.Add(new Edge3D(p6, p7));
            var edges4 = new List<Edge3D>();
            edges4.Add(new Edge3D(p2, p3));
            edges4.Add(new Edge3D(p3, p6));
            edges4.Add(new Edge3D(p6, p5));
            edges4.Add(new Edge3D(p5, p2));
            var edges5 = new List<Edge3D>();
            edges5.Add(new Edge3D(p2, p3));
            edges5.Add(new Edge3D(p3, p6));
            edges5.Add(new Edge3D(p6, p5));
            edges5.Add(new Edge3D(p5, p2));

            facets.Add(new Facet3D(edges0));
            facets.Add(new Facet3D(edges1));
            facets.Add(new Facet3D(edges2));
            facets.Add(new Facet3D(edges3));
            facets.Add(new Facet3D(edges4));
            facets.Add(new Facet3D(edges5));

            var cube = new Polyhedron(vertices, edges, facets);
            return cube;
        }
    }
}
