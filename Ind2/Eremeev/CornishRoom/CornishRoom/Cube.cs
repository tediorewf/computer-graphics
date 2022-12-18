using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom {
public class Cube : Primitive {
  private Vector3D position;
  private double edgeLength;
  private double epsilon;

  public Vector3D[] Vectices { get; }

  public Cube(Vector3D position, double edgeLength, Material material,
              double epsilon = 0.001)
      : base(material) {
    this.position = position;
    this.edgeLength = edgeLength;
    this.epsilon = epsilon;
  }

  public override Tuple<double, double> Intersect(Vector3D origin,
                                                  Vector3D direction) {
    return Tuple.Create(double.MaxValue, double.MaxValue);
  }

  public override Vector3D ComputeNormal(Vector3D point) {
    throw new NotImplementedException();
  }
}
}
