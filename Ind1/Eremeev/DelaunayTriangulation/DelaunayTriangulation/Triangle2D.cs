using System.Collections.Generic;
using System.Linq;

namespace DelaunayTriangulation {
public class Triangle2D {
  public Point2D[] Vertices { get; private set; }
  public Point2D P1 { get; private set; }
  public Point2D P2 { get; private set; }
  public Point2D P3 { get; private set; }
  public Point2D CircumscribedCircleCenter { get; private set; }
  public int RadiusSquared { get; private set; }

  public Triangle2D(Point2D p1, Point2D p2, Point2D p3) {
    Vertices = new Point2D[3];

    P1 = Vertices[0] = p1;
    P2 = Vertices[1] = p2;
    P3 = Vertices[2] = p3;

    foreach (var vertex in Vertices) {
      vertex.AdjacentTriangles.Add(this);
    }

    SetCircumscribedCircle();
  }

  public bool IsPointInCircumscribedCircle(Point2D p) =>
      p.ComputeDistanceSquared(CircumscribedCircleCenter) < RadiusSquared;

  // https://www.cyberforum.ru/geometry/thread1190053.html?ysclid=la3zcot2u5108394910
  private void SetCircumscribedCircle() {
    int x12 = P1.X - P2.X;
    int x23 = P2.X - P3.X;
    int x31 = P3.X - P1.X;

    int y12 = P1.Y - P2.Y;
    int y23 = P2.Y - P3.Y;
    int y31 = P3.Y - P1.Y;

    int z1 = P1.X * P1.X + P1.Y * P1.Y;
    int z2 = P2.X * P2.X + P2.Y * P2.Y;
    int z3 = P3.X * P3.X + P3.Y * P3.Y;

    int zx = y12 * z3 + y23 * z1 + y31 * z2;
    int zy = x12 * z3 + x23 * z1 + x31 * z2;
    int z = x12 * y31 - y12 * x31;

    int a = -zx / (2 * z);
    int b = zy / (2 * z);

    CircumscribedCircleCenter = new Point2D(a, b);
    RadiusSquared = CircumscribedCircleCenter.ComputeDistanceSquared(P1);
  }
}
}
