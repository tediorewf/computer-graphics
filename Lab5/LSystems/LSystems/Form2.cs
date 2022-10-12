using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AffineTransformations
{
    using FastBitmap;
    using RasterAlgorithms;
    using WindowsFormsTimer = System.Windows.Forms.Timer;
    using static MidpointDisplacementAlgorithm;

    public partial class Form2 : Form
    {
        private List<List<Edge>> _edges;
        private int _currentIteration;
        private int _iterationsCount;
        private WindowsFormsTimer _timer;

        public Form2()
        {
            InitializeComponent();

            _timer = new WindowsFormsTimer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(DrawEdge);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            _edges = null;
            _currentIteration = 0;
            _iterationsCount = 5;
        }

        private void DrawEdge(object sender, EventArgs e)
        {
            var size = pictureBox1.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            if (_currentIteration != _iterationsCount)
            {
                using (var fastDrawingSurface = new FastBitmap(drawingSurface))
                {
                    foreach (var edge in _edges[_currentIteration])
                    {
                        fastDrawingSurface.DrawBresenhamLine(edge.Begin, edge.End, Color.Black);
                    }
                    _currentIteration += 1;
                }
                pictureBox1.Image = drawingSurface;
            } 
            else
            {
                _timer.Stop();
                SwitchEnabled();
            }
        }

        private void buildButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(iterationsCountTextBox.Text, out int iterationsCount))
            {
                _iterationsCount = iterationsCount;
            } 
            else
            {
                MessageBox.Show("Некорректное значение для числа итераций!");
                return;
            }

            _currentIteration = 0;
            var size = pictureBox1.Size;
            var p1 = new Point(0, size.Height * beginHeightTrackBar.Value / 100);
            var p2 = new Point(size.Width, size.Height * endHeightTrackBar.Value / 100);

            SwitchEnabled();

            _edges = GetMidpointDisplacementEdgesStepByStep(p1, p2, (double)roughnessTrackBar.Value / 100, _iterationsCount).ToList();

            _timer.Start();
        }

        private void SwitchEnabled()
        {
            beginHeightTrackBar.Enabled = !beginHeightTrackBar.Enabled;
            endHeightTrackBar.Enabled = !endHeightTrackBar.Enabled;
            roughnessTrackBar.Enabled = !roughnessTrackBar.Enabled;
            iterationsCountTextBox.Enabled = !iterationsCountTextBox.Enabled;
            buildButton.Enabled = !buildButton.Enabled;
        }
    }
}
