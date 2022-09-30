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
            this.chooseColorButton = new System.Windows.Forms.Button();
            this.trianglePictureBox = new System.Windows.Forms.PictureBox();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trianglePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseColorButton
            // 
            this.chooseColorButton.Location = new System.Drawing.Point(12, 12);
            this.chooseColorButton.Name = "chooseColorButton";
            this.chooseColorButton.Size = new System.Drawing.Size(472, 80);
            this.chooseColorButton.TabIndex = 2;
            this.chooseColorButton.Text = "Выбрать цвет";
            this.chooseColorButton.UseVisualStyleBackColor = true;
            this.chooseColorButton.Click += new System.EventHandler(this.chooseColorButton_Click);
            // 
            // trianglePictureBox
            // 
            this.trianglePictureBox.Location = new System.Drawing.Point(12, 109);
            this.trianglePictureBox.Name = "trianglePictureBox";
            this.trianglePictureBox.Size = new System.Drawing.Size(980, 838);
            this.trianglePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trianglePictureBox.TabIndex = 3;
            this.trianglePictureBox.TabStop = false;
            this.trianglePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trianglePictureBox_MouseClick);
            this.trianglePictureBox.MouseLeave += new System.EventHandler(this.trianglePictureBox_MouseLeave);
            this.trianglePictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.trianglePictureBox_MouseMove);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(508, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(484, 80);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Очистить";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.removeVerticesButton_Click);
            // 
            // Task3Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 959);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.trianglePictureBox);
            this.Controls.Add(this.chooseColorButton);
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
        private System.Windows.Forms.Button chooseColorButton;
        private System.Windows.Forms.PictureBox trianglePictureBox;
        private System.Windows.Forms.Button clearButton;
    }
}