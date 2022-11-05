using System;
using System.Collections.Generic;
using System.Linq;

namespace DelaunayTriangulation {
public static class DelaunayTriangulationAlgorithm {
  // https://en.wikipedia.org/wiki/Bowyer%E2%80%93Watson_algorithm
  public static HashSet<Triangle2D> Triangulate(List<Point2D> points) {
    var supraTriangle = GenerateSupraTriangle(points);
    var triangulation = new HashSet<Triangle2D> { supraTriangle };

    foreach (var point in points) {
      var badTriangles = FindBadTriangles(point, triangulation);

      foreach (var triangle in badTriangles) {
        foreach (var vertex in triangle.Vertices) {
          vertex.AdjacentTriangles.Remove(triangle);
        }
      }

      triangulation.RemoveWhere(t => badTriangles.Contains(t));

      var polygon = FindPolygonalHoleBoundaries(badTriangles);

          foreach (var edge in polygon.Where(e => e.Begin != point &&
                                                  e.End != point)) {
        var triangle = new Triangle2D(point, edge.Begin, edge.End);
        triangulation.Add(triangle);
      }
    }

    triangulation.RemoveWhere(
        t => t.Vertices.Any(v => supraTriangle.Vertices.Contains(v)));

    return triangulation;
  }

  private static Triangle2D GenerateSupraTriangle(List<Point2D> points) {
    int maxX = points.Select(p => p.X).Max();
    int maxY = points.Select(p => p.Y).Max();

    var p1 = new Point2D(maxX / 2, -2 * maxX);
        var p2 = new Point2D(-2 * maxY, 2 * maxY);
        var p3 = new Point2D(2 * maxX + maxY, 2 * maxY);
        return new Triangle2D(p1, p2, p3);
  }

  private static HashSet<Triangle2D>
  FindBadTriangles(Point2D point, HashSet<Triangle2D> triangles) {
    var badTriangles =
        triangles.Where(t => t.IsPointInCircumscribedCircle(point));
    return new HashSet<Triangle2D>(badTriangles);
  }

  private static List<Edge2D>
  FindPolygonalHoleBoundaries(HashSet<Triangle2D> badTriangles) {
    var edges = new List<Edge2D>();
    foreach (var triangle in badTriangles) {
      edges.Add(new Edge2D(triangle.P1, triangle.P2));
      edges.Add(new Edge2D(triangle.P2, triangle.P3));
      edges.Add(new Edge2D(triangle.P3, triangle.P1));
    }
    var polygonalHoleBoundaries =
        edges.GroupBy(e => e).Where(e => e.Count() == 1).Select(e => e.First());
    return polygonalHoleBoundaries.ToList();
  }
}
}
