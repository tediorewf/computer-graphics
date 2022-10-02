namespace AffineTransformations
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
        this.primitiveTypeComboBox = new System.Windows.Forms.ComboBox();
        this.currentPrimitiveLabel = new System.Windows.Forms.Label();
        this.scenePictureBox = new System.Windows.Forms.PictureBox();
        this.clearSceneButton = new System.Windows.Forms.Button();
        this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        this.doneButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).BeginInit();
        this.flowLayoutPanel1.SuspendLayout();
        this.tableLayoutPanel1.SuspendLayout();
        this.SuspendLayout();
        //
        // primitiveTypeComboBox
        //
        this.primitiveTypeComboBox.FormattingEnabled = true;
        this.primitiveTypeComboBox.Location = new System.Drawing.Point(3, 28);
        this.primitiveTypeComboBox.Name = "primitiveTypeComboBox";
        this.primitiveTypeComboBox.Size = new System.Drawing.Size(226, 33);
        this.primitiveTypeComboBox.TabIndex = 0;
        this.primitiveTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.primitiveTypeComboBox_SelectedIndexChanged);
        //
        // currentPrimitiveLabel
        //
        this.currentPrimitiveLabel.AutoSize = true;
        this.currentPrimitiveLabel.Location = new System.Drawing.Point(3, 0);
        this.currentPrimitiveLabel.Name = "currentPrimitiveLabel";
        this.currentPrimitiveLabel.Size = new System.Drawing.Size(202, 25);
        this.currentPrimitiveLabel.TabIndex = 1;
        this.currentPrimitiveLabel.Text = "Текущий примитив";
        //
        // scenePictureBox
        //
        this.scenePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                       | System.Windows.Forms.AnchorStyles.Left)
                                       | System.Windows.Forms.AnchorStyles.Right)));
        this.scenePictureBox.Location = new System.Drawing.Point(12, 101);
        this.scenePictureBox.Name = "scenePictureBox";
        this.scenePictureBox.Size = new System.Drawing.Size(1133, 634);
        this.scenePictureBox.TabIndex = 2;
        this.scenePictureBox.TabStop = false;
        this.scenePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scenePictureBox_MouseClick);
        this.scenePictureBox.MouseEnter += new System.EventHandler(this.scenePictureBox_MouseEnter);
        this.scenePictureBox.MouseLeave += new System.EventHandler(this.scenePictureBox_MouseLeave);
        //
        // clearSceneButton
        //
        this.clearSceneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.clearSceneButton.Location = new System.Drawing.Point(927, 3);
        this.clearSceneButton.Name = "clearSceneButton";
        this.clearSceneButton.Size = new System.Drawing.Size(203, 64);
        this.clearSceneButton.TabIndex = 3;
        this.clearSceneButton.Text = "Очистить сцену";
        this.clearSceneButton.UseVisualStyleBackColor = true;
        this.clearSceneButton.Click += new System.EventHandler(this.clearSceneButton_Click);
        //
        // flowLayoutPanel1
        //
        this.flowLayoutPanel1.AutoSize = true;
        this.flowLayoutPanel1.Controls.Add(this.currentPrimitiveLabel);
        this.flowLayoutPanel1.Controls.Add(this.primitiveTypeComboBox);
        this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
        this.flowLayoutPanel1.Name = "flowLayoutPanel1";
        this.flowLayoutPanel1.Size = new System.Drawing.Size(232, 64);
        this.flowLayoutPanel1.TabIndex = 4;
        //
        // tableLayoutPanel1
        //
        this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                         | System.Windows.Forms.AnchorStyles.Right)));
        this.tableLayoutPanel1.ColumnCount = 3;
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.51077F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.48923F));
        this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
        this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
        this.tableLayoutPanel1.Controls.Add(this.clearSceneButton, 2, 0);
        this.tableLayoutPanel1.Controls.Add(this.doneButton, 1, 0);
        this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
        this.tableLayoutPanel1.Name = "tableLayoutPanel1";
        this.tableLayoutPanel1.RowCount = 1;
        this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        this.tableLayoutPanel1.Size = new System.Drawing.Size(1133, 82);
        this.tableLayoutPanel1.TabIndex = 5;
        //
        // doneButton
        //
        this.doneButton.Location = new System.Drawing.Point(419, 3);
        this.doneButton.Name = "doneButton";
        this.doneButton.Size = new System.Drawing.Size(216, 64);
        this.doneButton.TabIndex = 5;
        this.doneButton.Text = "Готово";
        this.doneButton.UseVisualStyleBackColor = true;
        this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1157, 747);
        this.Controls.Add(this.tableLayoutPanel1);
        this.Controls.Add(this.scenePictureBox);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MainForm";
        this.Text = "Аффинные преобразования";
        ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).EndInit();
        this.flowLayoutPanel1.ResumeLayout(false);
        this.flowLayoutPanel1.PerformLayout();
        this.tableLayoutPanel1.ResumeLayout(false);
        this.tableLayoutPanel1.PerformLayout();
        this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ComboBox primitiveTypeComboBox;
    private System.Windows.Forms.Label currentPrimitiveLabel;
    private System.Windows.Forms.PictureBox scenePictureBox;
    private System.Windows.Forms.Button clearSceneButton;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.Button doneButton;
}
}

