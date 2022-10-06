using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AffineTransformations {
public class Polygon {
  public List<Edge> Edges { get; private set; }
  public Point Center {
    get {
      int verticesCount = 0;
      int x = 0, y = 0;
      Edges.ForEach(e => {
        x += e.Begin.Y;
        y += e.Begin.Y;
        verticesCount += 1;
      });
      return new Point(x / verticesCount, y / verticesCount);
    }
  }

  public Polygon(List<Edge> edges) { Edges = edges; }

  public void ToRed() {
    foreach (var item in Edges)
      item.Red = true;
  }
  public void ToUsual() {
    foreach (var item in Edges)
      item.Red = false;
  }
  // TODO: реализовать методы для полигона. При необходимости реализовать методы
  // для ребра и вызавать в полигоне (например, для поворота полигона нужно
  // реализовать поворот ребра).
}
}
