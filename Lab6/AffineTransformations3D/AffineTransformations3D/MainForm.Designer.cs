namespace AffineTransformations3D
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
            ((System.ComponentModel.ISupportInitialize)(this.polyhedronPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // polyhedronPictureBox
            // 
            this.polyhedronPictureBox.Location = new System.Drawing.Point(6, 73);
            this.polyhedronPictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.polyhedronPictureBox.Name = "polyhedronPictureBox";
            this.polyhedronPictureBox.Size = new System.Drawing.Size(568, 315);
            this.polyhedronPictureBox.TabIndex = 0;
            this.polyhedronPictureBox.TabStop = false;
            // 
            // switchProjectionButton
            // 
            this.switchProjectionButton.Location = new System.Drawing.Point(6, 6);
            this.switchProjectionButton.Margin = new System.Windows.Forms.Padding(2);
            this.switchProjectionButton.Name = "switchProjectionButton";
            this.switchProjectionButton.Size = new System.Drawing.Size(97, 41);
            this.switchProjectionButton.TabIndex = 1;
            this.switchProjectionButton.Text = "Переключить проекцию";
            this.switchProjectionButton.UseVisualStyleBackColor = true;
            // 
            // projectionLabel
            // 
            this.projectionLabel.AutoSize = true;
            this.projectionLabel.Location = new System.Drawing.Point(12, 49);
            this.projectionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.projectionLabel.Name = "projectionLabel";
            this.projectionLabel.Size = new System.Drawing.Size(79, 13);
            this.projectionLabel.TabIndex = 2;
            this.projectionLabel.Text = "projectionLabel";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 41);
            this.button1.TabIndex = 3;
            this.button1.Text = "Повернуть по X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RotateX);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(686, 6);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 41);
            this.button2.TabIndex = 4;
            this.button2.Text = "Повернуть по Y";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RotateY);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(787, 6);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 41);
            this.button3.TabIndex = 5;
            this.button3.Text = "Повернуть по Z";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.RotateZ);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 394);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.projectionLabel);
            this.Controls.Add(this.switchProjectionButton);
            this.Controls.Add(this.polyhedronPictureBox);
            this.Margin = new System.Windows.Forms.Padding(2);
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
    }
}

