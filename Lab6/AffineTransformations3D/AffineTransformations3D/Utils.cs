using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AffineTransformations3D
{
    public static class Utils
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            var t = lhs;
            lhs = rhs;
            rhs = t;
        }
    }
}
