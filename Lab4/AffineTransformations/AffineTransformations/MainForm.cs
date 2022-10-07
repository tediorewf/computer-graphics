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
using FastBitmap;
using RasterAlgorithms;
public partial class MainForm : Form {

  private PrimitiveType[] primitiveTypes;
  private PrimitiveType selectedPrimitiveType;

  private List<Point> points;
  private List<Edge> edges;
  private List<Polygon> polygons;
  private Polygon P;
  private Point Cntr;
  private int d = 10;
  private double pr = 1.1;
  private double pr2 = 0.9;
  private double alpha = 0.3;
  private List<Point> currentPoints;

  private Edge currentlySelectedEdge;

  private const int DefaultSelectedPrimitiveType = 0;

  private static readonly Color DrawingColor = Color.Blue;
  private static readonly Color DrawingColorRed = Color.Red;
  public MainForm() {
    InitializeComponent();
    SetPrimitiveTypes();
    ResetDrawingSurface();

    doneButton.Enabled = false;

    points = new List<Point>();
    edges = new List<Edge>();
    polygons = new List<Polygon>();

    currentPoints = new List<Point>();
  }

  private void SetPrimitiveTypes() {
    primitiveTypes =
        Enum.GetValues(typeof(PrimitiveType)).Cast<PrimitiveType>().ToArray();
    var primitiveTypeNames =
        primitiveTypes.Select(pt => pt.GetPrimitiveName()).ToArray();
    primitiveTypeComboBox.Items.AddRange(primitiveTypeNames);

        primitiveTypeComboBox.SelectedIndex = DefaultSelectedPrimitiveType;
        selectedPrimitiveType =
            primitiveTypes[primitiveTypeComboBox.SelectedIndex];
  }

  private void ResetDrawingSurface() {
    var size = scenePictureBox.Size;
    var scene = new Bitmap(size.Width, size.Height);
    scenePictureBox.Image = scene;
    comboBox1.Items.Clear();
    edgesComboBox.Items.Clear();
    P = null;
    currentlySelectedEdge = null;
    if (points != null)
      points.Clear();
    if (edges != null)
      edges.Clear();
    if (polygons != null)
      polygons.Clear();
  }

  private void scenePictureBox_MouseEnter(object sender, EventArgs e) {
    Cursor = Cursors.Cross;
  }

  private void scenePictureBox_MouseLeave(object sender, EventArgs e) {
    Cursor = Cursors.Arrow;
  }

  private void clearSceneButton_Click(object sender, EventArgs e) {
    ResetDrawingSurface();
  }

  private void scenePictureBox_MouseClick(object sender, MouseEventArgs e) {
    var p = new Point(e.X, e.Y);
    DrawPoint(p.X, p.Y, DrawingColor);

    switch (selectedPrimitiveType) {
    case PrimitiveType.Point:
      points.Add(p);
      break;
    case PrimitiveType.Edge:
      currentPoints.Add(p);
      primitiveTypeComboBox.Enabled = false;
      if (currentPoints.Count == 2) {
        var begin = currentPoints.First();
        var end = currentPoints.Last();
        edges.Add(new Edge(begin, end));

        edgesComboBox.Items.Add(edges.Count);
        edgesComboBox.SelectedIndex = edges.Count - 1;

        var drawingSurface = scenePictureBox.Image as Bitmap;
        scenePictureBox.Image = drawingSurface;

        currentPoints.Clear();

        primitiveTypeComboBox.Enabled = true;
      }
      break;
    case PrimitiveType.Polygon:
      primitiveTypeComboBox.Enabled = false;
      currentPoints.Add(p);
      doneButton.Enabled = currentPoints.Count > 3;
      break;
    }
  }

