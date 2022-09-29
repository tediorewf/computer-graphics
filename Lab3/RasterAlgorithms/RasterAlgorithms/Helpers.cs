using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RasterAlgorithms
{
public static class Helpers
{
    public static void Swap(ref int lhs, ref int rhs)
    {
        int tmp = lhs;
        lhs = rhs;
        rhs = tmp;
    }
}
}
