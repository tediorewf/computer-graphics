
namespace AffineTransformations {
partial class Form2 {
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
    this.beginHeightTrackBar = new System.Windows.Forms.TrackBar();
    this.beginHeightLabel = new System.Windows.Forms.Label();
    this.endHeightLabel = new System.Windows.Forms.Label();
    this.endHeightTrackBar = new System.Windows.Forms.TrackBar();
    this.roughnessTrackBar = new System.Windows.Forms.TrackBar();
    this.roughnessLabel = new System.Windows.Forms.Label();
    this.buildButton = new System.Windows.Forms.Button();
    this.iterationsCountTextBox = new System.Windows.Forms.TextBox();
    this.iterationsCountLabel = new System.Windows.Forms.Label();
    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.beginHeightTrackBar))
        .BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.endHeightTrackBar))
        .BeginInit();
    ((System.ComponentModel.ISupportInitialize)(this.roughnessTrackBar))
        .BeginInit();
    this.SuspendLayout();
    //
    // pictureBox1
    //
    this.pictureBox1.Location = new System.Drawing.Point(12, 12);
    this.pictureBox1.Name = "pictureBox1";
    this.pictureBox1.Size = new System.Drawing.Size(1129, 675);
    this.pictureBox1.TabIndex = 0;
    this.pictureBox1.TabStop = false;
    //
    // beginHeightTrackBar
    //
    this.beginHeightTrackBar.Location = new System.Drawing.Point(12, 725);
    this.beginHeightTrackBar.Maximum = 100;
    this.beginHeightTrackBar.Name = "beginHeightTrackBar";
    this.beginHeightTrackBar.Size = new System.Drawing.Size(237, 90);
    this.beginHeightTrackBar.TabIndex = 1;
    this.beginHeightTrackBar.Value = 30;
    //
    // beginHeightLabel
    //
    this.beginHeightLabel.AutoSize = true;
    this.beginHeightLabel.Location = new System.Drawing.Point(25, 690);
    this.beginHeightLabel.Name = "beginHeightLabel";
    this.beginHeightLabel.Size = new System.Drawing.Size(163, 25);
    this.beginHeightLabel.TabIndex = 2;
    this.beginHeightLabel.Text = "Высота начала";
    //
    // endHeightLabel
    //
    this.endHeightLabel.AutoSize = true;
    this.endHeightLabel.Location = new System.Drawing.Point(284, 690);
    this.endHeightLabel.Name = "endHeightLabel";
    this.endHeightLabel.Size = new System.Drawing.Size(151, 25);
    this.endHeightLabel.TabIndex = 3;
    this.endHeightLabel.Text = "Высота конца";
    //
    // endHeightTrackBar
    //
    this.endHeightTrackBar.Location = new System.Drawing.Point(276, 722);
    this.endHeightTrackBar.Maximum = 100;
    this.endHeightTrackBar.Name = "endHeightTrackBar";
    this.endHeightTrackBar.Size = new System.Drawing.Size(237, 90);
    this.endHeightTrackBar.TabIndex = 4;
    this.endHeightTrackBar.Value = 53;
    //
    // roughnessTrackBar
    //
    this.roughnessTrackBar.Location = new System.Drawing.Point(543, 722);
    this.roughnessTrackBar.Maximum = 100;
    this.roughnessTrackBar.Name = "roughnessTrackBar";
    this.roughnessTrackBar.Size = new System.Drawing.Size(237, 90);
    this.roughnessTrackBar.TabIndex = 5;
    this.roughnessTrackBar.Value = 72;
    //
    // roughnessLabel
    //
    this.roughnessLabel.AutoSize = true;
    this.roughnessLabel.Location = new System.Drawing.Point(552, 690);
    this.roughnessLabel.Name = "roughnessLabel";
    this.roughnessLabel.Size = new System.Drawing.Size(166, 25);
    this.roughnessLabel.TabIndex = 6;
    this.roughnessLabel.Text = "Шероховатость";
    //
    // buildButton
    //
    this.buildButton.Location = new System.Drawing.Point(967, 694);
    this.buildButton.Name = "buildButton";
    this.buildButton.Size = new System.Drawing.Size(174, 85);
    this.buildButton.TabIndex = 7;
    this.buildButton.Text = "Построить";
    this.buildButton.UseVisualStyleBackColor = true;
    this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
    //
    // iterationsCountTextBox
    //
    this.iterationsCountTextBox.Location = new System.Drawing.Point(792, 725);
    this.iterationsCountTextBox.Name = "iterationsCountTextBox";
    this.iterationsCountTextBox.Size = new System.Drawing.Size(100, 31);
    this.iterationsCountTextBox.TabIndex = 8;
    this.iterationsCountTextBox.Text = "5";
    //
    // iterationsCountLabel
    //
    this.iterationsCountLabel.AutoSize = true;
    this.iterationsCountLabel.Location = new System.Drawing.Point(787, 690);
    this.iterationsCountLabel.Name = "iterationsCountLabel";
    this.iterationsCountLabel.Size = new System.Drawing.Size(173, 25);
    this.iterationsCountLabel.TabIndex = 9;
    this.iterationsCountLabel.Text = "Число итераций";
    //
    // Form2
    //
    this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(1153, 827);
    this.Controls.Add(this.iterationsCountLabel);
    this.Controls.Add(this.iterationsCountTextBox);
    this.Controls.Add(this.buildButton);
    this.Controls.Add(this.roughnessLabel);
    this.Controls.Add(this.roughnessTrackBar);
    this.Controls.Add(this.endHeightTrackBar);
    this.Controls.Add(this.endHeightLabel);
    this.Controls.Add(this.beginHeightLabel);
    this.Controls.Add(this.beginHeightTrackBar);
    this.Controls.Add(this.pictureBox1);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "Form2";
    this.Text = "Form2";
    this.Load += new System.EventHandler(this.Form2_Load);
    ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.beginHeightTrackBar))
        .EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.endHeightTrackBar))
        .EndInit();
    ((System.ComponentModel.ISupportInitialize)(this.roughnessTrackBar))
        .EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

#endregion

  private System.Windows.Forms.PictureBox pictureBox1;
  private System.Windows.Forms.TrackBar beginHeightTrackBar;
  private System.Windows.Forms.Label beginHeightLabel;
  private System.Windows.Forms.Label endHeightLabel;
  private System.Windows.Forms.TrackBar endHeightTrackBar;
  private System.Windows.Forms.TrackBar roughnessTrackBar;
  private System.Windows.Forms.Label roughnessLabel;
  private System.Windows.Forms.Button buildButton;
  private System.Windows.Forms.TextBox iterationsCountTextBox;
  private System.Windows.Forms.Label iterationsCountLabel;
}
}