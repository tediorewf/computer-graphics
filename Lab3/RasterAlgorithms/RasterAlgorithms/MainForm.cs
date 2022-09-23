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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task1Form = new Task1Form();
            task1Form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var task2Form = new Task2Form();
            task2Form.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var task3Form = new Task3Form();
            task3Form.ShowDialog();
        }
    }
}
