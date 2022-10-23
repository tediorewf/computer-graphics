﻿using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AffineTransformations3D {
using static AffineTransformationMatrices;

public class Polyhedron : ICloneable {
  public List<Point3D> Vertices { get; set; }
  public List<Edge3D> Edges { get; set; }
  public List<Facet3D> Facets { get; set; }
  private Point3D _center;
  // Отложенная инициализация центра многогранника
  public Point3D Center {
    get {
      if (_center == null) {
        _center = ComputeCenter();
      }
      return _center;
    }
  }

  public Polyhedron(List<Point3D> vertices, List<Edge3D> edges,
                    List<Facet3D> facets) {
    Vertices = vertices;
    Edges = edges;
    Facets = facets;
  }

  public void SaveToFile(string path) {
    var sb = new StringBuilder();
    foreach (var v in Vertices) {
      sb.Append($"v {v.X} {v.Y} {v.Z}\n");
    }
    foreach (var e in Edges) {
      int beginIndex = Vertices.FindIndex(v => v == e.Begin);
      int endIndex = Vertices.FindIndex(v => v == e.End);
      sb.Append($"e {beginIndex} {endIndex}\n");
    }
    foreach (var facet in Facets) {
      sb.Append("facet\n");
      foreach (var p in facet.Points) {
        int pointIndex = Vertices.FindIndex(v => p == v);
        sb.Append($"vi {pointIndex}\n");
      }
      foreach (var edge in facet.Edges) {
        int edgeIndex = Edges.FindIndex(e => e == edge);
        sb.Append($"ei {edgeIndex}\n");
      }
      sb.Append("endfacet\n");
    }
    File.WriteAllText(path, sb.ToString());
  }

  public static Polyhedron ReadFromFile(string path) {
    var vertices = new List<Point3D>();
    var edges = new List<Edge3D>();
    var facets = new List<Facet3D>();
    Facet3D currentFacet = null;
    foreach (var line in File.ReadLines(path)) {
      var splited = line.Split();

      if (currentFacet != null) {
        if (splited[0] == "vi") {
          int vertexIndex = int.Parse(splited[1]);
          currentFacet.AddPoint(vertices[vertexIndex]);
        } else if (splited[0] == "ei") {
          int edgeIndex = int.Parse(splited[1]);
          currentFacet.AddEdge(edges[edgeIndex]);
        }
      } else if (splited[0] == "v") {
        double x = double.Parse(splited[1]);
        double y = double.Parse(splited[2]);
        double z = double.Parse(splited[3]);
        vertices.Add(new Point3D(x, y, z));
      } else if (splited[0] == "e") {
        int beginIndex = int.Parse(splited[1]);
        int endIndex = int.Parse(splited[2]);
        edges.Add(new Edge3D(vertices[beginIndex], vertices[endIndex]));
      } else if (splited[0] == "facet") {
        currentFacet = new Facet3D();
      } else if (splited[0] == "endfacet") {
        facets.Add(currentFacet);
        currentFacet = null;
      }
    }
    return new Polyhedron(vertices, edges, facets);
  }

  // TODO: мне надо будет доделать это
  // Не меняет исходную фигуру, создает копию
  public Polyhedron ComputeProjection(ProjectionType projectionType) {
    var clone = Clone() as Polyhedron;
    var perspectiveProjectionMatrix = projectionType.CreateMatrix();
    ApplyTransformationInplace(clone, perspectiveProjectionMatrix);
    return clone;
  }

  public void Translate(double dx, double dy, double dz) {
    var translationTransformation = MakeTranslationMatrix(dx, dy, dz);
    ApplyTransformationInplace(this, translationTransformation);
  }

  public void RotateAroundEdge(Edge3D edge, double degrees) {
    var rotationAroundEdgeCenteredTransformation =
        MakeRotateAroundEdgeMatrix(edge, degrees);
    ApplyTransformationInplace(this, rotationAroundEdgeCenteredTransformation);
  }

  public void RotateAxis(double xDegrees, double yDegrees, double zDegrees) {
    var axisRotationTransformation = MakeXRotationMatrix(xDegrees) *
                                     MakeYRotationMatrix(yDegrees) *
                                     MakeZRotationMatrix(zDegrees);
    ApplyTransformationInplace(this, axisRotationTransformation);
  }

  public void RotateAroundCenter(double degreesX, double degreesY,
                                 double degreesZ) {
    var centeredRotationTransformation =
        MakeTranslationMatrix(-Center.X, -Center.Y, -Center.Z) *
        MakeXYZRotationMatrix(degreesX, degreesY, degreesZ) *
        MakeTranslationMatrix(Center.X, Center.Y, Center.Z);
    ApplyTransformationInplace(this, centeredRotationTransformation);
  }

  public void Scale(double mx, double my, double mz) {
    var scalingTransformation = MakeScalingMatrix(mx, my, mz);
    ApplyTransformationInplace(this, scalingTransformation);
  }

  public void ScaleCentered(double factor) {
    var centeredScalingTransformation =
        MakeTranslationMatrix(-Center.X, -Center.Y, -Center.Z) *
        MakeScalingMatrix(factor, factor, factor) *
        MakeTranslationMatrix(Center.X, Center.Y, Center.Z);
    ApplyTransformationInplace(this, centeredScalingTransformation);
  }

  public void ReflectXY() {
    var xYReflectionTransformation = MakeXYReflectionMatrix();
    ApplyTransformationInplace(this, xYReflectionTransformation);
  }

  public void ReflectYZ() {
    var yZReflectionTransformation = MakeYZReflectionMatrix();
    ApplyTransformationInplace(this, yZReflectionTransformation);
  }

  public void ReflectZX() {
    var zXReflectionTransformation = MakeZXReflectionMatrix();
    ApplyTransformationInplace(this, zXReflectionTransformation);
  }

  public object Clone() {
    var vertices = Vertices.Select(v => v.Clone() as Point3D).ToList();
    var edges = new List<Edge3D>(Edges.Count);
        for (int i = 0; i < Edges.Count; i++) {
          Point3D begin = null, end = null;
          for (int j = 0; j < Vertices.Count; j++) {
            if (begin == null &&
                Edges[i].Begin.Identifier == vertices[j].Identifier) {
              begin = vertices[j];
            }
            if (end == null &&
                Edges[i].End.Identifier == vertices[j].Identifier) {
              end = vertices[j];
            }
            if (begin != null && end != null) {
              edges.Add(new Edge3D(begin, end));
              break;
            }
          }
        }
        // Поверхности пока не нужны в этой лабе. Это так, на будущее
        var facets = new List<Facet3D>(Facets.Count);
        return new Polyhedron(vertices, edges, facets);
  }

  private Point3D ComputeCenter() { return ComputeCenter(this); }

  private static Point3D ComputeCenter(Polyhedron polyhedron) {
    double x = 0;
    double y = 0;
    double z = 0;
    int pointsTotal = 0;
    foreach (var vertex in polyhedron.Vertices) {
      x += vertex.X;
      y += vertex.Y;
      z += vertex.Z;
      pointsTotal += 1;
    }
    return new Point3D(x / pointsTotal, y / pointsTotal, z / pointsTotal);
  }

  private static void ApplyTransformationInplace(Polyhedron polyhedron,
                                                 Matrix transformation) {
    for (int i = 0; i < polyhedron.Vertices.Count; i++) {
      TransformPointInplace(polyhedron.Vertices[i], transformation);
    }
    TransformPointInplace(polyhedron.Center, transformation);
  }

  private static void TransformPointInplace(Point3D point,
                                            Matrix transformation) {
    var product = point.ToVector3D() * transformation;
    double x = product[0, 0];
    double y = product[0, 1];
    double z = product[0, 2];
    double w = product[0, 3];
    var transformedPoint = new Point3D(x / w, y / w, z / w);
    point.X = transformedPoint.X;
    point.Y = transformedPoint.Y;
    point.Z = transformedPoint.Z;
  }
}
}
