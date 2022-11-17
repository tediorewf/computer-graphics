﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations3D
{
    using static TransformationHelper;
    using static ProjectionType;
    using FastBitmap;

    public partial class MainForm : Form
    {
        private PolyhedronType[] polyhedronTypes;
        private string[] polyhedronNames;
        private ProjectionType[] projectionTypes;
        private string[] projectionNames;
        private CoordinatePlaneType[] rotationCoordinatePlaneTypes;
        private string[] rotationCcoordinatePlaneNames;
        private CoordinatePlaneType[] reflectionCoordinatePlaneTypes;
        private string[] reflectionCoordinatePlaneNames;

        private AxisType[] axisTypes;
        private string[] axisNames;
        private AxisType currentAxisType;

        private Point previousMousePosition;
        private bool rotating = false;
        private Polyhedron currentPolyhedron;
        private List<Polyhedron> ListPolyhedron;
        private List<Polyhedron> polyhedronProjections;

        private ProjectionType currentProjectionType;
        private CoordinatePlaneType currentRotationCoordinatePlaneType;
        private CoordinatePlaneType currentReflectionCoordinatePlaneType;

        private Edge3D rotateAroundEdge;

        private double MashtabP = 1.1;
        private double MashtabM = 0.9;

        public MainForm()
        {
            InitializeComponent();
            InitializePolyhedronStuff();
            InitializeProjectionStuff();
            InitializeRotationCoordinatePlaneStuff();
            InitializeReflectionCoordinatePlaneStuff();
            InitializeRotationBodyStuff();
            Size = new Size(1150, 540);
        }

        private void InitializePolyhedronStuff()
        {
            polyhedronTypes = Enum.GetValues(typeof(PolyhedronType)).Cast<PolyhedronType>().ToArray();
            polyhedronNames = polyhedronTypes.Select(pt => pt.GetPolyhedronName()).ToArray();
            polyhedronSelectionComboBox.Items.AddRange(polyhedronNames);
            polyhedronSelectionComboBox.SelectedIndex = 0;
            currentPolyhedron = polyhedronTypes[2].CreatePolyhedron();
            ListPolyhedron = new List<Polyhedron> {};
            ListPolyhedron.Add(currentPolyhedron);
            ChoiceComboBox.Items.Add(ListPolyhedron.Count);
            ChoiceComboBox.SelectedIndex = ListPolyhedron.Count - 1;
        }

        private void InitializeProjectionStuff()
        {
            projectionTypes = Enum.GetValues(typeof(ProjectionType)).Cast<ProjectionType>().ToArray();
            projectionNames = projectionTypes.Select(pt => pt.GetProjectionName()).ToArray();
            projectionSelectionComboBox.Items.AddRange(projectionNames);
            projectionSelectionComboBox.SelectedIndex = 0;
            currentProjectionType = projectionTypes[projectionSelectionComboBox.SelectedIndex];
        }

        private void InitializeRotationCoordinatePlaneStuff()
        {
            rotationCoordinatePlaneTypes = Enum.GetValues(typeof(CoordinatePlaneType)).Cast<CoordinatePlaneType>().ToArray();
            rotationCcoordinatePlaneNames = rotationCoordinatePlaneTypes.Select(cpt => cpt.GetCoordinatePlaneName()).ToArray();
            rotationCoordinatePlaneComboBox.Items.AddRange(rotationCcoordinatePlaneNames);
            rotationCoordinatePlaneComboBox.SelectedIndex = 0;
            currentRotationCoordinatePlaneType = rotationCoordinatePlaneTypes[rotationCoordinatePlaneComboBox.SelectedIndex];
        }

        private void InitializeReflectionCoordinatePlaneStuff()
        {
            reflectionCoordinatePlaneTypes = Enum.GetValues(typeof(CoordinatePlaneType)).Cast<CoordinatePlaneType>().ToArray();
            reflectionCoordinatePlaneNames = reflectionCoordinatePlaneTypes.Select(cpt => cpt.GetCoordinatePlaneName()).ToArray();
            reflectionCoordinatePlaneComboBox.Items.AddRange(reflectionCoordinatePlaneNames);
            reflectionCoordinatePlaneComboBox.SelectedIndex = 0;
            currentReflectionCoordinatePlaneType = rotationCoordinatePlaneTypes[reflectionCoordinatePlaneComboBox.SelectedIndex];
        }

        private void InitializeRotationBodyStuff()
        {
            axisTypes = Enum.GetValues(typeof(AxisType)).Cast<AxisType>().ToArray();
            axisNames = axisTypes.Select(at => at.GetAxisName()).ToArray();
            chooseRotationBodyAxisComboBox.Items.AddRange(axisNames);
            chooseRotationBodyAxisComboBox.SelectedIndex = 0;
            currentAxisType = axisTypes[chooseRotationBodyAxisComboBox.SelectedIndex];
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Project();
        }

        private void Project() {
            // Перед проецированием обязательно создается копия т.к.
            // проекция влияет на отображение фигуры а не на перемещение в пространстве
            var size = polyhedronPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            DrawEdges(drawingSurface);
            polyhedronPictureBox.Image = drawingSurface;
        }

        private void DrawEdges(Bitmap drawingSurface)
        {
            foreach (var item in ListPolyhedron)
            {
                if (item != currentPolyhedron)
                {
                    drawingSurface.DrawPolyhedron(item.ComputeProjection(currentProjectionType), Color.Blue);
                }
                else
                {
                    drawingSurface.DrawPolyhedron(currentPolyhedron.ComputeProjection(currentProjectionType), Color.Red);
                }
            }
        }

        private void MashtabMinus(object sender, System.EventArgs e)
        {
            currentPolyhedron.ScaleCentered(MashtabM);
            Project();
        }

        private void MashtabPlus(object sender, System.EventArgs e)
        {
            currentPolyhedron.ScaleCentered(MashtabP);
            Project();
        }

        private void ReflectXY(object sender, System.EventArgs e)
        {
            currentPolyhedron.ReflectXY();
            Project();
        }

        private void ReflectYZButton(object sender, System.EventArgs e)
        {
            currentPolyhedron.ReflectYZ();
            Project();
        }

        private void ReflectZXButton(object sender, System.EventArgs e)
        {
            currentPolyhedron.ReflectZX();
            Project();
        }

        private void RotateAroundEdgeCentered(object sender, System.EventArgs e)
        {
            var edge3D = new Edge3D(new Point3D(0, 0, 0), new Point3D(1, 1, 1));
            currentPolyhedron.RotateAroundEdge(edge3D, 60);
            Project();
        }

        private void polyhedronPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!rotating)
            {
                return;
            }

            if (previousMousePosition == null)
            {
                previousMousePosition = e.Location;
            }

            double degreesX, degreesY, degreesZ;

            switch(currentRotationCoordinatePlaneType)
            {
                case CoordinatePlaneType.XY:
                    degreesX = previousMousePosition.X - e.Location.X;
                    degreesY = previousMousePosition.Y - e.Location.Y;
                    degreesZ = 0;
                    break;
                case CoordinatePlaneType.YZ:
                    degreesX = 0;
                    degreesY = previousMousePosition.Y - e.Location.Y;
                    degreesZ = previousMousePosition.X - e.Location.X;
                    break;
                case CoordinatePlaneType.ZX:
                    degreesX = previousMousePosition.X - e.Location.X;
                    degreesY = 0;
                    degreesZ = previousMousePosition.Y - e.Location.Y;
                    break;
                default:
                    throw new ArgumentException("Unknown coordinate plane type");
            }

            currentPolyhedron.RotateAroundCenter(degreesX, degreesY, degreesZ);
            Project();

            previousMousePosition = e.Location;
        }

        private void polyhedronPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            rotating = !rotating;
        }

        private void polyhedronComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentPolyhedron = polyhedronTypes[polyhedronSelectionComboBox.SelectedIndex].CreatePolyhedron();
            ListPolyhedron.Add(currentPolyhedron);
            ChoiceComboBox.Items.Add(ListPolyhedron.Count);
            ChoiceComboBox.SelectedIndex = ListPolyhedron.Count - 1;
            Project();
        }

        private void projectionSelectionComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentProjectionType = projectionTypes[projectionSelectionComboBox.SelectedIndex];
            Project();
        }

        private void rotationAroundEdgeEndPointTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void rotationAroundEdgeAngleButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(rotationAroundEdgeBeginPointXTextBox.Text, out var x1))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(rotationAroundEdgeBeginPointYTextBox.Text, out var y1))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(rotationAroundEdgeBeginPointZTextBox.Text, out var z1))
            {
                WarnInvalidInput();
                return;
            }

            if (!double.TryParse(rotationAroundEdgeEndPointXTextBox.Text, out var x2))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(rotationAroundEdgeEndPointYTextBox.Text, out var y2))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(rotationAroundEdgeEndPointZTextBox.Text, out var z2))
            {
                WarnInvalidInput();
                return;
            }

            if (!double.TryParse(rotationAroundEdgeAngleTextBox.Text, out var degrees))
            {
                WarnInvalidInput();
                return;
            }

            rotateAroundEdge = new Edge3D(new Point3D(x1, y1, z1), new Point3D(x2, y2, z2));

            currentPolyhedron.RotateAroundEdge(rotateAroundEdge, degrees);
            Project();
        }

        private void translateButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(translationXTextBox.Text, out var dx))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(translationYTextBox.Text, out var dy))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(translationZTextBox.Text, out var dz))
            {
                WarnInvalidInput();
                return;
            }

            currentPolyhedron.Translate(dx, dy, dz);
            Project();
        }

        private void WarnInvalidInput()
        {
            MessageBox.Show("Некорректный ввод");
        }

        private void rotateButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(rotationXTextBox.Text, out var xDegrees))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(rotationYTextBox.Text, out var yDegrees))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(rotationZTextBox.Text, out var zDegrees))
            {
                WarnInvalidInput();
                return;
            }

            currentPolyhedron.RotateAxis(xDegrees, yDegrees, zDegrees);
            Project();
        }

        private void scalingButton_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(scalingXTextBox.Text, out var mx))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(scalingYTextBox.Text, out var my))
            {
                WarnInvalidInput();
                return;
            }
            if (!double.TryParse(scalingZTextBox.Text, out var mz))
            {
                WarnInvalidInput();
                return;
            }

            currentPolyhedron.Scale(mx, my, mz);
            Project();
        }

        private void rotationCoordinatePlaneComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentRotationCoordinatePlaneType = rotationCoordinatePlaneTypes[rotationCoordinatePlaneComboBox.SelectedIndex];
        }

        private void reflectionCoordinatePlaneComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentReflectionCoordinatePlaneType = reflectionCoordinatePlaneTypes[reflectionCoordinatePlaneComboBox.SelectedIndex];
        }

        private void reflectButton_Click(object sender, EventArgs e)
        {
            switch (currentReflectionCoordinatePlaneType)
            {
                case CoordinatePlaneType.XY:
                    currentPolyhedron.ReflectXY();
                    break;
                case CoordinatePlaneType.YZ:
                    currentPolyhedron.ReflectYZ();
                    break;
                case CoordinatePlaneType.ZX:
                    currentPolyhedron.ReflectZX();
                    break;
                default:
                    throw new ArgumentException("Unknown coordinate plane type");
            }
            Project();
        }

        private double f(double x,double y)
        {
            string str = FtextBox.Text;
            string s1 = "" + x;
            string s2 = "" + y;
            str = str.Replace("x", s1);
            str = str.Replace("y", s2);
            double d;
            try
            {
                string result = new DataTable().Compute(str, null).ToString();
                d = double.Parse(result);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите функцию корректно!");
                return double.MaxValue;
                throw;
            }
            return d;
        }
        private void building_function(object sender, EventArgs e)
        {
            bool b;
            double x0=0;
            double x1=0;
            double y0=0;
            double y1=0;
            int splitting=0;
            b = double.TryParse(x0TextBox.Text,out x0);
            b = b && double.TryParse(x1TextBox.Text, out x1);
            b = b && double.TryParse(y0TextBox.Text, out y0);
            b = b && double.TryParse(y1TextBox.Text, out y1);
            b = b && int.TryParse(splittingTextBox.Text, out splitting);
            if (!b)
            {
                MessageBox.Show("Введите числа корректно!");
                return;
            }
            double x = (x1 - x0) / splitting;
            double y = (y1 - y0) / splitting;
            List < List<Point3D> > Arr = new List<List<Point3D>>();
            List < Point3D > vertices =  new List<Point3D>();
            var edges = new List<Edge3D>();
            var facets = new List<Facet3D>();
            for (int i = 0; i <= splitting; i++)
            {
                List<Point3D> L = new List<Point3D>();
                for (int j = 0; j <= splitting; j++)
                {
                    double x_0 = x0 + i * x;
                    double y_0 = y0 + j * y;
                    double z = f(x_0, y_0);
                    if (z == double.MaxValue)
                        return;
                    Point3D P = new Point3D(x_0, y_0, z);
                    vertices.Add(P);
                    L.Add(P);
                }
                Arr.Add(L);
            }
            for (int i = 0; i < splitting; i++)
                for (int j = 0; j < splitting; j++)
                {
                    var edge0 = new Edge3D(Arr[i][j], Arr[i+1][j]);
                    var edge1 = new Edge3D(Arr[i][j], Arr[i][j+1]);
                    edges.Add(edge0);
                    edges.Add(edge1);
                }
            for (int i = 0; i < splitting; i++)
            {
                var edge0 = new Edge3D(Arr[i][splitting], Arr[i + 1][splitting]);
                edges.Add(edge0);
            }
            for (int j = 0; j < splitting; j++)
            {
                var edge0 = new Edge3D(Arr[splitting][j], Arr[splitting][j+1]);
                edges.Add(edge0);
            }

            for (int i = 0; i < splitting-1; i++)
                for (int j = 0; j < splitting-1; j++)
                    facets.Add(new Facet3D(new List<Point3D> { Arr[i][j], Arr[i+1][j], Arr[i][j+1], Arr[i+1][j+1] }, new List<Edge3D> { edges[2* (splitting*i+j)], edges[2 * (splitting * i + j) + 1], edges[2 * (splitting * i + j) + 2], edges[2 * (splitting * (i+1) + j) + 1] }));
            int t = 2*splitting * splitting;
            for (int i = 0; i < splitting - 1; i++)
                facets.Add(new Facet3D(new List<Point3D> { Arr[i][splitting-1], Arr[i + 1][splitting-1], Arr[i][splitting], Arr[i + 1][splitting] }, new List<Edge3D> { edges[2 * (splitting * i + (splitting - 1))], edges[2 * (splitting * i + (splitting - 1)) + 1], edges[t+i], edges[2 * (splitting * (i + 1) + (splitting - 1)) + 1] }));
            t += splitting;
            for (int j = 0; j < splitting - 1; j++)
                facets.Add(new Facet3D(new List<Point3D> { Arr[splitting - 1][j], Arr[splitting ][j], Arr[splitting - 1][j + 1], Arr[splitting ][j + 1] }, new List<Edge3D> { edges[2 * (splitting * (splitting - 1) + j)], edges[2 * (splitting * (splitting - 1) + j) + 1], edges[2 * (splitting * (splitting - 1) + j) + 2], edges[t+j] }));
            t--;
            facets.Add(new Facet3D(new List<Point3D> { Arr[splitting - 1][splitting - 1], Arr[splitting][splitting - 1], Arr[splitting - 1][splitting], Arr[splitting][splitting] }, new List<Edge3D> { edges[2 * (splitting * (splitting - 1) + (splitting - 1))], edges[2 * (splitting * (splitting - 1) + (splitting - 1)) + 1], edges[t], edges[t+ splitting] }));

            currentPolyhedron =  new Polyhedron(vertices, edges, facets);
            ListPolyhedron.Add(currentPolyhedron);
            ChoiceComboBox.Items.Add(ListPolyhedron.Count);
            ChoiceComboBox.SelectedIndex = ListPolyhedron.Count - 1;
            Project();

        }

        private void saveModelIntoFileButton_Click(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentPolyhedron.SaveToFile(sfd.FileName);
            }
        }

        private void loadModelronFromFileButton_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentPolyhedron = Polyhedron.ReadFromFile(ofd.FileName);
                ListPolyhedron.Add(currentPolyhedron);
                ChoiceComboBox.Items.Add(ListPolyhedron.Count);
                ChoiceComboBox.SelectedIndex = ListPolyhedron.Count - 1;
                Project();
            }
        }

        private void buttonDoTask2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(partitionsCountTextBox.Text, out int partitionsCount))
            {
                WarnInvalidInput();
                return;
            }

            var splitted = setGeneratrixTextBox.Text.Split();
            var points = new List<Point3D>();
            foreach (var p in splitted)
            {
                var coordinates = p.Split(';');

                if (!double.TryParse(coordinates[0], out var x)) {
                    WarnInvalidInput();
                    return;
                }

                if (!double.TryParse(coordinates[1], out var y))
                {
                    WarnInvalidInput();
                    return;
                }

                if (!double.TryParse(coordinates[2], out var z))
                {
                    WarnInvalidInput();
                    return;
                }

                points.Add(new Point3D(x, y, z));
            }

            var generatrix = new Generatrix3D(points, currentAxisType);

            currentPolyhedron = generatrix.CreateRotationBody(partitionsCount);
            ListPolyhedron.Add(currentPolyhedron);
            ChoiceComboBox.Items.Add(ListPolyhedron.Count);
            ChoiceComboBox.SelectedIndex = ListPolyhedron.Count - 1;
            Project();
        }

        private void chooseRotationBodyAxisComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            currentAxisType = axisTypes[chooseRotationBodyAxisComboBox.SelectedIndex];
        }

        private void ChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int N = ChoiceComboBox.SelectedIndex;
            currentPolyhedron = ListPolyhedron[N];
            Project();
        }

        List<Facet3D> TriangulateConvexFacet(Facet3D convexFacet)
        {
            var triangles = new List<Facet3D>();
            var firstPoint = convexFacet.Points[0];
            for (int i = 2; i < convexFacet.Points.Count; i++)
            {
                var vertices = new List<Point3D> 
                { 
                    firstPoint, convexFacet.Points[i - 1], convexFacet.Points[i] 
                };
                var edges = new List<Edge3D>
                {
                    new Edge3D(firstPoint, convexFacet.Points[i - 1]),
                    new Edge3D(convexFacet.Points[i - 1], convexFacet.Points[i]),
                    new Edge3D(convexFacet.Points[i], firstPoint)
                };
                var triangle = new Facet3D(vertices, edges);
                triangles.Add(triangle);
            }
            return triangles;
        }

        private struct ZBuferStruct
        {
            public bool IsNotEmpty;
            public double Depth;
            public Color Color;
        }

        IEnumerable<DeptherizedPoint> TriangleToListPoint(Facet3D triangle)
        {
            var v1 = DeptherizedPoint.FromPoint3D(triangle.Points[0]);
            var v2 = DeptherizedPoint.FromPoint3D(triangle.Points[1]);
            var v3 = DeptherizedPoint.FromPoint3D(triangle.Points[2]);
            var rasterizedPoints = TriangleRasterizationAlgoritm.RasterizeTriangle(v1, v2, v3);
            return rasterizedPoints;
        }

        private void ZBufer(ZBuferStruct[,] ZBuferArr, Facet3D Triangle, Color Clr)
        {
            var size = polyhedronPictureBox.Size;

            var LstPnt = TriangleToListPoint(Triangle);
            foreach (var item in LstPnt)
            {
                double depth = item.Depth;

                if ((item.X >= 0) && (item.X < size.Width) && (item.Y >= 0) && (item.Y < size.Height))
                {
                    if ((!ZBuferArr[item.X, item.Y].IsNotEmpty) || (depth > ZBuferArr[item.X, item.Y].Depth))
                    {
                        ZBuferArr[item.X, item.Y].Depth = depth;
                        ZBuferArr[item.X, item.Y].Color = Clr;
                        ZBuferArr[item.X, item.Y].IsNotEmpty = true;
                    }
                }
            }
        }

        private void PaintZBufer(ZBuferStruct[,] ZBuferArr, Bitmap drawingSurface)
        {
            using (var fastDrawingSurface = new FastBitmap(drawingSurface))
            {
                for (int i = 0; i < fastDrawingSurface.Width; i++)
                {
                    for (int j = 0; j < fastDrawingSurface.Height; j++)
                    {
                        var zBufferItem = ZBuferArr[i, j];
                        if (zBufferItem.IsNotEmpty)
                        {
                            fastDrawingSurface[i, j] = zBufferItem.Color;
                        }
                    }
                }
            }
            DrawEdges(drawingSurface);
        }

        private void ZbuferButton_Click(object sender, EventArgs e)
        {
            DrawZBuffer();
        }

        private void DrawZBuffer()
        {
            var size = polyhedronPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            var zBuffer = new ZBuferStruct[size.Width, size.Height];

            var transformation = currentProjectionType.CreateMatrix();

            foreach (var item in ListPolyhedron)
            {
                var itemCopy = item.Copy();

                foreach (var vertex in itemCopy.Vertices)
                {
                    TransformPointInplace(vertex, transformation);
                }

                var random = new Random();
                var color = Color.FromArgb(random.Next(255), random.Next(255), random.Next(255));
                foreach (var facets in itemCopy.Facets)
                {
                    var triangulatedConvexFacet = TriangulateConvexFacet(facets);
                    foreach (var triangle in triangulatedConvexFacet)
                    {
                        ZBufer(zBuffer, triangle, color);
                    }
                }
            }
            PaintZBufer(zBuffer, drawingSurface);

            polyhedronPictureBox.Image = drawingSurface;
        }
    }
}
