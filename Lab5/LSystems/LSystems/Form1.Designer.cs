namespace AffineTransformations
{
    partial class Form1
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
            this.scenePictureBox = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // scenePictureBox
            // 
            this.scenePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scenePictureBox.BackColor = System.Drawing.Color.White;
            this.scenePictureBox.Location = new System.Drawing.Point(54, 6);
            this.scenePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.scenePictureBox.Name = "scenePictureBox";
            this.scenePictureBox.Size = new System.Drawing.Size(678, 615);
            this.scenePictureBox.TabIndex = 2;
            this.scenePictureBox.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(774, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 61);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сгенерировать фрактал";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(774, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(771, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите количество итераций:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(774, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 61);
            this.button2.TabIndex = 6;
            this.button2.Text = "Очистить сцену";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(774, 189);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(139, 61);
            this.button3.TabIndex = 7;
            this.button3.Text = "Сгенерировать дерево";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 669);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scenePictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Фрактальные узоры и деревья";
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox scenePictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

