namespace AffineTransformations3D {
public class Edge3D {
  public Point3D Begin { get; set; }
  public Point3D End { get; set; }

  public Edge3D(Point3D begin, Point3D end) {
    Begin = begin;
    End = end;
  }

  public Vector3D ToVector3D() {
    double x = End.X - Begin.X;
    double y = End.Y - Begin.Y;
    double z = End.Z - Begin.Z;
    return new Vector3D(x, y, z);
  }
}
}
