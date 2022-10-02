using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterAlgorithms {
public partial class Task2Form : Form {
  private List<Point> points;
  private bool smooth;

  public Task2Form() {
    InitializeComponent();

    var size = pictureBox1.Size;
    pictureBox1.Image = new Bitmap(size.Width, size.Height);

    points = new List<Point>();
    smoothCheckBox.Checked = smooth = true;
  }

  private void pictureBox1_MouseEnter(object sender, EventArgs e) {
    Cursor = Cursors.Cross;
  }

  private void pictureBox1_MouseLeave(object sender, EventArgs e) {
    Cursor = Cursors.Arrow;
  }

  private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
    points.Add(e.Location);
    if (points.Count == 2) {
      var bmp = pictureBox1.Image as Bitmap;
      if (smooth) {
        bmp.DrawWuLine(points[0], points[1]);
      } else {
        bmp.DrawBresenhamLine(points[0], points[1], Color.Black);
      }
      pictureBox1.Image = bmp;
      points.Clear();
    }
  }

  private void smoothCheckBox_CheckedChanged(object sender, EventArgs e) {
    smooth = smoothCheckBox.Checked;
  }

  private void button1_Click(object sender, EventArgs e) {
    var size = pictureBox1.Size;
    pictureBox1.Image = new Bitmap(size.Width, size.Height);
  }
}
}
