using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RasterAlgorithms {
using FastBitmap;

public class TriangleRasterisationException : RasterAlgorithmException {
  public TriangleRasterisationException(string message) : base(message) {}
}

public class NearestOrdinateComparer : IComparer<ColoredPoint> {
  public int Compare(ColoredPoint lhs, ColoredPoint rhs) {
    return lhs.Y.CompareTo(rhs.Y);
  }
}

public class ColoredPointsGroupPair {
  public List<ColoredPoint> Left { get; }
  public List<ColoredPoint> Right { get; }

  public ColoredPointsGroupPair(List<ColoredPoint> left,
                                List<ColoredPoint> right) {
    Left = left;
    Right = right;
  }
}

public static class TriangleRasterisationAlgorithm {
  private const int IndexVertex1 = 0, IndexVertex2 = 1, IndexVertex3 = 2;

  public static void RasteriseTriangle(this Bitmap drawingSurface,
                                       ColoredPoint v1, ColoredPoint v2,
                                       ColoredPoint v3) {
    EnsureVerticesAreDifferent(v1, v2, v3);

    var vertices = new ColoredPoint[] { v1, v2, v3 };
    Array.Sort(vertices, new NearestOrdinateComparer());

    using (var fastDrawingsurface = new FastBitmap(drawingSurface)) {
      var pointsGroupPairs =
          MakeBresenhamMovement(vertices[IndexVertex1], vertices[IndexVertex2])
              .Concat(MakeBresenhamMovement(vertices[IndexVertex2],
                                            vertices[IndexVertex3]))
              .Zip(MakeBresenhamMovement(vertices[IndexVertex1],
                                         vertices[IndexVertex3]),
                   (pointsGroupLeft, pointsGroupRight) =>
                       new ColoredPointsGroupPair(pointsGroupLeft,
                                                  pointsGroupRight));
      foreach (var pointsGroupPair in pointsGroupPairs) {
        var pointsGroupLeft = pointsGroupPair.Left;
        var pointsGroupRight = pointsGroupPair.Right;

        var leftSideMostRightPoint = pointsGroupLeft.FetchRightMost();
        var rightSideMostLeftPoint = pointsGroupRight.FetchLeftMost();

        int coordinateDeltaX =
            Math.Abs(leftSideMostRightPoint.X - rightSideMostLeftPoint.X);
        fastDrawingsurface[leftSideMostRightPoint.X, leftSideMostRightPoint.Y] =
            leftSideMostRightPoint.Color;
        int y = leftSideMostRightPoint.Y;
        for (int x = leftSideMostRightPoint.X + 1; x < rightSideMostLeftPoint.X;
             x += 1) {
          var currentColor = ApplyLinearInterpolation(
              leftSideMostRightPoint.Color, rightSideMostLeftPoint.Color, x,
              rightSideMostLeftPoint.X, coordinateDeltaX);
          fastDrawingsurface[x, y] = currentColor;
        }
        for (int x = rightSideMostLeftPoint.X + 1; x < leftSideMostRightPoint.X;
             x += 1) {
          var currentColor = ApplyLinearInterpolation(
              leftSideMostRightPoint.Color, rightSideMostLeftPoint.Color, x,
              rightSideMostLeftPoint.X, coordinateDeltaX);
          fastDrawingsurface[x, y] = currentColor;
        }
        fastDrawingsurface[rightSideMostLeftPoint.X, rightSideMostLeftPoint.Y] =
            rightSideMostLeftPoint.Color;

        foreach (var pointGroupLeft in pointsGroupLeft) {
          fastDrawingsurface[pointGroupLeft.X, pointGroupLeft.Y] =
              pointGroupLeft.Color;
        }
        foreach (var pointGroupRight in pointsGroupRight) {
          fastDrawingsurface[pointGroupRight.X, pointGroupRight.Y] =
              pointGroupRight.Color;
        }
      }
    }
  }

  private static void EnsureVerticesAreDifferent(ColoredPoint v1,
                                                 ColoredPoint v2,
                                                 ColoredPoint v3) {
    if (v1.X == v2.X && v1.Y == v2.Y || v2.X == v3.X && v2.Y == v3.Y) {
      throw new TriangleRasterisationException(
          "Есть вершины с совпадающими координатами");
    }

    if (v1.Color == v2.Color || v2.Color == v3.Color) {
      throw new TriangleRasterisationException(
          "Есть вершины с совпадающими цветами");
    }
  }

  private static IEnumerable<List<ColoredPoint>>
  MakeBresenhamMovement(ColoredPoint v1, ColoredPoint v2) {
    int x1 = v1.X, x2 = v2.X;
    int y1 = v1.Y, y2 = v2.Y;
    Color c1 = v1.Color, c2 = v2.Color;

    int diffX = x2 - x1;
    int diffY = y2 - y1;

    int growthDirectionX = diffX > 0 ? 1 : -1;
    int growthDirectionY = diffY > 0 ? 1 : -1;

    int deltaX = Math.Abs(diffX);
    int deltaY = Math.Abs(diffY);

    int axisGrowthDirection = deltaX > deltaY ? 1 : -1;

    int decision = 2 * axisGrowthDirection * (deltaY - deltaX);

    int refereeY = Math.Max(axisGrowthDirection, 0);
    int refereeX = Math.Min(axisGrowthDirection, 0);

    int interpolationEndCoordinate = x2 * refereeY - y2 * refereeX;
    int interpolationCoordinateDelta = deltaX * refereeY - deltaY * refereeX;

    int previousY = y1;

    var currentPointsQueue = new Queue<ColoredPoint>();

    List<ColoredPoint> pointsGroup;

    while (x1 != x2 || y1 != y2) {
      var colorCurrent = ApplyLinearInterpolation(
          c1, c2, x1 * refereeY - y1 * refereeX, interpolationEndCoordinate,
          interpolationCoordinateDelta);
      var pointCurrent = new ColoredPoint(x1, y1, colorCurrent);

      currentPointsQueue.Enqueue(pointCurrent);

      if (pointCurrent.Y != previousY) {
        previousY = pointCurrent.Y;
        pointsGroup = new List<ColoredPoint>();
        while (currentPointsQueue.Count > 1) {
          pointsGroup.Add(currentPointsQueue.Dequeue());
        }
        yield return pointsGroup;
      }

      x1 += growthDirectionX * refereeY;
      y1 -= growthDirectionY * refereeX;

      if (decision < 0) {
        decision += 2 * (deltaY * refereeY - deltaX * refereeX);
      } else {
        y1 += growthDirectionY * refereeY;
        x1 -= growthDirectionX * refereeX;
        decision += 2 * axisGrowthDirection * (deltaY - deltaX);
      }
    }

    pointsGroup = new List<ColoredPoint>();
    while (currentPointsQueue.Count > 0) {
      pointsGroup.Add(currentPointsQueue.Dequeue());
    }
    if (pointsGroup.Count > 0) {
      yield return pointsGroup;
    }
  }

  private static Color ApplyLinearInterpolation(Color beginColor,
                                                Color endColor,
                                                int currentCoordinate,
                                                int endCoordinate,
                                                int coordinateDelta) {
    int coordinateDeltaCurrent = Math.Abs(currentCoordinate - endCoordinate);
    int red = InterpolateColorComponent(
        beginColor.R, endColor.R, coordinateDelta, coordinateDeltaCurrent);
    int green = InterpolateColorComponent(
        beginColor.G, endColor.G, coordinateDelta, coordinateDeltaCurrent);
    int blue = InterpolateColorComponent(
        beginColor.B, endColor.B, coordinateDelta, coordinateDeltaCurrent);
    var interpolatedColor = Color.FromArgb(red, green, blue);
    return interpolatedColor;
  }

  private static int InterpolateColorComponent(int colorComponentBegin,
                                               int colorComponentEnd,
                                               int coordinateDelta,
                                               int coordinateDeltaCurrent) {
    return colorComponentBegin * coordinateDeltaCurrent / coordinateDelta +
           colorComponentEnd * (coordinateDelta - coordinateDeltaCurrent) /
               coordinateDelta;
  }
}
}
