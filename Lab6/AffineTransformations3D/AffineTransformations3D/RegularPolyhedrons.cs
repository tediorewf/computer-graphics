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
        var facet0 = new Facet3D(new List<Point3D> {p1,p4,p6,p7 },new List<Edge3D> { edge3, edge4, edge11, edge9 });
        var facet1 = new Facet3D(new List<Point3D> {p0,p2,p3,p5 },new List<Edge3D> { edge2, edge1, edge5, edge7 });
        var facet2 = new Facet3D(new List<Point3D> {p0,p3,p4,p1 }, new List<Edge3D> { edge2, edge8, edge3, edge0 });
        var facet3 = new Facet3D(new List<Point3D> {p5,p6,p7,p2 }, new List<Edge3D> { edge10, edge11, edge6, edge5 });
        var facet4 = new Facet3D(new List<Point3D> {p3,p4,p7,p5 }, new List<Edge3D> { edge8, edge9, edge10, edge7 });
        var facet5 = new Facet3D(new List<Point3D> {p0,p1,p2,p6 }, new List<Edge3D> { edge0, edge4, edge6, edge1 });

        facets.Add(facet0);
        facets.Add(facet1);
        facets.Add(facet2);
        facets.Add(facet3);
        facets.Add(facet4);
        facets.Add(facet5);

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

        var facet0 = new Facet3D(new List<Point3D> { vertices[0], vertices[1], vertices[3] }, new List<Edge3D> { edges[0], edges[4], edges[2] });
        var facet1 = new Facet3D(new List<Point3D> { vertices[0], vertices[3], vertices[2] }, new List<Edge3D> { edges[2], edges[5], edges[1] });
        var facet2 = new Facet3D(new List<Point3D> { vertices[1], vertices[2], vertices[3] }, new List<Edge3D> { edges[3], edges[4], edges[5] });
        var facet3 = new Facet3D(new List<Point3D> { vertices[0], vertices[1], vertices[2] }, new List<Edge3D> { edges[1], edges[0], edges[3] });

        facets.Add(facet0);
        facets.Add(facet1);
        facets.Add(facet2);
        facets.Add(facet3);

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

        var facet0 = new Facet3D(new List<Point3D> { vertices[0], vertices[1], vertices[2] },new List<Edge3D> { edges[0], edges[1], edges[4] });
        var facet1 = new Facet3D(new List<Point3D> { vertices[0], vertices[1], vertices[5] }, new List<Edge3D> { edges[0], edges[3], edges[6] });
        var facet2 = new Facet3D(new List<Point3D> { vertices[0], vertices[3], vertices[5] }, new List<Edge3D> { edges[3], edges[2], edges[10] });
        var facet3 = new Facet3D(new List<Point3D> { vertices[0], vertices[2], vertices[3] }, new List<Edge3D> { edges[1], edges[2], edges[7] });
        var facet4 = new Facet3D(new List<Point3D> { vertices[4], vertices[1], vertices[2] }, new List<Edge3D> { edges[4], edges[5], edges[8] });
        var facet5 = new Facet3D(new List<Point3D> { vertices[4], vertices[1], vertices[5] }, new List<Edge3D> { edges[5], edges[6], edges[11] });
        var facet6 = new Facet3D(new List<Point3D> { vertices[4], vertices[3], vertices[5] }, new List<Edge3D> { edges[9], edges[10], edges[11] });
        var facet7 = new Facet3D(new List<Point3D> { vertices[4], vertices[2], vertices[3] }, new List<Edge3D> { edges[7], edges[8], edges[9] });

        facets.Add(facet0);
        facets.Add(facet1);
        facets.Add(facet2);
        facets.Add(facet3);
        facets.Add(facet4);
        facets.Add(facet5);
        facets.Add(facet6);
        facets.Add(facet7);

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
        var facets = new List<Facet3D>();

        for (int i = 0; i <= 7; i++)
        {
            edges.Add(new Edge3D(vertices[i], vertices[i + 1]));
            edges.Add(new Edge3D(vertices[i], vertices[i + 2]));
        }
        edges.Add(new Edge3D(vertices[8], vertices[9]));
        edges.Add(new Edge3D(vertices[8], vertices[0]));
        edges.Add(new Edge3D(vertices[9], vertices[0]));
        edges.Add(new Edge3D(vertices[9], vertices[1]));

        for (int i = 0; i <= 17; i++)
            facets.Add(new Facet3D(new List<Point3D> { edges[i].Begin, edges[i + 2].Begin, edges[i + 2].End },new List<Edge3D> { edges[i], edges[i + 1], edges[i + 2] }));
        facets.Add(new Facet3D(new List<Point3D> { edges[18].Begin, edges[0].Begin, edges[0].End }, new List<Edge3D> { edges[18], edges[19], edges[0] }));
        facets.Add(new Facet3D(new List<Point3D> { edges[19].Begin, edges[1].Begin, edges[1].End }, new List<Edge3D> { edges[19], edges[0], edges[1] }));


        for (int i = 0; i <= 8; i += 2)
            edges.Add(new Edge3D(vertices[10], vertices[i]));

        facets.Add(new Facet3D(new List<Point3D> { vertices[10], vertices[0], vertices[2] }, new List<Edge3D> { edges[1], edges[20], edges[21] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[10], vertices[2], vertices[4] }, new List<Edge3D> { edges[5], edges[21], edges[22] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[10], vertices[4], vertices[6] }, new List<Edge3D> { edges[22], edges[9], edges[23] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[10], vertices[6], vertices[8] }, new List<Edge3D> { edges[13], edges[23], edges[24] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[10], vertices[8], vertices[0] }, new List<Edge3D> { edges[17], edges[20], edges[24] }));

        for (int i = 1; i <= 9; i += 2)
            edges.Add(new Edge3D(vertices[11], vertices[i]));


        facets.Add(new Facet3D(new List<Point3D> { vertices[11], vertices[1], vertices[3] }, new List<Edge3D> { edges[3], edges[25], edges[26] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[11], vertices[3], vertices[5] }, new List<Edge3D> { edges[7], edges[26], edges[27] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[11], vertices[5], vertices[7] }, new List<Edge3D> { edges[11], edges[27], edges[28] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[11], vertices[7], vertices[9] }, new List<Edge3D> { edges[15], edges[28], edges[29] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[11], vertices[9], vertices[1] }, new List<Edge3D> { edges[19], edges[25], edges[29] }));

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
        var facets = new List<Facet3D>();

        int j = 0;
        for (int i = 0; i <= 3; i++)
        {
            edges.Add(new Edge3D(vertices[i], vertices[i+1]));
            edges.Add(new Edge3D(vertices[i], vertices[j+5]));
            j+=2;
        }
        edges.Add(new Edge3D(vertices[4], vertices[0]));
        edges.Add(new Edge3D(vertices[4], vertices[13]));

        facets.Add(new Facet3D(new List<Point3D> { vertices[0], vertices[1], vertices[2], vertices[3], vertices[4] }, new List<Edge3D> { edges[0], edges[2], edges[4], edges[6], edges[8] }));

        for (int i = 5; i <= 13; i++)
            edges.Add(new Edge3D(vertices[i], vertices[i + 1]));
        edges.Add(new Edge3D(vertices[14], vertices[5]));

        facets.Add(new Facet3D(new List<Point3D> { vertices[0], vertices[1], vertices[7], vertices[6], vertices[5] }, new List<Edge3D> { edges[0], edges[3], edges[11], edges[10], edges[1] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[1], vertices[2], vertices[9], vertices[8], vertices[7] }, new List<Edge3D> { edges[2], edges[5], edges[13], edges[12], edges[3] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[2], vertices[3], vertices[11], vertices[10], vertices[9] }, new List<Edge3D> { edges[4], edges[7], edges[15], edges[14], edges[5] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[3], vertices[4], vertices[13], vertices[12], vertices[1] }, new List<Edge3D> { edges[6], edges[9], edges[17], edges[16], edges[7] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[4], vertices[0], vertices[5], vertices[14], vertices[3] }, new List<Edge3D> { edges[8], edges[1], edges[19], edges[18], edges[9] }));

        j = 4;
        for (int i = 15; i <= 18; i++)
        {
            edges.Add(new Edge3D(vertices[i], vertices[i + 1]));
            edges.Add(new Edge3D(vertices[i], vertices[i - 5 - j]));
            j--;
        }
        edges.Add(new Edge3D(vertices[19], vertices[15]));
        edges.Add(new Edge3D(vertices[19], vertices[14]));

        facets.Add(new Facet3D(new List<Point3D> { vertices[15], vertices[6], vertices[5], vertices[14], vertices[19] }, new List<Edge3D> { edges[21], edges[10], edges[19], edges[29], edges[28] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[19], vertices[14], vertices[13], vertices[12], vertices[18] }, new List<Edge3D> { edges[29], edges[18], edges[17], edges[27], edges[26] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[18], vertices[12], vertices[11], vertices[10], vertices[17] }, new List<Edge3D> { edges[27], edges[16], edges[15], edges[25], edges[24] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[17], vertices[10], vertices[9], vertices[8], vertices[16] }, new List<Edge3D> { edges[25], edges[14], edges[13], edges[23], edges[22] }));
        facets.Add(new Facet3D(new List<Point3D> { vertices[16], vertices[8], vertices[7], vertices[6], vertices[15] }, new List<Edge3D> { edges[23], edges[12], edges[11], edges[21], edges[20] }));

        facets.Add(new Facet3D(new List<Point3D> { vertices[15], vertices[16], vertices[17], vertices[18], vertices[19], }, new List<Edge3D> { edges[20], edges[22], edges[24], edges[26], edges[28] }));

        return new Polyhedron(vertices, edges, facets);
    }
}
}
