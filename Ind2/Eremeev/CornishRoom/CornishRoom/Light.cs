using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom {
public class Light {
  public Vector3D Position { get; }
  public double Intensivity { get; }

  public Light(Vector3D position, double intensivity) {
    Position = position;
    Intensivity = intensivity;
  }
}
}
