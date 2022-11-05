using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
    public static class ListExtensionMethods
    {
        public static Edge2D FetchShortestEdge(this List<Edge2D> edges)
        {
            double minLength = int.MaxValue;
            int minLengthIndex = 0;
            for (int i = 0; i < edges.Count; i++)
            {
                int squareLength = edges[i].SquareLength;
                if (squareLength < minLength)
                {
                    minLength = squareLength;
                    minLengthIndex = i;
                }
            }
            var edge = edges[minLengthIndex];
            edges.RemoveAt(minLengthIndex);
            return edge;
        }
    }
}
