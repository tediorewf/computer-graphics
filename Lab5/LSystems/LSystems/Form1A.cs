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
using System.IO;

public partial class Form1A : Form {
  //Ссылка на файл с описанием фрактала
  private string path = "Fractal.txt";
  //Цвет для рисования
  private static readonly Color DrawingColor = Color.Blue;
  //Размер линии
  private int length = 15;
  public Form1A() {
    InitializeComponent();
    ResetDrawingSurface();
  }

  //Функция очистки сцены
  private void ResetDrawingSurface() {
    var size = scenePictureBox.Size;
    var scene = new Bitmap(size.Width, size.Height);
    scenePictureBox.Image = scene;
  }

  //Очистить сцену
  private void button2_Click(object sender, EventArgs e) {
    ResetDrawingSurface();
  }

  //Сгенерировать фрактал
  private void button1_Click(object sender, EventArgs e) {
    //угол
    double corner;
    //описание фрактала
    string mainstr;
    //количество итераций для построения фрактала
    int iteration;
    //список правил
    List<string> rules = new List<string>();

    if (!int.TryParse(textBox1.Text, out iteration)) {
      MessageBox.Show("Введите натуральное число!");
      textBox1.Text = "";
      return;
    }
    if (iteration <= 0) {
      MessageBox.Show("Введите натуральное число!");
      textBox1.Text = "";
      return;
    }
    using (StreamReader reader = new StreamReader(path)) {
      string line;
      string[] str = reader.ReadLine().Split(' ');
      mainstr = str[0];
      corner = double.Parse(str[1]);
      while ((line = reader.ReadLine()) != null)
        rules.Add(line);
    }
    mainstr = BuildFractal(mainstr, rules, iteration);

    PaintFractal(mainstr, corner);
  }
  //Создание описания фрактала
  private string BuildFractal(string mainstr, List<string> rules,
                              int iteration) {
    for (int i = 0; i < iteration; i++)
      foreach (string item in rules) {
        string c = "" + item[0];
        mainstr = mainstr.Replace(c, item.Substring(2));
      }

    return mainstr;
  }
  //Рисование фрактала
  private void PaintFractal(string mainstr, double corner) {
    //создать список линий
    corner = corner * Math.PI / 180.0;

    List<Edge> edges = MakeEdges(mainstr, corner);

    //перенос и масштабирование
    edges = TransferringScaling(edges);

    //прорисовка
    PaintEdges(edges);
  }
  //прорисовка
  private void PaintEdges(List<Edge> edges) {
    var drawingSurface = scenePictureBox.Image as Bitmap;
    using (var fastDrawingSurface = new FastBitmap(drawingSurface)) {
      foreach (var edge in edges)
        fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End,
                                             DrawingColor);
    }
    scenePictureBox.Image = drawingSurface;
  }
  //перенос и масштабирование
  private List<Edge> TransferringScaling(List<Edge> edges) {
    Point PointLeft = new Point(0, 0);
    Point PointRight = new Point(0, 0);
    Point PointTop = new Point(0, 0);
    Point PointBotton = new Point(0, 0);
    foreach (var edge in edges) {
      Point P = edge.Begin;
      if (P.X < PointLeft.X)
        PointLeft = P;
      if (P.X > PointRight.X)
        PointRight = P;
      if (P.Y < PointBotton.Y)
        PointBotton = P;
      if (P.Y > PointTop.Y)
        PointTop = P;
      P = edge.End;
      if (P.X < PointLeft.X)
        PointLeft = P;
      if (P.X > PointRight.X)
        PointRight = P;
      if (P.Y < PointBotton.Y)
        PointBotton = P;
      if (P.Y > PointTop.Y)
        PointTop = P;
    }
    double k = 1;
    double k2 = 1;
    var size = scenePictureBox.Size;
    int L = PointRight.X - PointLeft.X;
    int H = PointTop.Y - PointBotton.Y;
    if (L >= size.Width)
      k = (double)L / (double)size.Width;
    if (H >= size.Height)
      k2 = (double)H / (double)size.Height;
    if (k2 > k)
      k = k2;
    int dx = PointLeft.X;
    int dy = PointBotton.Y;
    //перенос
    foreach (var edge in edges) {
      Matrix M =
          new Matrix(1, 3, new double[,] { { edge.Begin.X, edge.Begin.Y, 1 } });
      Matrix M2 = new Matrix(
          3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -dx, -dy, 1 } });
      Matrix M3 = M.Mul(M2);
      edge.Begin = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);

      M = new Matrix(1, 3, new double[,] { { edge.End.X, edge.End.Y, 1 } });
      M2 = new Matrix(
          3, 3, new double[,] { { 1, 0, 0 }, { 0, 1, 0 }, { -dx, -dy, 1 } });
      M3 = M.Mul(M2);
      edge.End = new Point((int)M3.Arr()[0, 0], (int)M3.Arr()[0, 1]);
    }
    k = 1.0 / k;

    //масштабирование
    foreach (var edge in edges) {
      Matrix M =
          new Matrix(1, 3, new double[,] { { edge.Begin.X, edge.Begin.Y, 1 } });
      Matrix M2 = new Matrix(
          3, 3, new double[,] { { k, 0, 0 }, { 0, k, 0 }, { 0, 0, 1 } });
      Matrix M3 = M.Mul(M2);
      edge.Begin =
          new Point((int)M3.Arr()[0, 0], size.Height - (int)M3.Arr()[0, 1]);

      M = new Matrix(1, 3, new double[,] { { edge.End.X, edge.End.Y, 1 } });
      M2 = new Matrix(3, 3,
                      new double[,] { { k, 0, 0 }, { 0, k, 0 }, { 0, 0, 1 } });
      M3 = M.Mul(M2);
      edge.End =
          new Point((int)M3.Arr()[0, 0], size.Height - (int)M3.Arr()[0, 1]);
    }

    return edges;
  }
  //создать список линий
  private List<Edge> MakeEdges(string mainstr, double corner) {
    Random rnd = new Random();
    bool Rand = false;
    Stack<Point> PointStack = new Stack<Point>();
    Stack<double> CornerStack = new Stack<double>();
    Stack<bool> BoolStack = new Stack<bool>();
    double alpha = 0;
    List<Edge> Lst = new List<Edge>();
    Point P = new Point(0, 0);
    for (int i = 0; i < mainstr.Length; i++) {
      switch (mainstr[i]) {
      case '−':
        alpha -= corner;
        break;
      case '+':
        alpha += corner;
        break;
      case '[':
        Point PP = new Point(P.X, P.Y);
        PointStack.Push(PP);
        CornerStack.Push(alpha);
        BoolStack.Push(Rand);
        break;
      case ']':
        P = PointStack.Pop();
        alpha = CornerStack.Pop();
        Rand = BoolStack.Pop();
        break;
      case '@':
        Rand = true;
        break;
      default:
        Point NewP;
        if (Rand) {
          int value = rnd.Next(10);
          double a = alpha * value / 10.0;
          NewP = new Point(P.X + (int)(length * Math.Sin(a)),
                           P.Y + (int)(length * Math.Cos(a)));
        } else
          NewP = new Point(P.X + (int)(length * Math.Sin(alpha)),
                           P.Y + (int)(length * Math.Cos(alpha)));
        Edge E = new Edge(P, NewP);
        Lst.Add(E);
        P = NewP;
        break;
      }
    }
    return Lst;
  }
}
}
