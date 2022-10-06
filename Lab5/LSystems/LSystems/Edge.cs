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
    public int Proc_clr {
        get;
        set;
    }
    public Edge(Point begin, Point end,  int proc_clr = 100)
    {
        Begin = begin;
        End = end;
        Proc_clr = proc_clr;
    }
}
}
