using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterAlgorithms
{
	
	public partial class Task2Form : Form
	{
		int x1, x2;
		int y1, y2;
		Graphics g;// = pictureBox1.CreateGraphics();
		public Task2Form()
		{
			InitializeComponent();
			var size = pictureBox1.Size;
			pictureBox1.Image = new Bitmap(size.Width, size.Height);
		}

        private void BYbutton_Click(object sender, EventArgs e)
        {
			try
			{
				bool b = true;
                while (b)
                {
					x1 = int.Parse(textBox1.Text);
					x2 = int.Parse(textBox2.Text);
					y1 = int.Parse(textBox3.Text);
					y2 = int.Parse(textBox4.Text);
					b = ((x1 < 0) || (x2 < 0) || (y1 < 0) || (y2 < 0) || (x1 > 480) || (x2 > 480) || (y1 > 340) || (y2 > 340));
                    if (b)
                    {
						MessageBox.Show("Значения за пределами границ");
						return;
					}
				}
				
			}catch(Exception ex)
            {
				MessageBox.Show(Text, ex.Message);
            }
			draw_line(x1,y1,x2,y2);
		}
		private void plot(int x, int y, double c)
        {
			int col = 255 - (int)(c * 255);
			var bmp = pictureBox1.Image as Bitmap;
			Color color = Color.FromArgb(col, col, col);
			//int cc = (int)(c*255);
			//Color color = Color.FromArgb(cc, cc, cc);
			Pen pen = new Pen(color, 1);
			bmp.SetPixel(x, y, color);
			pictureBox1.Image = bmp;
		}
		private int ipart(double x)
        {
			return (int)Math.Truncate(x);
        }
		private int round(double x)
        {
			return ipart(x + 0.5);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private double fpart(double x)
        {
			return x - (int)Math.Truncate(x);
		}
		private double rfpart(double x)
		{
			return 1 - fpart(x);
		}
		private void draw_line(int x1, int y1, int x2, int y2)
		{
			bool steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);

			if (steep) {
				int t = y1;
				y1 = x1;
				x1 = t;
				t = y2;
				y2 = x2;
				x2 = t;
			}

			if (x1 > x2) {
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
			double a = gradient;
			int xend = round(x1);
			double yend = y1 + gradient * (xend - x1);
			var xgapg = rfpart(x1 + 0.5);
			var xpxl1 = xend;  // будет использоваться в основном цикле
			var ypxl1 = ipart(yend);
            if (steep)
            {
				plot(ypxl1, xpxl1, rfpart(yend) * xgapg);
				plot(ypxl1 + 1, xpxl1, fpart(yend) * xgapg);
            }
            else
            {
				plot(xpxl1, ypxl1, rfpart(yend) * xgapg);
				plot(xpxl1, ypxl1 + 1, fpart(yend) * xgapg);
			}
			
			var intery = yend + gradient; // первое y-пересечение для цикла

			// обработать конечную точку
			xend = round(x2);
			yend = y2 + gradient * (xend - x2);
			var xgap = fpart(x2 + 0.5);
			var xpxl2 = xend;  // будет использоваться в основном цикле
			var ypxl2 = ipart(yend);
            if (steep)
            {
				plot(ypxl2, xpxl2, rfpart(yend) * xgap);
				plot(ypxl2 + 1, xpxl2, fpart(yend) * xgap);
            }
            else
            {
				plot(xpxl2, ypxl2, rfpart(yend) * xgap);
				plot(xpxl2, ypxl2 + 1, fpart(yend) * xgap);
			}


            // основной цикл
            if (steep)
            {
				for (var x = xpxl1 + 1; x < xpxl2 - 1; x++)
				{
					plot(ipart(intery),x, rfpart(intery));
					plot(ipart(intery) + 1,x, fpart(intery));
					intery = intery + gradient;
				}
            }
            else
            {
				for (var x = xpxl1 + 1; x < xpxl2 - 1; x++)
				{
					plot(x,ipart(intery),  rfpart(intery));
					plot(x,ipart(intery) + 1, fpart(intery));
					intery = intery + gradient;
				}
			}
			
		}
    }
}
