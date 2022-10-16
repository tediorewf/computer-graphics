using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D {
public static class RegularPolyhedrons {
  /* Создание тетраэдра
   * По-хорошему надо тетраэдр на снове куба делать, так проще наверное.
   * Но у меня уже не было времени заморачиваться, поэтому точки захардкожены.
   */
  public static Polyhedron MakeGeksahedron() {
    var vertices = new List<Point3D>();
    var p0 = new Point3D(0, 0, 0);
    var p1 = new Point3D(0, 0, 300);
    var p2 = new Point3D(0, 300, 0);
    var p3 = new Point3D(300, 0, 0);
    var p4 = new Point3D(300, 0, 300);
    var p5 = new Point3D(300, 300, 0);
    var p6 = new Point3D(0, 300, 300);
    var p7 = new Point3D(300, 300, 300);
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
  public static Polyhedron MakeTetrahedron() {
    var vertices = new List<Point3D>();
    var p0 = new Point3D(100, 100, 100);
    var p1 = new Point3D(0, 200, 500);
    var p2 = new Point3D(300, -100, 400);
    var p3 = new Point3D(400, 200, 100);
    vertices.Add(p0);
    vertices.Add(p1);
    vertices.Add(p2);
    vertices.Add(p3);

    var edges = new List<Edge3D>();
    var edge0 = new Edge3D(p0, p1);
    var edge1 = new Edge3D(p0, p2);
    var edge2 = new Edge3D(p0, p3);
    var edge3 = new Edge3D(p1, p2);
    var edge4 = new Edge3D(p1, p3);
    var edge5 = new Edge3D(p2, p3);
    edges.Add(edge0);
    edges.Add(edge1);
    edges.Add(edge2);
    edges.Add(edge3);
    edges.Add(edge4);
    edges.Add(edge5);

    var facets = new List<Facet3D>();
    // TODO: добавить поверхности когда они реально понадобятся
    /*var edges0 = new List<Edge3D>();
    edges0.Add();
    var facet0 = new Facet3D();*/

    return new Polyhedron(vertices, edges, facets);
  }
  public static Polyhedron MakeOktahedron() {
    var vertices = new List<Point3D>();
    var p1 = new Point3D(0, 0, 200);
    var p2 = new Point3D(200, 0, 200);
    var p3 = new Point3D(200, 200, 200);
    var p4 = new Point3D(0, 200, 200);
    var p5 = new Point3D(100, 100, 400);
    var p6 = new Point3D(100, 100, 0);
    vertices.Add(p1);
    vertices.Add(p2);
    vertices.Add(p3);
    vertices.Add(p4);
    vertices.Add(p5);
    vertices.Add(p6);

    var edges = new List<Edge3D>();
    var edge1 = new Edge3D(p1, p2);
    var edge2 = new Edge3D(p2, p3);
    var edge3 = new Edge3D(p3, p4);
    var edge4 = new Edge3D(p4, p1);
    var edge5 = new Edge3D(p1, p5);
    var edge6 = new Edge3D(p2, p5);
    var edge7 = new Edge3D(p3, p5);
    var edge8 = new Edge3D(p4, p5);
    var edge9 = new Edge3D(p1, p6);
    var edge10 = new Edge3D(p2, p6);
    var edge11 = new Edge3D(p3, p6);
    var edge12 = new Edge3D(p4, p6);
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
    edges.Add(edge12);

    var facets = new List<Facet3D>();
    // TODO: добавить поверхности когда они реально понадобятся
    /*var edges0 = new List<Edge3D>();
    edges0.Add();
    var facet0 = new Facet3D();*/

    return new Polyhedron(vertices, edges, facets);
  }
}
}
