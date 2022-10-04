using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AffineTransformations
{
public class Edge
{
    public Point Begin {
        get;
        set;
    }
    public Point End {
        get;
        set;
    }

    public Edge(Point begin, Point end)
    {
        Begin = begin;
        End = end;
    }
}
}
