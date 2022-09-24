using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RasterAlgorithms {
using FastBitmap;
public partial class Task1Form : Form {
  bool b = true;
  int x1 = 0;
  int y1 = 0;
  //цвет для рисования и заливки
  Color Clr = Color.FromArgb(0, 0, 0);
  //основной рисунок
  Bitmap Img = new Bitmap(659, 526);
  //фото, которым будет производиться заливка
  Bitmap Photo;
  public Task1Form() { InitializeComponent(); }
  //выбор цвета
  private void button1_Click(object sender, EventArgs e) {
    ColorDialog MyDialog = new ColorDialog();
    MyDialog.FullOpen = true;
    MyDialog.Color = Clr;
    MyDialog.ShowDialog();
    Clr = MyDialog.Color;
    button1.BackColor = Clr;
  }
  //выбор фото
  private void button2_Click(object sender, EventArgs e) {
    button2.BackColor = Color.Red;
    button3.BackColor = Color.White;
    button4.BackColor = Color.White;
  }
  //выбор кисти
  private void button3_Click(object sender, EventArgs e) {
    button3.BackColor = Color.Red;
    button2.BackColor = Color.White;
    button4.BackColor = Color.White;
  }
  //выбор заливки
  private void button4_Click(object sender, EventArgs e) {
    button4.BackColor = Color.Red;
    button2.BackColor = Color.White;
    button3.BackColor = Color.White;
  }
  //выбор заливки фотографией
  private void button5_Click(object sender, EventArgs e) {
    OpenFileDialog open_dialog =
        new OpenFileDialog(); //создание диалогового окна для выбора файла
    open_dialog.Filter =
        "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; //формат загружаемого файла
    if (open_dialog.ShowDialog() ==
        DialogResult.OK) //если в окне была нажата кнопка "ОК"
    {
      try {
        Photo = new Bitmap(open_dialog.FileName);
        button5.BackColor = Color.Red;
      } catch {
        DialogResult rezult =
            MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
  private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {

    if ((e.Button == MouseButtons.Left) && (button2.BackColor == Color.Red)) {
      // fast_img[, ] = Clr;
      Pen blackPen = new Pen(Clr, 1);
      Graphics g = Graphics.FromImage(Img);
      int x = Cursor.Position.X - this.Location.X - 20;
      int y = Cursor.Position.Y - this.Location.Y - 43;
      if (b) {
        x1 = x;
        y1 = y;
      }
      g.DrawLine(blackPen, x1, y1, x, y);
      x1 = x;
      y1 = y;
      pictureBox1.Image = Img;
      b = false;
    }
  }
  private void pictureBox1_MouseDown(object sender, MouseEventArgs e) {
    b = true;
  }
  //залить в точке
  private void pictureBox1_Click(object sender, EventArgs e) {
    if (button3.BackColor == Color.Red) {
      int x = Cursor.Position.X - this.Location.X - 20;
      int y = Cursor.Position.Y - this.Location.Y - 43;
      using (var fast_IMG = new FastBitmap(Img)) {
        Color pixelColor = fast_IMG[x, y];
        Solid(x, y, pixelColor, fast_IMG);
        pictureBox1.Image = Img;
      }
    }
    if (button4.BackColor == Color.Red) {
      int x = Cursor.Position.X - this.Location.X - 20;
      int y = Cursor.Position.Y - this.Location.Y - 43;
      using (var fast_IMG = new FastBitmap(Img)) {
        Color pixelColor = fast_IMG[x, y];
        SolidPhoto(x, y, pixelColor, fast_IMG);
        pictureBox1.Image = Img;
      }
    }
  }
  //заливка
  private void Solid(int x, int y, Color c, FastBitmap fast_IMG) {

    fast_IMG[x, y] = Clr;
    int i = x;
    while ((i != 1) && (fast_IMG[i - 1, y] == c)) {
      fast_IMG[i - 1, y] = Clr;
      i--;
    }
    int j = x;
    while ((j != 658) && (fast_IMG[j + 1, y] == c)) {
      fast_IMG[j + 1, y] = Clr;
      j++;
    }
    for (int t = i; t <= j; t++) {
      if ((y < 525) && (fast_IMG[t, y + 1] == c)) {
        Solid(t, y + 1, c, fast_IMG);
      }
    }
    for (int t = i; t <= j; t++) {
      if ((y > 0) && (fast_IMG[t, y - 1] == c)) {
        Solid(t, y - 1, c, fast_IMG);
      }
    }
  }
  //заливка фотографией
  private void SolidPhoto(int x, int y, Color c, FastBitmap fast_IMG) {
    if (button5.BackColor != Color.Red) {
      MessageBox.Show("Выберете фото!!!");
    } else {
      using (var fast_photo = new FastBitmap(Photo)) {
        SolidPhoto2(x, y, c, fast_IMG, fast_photo, x, y);
      }
    }
  }
  private void SolidPhoto2(int x, int y, Color c, FastBitmap fast_IMG,
                           FastBitmap fast_photo, int xn, int yn) {
    int xp1 = x - xn;
    int yp1 = y - yn;
    while (xp1 < 0) {
      xp1 = fast_photo.Width + xp1;
    }
    while (yp1 < 0) {
      yp1 = fast_photo.Height + yp1;
    }
    while (xp1 >= fast_photo.Width) {
      xp1 = xp1 - fast_photo.Width;
    }
    while (yp1 >= fast_photo.Height) {
      yp1 = yp1 - fast_photo.Height;
    }
    fast_IMG[x, y] = fast_photo[xp1, yp1];
    int i = x;
    while ((i != 1) && (fast_IMG[i - 1, y] == c)) {
      int xp = i - 1 - xn;
      int yp = y - yn;
      while (xp < 0) {
        xp = fast_photo.Width + xp;
      }
      while (yp < 0) {
        yp = fast_photo.Height + yp;
      }
      while (xp >= fast_photo.Width) {
        xp = xp - fast_photo.Width;
      }
      while (yp >= fast_photo.Height) {
        yp = yp - fast_photo.Height;
      }
      fast_IMG[i - 1, y] = fast_photo[xp, yp];
      i--;
    }
    int j = x;
    while ((j != 658) && (fast_IMG[j + 1, y] == c)) {
      int xp = j + 1 - xn;
      int yp = y - yn;
      while (xp < 0) {
        xp = fast_photo.Width + xp;
      }
      while (yp < 0) {
        yp = fast_photo.Height + yp;
      }
      while (xp >= fast_photo.Width) {
        xp = xp - fast_photo.Width;
      }
      while (yp >= fast_photo.Height) {
        yp = yp - fast_photo.Height;
      }
      fast_IMG[j + 1, y] = fast_photo[xp, yp];
      j++;
    }
    for (int t = i; t <= j; t++) {
      if ((y < 525) && (fast_IMG[t, y + 1] == c)) {
        SolidPhoto2(t, y + 1, c, fast_IMG, fast_photo, xn, yn);
      }
    }
    for (int t = i; t <= j; t++) {
      if ((y > 0) && (fast_IMG[t, y - 1] == c)) {
        SolidPhoto2(t, y - 1, c, fast_IMG, fast_photo, xn, yn);
      }
    }
  }
}
}
