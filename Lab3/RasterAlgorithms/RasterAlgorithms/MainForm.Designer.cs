﻿namespace RasterAlgorithms
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
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.button3 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // button1
        //
        this.button1.Location = new System.Drawing.Point(50, 89);
        this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(77, 45);
        this.button1.TabIndex = 0;
        this.button1.Text = "Заливка";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        //
        // button2
        //
        this.button2.Location = new System.Drawing.Point(156, 89);
        this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(77, 45);
        this.button2.TabIndex = 1;
        this.button2.Text = "Задание 2";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        //
        // button3
        //
        this.button3.Location = new System.Drawing.Point(260, 89);
        this.button3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.button3.Name = "button3";
        this.button3.Size = new System.Drawing.Size(77, 45);
        this.button3.TabIndex = 2;
        this.button3.Text = "Задание 3";
        this.button3.UseVisualStyleBackColor = true;
        this.button3.Click += new System.EventHandler(this.button3_Click);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(400, 234);
        this.Controls.Add(this.button3);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
        this.Name = "MainForm";
        this.Text = "Растровые алгоритмы";
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
}
}

