using System;

namespace CornishRoom {
public class Sphere : Primitive {
  private double epsilon;

  public Vector3D Center { get; }
  public double Radius { get; }

  public Sphere(Material material, Vector3D center, double radius,
                double epsilon = 0.001)
      : base(material) {
    this.epsilon = epsilon;

    Center = center;
    Radius = radius;
  }

  public override Tuple<double, double> Intersect(Vector3D origin,
                                                  Vector3D direction) {
    var oc = origin - Center;
    double k1 = direction.ComputeDotProduct(direction);
    double k2 = 2 * oc.ComputeDotProduct(direction);
    double k3 = oc.ComputeDotProduct(oc) - Radius * Radius;

    double discriminant = k2 * k2 - 4 * k1 * k3;
    if (discriminant < epsilon) {
      return Tuple.Create(double.MaxValue, double.MaxValue);
    }

    double t1 = (-k2 + Math.Sqrt(discriminant)) / (2 * k1);
    double t2 = (-k2 - Math.Sqrt(discriminant)) / (2 * k1);

    return Tuple.Create(t1, t2);
  }

  public override Vector3D ComputeNormal(Vector3D point) {
    var normal = point - Center;
    return normal.Normalize();
  }
}
}
