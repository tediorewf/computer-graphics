using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelaunayTriangulation
{
    public static class Utils
    {
        public static void Swap<T>(ref T lhs, ref T rhs)
        {
            var tmp = lhs;
            lhs = rhs;
            rhs = tmp;
        }
    }
}
