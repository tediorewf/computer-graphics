using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations3D {
public partial class MainForm : Form {
  private PolyhedronType[] polyhedronTypes;
  private string[] polyhedronNames;
  private ProjectionType[] projectionTypes;
  private string[] projectionNames;
  private CoordinatePlaneType[] rotationCoordinatePlaneTypes;
  private string[] rotationCcoordinatePlaneNames;
  private CoordinatePlaneType[] reflectionCoordinatePlaneTypes;
  private string[] reflectionCoordinatePlaneNames;

  private Point previousMousePosition;
  private bool rotating = false;
  private Polyhedron currentPolyhedron;

  private ProjectionType currentProjectionType;
  private CoordinatePlaneType currentRotationCoordinatePlaneType;
  private CoordinatePlaneType currentReflectionCoordinatePlaneType;

  private Edge3D rotateAroundEdge;

  private double MashtabP = 1.1;
  private double MashtabM = 0.9;

  public MainForm() {
    InitializeComponent();
    InitializePolyhedronStuff();
    InitializeProjectionStuff();
    InitializeRotationCoordinatePlaneStuff();
    InitializeReflectionCoordinatePlaneStuff();
    Size = new Size(735, 455);
  }

  private void InitializePolyhedronStuff() {
    polyhedronTypes =
        Enum.GetValues(typeof(PolyhedronType)).Cast<PolyhedronType>().ToArray();
    polyhedronNames =
        polyhedronTypes.Select(pt => pt.GetPolyhedronName()).ToArray();
    polyhedronSelectionComboBox.Items.AddRange(polyhedronNames);
        polyhedronSelectionComboBox.SelectedIndex = 0;
        currentPolyhedron =
            polyhedronTypes[polyhedronSelectionComboBox.SelectedIndex]
                .CreatePolyhedron();
  }

  private void InitializeProjectionStuff() {
    projectionTypes =
        Enum.GetValues(typeof(ProjectionType)).Cast<ProjectionType>().ToArray();
    projectionNames =
        projectionTypes.Select(pt => pt.GetProjectionName()).ToArray();
    projectionSelectionComboBox.Items.AddRange(projectionNames);
        projectionSelectionComboBox.SelectedIndex = 0;
        currentProjectionType =
            projectionTypes[projectionSelectionComboBox.SelectedIndex];
  }

  private void InitializeRotationCoordinatePlaneStuff() {
    rotationCoordinatePlaneTypes = Enum.GetValues(typeof(CoordinatePlaneType))
                                       .Cast<CoordinatePlaneType>()
                                       .ToArray();
    rotationCcoordinatePlaneNames =
        rotationCoordinatePlaneTypes.Select(cpt => cpt.GetCoordinatePlaneName())
            .ToArray();
    rotationCoordinatePlaneComboBox.Items.AddRange(
        rotationCcoordinatePlaneNames);
        rotationCoordinatePlaneComboBox.SelectedIndex = 0;
        currentRotationCoordinatePlaneType =
            rotationCoordinatePlaneTypes[rotationCoordinatePlaneComboBox
                                             .SelectedIndex];
  }

  private void InitializeReflectionCoordinatePlaneStuff() {
    reflectionCoordinatePlaneTypes = Enum.GetValues(typeof(CoordinatePlaneType))
                                         .Cast<CoordinatePlaneType>()
                                         .ToArray();
    reflectionCoordinatePlaneNames =
        reflectionCoordinatePlaneTypes
            .Select(cpt => cpt.GetCoordinatePlaneName())
            .ToArray();
    reflectionCoordinatePlaneComboBox.Items.AddRange(
        reflectionCoordinatePlaneNames);
        reflectionCoordinatePlaneComboBox.SelectedIndex = 0;
        currentReflectionCoordinatePlaneType =
            rotationCoordinatePlaneTypes[reflectionCoordinatePlaneComboBox
                                             .SelectedIndex];
  }

  private void MainForm_Load(object sender, EventArgs e) { Project(); }

  private void Project() {
    // Перед проецированием обязательно создается копия т.к.
    // проекция влияет на отображение фигуры а не на перемещение в пространстве
    var size = polyhedronPictureBox.Size;
    var drawingSurface = new Bitmap(size.Width, size.Height);
    drawingSurface.DrawPolyhedron(
        currentPolyhedron.ComputeProjection(currentProjectionType), Color.Blue);
    polyhedronPictureBox.Image = drawingSurface;
  }

  private void MashtabMinus(object sender, System.EventArgs e) {
    currentPolyhedron.ScaleCentered(MashtabM);
    Project();
  }

  private void MashtabPlus(object sender, System.EventArgs e) {
    currentPolyhedron.ScaleCentered(MashtabP);
    Project();
  }

  private void ReflectXY(object sender, System.EventArgs e) {
    currentPolyhedron.ReflectXY();
    Project();
  }

  private void ReflectYZButton(object sender, System.EventArgs e) {
    currentPolyhedron.ReflectYZ();
    Project();
  }

  private void ReflectZXButton(object sender, System.EventArgs e) {
    currentPolyhedron.ReflectZX();
    Project();
  }

  private void RotateAroundEdgeCentered(object sender, System.EventArgs e) {
    var edge3D = new Edge3D(new Point3D(0, 0, 0), new Point3D(1, 1, 1));
    currentPolyhedron.RotateAroundEdge(edge3D, 60);
    Project();
  }

  private void polyhedronPictureBox_MouseMove(object sender, MouseEventArgs e) {
    if (!rotating) {
      return;
    }

    if (previousMousePosition == null) {
      previousMousePosition = e.Location;
    }

    double degreesX, degreesY, degreesZ;

    switch (currentRotationCoordinatePlaneType) {
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

  private void polyhedronPictureBox_MouseClick(object sender,
                                               MouseEventArgs e) {
    rotating = !rotating;
  }

  private void polyhedronComboBox_SelectionChangeCommitted(object sender,
                                                           EventArgs e) {
    currentPolyhedron =
        polyhedronTypes[polyhedronSelectionComboBox.SelectedIndex]
            .CreatePolyhedron();
    Project();
  }

  private void
  projectionSelectionComboBox_SelectionChangeCommitted(object sender,
                                                       EventArgs e) {
    currentProjectionType =
        projectionTypes[projectionSelectionComboBox.SelectedIndex];
    Project();
  }

  private void rotationAroundEdgeEndPointTextBox_TextChanged(object sender,
                                                             EventArgs e) {}

  private void rotationAroundEdgeAngleButton_Click(object sender, EventArgs e) {
    if (!double.TryParse(rotationAroundEdgeBeginPointXTextBox.Text,
                         out var x1)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(rotationAroundEdgeBeginPointYTextBox.Text,
                         out var y1)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(rotationAroundEdgeBeginPointZTextBox.Text,
                         out var z1)) {
      WarnInvalidInput();
      return;
    }

    if (!double.TryParse(rotationAroundEdgeEndPointXTextBox.Text, out var x2)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(rotationAroundEdgeEndPointYTextBox.Text, out var y2)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(rotationAroundEdgeEndPointZTextBox.Text, out var z2)) {
      WarnInvalidInput();
      return;
    }

    if (!double.TryParse(rotationAroundEdgeAngleTextBox.Text,
                         out var degrees)) {
      WarnInvalidInput();
      return;
    }

    rotateAroundEdge =
        new Edge3D(new Point3D(x1, y1, z1), new Point3D(x2, y2, z2));

    currentPolyhedron.RotateAroundEdge(rotateAroundEdge, degrees);
    Project();
  }

  private void resetButton_Click(object sender, EventArgs e) { ResetScene(); }

  private void ResetScene() {
    var size = polyhedronPictureBox.Size;
    var drawingSurface = new Bitmap(size.Width, size.Height);
    polyhedronPictureBox.Image = drawingSurface;
  }

  private void translateButton_Click(object sender, EventArgs e) {
    if (!double.TryParse(translationXTextBox.Text, out var dx)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(translationYTextBox.Text, out var dy)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(translationZTextBox.Text, out var dz)) {
      WarnInvalidInput();
      return;
    }

    currentPolyhedron.Translate(dx, dy, dz);
    Project();
  }

  private void WarnInvalidInput() { MessageBox.Show("Некорректный ввод"); }

  private void rotateButton_Click(object sender, EventArgs e) {
    if (!double.TryParse(rotationXTextBox.Text, out var xDegrees)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(rotationYTextBox.Text, out var yDegrees)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(rotationZTextBox.Text, out var zDegrees)) {
      WarnInvalidInput();
      return;
    }

    currentPolyhedron.RotateAxis(xDegrees, yDegrees, zDegrees);
    Project();
  }

  private void scalingButton_Click(object sender, EventArgs e) {
    if (!double.TryParse(scalingXTextBox.Text, out var mx)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(scalingYTextBox.Text, out var my)) {
      WarnInvalidInput();
      return;
    }
    if (!double.TryParse(scalingZTextBox.Text, out var mz)) {
      WarnInvalidInput();
      return;
    }

    currentPolyhedron.Scale(mx, my, mz);
    Project();
  }

  private void
  rotationCoordinatePlaneComboBox_SelectionChangeCommitted(object sender,
                                                           EventArgs e) {
    currentRotationCoordinatePlaneType =
        rotationCoordinatePlaneTypes[rotationCoordinatePlaneComboBox
                                         .SelectedIndex];
  }

  private void
  reflectionCoordinatePlaneComboBox_SelectionChangeCommitted(object sender,
                                                             EventArgs e) {
    currentReflectionCoordinatePlaneType =
        reflectionCoordinatePlaneTypes[reflectionCoordinatePlaneComboBox
                                           .SelectedIndex];
  }

  private void reflectButton_Click(object sender, EventArgs e) {
    switch (currentReflectionCoordinatePlaneType) {
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
}
}
