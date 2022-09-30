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
    public partial class Task1CForm : Form
    {
        private Color borderColor = Color.Cyan;

        public Task1CForm()
        {
            InitializeComponent();
            button2.BackColor = borderColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var colourDialogue = new ColorDialog();
            colourDialogue.Color = borderColor;
            if (colourDialogue.ShowDialog() == DialogResult.OK)
            {
                borderColor = button2.BackColor = colourDialogue.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(ofd.FileName);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                var bitmap = pictureBox1.Image as Bitmap;
                bitmap.HightlightBorder(new Point(e.X, e.Y), borderColor);
                pictureBox1.Image = bitmap;
            }
        }
    }
}
