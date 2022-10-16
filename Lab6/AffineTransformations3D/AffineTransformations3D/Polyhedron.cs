using System;
using System.Collections.Generic;
using System.Linq;

namespace AffineTransformations3D
{
using static AffineTransformationMatrices;

public class Polyhedron : ICloneable
{
    public List<Point3D> Vertices {
        get;
        set;
    }
    public List<Edge3D> Edges {
        get;
        set;
    }
    public List<Facet3D> Facets {
        get;
        set;
    }

    public Polyhedron(List<Point3D> vertices, List<Edge3D> edges, List<Facet3D> facets)
    {
        Vertices = vertices;
        Edges = edges;
        Facets = facets;
    }

    // TODO: мне надо будет доделать это
    // Не меняет исходную фигуру, создает копию
    public Polyhedron Project(ProjectionType projectionType = ProjectionType.Perspective)
    {
        var clone = Clone() as Polyhedron;
        var perspectiveProjectionMatrix = MakePerspectiveProjectionMatrix(1000);
        for (int i = 0; i < clone.Vertices.Count; i++)
        {
            var product =  clone.Vertices[i].ToVector3D() * perspectiveProjectionMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w, y / w, z / w);
            clone.Vertices[i].X = transformedPoint.X;
            clone.Vertices[i].Y = transformedPoint.Y;
        }
        return clone;
    }

    public void Translate(double dx, double dy, double dz)
    {
        var translationMatrix = MakeTranslationMatrix(dx, dy, dz);
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product =  Vertices[i].ToVector3D() * translationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w, y / w, z / w);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public void RotateX(double degrees)
    {
        var xRotationMatrix = MakeXRotationMatrix(degrees);
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product =  Vertices[i].ToVector3D() * xRotationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w, y / w, z / w);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public void RotateY(double degrees)
    {
        var xRotationMatrix = MakeYRotationMatrix(degrees);
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product =  Vertices[i].ToVector3D() * xRotationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w, y / w, z / w);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public void RotateXCenter(double degrees)
    {
        var xRotationMatrix = MakeXRotationMatrix(degrees);
        Point3D P = Centr();
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product = Vertices[i].ToVector3D(P) * xRotationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w + P.X, y / w + P.Y, z / w + P.Z);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public void RotateYCenter(double degrees)
    {
        var xRotationMatrix = MakeYRotationMatrix(degrees);
        Point3D P = Centr();
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product = Vertices[i].ToVector3D(P) * xRotationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w + P.X, y / w +P.Y, z / w+P.Z);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public void RotateZCenter(double degrees)
    {
        var xRotationMatrix = MakeZRotationMatrix(degrees);
        Point3D P = Centr();
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product = Vertices[i].ToVector3D(P) * xRotationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w + P.X, y / w + P.Y, z / w + P.Z);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public void Mashtab(double d)
    {
        var xRotationMatrix = MakeMashtabMatrix(d);
        Point3D P = Centr();
        for (int i = 0; i < Vertices.Count; i++)
        {
            var product = Vertices[i].ToVector3D(P) * xRotationMatrix;
            double x = product[0, 0];
            double y = product[0, 1];
            double z = product[0, 2];
            double w = product[0, 3];
            var transformedPoint = new Point3D(x / w + P.X, y / w + P.Y, z / w + P.Z);
            Vertices[i].X = transformedPoint.X;
            Vertices[i].Y = transformedPoint.Y;
        }
    }

    public Point3D Centr()
    {
        double x = 0;
        double y = 0;
        double z = 0;
        int i = 0;
        foreach (var item in Vertices)
        {
            x += item.X;
            y += item.Y;
            z += item.Z;
            i++;
        }
        return new Point3D(x / i, y / i, z / i);
    }

    public object Clone()
    {
        var vertices = Vertices.Select(v => v.Clone() as Point3D).ToList();
        var edges = new List<Edge3D>(Edges.Count);
        for (int i = 0; i < Edges.Count; i++)
        {
            Point3D begin = null, end = null;
            for (int j = 0; j < Vertices.Count; j++)
            {
                if (begin == null && Edges[i].Begin.Identifier == vertices[j].Identifier)
                {
                    begin = vertices[j];
                }
                if (end == null && Edges[i].End.Identifier == vertices[j].Identifier)
                {
                    end = vertices[j];
                }
                if (begin != null && end != null)
                {
                    edges.Add(new Edge3D(begin, end));
                    break;
                }
            }
        }
        // Поверхности пока не нужны в этой лабе. Это так, на будущее
        var facets = new List<Facet3D>(Facets.Count);
        return new Polyhedron(vertices, edges, facets);
    }
}
}
