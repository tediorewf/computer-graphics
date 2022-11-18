﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D {
internal class Camera {
  public Point3D Position { get; set; }
  public double DegreesX { get; set; }
  public double DegreesY { get; set; }
  public double DegreesZ { get; set; }

  public Camera(double x, double y, double z) {
    Position = new Point3D(x, y, z);
    DegreesX = 0;
    DegreesY = 0;
    DegreesZ = 0;
  }

  public void Translate(double dx, double dy, double dz) {
    Position.X += dx;
    Position.Y += dy;
    Position.Z += dz;
  }

  public void Rotate(double xDelta, double yDelta, double zDelta) {
    DegreesX += xDelta;
    DegreesY += yDelta;
    DegreesZ += zDelta;
  }

  public Polyhedron Project(Polyhedron polyhedron,
                            ProjectionType projectionType) {
    var copyPolyhedron = polyhedron.Copy();
    // copyPolyhedron.Translate(-Position.X, -Position.Y, -Position.Z);
    // copyPolyhedron.Rotate
    return copyPolyhedron.ComputeProjection(projectionType);
  }
}
}
