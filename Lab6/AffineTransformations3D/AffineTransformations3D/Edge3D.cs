using System;

namespace AffineTransformations3D {
public class Edge3D : IIdentifiable<long>, IEquatable<Edge3D> {
  private static long nextIdentidier = 0;
  public Point3D Begin { get; set; }
  public Point3D End { get; set; }
  private long identifier;
  public long Identifier => identifier;

  public Edge3D(Point3D begin, Point3D end, long? identifier = null) {
    Begin = begin;
    End = end;
    if (identifier == null) {
      this.identifier = nextIdentidier;
      nextIdentidier += 1;
    } else {
      this.identifier = identifier.Value;
    }
  }

  public Vector3D ToVector3D() {
    double x = End.X - Begin.X;
    double y = End.Y - Begin.Y;
    double z = End.Z - Begin.Z;
    return new Vector3D(x, y, z);
  }

  public bool Equals(Edge3D other) => Identifier == other.Identifier;

  public override int GetHashCode() => Identifier.GetHashCode();
}
}
