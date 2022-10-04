using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations {
class Matrix {
  private int x;
  private int y;
  private double[,] arr;
  public double X() { return x; }
  public double Y() { return x; }
  public Matrix(int x, int y, double[,] arr) {
    this.x = x;
    this.y = y;
    this.arr = arr;
  }
  public double[,] Arr() { return arr; }
  public Matrix Mul(Matrix M) {
    double[,] A = new double[x, M.y];
    for (int i = 0; i < x; i++)
      for (int j = 0; j < M.y; j++) {
        double S = 0;
        for (int r = 0; r < y; r++)
          S += arr[i, r] * M.arr[r, j];
        A[i, j] = S;
      }
    return new Matrix(x, M.y, A);
  }
}
}
