using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CornishRoom
{
    public class Sphere: Primitive
    {
        public Point3D Center { get; set; }
        public double Radius { get; set; }

        public override bool DefineIfIntersect(Ray straighLine)
        {
            return true;
        }
    }
}
