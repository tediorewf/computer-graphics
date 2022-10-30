﻿using System;
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
        {

        }

        private void triangulationPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            var drawingSurface = triangulationPictureBox.Image as Bitmap;
            using (var fastDrawingSurface = new FastBitmap(drawingSurface))
            {
                fastDrawingSurface[e.X, e.Y] = Color.Black;
            }
            triangulationPictureBox.Image = drawingSurface;

            points.Add(new Point2D(e.Location));
        }
    }
}
