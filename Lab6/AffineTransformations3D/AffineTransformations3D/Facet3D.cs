using System.Collections.Generic;

namespace AffineTransformations3D {
public class Facet3D {
  List<Point3D> Points { get; set; }
  List<Edge3D> Edges { get; set; }

  public Facet3D(List<Point3D> points, List<Edge3D> edges) {
    Points = points;
    Edges = edges;
  }
}
}
