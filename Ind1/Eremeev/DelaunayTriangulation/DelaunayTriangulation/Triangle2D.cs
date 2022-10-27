using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation {
public class Triangle2D {
  public Edge2D A { get; set; }
  public Edge2D B { get; set; }
  public Edge2D C { get; set; }

  public Triangle2D(Edge2D a, Edge2D b, Edge2D c) {
    A = a;
    B = b;
    C = c;
  }
}
}
