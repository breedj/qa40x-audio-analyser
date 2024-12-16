namespace QA40x_AUDIO_ANALYSER
{
    partial class frmThdAmplitude
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
            this.scThdVsFreq = new System.Windows.Forms.SplitContainer();
            this.btnStopThdMeasurement = new System.Windows.Forms.Button();
            this.graphFft = new ScottPlot.WinForms.FormsPlot();
            this.btnStartThdMeasurement = new System.Windows.Forms.Button();
            this.graphTime = new ScottPlot.WinForms.FormsPlot();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbEndVoltageUnit = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEndVoltage = new System.Windows.Forms.TextBox();
            this.udAverages = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.lblThdFreq_OutputLoadUnit = new System.Windows.Forms.Label();
            this.lblThdFreq_OutputLoad = new System.Windows.Forms.Label();
            this.txtOutputLoad = new System.Windows.Forms.TextBox();
            this.cmbStartVoltageUnit = new System.Windows.Forms.ComboBox();
            this.lblThdFreq_GenVoltage = new System.Windows.Forms.Label();
            this.txtStartVoltage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.udStepsOctave = new System.Windows.Forms.NumericUpDown();
            this.lblThdFreq_StepsPerOctave = new System.Windows.Forms.Label();
            this.lblFrequency = new System.Windows.Forms.Label();
            this.scGraphCursors = new System.Windows.Forms.SplitContainer();
            this.scGraphSettings = new System.Windows.Forms.SplitContainer();
            this.thdPlot = new ScottPlot.WinForms.FormsPlot();
            this.chkShowDataPoints = new System.Windows.Forms.CheckBox();
            this.chkThickLines = new System.Windows.Forms.CheckBox();
            this.gbDbv_Range = new System.Windows.Forms.GroupBox();
            this.cmbDbV_Graph_Bottom = new System.Windows.Forms.NumericUpDown();
            this.cmbDbV_Graph_Top = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnDbv_FitGraphY = new System.Windows.Forms.Button();
            this.gbThdFreq_Harmonics = new System.Windows.Forms.GroupBox();
            this.chkShowMagnitude = new System.Windows.Forms.CheckBox();
            this.chkShowNoiseFloor = new System.Windows.Forms.CheckBox();
            this.chkShowD6 = new System.Windows.Forms.CheckBox();
            this.chkShowD5 = new System.Windows.Forms.CheckBox();
            this.chkShowD4 = new System.Windows.Forms.CheckBox();
            this.chkShowD3 = new System.Windows.Forms.CheckBox();
            this.chkShowD2 = new System.Windows.Forms.CheckBox();
            this.chkShowThd = new System.Windows.Forms.CheckBox();
            this.btnGraph_dBV = new System.Windows.Forms.Button();
            this.btnGraph_D = new System.Windows.Forms.Button();
            this.gbThdFreq_FrequencyRange = new System.Windows.Forms.GroupBox();
            this.btnAutoFitX = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbVoltageGraph_To = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbVoltageGraph_From = new System.Windows.Forms.ComboBox();
            this.gbD_Range = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbD_Graph_Bottom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbD_Graph_Top = new System.Windows.Forms.ComboBox();
            this.btnD_FitGraphY = new System.Windows.Forms.Button();
            this.lblCursor_NoiseFloor = new System.Windows.Forms.Label();
            this.lblCursor_Power = new System.Windows.Forms.Label();
            this.lblCursor_DC = new System.Windows.Forms.Label();
            this.lblCursor_D6 = new System.Windows.Forms.Label();
            this.lblCursor_D5 = new System.Windows.Forms.Label();
            this.lblCursor_D4 = new System.Windows.Forms.Label();
            this.lblCursor_D3 = new System.Windows.Forms.Label();
            this.lblCursor_D2 = new System.Windows.Forms.Label();
            this.lblCursor_THD = new System.Windows.Forms.Label();
            this.lblCursor_Magnitude = new System.Windows.Forms.Label();
            this.lblCursor_Voltage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scThdVsFreq)).BeginInit();
            this.scThdVsFreq.Panel1.SuspendLayout();
            this.scThdVsFreq.Panel2.SuspendLayout();
            this.scThdVsFreq.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAverages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStepsOctave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphCursors)).BeginInit();
            this.scGraphCursors.Panel1.SuspendLayout();
            this.scGraphCursors.Panel2.SuspendLayout();
            this.scGraphCursors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphSettings)).BeginInit();
            this.scGraphSettings.Panel1.SuspendLayout();
            this.scGraphSettings.Panel2.SuspendLayout();
            this.scGraphSettings.SuspendLayout();
            this.gbDbv_Range.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDbV_Graph_Bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDbV_Graph_Top)).BeginInit();
            this.gbThdFreq_Harmonics.SuspendLayout();
            this.gbThdFreq_FrequencyRange.SuspendLayout();
            this.gbD_Range.SuspendLayout();
            this.SuspendLayout();
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
            this.scThdVsFreq.Size = new System.Drawing.Size(1100, 765);
            this.scThdVsFreq.SplitterDistance = 260;
            this.scThdVsFreq.TabIndex = 1;
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
            this.btnStopThdMeasurement.Click += new System.EventHandler(this.btnStopThdMeasurement_Click);
            // 
            // graphFft
            // 
            this.graphFft.DisplayScale = 0F;
            this.graphFft.Location = new System.Drawing.Point(3, 288);
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
            this.graphTime.Location = new System.Drawing.Point(3, 482);
            this.graphTime.Name = "graphTime";
            this.graphTime.Size = new System.Drawing.Size(254, 183);
            this.graphTime.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmbEndVoltageUnit);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.txtEndVoltage);
            this.groupBox1.Controls.Add(this.udAverages);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFrequency);
            this.groupBox1.Controls.Add(this.lblThdFreq_OutputLoadUnit);
            this.groupBox1.Controls.Add(this.lblThdFreq_OutputLoad);
            this.groupBox1.Controls.Add(this.txtOutputLoad);
            this.groupBox1.Controls.Add(this.cmbStartVoltageUnit);
            this.groupBox1.Controls.Add(this.lblThdFreq_GenVoltage);
            this.groupBox1.Controls.Add(this.txtStartVoltage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.udStepsOctave);
            this.groupBox1.Controls.Add(this.lblThdFreq_StepsPerOctave);
            this.groupBox1.Controls.Add(this.lblFrequency);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 236);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Settings";
            // 
            // cmbEndVoltageUnit
            // 
            this.cmbEndVoltageUnit.DisplayMember = "1";
            this.cmbEndVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEndVoltageUnit.FormattingEnabled = true;
            this.cmbEndVoltageUnit.Items.AddRange(new object[] {
            "mV",
            "V"});
            this.cmbEndVoltageUnit.Location = new System.Drawing.Point(193, 71);
            this.cmbEndVoltageUnit.Name = "cmbEndVoltageUnit";
            this.cmbEndVoltageUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbEndVoltageUnit.TabIndex = 30;
            this.cmbEndVoltageUnit.SelectedIndexChanged += new System.EventHandler(this.cmbEndVoltageUnit_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(20, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "End Voltage";
            // 
            // txtEndVoltage
            // 
            this.txtEndVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndVoltage.Location = new System.Drawing.Point(127, 71);
            this.txtEndVoltage.Name = "txtEndVoltage";
            this.txtEndVoltage.Size = new System.Drawing.Size(59, 20);
            this.txtEndVoltage.TabIndex = 28;
            this.txtEndVoltage.TextChanged += new System.EventHandler(this.txtEndVoltage_TextChanged);
            this.txtEndVoltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndVoltage_KeyPress);
            // 
            // udAverages
            // 
            this.udAverages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udAverages.Location = new System.Drawing.Point(127, 202);
            this.udAverages.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.udAverages.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAverages.Name = "udAverages";
            this.udAverages.Size = new System.Drawing.Size(58, 20);
            this.udAverages.TabIndex = 24;
            this.udAverages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAverages.ValueChanged += new System.EventHandler(this.udAverages_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(17, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Averages";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(192, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hz";
            // 
            // txtFrequency
            // 
            this.txtFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFrequency.Location = new System.Drawing.Point(127, 149);
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(59, 20);
            this.txtFrequency.TabIndex = 19;
            this.txtFrequency.Text = "1000";
            this.txtFrequency.TextChanged += new System.EventHandler(this.txtFrequency_TextChanged);
            this.txtFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartFreq_KeyPress);
            // 
            // lblThdFreq_OutputLoadUnit
            // 
            this.lblThdFreq_OutputLoadUnit.AutoSize = true;
            this.lblThdFreq_OutputLoadUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_OutputLoadUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_OutputLoadUnit.Location = new System.Drawing.Point(193, 126);
            this.lblThdFreq_OutputLoadUnit.Name = "lblThdFreq_OutputLoadUnit";
            this.lblThdFreq_OutputLoadUnit.Size = new System.Drawing.Size(16, 13);
            this.lblThdFreq_OutputLoadUnit.TabIndex = 15;
            this.lblThdFreq_OutputLoadUnit.Text = "Ω";
            // 
            // lblThdFreq_OutputLoad
            // 
            this.lblThdFreq_OutputLoad.AutoSize = true;
            this.lblThdFreq_OutputLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_OutputLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_OutputLoad.Location = new System.Drawing.Point(17, 126);
            this.lblThdFreq_OutputLoad.Name = "lblThdFreq_OutputLoad";
            this.lblThdFreq_OutputLoad.Size = new System.Drawing.Size(73, 13);
            this.lblThdFreq_OutputLoad.TabIndex = 14;
            this.lblThdFreq_OutputLoad.Text = "Amplifier Load";
            // 
            // txtOutputLoad
            // 
            this.txtOutputLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputLoad.Location = new System.Drawing.Point(127, 123);
            this.txtOutputLoad.Name = "txtOutputLoad";
            this.txtOutputLoad.Size = new System.Drawing.Size(60, 20);
            this.txtOutputLoad.TabIndex = 13;
            this.txtOutputLoad.Text = "8";
            this.txtOutputLoad.TextChanged += new System.EventHandler(this.txtOutputLoad_TextChanged);
            this.txtOutputLoad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputLoad_KeyPress);
            // 
            // cmbStartVoltageUnit
            // 
            this.cmbStartVoltageUnit.DisplayMember = "1";
            this.cmbStartVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStartVoltageUnit.FormattingEnabled = true;
            this.cmbStartVoltageUnit.Items.AddRange(new object[] {
            "mV",
            "V"});
            this.cmbStartVoltageUnit.Location = new System.Drawing.Point(193, 44);
            this.cmbStartVoltageUnit.Name = "cmbStartVoltageUnit";
            this.cmbStartVoltageUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbStartVoltageUnit.TabIndex = 12;
            this.cmbStartVoltageUnit.SelectedIndexChanged += new System.EventHandler(this.cmbStartVoltageUnit_SelectedIndexChanged);
            // 
            // lblThdFreq_GenVoltage
            // 
            this.lblThdFreq_GenVoltage.AutoSize = true;
            this.lblThdFreq_GenVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_GenVoltage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_GenVoltage.Location = new System.Drawing.Point(20, 48);
            this.lblThdFreq_GenVoltage.Name = "lblThdFreq_GenVoltage";
            this.lblThdFreq_GenVoltage.Size = new System.Drawing.Size(68, 13);
            this.lblThdFreq_GenVoltage.TabIndex = 11;
            this.lblThdFreq_GenVoltage.Text = "Start Voltage";
            this.lblThdFreq_GenVoltage.Click += new System.EventHandler(this.lblThdFreq_GenVoltage_Click);
            // 
            // txtStartVoltage
            // 
            this.txtStartVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartVoltage.Location = new System.Drawing.Point(127, 45);
            this.txtStartVoltage.Name = "txtStartVoltage";
            this.txtStartVoltage.Size = new System.Drawing.Size(60, 20);
            this.txtStartVoltage.TabIndex = 10;
            this.txtStartVoltage.TextChanged += new System.EventHandler(this.txtStartVoltage_TextChanged);
            this.txtStartVoltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartVoltage_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(95, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Input voltage";
            // 
            // udStepsOctave
            // 
            this.udStepsOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udStepsOctave.Location = new System.Drawing.Point(127, 175);
            this.udStepsOctave.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.udStepsOctave.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStepsOctave.Name = "udStepsOctave";
            this.udStepsOctave.Size = new System.Drawing.Size(59, 20);
            this.udStepsOctave.TabIndex = 7;
            this.udStepsOctave.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udStepsOctave.ValueChanged += new System.EventHandler(this.udStepsOctave_ValueChanged);
            // 
            // lblThdFreq_StepsPerOctave
            // 
            this.lblThdFreq_StepsPerOctave.AutoSize = true;
            this.lblThdFreq_StepsPerOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_StepsPerOctave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_StepsPerOctave.Location = new System.Drawing.Point(17, 177);
            this.lblThdFreq_StepsPerOctave.Name = "lblThdFreq_StepsPerOctave";
            this.lblThdFreq_StepsPerOctave.Size = new System.Drawing.Size(80, 13);
            this.lblThdFreq_StepsPerOctave.TabIndex = 4;
            this.lblThdFreq_StepsPerOctave.Text = "Steps / Octave";
            // 
            // lblFrequency
            // 
            this.lblFrequency.AutoSize = true;
            this.lblFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrequency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrequency.Location = new System.Drawing.Point(17, 152);
            this.lblFrequency.Name = "lblFrequency";
            this.lblFrequency.Size = new System.Drawing.Size(81, 13);
            this.lblFrequency.TabIndex = 0;
            this.lblFrequency.Text = "Test Frequency";
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
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_NoiseFloor);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_Power);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_DC);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_D6);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_D5);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_D4);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_D3);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_D2);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_THD);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_Magnitude);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_Voltage);
            this.scGraphCursors.Size = new System.Drawing.Size(836, 765);
            this.scGraphCursors.SplitterDistance = 710;
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
            this.scGraphSettings.Panel2.Controls.Add(this.chkShowDataPoints);
            this.scGraphSettings.Panel2.Controls.Add(this.chkThickLines);
            this.scGraphSettings.Panel2.Controls.Add(this.gbDbv_Range);
            this.scGraphSettings.Panel2.Controls.Add(this.gbThdFreq_Harmonics);
            this.scGraphSettings.Panel2.Controls.Add(this.btnGraph_dBV);
            this.scGraphSettings.Panel2.Controls.Add(this.btnGraph_D);
            this.scGraphSettings.Panel2.Controls.Add(this.gbThdFreq_FrequencyRange);
            this.scGraphSettings.Panel2.Controls.Add(this.gbD_Range);
            this.scGraphSettings.Size = new System.Drawing.Size(836, 710);
            this.scGraphSettings.SplitterDistance = 709;
            this.scGraphSettings.TabIndex = 0;
            // 
            // thdPlot
            // 
            this.thdPlot.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.thdPlot.DisplayScale = 0F;
            this.thdPlot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thdPlot.Location = new System.Drawing.Point(0, 0);
            this.thdPlot.Name = "thdPlot";
            this.thdPlot.Size = new System.Drawing.Size(709, 710);
            this.thdPlot.TabIndex = 2;
            // 
            // chkShowDataPoints
            // 
            this.chkShowDataPoints.AutoSize = true;
            this.chkShowDataPoints.Location = new System.Drawing.Point(12, 596);
            this.chkShowDataPoints.Name = "chkShowDataPoints";
            this.chkShowDataPoints.Size = new System.Drawing.Size(108, 17);
            this.chkShowDataPoints.TabIndex = 45;
            this.chkShowDataPoints.Text = "Show data points";
            this.chkShowDataPoints.UseVisualStyleBackColor = true;
            this.chkShowDataPoints.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkThickLines
            // 
            this.chkThickLines.AutoSize = true;
            this.chkThickLines.Checked = true;
            this.chkThickLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkThickLines.Location = new System.Drawing.Point(12, 576);
            this.chkThickLines.Name = "chkThickLines";
            this.chkThickLines.Size = new System.Drawing.Size(77, 17);
            this.chkThickLines.TabIndex = 44;
            this.chkThickLines.Text = "Thick lines";
            this.chkThickLines.UseVisualStyleBackColor = true;
            this.chkThickLines.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // gbDbv_Range
            // 
            this.gbDbv_Range.Controls.Add(this.cmbDbV_Graph_Bottom);
            this.gbDbv_Range.Controls.Add(this.cmbDbV_Graph_Top);
            this.gbDbv_Range.Controls.Add(this.label10);
            this.gbDbv_Range.Controls.Add(this.label11);
            this.gbDbv_Range.Controls.Add(this.btnDbv_FitGraphY);
            this.gbDbv_Range.Location = new System.Drawing.Point(43, 20);
            this.gbDbv_Range.Name = "gbDbv_Range";
            this.gbDbv_Range.Size = new System.Drawing.Size(113, 143);
            this.gbDbv_Range.TabIndex = 30;
            this.gbDbv_Range.TabStop = false;
            this.gbDbv_Range.Text = "dB range";
            // 
            // cmbDbV_Graph_Bottom
            // 
            this.cmbDbV_Graph_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDbV_Graph_Bottom.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbDbV_Graph_Bottom.Location = new System.Drawing.Point(8, 77);
            this.cmbDbV_Graph_Bottom.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cmbDbV_Graph_Bottom.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.cmbDbV_Graph_Bottom.Name = "cmbDbV_Graph_Bottom";
            this.cmbDbV_Graph_Bottom.Size = new System.Drawing.Size(94, 20);
            this.cmbDbV_Graph_Bottom.TabIndex = 31;
            this.cmbDbV_Graph_Bottom.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cmbDbV_Graph_Bottom.ValueChanged += new System.EventHandler(this.cmbDbv_Graph_Top_ValueChanged);
            // 
            // cmbDbV_Graph_Top
            // 
            this.cmbDbV_Graph_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDbV_Graph_Top.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbDbV_Graph_Top.Location = new System.Drawing.Point(8, 36);
            this.cmbDbV_Graph_Top.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cmbDbV_Graph_Top.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.cmbDbV_Graph_Top.Name = "cmbDbV_Graph_Top";
            this.cmbDbV_Graph_Top.Size = new System.Drawing.Size(94, 20);
            this.cmbDbV_Graph_Top.TabIndex = 30;
            this.cmbDbV_Graph_Top.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cmbDbV_Graph_Top.ValueChanged += new System.EventHandler(this.cmbDbv_Graph_Top_ValueChanged);
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
            // btnDbv_FitGraphY
            // 
            this.btnDbv_FitGraphY.Location = new System.Drawing.Point(6, 109);
            this.btnDbv_FitGraphY.Name = "btnDbv_FitGraphY";
            this.btnDbv_FitGraphY.Size = new System.Drawing.Size(94, 23);
            this.btnDbv_FitGraphY.TabIndex = 25;
            this.btnDbv_FitGraphY.Text = "Autofit";
            this.btnDbv_FitGraphY.UseVisualStyleBackColor = true;
            this.btnDbv_FitGraphY.Click += new System.EventHandler(this.btnFitDbGraphY_Click);
            // 
            // gbThdFreq_Harmonics
            // 
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowMagnitude);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowNoiseFloor);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowD6);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowD5);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowD4);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowD3);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowD2);
            this.gbThdFreq_Harmonics.Controls.Add(this.chkShowThd);
            this.gbThdFreq_Harmonics.Location = new System.Drawing.Point(4, 363);
            this.gbThdFreq_Harmonics.Name = "gbThdFreq_Harmonics";
            this.gbThdFreq_Harmonics.Size = new System.Drawing.Size(111, 207);
            this.gbThdFreq_Harmonics.TabIndex = 29;
            this.gbThdFreq_Harmonics.TabStop = false;
            this.gbThdFreq_Harmonics.Text = "Graph data";
            // 
            // chkShowMagnitude
            // 
            this.chkShowMagnitude.AutoSize = true;
            this.chkShowMagnitude.Checked = true;
            this.chkShowMagnitude.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowMagnitude.Location = new System.Drawing.Point(8, 19);
            this.chkShowMagnitude.Name = "chkShowMagnitude";
            this.chkShowMagnitude.Size = new System.Drawing.Size(76, 17);
            this.chkShowMagnitude.TabIndex = 43;
            this.chkShowMagnitude.Text = "Magnitude";
            this.chkShowMagnitude.UseVisualStyleBackColor = true;
            this.chkShowMagnitude.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowNoiseFloor
            // 
            this.chkShowNoiseFloor.AutoSize = true;
            this.chkShowNoiseFloor.Checked = true;
            this.chkShowNoiseFloor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowNoiseFloor.Location = new System.Drawing.Point(8, 180);
            this.chkShowNoiseFloor.Name = "chkShowNoiseFloor";
            this.chkShowNoiseFloor.Size = new System.Drawing.Size(76, 17);
            this.chkShowNoiseFloor.TabIndex = 42;
            this.chkShowNoiseFloor.Text = "Noise floor";
            this.chkShowNoiseFloor.UseVisualStyleBackColor = true;
            this.chkShowNoiseFloor.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowD6
            // 
            this.chkShowD6.AutoSize = true;
            this.chkShowD6.Checked = true;
            this.chkShowD6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowD6.Location = new System.Drawing.Point(8, 157);
            this.chkShowD6.Name = "chkShowD6";
            this.chkShowD6.Size = new System.Drawing.Size(46, 17);
            this.chkShowD6.TabIndex = 41;
            this.chkShowD6.Text = "D6+";
            this.chkShowD6.UseVisualStyleBackColor = true;
            this.chkShowD6.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowD5
            // 
            this.chkShowD5.AutoSize = true;
            this.chkShowD5.Checked = true;
            this.chkShowD5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowD5.Location = new System.Drawing.Point(8, 134);
            this.chkShowD5.Name = "chkShowD5";
            this.chkShowD5.Size = new System.Drawing.Size(40, 17);
            this.chkShowD5.TabIndex = 40;
            this.chkShowD5.Text = "D5";
            this.chkShowD5.UseVisualStyleBackColor = true;
            this.chkShowD5.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowD4
            // 
            this.chkShowD4.AutoSize = true;
            this.chkShowD4.Checked = true;
            this.chkShowD4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowD4.Location = new System.Drawing.Point(8, 111);
            this.chkShowD4.Name = "chkShowD4";
            this.chkShowD4.Size = new System.Drawing.Size(40, 17);
            this.chkShowD4.TabIndex = 39;
            this.chkShowD4.Text = "D4";
            this.chkShowD4.UseVisualStyleBackColor = true;
            this.chkShowD4.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowD3
            // 
            this.chkShowD3.AutoSize = true;
            this.chkShowD3.Checked = true;
            this.chkShowD3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowD3.Location = new System.Drawing.Point(8, 88);
            this.chkShowD3.Name = "chkShowD3";
            this.chkShowD3.Size = new System.Drawing.Size(40, 17);
            this.chkShowD3.TabIndex = 38;
            this.chkShowD3.Text = "D3";
            this.chkShowD3.UseVisualStyleBackColor = true;
            this.chkShowD3.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowD2
            // 
            this.chkShowD2.AutoSize = true;
            this.chkShowD2.Checked = true;
            this.chkShowD2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowD2.Location = new System.Drawing.Point(8, 65);
            this.chkShowD2.Name = "chkShowD2";
            this.chkShowD2.Size = new System.Drawing.Size(40, 17);
            this.chkShowD2.TabIndex = 37;
            this.chkShowD2.Text = "D2";
            this.chkShowD2.UseVisualStyleBackColor = true;
            this.chkShowD2.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // chkShowThd
            // 
            this.chkShowThd.AutoSize = true;
            this.chkShowThd.Checked = true;
            this.chkShowThd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowThd.Location = new System.Drawing.Point(8, 42);
            this.chkShowThd.Name = "chkShowThd";
            this.chkShowThd.Size = new System.Drawing.Size(49, 17);
            this.chkShowThd.TabIndex = 36;
            this.chkShowThd.Text = "THD";
            this.chkShowThd.UseVisualStyleBackColor = true;
            this.chkShowThd.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
            // 
            // btnGraph_dBV
            // 
            this.btnGraph_dBV.BackColor = System.Drawing.Color.Cornsilk;
            this.btnGraph_dBV.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnGraph_dBV.FlatAppearance.BorderSize = 2;
            this.btnGraph_dBV.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph_dBV.Location = new System.Drawing.Point(9, 626);
            this.btnGraph_dBV.Name = "btnGraph_dBV";
            this.btnGraph_dBV.Size = new System.Drawing.Size(52, 37);
            this.btnGraph_dBV.TabIndex = 28;
            this.btnGraph_dBV.Text = "D (dB)";
            this.btnGraph_dBV.UseVisualStyleBackColor = false;
            this.btnGraph_dBV.Click += new System.EventHandler(this.btnGraph_dBV_Click);
            // 
            // btnGraph_D
            // 
            this.btnGraph_D.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGraph_D.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnGraph_D.FlatAppearance.BorderSize = 2;
            this.btnGraph_D.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph_D.Location = new System.Drawing.Point(67, 626);
            this.btnGraph_D.Name = "btnGraph_D";
            this.btnGraph_D.Size = new System.Drawing.Size(49, 37);
            this.btnGraph_D.TabIndex = 27;
            this.btnGraph_D.Text = "D (%)";
            this.btnGraph_D.UseVisualStyleBackColor = false;
            this.btnGraph_D.Click += new System.EventHandler(this.btnGraph_D_Click);
            // 
            // gbThdFreq_FrequencyRange
            // 
            this.gbThdFreq_FrequencyRange.Controls.Add(this.btnAutoFitX);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.label8);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.cmbVoltageGraph_To);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.label9);
            this.gbThdFreq_FrequencyRange.Controls.Add(this.cmbVoltageGraph_From);
            this.gbThdFreq_FrequencyRange.Location = new System.Drawing.Point(3, 195);
            this.gbThdFreq_FrequencyRange.Name = "gbThdFreq_FrequencyRange";
            this.gbThdFreq_FrequencyRange.Size = new System.Drawing.Size(112, 162);
            this.gbThdFreq_FrequencyRange.TabIndex = 26;
            this.gbThdFreq_FrequencyRange.TabStop = false;
            this.gbThdFreq_FrequencyRange.Text = "Voltage range";
            // 
            // btnAutoFitX
            // 
            this.btnAutoFitX.Location = new System.Drawing.Point(6, 117);
            this.btnAutoFitX.Name = "btnAutoFitX";
            this.btnAutoFitX.Size = new System.Drawing.Size(94, 23);
            this.btnAutoFitX.TabIndex = 35;
            this.btnAutoFitX.Text = "Autofit";
            this.btnAutoFitX.UseVisualStyleBackColor = true;
            this.btnAutoFitX.Click += new System.EventHandler(this.btnAutoFitX_Click);
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
            // cmbVoltageGraph_To
            // 
            this.cmbVoltageGraph_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoltageGraph_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoltageGraph_To.FormattingEnabled = true;
            this.cmbVoltageGraph_To.Items.AddRange(new object[] {
            "1",
            "2",
            "5",
            "10",
            "20",
            "50",
            "100"});
            this.cmbVoltageGraph_To.Location = new System.Drawing.Point(6, 82);
            this.cmbVoltageGraph_To.Name = "cmbVoltageGraph_To";
            this.cmbVoltageGraph_To.Size = new System.Drawing.Size(94, 21);
            this.cmbVoltageGraph_To.TabIndex = 33;
            this.cmbVoltageGraph_To.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_SelectedIndexChanged);
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
            // cmbVoltageGraph_From
            // 
            this.cmbVoltageGraph_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVoltageGraph_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVoltageGraph_From.FormattingEnabled = true;
            this.cmbVoltageGraph_From.Items.AddRange(new object[] {
            "0.0001",
            "0.0002",
            "0.0005",
            "0.001",
            "0.002",
            "0.005",
            "0.01",
            "0.02",
            "0.05",
            "0.1",
            "0.2",
            "0.5"});
            this.cmbVoltageGraph_From.Location = new System.Drawing.Point(6, 38);
            this.cmbVoltageGraph_From.Name = "cmbVoltageGraph_From";
            this.cmbVoltageGraph_From.Size = new System.Drawing.Size(94, 21);
            this.cmbVoltageGraph_From.TabIndex = 31;
            this.cmbVoltageGraph_From.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_SelectedIndexChanged);
            // 
            // gbD_Range
            // 
            this.gbD_Range.Controls.Add(this.label7);
            this.gbD_Range.Controls.Add(this.cmbD_Graph_Bottom);
            this.gbD_Range.Controls.Add(this.label6);
            this.gbD_Range.Controls.Add(this.cmbD_Graph_Top);
            this.gbD_Range.Controls.Add(this.btnD_FitGraphY);
            this.gbD_Range.Location = new System.Drawing.Point(3, 46);
            this.gbD_Range.Name = "gbD_Range";
            this.gbD_Range.Size = new System.Drawing.Size(113, 143);
            this.gbD_Range.TabIndex = 25;
            this.gbD_Range.TabStop = false;
            this.gbD_Range.Text = "D% range";
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
            // cmbD_Graph_Bottom
            // 
            this.cmbD_Graph_Bottom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbD_Graph_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbD_Graph_Bottom.FormattingEnabled = true;
            this.cmbD_Graph_Bottom.Items.AddRange(new object[] {
            "0.1",
            "0.01",
            "0.001",
            "0.0001",
            "0.00001",
            "0.000001"});
            this.cmbD_Graph_Bottom.Location = new System.Drawing.Point(6, 74);
            this.cmbD_Graph_Bottom.Name = "cmbD_Graph_Bottom";
            this.cmbD_Graph_Bottom.Size = new System.Drawing.Size(94, 21);
            this.cmbD_Graph_Bottom.TabIndex = 28;
            this.cmbD_Graph_Bottom.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_SelectedIndexChanged);
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
            // cmbD_Graph_Top
            // 
            this.cmbD_Graph_Top.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbD_Graph_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbD_Graph_Top.FormattingEnabled = true;
            this.cmbD_Graph_Top.Items.AddRange(new object[] {
            "100",
            "10",
            "1"});
            this.cmbD_Graph_Top.Location = new System.Drawing.Point(6, 33);
            this.cmbD_Graph_Top.Name = "cmbD_Graph_Top";
            this.cmbD_Graph_Top.Size = new System.Drawing.Size(94, 21);
            this.cmbD_Graph_Top.TabIndex = 26;
            this.cmbD_Graph_Top.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_SelectedIndexChanged);
            // 
            // btnD_FitGraphY
            // 
            this.btnD_FitGraphY.Location = new System.Drawing.Point(6, 109);
            this.btnD_FitGraphY.Name = "btnD_FitGraphY";
            this.btnD_FitGraphY.Size = new System.Drawing.Size(94, 23);
            this.btnD_FitGraphY.TabIndex = 25;
            this.btnD_FitGraphY.Text = "Autofit";
            this.btnD_FitGraphY.UseVisualStyleBackColor = true;
            this.btnD_FitGraphY.Click += new System.EventHandler(this.btnFitDGraphY_Click);
            // 
            // lblCursor_NoiseFloor
            // 
            this.lblCursor_NoiseFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_NoiseFloor.Location = new System.Drawing.Point(654, 29);
            this.lblCursor_NoiseFloor.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_NoiseFloor.Name = "lblCursor_NoiseFloor";
            this.lblCursor_NoiseFloor.Size = new System.Drawing.Size(178, 19);
            this.lblCursor_NoiseFloor.TabIndex = 20;
            this.lblCursor_NoiseFloor.Text = "Noise floor: 00.00 dB";
            // 
            // lblCursor_Power
            // 
            this.lblCursor_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Power.Location = new System.Drawing.Point(583, 3);
            this.lblCursor_Power.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_Power.Name = "lblCursor_Power";
            this.lblCursor_Power.Size = new System.Drawing.Size(203, 15);
            this.lblCursor_Power.TabIndex = 19;
            this.lblCursor_Power.Text = "Power: 0 mW";
            // 
            // lblCursor_DC
            // 
            this.lblCursor_DC.AutoSize = true;
            this.lblCursor_DC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_DC.Location = new System.Drawing.Point(471, 3);
            this.lblCursor_DC.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_DC.Name = "lblCursor_DC";
            this.lblCursor_DC.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_DC.TabIndex = 18;
            this.lblCursor_DC.Text = "DC: 0 V";
            // 
            // lblCursor_D6
            // 
            this.lblCursor_D6.AutoSize = true;
            this.lblCursor_D6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D6.Location = new System.Drawing.Point(525, 29);
            this.lblCursor_D6.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_D6.Name = "lblCursor_D6";
            this.lblCursor_D6.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_D6.TabIndex = 17;
            this.lblCursor_D6.Text = "D6+: 00.00 %";
            // 
            // lblCursor_D5
            // 
            this.lblCursor_D5.AutoSize = true;
            this.lblCursor_D5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D5.Location = new System.Drawing.Point(404, 29);
            this.lblCursor_D5.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_D5.Name = "lblCursor_D5";
            this.lblCursor_D5.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_D5.TabIndex = 16;
            this.lblCursor_D5.Text = "D5: 00.00 %";
            // 
            // lblCursor_D4
            // 
            this.lblCursor_D4.AutoSize = true;
            this.lblCursor_D4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D4.Location = new System.Drawing.Point(282, 29);
            this.lblCursor_D4.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_D4.Name = "lblCursor_D4";
            this.lblCursor_D4.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_D4.TabIndex = 15;
            this.lblCursor_D4.Text = "D4: 00.00 %";
            // 
            // lblCursor_D3
            // 
            this.lblCursor_D3.AutoSize = true;
            this.lblCursor_D3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D3.Location = new System.Drawing.Point(161, 29);
            this.lblCursor_D3.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_D3.Name = "lblCursor_D3";
            this.lblCursor_D3.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_D3.TabIndex = 14;
            this.lblCursor_D3.Text = "D3: 00.00 %";
            // 
            // lblCursor_D2
            // 
            this.lblCursor_D2.AutoSize = true;
            this.lblCursor_D2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D2.Location = new System.Drawing.Point(41, 29);
            this.lblCursor_D2.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_D2.Name = "lblCursor_D2";
            this.lblCursor_D2.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_D2.TabIndex = 13;
            this.lblCursor_D2.Text = "D2: 00.00 %";
            // 
            // lblCursor_THD
            // 
            this.lblCursor_THD.AutoSize = true;
            this.lblCursor_THD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_THD.Location = new System.Drawing.Point(342, 3);
            this.lblCursor_THD.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_THD.Name = "lblCursor_THD";
            this.lblCursor_THD.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_THD.TabIndex = 12;
            this.lblCursor_THD.Text = "THD: 0.00 %";
            // 
            // lblCursor_Magnitude
            // 
            this.lblCursor_Magnitude.AutoSize = true;
            this.lblCursor_Magnitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Magnitude.Location = new System.Drawing.Point(214, 3);
            this.lblCursor_Magnitude.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_Magnitude.Name = "lblCursor_Magnitude";
            this.lblCursor_Magnitude.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_Magnitude.TabIndex = 11;
            this.lblCursor_Magnitude.Text = "Magn: 0.00 dB";
            // 
            // lblCursor_Voltage
            // 
            this.lblCursor_Voltage.AutoSize = true;
            this.lblCursor_Voltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Voltage.Location = new System.Drawing.Point(41, 3);
            this.lblCursor_Voltage.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_Voltage.Name = "lblCursor_Voltage";
            this.lblCursor_Voltage.Size = new System.Drawing.Size(127, 15);
            this.lblCursor_Voltage.TabIndex = 10;
            this.lblCursor_Voltage.Text = "Amplitude: 0.000 V";
            // 
            // frmThdAmplitude
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 765);
            this.Controls.Add(this.scThdVsFreq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1100, 765);
            this.Name = "frmThdAmplitude";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QA40x Audio Analyser - V0.1";
            this.scThdVsFreq.Panel1.ResumeLayout(false);
            this.scThdVsFreq.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scThdVsFreq)).EndInit();
            this.scThdVsFreq.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udAverages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udStepsOctave)).EndInit();
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
            this.gbDbv_Range.ResumeLayout(false);
            this.gbDbv_Range.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDbV_Graph_Bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDbV_Graph_Top)).EndInit();
            this.gbThdFreq_Harmonics.ResumeLayout(false);
            this.gbThdFreq_Harmonics.PerformLayout();
            this.gbThdFreq_FrequencyRange.ResumeLayout(false);
            this.gbThdFreq_FrequencyRange.PerformLayout();
            this.gbD_Range.ResumeLayout(false);
            this.gbD_Range.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scThdVsFreq;
        private System.Windows.Forms.Button btnStopThdMeasurement;
        private ScottPlot.WinForms.FormsPlot graphFft;
        private System.Windows.Forms.Button btnStartThdMeasurement;
        private ScottPlot.WinForms.FormsPlot graphTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown udAverages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label lblThdFreq_OutputLoadUnit;
        private System.Windows.Forms.Label lblThdFreq_OutputLoad;
        private System.Windows.Forms.TextBox txtOutputLoad;
        private System.Windows.Forms.ComboBox cmbStartVoltageUnit;
        private System.Windows.Forms.Label lblThdFreq_GenVoltage;
        private System.Windows.Forms.TextBox txtStartVoltage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown udStepsOctave;
        private System.Windows.Forms.Label lblThdFreq_StepsPerOctave;
        private System.Windows.Forms.Label lblFrequency;
        private System.Windows.Forms.SplitContainer scGraphCursors;
        private System.Windows.Forms.SplitContainer scGraphSettings;
        private ScottPlot.WinForms.FormsPlot thdPlot;
        private System.Windows.Forms.CheckBox chkShowDataPoints;
        private System.Windows.Forms.CheckBox chkThickLines;
        private System.Windows.Forms.GroupBox gbDbv_Range;
        private System.Windows.Forms.NumericUpDown cmbDbV_Graph_Bottom;
        private System.Windows.Forms.NumericUpDown cmbDbV_Graph_Top;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnDbv_FitGraphY;
        private System.Windows.Forms.GroupBox gbThdFreq_Harmonics;
        private System.Windows.Forms.CheckBox chkShowMagnitude;
        private System.Windows.Forms.CheckBox chkShowNoiseFloor;
        private System.Windows.Forms.CheckBox chkShowD6;
        private System.Windows.Forms.CheckBox chkShowD5;
        private System.Windows.Forms.CheckBox chkShowD4;
        private System.Windows.Forms.CheckBox chkShowD3;
        private System.Windows.Forms.CheckBox chkShowD2;
        private System.Windows.Forms.CheckBox chkShowThd;
        private System.Windows.Forms.Button btnGraph_dBV;
        private System.Windows.Forms.Button btnGraph_D;
        private System.Windows.Forms.GroupBox gbThdFreq_FrequencyRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbVoltageGraph_To;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbVoltageGraph_From;
        private System.Windows.Forms.GroupBox gbD_Range;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbD_Graph_Bottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbD_Graph_Top;
        private System.Windows.Forms.Button btnD_FitGraphY;
        private System.Windows.Forms.Label lblCursor_NoiseFloor;
        private System.Windows.Forms.Label lblCursor_Power;
        private System.Windows.Forms.Label lblCursor_DC;
        private System.Windows.Forms.Label lblCursor_D6;
        private System.Windows.Forms.Label lblCursor_D5;
        private System.Windows.Forms.Label lblCursor_D4;
        private System.Windows.Forms.Label lblCursor_D3;
        private System.Windows.Forms.Label lblCursor_D2;
        private System.Windows.Forms.Label lblCursor_THD;
        private System.Windows.Forms.Label lblCursor_Magnitude;
        private System.Windows.Forms.Label lblCursor_Voltage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtEndVoltage;
        private System.Windows.Forms.ComboBox cmbEndVoltageUnit;
        private System.Windows.Forms.Button btnAutoFitX;
    }
}