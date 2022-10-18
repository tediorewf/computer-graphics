using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public static class RegularPolyhedrons
    {
        private static Point3D Middle(Point3D P1, Point3D P2)
        {
            return new Point3D((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2, (P1.Z + P2.Z) / 2);
        }

        public static Polyhedron MakeGeksahedron()
        {
            int longg = 300;
            var vertices = new List<Point3D>();
            var p0 = new Point3D(0, 0, 0);
            var p1 = new Point3D(0, 0, longg);
            var p2 = new Point3D(0, longg, 0);
            var p3 = new Point3D(longg, 0, 0);
            var p4 = new Point3D(longg, 0, longg);
            var p5 = new Point3D(longg, longg, 0);
            var p6 = new Point3D(0, longg, longg);
            var p7 = new Point3D(longg, longg, longg);
            vertices.Add(p0);
            vertices.Add(p1);
            vertices.Add(p2);
            vertices.Add(p3);
            vertices.Add(p4);
            vertices.Add(p5);
            vertices.Add(p6);
            vertices.Add(p7);

            var edges = new List<Edge3D>();
            var edge0 = new Edge3D(p0, p1);
            var edge1 = new Edge3D(p0, p2);
            var edge2 = new Edge3D(p0, p3);
            var edge3 = new Edge3D(p1, p4);
            var edge4 = new Edge3D(p1, p6);
            var edge5 = new Edge3D(p2, p5);
            var edge6 = new Edge3D(p2, p6);
            var edge7 = new Edge3D(p3, p5);
            var edge8 = new Edge3D(p3, p4);
            var edge9 = new Edge3D(p4, p7);
            var edge10 = new Edge3D(p5, p7);
            var edge11 = new Edge3D(p6, p7);

            edges.Add(edge0);
            edges.Add(edge1);
            edges.Add(edge2);
            edges.Add(edge3);
            edges.Add(edge4);
            edges.Add(edge5);
            edges.Add(edge6);
            edges.Add(edge7);
            edges.Add(edge8);
            edges.Add(edge9);
            edges.Add(edge10);
            edges.Add(edge11);

            var facets = new List<Facet3D>();
            // TODO: добавить поверхности когда они реально понадобятся
            /*var edges0 = new List<Edge3D>();
            edges0.Add();
            var facet0 = new Facet3D();*/

            return new Polyhedron(vertices, edges, facets);
        }
        public static Polyhedron MakeTetrahedron()
        {
            Polyhedron P = MakeGeksahedron();
            var vertices = new List<Point3D>();
            for (int i = 1; i <= 3; i++)
                vertices.Add(P.Vertices[i]);
            vertices.Add(P.Vertices[7]);
            var edges = new List<Edge3D>();
            for (int i = 0; i <= 3; i++)
                for (int j = i+1; j <= 3; j++)
                    edges.Add(new Edge3D(vertices[i], vertices[j]));
            var facets = new List<Facet3D>();
            // TODO: добавить поверхности когда они реально понадобятся
            /*var edges0 = new List<Edge3D>();
            edges0.Add();
            var facet0 = new Facet3D();*/

            return new Polyhedron(vertices, edges, facets);
        }
        public static Polyhedron MakeOktahedron()
        {
            Polyhedron P = MakeGeksahedron();
            var vertices = new List<Point3D>();
            for (int i = 4; i <= 6; i++)
                vertices.Add(Middle(P.Vertices[0], P.Vertices[i]));
            for (int i = 1; i <= 3; i++)
                vertices.Add(Middle(P.Vertices[7], P.Vertices[i]));

            var edges = new List<Edge3D>();
            for (int i = 1; i <= 3; i++)
                edges.Add(new Edge3D(vertices[0], vertices[i]));
            edges.Add(new Edge3D(vertices[0], vertices[5]));
            edges.Add(new Edge3D(vertices[1], vertices[2]));
            edges.Add(new Edge3D(vertices[1], vertices[4]));
            edges.Add(new Edge3D(vertices[1], vertices[5]));
            edges.Add(new Edge3D(vertices[2], vertices[3]));
            edges.Add(new Edge3D(vertices[2], vertices[4]));
            edges.Add(new Edge3D(vertices[3], vertices[4]));
            edges.Add(new Edge3D(vertices[3], vertices[5]));
            edges.Add(new Edge3D(vertices[4], vertices[5]));
            var facets = new List<Facet3D>();
            // TODO: добавить поверхности когда они реально понадобятся
            /*var edges0 = new List<Edge3D>();
            edges0.Add();
            var facet0 = new Facet3D();*/

            return new Polyhedron(vertices, edges, facets);
        }
    }
}
