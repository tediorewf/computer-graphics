namespace DelaunayTriangulation {
partial class MainForm {
  /// <summary>
  /// Обязательная переменная конструктора.
  /// </summary>
  private System.ComponentModel.IContainer components = null;

  /// <summary>
  /// Освободить все используемые ресурсы.
  /// </summary>
  /// <param name="disposing">истинно, если управляемый ресурс должен быть
  /// удален; иначе ложно.</param>
  protected override void Dispose(bool disposing) {
    if (disposing && (components != null)) {
      components.Dispose();
    }
    base.Dispose(disposing);
  }

#region Код, автоматически созданный конструктором форм Windows

  /// <summary>
  /// Требуемый метод для поддержки конструктора — не изменяйте
  /// содержимое этого метода с помощью редактора кода.
  /// </summary>
  private void InitializeComponent() {
    this.triangulationPictureBox = new System.Windows.Forms.PictureBox();
    this.triangulateButton = new System.Windows.Forms.Button();
    this.clearSceneButton = new System.Windows.Forms.Button();
    ((System.ComponentModel.ISupportInitialize)(this.triangulationPictureBox))
        .BeginInit();
    this.SuspendLayout();
    //
    // triangulationPictureBox
    //
    this.triangulationPictureBox.Location = new System.Drawing.Point(13, 13);
    this.triangulationPictureBox.Name = "triangulationPictureBox";
    this.triangulationPictureBox.Size = new System.Drawing.Size(749, 648);
    this.triangulationPictureBox.TabIndex = 0;
    this.triangulationPictureBox.TabStop = false;
    //
    // triangulateButton
    //
    this.triangulateButton.Location = new System.Drawing.Point(13, 667);
    this.triangulateButton.Name = "triangulateButton";
    this.triangulateButton.Size = new System.Drawing.Size(370, 50);
    this.triangulateButton.TabIndex = 1;
    this.triangulateButton.Text = "Триангулировать";
    this.triangulateButton.UseVisualStyleBackColor = true;
    this.triangulateButton.Click +=
        new System.EventHandler(this.triangulateButton_Click);
    //
    // clearSceneButton
    //
    this.clearSceneButton.Location = new System.Drawing.Point(392, 667);
    this.clearSceneButton.Name = "clearSceneButton";
    this.clearSceneButton.Size = new System.Drawing.Size(370, 50);
    this.clearSceneButton.TabIndex = 2;
    this.clearSceneButton.Text = "Очистить сцену";
    this.clearSceneButton.UseVisualStyleBackColor = true;
    this.clearSceneButton.Click +=
        new System.EventHandler(this.clearSceneButton_Click);
    //
    // MainForm
    //
    this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
    this.ClientSize = new System.Drawing.Size(774, 729);
    this.Controls.Add(this.clearSceneButton);
    this.Controls.Add(this.triangulateButton);
    this.Controls.Add(this.triangulationPictureBox);
    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "MainForm";
    this.Text = "Триангуляция Делоне";
    ((System.ComponentModel.ISupportInitialize)(this.triangulationPictureBox))
        .EndInit();
    this.ResumeLayout(false);
  }

#endregion

  private System.Windows.Forms.PictureBox triangulationPictureBox;
  private System.Windows.Forms.Button triangulateButton;
  private System.Windows.Forms.Button clearSceneButton;
}
}
