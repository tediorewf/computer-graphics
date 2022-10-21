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
        this.polyhedronSelectionComboBox = new System.Windows.Forms.ComboBox();
        this.polyhedronSelectionLabel = new System.Windows.Forms.Label();
        this.projectionSelectionComboBox = new System.Windows.Forms.ComboBox();
        this.projectionSelectionLabel = new System.Windows.Forms.Label();
        this.reflectionCoordinatePlaneComboBox = new System.Windows.Forms.ComboBox();
        this.reflectionCoordinatePlaneLabel = new System.Windows.Forms.Label();
        this.rotationAroundEdgeGroupBox = new System.Windows.Forms.GroupBox();
        this.rotationAroundEdgeEndPointZTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeEndPointYTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeBeginPointZTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeBeginPointYTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeAngleButton = new System.Windows.Forms.Button();
        this.rotationAroundEdgeEndPointXTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeBeginPointXTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeEndPointLabel = new System.Windows.Forms.Label();
        this.rotationAroundEdgeBeginPointLabel = new System.Windows.Forms.Label();
        this.rotationAroundEdgeAngleTextBox = new System.Windows.Forms.TextBox();
        this.rotationAroundEdgeAngleLabel = new System.Windows.Forms.Label();
        this.affineTransformationsGroupBox = new System.Windows.Forms.GroupBox();
        this.scalingGroupBox = new System.Windows.Forms.GroupBox();
        this.scalingButton = new System.Windows.Forms.Button();
        this.scalingZTextBox = new System.Windows.Forms.TextBox();
        this.scalingYTextBox = new System.Windows.Forms.TextBox();
        this.scalingXTextBox = new System.Windows.Forms.TextBox();
        this.scalingZLabel = new System.Windows.Forms.Label();
        this.scalingYLabel = new System.Windows.Forms.Label();
        this.scalingXLabel = new System.Windows.Forms.Label();
        this.rotationGroupBox = new System.Windows.Forms.GroupBox();
        this.rotateButton = new System.Windows.Forms.Button();
        this.rotationZTextBox = new System.Windows.Forms.TextBox();
        this.rotationYTextBox = new System.Windows.Forms.TextBox();
        this.rotationXTextBox = new System.Windows.Forms.TextBox();
        this.rotaionDegreesZLabel = new System.Windows.Forms.Label();
        this.rotaionDegreesYLabel = new System.Windows.Forms.Label();
        this.rotaionDegreesXLabel = new System.Windows.Forms.Label();
        this.translationGroupBox = new System.Windows.Forms.GroupBox();
        this.translationZLabel = new System.Windows.Forms.Label();
        this.translationYLabel = new System.Windows.Forms.Label();
        this.translationXLabel = new System.Windows.Forms.Label();
        this.translationXTextBox = new System.Windows.Forms.TextBox();
        this.translateButton = new System.Windows.Forms.Button();
        this.translationYTextBox = new System.Windows.Forms.TextBox();
        this.translationZTextBox = new System.Windows.Forms.TextBox();
        this.translationLabel = new System.Windows.Forms.Label();
        this.reflectionGroupBox = new System.Windows.Forms.GroupBox();
        this.reflectButton = new System.Windows.Forms.Button();
        this.centeredScalingGroupBox = new System.Windows.Forms.GroupBox();
        this.decreaseScaleButton = new System.Windows.Forms.Button();
        this.increaseScaleButton = new System.Windows.Forms.Button();
        this.rotatingGroupBox = new System.Windows.Forms.GroupBox();
        this.rotationCoordinatePlaneLabel = new System.Windows.Forms.Label();
        this.rotationCoordinatePlaneComboBox = new System.Windows.Forms.ComboBox();
        this.resetButton = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.polyhedronPictureBox)).BeginInit();
        this.rotationAroundEdgeGroupBox.SuspendLayout();
        this.affineTransformationsGroupBox.SuspendLayout();
        this.scalingGroupBox.SuspendLayout();
        this.rotationGroupBox.SuspendLayout();
        this.translationGroupBox.SuspendLayout();
        this.reflectionGroupBox.SuspendLayout();
        this.centeredScalingGroupBox.SuspendLayout();
        this.rotatingGroupBox.SuspendLayout();
        this.SuspendLayout();
        //
        // polyhedronPictureBox
        //
        this.polyhedronPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                            | System.Windows.Forms.AnchorStyles.Left)));
        this.polyhedronPictureBox.Location = new System.Drawing.Point(12, 13);
        this.polyhedronPictureBox.Margin = new System.Windows.Forms.Padding(4);
        this.polyhedronPictureBox.Name = "polyhedronPictureBox";
        this.polyhedronPictureBox.Size = new System.Drawing.Size(787, 787);
        this.polyhedronPictureBox.TabIndex = 0;
        this.polyhedronPictureBox.TabStop = false;
        this.polyhedronPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.polyhedronPictureBox_MouseClick);
        this.polyhedronPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.polyhedronPictureBox_MouseMove);
        //
        // polyhedronSelectionComboBox
        //
        this.polyhedronSelectionComboBox.FormattingEnabled = true;
        this.polyhedronSelectionComboBox.Location = new System.Drawing.Point(806, 39);
        this.polyhedronSelectionComboBox.Name = "polyhedronSelectionComboBox";
        this.polyhedronSelectionComboBox.Size = new System.Drawing.Size(233, 33);
        this.polyhedronSelectionComboBox.TabIndex = 23;
        this.polyhedronSelectionComboBox.SelectionChangeCommitted += new System.EventHandler(this.polyhedronComboBox_SelectionChangeCommitted);
        //
        // polyhedronSelectionLabel
        //
        this.polyhedronSelectionLabel.AutoSize = true;
        this.polyhedronSelectionLabel.Location = new System.Drawing.Point(806, 11);
        this.polyhedronSelectionLabel.Name = "polyhedronSelectionLabel";
        this.polyhedronSelectionLabel.Size = new System.Drawing.Size(233, 25);
        this.polyhedronSelectionLabel.TabIndex = 24;
        this.polyhedronSelectionLabel.Text = "Выбор многогранника";
        //
        // projectionSelectionComboBox
        //
        this.projectionSelectionComboBox.FormattingEnabled = true;
        this.projectionSelectionComboBox.Location = new System.Drawing.Point(1045, 39);
        this.projectionSelectionComboBox.Name = "projectionSelectionComboBox";
        this.projectionSelectionComboBox.Size = new System.Drawing.Size(233, 33);
        this.projectionSelectionComboBox.TabIndex = 25;
        this.projectionSelectionComboBox.SelectionChangeCommitted += new System.EventHandler(this.projectionSelectionComboBox_SelectionChangeCommitted);
        //
        // projectionSelectionLabel
        //
        this.projectionSelectionLabel.AutoSize = true;
        this.projectionSelectionLabel.Location = new System.Drawing.Point(1050, 9);
        this.projectionSelectionLabel.Name = "projectionSelectionLabel";
        this.projectionSelectionLabel.Size = new System.Drawing.Size(178, 25);
        this.projectionSelectionLabel.TabIndex = 26;
        this.projectionSelectionLabel.Text = "Выбор проекции";
        //
        // reflectionCoordinatePlaneComboBox
        //
        this.reflectionCoordinatePlaneComboBox.FormattingEnabled = true;
        this.reflectionCoordinatePlaneComboBox.Location = new System.Drawing.Point(17, 55);
        this.reflectionCoordinatePlaneComboBox.Name = "reflectionCoordinatePlaneComboBox";
        this.reflectionCoordinatePlaneComboBox.Size = new System.Drawing.Size(171, 33);
        this.reflectionCoordinatePlaneComboBox.TabIndex = 27;
        this.reflectionCoordinatePlaneComboBox.SelectionChangeCommitted += new System.EventHandler(this.reflectionCoordinatePlaneComboBox_SelectionChangeCommitted);
        //
        // reflectionCoordinatePlaneLabel
        //
        this.reflectionCoordinatePlaneLabel.AutoSize = true;
        this.reflectionCoordinatePlaneLabel.Location = new System.Drawing.Point(23, 27);
        this.reflectionCoordinatePlaneLabel.Name = "reflectionCoordinatePlaneLabel";
        this.reflectionCoordinatePlaneLabel.Size = new System.Drawing.Size(117, 25);
        this.reflectionCoordinatePlaneLabel.TabIndex = 28;
        this.reflectionCoordinatePlaneLabel.Text = "Плоскость";
        //
        // rotationAroundEdgeGroupBox
        //
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeEndPointZTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeEndPointYTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeBeginPointZTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeBeginPointYTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeAngleButton);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeEndPointXTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeBeginPointXTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeEndPointLabel);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeBeginPointLabel);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeAngleTextBox);
        this.rotationAroundEdgeGroupBox.Controls.Add(this.rotationAroundEdgeAngleLabel);
        this.rotationAroundEdgeGroupBox.Location = new System.Drawing.Point(809, 635);
        this.rotationAroundEdgeGroupBox.Name = "rotationAroundEdgeGroupBox";
        this.rotationAroundEdgeGroupBox.Size = new System.Drawing.Size(628, 163);
        this.rotationAroundEdgeGroupBox.TabIndex = 29;
        this.rotationAroundEdgeGroupBox.TabStop = false;
        this.rotationAroundEdgeGroupBox.Text = "Поворот вокруг произвольной прямой на заданный угол";
        //
        // rotationAroundEdgeEndPointZTextBox
        //
        this.rotationAroundEdgeEndPointZTextBox.Location = new System.Drawing.Point(284, 118);
        this.rotationAroundEdgeEndPointZTextBox.Name = "rotationAroundEdgeEndPointZTextBox";
        this.rotationAroundEdgeEndPointZTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationAroundEdgeEndPointZTextBox.TabIndex = 9;
        //
        // rotationAroundEdgeEndPointYTextBox
        //
        this.rotationAroundEdgeEndPointYTextBox.Location = new System.Drawing.Point(148, 118);
        this.rotationAroundEdgeEndPointYTextBox.Name = "rotationAroundEdgeEndPointYTextBox";
        this.rotationAroundEdgeEndPointYTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationAroundEdgeEndPointYTextBox.TabIndex = 8;
        //
        // rotationAroundEdgeBeginPointZTextBox
        //
        this.rotationAroundEdgeBeginPointZTextBox.Location = new System.Drawing.Point(280, 59);
        this.rotationAroundEdgeBeginPointZTextBox.Name = "rotationAroundEdgeBeginPointZTextBox";
        this.rotationAroundEdgeBeginPointZTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationAroundEdgeBeginPointZTextBox.TabIndex = 6;
        //
        // rotationAroundEdgeBeginPointYTextBox
        //
        this.rotationAroundEdgeBeginPointYTextBox.Location = new System.Drawing.Point(144, 59);
        this.rotationAroundEdgeBeginPointYTextBox.Name = "rotationAroundEdgeBeginPointYTextBox";
        this.rotationAroundEdgeBeginPointYTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationAroundEdgeBeginPointYTextBox.TabIndex = 5;
        //
        // rotationAroundEdgeAngleButton
        //
        this.rotationAroundEdgeAngleButton.Location = new System.Drawing.Point(427, 48);
        this.rotationAroundEdgeAngleButton.Name = "rotationAroundEdgeAngleButton";
        this.rotationAroundEdgeAngleButton.Size = new System.Drawing.Size(183, 39);
        this.rotationAroundEdgeAngleButton.TabIndex = 11;
        this.rotationAroundEdgeAngleButton.Text = "Повернуть";
        this.rotationAroundEdgeAngleButton.UseVisualStyleBackColor = true;
        this.rotationAroundEdgeAngleButton.Click += new System.EventHandler(this.rotationAroundEdgeAngleButton_Click);
        //
        // rotationAroundEdgeEndPointXTextBox
        //
        this.rotationAroundEdgeEndPointXTextBox.Location = new System.Drawing.Point(9, 118);
        this.rotationAroundEdgeEndPointXTextBox.Name = "rotationAroundEdgeEndPointXTextBox";
        this.rotationAroundEdgeEndPointXTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationAroundEdgeEndPointXTextBox.TabIndex = 7;
        this.rotationAroundEdgeEndPointXTextBox.TextChanged += new System.EventHandler(this.rotationAroundEdgeEndPointTextBox_TextChanged);
        //
        // rotationAroundEdgeBeginPointXTextBox
        //
        this.rotationAroundEdgeBeginPointXTextBox.Location = new System.Drawing.Point(8, 59);
        this.rotationAroundEdgeBeginPointXTextBox.Name = "rotationAroundEdgeBeginPointXTextBox";
        this.rotationAroundEdgeBeginPointXTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationAroundEdgeBeginPointXTextBox.TabIndex = 4;
        //
        // rotationAroundEdgeEndPointLabel
        //
        this.rotationAroundEdgeEndPointLabel.AutoSize = true;
        this.rotationAroundEdgeEndPointLabel.Location = new System.Drawing.Point(13, 90);
        this.rotationAroundEdgeEndPointLabel.Name = "rotationAroundEdgeEndPointLabel";
        this.rotationAroundEdgeEndPointLabel.Size = new System.Drawing.Size(170, 25);
        this.rotationAroundEdgeEndPointLabel.TabIndex = 3;
        this.rotationAroundEdgeEndPointLabel.Text = "Конечная точка";
        //
        // rotationAroundEdgeBeginPointLabel
        //
        this.rotationAroundEdgeBeginPointLabel.AutoSize = true;
        this.rotationAroundEdgeBeginPointLabel.Location = new System.Drawing.Point(9, 27);
        this.rotationAroundEdgeBeginPointLabel.Name = "rotationAroundEdgeBeginPointLabel";
        this.rotationAroundEdgeBeginPointLabel.Size = new System.Drawing.Size(182, 25);
        this.rotationAroundEdgeBeginPointLabel.TabIndex = 2;
        this.rotationAroundEdgeBeginPointLabel.Text = "Начальная точка";
        //
        // rotationAroundEdgeAngleTextBox
        //
        this.rotationAroundEdgeAngleTextBox.Location = new System.Drawing.Point(429, 117);
        this.rotationAroundEdgeAngleTextBox.Name = "rotationAroundEdgeAngleTextBox";
        this.rotationAroundEdgeAngleTextBox.Size = new System.Drawing.Size(183, 31);
        this.rotationAroundEdgeAngleTextBox.TabIndex = 10;
        //
        // rotationAroundEdgeAngleLabel
        //
        this.rotationAroundEdgeAngleLabel.AutoSize = true;
        this.rotationAroundEdgeAngleLabel.Location = new System.Drawing.Point(427, 90);
        this.rotationAroundEdgeAngleLabel.Name = "rotationAroundEdgeAngleLabel";
        this.rotationAroundEdgeAngleLabel.Size = new System.Drawing.Size(183, 25);
        this.rotationAroundEdgeAngleLabel.TabIndex = 0;
        this.rotationAroundEdgeAngleLabel.Text = "Угол (в градусах)";
        //
        // affineTransformationsGroupBox
        //
        this.affineTransformationsGroupBox.Controls.Add(this.scalingGroupBox);
        this.affineTransformationsGroupBox.Controls.Add(this.rotationGroupBox);
        this.affineTransformationsGroupBox.Controls.Add(this.translationGroupBox);
        this.affineTransformationsGroupBox.Controls.Add(this.translationLabel);
        this.affineTransformationsGroupBox.Location = new System.Drawing.Point(806, 78);
        this.affineTransformationsGroupBox.Name = "affineTransformationsGroupBox";
        this.affineTransformationsGroupBox.Size = new System.Drawing.Size(634, 382);
        this.affineTransformationsGroupBox.TabIndex = 30;
        this.affineTransformationsGroupBox.TabStop = false;
        this.affineTransformationsGroupBox.Text = "Аффинные преобразования";
        //
        // scalingGroupBox
        //
        this.scalingGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                       | System.Windows.Forms.AnchorStyles.Right)));
        this.scalingGroupBox.Controls.Add(this.scalingButton);
        this.scalingGroupBox.Controls.Add(this.scalingZTextBox);
        this.scalingGroupBox.Controls.Add(this.scalingYTextBox);
        this.scalingGroupBox.Controls.Add(this.scalingXTextBox);
        this.scalingGroupBox.Controls.Add(this.scalingZLabel);
        this.scalingGroupBox.Controls.Add(this.scalingYLabel);
        this.scalingGroupBox.Controls.Add(this.scalingXLabel);
        this.scalingGroupBox.Location = new System.Drawing.Point(8, 268);
        this.scalingGroupBox.Name = "scalingGroupBox";
        this.scalingGroupBox.Size = new System.Drawing.Size(623, 97);
        this.scalingGroupBox.TabIndex = 7;
        this.scalingGroupBox.TabStop = false;
        this.scalingGroupBox.Text = "Масштаб";
        //
        // scalingButton
        //
        this.scalingButton.Location = new System.Drawing.Point(412, 47);
        this.scalingButton.Name = "scalingButton";
        this.scalingButton.Size = new System.Drawing.Size(197, 39);
        this.scalingButton.TabIndex = 7;
        this.scalingButton.Text = "Масштабировать";
        this.scalingButton.UseVisualStyleBackColor = true;
        this.scalingButton.Click += new System.EventHandler(this.scalingButton_Click);
        //
        // scalingZTextBox
        //
        this.scalingZTextBox.Location = new System.Drawing.Point(281, 55);
        this.scalingZTextBox.Name = "scalingZTextBox";
        this.scalingZTextBox.Size = new System.Drawing.Size(124, 31);
        this.scalingZTextBox.TabIndex = 5;
        //
        // scalingYTextBox
        //
        this.scalingYTextBox.Location = new System.Drawing.Point(139, 55);
        this.scalingYTextBox.Name = "scalingYTextBox";
        this.scalingYTextBox.Size = new System.Drawing.Size(130, 31);
        this.scalingYTextBox.TabIndex = 4;
        //
        // scalingXTextBox
        //
        this.scalingXTextBox.Location = new System.Drawing.Point(3, 56);
        this.scalingXTextBox.Name = "scalingXTextBox";
        this.scalingXTextBox.Size = new System.Drawing.Size(130, 31);
        this.scalingXTextBox.TabIndex = 3;
        //
        // scalingZLabel
        //
        this.scalingZLabel.AutoSize = true;
        this.scalingZLabel.Location = new System.Drawing.Point(288, 27);
        this.scalingZLabel.Name = "scalingZLabel";
        this.scalingZLabel.Size = new System.Drawing.Size(145, 25);
        this.scalingZLabel.TabIndex = 2;
        this.scalingZLabel.Text = "Множитель Z";
        //
        // scalingYLabel
        //
        this.scalingYLabel.AutoSize = true;
        this.scalingYLabel.Location = new System.Drawing.Point(147, 27);
        this.scalingYLabel.Name = "scalingYLabel";
        this.scalingYLabel.Size = new System.Drawing.Size(147, 25);
        this.scalingYLabel.TabIndex = 1;
        this.scalingYLabel.Text = "Множитель Y";
        //
        // scalingXLabel
        //
        this.scalingXLabel.AutoSize = true;
        this.scalingXLabel.Location = new System.Drawing.Point(6, 27);
        this.scalingXLabel.Name = "scalingXLabel";
        this.scalingXLabel.Size = new System.Drawing.Size(146, 25);
        this.scalingXLabel.TabIndex = 0;
        this.scalingXLabel.Text = "Множитель X";
        //
        // rotationGroupBox
        //
        this.rotationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                        | System.Windows.Forms.AnchorStyles.Right)));
        this.rotationGroupBox.Controls.Add(this.rotateButton);
        this.rotationGroupBox.Controls.Add(this.rotationZTextBox);
        this.rotationGroupBox.Controls.Add(this.rotationYTextBox);
        this.rotationGroupBox.Controls.Add(this.rotationXTextBox);
        this.rotationGroupBox.Controls.Add(this.rotaionDegreesZLabel);
        this.rotationGroupBox.Controls.Add(this.rotaionDegreesYLabel);
        this.rotationGroupBox.Controls.Add(this.rotaionDegreesXLabel);
        this.rotationGroupBox.Location = new System.Drawing.Point(6, 164);
        this.rotationGroupBox.Name = "rotationGroupBox";
        this.rotationGroupBox.Size = new System.Drawing.Size(625, 98);
        this.rotationGroupBox.TabIndex = 6;
        this.rotationGroupBox.TabStop = false;
        this.rotationGroupBox.Text = "Поворот";
        //
        // rotateButton
        //
        this.rotateButton.Location = new System.Drawing.Point(414, 47);
        this.rotateButton.Name = "rotateButton";
        this.rotateButton.Size = new System.Drawing.Size(197, 39);
        this.rotateButton.TabIndex = 6;
        this.rotateButton.Text = "Повернуть";
        this.rotateButton.UseVisualStyleBackColor = true;
        this.rotateButton.Click += new System.EventHandler(this.rotateButton_Click);
        //
        // rotationZTextBox
        //
        this.rotationZTextBox.Location = new System.Drawing.Point(282, 55);
        this.rotationZTextBox.Name = "rotationZTextBox";
        this.rotationZTextBox.Size = new System.Drawing.Size(124, 31);
        this.rotationZTextBox.TabIndex = 5;
        //
        // rotationYTextBox
        //
        this.rotationYTextBox.Location = new System.Drawing.Point(140, 55);
        this.rotationYTextBox.Name = "rotationYTextBox";
        this.rotationYTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationYTextBox.TabIndex = 4;
        //
        // rotationXTextBox
        //
        this.rotationXTextBox.Location = new System.Drawing.Point(4, 55);
        this.rotationXTextBox.Name = "rotationXTextBox";
        this.rotationXTextBox.Size = new System.Drawing.Size(130, 31);
        this.rotationXTextBox.TabIndex = 3;
        //
        // rotaionDegreesZLabel
        //
        this.rotaionDegreesZLabel.AutoSize = true;
        this.rotaionDegreesZLabel.Location = new System.Drawing.Point(286, 27);
        this.rotaionDegreesZLabel.Name = "rotaionDegreesZLabel";
        this.rotaionDegreesZLabel.Size = new System.Drawing.Size(76, 25);
        this.rotaionDegreesZLabel.TabIndex = 2;
        this.rotaionDegreesZLabel.Text = "Угол Z";
        //
        // rotaionDegreesYLabel
        //
        this.rotaionDegreesYLabel.AutoSize = true;
        this.rotaionDegreesYLabel.Location = new System.Drawing.Point(149, 27);
        this.rotaionDegreesYLabel.Name = "rotaionDegreesYLabel";
        this.rotaionDegreesYLabel.Size = new System.Drawing.Size(78, 25);
        this.rotaionDegreesYLabel.TabIndex = 1;
        this.rotaionDegreesYLabel.Text = "Угол Y";
        //
        // rotaionDegreesXLabel
        //
        this.rotaionDegreesXLabel.AutoSize = true;
        this.rotaionDegreesXLabel.Location = new System.Drawing.Point(14, 27);
        this.rotaionDegreesXLabel.Name = "rotaionDegreesXLabel";
        this.rotaionDegreesXLabel.Size = new System.Drawing.Size(77, 25);
        this.rotaionDegreesXLabel.TabIndex = 0;
        this.rotaionDegreesXLabel.Text = "Угол X";
        //
        // translationGroupBox
        //
        this.translationGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                           | System.Windows.Forms.AnchorStyles.Right)));
        this.translationGroupBox.Controls.Add(this.translationZLabel);
        this.translationGroupBox.Controls.Add(this.translationYLabel);
        this.translationGroupBox.Controls.Add(this.translationXLabel);
        this.translationGroupBox.Controls.Add(this.translationXTextBox);
        this.translationGroupBox.Controls.Add(this.translateButton);
        this.translationGroupBox.Controls.Add(this.translationYTextBox);
        this.translationGroupBox.Controls.Add(this.translationZTextBox);
        this.translationGroupBox.Location = new System.Drawing.Point(6, 37);
        this.translationGroupBox.Name = "translationGroupBox";
        this.translationGroupBox.Size = new System.Drawing.Size(625, 121);
        this.translationGroupBox.TabIndex = 5;
        this.translationGroupBox.TabStop = false;
        this.translationGroupBox.Text = "Смещение";
        //
        // translationZLabel
        //
        this.translationZLabel.AutoSize = true;
        this.translationZLabel.Location = new System.Drawing.Point(278, 35);
        this.translationZLabel.Name = "translationZLabel";
        this.translationZLabel.Size = new System.Drawing.Size(138, 25);
        this.translationZLabel.TabIndex = 7;
        this.translationZLabel.Text = "Смещение Z";
        //
        // translationYLabel
        //
        this.translationYLabel.AutoSize = true;
        this.translationYLabel.Location = new System.Drawing.Point(141, 35);
        this.translationYLabel.Name = "translationYLabel";
        this.translationYLabel.Size = new System.Drawing.Size(140, 25);
        this.translationYLabel.TabIndex = 6;
        this.translationYLabel.Text = "Смещение Y";
        //
        // translationXLabel
        //
        this.translationXLabel.AutoSize = true;
        this.translationXLabel.Location = new System.Drawing.Point(6, 35);
        this.translationXLabel.Name = "translationXLabel";
        this.translationXLabel.Size = new System.Drawing.Size(139, 25);
        this.translationXLabel.TabIndex = 5;
        this.translationXLabel.Text = "Смещение X";
        //
        // translationXTextBox
        //
        this.translationXTextBox.Location = new System.Drawing.Point(4, 75);
        this.translationXTextBox.Name = "translationXTextBox";
        this.translationXTextBox.Size = new System.Drawing.Size(130, 31);
        this.translationXTextBox.TabIndex = 1;
        //
        // translateButton
        //
        this.translateButton.Location = new System.Drawing.Point(414, 71);
        this.translateButton.Name = "translateButton";
        this.translateButton.Size = new System.Drawing.Size(197, 39);
        this.translateButton.TabIndex = 4;
        this.translateButton.Text = "Сместить";
        this.translateButton.UseVisualStyleBackColor = true;
        this.translateButton.Click += new System.EventHandler(this.translateButton_Click);
        //
        // translationYTextBox
        //
        this.translationYTextBox.Location = new System.Drawing.Point(140, 75);
        this.translationYTextBox.Name = "translationYTextBox";
        this.translationYTextBox.Size = new System.Drawing.Size(130, 31);
        this.translationYTextBox.TabIndex = 2;
        //
        // translationZTextBox
        //
        this.translationZTextBox.Location = new System.Drawing.Point(277, 75);
        this.translationZTextBox.Name = "translationZTextBox";
        this.translationZTextBox.Size = new System.Drawing.Size(129, 31);
        this.translationZTextBox.TabIndex = 3;
        //
        // translationLabel
        //
        this.translationLabel.AutoSize = true;
        this.translationLabel.Location = new System.Drawing.Point(14, 37);
        this.translationLabel.Name = "translationLabel";
        this.translationLabel.Size = new System.Drawing.Size(0, 25);
        this.translationLabel.TabIndex = 0;
        //
        // reflectionGroupBox
        //
        this.reflectionGroupBox.Controls.Add(this.reflectButton);
        this.reflectionGroupBox.Controls.Add(this.reflectionCoordinatePlaneLabel);
        this.reflectionGroupBox.Controls.Add(this.reflectionCoordinatePlaneComboBox);
        this.reflectionGroupBox.Location = new System.Drawing.Point(806, 466);
        this.reflectionGroupBox.Name = "reflectionGroupBox";
        this.reflectionGroupBox.Size = new System.Drawing.Size(219, 163);
        this.reflectionGroupBox.TabIndex = 31;
        this.reflectionGroupBox.TabStop = false;
        this.reflectionGroupBox.Text = "Отражение";
        //
        // reflectButton
        //
        this.reflectButton.Location = new System.Drawing.Point(17, 106);
        this.reflectButton.Name = "reflectButton";
        this.reflectButton.Size = new System.Drawing.Size(171, 39);
        this.reflectButton.TabIndex = 29;
        this.reflectButton.Text = "Отразить";
        this.reflectButton.UseVisualStyleBackColor = true;
        this.reflectButton.Click += new System.EventHandler(this.reflectButton_Click);
        //
        // centeredScalingGroupBox
        //
        this.centeredScalingGroupBox.Controls.Add(this.decreaseScaleButton);
        this.centeredScalingGroupBox.Controls.Add(this.increaseScaleButton);
        this.centeredScalingGroupBox.Location = new System.Drawing.Point(1031, 552);
        this.centeredScalingGroupBox.Name = "centeredScalingGroupBox";
        this.centeredScalingGroupBox.Size = new System.Drawing.Size(406, 77);
        this.centeredScalingGroupBox.TabIndex = 32;
        this.centeredScalingGroupBox.TabStop = false;
        this.centeredScalingGroupBox.Text = "Масштабирование";
        //
        // decreaseScaleButton
        //
        this.decreaseScaleButton.Location = new System.Drawing.Point(199, 30);
        this.decreaseScaleButton.Name = "decreaseScaleButton";
        this.decreaseScaleButton.Size = new System.Drawing.Size(193, 40);
        this.decreaseScaleButton.TabIndex = 31;
        this.decreaseScaleButton.Text = "-";
        this.decreaseScaleButton.UseVisualStyleBackColor = true;
        this.decreaseScaleButton.Click += new System.EventHandler(this.MashtabMinus);
        //
        // increaseScaleButton
        //
        this.increaseScaleButton.Location = new System.Drawing.Point(6, 30);
        this.increaseScaleButton.Name = "increaseScaleButton";
        this.increaseScaleButton.Size = new System.Drawing.Size(181, 40);
        this.increaseScaleButton.TabIndex = 30;
        this.increaseScaleButton.Text = "+";
        this.increaseScaleButton.UseVisualStyleBackColor = true;
        this.increaseScaleButton.Click += new System.EventHandler(this.MashtabPlus);
        //
        // rotatingGroupBox
        //
        this.rotatingGroupBox.Controls.Add(this.rotationCoordinatePlaneLabel);
        this.rotatingGroupBox.Controls.Add(this.rotationCoordinatePlaneComboBox);
        this.rotatingGroupBox.Location = new System.Drawing.Point(1031, 466);
        this.rotatingGroupBox.Name = "rotatingGroupBox";
        this.rotatingGroupBox.Size = new System.Drawing.Size(408, 80);
        this.rotatingGroupBox.TabIndex = 33;
        this.rotatingGroupBox.TabStop = false;
        this.rotatingGroupBox.Text = "Вращение";
        //
        // rotationCoordinatePlaneLabel
        //
        this.rotationCoordinatePlaneLabel.AutoSize = true;
        this.rotationCoordinatePlaneLabel.Location = new System.Drawing.Point(23, 38);
        this.rotationCoordinatePlaneLabel.Name = "rotationCoordinatePlaneLabel";
        this.rotationCoordinatePlaneLabel.Size = new System.Drawing.Size(117, 25);
        this.rotationCoordinatePlaneLabel.TabIndex = 1;
        this.rotationCoordinatePlaneLabel.Text = "Плоскость";
        //
        // rotationCoordinatePlaneComboBox
        //
        this.rotationCoordinatePlaneComboBox.FormattingEnabled = true;
        this.rotationCoordinatePlaneComboBox.Location = new System.Drawing.Point(163, 35);
        this.rotationCoordinatePlaneComboBox.Name = "rotationCoordinatePlaneComboBox";
        this.rotationCoordinatePlaneComboBox.Size = new System.Drawing.Size(171, 33);
        this.rotationCoordinatePlaneComboBox.TabIndex = 0;
        this.rotationCoordinatePlaneComboBox.SelectionChangeCommitted += new System.EventHandler(this.rotationCoordinatePlaneComboBox_SelectionChangeCommitted);
        //
        // resetButton
        //
        this.resetButton.Location = new System.Drawing.Point(1284, 13);
        this.resetButton.Name = "resetButton";
        this.resetButton.Size = new System.Drawing.Size(156, 59);
        this.resetButton.TabIndex = 34;
        this.resetButton.Text = "Сброс";
        this.resetButton.UseVisualStyleBackColor = true;
        this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
        //
        // MainForm
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1452, 811);
        this.Controls.Add(this.resetButton);
        this.Controls.Add(this.rotatingGroupBox);
        this.Controls.Add(this.centeredScalingGroupBox);
        this.Controls.Add(this.reflectionGroupBox);
        this.Controls.Add(this.affineTransformationsGroupBox);
        this.Controls.Add(this.rotationAroundEdgeGroupBox);
        this.Controls.Add(this.projectionSelectionLabel);
        this.Controls.Add(this.projectionSelectionComboBox);
        this.Controls.Add(this.polyhedronSelectionLabel);
        this.Controls.Add(this.polyhedronSelectionComboBox);
        this.Controls.Add(this.polyhedronPictureBox);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Margin = new System.Windows.Forms.Padding(4);
        this.MaximizeBox = false;
        this.Name = "MainForm";
        this.Text = "Аффинные преобразования в пространстве. Проецирование";
        this.Load += new System.EventHandler(this.MainForm_Load);
        ((System.ComponentModel.ISupportInitialize)(this.polyhedronPictureBox)).EndInit();
        this.rotationAroundEdgeGroupBox.ResumeLayout(false);
        this.rotationAroundEdgeGroupBox.PerformLayout();
        this.affineTransformationsGroupBox.ResumeLayout(false);
        this.affineTransformationsGroupBox.PerformLayout();
        this.scalingGroupBox.ResumeLayout(false);
        this.scalingGroupBox.PerformLayout();
        this.rotationGroupBox.ResumeLayout(false);
        this.rotationGroupBox.PerformLayout();
        this.translationGroupBox.ResumeLayout(false);
        this.translationGroupBox.PerformLayout();
        this.reflectionGroupBox.ResumeLayout(false);
        this.reflectionGroupBox.PerformLayout();
        this.centeredScalingGroupBox.ResumeLayout(false);
        this.rotatingGroupBox.ResumeLayout(false);
        this.rotatingGroupBox.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox polyhedronPictureBox;
    private System.Windows.Forms.ComboBox polyhedronSelectionComboBox;
    private System.Windows.Forms.Label polyhedronSelectionLabel;
    private System.Windows.Forms.ComboBox projectionSelectionComboBox;
    private System.Windows.Forms.Label projectionSelectionLabel;
    private System.Windows.Forms.ComboBox reflectionCoordinatePlaneComboBox;
    private System.Windows.Forms.Label reflectionCoordinatePlaneLabel;
    private System.Windows.Forms.GroupBox rotationAroundEdgeGroupBox;
    private System.Windows.Forms.Button rotationAroundEdgeAngleButton;
    private System.Windows.Forms.TextBox rotationAroundEdgeEndPointXTextBox;
    private System.Windows.Forms.TextBox rotationAroundEdgeBeginPointXTextBox;
    private System.Windows.Forms.Label rotationAroundEdgeEndPointLabel;
    private System.Windows.Forms.Label rotationAroundEdgeBeginPointLabel;
    private System.Windows.Forms.TextBox rotationAroundEdgeAngleTextBox;
    private System.Windows.Forms.Label rotationAroundEdgeAngleLabel;
    private System.Windows.Forms.TextBox rotationAroundEdgeBeginPointYTextBox;
    private System.Windows.Forms.TextBox rotationAroundEdgeBeginPointZTextBox;
    private System.Windows.Forms.TextBox rotationAroundEdgeEndPointZTextBox;
    private System.Windows.Forms.TextBox rotationAroundEdgeEndPointYTextBox;
    private System.Windows.Forms.GroupBox affineTransformationsGroupBox;
    private System.Windows.Forms.Label translationLabel;
    private System.Windows.Forms.GroupBox translationGroupBox;
    private System.Windows.Forms.Label translationZLabel;
    private System.Windows.Forms.Label translationYLabel;
    private System.Windows.Forms.Label translationXLabel;
    private System.Windows.Forms.TextBox translationXTextBox;
    private System.Windows.Forms.Button translateButton;
    private System.Windows.Forms.TextBox translationYTextBox;
    private System.Windows.Forms.TextBox translationZTextBox;
    private System.Windows.Forms.GroupBox rotationGroupBox;
    private System.Windows.Forms.Button rotateButton;
    private System.Windows.Forms.TextBox rotationZTextBox;
    private System.Windows.Forms.TextBox rotationYTextBox;
    private System.Windows.Forms.TextBox rotationXTextBox;
    private System.Windows.Forms.Label rotaionDegreesZLabel;
    private System.Windows.Forms.Label rotaionDegreesYLabel;
    private System.Windows.Forms.Label rotaionDegreesXLabel;
    private System.Windows.Forms.GroupBox scalingGroupBox;
    private System.Windows.Forms.Button scalingButton;
    private System.Windows.Forms.TextBox scalingZTextBox;
    private System.Windows.Forms.TextBox scalingYTextBox;
    private System.Windows.Forms.TextBox scalingXTextBox;
    private System.Windows.Forms.Label scalingZLabel;
    private System.Windows.Forms.Label scalingYLabel;
    private System.Windows.Forms.Label scalingXLabel;
    private System.Windows.Forms.GroupBox reflectionGroupBox;
    private System.Windows.Forms.Button reflectButton;
    private System.Windows.Forms.GroupBox centeredScalingGroupBox;
    private System.Windows.Forms.Button decreaseScaleButton;
    private System.Windows.Forms.Button increaseScaleButton;
    private System.Windows.Forms.GroupBox rotatingGroupBox;
    private System.Windows.Forms.Label rotationCoordinatePlaneLabel;
    private System.Windows.Forms.ComboBox rotationCoordinatePlaneComboBox;
    private System.Windows.Forms.Button resetButton;
}
}

