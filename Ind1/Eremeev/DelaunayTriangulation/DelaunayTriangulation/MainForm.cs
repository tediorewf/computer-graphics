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

    public partial class MainForm : Form
    {
        private List<Point2D> points;
        private HashSet<Triangle2D> triangulation;

        public MainForm()
        {
            InitializeComponent();
            ResetScene();
        }

        private void triangulateButton_Click(object sender, EventArgs e)
        {
            triangulation = Triangulate(points);
            DrawTriangulation(triangulation);
        }

        private void DrawTriangulation(HashSet<Triangle2D> triangulation)
        {
            var edges = new HashSet<Edge2D>();
            foreach (var triangle in triangulation)
            {
                edges.Add(new Edge2D(triangle.P1, triangle.P2));
                edges.Add(new Edge2D(triangle.P2, triangle.P3));
                edges.Add(new Edge2D(triangle.P3, triangle.P1));
            }
            var drawingSurface = triangulationPictureBox.Image as Bitmap;
            foreach (var edge in edges)
            {
                drawingSurface.DrawBresenhamLine(edge.Begin.ToPoint(), edge.End.ToPoint(), Color.Red);
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
            triangulation = new HashSet<Triangle2D>();
        }

        private void triangulationPictureBox_MouseClick(object sender, MouseEventArgs e)
            => DrawPoint(new Point2D(e.Location));

        private void DrawPoint(Point2D p)
        {
            var drawingSurface = triangulationPictureBox.Image as Bitmap;
            var gfx = Graphics.FromImage(drawingSurface);
            int radius = 5, diameter = radius * 2;
            gfx.FillEllipse(Brushes.Blue, p.X - radius, p.Y - radius, diameter, diameter);
            triangulationPictureBox.Image = drawingSurface;
            points.Add(p);
        }
    }
}
