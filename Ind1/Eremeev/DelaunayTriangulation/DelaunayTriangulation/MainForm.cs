using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DelaunayTriangulation
{
    using static DelaunayTriangulationAlgorithm;
    using static RasterAlgorithms.BresenhamAlgorithm;
    using FastBitmap;

    public partial class MainForm : Form
    {
        private List<Point2D> points = new List<Point2D>();
        private List<Triangle2D> triangles = new List<Triangle2D>();

        public MainForm()
        {
            InitializeComponent();
            var size = triangulationPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            triangulationPictureBox.Image = drawingSurface;
        }

        private void triangulateButton_Click(object sender, EventArgs e)
        {
            triangles = Triangulate(points);
            var drawingSurface = triangulationPictureBox.Image as Bitmap;
            foreach (var triangle in triangles)
            {
                drawingSurface.DrawBresenhamLine(triangle.P1.ToPoint(), triangle.P2.ToPoint(), Color.Red);
                drawingSurface.DrawBresenhamLine(triangle.P2.ToPoint(), triangle.P3.ToPoint(), Color.Red);
                drawingSurface.DrawBresenhamLine(triangle.P3.ToPoint(), triangle.P1.ToPoint(), Color.Red);
            }
            triangulationPictureBox.Image = drawingSurface;
        }

        private void clearSceneButton_Click(object sender, EventArgs e) 
            => ResetScene();

        private void ResetScene()
        {
            ResetDrawingSurface();
            ResetPoints();
            ResetTriangles();
        }

        private void ResetDrawingSurface()
        {
            var size = triangulationPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            triangulationPictureBox.Image = drawingSurface;
        }

        private void ResetPoints()
        {
            points = new List<Point2D>();
        }

        private void ResetTriangles()
        {
            triangles = new List<Triangle2D>();
        }

        private void triangulationPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var drawingSurface = triangulationPictureBox.Image as Bitmap;
            var gfx = Graphics.FromImage(drawingSurface);
            int radius = 5, diameter = radius * 2;
            gfx.FillEllipse(Brushes.Blue, e.X - radius, e.Y - radius, diameter, diameter);
            triangulationPictureBox.Image = drawingSurface;
            points.Add(new Point2D(e.Location));
        }
    }
}
