using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RasterAlgorithms
{
    public partial class Task3Form : Form
    {
        public Task3Form()
        {
            InitializeComponent();
        }

        private void trianglePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Cross;
        }

        private void trianglePictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }
    }
}
