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
        ((System.ComponentModel.ISupportInitialize)(this.polyhedronPictureBox)).BeginInit();
        this.SuspendLayout();
        //
        // polyhedronPictureBox
        //
        this.polyhedronPictureBox.Location = new System.Drawing.Point(12, 140);
        this.polyhedronPictureBox.Name = "polyhedronPictureBox";
        this.polyhedronPictureBox.Size = new System.Drawing.Size(1137, 605);
        this.polyhedronPictureBox.TabIndex = 0;
        this.polyhedronPictureBox.TabStop = false;
        //
        // switchProjectionButton
        //
        this.switchProjectionButton.Location = new System.Drawing.Point(12, 12);
        this.switchProjectionButton.Name = "switchProjectionButton";
        this.switchProjectionButton.Size = new System.Drawing.Size(194, 79);
        this.switchProjectionButton.TabIndex = 1;
        this.switchProjectionButton.Text = "Переключить проекцию";
        this.switchProjectionButton.UseVisualStyleBackColor = true;
        //
        // projectionLabel
        //
        this.projectionLabel.AutoSize = true;
        this.projectionLabel.Location = new System.Drawing.Point(25, 94);
        this.projectionLabel.Name = "projectionLabel";
        this.projectionLabel.Size = new System.Drawing.Size(159, 25);
        this.projectionLabel.TabIndex = 2;
        this.projectionLabel.Text = "projectionLabel";
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1161, 757);
        this.Controls.Add(this.projectionLabel);
        this.Controls.Add(this.switchProjectionButton);
        this.Controls.Add(this.polyhedronPictureBox);
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
}
}

