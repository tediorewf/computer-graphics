using System.Windows.Forms;
using System.Drawing;

namespace AffineTransformations3D
{
    public partial class MainForm : Form
    {
        private Polyhedron currentPolyhedron;

        public MainForm()
        {
            InitializeComponent();
            currentPolyhedron = RegularPolyhedrons.MakeCube();
            //currentPolyhedron.Translate(1000, 1000, 1000);
            currentPolyhedron.RotateX(60);
            currentPolyhedron.RotateY(45);
            currentPolyhedron.Project();
            var size = polyhedronPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            drawingSurface.DrawPolyhedron(currentPolyhedron, Color.Blue);
            polyhedronPictureBox.Image = drawingSurface;
        }
    }
}
