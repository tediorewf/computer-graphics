namespace AffineTransformations3D {
public class Vector3D {
  public double X { get; set; }
  public double Y { get; set; }
  public double Z { get; set; }
  public double W { get; set; }

  public Vector3D(double x, double y, double z, double w = 0) {
    X = x;
    Y = y;
    Z = z;
    W = w;
  }

  public Matrix ToMatrix() {
    var elements = new double[,] { { X, Y, Z, W } };
    return new Matrix(elements);
  }
}
}
