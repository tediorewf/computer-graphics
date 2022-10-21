using System;
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
    public partial class MainForm : Form
    {
        private PolyhedronType[] polyhedronTypes;
        private string[] polyhedronNames;
        private ProjectionType[] projectionTypes;
        private string[] projectionNames;

        private Point previousMousePosition;
        private bool rotating = false;
        private Polyhedron currentPolyhedron;

        private ProjectionType currentProjectionType;
        private int RotateLength = 1;
        private double MashtabP = 1.1;
        private double MashtabM = 0.9;

        public MainForm()
        {
            InitializeComponent();
            InitializePolyhedronStuff();
            InitializeProjectionStuff();
            Size = new Size(735, 455);
        }

        private void InitializePolyhedronStuff()
        {
            polyhedronTypes = Enum.GetValues(typeof(PolyhedronType)).Cast<PolyhedronType>().ToArray();
            polyhedronNames = polyhedronTypes.Select(pt => pt.GetPolyhedronName()).ToArray();
            polyhedronSelectionComboBox.Items.AddRange(polyhedronNames);
            polyhedronSelectionComboBox.SelectedIndex = 0;
            currentPolyhedron = polyhedronTypes[polyhedronSelectionComboBox.SelectedIndex].CreatePolyhedron();
        }

        private void InitializeProjectionStuff()
        {
            projectionTypes = Enum.GetValues(typeof(ProjectionType)).Cast<ProjectionType>().ToArray();
            projectionNames = projectionTypes.Select(pt => pt.GetProjectionName()).ToArray();
            projectionSelectionComboBox.Items.AddRange(projectionNames);
            projectionSelectionComboBox.SelectedIndex = 0;
            currentProjectionType = projectionTypes[projectionSelectionComboBox.SelectedIndex];
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
            drawingSurface.DrawPolyhedron(currentPolyhedron.ComputeProjection(currentProjectionType), Color.Blue);
            polyhedronPictureBox.Image = drawingSurface;
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
            currentPolyhedron.RotateAroundEdgeCentered(edge3D, 60);
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

            currentPolyhedron.RotateAroundCenter(previousMousePosition.X - e.Location.X, 
                previousMousePosition.Y - e.Location.Y, 
                0);
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

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetScene();
        }

        private void ResetScene()
        {

        }
    }
}
