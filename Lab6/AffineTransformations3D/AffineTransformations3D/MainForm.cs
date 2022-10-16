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
            currentPolyhedron = RegularPolyhedrons.MakeTetrahedron();
            //currentPolyhedron.Translate(5, 5, 5);
            //currentPolyhedron.RotateX(30);
            //currentPolyhedron.RotateY(20);

            // Перед проецированием обязателбно создается копия т.к.
            // проекция влияет на отображение фигуры а не на перемещение в пространстве
            var projectedPolyhedron = currentPolyhedron.Project();
            var size = polyhedronPictureBox.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            drawingSurface.DrawPolyhedron(projectedPolyhedron, Color.Blue);
            polyhedronPictureBox.Image = drawingSurface;
        }
    }
}
