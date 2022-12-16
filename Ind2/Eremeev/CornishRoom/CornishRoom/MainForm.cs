using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CornishRoom
{
    public partial class MainForm : Form
    {
        private Color backgroundColor;
        private List<Primitive> primitives;
        private List<Light> lights;

        public MainForm()
        {
            InitializeComponent();
            InitializeScene();
        }

        private void InitializeScene()
        {
            cornishRoomPictureBox.Image = new Bitmap(cornishRoomPictureBox.Width, cornishRoomPictureBox.Height);

            backgroundColor = Color.BurlyWood;

            var yellowGreenMaterial = new Material(Color.YellowGreen, 0.0, 0.0, 0.0);
            var blueMaterial = new Material(Color.Blue, 500, 0.0, 0.0);
            var orangeMaterial = new Material(Color.Orange, 1000, 0.001, 0.7);
            var pinkMaterial = new Material(Color.Pink, 3000, 0.5, 0.0);

            primitives = new List<Primitive>
            {
                new Sphere(yellowGreenMaterial, new Vector3D(6.0, 3.0, 15.0), 1.0),
                new Sphere(blueMaterial, new Vector3D(0.5, 3.0, 13.0), 1.0),
                new Sphere(orangeMaterial, new Vector3D(1.0, 1.0, 9.0), 0.8),
                new Sphere(pinkMaterial, new Vector3D(3.0, -1851.0, -30.0), 1850.0)
            };

            lights = new List<Light>
            {
                new Light(new Vector3D(2.0, 1.0, 0.0), 0.3),
                new Light(new Vector3D(3.0, 4.0, 0.0), 0.2),
                new Light(new Vector3D(1.0, 7.0, 0.0), 0.1)
            };
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            var pointOfView = ParsePointOfView();
            var renderer = new Renderer(pointOfView, cornishRoomPictureBox.Size, primitives, lights, backgroundColor);
            cornishRoomPictureBox.Image = renderer.Render();
        }

        private Vector3D ParsePointOfView()
        {
            double x = double.Parse(xCameraPositionTextBox.Text);
            double y = double.Parse(yCameraPositionTextBox.Text);
            double z = double.Parse(zCameraPositionTextBox.Text);
            return new Vector3D(x, y, z);
        }
    }
}
