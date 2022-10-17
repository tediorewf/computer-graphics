﻿namespace AffineTransformations3D
{
partial class MainForm
{
    /// <summary>
    /// Обязательная переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Требуемый метод для поддержки конструктора — не изменяйте
    /// содержимое этого метода с помощью редактора кода.
    /// </summary>
    private void InitializeComponent()
    {
        this.polyhedronPictureBox = new System.Windows.Forms.PictureBox();
        this.switchProjectionButton = new System.Windows.Forms.Button();
        this.projectionLabel = new System.Windows.Forms.Label();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.button4 = new System.Windows.Forms.Button();
        this.button5 = new System.Windows.Forms.Button();
        this.button6 = new System.Windows.Forms.Button();
        this.button7 = new System.Windows.Forms.Button();
        this.button8 = new System.Windows.Forms.Button();
        this.button9 = new System.Windows.Forms.Button();
        this.button10 = new System.Windows.Forms.Button();
        this.button11 = new System.Windows.Forms.Button();
        this.button12 = new System.Windows.Forms.Button();
        this.button13 = new System.Windows.Forms.Button();
        this.button14 = new System.Windows.Forms.Button();
        this.reflectXYButton = new System.Windows.Forms.Button();
        this.reflectYZButton = new System.Windows.Forms.Button();
        this.reflectZXButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.polyhedronPictureBox)).BeginInit();
        this.SuspendLayout();
        //
        // polyhedronPictureBox
        //
        this.polyhedronPictureBox.Location = new System.Drawing.Point(12, 140);
        this.polyhedronPictureBox.Margin = new System.Windows.Forms.Padding(4);
        this.polyhedronPictureBox.Name = "polyhedronPictureBox";
        this.polyhedronPictureBox.Size = new System.Drawing.Size(1136, 606);
        this.polyhedronPictureBox.TabIndex = 0;
        this.polyhedronPictureBox.TabStop = false;
        //
        // switchProjectionButton
        //
        this.switchProjectionButton.Location = new System.Drawing.Point(12, 12);
        this.switchProjectionButton.Margin = new System.Windows.Forms.Padding(4);
        this.switchProjectionButton.Name = "switchProjectionButton";
        this.switchProjectionButton.Size = new System.Drawing.Size(194, 79);
        this.switchProjectionButton.TabIndex = 1;
        this.switchProjectionButton.Text = "Переключить проекцию";
        this.switchProjectionButton.UseVisualStyleBackColor = true;
        //
        // projectionLabel
        //
        this.projectionLabel.AutoSize = true;
        this.projectionLabel.Location = new System.Drawing.Point(24, 94);
        this.projectionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        this.projectionLabel.Name = "projectionLabel";
        this.projectionLabel.Size = new System.Drawing.Size(159, 25);
        this.projectionLabel.TabIndex = 2;
        this.projectionLabel.Text = "projectionLabel";
        //
        // button1
        //
        this.button1.Location = new System.Drawing.Point(1170, 12);
        this.button1.Margin = new System.Windows.Forms.Padding(4);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(194, 79);
        this.button1.TabIndex = 3;
        this.button1.Text = "Повернуть по X";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.RotateX);
        //
        // button2
        //
        this.button2.Location = new System.Drawing.Point(1372, 12);
        this.button2.Margin = new System.Windows.Forms.Padding(4);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(194, 79);
        this.button2.TabIndex = 4;
        this.button2.Text = "Повернуть по Y";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.RotateY);
        //
        // button3
        //
        this.button3.Location = new System.Drawing.Point(1574, 12);
        this.button3.Margin = new System.Windows.Forms.Padding(4);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(194, 79);
        this.button3.TabIndex = 5;
        this.button3.Text = "Повернуть по Z";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.RotateZ);
        //
        // button4
        //
        this.button4.Location = new System.Drawing.Point(1256, 140);
        this.button4.Margin = new System.Windows.Forms.Padding(4);
        this.button4.Name = "button4";
        this.button4.Size = new System.Drawing.Size(194, 79);
        this.button4.TabIndex = 6;
        this.button4.Text = "-";
        this.button4.UseVisualStyleBackColor = true;
        this.button4.Click += new System.EventHandler(this.MashtabMinus);
        //
        // button5
        //
        this.button5.Location = new System.Drawing.Point(1476, 140);
        this.button5.Margin = new System.Windows.Forms.Padding(4);
        this.button5.Name = "button5";
        this.button5.Size = new System.Drawing.Size(194, 79);
        this.button5.TabIndex = 7;
        this.button5.Text = "+";
        this.button5.UseVisualStyleBackColor = true;
        this.button5.Click += new System.EventHandler(this.MashtabPlus);
        //
        // button6
        //
        this.button6.Location = new System.Drawing.Point(1574, 246);
        this.button6.Margin = new System.Windows.Forms.Padding(4);
        this.button6.Name = "button6";
        this.button6.Size = new System.Drawing.Size(194, 79);
        this.button6.TabIndex = 10;
        this.button6.Text = "Смещение по Z  -";
        this.button6.UseVisualStyleBackColor = true;
        this.button6.Click += new System.EventHandler(this.TranslateZMinus);
        //
        // button7
        //
        this.button7.Location = new System.Drawing.Point(1372, 246);
        this.button7.Margin = new System.Windows.Forms.Padding(4);
        this.button7.Name = "button7";
        this.button7.Size = new System.Drawing.Size(194, 79);
        this.button7.TabIndex = 9;
        this.button7.Text = "Смещение по Y  -";
        this.button7.UseVisualStyleBackColor = true;
        this.button7.Click += new System.EventHandler(this.TranslateYMinus);
        //
        // button8
        //
        this.button8.Location = new System.Drawing.Point(1170, 246);
        this.button8.Margin = new System.Windows.Forms.Padding(4);
        this.button8.Name = "button8";
        this.button8.Size = new System.Drawing.Size(194, 79);
        this.button8.TabIndex = 8;
        this.button8.Text = "Смещение по X  -";
        this.button8.UseVisualStyleBackColor = true;
        this.button8.Click += new System.EventHandler(this.TranslateXMinus);
        //
        // button9
        //
        this.button9.Location = new System.Drawing.Point(1574, 333);
        this.button9.Margin = new System.Windows.Forms.Padding(4);
        this.button9.Name = "button9";
        this.button9.Size = new System.Drawing.Size(194, 79);
        this.button9.TabIndex = 13;
        this.button9.Text = "Смещение по Z  +";
        this.button9.UseVisualStyleBackColor = true;
        this.button9.Click += new System.EventHandler(this.TranslateZPlus);
        //
        // button10
        //
        this.button10.Location = new System.Drawing.Point(1372, 333);
        this.button10.Margin = new System.Windows.Forms.Padding(4);
        this.button10.Name = "button10";
        this.button10.Size = new System.Drawing.Size(194, 79);
        this.button10.TabIndex = 12;
        this.button10.Text = "Смещение по Y +";
        this.button10.UseVisualStyleBackColor = true;
        this.button10.Click += new System.EventHandler(this.TranslateYPlus);
        //
        // button11
        //
        this.button11.Location = new System.Drawing.Point(1170, 333);
        this.button11.Margin = new System.Windows.Forms.Padding(4);
        this.button11.Name = "button11";
        this.button11.Size = new System.Drawing.Size(194, 79);
        this.button11.TabIndex = 11;
        this.button11.Text = "Смещение по X  +";
        this.button11.UseVisualStyleBackColor = true;
        this.button11.Click += new System.EventHandler(this.TranslateXPlus);
        //
        // button12
        //
        this.button12.Location = new System.Drawing.Point(616, 779);
        this.button12.Margin = new System.Windows.Forms.Padding(4);
        this.button12.Name = "button12";
        this.button12.Size = new System.Drawing.Size(194, 79);
        this.button12.TabIndex = 16;
        this.button12.Text = "Октаэдр";
        this.button12.UseVisualStyleBackColor = true;
        this.button12.Click += new System.EventHandler(this.Oktahedron);
        //
        // button13
        //
        this.button13.Location = new System.Drawing.Point(414, 779);
        this.button13.Margin = new System.Windows.Forms.Padding(4);
        this.button13.Name = "button13";
        this.button13.Size = new System.Drawing.Size(194, 79);
        this.button13.TabIndex = 15;
        this.button13.Text = "Гексаэдр";
        this.button13.UseVisualStyleBackColor = true;
        this.button13.Click += new System.EventHandler(this.Geksahedron);
        //
        // button14
        //
        this.button14.Location = new System.Drawing.Point(212, 779);
        this.button14.Margin = new System.Windows.Forms.Padding(4);
        this.button14.Name = "button14";
        this.button14.Size = new System.Drawing.Size(194, 79);
        this.button14.TabIndex = 14;
        this.button14.Text = "Тетраэдр";
        this.button14.UseVisualStyleBackColor = true;
        this.button14.Click += new System.EventHandler(this.Tetrahedron);
        //
        // reflectXYButton
        //
        this.reflectXYButton.Location = new System.Drawing.Point(1170, 419);
        this.reflectXYButton.Name = "reflectXYButton";
        this.reflectXYButton.Size = new System.Drawing.Size(195, 80);
        this.reflectXYButton.TabIndex = 17;
        this.reflectXYButton.Text = "Отразить по XY";
        this.reflectXYButton.UseVisualStyleBackColor = true;
        this.reflectXYButton.Click += new System.EventHandler(this.ReflectXY);
        //
        // reflectYZButton
        //
        this.reflectYZButton.Location = new System.Drawing.Point(1372, 419);
        this.reflectYZButton.Name = "reflectYZButton";
        this.reflectYZButton.Size = new System.Drawing.Size(194, 80);
        this.reflectYZButton.TabIndex = 18;
        this.reflectYZButton.Text = "Отразить по YZ";
        this.reflectYZButton.UseVisualStyleBackColor = true;
        this.reflectYZButton.Click += new System.EventHandler(this.ReflectYZButton);
        //
        // reflectZXButton
        //
        this.reflectZXButton.Location = new System.Drawing.Point(1574, 419);
        this.reflectZXButton.Name = "reflectZXButton";
        this.reflectZXButton.Size = new System.Drawing.Size(194, 80);
        this.reflectZXButton.TabIndex = 19;
        this.reflectZXButton.Text = "Отразить по ZX";
        this.reflectZXButton.UseVisualStyleBackColor = true;
        this.reflectZXButton.Click += new System.EventHandler(this.ReflectZXButton);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1910, 913);
        this.Controls.Add(this.reflectZXButton);
        this.Controls.Add(this.reflectYZButton);
        this.Controls.Add(this.reflectXYButton);
        this.Controls.Add(this.button12);
        this.Controls.Add(this.button13);
        this.Controls.Add(this.button14);
        this.Controls.Add(this.button9);
        this.Controls.Add(this.button10);
        this.Controls.Add(this.button11);
        this.Controls.Add(this.button6);
        this.Controls.Add(this.button7);
        this.Controls.Add(this.button8);
        this.Controls.Add(this.button5);
        this.Controls.Add(this.button4);
        this.Controls.Add(this.button3);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.projectionLabel);
        this.Controls.Add(this.switchProjectionButton);
        this.Controls.Add(this.polyhedronPictureBox);
        this.Margin = new System.Windows.Forms.Padding(4);
        this.Name = "MainForm";
        this.Text = "Аффинные преобразования в пространстве. Проецирование";
        ((System.ComponentModel.ISupportInitialize)(this.polyhedronPictureBox)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox polyhedronPictureBox;
    private System.Windows.Forms.Button switchProjectionButton;
    private System.Windows.Forms.Label projectionLabel;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Button button5;
    private System.Windows.Forms.Button button6;
    private System.Windows.Forms.Button button7;
    private System.Windows.Forms.Button button8;
    private System.Windows.Forms.Button button9;
    private System.Windows.Forms.Button button10;
    private System.Windows.Forms.Button button11;
    private System.Windows.Forms.Button button12;
    private System.Windows.Forms.Button button13;
    private System.Windows.Forms.Button button14;
    private System.Windows.Forms.Button reflectXYButton;
    private System.Windows.Forms.Button reflectYZButton;
    private System.Windows.Forms.Button reflectZXButton;
}
}

