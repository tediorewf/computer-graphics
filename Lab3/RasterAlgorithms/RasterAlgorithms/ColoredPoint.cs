using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RasterAlgorithms {
public struct ColoredPoint {
  public int X { get; set; }
  public int Y { get; set; }
  public Color Color { get; set; }

  public ColoredPoint(int x, int y, Color color) {
    X = x;
    Y = y;
    Color = color;
  }
}
}
