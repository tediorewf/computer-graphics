using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public static class RegularPolyhedrons
    {
        private static int longg = 300;
        private static int longg2 = 100;
        private static Point3D Middle(Point3D P1, Point3D P2)
        {
            return new Point3D((P1.X + P2.X) / 2, (P1.Y + P2.Y) / 2, (P1.Z + P2.Z) / 2);
        }
        private static Point3D Middle(Point3D P1, Point3D P2, Point3D P3)
        {
            return new Point3D((P1.X + P2.X + P3.X) / 3, (P1.Y + P2.Y + P3.Y) / 3, (P1.Z + P2.Z + P3.Z) / 3);
        }
        private static Point3D NewPointIkosahedron(Point3D PFCentr, double r, double h, int i)
        {
            Point3D P = new Point3D(0, 0, 0);
            double alpha = 0.6283 * i;
            P.X = (0 - PFCentr.X) * Math.Cos(alpha) - (r - PFCentr.Y) * Math.Sin(alpha) + PFCentr.X;
            P.Y = (0 - PFCentr.X) * Math.Sin(alpha) + (r - PFCentr.Y) * Math.Cos(alpha) + PFCentr.Y;
            if (i % 2 == 0)
                P.Z = h;
            return P;
        }
        public static Polyhedron MakeGeksahedron()
        {
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
                for (int j = i + 1; j <= 3; j++)
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
        public static Polyhedron MakeIkosahedron()
        {
            var vertices = new List<Point3D>();
            Point3D PFCentr = new Point3D(longg2, longg2, 0);
            double l = 1.17557 * longg2;
            double h = 0.86603 * l;
            double H = 1.902 * l;
            double k = (H - h) / 2;
            for (int i = 0; i < 10; i++)
                vertices.Add(NewPointIkosahedron(PFCentr, longg2, h, i));
            vertices.Add(new Point3D(longg2, longg2, h + k));
            vertices.Add(new Point3D(longg2, longg2, -k));

            var edges = new List<Edge3D>();
            for (int i = 0; i <= 7; i++)
            {
                edges.Add(new Edge3D(vertices[i], vertices[i + 1]));
                edges.Add(new Edge3D(vertices[i], vertices[i + 2]));
            }
            edges.Add(new Edge3D(vertices[8], vertices[9]));
            edges.Add(new Edge3D(vertices[8], vertices[0]));
            edges.Add(new Edge3D(vertices[9], vertices[0]));
            edges.Add(new Edge3D(vertices[9], vertices[1]));

            for (int i = 0; i <= 8; i += 2)
                edges.Add(new Edge3D(vertices[10], vertices[i]));
            for (int i = 1; i <= 9; i += 2)
                edges.Add(new Edge3D(vertices[11], vertices[i]));


            var facets = new List<Facet3D>();
            // TODO: добавить поверхности когда они реально понадобятся
            /*var edges0 = new List<Edge3D>();
            edges0.Add();
            var facet0 = new Facet3D();*/

            return new Polyhedron(vertices, edges, facets);

        }
        public static Polyhedron MakeDodahedron()
        {
            var vertices = new List<Point3D>();
            Polyhedron P = MakeIkosahedron();
            for (int i = 0; i <= 6; i+=2)
                vertices.Add(Middle(P.Vertices[10], P.Vertices[i], P.Vertices[i+2]));
            vertices.Add(Middle(P.Vertices[10], P.Vertices[8], P.Vertices[0]));
            for (int i = 0; i <= 7; i ++)
                vertices.Add(Middle(P.Vertices[i], P.Vertices[i+1], P.Vertices[i + 2]));
            vertices.Add(Middle(P.Vertices[8], P.Vertices[9], P.Vertices[0]));
            vertices.Add(Middle(P.Vertices[9], P.Vertices[0], P.Vertices[1]));
            for (int i = 1; i <= 7; i += 2)
                vertices.Add(Middle(P.Vertices[11], P.Vertices[i], P.Vertices[i + 2]));
            vertices.Add(Middle(P.Vertices[11], P.Vertices[9], P.Vertices[1]));


            var edges = new List<Edge3D>();

            int j = 0;
            for (int i = 0; i <= 3; i++)
            {
                edges.Add(new Edge3D(vertices[i], vertices[i+1]));
                edges.Add(new Edge3D(vertices[i], vertices[j+5]));
                j+=2;
            }
            edges.Add(new Edge3D(vertices[4], vertices[0]));
            edges.Add(new Edge3D(vertices[4], vertices[13]));
            for (int i = 5; i <= 13; i++)
                edges.Add(new Edge3D(vertices[i], vertices[i + 1]));
            edges.Add(new Edge3D(vertices[14], vertices[5]));

            j = 4;
            for (int i = 15; i <= 18; i++)
            {
                edges.Add(new Edge3D(vertices[i], vertices[i + 1]));
                edges.Add(new Edge3D(vertices[i], vertices[i - 5 - j]));
                j--;
            }
            edges.Add(new Edge3D(vertices[19], vertices[15]));
            edges.Add(new Edge3D(vertices[19], vertices[14]));

            var facets = new List<Facet3D>();
            // TODO: добавить поверхности когда они реально понадобятся
            /*var edges0 = new List<Edge3D>();
            edges0.Add();
            var facet0 = new Facet3D();*/

            return new Polyhedron(vertices, edges, facets);
        }
    }
}
