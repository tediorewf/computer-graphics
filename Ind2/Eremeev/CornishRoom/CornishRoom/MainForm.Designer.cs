namespace CornishRoom
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
        this.cornishRoomPictureBox = new System.Windows.Forms.PictureBox();
        this.renderButton = new System.Windows.Forms.Button();
        this.xCameraPositionTextBox = new System.Windows.Forms.TextBox();
        this.zCameraPositionTextBox = new System.Windows.Forms.TextBox();
        this.yCameraPositionTextBox = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize)(this.cornishRoomPictureBox)).BeginInit();
        this.SuspendLayout();
        //
        // cornishRoomPictureBox
        //
        this.cornishRoomPictureBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.cornishRoomPictureBox.Location = new System.Drawing.Point(13, 13);
        this.cornishRoomPictureBox.Name = "cornishRoomPictureBox";
        this.cornishRoomPictureBox.Size = new System.Drawing.Size(1117, 509);
        this.cornishRoomPictureBox.TabIndex = 0;
        this.cornishRoomPictureBox.TabStop = false;
        //
        // renderButton
        //
        this.renderButton.Location = new System.Drawing.Point(12, 587);
        this.renderButton.Name = "renderButton";
        this.renderButton.Size = new System.Drawing.Size(1118, 74);
        this.renderButton.TabIndex = 1;
        this.renderButton.Text = "Отрендерить";
        this.renderButton.UseVisualStyleBackColor = true;
        this.renderButton.Click += new System.EventHandler(this.renderButton_Click);
        //
        // xCameraPositionTextBox
        //
        this.xCameraPositionTextBox.Location = new System.Drawing.Point(13, 540);
        this.xCameraPositionTextBox.Name = "xCameraPositionTextBox";
        this.xCameraPositionTextBox.Size = new System.Drawing.Size(368, 31);
        this.xCameraPositionTextBox.TabIndex = 2;
        this.xCameraPositionTextBox.Text = "0";
        this.xCameraPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        //
        // zCameraPositionTextBox
        //
        this.zCameraPositionTextBox.Location = new System.Drawing.Point(762, 540);
        this.zCameraPositionTextBox.Name = "zCameraPositionTextBox";
        this.zCameraPositionTextBox.Size = new System.Drawing.Size(368, 31);
        this.zCameraPositionTextBox.TabIndex = 3;
        this.zCameraPositionTextBox.Text = "0";
        this.zCameraPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        //
        // yCameraPositionTextBox
        //
        this.yCameraPositionTextBox.Location = new System.Drawing.Point(388, 540);
        this.yCameraPositionTextBox.Name = "yCameraPositionTextBox";
        this.yCameraPositionTextBox.Size = new System.Drawing.Size(368, 31);
        this.yCameraPositionTextBox.TabIndex = 4;
        this.yCameraPositionTextBox.Text = "0";
        this.yCameraPositionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.SystemColors.Desktop;
        this.ClientSize = new System.Drawing.Size(1142, 673);
        this.Controls.Add(this.yCameraPositionTextBox);
        this.Controls.Add(this.zCameraPositionTextBox);
        this.Controls.Add(this.xCameraPositionTextBox);
        this.Controls.Add(this.renderButton);
        this.Controls.Add(this.cornishRoomPictureBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MainForm";
        this.Text = "Корнуэльская комната";
        ((System.ComponentModel.ISupportInitialize)(this.cornishRoomPictureBox)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox cornishRoomPictureBox;
    private System.Windows.Forms.Button renderButton;
    private System.Windows.Forms.TextBox xCameraPositionTextBox;
    private System.Windows.Forms.TextBox zCameraPositionTextBox;
    private System.Windows.Forms.TextBox yCameraPositionTextBox;
}
}

