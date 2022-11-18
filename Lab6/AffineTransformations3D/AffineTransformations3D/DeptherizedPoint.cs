using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D {
public class DeptherizedPoint {
  public int X { get; set; }
  public int Y { get; set; }
  public double Depth { get; set; }

  public DeptherizedPoint(int x, int y, double depth) {
    X = x;
    Y = y;
    Depth = depth;
  }

  public static DeptherizedPoint FromPoint3D(Point3D point3D) {
    var p = point3D.ToPoint();
    return new DeptherizedPoint(p.X, p.Y, point3D.Z);
  }
}
}
