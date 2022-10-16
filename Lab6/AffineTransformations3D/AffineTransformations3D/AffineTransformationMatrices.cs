using System;

namespace AffineTransformations3D {
public static class AffineTransformationMatrices {
  public static Matrix MakeXRotationMatrix(double degrees) {
    double radians = degrees * Math.PI / 180;

    double angleCos = Math.Cos(radians);
    double angleSin = Math.Sin(radians);

    var elements = new double[,] { { 1, 0, 0, 0 },
                                   { 0, angleCos, -angleSin, 0 },
                                   { 0, angleSin, angleCos, 0 },
                                   { 0, 0, 0, 1 } };
    return new Matrix(elements);
  }

  public static Matrix MakeYRotationMatrix(double degrees) {
    double radians = degrees * Math.PI / 180;

    double angleCos = Math.Cos(radians);
    double angleSin = Math.Sin(radians);

    var elements = new double[,] { { angleCos, 0, angleSin, 0 },
                                   { 0, 1, 0, 0 },
                                   { -angleSin, 0, angleCos, 0 },
                                   { 0, 0, 0, 1 } };
    return new Matrix(elements);
  }

  public static Matrix MakeZRotationMatrix(double degrees) {
    double radians = degrees * Math.PI / 180;

    double angleCos = Math.Cos(radians);
    double angleSin = Math.Sin(radians);

    var elements = new double[,] { { angleCos, -angleSin, 0, 0 },
                                   { angleSin, angleCos, 0, 0 },
                                   { 0, 0, 1, 0 },
                                   { 0, 0, 0, 1 } };
    return new Matrix(elements);
  }

  public static Matrix MakeMashtabMatrix(double d) {

    var elements = new double[,] {
      { d, 0, 0, 0 }, { 0, d, 0, 0 }, { 0, 0, d, 0 }, { 0, 0, 0, 1 }
    };
    return new Matrix(elements);
  }

  public static Matrix MakeTranslationMatrix(double dx, double dy, double dz) {
    var elements = new double[,] {
      { 1, 0, 0, dx }, { 0, 1, 0, dy }, { 0, 0, 1, dz }, { 0, 0, 0, 1 }
    };
    return new Matrix(elements);
  }

  public static Matrix MakePerspectiveProjectionMatrix(double c) {
    var elements = new double[,] {
      { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 1 / c }, { 0, 0, 0, 1 }
    };
    return new Matrix(elements);
  }

  public static Matrix MakeAxonometricProjectionMatrix() {
    // TODO: доделать (пока не нашел подходящую матрицу)
    var elements = new double[,] {
      { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 1 }, { 0, 0, 0, 1 }
    };
    return new Matrix(elements);
  }
}
}
