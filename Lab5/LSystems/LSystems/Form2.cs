using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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
        private int _iterationsTotal = 5;
        private WindowsFormsTimer _timer;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var size = pictureBox1.Size;
            _edges = GetMidpointDisplacementEdgesStepByStep(new Point(0, size.Height / 2), new Point(size.Width, size.Height / 2), 0.4, _iterationsTotal).ToList();
            _currentIteration = 0;

            _timer = new WindowsFormsTimer();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(DrawEdge);
            _timer.Start();
        }

        private void DrawEdge(object sender, EventArgs e)
        {
            var size = pictureBox1.Size;
            var drawingSurface = new Bitmap(size.Width, size.Height);
            if (_currentIteration == _iterationsTotal)
            {
                _timer.Stop();
            } else
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
        }
    }
}
