using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    using static TransformationHelper;

    public class Generatrix3D
    {
        public AxisType RotationAxis { get; set; }
        public List<Point3D> Points { get; private set; }
        public List<Edge3D> Edges { get; private set; }

        public Generatrix3D(List<Point3D> points, AxisType rotationAxis)
        {
            Points = points;
            Edges = ConnectPoints(points);
            RotationAxis = rotationAxis;
        }

        private static List<Edge3D> ConnectPoints(List<Point3D> points)
        {
            var edges = new List<Edge3D>();
            for (int i = 0; i < points.Count - 1; i++)
            {
                edges.Add(new Edge3D(points[i], points[i + 1]));
            }
            return edges;
        }

        /// <summary>
        /// Создает тело вращения на основе образующей
        /// </summary>
        /// <param name="partitionsCount">Число разбиений</param>
        /// <returns>Многогранник, приближенно представляющий тело вращения</returns>
        public Polyhedron CreateRotationBody(int partitionsCount)
        {
            EnsurePartitionsCountIsPositive(partitionsCount);
            var generatrices = GenerateSkeletonBase(partitionsCount);
            return ConnectGeneratrices(generatrices);
        }

        private Generatrix3D[] GenerateSkeletonBase(int partitionsCount)
        {
            return GenerateSkeletonBase(this, partitionsCount);
        }

        private static Generatrix3D[] GenerateSkeletonBase(Generatrix3D beginGeneratrix, int partitionsCount)
        {
            double degreesPerPartition = 360 / partitionsCount;
            var generatrices = new Generatrix3D[partitionsCount];
            generatrices[0] = beginGeneratrix;
            for (int i = 1; i < partitionsCount; i++)
            {
                generatrices[i] = generatrices[i - 1].Rotate(degreesPerPartition);
            }
            return generatrices;
        }

        private Generatrix3D Rotate(double degrees)
        {
            var rotated = Copy();
            TransformMultiplePointsInplace(rotated.Points, RotationAxis.CreateRotationMatrix(degrees));
            return rotated;
        }

        private static Polyhedron ConnectGeneratrices(Generatrix3D[] generatrices)
        {
            var vertices = new List<Point3D>();
            var edges = new List<Edge3D>();
            var facets = new List<Facet3D>();

            foreach (var g in generatrices)
            {
                edges.AddRange(g.Edges);
                vertices.AddRange(g.Points);
            }

            int i = 0;
            for (; i < generatrices.Length - 1; i++)
            {
                MakeConnectionStep(generatrices, vertices, edges, facets, i, i + 1);
            }
            MakeConnectionStep(generatrices, vertices, edges, facets, i, 0);

            return new Polyhedron(vertices, edges, facets);
        }

        private static void MakeConnectionStep(Generatrix3D[] generatrices, List<Point3D> vertices, List<Edge3D> edges, List<Facet3D> facets, int iCurrent, int iNext)
        {
            var connectionEdges = new List<Edge3D>();
            for (int j = 0; j < generatrices[iCurrent].Points.Count; j++)
            {
                var connectionEdge = new Edge3D(generatrices[iCurrent].Points[j], generatrices[iNext].Points[j]);
                connectionEdges.Add(connectionEdge);
            }
            edges.AddRange(connectionEdges);

            for (int k = 0; k < generatrices[iCurrent].Edges.Count; k++)
            {
                var connectionEdge0 = connectionEdges[k];
                var generatrixEdge0 = generatrices[iCurrent].Edges[k];
                var generatrixEdge1 = generatrices[iNext].Edges[k];
                var connectionEdge1 = connectionEdges[k + 1];

                var currentFacetEdges = new List<Edge3D>
                {
                    connectionEdge0,
                    generatrixEdge0, generatrixEdge1,
                    connectionEdge1
                };

                var currentFacetPoints = new List<Point3D>
                {
                    connectionEdge0.Begin, connectionEdge0.End,
                    connectionEdge1.Begin, connectionEdge1.End,
                };

                var currentFacet = new Facet3D(currentFacetPoints, currentFacetEdges);

                facets.Add(currentFacet);
            }
        }

        private static void EnsurePartitionsCountIsPositive(int partitionsCount)
        {
            if (partitionsCount < 1)
            {
                throw new ArgumentException("Число разиений должно быть положительно");
            }
        }

        private Generatrix3D Copy()
        {
            var points = Points.Select(p => new Point3D(p)).ToList();
            return new Generatrix3D(points, RotationAxis);
        }
    }
}
