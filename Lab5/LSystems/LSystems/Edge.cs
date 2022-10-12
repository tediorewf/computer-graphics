using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AffineTransformations
{
    using static RasterAlgorithms.BresenhamAlgorithm;

    public class Edge
    {
        public Point Begin { get; set; }
        public Point End { get; set; }
        public Point Mid => new Point((Begin.X + End.X) / 2, (Begin.Y + End.Y) / 2);
        public int Length 
        { 
            get 
            { 
                int dX = Begin.X - End.X;
                int dY = Begin.Y - End.Y;
                return (int)Math.Sqrt(dX*dX + dY*dY); 
            } 
        }
        public int Proc_clr { get; set; }

        public Edge(Point begin, Point end,  int proc_clr = 100)
        {
            Begin = begin;
            End = end;
            Proc_clr = proc_clr;
        }
    }
}
