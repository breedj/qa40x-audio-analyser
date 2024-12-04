namespace QA402_REST_TEST
{
    partial class frmMain
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
            this.scTopBottom = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblThdFreq_Message = new System.Windows.Forms.Label();
            this.btnMeasurement_ThdFreq = new System.Windows.Forms.Button();
            this.scThdVsFreq = new System.Windows.Forms.SplitContainer();
            this.btnStopThdMeasurement = new System.Windows.Forms.Button();
            this.graphFft = new ScottPlot.WinForms.FormsPlot();
            this.btnStartThdMeasurement = new System.Windows.Forms.Button();
            this.graphTime = new ScottPlot.WinForms.FormsPlot();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbThdFreq_OutputVoltageUnit = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThdFreq_OutputVoltage = new System.Windows.Forms.TextBox();
            this.udThdFreq_Averages = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThdFreq_EndFreq = new System.Windows.Forms.TextBox();
            this.txtThdFreq_StartFreq = new System.Windows.Forms.TextBox();
            this.lblThdFreq_PowerUnit = new System.Windows.Forms.Label();
            this.lblThdFreq_OutputPower = new System.Windows.Forms.Label();
            this.txtThdFreq_OutputPower = new System.Windows.Forms.TextBox();
            this.lblThdFreq_OutputLoadUnit = new System.Windows.Forms.Label();
            this.lblThdFreq_OutputLoad = new System.Windows.Forms.Label();
            this.txtThdFreq_OutputLoad = new System.Windows.Forms.TextBox();
            this.cmbThdFreq_GenVoltageUnit = new System.Windows.Forms.ComboBox();
            this.lblThdFreq_GenVoltage = new System.Windows.Forms.Label();
            this.txtThdFreq_GenVoltage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbThdFreq_GenType = new System.Windows.Forms.ComboBox();
            this.udThdFreq_StepsOctave = new System.Windows.Forms.NumericUpDown();
            this.lblThdFreq_StepsPerOctave = new System.Windows.Forms.Label();
            this.lblThdFreq_EndFrequency = new System.Windows.Forms.Label();
            this.lblThdFreq_StartFrequency = new System.Windows.Forms.Label();
            this.scGraphCursors = new System.Windows.Forms.SplitContainer();
            this.scGraphSettings = new System.Windows.Forms.SplitContainer();
            this.thdPlot = new ScottPlot.WinForms.FormsPlot();
            this.chkThdFreq_ShowMarkers = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ThickLines = new System.Windows.Forms.CheckBox();
            this.gbThdFreq_dBV_Range = new System.Windows.Forms.GroupBox();
            this.cmbThdFreq_dBV_Graph_Bottom = new System.Windows.Forms.NumericUpDown();
            this.cmbThdFreq_dBV_Graph_Top = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnThdFreq_dBV_FitGraphY = new System.Windows.Forms.Button();
            this.gbThdFreq_Harmonics = new System.Windows.Forms.GroupBox();
            this.chkThdFreq_ShowMagnitude = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowNoiseFloor = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowD6 = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowD5 = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowD4 = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowD3 = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowD2 = new System.Windows.Forms.CheckBox();
            this.chkThdFreq_ShowThd = new System.Windows.Forms.CheckBox();
            this.btnFreqThd_Graph_dBV = new System.Windows.Forms.Button();
            this.btnFreqThd_Graph_D = new System.Windows.Forms.Button();
            this.gbThdFreq_FrequencyRange = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbThdFreq_Graph_To = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbThdFreq_Graph_From = new System.Windows.Forms.ComboBox();
            this.btnThdFreq_FitGraphX = new System.Windows.Forms.Button();
            this.gbThdFreq_D_Range = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbThdFreq_D_Graph_Bottom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbThdFreq_D_Graph_Top = new System.Windows.Forms.ComboBox();
            this.btnThdFreq_D_FitGraphY = new System.Windows.Forms.Button();
            this.lblThdFreq_NoiseFloor = new System.Windows.Forms.Label();
            this.lblThdFreq_Power = new System.Windows.Forms.Label();
            this.lblThdFreq_DC = new System.Windows.Forms.Label();
            this.lblThdFreq_D6 = new System.Windows.Forms.Label();
            this.lblThdFreq_D5 = new System.Windows.Forms.Label();
            this.lblThdFreq_D4 = new System.Windows.Forms.Label();
            this.lblThdFreq_D3 = new System.Windows.Forms.Label();
            this.lblThdFreq_D2 = new System.Windows.Forms.Label();
            this.lblThdFreq_THD = new System.Windows.Forms.Label();
            this.lblThdFreq_Magnitude = new System.Windows.Forms.Label();
            this.lblThdFreq_Frequency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scTopBottom)).BeginInit();
            this.scTopBottom.Panel1.SuspendLayout();
            this.scTopBottom.Panel2.SuspendLayout();
            this.scTopBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scThdVsFreq)).BeginInit();
            this.scThdVsFreq.Panel1.SuspendLayout();
            this.scThdVsFreq.Panel2.SuspendLayout();
            this.scThdVsFreq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udThdFreq_Averages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThdFreq_StepsOctave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphCursors)).BeginInit();
            this.scGraphCursors.Panel1.SuspendLayout();
            this.scGraphCursors.Panel2.SuspendLayout();
            this.scGraphCursors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphSettings)).BeginInit();
            this.scGraphSettings.Panel1.SuspendLayout();
            this.scGraphSettings.Panel2.SuspendLayout();
            this.scGraphSettings.SuspendLayout();
            this.gbThdFreq_dBV_Range.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThdFreq_dBV_Graph_Bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThdFreq_dBV_Graph_Top)).BeginInit();
            this.gbThdFreq_Harmonics.SuspendLayout();
            this.gbThdFreq_FrequencyRange.SuspendLayout();
            this.gbThdFreq_D_Range.SuspendLayout();
            this.SuspendLayout();
            // 
            // scTopBottom
            // 
            this.scTopBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scTopBottom.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scTopBottom.IsSplitterFixed = true;
            this.scTopBottom.Location = new System.Drawing.Point(0, 0);
            this.scTopBottom.Name = "scTopBottom";
            this.scTopBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scTopBottom.Panel1
            // 
            this.scTopBottom.Panel1.Controls.Add(this.progressBar1);
            this.scTopBottom.Panel1.Controls.Add(this.lblThdFreq_Message);
            this.scTopBottom.Panel1.Controls.Add(this.btnMeasurement_ThdFreq);
            // 
            // scTopBottom.Panel2
            // 
            this.scTopBottom.Panel2.Controls.Add(this.scThdVsFreq);
            this.scTopBottom.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scTopBottom.Size = new System.Drawing.Size(1241, 789);
            this.scTopBottom.SplitterDistance = 60;
            this.scTopBottom.TabIndex = 0;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(1122, 40);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(112, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Value = 20;
            // 
            // lblThdFreq_Message
            // 
            this.lblThdFreq_Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_Message.ForeColor = System.Drawing.Color.IndianRed;
            this.lblThdFreq_Message.Location = new System.Drawing.Point(632, 18);
            this.lblThdFreq_Message.Name = "lblThdFreq_Message";
            this.lblThdFreq_Message.Size = new System.Drawing.Size(606, 22);
            this.lblThdFreq_Message.TabIndex = 8;
            this.lblThdFreq_Message.Text = "Message";
            this.lblThdFreq_Message.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnMeasurement_ThdFreq
            // 
            this.btnMeasurement_ThdFreq.BackColor = System.Drawing.Color.Bisque;
            this.btnMeasurement_ThdFreq.FlatAppearance.BorderColor = System.Drawing.Color.Peru;
            this.btnMeasurement_ThdFreq.FlatAppearance.BorderSize = 2;
            this.btnMeasurement_ThdFreq.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMeasurement_ThdFreq.Location = new System.Drawing.Point(3, 3);
            this.btnMeasurement_ThdFreq.Name = "btnMeasurement_ThdFreq";
            this.btnMeasurement_ThdFreq.Size = new System.Drawing.Size(113, 54);
            this.btnMeasurement_ThdFreq.TabIndex = 7;
            this.btnMeasurement_ThdFreq.Text = "THD vs Frequency";
            this.btnMeasurement_ThdFreq.UseVisualStyleBackColor = false;
            this.btnMeasurement_ThdFreq.Click += new System.EventHandler(this.button1_Click);
            // 
            // scThdVsFreq
            // 
            this.scThdVsFreq.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scThdVsFreq.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scThdVsFreq.IsSplitterFixed = true;
            this.scThdVsFreq.Location = new System.Drawing.Point(0, 0);
            this.scThdVsFreq.Name = "scThdVsFreq";
            // 
            // scThdVsFreq.Panel1
            // 
            this.scThdVsFreq.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.scThdVsFreq.Panel1.Controls.Add(this.btnStopThdMeasurement);
            this.scThdVsFreq.Panel1.Controls.Add(this.graphFft);
            this.scThdVsFreq.Panel1.Controls.Add(this.btnStartThdMeasurement);
            this.scThdVsFreq.Panel1.Controls.Add(this.graphTime);
            this.scThdVsFreq.Panel1.Controls.Add(this.groupBox1);
            this.scThdVsFreq.Panel1MinSize = 260;
            // 
            // scThdVsFreq.Panel2
            // 
            this.scThdVsFreq.Panel2.Controls.Add(this.scGraphCursors);
            this.scThdVsFreq.Panel2MinSize = 200;
            this.scThdVsFreq.Size = new System.Drawing.Size(1241, 725);
            this.scThdVsFreq.SplitterDistance = 260;
            this.scThdVsFreq.TabIndex = 0;
            // 
            // btnStopThdMeasurement
            // 
            this.btnStopThdMeasurement.BackColor = System.Drawing.Color.LightCoral;
            this.btnStopThdMeasurement.Enabled = false;
            this.btnStopThdMeasurement.FlatAppearance.BorderColor = System.Drawing.Color.Tomato;
            this.btnStopThdMeasurement.FlatAppearance.BorderSize = 2;
            this.btnStopThdMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStopThdMeasurement.ForeColor = System.Drawing.Color.DimGray;
            this.btnStopThdMeasurement.Location = new System.Drawing.Point(135, 3);
            this.btnStopThdMeasurement.Name = "btnStopThdMeasurement";
            this.btnStopThdMeasurement.Size = new System.Drawing.Size(109, 37);
            this.btnStopThdMeasurement.TabIndex = 7;
            this.btnStopThdMeasurement.Text = "STOP MEASUREMENT";
            this.btnStopThdMeasurement.UseVisualStyleBackColor = false;
            this.btnStopThdMeasurement.Click += new System.EventHandler(this.btnCancelThdMeasurement_Click);
            // 
            // graphFft
            // 
            this.graphFft.DisplayScale = 0F;
            this.graphFft.Location = new System.Drawing.Point(3, 345);
            this.graphFft.Name = "graphFft";
            this.graphFft.Size = new System.Drawing.Size(254, 188);
            this.graphFft.TabIndex = 6;
            // 
            // btnStartThdMeasurement
            // 
            this.btnStartThdMeasurement.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnStartThdMeasurement.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnStartThdMeasurement.FlatAppearance.BorderSize = 2;
            this.btnStartThdMeasurement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStartThdMeasurement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartThdMeasurement.Location = new System.Drawing.Point(15, 3);
            this.btnStartThdMeasurement.Name = "btnStartThdMeasurement";
            this.btnStartThdMeasurement.Size = new System.Drawing.Size(109, 37);
            this.btnStartThdMeasurement.TabIndex = 5;
            this.btnStartThdMeasurement.Text = "START MEASUREMENT";
            this.btnStartThdMeasurement.UseVisualStyleBackColor = false;
            this.btnStartThdMeasurement.Click += new System.EventHandler(this.btnStartThdMeasurement_Click);
            // 
            // graphTime
            // 
            this.graphTime.DisplayScale = 0F;
            this.graphTime.Location = new System.Drawing.Point(3, 539);
            this.graphTime.Name = "graphTime";
            this.graphTime.Size = new System.Drawing.Size(254, 183);
            this.graphTime.TabIndex = 3;
            this.graphTime.Load += new System.EventHandler(this.graphTime_Load);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbThdFreq_OutputVoltageUnit);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtThdFreq_OutputVoltage);
            this.groupBox1.Controls.Add(this.udThdFreq_Averages);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtThdFreq_EndFreq);
            this.groupBox1.Controls.Add(this.txtThdFreq_StartFreq);
            this.groupBox1.Controls.Add(this.lblThdFreq_PowerUnit);
            this.groupBox1.Controls.Add(this.lblThdFreq_OutputPower);
            this.groupBox1.Controls.Add(this.txtThdFreq_OutputPower);
            this.groupBox1.Controls.Add(this.lblThdFreq_OutputLoadUnit);
            this.groupBox1.Controls.Add(this.lblThdFreq_OutputLoad);
            this.groupBox1.Controls.Add(this.txtThdFreq_OutputLoad);
            this.groupBox1.Controls.Add(this.cmbThdFreq_GenVoltageUnit);
            this.groupBox1.Controls.Add(this.lblThdFreq_GenVoltage);
            this.groupBox1.Controls.Add(this.txtThdFreq_GenVoltage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbThdFreq_GenType);
            this.groupBox1.Controls.Add(this.udThdFreq_StepsOctave);
            this.groupBox1.Controls.Add(this.lblThdFreq_StepsPerOctave);
            this.groupBox1.Controls.Add(this.lblThdFreq_EndFrequency);
            this.groupBox1.Controls.Add(this.lblThdFreq_StartFrequency);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Settings";
            // 
            // cmbThdFreq_OutputVoltageUnit
            // 
            this.cmbThdFreq_OutputVoltageUnit.DisplayMember = "1";
            this.cmbThdFreq_OutputVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_OutputVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_OutputVoltageUnit.FormattingEnabled = true;
            this.cmbThdFreq_OutputVoltageUnit.Items.AddRange(new object[] {
            "mV",
            "V",
            "dBV"});
            this.cmbThdFreq_OutputVoltageUnit.Location = new System.Drawing.Point(192, 122);
            this.cmbThdFreq_OutputVoltageUnit.Name = "cmbThdFreq_OutputVoltageUnit";
            this.cmbThdFreq_OutputVoltageUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbThdFreq_OutputVoltageUnit.TabIndex = 27;
            this.cmbThdFreq_OutputVoltageUnit.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_OutputVoltageUnit_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(19, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Output Voltage";
            // 
            // txtThdFreq_OutputVoltage
            // 
            this.txtThdFreq_OutputVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThdFreq_OutputVoltage.Location = new System.Drawing.Point(110, 123);
            this.txtThdFreq_OutputVoltage.Name = "txtThdFreq_OutputVoltage";
            this.txtThdFreq_OutputVoltage.Size = new System.Drawing.Size(76, 20);
            this.txtThdFreq_OutputVoltage.TabIndex = 25;
            this.txtThdFreq_OutputVoltage.TextChanged += new System.EventHandler(this.txtThdFreq_OutputVoltage_TextChanged);
            this.txtThdFreq_OutputVoltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThdFreq_OutputVoltage_KeyPress);
            // 
            // udThdFreq_Averages
            // 
            this.udThdFreq_Averages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udThdFreq_Averages.Location = new System.Drawing.Point(128, 259);
            this.udThdFreq_Averages.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.udThdFreq_Averages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udThdFreq_Averages.Name = "udThdFreq_Averages";
            this.udThdFreq_Averages.Size = new System.Drawing.Size(84, 20);
            this.udThdFreq_Averages.TabIndex = 24;
            this.udThdFreq_Averages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udThdFreq_Averages.ValueChanged += new System.EventHandler(this.udThdFreq_Averages_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(18, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Averages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(218, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Hz";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(218, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hz";
            // 
            // txtThdFreq_EndFreq
            // 
            this.txtThdFreq_EndFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThdFreq_EndFreq.Location = new System.Drawing.Point(128, 205);
            this.txtThdFreq_EndFreq.Name = "txtThdFreq_EndFreq";
            this.txtThdFreq_EndFreq.Size = new System.Drawing.Size(84, 20);
            this.txtThdFreq_EndFreq.TabIndex = 20;
            this.txtThdFreq_EndFreq.Text = "20000";
            this.txtThdFreq_EndFreq.TextChanged += new System.EventHandler(this.txtThdFreq_EndFreq_TextChanged);
            this.txtThdFreq_EndFreq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThdFreq_EndFreq_KeyPress);
            // 
            // txtThdFreq_StartFreq
            // 
            this.txtThdFreq_StartFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThdFreq_StartFreq.Location = new System.Drawing.Point(128, 179);
            this.txtThdFreq_StartFreq.Name = "txtThdFreq_StartFreq";
            this.txtThdFreq_StartFreq.Size = new System.Drawing.Size(84, 20);
            this.txtThdFreq_StartFreq.TabIndex = 19;
            this.txtThdFreq_StartFreq.Text = "20";
            this.txtThdFreq_StartFreq.TextChanged += new System.EventHandler(this.txtThdFreq_StartFreq_TextChanged);
            this.txtThdFreq_StartFreq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThdFreq_StartFreq_KeyPress);
            // 
            // lblThdFreq_PowerUnit
            // 
            this.lblThdFreq_PowerUnit.AutoSize = true;
            this.lblThdFreq_PowerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_PowerUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_PowerUnit.Location = new System.Drawing.Point(193, 100);
            this.lblThdFreq_PowerUnit.Name = "lblThdFreq_PowerUnit";
            this.lblThdFreq_PowerUnit.Size = new System.Drawing.Size(30, 13);
            this.lblThdFreq_PowerUnit.TabIndex = 18;
            this.lblThdFreq_PowerUnit.Text = "Watt";
            // 
            // lblThdFreq_OutputPower
            // 
            this.lblThdFreq_OutputPower.AutoSize = true;
            this.lblThdFreq_OutputPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_OutputPower.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_OutputPower.Location = new System.Drawing.Point(20, 100);
            this.lblThdFreq_OutputPower.Name = "lblThdFreq_OutputPower";
            this.lblThdFreq_OutputPower.Size = new System.Drawing.Size(72, 13);
            this.lblThdFreq_OutputPower.TabIndex = 17;
            this.lblThdFreq_OutputPower.Text = "Output Power";
            // 
            // txtThdFreq_OutputPower
            // 
            this.txtThdFreq_OutputPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThdFreq_OutputPower.Location = new System.Drawing.Point(111, 97);
            this.txtThdFreq_OutputPower.Name = "txtThdFreq_OutputPower";
            this.txtThdFreq_OutputPower.Size = new System.Drawing.Size(76, 20);
            this.txtThdFreq_OutputPower.TabIndex = 16;
            this.txtThdFreq_OutputPower.Text = "1";
            this.txtThdFreq_OutputPower.TextChanged += new System.EventHandler(this.txtThdFreq_OutputPower_TextChanged);
            this.txtThdFreq_OutputPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThdFreq_OutputPower_KeyPress);
            // 
            // lblThdFreq_OutputLoadUnit
            // 
            this.lblThdFreq_OutputLoadUnit.AutoSize = true;
            this.lblThdFreq_OutputLoadUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_OutputLoadUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_OutputLoadUnit.Location = new System.Drawing.Point(193, 74);
            this.lblThdFreq_OutputLoadUnit.Name = "lblThdFreq_OutputLoadUnit";
            this.lblThdFreq_OutputLoadUnit.Size = new System.Drawing.Size(29, 13);
            this.lblThdFreq_OutputLoadUnit.TabIndex = 15;
            this.lblThdFreq_OutputLoadUnit.Text = "Ohm";
            // 
            // lblThdFreq_OutputLoad
            // 
            this.lblThdFreq_OutputLoad.AutoSize = true;
            this.lblThdFreq_OutputLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_OutputLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_OutputLoad.Location = new System.Drawing.Point(20, 74);
            this.lblThdFreq_OutputLoad.Name = "lblThdFreq_OutputLoad";
            this.lblThdFreq_OutputLoad.Size = new System.Drawing.Size(73, 13);
            this.lblThdFreq_OutputLoad.TabIndex = 14;
            this.lblThdFreq_OutputLoad.Text = "Amplifier Load";
            this.lblThdFreq_OutputLoad.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtThdFreq_OutputLoad
            // 
            this.txtThdFreq_OutputLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThdFreq_OutputLoad.Location = new System.Drawing.Point(111, 71);
            this.txtThdFreq_OutputLoad.Name = "txtThdFreq_OutputLoad";
            this.txtThdFreq_OutputLoad.Size = new System.Drawing.Size(76, 20);
            this.txtThdFreq_OutputLoad.TabIndex = 13;
            this.txtThdFreq_OutputLoad.Text = "8";
            this.txtThdFreq_OutputLoad.TextChanged += new System.EventHandler(this.txtThdFreq_OutputLoad_TextChanged);
            this.txtThdFreq_OutputLoad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThdFreq_OutputLoad_KeyPress);
            // 
            // cmbThdFreq_GenVoltageUnit
            // 
            this.cmbThdFreq_GenVoltageUnit.DisplayMember = "1";
            this.cmbThdFreq_GenVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_GenVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_GenVoltageUnit.FormattingEnabled = true;
            this.cmbThdFreq_GenVoltageUnit.Items.AddRange(new object[] {
            "mV",
            "V",
            "dBV"});
            this.cmbThdFreq_GenVoltageUnit.Location = new System.Drawing.Point(193, 44);
            this.cmbThdFreq_GenVoltageUnit.Name = "cmbThdFreq_GenVoltageUnit";
            this.cmbThdFreq_GenVoltageUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbThdFreq_GenVoltageUnit.TabIndex = 12;
            this.cmbThdFreq_GenVoltageUnit.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_VoltageUnit_SelectedIndexChanged);
            // 
            // lblThdFreq_GenVoltage
            // 
            this.lblThdFreq_GenVoltage.AutoSize = true;
            this.lblThdFreq_GenVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_GenVoltage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_GenVoltage.Location = new System.Drawing.Point(20, 47);
            this.lblThdFreq_GenVoltage.Name = "lblThdFreq_GenVoltage";
            this.lblThdFreq_GenVoltage.Size = new System.Drawing.Size(66, 13);
            this.lblThdFreq_GenVoltage.TabIndex = 11;
            this.lblThdFreq_GenVoltage.Text = "Gen Voltage";
            // 
            // txtThdFreq_GenVoltage
            // 
            this.txtThdFreq_GenVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThdFreq_GenVoltage.Location = new System.Drawing.Point(111, 45);
            this.txtThdFreq_GenVoltage.Name = "txtThdFreq_GenVoltage";
            this.txtThdFreq_GenVoltage.Size = new System.Drawing.Size(76, 20);
            this.txtThdFreq_GenVoltage.TabIndex = 10;
            this.txtThdFreq_GenVoltage.TextChanged += new System.EventHandler(this.txtThdFreq_GenVoltage_TextChanged);
            this.txtThdFreq_GenVoltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThdFreq_GenVoltage_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Type";
            // 
            // cmbThdFreq_GenType
            // 
            this.cmbThdFreq_GenType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_GenType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_GenType.FormattingEnabled = true;
            this.cmbThdFreq_GenType.Items.AddRange(new object[] {
            "Input voltage",
            "Output voltage",
            "Output power"});
            this.cmbThdFreq_GenType.Location = new System.Drawing.Point(111, 19);
            this.cmbThdFreq_GenType.Name = "cmbThdFreq_GenType";
            this.cmbThdFreq_GenType.Size = new System.Drawing.Size(130, 21);
            this.cmbThdFreq_GenType.TabIndex = 8;
            this.cmbThdFreq_GenType.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_GenType_SelectedIndexChanged);
            // 
            // udThdFreq_StepsOctave
            // 
            this.udThdFreq_StepsOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udThdFreq_StepsOctave.Location = new System.Drawing.Point(128, 232);
            this.udThdFreq_StepsOctave.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.udThdFreq_StepsOctave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udThdFreq_StepsOctave.Name = "udThdFreq_StepsOctave";
            this.udThdFreq_StepsOctave.Size = new System.Drawing.Size(84, 20);
            this.udThdFreq_StepsOctave.TabIndex = 7;
            this.udThdFreq_StepsOctave.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udThdFreq_StepsOctave.ValueChanged += new System.EventHandler(this.udThdFreq_StepsOctave_ValueChanged);
            // 
            // lblThdFreq_StepsPerOctave
            // 
            this.lblThdFreq_StepsPerOctave.AutoSize = true;
            this.lblThdFreq_StepsPerOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_StepsPerOctave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_StepsPerOctave.Location = new System.Drawing.Point(18, 234);
            this.lblThdFreq_StepsPerOctave.Name = "lblThdFreq_StepsPerOctave";
            this.lblThdFreq_StepsPerOctave.Size = new System.Drawing.Size(80, 13);
            this.lblThdFreq_StepsPerOctave.TabIndex = 4;
            this.lblThdFreq_StepsPerOctave.Text = "Steps / Octave";
            // 
            // lblThdFreq_EndFrequency
            // 
            this.lblThdFreq_EndFrequency.AutoSize = true;
            this.lblThdFreq_EndFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_EndFrequency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_EndFrequency.Location = new System.Drawing.Point(18, 208);
            this.lblThdFreq_EndFrequency.Name = "lblThdFreq_EndFrequency";
            this.lblThdFreq_EndFrequency.Size = new System.Drawing.Size(79, 13);
            this.lblThdFreq_EndFrequency.TabIndex = 2;
            this.lblThdFreq_EndFrequency.Text = "End Frequency";
            // 
            // lblThdFreq_StartFrequency
            // 
            this.lblThdFreq_StartFrequency.AutoSize = true;
            this.lblThdFreq_StartFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_StartFrequency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_StartFrequency.Location = new System.Drawing.Point(18, 182);
            this.lblThdFreq_StartFrequency.Name = "lblThdFreq_StartFrequency";
            this.lblThdFreq_StartFrequency.Size = new System.Drawing.Size(82, 13);
            this.lblThdFreq_StartFrequency.TabIndex = 0;
            this.lblThdFreq_StartFrequency.Text = "Start Frequency";
            // 
            // scGraphCursors
            // 
            this.scGraphCursors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGraphCursors.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scGraphCursors.IsSplitterFixed = true;
            this.scGraphCursors.Location = new System.Drawing.Point(0, 0);
            this.scGraphCursors.Name = "scGraphCursors";
            this.scGraphCursors.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scGraphCursors.Panel1
            // 
            this.scGraphCursors.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            this.scGraphCursors.Panel1.Controls.Add(this.scGraphSettings);
            this.scGraphCursors.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // scGraphCursors.Panel2
            // 
            this.scGraphCursors.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_NoiseFloor);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_Power);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_DC);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_D6);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_D5);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_D4);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_D3);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_D2);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_THD);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_Magnitude);
            this.scGraphCursors.Panel2.Controls.Add(this.lblThdFreq_Frequency);
            this.scGraphCursors.Size = new System.Drawing.Size(977, 725);
            this.scGraphCursors.SplitterDistance = 670;
            this.scGraphCursors.TabIndex = 0;
            // 
            // scGraphSettings
            // 
            this.scGraphSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scGraphSettings.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scGraphSettings.IsSplitterFixed = true;
            this.scGraphSettings.Location = new System.Drawing.Point(0, 0);
            this.scGraphSettings.Name = "scGraphSettings";
            // 
            // scGraphSettings.Panel1
            // 
            this.scGraphSettings.Panel1.Controls.Add(this.thdPlot);
            // 
            // scGraphSettings.Panel2
            // 
            this.scGraphSettings.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.scGraphSettings.Panel2.Controls.Add(this.chkThdFreq_ShowMarkers);
            this.scGraphSettings.Panel2.Controls.Add(this.chkThdFreq_ThickLines);
            this.scGraphSettings.Panel2.Controls.Add(this.gbThdFreq_dBV_Range);
            this.scGraphSettings.Panel2.Controls.Add(this.gbThdFreq_Harmonics);
            this.scGraphSettings.Panel2.Controls.Add(this.btnFreqThd_Graph_dBV);
            this.scGraphSettings.Panel2.Controls.Add(this.btnFreqThd_Graph_D);
            this.scGraphSettings.Panel2.Controls.Add(this.gbThdFreq_FrequencyRange);
            this.scGraphSettings.Panel2.Controls.Add(this.gbThdFreq_D_Range);
            this.scGraphSettings.Size = new System.Drawing.Size(977, 670);
            this.scGraphSettings.SplitterDistance = 850;
            this.scGraphSettings.TabIndex = 0;
            // 
            // thdPlot
            // 
            this.thdPlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.thdPlot.DisplayScale = 0F;
            this.thdPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thdPlot.Location = new System.Drawing.Point(0, 0);
            this.thdPlot.Name = "thdPlot";
            this.thdPlot.Size = new System.Drawing.Size(850, 670);
            this.thdPlot.TabIndex = 2;
            // 
            // chkThdFreq_ShowMarkers
            // 
            this.chkThdFreq_ShowMarkers.AutoSize = true;
            this.chkThdFreq_ShowMarkers.Location = new System.Drawing.Point(12, 596);
            this.chkThdFreq_ShowMarkers.Name = "chkThdFreq_ShowMarkers";
            this.chkThdFreq_ShowMarkers.Size = new System.Drawing.Size(108, 17);
            this.chkThdFreq_ShowMarkers.TabIndex = 45;
            this.chkThdFreq_ShowMarkers.Text = "Show data points";
            this.chkThdFreq_ShowMarkers.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowMarkers.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ThickLines
            // 
            this.chkThdFreq_ThickLines.AutoSize = true;
            this.chkThdFreq_ThickLines.Checked = true;
            this.chkThdFreq_ThickLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ThickLines.Location = new System.Drawing.Point(12, 576);
            this.chkThdFreq_ThickLines.Name = "chkThdFreq_ThickLines";
            this.chkThdFreq_ThickLines.Size = new System.Drawing.Size(77, 17);
            this.chkThdFreq_ThickLines.TabIndex = 44;
            this.chkThdFreq_ThickLines.Text = "Thick lines";
            this.chkThdFreq_ThickLines.UseVisualStyleBackColor = true;
            this.chkThdFreq_ThickLines.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // gbThdFreq_dBV_Range
            // 
            this.gbThdFreq_dBV_Range.Controls.Add(this.cmbThdFreq_dBV_Graph_Bottom);
            this.gbThdFreq_dBV_Range.Controls.Add(this.cmbThdFreq_dBV_Graph_Top);
            this.gbThdFreq_dBV_Range.Controls.Add(this.label10);
            this.gbThdFreq_dBV_Range.Controls.Add(this.label11);
            this.gbThdFreq_dBV_Range.Controls.Add(this.btnThdFreq_dBV_FitGraphY);
            this.gbThdFreq_dBV_Range.Location = new System.Drawing.Point(43, 20);
            this.gbThdFreq_dBV_Range.Name = "gbThdFreq_dBV_Range";
            this.gbThdFreq_dBV_Range.Size = new System.Drawing.Size(113, 143);
            this.gbThdFreq_dBV_Range.TabIndex = 30;
            this.gbThdFreq_dBV_Range.TabStop = false;
            this.gbThdFreq_dBV_Range.Text = "dB range";
            // 
            // cmbThdFreq_dBV_Graph_Bottom
            // 
            this.cmbThdFreq_dBV_Graph_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_dBV_Graph_Bottom.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbThdFreq_dBV_Graph_Bottom.Location = new System.Drawing.Point(8, 77);
            this.cmbThdFreq_dBV_Graph_Bottom.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cmbThdFreq_dBV_Graph_Bottom.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.cmbThdFreq_dBV_Graph_Bottom.Name = "cmbThdFreq_dBV_Graph_Bottom";
            this.cmbThdFreq_dBV_Graph_Bottom.Size = new System.Drawing.Size(94, 20);
            this.cmbThdFreq_dBV_Graph_Bottom.TabIndex = 31;
            this.cmbThdFreq_dBV_Graph_Bottom.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cmbThdFreq_dBV_Graph_Bottom.ValueChanged += new System.EventHandler(this.cmbThdFreq_dBV_Graph_Top_ValueChanged);
            // 
            // cmbThdFreq_dBV_Graph_Top
            // 
            this.cmbThdFreq_dBV_Graph_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_dBV_Graph_Top.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbThdFreq_dBV_Graph_Top.Location = new System.Drawing.Point(8, 36);
            this.cmbThdFreq_dBV_Graph_Top.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cmbThdFreq_dBV_Graph_Top.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.cmbThdFreq_dBV_Graph_Top.Name = "cmbThdFreq_dBV_Graph_Top";
            this.cmbThdFreq_dBV_Graph_Top.Size = new System.Drawing.Size(94, 20);
            this.cmbThdFreq_dBV_Graph_Top.TabIndex = 30;
            this.cmbThdFreq_dBV_Graph_Top.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cmbThdFreq_dBV_Graph_Top.ValueChanged += new System.EventHandler(this.cmbThdFreq_dBV_Graph_Top_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(8, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Bottom";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(8, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(26, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Top";
            // 
            // btnThdFreq_dBV_FitGraphY
            // 
            this.btnThdFreq_dBV_FitGraphY.Location = new System.Drawing.Point(6, 109);
            this.btnThdFreq_dBV_FitGraphY.Name = "btnThdFreq_dBV_FitGraphY";
            this.btnThdFreq_dBV_FitGraphY.Size = new System.Drawing.Size(94, 23);
            this.btnThdFreq_dBV_FitGraphY.TabIndex = 25;
            this.btnThdFreq_dBV_FitGraphY.Text = "Autofit";
            this.btnThdFreq_dBV_FitGraphY.UseVisualStyleBackColor = true;
            this.btnThdFreq_dBV_FitGraphY.Click += new System.EventHandler(this.btnThdFreq_FitDbGraphY_Click);
            // 
            // gbThdFreq_Harmonics
            // 
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowMagnitude);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowNoiseFloor);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowD6);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowD5);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowD4);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowD3);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowD2);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkThdFreq_ShowThd);
            this.gbThdFreq_Harmonics.Location = new System.Drawing.Point(4, 363);
            this.gbThdFreq_Harmonics.Name = "gbThdFreq_Harmonics";
            this.gbThdFreq_Harmonics.Size = new System.Drawing.Size(111, 207);
            this.gbThdFreq_Harmonics.TabIndex = 29;
            this.gbThdFreq_Harmonics.TabStop = false;
            this.gbThdFreq_Harmonics.Text = "Graph data";
            // 
            // chkThdFreq_ShowMagnitude
            // 
            this.chkThdFreq_ShowMagnitude.AutoSize = true;
            this.chkThdFreq_ShowMagnitude.Checked = true;
            this.chkThdFreq_ShowMagnitude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowMagnitude.Location = new System.Drawing.Point(8, 19);
            this.chkThdFreq_ShowMagnitude.Name = "chkThdFreq_ShowMagnitude";
            this.chkThdFreq_ShowMagnitude.Size = new System.Drawing.Size(76, 17);
            this.chkThdFreq_ShowMagnitude.TabIndex = 43;
            this.chkThdFreq_ShowMagnitude.Text = "Magnitude";
            this.chkThdFreq_ShowMagnitude.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowMagnitude.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowNoiseFloor
            // 
            this.chkThdFreq_ShowNoiseFloor.AutoSize = true;
            this.chkThdFreq_ShowNoiseFloor.Checked = true;
            this.chkThdFreq_ShowNoiseFloor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowNoiseFloor.Location = new System.Drawing.Point(8, 180);
            this.chkThdFreq_ShowNoiseFloor.Name = "chkThdFreq_ShowNoiseFloor";
            this.chkThdFreq_ShowNoiseFloor.Size = new System.Drawing.Size(76, 17);
            this.chkThdFreq_ShowNoiseFloor.TabIndex = 42;
            this.chkThdFreq_ShowNoiseFloor.Text = "Noise floor";
            this.chkThdFreq_ShowNoiseFloor.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowNoiseFloor.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowD6
            // 
            this.chkThdFreq_ShowD6.AutoSize = true;
            this.chkThdFreq_ShowD6.Checked = true;
            this.chkThdFreq_ShowD6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowD6.Location = new System.Drawing.Point(8, 157);
            this.chkThdFreq_ShowD6.Name = "chkThdFreq_ShowD6";
            this.chkThdFreq_ShowD6.Size = new System.Drawing.Size(46, 17);
            this.chkThdFreq_ShowD6.TabIndex = 41;
            this.chkThdFreq_ShowD6.Text = "D6+";
            this.chkThdFreq_ShowD6.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowD6.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowD5
            // 
            this.chkThdFreq_ShowD5.AutoSize = true;
            this.chkThdFreq_ShowD5.Checked = true;
            this.chkThdFreq_ShowD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowD5.Location = new System.Drawing.Point(8, 134);
            this.chkThdFreq_ShowD5.Name = "chkThdFreq_ShowD5";
            this.chkThdFreq_ShowD5.Size = new System.Drawing.Size(40, 17);
            this.chkThdFreq_ShowD5.TabIndex = 40;
            this.chkThdFreq_ShowD5.Text = "D5";
            this.chkThdFreq_ShowD5.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowD5.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowD4
            // 
            this.chkThdFreq_ShowD4.AutoSize = true;
            this.chkThdFreq_ShowD4.Checked = true;
            this.chkThdFreq_ShowD4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowD4.Location = new System.Drawing.Point(8, 111);
            this.chkThdFreq_ShowD4.Name = "chkThdFreq_ShowD4";
            this.chkThdFreq_ShowD4.Size = new System.Drawing.Size(40, 17);
            this.chkThdFreq_ShowD4.TabIndex = 39;
            this.chkThdFreq_ShowD4.Text = "D4";
            this.chkThdFreq_ShowD4.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowD4.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowD3
            // 
            this.chkThdFreq_ShowD3.AutoSize = true;
            this.chkThdFreq_ShowD3.Checked = true;
            this.chkThdFreq_ShowD3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowD3.Location = new System.Drawing.Point(8, 88);
            this.chkThdFreq_ShowD3.Name = "chkThdFreq_ShowD3";
            this.chkThdFreq_ShowD3.Size = new System.Drawing.Size(40, 17);
            this.chkThdFreq_ShowD3.TabIndex = 38;
            this.chkThdFreq_ShowD3.Text = "D3";
            this.chkThdFreq_ShowD3.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowD3.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowD2
            // 
            this.chkThdFreq_ShowD2.AutoSize = true;
            this.chkThdFreq_ShowD2.Checked = true;
            this.chkThdFreq_ShowD2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowD2.Location = new System.Drawing.Point(8, 65);
            this.chkThdFreq_ShowD2.Name = "chkThdFreq_ShowD2";
            this.chkThdFreq_ShowD2.Size = new System.Drawing.Size(40, 17);
            this.chkThdFreq_ShowD2.TabIndex = 37;
            this.chkThdFreq_ShowD2.Text = "D2";
            this.chkThdFreq_ShowD2.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowD2.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // chkThdFreq_ShowThd
            // 
            this.chkThdFreq_ShowThd.AutoSize = true;
            this.chkThdFreq_ShowThd.Checked = true;
            this.chkThdFreq_ShowThd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThdFreq_ShowThd.Location = new System.Drawing.Point(8, 42);
            this.chkThdFreq_ShowThd.Name = "chkThdFreq_ShowThd";
            this.chkThdFreq_ShowThd.Size = new System.Drawing.Size(49, 17);
            this.chkThdFreq_ShowThd.TabIndex = 36;
            this.chkThdFreq_ShowThd.Text = "THD";
            this.chkThdFreq_ShowThd.UseVisualStyleBackColor = true;
            this.chkThdFreq_ShowThd.CheckedChanged += new System.EventHandler(this.chkThdFreq_ShowThd_CheckedChanged);
            // 
            // btnFreqThd_Graph_dBV
            // 
            this.btnFreqThd_Graph_dBV.BackColor = System.Drawing.Color.Cornsilk;
            this.btnFreqThd_Graph_dBV.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnFreqThd_Graph_dBV.FlatAppearance.BorderSize = 2;
            this.btnFreqThd_Graph_dBV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFreqThd_Graph_dBV.Location = new System.Drawing.Point(9, 626);
            this.btnFreqThd_Graph_dBV.Name = "btnFreqThd_Graph_dBV";
            this.btnFreqThd_Graph_dBV.Size = new System.Drawing.Size(52, 37);
            this.btnFreqThd_Graph_dBV.TabIndex = 28;
            this.btnFreqThd_Graph_dBV.Text = "D (dB)";
            this.btnFreqThd_Graph_dBV.UseVisualStyleBackColor = false;
            this.btnFreqThd_Graph_dBV.Click += new System.EventHandler(this.btnFreqThd_Graph_dBV_Click);
            // 
            // btnFreqThd_Graph_D
            // 
            this.btnFreqThd_Graph_D.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFreqThd_Graph_D.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnFreqThd_Graph_D.FlatAppearance.BorderSize = 2;
            this.btnFreqThd_Graph_D.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFreqThd_Graph_D.Location = new System.Drawing.Point(67, 626);
            this.btnFreqThd_Graph_D.Name = "btnFreqThd_Graph_D";
            this.btnFreqThd_Graph_D.Size = new System.Drawing.Size(49, 37);
            this.btnFreqThd_Graph_D.TabIndex = 27;
            this.btnFreqThd_Graph_D.Text = "D (%)";
            this.btnFreqThd_Graph_D.UseVisualStyleBackColor = false;
            this.btnFreqThd_Graph_D.Click += new System.EventHandler(this.btnFreqThd_Graph_D_Click);
            // 
            // gbThdFreq_FrequencyRange
            // 
            this.gbThdFreq_FrequencyRange.Controls.Add(this.label8);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.cmbThdFreq_Graph_To);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.label9);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.cmbThdFreq_Graph_From);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.btnThdFreq_FitGraphX);
            this.gbThdFreq_FrequencyRange.Location = new System.Drawing.Point(3, 195);
            this.gbThdFreq_FrequencyRange.Name = "gbThdFreq_FrequencyRange";
            this.gbThdFreq_FrequencyRange.Size = new System.Drawing.Size(112, 161);
            this.gbThdFreq_FrequencyRange.TabIndex = 26;
            this.gbThdFreq_FrequencyRange.TabStop = false;
            this.gbThdFreq_FrequencyRange.Text = "Frequency range";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(8, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 34;
            this.label8.Text = "To";
            // 
            // cmbThdFreq_Graph_To
            // 
            this.cmbThdFreq_Graph_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_Graph_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_Graph_To.FormattingEnabled = true;
            this.cmbThdFreq_Graph_To.Items.AddRange(new object[] {
            "1000",
            "2000",
            "5000",
            "10000",
            "20000",
            "50000",
            "100000"});
            this.cmbThdFreq_Graph_To.Location = new System.Drawing.Point(6, 82);
            this.cmbThdFreq_Graph_To.Name = "cmbThdFreq_Graph_To";
            this.cmbThdFreq_Graph_To.Size = new System.Drawing.Size(94, 21);
            this.cmbThdFreq_Graph_To.TabIndex = 33;
            this.cmbThdFreq_Graph_To.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_Graph_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(8, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 32;
            this.label9.Text = "From";
            // 
            // cmbThdFreq_Graph_From
            // 
            this.cmbThdFreq_Graph_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_Graph_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_Graph_From.FormattingEnabled = true;
            this.cmbThdFreq_Graph_From.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "50",
            "100",
            "200",
            "500"});
            this.cmbThdFreq_Graph_From.Location = new System.Drawing.Point(6, 38);
            this.cmbThdFreq_Graph_From.Name = "cmbThdFreq_Graph_From";
            this.cmbThdFreq_Graph_From.Size = new System.Drawing.Size(94, 21);
            this.cmbThdFreq_Graph_From.TabIndex = 31;
            this.cmbThdFreq_Graph_From.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_Graph_SelectedIndexChanged);
            // 
            // btnThdFreq_FitGraphX
            // 
            this.btnThdFreq_FitGraphX.Location = new System.Drawing.Point(6, 117);
            this.btnThdFreq_FitGraphX.Name = "btnThdFreq_FitGraphX";
            this.btnThdFreq_FitGraphX.Size = new System.Drawing.Size(94, 23);
            this.btnThdFreq_FitGraphX.TabIndex = 30;
            this.btnThdFreq_FitGraphX.Text = "Autofit";
            this.btnThdFreq_FitGraphX.UseVisualStyleBackColor = true;
            this.btnThdFreq_FitGraphX.Click += new System.EventHandler(this.btnThdFreq_FitGraphX_Click);
            // 
            // gbThdFreq_D_Range
            // 
            this.gbThdFreq_D_Range.Controls.Add(this.label7);
            this.gbThdFreq_D_Range.Controls.Add(this.cmbThdFreq_D_Graph_Bottom);
            this.gbThdFreq_D_Range.Controls.Add(this.label6);
            this.gbThdFreq_D_Range.Controls.Add(this.cmbThdFreq_D_Graph_Top);
            this.gbThdFreq_D_Range.Controls.Add(this.btnThdFreq_D_FitGraphY);
            this.gbThdFreq_D_Range.Location = new System.Drawing.Point(3, 46);
            this.gbThdFreq_D_Range.Name = "gbThdFreq_D_Range";
            this.gbThdFreq_D_Range.Size = new System.Drawing.Size(113, 143);
            this.gbThdFreq_D_Range.TabIndex = 25;
            this.gbThdFreq_D_Range.TabStop = false;
            this.gbThdFreq_D_Range.Text = "D% range";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(8, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Bottom";
            // 
            // cmbThdFreq_D_Graph_Bottom
            // 
            this.cmbThdFreq_D_Graph_Bottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_D_Graph_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_D_Graph_Bottom.FormattingEnabled = true;
            this.cmbThdFreq_D_Graph_Bottom.Items.AddRange(new object[] {
            "0.1",
            "0.01",
            "0.001",
            "0.0001",
            "0.00001",
            "0.000001"});
            this.cmbThdFreq_D_Graph_Bottom.Location = new System.Drawing.Point(6, 74);
            this.cmbThdFreq_D_Graph_Bottom.Name = "cmbThdFreq_D_Graph_Bottom";
            this.cmbThdFreq_D_Graph_Bottom.Size = new System.Drawing.Size(94, 21);
            this.cmbThdFreq_D_Graph_Bottom.TabIndex = 28;
            this.cmbThdFreq_D_Graph_Bottom.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_Graph_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(8, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Top";
            // 
            // cmbThdFreq_D_Graph_Top
            // 
            this.cmbThdFreq_D_Graph_Top.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThdFreq_D_Graph_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThdFreq_D_Graph_Top.FormattingEnabled = true;
            this.cmbThdFreq_D_Graph_Top.Items.AddRange(new object[] {
            "100",
            "10",
            "1"});
            this.cmbThdFreq_D_Graph_Top.Location = new System.Drawing.Point(6, 33);
            this.cmbThdFreq_D_Graph_Top.Name = "cmbThdFreq_D_Graph_Top";
            this.cmbThdFreq_D_Graph_Top.Size = new System.Drawing.Size(94, 21);
            this.cmbThdFreq_D_Graph_Top.TabIndex = 26;
            this.cmbThdFreq_D_Graph_Top.SelectedIndexChanged += new System.EventHandler(this.cmbThdFreq_Graph_SelectedIndexChanged);
            // 
            // btnThdFreq_D_FitGraphY
            // 
            this.btnThdFreq_D_FitGraphY.Location = new System.Drawing.Point(6, 109);
            this.btnThdFreq_D_FitGraphY.Name = "btnThdFreq_D_FitGraphY";
            this.btnThdFreq_D_FitGraphY.Size = new System.Drawing.Size(94, 23);
            this.btnThdFreq_D_FitGraphY.TabIndex = 25;
            this.btnThdFreq_D_FitGraphY.Text = "Autofit";
            this.btnThdFreq_D_FitGraphY.UseVisualStyleBackColor = true;
            this.btnThdFreq_D_FitGraphY.Click += new System.EventHandler(this.btnThdFreq_FitDGraphY_Click);
            // 
            // lblThdFreq_NoiseFloor
            // 
            this.lblThdFreq_NoiseFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_NoiseFloor.Location = new System.Drawing.Point(654, 29);
            this.lblThdFreq_NoiseFloor.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_NoiseFloor.Name = "lblThdFreq_NoiseFloor";
            this.lblThdFreq_NoiseFloor.Size = new System.Drawing.Size(178, 19);
            this.lblThdFreq_NoiseFloor.TabIndex = 20;
            this.lblThdFreq_NoiseFloor.Text = "Noise floor: 00.00 dB";
            // 
            // lblThdFreq_Power
            // 
            this.lblThdFreq_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_Power.Location = new System.Drawing.Point(583, 3);
            this.lblThdFreq_Power.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_Power.Name = "lblThdFreq_Power";
            this.lblThdFreq_Power.Size = new System.Drawing.Size(203, 15);
            this.lblThdFreq_Power.TabIndex = 19;
            this.lblThdFreq_Power.Text = "Power: 0 mW";
            // 
            // lblThdFreq_DC
            // 
            this.lblThdFreq_DC.AutoSize = true;
            this.lblThdFreq_DC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_DC.Location = new System.Drawing.Point(471, 3);
            this.lblThdFreq_DC.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_DC.Name = "lblThdFreq_DC";
            this.lblThdFreq_DC.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_DC.TabIndex = 18;
            this.lblThdFreq_DC.Text = "DC: 0 V";
            // 
            // lblThdFreq_D6
            // 
            this.lblThdFreq_D6.AutoSize = true;
            this.lblThdFreq_D6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_D6.Location = new System.Drawing.Point(525, 29);
            this.lblThdFreq_D6.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_D6.Name = "lblThdFreq_D6";
            this.lblThdFreq_D6.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_D6.TabIndex = 17;
            this.lblThdFreq_D6.Text = "D6+: 00.00 %";
            // 
            // lblThdFreq_D5
            // 
            this.lblThdFreq_D5.AutoSize = true;
            this.lblThdFreq_D5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_D5.Location = new System.Drawing.Point(404, 29);
            this.lblThdFreq_D5.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_D5.Name = "lblThdFreq_D5";
            this.lblThdFreq_D5.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_D5.TabIndex = 16;
            this.lblThdFreq_D5.Text = "D5: 00.00 %";
            // 
            // lblThdFreq_D4
            // 
            this.lblThdFreq_D4.AutoSize = true;
            this.lblThdFreq_D4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_D4.Location = new System.Drawing.Point(282, 29);
            this.lblThdFreq_D4.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_D4.Name = "lblThdFreq_D4";
            this.lblThdFreq_D4.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_D4.TabIndex = 15;
            this.lblThdFreq_D4.Text = "D4: 00.00 %";
            // 
            // lblThdFreq_D3
            // 
            this.lblThdFreq_D3.AutoSize = true;
            this.lblThdFreq_D3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_D3.Location = new System.Drawing.Point(161, 29);
            this.lblThdFreq_D3.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_D3.Name = "lblThdFreq_D3";
            this.lblThdFreq_D3.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_D3.TabIndex = 14;
            this.lblThdFreq_D3.Text = "D3: 00.00 %";
            // 
            // lblThdFreq_D2
            // 
            this.lblThdFreq_D2.AutoSize = true;
            this.lblThdFreq_D2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_D2.Location = new System.Drawing.Point(41, 29);
            this.lblThdFreq_D2.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_D2.Name = "lblThdFreq_D2";
            this.lblThdFreq_D2.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_D2.TabIndex = 13;
            this.lblThdFreq_D2.Text = "D2: 00.00 %";
            // 
            // lblThdFreq_THD
            // 
            this.lblThdFreq_THD.AutoSize = true;
            this.lblThdFreq_THD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_THD.Location = new System.Drawing.Point(342, 3);
            this.lblThdFreq_THD.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_THD.Name = "lblThdFreq_THD";
            this.lblThdFreq_THD.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_THD.TabIndex = 12;
            this.lblThdFreq_THD.Text = "THD: 0.00 %";
            // 
            // lblThdFreq_Magnitude
            // 
            this.lblThdFreq_Magnitude.AutoSize = true;
            this.lblThdFreq_Magnitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_Magnitude.Location = new System.Drawing.Point(226, 3);
            this.lblThdFreq_Magnitude.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_Magnitude.Name = "lblThdFreq_Magnitude";
            this.lblThdFreq_Magnitude.Size = new System.Drawing.Size(100, 15);
            this.lblThdFreq_Magnitude.TabIndex = 11;
            this.lblThdFreq_Magnitude.Text = "Magn: 0.00 dB";
            // 
            // lblThdFreq_Frequency
            // 
            this.lblThdFreq_Frequency.AutoSize = true;
            this.lblThdFreq_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_Frequency.Location = new System.Drawing.Point(41, 3);
            this.lblThdFreq_Frequency.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblThdFreq_Frequency.Name = "lblThdFreq_Frequency";
            this.lblThdFreq_Frequency.Size = new System.Drawing.Size(138, 15);
            this.lblThdFreq_Frequency.TabIndex = 10;
            this.lblThdFreq_Frequency.Text = "Frequency: 00.00 Hz";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 789);
            this.Controls.Add(this.scTopBottom);
            this.MinimumSize = new System.Drawing.Size(1000, 828);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QA40x Audio Analyser";
            this.scTopBottom.Panel1.ResumeLayout(false);
            this.scTopBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scTopBottom)).EndInit();
            this.scTopBottom.ResumeLayout(false);
            this.scThdVsFreq.Panel1.ResumeLayout(false);
            this.scThdVsFreq.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scThdVsFreq)).EndInit();
            this.scThdVsFreq.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udThdFreq_Averages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udThdFreq_StepsOctave)).EndInit();
            this.scGraphCursors.Panel1.ResumeLayout(false);
            this.scGraphCursors.Panel2.ResumeLayout(false);
            this.scGraphCursors.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphCursors)).EndInit();
            this.scGraphCursors.ResumeLayout(false);
            this.scGraphSettings.Panel1.ResumeLayout(false);
            this.scGraphSettings.Panel2.ResumeLayout(false);
            this.scGraphSettings.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphSettings)).EndInit();
            this.scGraphSettings.ResumeLayout(false);
            this.gbThdFreq_dBV_Range.ResumeLayout(false);
            this.gbThdFreq_dBV_Range.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThdFreq_dBV_Graph_Bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbThdFreq_dBV_Graph_Top)).EndInit();
            this.gbThdFreq_Harmonics.ResumeLayout(false);
            this.gbThdFreq_Harmonics.PerformLayout();
            this.gbThdFreq_FrequencyRange.ResumeLayout(false);
            this.gbThdFreq_FrequencyRange.PerformLayout();
            this.gbThdFreq_D_Range.ResumeLayout(false);
            this.gbThdFreq_D_Range.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scTopBottom;
        private System.Windows.Forms.SplitContainer scThdVsFreq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblThdFreq_EndFrequency;
        private System.Windows.Forms.Label lblThdFreq_StartFrequency;
        private System.Windows.Forms.Label lblThdFreq_StepsPerOctave;
        private System.Windows.Forms.NumericUpDown udThdFreq_StepsOctave;
        private System.Windows.Forms.SplitContainer scGraphCursors;
        private System.Windows.Forms.SplitContainer scGraphSettings;
        private ScottPlot.WinForms.FormsPlot thdPlot;
        private ScottPlot.WinForms.FormsPlot graphTime;
        private System.Windows.Forms.ComboBox cmbThdFreq_GenVoltageUnit;
        private System.Windows.Forms.Label lblThdFreq_GenVoltage;
        private System.Windows.Forms.TextBox txtThdFreq_GenVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbThdFreq_GenType;
        private System.Windows.Forms.Label lblThdFreq_OutputLoad;
        private System.Windows.Forms.TextBox txtThdFreq_OutputLoad;
        private System.Windows.Forms.Button btnStartThdMeasurement;
        private System.Windows.Forms.Label lblThdFreq_PowerUnit;
        private System.Windows.Forms.Label lblThdFreq_OutputPower;
        private System.Windows.Forms.TextBox txtThdFreq_OutputPower;
        private System.Windows.Forms.Label lblThdFreq_OutputLoadUnit;
        private ScottPlot.WinForms.FormsPlot graphFft;
        private System.Windows.Forms.Button btnMeasurement_ThdFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThdFreq_EndFreq;
        private System.Windows.Forms.TextBox txtThdFreq_StartFreq;
        private System.Windows.Forms.NumericUpDown udThdFreq_Averages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbThdFreq_OutputVoltageUnit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtThdFreq_OutputVoltage;
        private System.Windows.Forms.Label lblThdFreq_Frequency;
        private System.Windows.Forms.Label lblThdFreq_THD;
        private System.Windows.Forms.Label lblThdFreq_Magnitude;
        private System.Windows.Forms.Label lblThdFreq_D6;
        private System.Windows.Forms.Label lblThdFreq_D5;
        private System.Windows.Forms.Label lblThdFreq_D4;
        private System.Windows.Forms.Label lblThdFreq_D3;
        private System.Windows.Forms.Label lblThdFreq_D2;
        private System.Windows.Forms.Button btnStopThdMeasurement;
        private System.Windows.Forms.GroupBox gbThdFreq_FrequencyRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbThdFreq_Graph_To;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbThdFreq_Graph_From;
        private System.Windows.Forms.Button btnThdFreq_FitGraphX;
        private System.Windows.Forms.GroupBox gbThdFreq_D_Range;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbThdFreq_D_Graph_Bottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbThdFreq_D_Graph_Top;
        private System.Windows.Forms.Button btnThdFreq_D_FitGraphY;
        private System.Windows.Forms.Button btnFreqThd_Graph_dBV;
        private System.Windows.Forms.Button btnFreqThd_Graph_D;
        private System.Windows.Forms.GroupBox gbThdFreq_Harmonics;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowD6;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowD5;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowD4;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowD3;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowD2;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowThd;
        private System.Windows.Forms.GroupBox gbThdFreq_dBV_Range;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnThdFreq_dBV_FitGraphY;
        private System.Windows.Forms.NumericUpDown cmbThdFreq_dBV_Graph_Bottom;
        private System.Windows.Forms.NumericUpDown cmbThdFreq_dBV_Graph_Top;
        private System.Windows.Forms.Label lblThdFreq_DC;
        private System.Windows.Forms.Label lblThdFreq_Power;
        private System.Windows.Forms.Label lblThdFreq_Message;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowNoiseFloor;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowMagnitude;
        private System.Windows.Forms.Label lblThdFreq_NoiseFloor;
        private System.Windows.Forms.CheckBox chkThdFreq_ThickLines;
        private System.Windows.Forms.CheckBox chkThdFreq_ShowMarkers;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}