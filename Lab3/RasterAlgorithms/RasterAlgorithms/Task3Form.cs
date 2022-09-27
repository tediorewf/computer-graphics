﻿using System;
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
    public partial class Task3Form : Form
    {
        private List<ColoredPoint> points = new List<ColoredPoint>();

        public Task3Form()
        {
            InitializeComponent();
            var size = trianglePictureBox.Size;
            trianglePictureBox.Image = new Bitmap(size.Width, size.Height);
        }

        private void trianglePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void trianglePictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Task3Form_Load(object sender, EventArgs e)
        {

        }

        private void trianglePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                var color = Color.Blue;
                var point = new ColoredPoint(e.X, e.Y, color);
                points.Add(point);
                var bmp = trianglePictureBox.Image as Bitmap;
                bmp.SetPixel(point.X, point.Y, color);
                trianglePictureBox.Image = bmp;
                if (points.Count == 3)
                {
                    bmp = trianglePictureBox.Image as Bitmap;
                    bmp.RasteriseTriangle(points[0], points[1], points[2]);
                    trianglePictureBox.Image = bmp;
                    points.Clear();
                }
            }
        }
    }
}
