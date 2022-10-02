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

  private List<Point> currentPoints;

  private const int DefaultSelectedPrimitiveType = 0;

  private static readonly Color DrawingColor = Color.Blue;

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
    DrawPoint(p.X, p.Y);

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
        var edge = new Edge(begin, end);
        edges.Add(edge);

        var drawingSurface = scenePictureBox.Image as Bitmap;
        drawingSurface.DrawBresenhamLine(begin, end, DrawingColor);
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

  private void DrawPoint(int x, int y) {
    var drawingSurface = scenePictureBox.Image as Bitmap;
    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      fastDrawingSurface[x, y] = DrawingColor;
    }
    scenePictureBox.Image = drawingSurface;
  }

  private void primitiveTypeComboBox_SelectedIndexChanged(object sender,
                                                          EventArgs e) {
    selectedPrimitiveType = primitiveTypes[primitiveTypeComboBox.SelectedIndex];
    switch (selectedPrimitiveType) {
    case PrimitiveType.Point:
      break;
    case PrimitiveType.Edge:
      break;
    case PrimitiveType.Polygon:
      break;
    }
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
  }
}
}
