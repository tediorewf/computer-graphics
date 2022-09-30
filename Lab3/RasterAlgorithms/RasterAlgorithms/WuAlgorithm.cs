using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RasterAlgorithms
{
    using FastBitmap;

    public static class WuAlgorithm
    {
        public static void DrawWuLine(this Bitmap drawingSurface, Point p1, Point p2)
        {
            using (var fastDrawingSurface = new FastBitmap(drawingSurface))
                fastDrawingSurface.DrawWuLine(p1, p2);
        }

        public static void DrawWuLine(this FastBitmap fastDrawingSurface, Point p1, Point p2)
        {
            fastDrawingSurface.DrawWuLine(p1.X, p1.Y, p2.X, p2.Y);
        }

        public static void DrawWuLine(this FastBitmap fastDrawingSurface, int x1, int y1, int x2, int y2)
        {
			bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

			if (steep)
			{
				int t = y1;
				y1 = x1;
				x1 = t;
				t = y2;
				y2 = x2;
				x2 = t;
			}

			if (x1 > x2)
			{
				int t = x2;
				x2 = x1;
				x1 = t;
				t = y2;
				y2 = y1;
				y1 = t;
			}

			int dx = x2 - x1;
			int dy = y2 - y1;
			double gradient = 1.0;
			if (dx != 0)
			{
				gradient = (double)dy / (double)dx;
			}
			int xend = Round(x1);
			double yend = y1 + gradient * (xend - x1);
			var xgapg = RFpart(x1 + 0.5);
			var xpxl1 = xend;  // будет использоваться в основном цикле
			var ypxl1 = IPart(yend);
			if (steep)
			{
				Plot(fastDrawingSurface, ypxl1, xpxl1, RFpart(yend) * xgapg);
				Plot(fastDrawingSurface, ypxl1 + 1, xpxl1, FPart(yend) * xgapg);
			}
			else
			{
				Plot(fastDrawingSurface, xpxl1, ypxl1, RFpart(yend) * xgapg);
				Plot(fastDrawingSurface, xpxl1, ypxl1 + 1, FPart(yend) * xgapg);
			}

			var intery = yend + gradient; // первое y-пересечение для цикла

			// обработать конечную точку
			xend = Round(x2);
			yend = y2 + gradient * (xend - x2);
			var xgap = FPart(x2 + 0.5);
			var xpxl2 = xend;  // будет использоваться в основном цикле
			var ypxl2 = IPart(yend);
			if (steep)
			{
				Plot(fastDrawingSurface, ypxl2, xpxl2, RFpart(yend) * xgap);
				Plot(fastDrawingSurface, ypxl2 + 1, xpxl2, FPart(yend) * xgap);
			}
			else
			{
				Plot(fastDrawingSurface, xpxl2, ypxl2, RFpart(yend) * xgap);
				Plot(fastDrawingSurface, xpxl2, ypxl2 + 1, FPart(yend) * xgap);
			}

			// основной цикл
			if (steep)
			{
				for (var x = xpxl1 + 1; x < xpxl2 - 1; x++)
				{
					Plot(fastDrawingSurface, IPart(intery), x, RFpart(intery));
					Plot(fastDrawingSurface, IPart(intery) + 1, x, FPart(intery));
					intery = intery + gradient;
				}
			}
			else
			{
				for (var x = xpxl1 + 1; x < xpxl2 - 1; x++)
				{
					Plot(fastDrawingSurface, x, IPart(intery), RFpart(intery));
					Plot(fastDrawingSurface, x, IPart(intery) + 1, FPart(intery));
					intery = intery + gradient;
				}
			}
		}

		private static double RFpart(double x)
		{
			return 1 - FPart(x);
		}

		private static void Plot(FastBitmap fastDrawingSurface, int x, int y, double c)
        {
            int col = 255 - (int)(c * 255);
            fastDrawingSurface[x, y] = Color.FromArgb(col, col, col);
        }

        private static int IPart(double x)
        {
            return (int)Math.Truncate(x);
        }

        private static int Round(double x)
        {
            return IPart(x + 0.5);
        }

        private static double FPart(double x)
        {
            return x - (int)Math.Truncate(x);
        }
    }
}
