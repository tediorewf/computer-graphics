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
            this.edgesComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.turnEdge90DegreesButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.edgePositionRelationLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.polygonPositionRelationLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // primitiveTypeComboBox
            // 
            this.primitiveTypeComboBox.FormattingEnabled = true;
            this.primitiveTypeComboBox.Location = new System.Drawing.Point(4, 29);
            this.primitiveTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.primitiveTypeComboBox.Name = "primitiveTypeComboBox";
            this.primitiveTypeComboBox.Size = new System.Drawing.Size(226, 33);
            this.primitiveTypeComboBox.TabIndex = 0;
            this.primitiveTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.primitiveTypeComboBox_SelectedIndexChanged);
            // 
            // currentPrimitiveLabel
            // 
            this.currentPrimitiveLabel.AutoSize = true;
            this.currentPrimitiveLabel.Location = new System.Drawing.Point(4, 0);
            this.currentPrimitiveLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentPrimitiveLabel.Name = "currentPrimitiveLabel";
            this.currentPrimitiveLabel.Size = new System.Drawing.Size(202, 25);
            this.currentPrimitiveLabel.TabIndex = 1;
            this.currentPrimitiveLabel.Text = "Текущий примитив";
            // 
            // scenePictureBox
            // 
            this.scenePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scenePictureBox.BackColor = System.Drawing.Color.White;
            this.scenePictureBox.Location = new System.Drawing.Point(12, 102);
            this.scenePictureBox.Margin = new System.Windows.Forms.Padding(4);
            this.scenePictureBox.Name = "scenePictureBox";
            this.scenePictureBox.Size = new System.Drawing.Size(834, 724);
            this.scenePictureBox.TabIndex = 2;
            this.scenePictureBox.TabStop = false;
            this.scenePictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scenePictureBox_MouseClick);
            this.scenePictureBox.MouseEnter += new System.EventHandler(this.scenePictureBox_MouseEnter);
            this.scenePictureBox.MouseLeave += new System.EventHandler(this.scenePictureBox_MouseLeave);
            // 
            // clearSceneButton
            // 
            this.clearSceneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clearSceneButton.Location = new System.Drawing.Point(625, 4);
            this.clearSceneButton.Margin = new System.Windows.Forms.Padding(4);
            this.clearSceneButton.Name = "clearSceneButton";
            this.clearSceneButton.Size = new System.Drawing.Size(204, 63);
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
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(234, 66);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.51077F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.48923F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.clearSceneButton, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.doneButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 13);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(833, 83);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // doneButton
            // 
            this.doneButton.Location = new System.Drawing.Point(267, 4);
            this.doneButton.Margin = new System.Windows.Forms.Padding(4);
            this.doneButton.Name = "doneButton";
            this.doneButton.Size = new System.Drawing.Size(216, 63);
            this.doneButton.TabIndex = 5;
            this.doneButton.Text = "Готово";
            this.doneButton.UseVisualStyleBackColor = true;
            this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(853, 63);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(226, 33);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(853, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберете полигон для изменения";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(856, 149);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "влево";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(981, 106);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "вверх";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1109, 149);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(128, 37);
            this.button3.TabIndex = 8;
            this.button3.Text = "вправо";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(981, 187);
            this.button4.Margin = new System.Windows.Forms.Padding(6);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(128, 38);
            this.button4.TabIndex = 9;
            this.button4.Text = "вниз";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(858, 260);
            this.button5.Margin = new System.Windows.Forms.Padding(6);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(61, 47);
            this.button5.TabIndex = 10;
            this.button5.Text = "+";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(921, 260);
            this.button6.Margin = new System.Windows.Forms.Padding(6);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(63, 47);
            this.button6.TabIndex = 11;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(862, 229);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "масштаб";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(996, 260);
            this.button7.Margin = new System.Windows.Forms.Padding(6);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(241, 47);
            this.button7.TabIndex = 13;
            this.button7.Text = "поворот";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // edgesComboBox
            // 
            this.edgesComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.edgesComboBox.FormattingEnabled = true;
            this.edgesComboBox.Location = new System.Drawing.Point(858, 356);
            this.edgesComboBox.Name = "edgesComboBox";
            this.edgesComboBox.Size = new System.Drawing.Size(172, 33);
            this.edgesComboBox.TabIndex = 14;
            this.edgesComboBox.SelectedIndexChanged += new System.EventHandler(this.edgesComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(853, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Выберите ребро";
            // 
            // turnEdge90DegreesButton
            // 
            this.turnEdge90DegreesButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.turnEdge90DegreesButton.Location = new System.Drawing.Point(1040, 316);
            this.turnEdge90DegreesButton.Name = "turnEdge90DegreesButton";
            this.turnEdge90DegreesButton.Size = new System.Drawing.Size(192, 73);
            this.turnEdge90DegreesButton.TabIndex = 16;
            this.turnEdge90DegreesButton.Text = "Поворот на 90 градусов";
            this.turnEdge90DegreesButton.UseVisualStyleBackColor = true;
            this.turnEdge90DegreesButton.Click += new System.EventHandler(this.turnEdge90DegreesButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.edgePositionRelationLabel);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Location = new System.Drawing.Point(858, 408);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 185);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Положение точки относительно ребра";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(11, 68);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(365, 61);
            this.button8.TabIndex = 0;
            this.button8.Text = "Определить";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.buttonTask3_Click);
            // 
            // edgePositionRelationLabel
            // 
            this.edgePositionRelationLabel.AutoSize = true;
            this.edgePositionRelationLabel.Location = new System.Drawing.Point(16, 155);
            this.edgePositionRelationLabel.Name = "edgePositionRelationLabel";
            this.edgePositionRelationLabel.Size = new System.Drawing.Size(70, 25);
            this.edgePositionRelationLabel.TabIndex = 1;
            this.edgePositionRelationLabel.Text = "label4";
            this.edgePositionRelationLabel.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.polygonPositionRelationLabel);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Location = new System.Drawing.Point(858, 628);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 168);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Принадлежность точки полигону";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(19, 51);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(360, 61);
            this.button9.TabIndex = 0;
            this.button9.Text = "Определить";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.buttonPrinadlegit_Click);
            // 
            // polygonPositionRelationLabel
            // 
            this.polygonPositionRelationLabel.AutoSize = true;
            this.polygonPositionRelationLabel.Location = new System.Drawing.Point(14, 130);
            this.polygonPositionRelationLabel.Name = "polygonPositionRelationLabel";
            this.polygonPositionRelationLabel.Size = new System.Drawing.Size(70, 25);
            this.polygonPositionRelationLabel.TabIndex = 1;
            this.polygonPositionRelationLabel.Text = "label5";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1270, 836);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.turnEdge90DegreesButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edgesComboBox);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Аффинные преобразования";
            ((System.ComponentModel.ISupportInitialize)(this.scenePictureBox)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.ComboBox edgesComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button turnEdge90DegreesButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label edgePositionRelationLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label polygonPositionRelationLabel;
        private System.Windows.Forms.Button button9;
    }
}

