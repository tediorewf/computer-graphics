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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // primitiveTypeComboBox
            // 
            this.primitiveTypeComboBox.FormattingEnabled = true;
            this.primitiveTypeComboBox.Location = new System.Drawing.Point(2, 15);
            this.primitiveTypeComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.primitiveTypeComboBox.Name = "primitiveTypeComboBox";
            this.primitiveTypeComboBox.Size = new System.Drawing.Size(115, 21);
            this.primitiveTypeComboBox.TabIndex = 0;
            this.primitiveTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.primitiveTypeComboBox_SelectedIndexChanged);
            // 
            // currentPrimitiveLabel
            // 
            this.currentPrimitiveLabel.AutoSize = true;
            this.currentPrimitiveLabel.Location = new System.Drawing.Point(2, 0);
            this.currentPrimitiveLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentPrimitiveLabel.Name = "currentPrimitiveLabel";
            this.currentPrimitiveLabel.Size = new System.Drawing.Size(104, 13);
            this.currentPrimitiveLabel.TabIndex = 1;
            this.currentPrimitiveLabel.Text = "Текущий примитив";
            // 
            // scenePictureBox
            // 
            this.scenePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scenePictureBox.BackColor = System.Drawing.Color.White;
            this.scenePictureBox.Location = new System.Drawing.Point(6, 53);
            this.scenePictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.scenePictureBox.Name = "scenePictureBox";
            this.scenePictureBox.Size = new System.Drawing.Size(726, 580);
            this.scenePictureBox.TabIndex = 2;
            this.scenePictureBox.TabStop = false;
            this.scenePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scenePictureBox_MouseClick);
            this.scenePictureBox.MouseEnter += new System.EventHandler(this.scenePictureBox_MouseEnter);
            this.scenePictureBox.MouseLeave += new System.EventHandler(this.scenePictureBox_MouseLeave);
            // 
            // clearSceneButton
            // 
            this.clearSceneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearSceneButton.Location = new System.Drawing.Point(622, 2);
            this.clearSceneButton.Margin = new System.Windows.Forms.Padding(2);
            this.clearSceneButton.Name = "clearSceneButton";
            this.clearSceneButton.Size = new System.Drawing.Size(102, 33);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(119, 38);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.51077F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.48923F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 148F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearSceneButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.doneButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 7);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 43);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(288, 2);
            this.doneButton.Margin = new System.Windows.Forms.Padding(2);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(108, 33);
            this.doneButton.TabIndex = 5;
            this.doneButton.Text = "Готово";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(748, 53);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(115, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(745, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберете полигон для изменения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(758, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 52);
            this.button1.TabIndex = 6;
            this.button1.Text = "влево";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(818, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "вверх";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(879, 128);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(64, 52);
            this.button3.TabIndex = 8;
            this.button3.Text = "вправо";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(818, 176);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 52);
            this.button4.TabIndex = 9;
            this.button4.Text = "вниз";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(879, 280);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(64, 52);
            this.button5.TabIndex = 10;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(758, 280);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(64, 52);
            this.button6.TabIndex = 11;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(827, 300);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "масштаб";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(818, 408);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(64, 52);
            this.button7.TabIndex = 13;
            this.button7.Text = "поворот";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 638);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.scenePictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox primitiveTypeComboBox;
        private System.Windows.Forms.Label currentPrimitiveLabel;
        private System.Windows.Forms.PictureBox scenePictureBox;
        private System.Windows.Forms.Button clearSceneButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button7;
    }
}

