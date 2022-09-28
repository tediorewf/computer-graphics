namespace RasterAlgorithms
{
    partial class Task3Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addVerticesButton = new System.Windows.Forms.Button();
            this.performRasterizationButton = new System.Windows.Forms.Button();
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.trianglePictureBox = new System.Windows.Forms.PictureBox();
            this.removeVerticesButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addVerticesButton
            // 
            this.addVerticesButton.Location = new System.Drawing.Point(12, 12);
            this.addVerticesButton.Name = "addVerticesButton";
            this.addVerticesButton.Size = new System.Drawing.Size(220, 80);
            this.addVerticesButton.TabIndex = 0;
            this.addVerticesButton.Text = "Добавить вершины";
            this.addVerticesButton.UseVisualStyleBackColor = true;
            // 
            // performRasterizationButton
            // 
            this.performRasterizationButton.Location = new System.Drawing.Point(772, 12);
            this.performRasterizationButton.Name = "performRasterizationButton";
            this.performRasterizationButton.Size = new System.Drawing.Size(220, 80);
            this.performRasterizationButton.TabIndex = 1;
            this.performRasterizationButton.Text = "Выполнить растеризацию";
            this.performRasterizationButton.UseVisualStyleBackColor = true;
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Location = new System.Drawing.Point(267, 12);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(220, 80);
            this.chooseColorButton.TabIndex = 2;
            this.chooseColorButton.Text = "Выбрать цвет";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            // 
            // trianglePictureBox
            // 
            this.trianglePictureBox.Location = new System.Drawing.Point(12, 109);
            this.trianglePictureBox.Name = "trianglePictureBox";
            this.trianglePictureBox.Size = new System.Drawing.Size(980, 838);
            this.trianglePictureBox.TabIndex = 3;
            this.trianglePictureBox.TabStop = false;
            this.trianglePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trianglePictureBox_MouseClick);
            this.trianglePictureBox.MouseLeave += new System.EventHandler(this.trianglePictureBox_MouseLeave);
            this.trianglePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trianglePictureBox_MouseMove);
            // 
            // removeVerticesButton
            // 
            this.removeVerticesButton.Location = new System.Drawing.Point(518, 12);
            this.removeVerticesButton.Name = "removeVerticesButton";
            this.removeVerticesButton.Size = new System.Drawing.Size(220, 80);
            this.removeVerticesButton.TabIndex = 4;
            this.removeVerticesButton.Text = "Удалить вершины";
            this.removeVerticesButton.UseVisualStyleBackColor = true;
            this.removeVerticesButton.Click += new System.EventHandler(this.removeVerticesButton_Click);
            // 
            // Task3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 959);
            this.Controls.Add(this.removeVerticesButton);
            this.Controls.Add(this.trianglePictureBox);
            this.Controls.Add(this.chooseColorButton);
            this.Controls.Add(this.performRasterizationButton);
            this.Controls.Add(this.addVerticesButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Task3Form";
            this.Text = "Растеризация треугольника";
            this.Load += new System.EventHandler(this.Task3Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addVerticesButton;
        private System.Windows.Forms.Button performRasterizationButton;
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.PictureBox trianglePictureBox;
        private System.Windows.Forms.Button removeVerticesButton;
    }
}