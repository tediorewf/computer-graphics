using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AffineTransformations3D
{
    using FastBitmap;
    using RasterAlgorithms;

    public static class PolyhedronDrawing
    {
        public static void DrawPolyhedron(this Bitmap drawingSurface, Polyhedron polyhedron, Color color)
        {
            using (var fastDrawingSurface = new FastBitmap(drawingSurface))
                fastDrawingSurface.DrawPolyhedron(polyhedron, color);
        }

        public static void DrawPolyhedron(this FastBitmap fastDrawingSurface, Polyhedron polyhedron, Color color)
        {
            foreach (var edge in polyhedron.Edges)
            {
                fastDrawingSurface.DrawBresenhamLine(edge.Begin.ToPoint(), edge.End.ToPoint(), color);
            }
        }
    }
}
