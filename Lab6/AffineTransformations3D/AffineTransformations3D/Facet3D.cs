using System.Collections.Generic;

namespace AffineTransformations3D {
public class Facet3D {
  List<Edge3D> Edges { get; set; }

  public Facet3D(List<Edge3D> edges) { Edges = edges; }
}
}
