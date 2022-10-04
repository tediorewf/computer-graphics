using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations
{
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var Form1A = new Form1A();
        Form1A.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        var Form1B = new Form1B();
        Form1B.ShowDialog();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var Form2 = new Form2();
        Form2.ShowDialog();
    }

    private void button4_Click(object sender, EventArgs e)
    {
        var Form3 = new Form3();
        Form3.ShowDialog();
    }
}
}
