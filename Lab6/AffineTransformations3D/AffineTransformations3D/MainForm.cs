using System.Windows.Forms;
using System.Drawing;

namespace AffineTransformations3D
{
    public partial class MainForm : Form
    {
        private Polyhedron currentPolyhedron;
        private int RotateLength = 20;
        private double MashtabP = 1.1;
        private double MashtabM = 0.9;
        private int TranslateD = 10;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Proection() {
            // Перед проецированием обязателбно создается копия т.к.
            // проекция влияет на отображение фигуры а не на перемещение в пространстве
            var size = polyhedronPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            drawingSurface.DrawPolyhedron(currentPolyhedron.ComputeProjection(), Color.Blue);
            polyhedronPictureBox.Image = drawingSurface;
        }

        private void RotateX(object sender, System.EventArgs e)
        {
            currentPolyhedron.RotateXCenter(RotateLength);
            Proection();
        }

        private void RotateY(object sender, System.EventArgs e)
        {
            currentPolyhedron.RotateYCenter(RotateLength);
            Proection();
        }

        private void RotateZ(object sender, System.EventArgs e)
        {
            currentPolyhedron.RotateZCenter(RotateLength);
            Proection();
        }

        private void MashtabMinus(object sender, System.EventArgs e)
        {
            currentPolyhedron.ScaleCentered(MashtabM);
            Proection();
        }

        private void MashtabPlus(object sender, System.EventArgs e)
        {
            currentPolyhedron.ScaleCentered(MashtabP);
            Proection();
        }

        private void TranslateXPlus(object sender, System.EventArgs e)
        {
            currentPolyhedron.Translate(TranslateD, 0, 0);
            Proection();
        }

        private void TranslateXMinus(object sender, System.EventArgs e)
        {
            currentPolyhedron.Translate(-TranslateD, 0, 0);
            Proection();
        }

        private void TranslateYPlus(object sender, System.EventArgs e)
        {
            currentPolyhedron.Translate(0, TranslateD, 0);
            Proection();
        }

        private void TranslateYMinus(object sender, System.EventArgs e)
        {
            currentPolyhedron.Translate(0, -TranslateD, 0);
            Proection();
        }

        private void TranslateZPlus(object sender, System.EventArgs e)
        {
            currentPolyhedron.Translate(0, 0, TranslateD);
            Proection();
        }

        private void TranslateZMinus(object sender, System.EventArgs e)
        {
            currentPolyhedron.Translate(0, 0, -TranslateD);
            Proection();
        }

        private void ReflectXY(object sender, System.EventArgs e)
        {
            currentPolyhedron.ReflectXY();
            Proection();
        }

        private void ReflectYZButton(object sender, System.EventArgs e)
        {
            currentPolyhedron.ReflectYZ();
            Proection();
        }

        private void ReflectZXButton(object sender, System.EventArgs e)
        {
            currentPolyhedron.ReflectZX();
            Proection();
        }

        private void Tetrahedron(object sender, System.EventArgs e)
        {
            currentPolyhedron = RegularPolyhedrons.MakeTetrahedron();
            Proection();
        }

        private void Geksahedron(object sender, System.EventArgs e)
        {
            currentPolyhedron = RegularPolyhedrons.MakeGeksahedron();
            Proection();
        }

        private void Oktahedron(object sender, System.EventArgs e)
        {
            currentPolyhedron = RegularPolyhedrons.MakeOktahedron();
            Proection();
        }

        private void Ikosahedron(object sender, System.EventArgs e)
        {
            currentPolyhedron = RegularPolyhedrons.MakeIkosahedron();
            Proection();
        }

        private void Dodahedron(object sender, System.EventArgs e)
        {
            currentPolyhedron = RegularPolyhedrons.MakeDodahedron();
            Proection();
        }
    }
}
