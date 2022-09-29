using System;
using System.Collections.Generic;
using System.Linq;

namespace RasterAlgorithms {
public static class ListExtensions {
  public static ColoredPoint FetchLeftMost(this List<ColoredPoint> collection) {
    var leftMost = collection.First();
    for (int i = 1; i < collection.Count(); i++) {
      if (collection[i].X < leftMost.X) {
        leftMost = collection[i];
      }
    }
    collection.Remove(leftMost);
    return leftMost;
  }

  public static ColoredPoint
  FetchRightMost(this List<ColoredPoint> collection) {
    var rightMost = collection.First();
    for (int i = 1; i < collection.Count(); i++) {
      if (collection[i].X > rightMost.X) {
        rightMost = collection[i];
      }
    }
    collection.Remove(rightMost);
    return rightMost;
  }
}
}
