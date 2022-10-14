using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations {
public partial class Form3 : Form {
  Bitmap image;

  List<PointF> points = new List<PointF>();
  List<PointF> pointsBezier = new List<PointF>();

  Pen[] pens = new Pen[4];
  int current;
  bool move_point_mode = false;
  PointF lstreq;
  int counter;

  bool add_pt = false;
  public Form3() {
    InitializeComponent();
    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    pens[0] = new Pen(Color.Red, 3);
    pens[1] = new Pen(Color.Aqua, 3);
    pens[2] = new Pen(Color.Purple, 3);
    pens[3] = new Pen(Color.Lime, 3);
    counter = 0;
  }

  private void DrawPoint(float x, float y, int pen) {
    var g = Graphics.FromImage(pictureBox1.Image);
    if (pen == 0) {
      g.DrawEllipse(pens[0], x - 1, y - 1, 2, 2);
    } else if (pen == 1) {
      g.DrawEllipse(pens[2], x - 1, y - 1, 2, 2);
    } else {
      g.DrawEllipse(pens[3], x - 1, y - 1, 2, 2);
    }
    pictureBox1.Invalidate();
  }

  private void button2_Click(object sender, EventArgs e) {
    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    points.Clear();
    counter = 0;
    pointsBezier.Clear();
    comboBox1.Items.Clear();
  }

  private void button1_Click(object sender, EventArgs e) { current = 0; }
  private PointF calculate(double t, PointF p1, PointF p2, PointF p3,
                           PointF p4) // Where i is a start index of list
  {
    double f = (1 - t);
    double x = Math.Pow(f, 3) * p1.X + 3 * Math.Pow(f, 2) * t * p2.X +
               3 * f * Math.Pow(t, 2) * p3.X + Math.Pow(t, 3) * p4.X;
    double y = Math.Pow(f, 3) * p1.Y + 3 * Math.Pow(f, 2) * t * p2.Y +
               3 * f * Math.Pow(t, 2) * p3.Y + Math.Pow(t, 3) * p4.Y;
    return new PointF((float)x, (float)y);
  }
  private void Form3_Load(object sender, EventArgs e) {}
  private PointF find_btw_point(PointF p1, PointF p2) {
    return new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
  }

  private Tuple<PointF, PointF> find_btw_points(PointF pm1, PointF p1,
                                                PointF p2, PointF p2p) {

    PointF pt1_new =
        new PointF(pm1.X + 2 * (p1.X - pm1.X), pm1.Y + 2 * (p1.Y - pm1.Y));
    PointF pt2_new =
        new PointF(p2p.X + 2 * (p2.X - p2p.X), p2p.Y + 2 * (p2.Y - p2p.Y));
    return new Tuple<PointF, PointF>(pt1_new, pt2_new);
  }

  private void drawcurveBy4pts(PointF p1, PointF p2, PointF p3, PointF p4) {
    var g = Graphics.FromImage(pictureBox1.Image);
    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
    double t = 0.0;
    Pen p = new Pen(Color.Black, 1);
    PointF prev = calculate(t, p1, p2, p3, p4);
    while (t <= 1.0) {
      PointF next = calculate(t, p1, p2, p3, p4);
      g.DrawLine(p, prev, next);
      t += 0.001;
      prev = next;
    }
    pictureBox1.Invalidate();
    p.Dispose();
  }

  private void redraw() {
    pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
    var g = Graphics.FromImage(pictureBox1.Image);
    Pen p = new Pen(Color.Black, 1);

    pointsBezier.Clear();
    pointsBezier = new List<PointF>();
    pointsBezier.Add(points[0]);
    int ct = 1;
    while (ct <= points.Count - 3) {
      pointsBezier.Add(points[ct]);
      ct += 1;
      pointsBezier.Add(points[ct]);
      ct += 1;
      pointsBezier.Add(points[ct]);
    }
    int bez_ct = 4;
    while (bez_ct <= pointsBezier.Count) {
      drawcurveBy4pts(pointsBezier[bez_ct - 4], pointsBezier[bez_ct - 3],
                      pointsBezier[bez_ct - 2], pointsBezier[bez_ct - 1]);
      bez_ct += 3;
    }

    foreach (var item in pointsBezier) {
      DrawPoint(item.X, item.Y, 2);
    }
    foreach (var item in points) {
      DrawPoint(item.X, item.Y, 0);
    }
  }

  private void button6_Click(object sender, EventArgs e) { redraw(); }

  private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
    if (lstreq == null) {
      DrawPoint(points[comboBox1.SelectedIndex].X,
                points[comboBox1.SelectedIndex].Y, 1);
      lstreq = points[comboBox1.SelectedIndex];
    } else {
      DrawPoint(lstreq.X, lstreq.Y, 0);
      DrawPoint(points[comboBox1.SelectedIndex].X,
                points[comboBox1.SelectedIndex].Y, 1);
      lstreq = points[comboBox1.SelectedIndex];
    }
  }

  private void button1_Click_1(object sender, EventArgs e) {
    move_point_mode = true;
  }

  private void button1_MouseDown(object sender, MouseEventArgs e) {
    button1.BackColor = Color.Red;
  }

  private void pictureBox1_MouseClick(object sender, MouseEventArgs e) {
    if (move_point_mode) {
      points[comboBox1.SelectedIndex] = new PointF(e.X, e.Y);
      points.Remove(points.ElementAt(comboBox1.SelectedIndex));
      DrawPoint(e.X, e.Y, 1);
      redraw();
      move_point_mode = false;
    } else {
      DrawPoint(e.X, e.Y, 0);
      points.Add(new PointF(e.X, e.Y));
      comboBox1.Items.Add("Point#" + points.Count + " X=" + e.X + " Y=" + e.Y);
    }
  }
}
}
