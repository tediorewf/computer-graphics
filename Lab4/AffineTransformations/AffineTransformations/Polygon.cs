using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations
{
public class Polygon
{
    public List<Edge> Edges {
        get;
        private set;
    }

    public Polygon(List<Edge> edges)
    {
        Edges = edges;
    }

    // TODO: реализовать методы для полигона. При необходимости реализовать методы для ребра и вызавать в полигоне
    // (например, для поворота полигона нужно реализовать поворот ребра).
}
}