  private void DrawPoint(int x, int y, Color color) {
    var drawingSurface = scenePictureBox.Image as Bitmap;
    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      fastDrawingSurface[x, y] = color;
    }
    scenePictureBox.Image = drawingSurface;
  }

  private void primitiveTypeComboBox_SelectedIndexChanged(object sender,
                                                          EventArgs e) {
    selectedPrimitiveType = primitiveTypes[primitiveTypeComboBox.SelectedIndex];
  }

  private void doneButton_Click(object sender, EventArgs e) {
    var polygonEdges = new List<Edge>();
    var drawingSurface = scenePictureBox.Image as Bitmap;
    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      for (int i = 0; i < currentPoints.Count; i++) {
        var edge = new Edge(currentPoints[i],
                            currentPoints[(i + 1) % currentPoints.Count]);
        polygonEdges.Add(edge);
        fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                             DrawingColor);
      }
    }
    scenePictureBox.Image = drawingSurface;
    polygons.Add(new Polygon(polygonEdges));

    currentPoints.Clear();

    primitiveTypeComboBox.Enabled = true;
    doneButton.Enabled = false;

    comboBox1.Items.Add(polygons.Count);
    comboBox1.SelectedIndex = polygons.Count - 1;
  }

  private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
    Polygon Pred = P;
    int N = comboBox1.SelectedIndex;
    P = polygons[N];
    Centr();
    var drawingSurface = scenePictureBox.Image as Bitmap;
    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      foreach (var edge in P.Edges)
        fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                             DrawingColorRed);
      if (Pred != null)
        foreach (var edge in Pred.Edges)
          fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                               DrawingColor);
    }
    scenePictureBox.Image = drawingSurface;
  }
  private void Return() {
    var size = scenePictureBox.Size;
    var scene = new Bitmap(size.Width, size.Height);
    scenePictureBox.Image = scene;
    var drawingSurface = scenePictureBox.Image as Bitmap;

    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      foreach (var PP in polygons)
        foreach (var edge in PP.Edges)
          fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                               DrawingColor);
      if (P != null) {
        foreach (var edge in P.Edges)
          fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                               DrawingColorRed);
      }
      foreach (var PP in points)
        fastDrawingSurface[PP.X, PP.Y] = DrawingColor;
      foreach (var edge in edges)
        fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                             DrawingColor);
      if (currentlySelectedEdge != null) {
        fastDrawingSurface.DrawBresenhamLine(currentlySelectedEdge.Begin,
                                             currentlySelectedEdge.End,
                                             DrawingColorRed);
      }
    }
    scenePictureBox.Image = drawingSurface;
  }
  private void button1_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(
            1, 3, new double[,] { { edge.Begin.X, edge.Begin.Y, 1 } });
        Matrix M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -d, 0, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);

        M = new Matrix(1, 3, new double[,] { { edge.End.X, edge.End.Y, 1 } });
        M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -d, 0, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);
      }
      Return();
    }
    Centr();
  }

  private void button2_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(
            1, 3, new double[,] { { edge.Begin.X, edge.Begin.Y, 1 } });
        Matrix M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, -d, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);

        M = new Matrix(1, 3, new double[,] { { edge.End.X, edge.End.Y, 1 } });
        M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, -d, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);
      }
      Return();
    }
    Centr();
  }

  private void button3_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(
            1, 3, new double[,] { { edge.Begin.X, edge.Begin.Y, 1 } });
        Matrix M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { d, 0, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);

        M = new Matrix(1, 3, new double[,] { { edge.End.X, edge.End.Y, 1 } });
        M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { d, 0, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);
      }
      Return();
    }
    Centr();
  }

  private void button4_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(
            1, 3, new double[,] { { edge.Begin.X, edge.Begin.Y, 1 } });
        Matrix M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, d, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);

        M = new Matrix(1, 3, new double[,] { { edge.End.X, edge.End.Y, 1 } });
        M2 = new Matrix(
            3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { 0, d, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);
      }
      Return();
    }
    Centr();
  }
  private void Centr() {

    int x = 0;
    int y = 0;
    int i = 0;
    foreach (var edge in P.Edges) {
      x += edge.Begin.X;
      y += edge.Begin.Y;
      i++;
    }
    Cntr = new Point(x / i, y / i);
  }
  private void button5_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(1, 3,
                              new double[,] { { edge.Begin.X - Cntr.X,
                                                edge.Begin.Y - Cntr.Y, 1 } });
        Matrix M2 = new Matrix(
            3, 3, new double[,] { { pr, 0, 0 }, { 0, pr, 0 }, { 0, 0, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0] + Cntr.X,
                               (int)M3.Arr()[0, 1] + Cntr.Y);

        M = new Matrix(
            1, 3,
            new double[,] { { edge.End.X - Cntr.X, edge.End.Y - Cntr.Y, 1 } });
        M2 = new Matrix(
            3, 3, new double[,] { { pr, 0, 0 }, { 0, pr, 0 }, { 0, 0, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0] + Cntr.X,
                             (int)M3.Arr()[0, 1] + Cntr.Y);
      }
      Return();
    }
  }

  private void button6_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(1, 3,
                              new double[,] { { edge.Begin.X - Cntr.X,
                                                edge.Begin.Y - Cntr.Y, 1 } });
        Matrix M2 = new Matrix(
            3, 3, new double[,] { { pr2, 0, 0 }, { 0, pr2, 0 }, { 0, 0, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0] + Cntr.X,
                               (int)M3.Arr()[0, 1] + Cntr.Y);

        M = new Matrix(
            1, 3,
            new double[,] { { edge.End.X - Cntr.X, edge.End.Y - Cntr.Y, 1 } });
        M2 = new Matrix(
            3, 3, new double[,] { { pr2, 0, 0 }, { 0, pr2, 0 }, { 0, 0, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0] + Cntr.X,
                             (int)M3.Arr()[0, 1] + Cntr.Y);
      }
      Return();
    }
  }

  private void label2_Click(object sender, EventArgs e) {}

  private void button7_Click(object sender, EventArgs e) {
    if (P != null) {
      foreach (var edge in P.Edges) {
        Matrix M = new Matrix(1, 3,
                              new double[,] { { edge.Begin.X - Cntr.X,
                                                edge.Begin.Y - Cntr.Y, 1 } });
        Matrix M2 =
            new Matrix(3, 3,
                       new double[,] { { Math.Cos(alpha), Math.Sin(alpha), 0 },
                                       { -Math.Sin(alpha), Math.Cos(alpha), 0 },
                                       { 0, 0, 1 } });
        Matrix M3 = M.Mul(M2);
        edge.Begin = new Point((int)M3.Arr()[0, 0] + Cntr.X,
                               (int)M3.Arr()[0, 1] + Cntr.Y);

        M = new Matrix(
            1, 3,
            new double[,] { { edge.End.X - Cntr.X, edge.End.Y - Cntr.Y, 1 } });
        M2 =
            new Matrix(3, 3,
                       new double[,] { { Math.Cos(alpha), Math.Sin(alpha), 0 },
                                       { -Math.Sin(alpha), Math.Cos(alpha), 0 },
                                       { 0, 0, 1 } });
        M3 = M.Mul(M2);
        edge.End = new Point((int)M3.Arr()[0, 0] + Cntr.X,
                             (int)M3.Arr()[0, 1] + Cntr.Y);
      }
      Return();
    }
  }

  private void edgesComboBox_SelectedIndexChanged(object sender, EventArgs e) {
    var prevEdge = currentlySelectedEdge;
    currentlySelectedEdge = edges[edgesComboBox.SelectedIndex];
    var drawingSurface = scenePictureBox.Image as Bitmap;
    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      fastDrawingSurface.DrawBresenhamLine(currentlySelectedEdge.Begin,
                                           currentlySelectedEdge.End,
                                           DrawingColorRed);
      if (prevEdge != null) {
        fastDrawingSurface.DrawBresenhamLine(prevEdge.Begin, prevEdge.End,
                                             DrawingColor);
      }
    }
    scenePictureBox.Image = drawingSurface;

    var bmp = scenePictureBox.Image as Bitmap;
    var gfx = Graphics.FromImage(bmp);
    var pen = new Pen(Color.Black, 5);

    foreach (var edge in edges) {
      if (edge != currentlySelectedEdge) {
        try {
          var intersectionPoint = currentlySelectedEdge.Intersect(edge);
          gfx.DrawEllipse(pen, intersectionPoint.X, intersectionPoint.Y, 1, 1);
        } catch (EdgesDontIntersectException) {
        }
      }
    }
  }

  private void turnEdge90DegreesButton_Click(object sender, EventArgs e) {
    currentlySelectedEdge.Rotate();
    Return();
  }

  private void buttonTask3_Click(object sender, EventArgs e) {
    try {
      edgePositionRelationLabel.Visible = true;

      var point = points.Last();

      var cm1 = currentlySelectedEdge.Begin;

      int yb = currentlySelectedEdge.End.Y - cm1.Y;
      int xb = currentlySelectedEdge.End.X - cm1.X;
      int ya = point.Y - cm1.Y;
      int xa = point.X - cm1.X;

      if (yb * xa - xb * ya > 0) {
        edgePositionRelationLabel.Text = " левее";
      } else if (yb * xa - xb * ya < 0) {
        edgePositionRelationLabel.Text = " правее";
      } else {
        edgePositionRelationLabel.Text += " лежит на прямой";
      }
    } catch (Exception ex) {
      edgePositionRelationLabel.Visible = true;
      edgePositionRelationLabel.Text = ex.Message;
    }
  }

  private void buttonPrinadlegit_Click(object sender, EventArgs e) {
    int number;
    var point = points.Last();
    var point0 = new Point(0, point.Y);
    int intersections = 0;
    try {
      number = comboBox1.SelectedIndex;
      P = polygons[number];
    } catch (Exception ex) {
      Console.WriteLine(ex.Message + " Выбран полигон 1");
      P = polygons[0];
    }

    List<Point> primitiv = ToPoint(P);
    Point p1 = primitiv.First();
    int num = 0;

    foreach (var p2 in primitiv) {
      if (p1 == p2) {
        continue;
      }

      if (point.X <= p1.X && point.Y == p1.Y && num == 0) {
        num++;
        continue;
      } else {
        num = 0;
      }

      if (Edge.AreIntersect(point, point0, p1, p2)) {
        intersections++;
      }

      p1 = p2;
    }

    if (!(point.X <= p1.X && point.Y == p1.Y && num == 0)) {

      if (Edge.AreIntersect(point, point0, p1, primitiv.First())) {
        intersections++;
      }
    }

    polygonPositionRelationLabel.Visible = true;
    polygonPositionRelationLabel.Text = intersections % 2 == 0
                                            ? "Не принадлежит полигону"
                                            : "Принадлежит полигону";
  }

  private List<Point> ToPoint(Polygon polygon) {
    List<Point> result = new List<Point>();
    result.Add(polygon.Edges[0].Begin);
    foreach (Edge e in polygon.Edges) {
      result.Add(e.End);
    }
    return result;
  }

  private void label4_Click(object sender, EventArgs e) {}

  private void label4_Click_1(object sender, EventArgs e) {}
}
}
