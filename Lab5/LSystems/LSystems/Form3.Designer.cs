
namespace AffineTransformations {
partial class Form3 {
  /// <summary>
  /// Required designer variable.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Clean up any resources being used.
  /// </summary>
  /// <param name="disposing">true if managed resources should be disposed;
  /// otherwise, false.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

#region Windows Form Designer generated code

  /// <summary>
  /// Required method for Designer support - do not modify
  /// the contents of this method with the code editor.
  /// </summary>
  private void InitializeComponent() {
    this.pictureBox1 = new System.Windows.Forms.PictureBox();
    this.comboBox1 = new System.Windows.Forms.ComboBox();
    this.button1 = new System.Windows.Forms.Button();
    this.button6 = new System.Windows.Forms.Button();
    this.button2 = new System.Windows.Forms.Button();
    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
    this.SuspendLayout();
    //
    // pictureBox1
    //
    this.pictureBox1.Location = new System.Drawing.Point(12, 12);
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.Size = new System.Drawing.Size(659, 426);
    this.pictureBox1.TabIndex = 0;
    this.pictureBox1.TabStop = false;
    this.pictureBox1.MouseClick +=
        new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
    //
    // comboBox1
    //
    this.comboBox1.FormattingEnabled = true;
    this.comboBox1.Location = new System.Drawing.Point(677, 12);
    this.comboBox1.Name = "comboBox1";
    this.comboBox1.Size = new System.Drawing.Size(181, 24);
    this.comboBox1.TabIndex = 1;
    this.comboBox1.SelectedIndexChanged +=
        new System.EventHandler(this.comboBox1_SelectedIndexChanged);
    //
    // button1
    //
    this.button1.Location = new System.Drawing.Point(677, 395);
    this.button1.Name = "button1";
    this.button1.Size = new System.Drawing.Size(181, 43);
    this.button1.TabIndex = 2;
    this.button1.Text = "Очистить";
    this.button1.UseVisualStyleBackColor = true;
    this.button1.Click += new System.EventHandler(this.button2_Click);
    this.button1.MouseDown +=
        new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
    //
    // button6
    //
    this.button6.Location = new System.Drawing.Point(677, 169);
    this.button6.Name = "button6";
    this.button6.Size = new System.Drawing.Size(181, 82);
    this.button6.TabIndex = 3;
    this.button6.Text = "Нарисовать";
    this.button6.UseVisualStyleBackColor = true;
    this.button6.Click += new System.EventHandler(this.button6_Click);
    //
    // button2
    //
    this.button2.Location = new System.Drawing.Point(677, 43);
    this.button2.Name = "button2";
    this.button2.Size = new System.Drawing.Size(181, 44);
    this.button2.TabIndex = 4;
    this.button2.Text = "переместить точку";
    this.button2.UseVisualStyleBackColor = true;
    this.button2.Click += new System.EventHandler(this.button1_Click_1);
    //
    // Form3
    //
    this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(870, 460);
    this.Controls.Add(this.button2);
    this.Controls.Add(this.button6);
    this.Controls.Add(this.button1);
    this.Controls.Add(this.comboBox1);
    this.Controls.Add(this.pictureBox1);
    this.Name = "Form3";
    this.Text = "Form3";
    this.Load += new System.EventHandler(this.Form3_Load);
    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
    this.ResumeLayout(false);
  }

#endregion

  private System.Windows.Forms.PictureBox pictureBox1;
  private System.Windows.Forms.ComboBox comboBox1;
  private System.Windows.Forms.Button button1;
  private System.Windows.Forms.Button button6;
  private System.Windows.Forms.Button button2;
}
}
