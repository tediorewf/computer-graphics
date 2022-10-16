using System.Windows.Forms;
using System.Drawing;

namespace AffineTransformations3D
{
    public partial class MainForm : Form
    {
        private Polyhedron currentPolyhedron;
        private int RotateLength = 20;
        public MainForm()
        {
            InitializeComponent();
            currentPolyhedron = RegularPolyhedrons.MakeTetrahedron();
            //currentPolyhedron.Translate(-50, 0, 0);
            //currentPolyhedron.RotateX(30);
            //currentPolyhedron.RotateY(20);
            Proection();


        }

        private void Proection() {
            // Перед проецированием обязателбно создается копия т.к.
            // проекция влияет на отображение фигуры а не на перемещение в пространстве
            var projectedPolyhedron = currentPolyhedron.Project();
            var size = polyhedronPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            drawingSurface.DrawPolyhedron(projectedPolyhedron, Color.Blue);
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
    }
}
