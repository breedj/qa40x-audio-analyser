namespace QA40x_AUDIO_ANALYSER
{
    partial class frmThdFrequency
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
            this.chkEnableRightChannel = new System.Windows.Forms.CheckBox();
            this.chkEnableLeftChannel = new System.Windows.Forms.CheckBox();
            this.cmbAmplifierOutputVoltageUnit = new System.Windows.Forms.ComboBox();
            this.lblAmplifierOutputVoltage = new System.Windows.Forms.Label();
            this.txtAmplifierOutputVoltage = new System.Windows.Forms.TextBox();
            this.udAverages = new System.Windows.Forms.NumericUpDown();
            this.lblAverages = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEndFrequency = new System.Windows.Forms.TextBox();
            this.txtStartFrequency = new System.Windows.Forms.TextBox();
            this.lblAmplifierOutputPowerUnit = new System.Windows.Forms.Label();
            this.lblAmplifierOutputPower = new System.Windows.Forms.Label();
            this.txtAmplifierOutputPower = new System.Windows.Forms.TextBox();
            this.lblAmplifierLoadUnit = new System.Windows.Forms.Label();
            this.lblOutputLoad = new System.Windows.Forms.Label();
            this.txtOutputLoad = new System.Windows.Forms.TextBox();
            this.cmbGeneratorVoltageUnit = new System.Windows.Forms.ComboBox();
            this.lblGeneratorVoltage = new System.Windows.Forms.Label();
            this.txtGeneratorVoltage = new System.Windows.Forms.TextBox();
            this.lblGeneratorType = new System.Windows.Forms.Label();
            this.cmbGeneratorType = new System.Windows.Forms.ComboBox();
            this.udStepsOctave = new System.Windows.Forms.NumericUpDown();
            this.lblStepsPerOctave = new System.Windows.Forms.Label();
            this.lblThdFreq_EndFrequency = new System.Windows.Forms.Label();
            this.lblStartFrequency = new System.Windows.Forms.Label();
            this.scGraphCursors = new System.Windows.Forms.SplitContainer();
            this.scGraphSettings = new System.Windows.Forms.SplitContainer();
            this.thdPlot = new ScottPlot.WinForms.FormsPlot();
            this.chkGraphShowRightChannel = new System.Windows.Forms.CheckBox();
            this.chkGraphShowLeftChannel = new System.Windows.Forms.CheckBox();
            this.chkShowDataPoints = new System.Windows.Forms.CheckBox();
            this.chkThickLines = new System.Windows.Forms.CheckBox();
            this.gbdB_Range = new System.Windows.Forms.GroupBox();
            this.ud_dB_Graph_Bottom = new System.Windows.Forms.NumericUpDown();
            this.ud_dB_Graph_Top = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btndB_FitGraphY = new System.Windows.Forms.Button();
            this.gbHarmonics = new System.Windows.Forms.GroupBox();
            this.chkShowMagnitude = new System.Windows.Forms.CheckBox();
            this.chkShowNoiseFloor = new System.Windows.Forms.CheckBox();
            this.chkShowD6 = new System.Windows.Forms.CheckBox();
            this.chkShowD5 = new System.Windows.Forms.CheckBox();
            this.chkShowD4 = new System.Windows.Forms.CheckBox();
            this.chkShowD3 = new System.Windows.Forms.CheckBox();
            this.chkShowD2 = new System.Windows.Forms.CheckBox();
            this.chkShowThd = new System.Windows.Forms.CheckBox();
            this.btnGraph_dB = new System.Windows.Forms.Button();
            this.btnGraph_D_Percent = new System.Windows.Forms.Button();
            this.gbFrequencyRange = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbGraph_FreqEnd = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbGraph_FreqStart = new System.Windows.Forms.ComboBox();
            this.btnFitGraphX = new System.Windows.Forms.Button();
            this.gbD_Range = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbD_Graph_Bottom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbD_Graph_Top = new System.Windows.Forms.ComboBox();
            this.btnD_FitGraphY = new System.Windows.Forms.Button();
            this.pnlCursorsRight = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.lblCursor_Magnitude_R = new System.Windows.Forms.Label();
            this.lblCursor_NoiseFloor_R = new System.Windows.Forms.Label();
            this.lblCursor_THD_R = new System.Windows.Forms.Label();
            this.lblCursor_Power_R = new System.Windows.Forms.Label();
            this.lblCursor_D2_R = new System.Windows.Forms.Label();
            this.lblCursor_D6_R = new System.Windows.Forms.Label();
            this.lblCursor_D3_R = new System.Windows.Forms.Label();
            this.lblCursor_D5_R = new System.Windows.Forms.Label();
            this.lblCursor_D4_R = new System.Windows.Forms.Label();
            this.pnlCursorsLeft = new System.Windows.Forms.Panel();
            this.lblCursor_D5_L = new System.Windows.Forms.Label();
            this.lblCursor_Magnitude_L = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lblCursor_THD_L = new System.Windows.Forms.Label();
            this.lblCursor_D2_L = new System.Windows.Forms.Label();
            this.lblCursor_D3_L = new System.Windows.Forms.Label();
            this.lblCursor_D4_L = new System.Windows.Forms.Label();
            this.lblCursor_D6_L = new System.Windows.Forms.Label();
            this.lblCursor_Power_L = new System.Windows.Forms.Label();
            this.lblCursor_NoiseFloor_L = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCursorMagnitude = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCursor_Frequency = new System.Windows.Forms.Label();
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
            this.gbdB_Range.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_dB_Graph_Bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_dB_Graph_Top)).BeginInit();
            this.gbHarmonics.SuspendLayout();
            this.gbFrequencyRange.SuspendLayout();
            this.gbD_Range.SuspendLayout();
            this.pnlCursorsRight.SuspendLayout();
            this.pnlCursorsLeft.SuspendLayout();
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
            this.btnStopThdMeasurement.Click += new System.EventHandler(this.btnStopMeasurement_Click);
            // 
            // graphFft
            // 
            this.graphFft.DisplayScale = 0F;
            this.graphFft.Location = new System.Drawing.Point(3, 375);
            this.graphFft.Name = "graphFft";
            this.graphFft.Size = new System.Drawing.Size(254, 160);
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
            this.btnStartThdMeasurement.Click += new System.EventHandler(this.btnStartMeasurement_Click);
            // 
            // graphTime
            // 
            this.graphTime.DisplayScale = 0F;
            this.graphTime.Location = new System.Drawing.Point(3, 536);
            this.graphTime.Name = "graphTime";
            this.graphTime.Size = new System.Drawing.Size(254, 160);
            this.graphTime.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnableRightChannel);
            this.groupBox1.Controls.Add(this.chkEnableLeftChannel);
            this.groupBox1.Controls.Add(this.cmbAmplifierOutputVoltageUnit);
            this.groupBox1.Controls.Add(this.lblAmplifierOutputVoltage);
            this.groupBox1.Controls.Add(this.txtAmplifierOutputVoltage);
            this.groupBox1.Controls.Add(this.udAverages);
            this.groupBox1.Controls.Add(this.lblAverages);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEndFrequency);
            this.groupBox1.Controls.Add(this.txtStartFrequency);
            this.groupBox1.Controls.Add(this.lblAmplifierOutputPowerUnit);
            this.groupBox1.Controls.Add(this.lblAmplifierOutputPower);
            this.groupBox1.Controls.Add(this.txtAmplifierOutputPower);
            this.groupBox1.Controls.Add(this.lblAmplifierLoadUnit);
            this.groupBox1.Controls.Add(this.lblOutputLoad);
            this.groupBox1.Controls.Add(this.txtOutputLoad);
            this.groupBox1.Controls.Add(this.cmbGeneratorVoltageUnit);
            this.groupBox1.Controls.Add(this.lblGeneratorVoltage);
            this.groupBox1.Controls.Add(this.txtGeneratorVoltage);
            this.groupBox1.Controls.Add(this.lblGeneratorType);
            this.groupBox1.Controls.Add(this.cmbGeneratorType);
            this.groupBox1.Controls.Add(this.udStepsOctave);
            this.groupBox1.Controls.Add(this.lblStepsPerOctave);
            this.groupBox1.Controls.Add(this.lblThdFreq_EndFrequency);
            this.groupBox1.Controls.Add(this.lblStartFrequency);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(254, 319);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Settings";
            // 
            // chkEnableRightChannel
            // 
            this.chkEnableRightChannel.AutoSize = true;
            this.chkEnableRightChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableRightChannel.Location = new System.Drawing.Point(143, 292);
            this.chkEnableRightChannel.Name = "chkEnableRightChannel";
            this.chkEnableRightChannel.Size = new System.Drawing.Size(92, 17);
            this.chkEnableRightChannel.TabIndex = 45;
            this.chkEnableRightChannel.Text = "Right channel";
            this.chkEnableRightChannel.UseVisualStyleBackColor = true;
            this.chkEnableRightChannel.CheckedChanged += new System.EventHandler(this.chkEnableRightChannel_CheckedChanged);
            // 
            // chkEnableLeftChannel
            // 
            this.chkEnableLeftChannel.AutoSize = true;
            this.chkEnableLeftChannel.Checked = true;
            this.chkEnableLeftChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableLeftChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnableLeftChannel.Location = new System.Drawing.Point(18, 292);
            this.chkEnableLeftChannel.Name = "chkEnableLeftChannel";
            this.chkEnableLeftChannel.Size = new System.Drawing.Size(85, 17);
            this.chkEnableLeftChannel.TabIndex = 44;
            this.chkEnableLeftChannel.Text = "Left channel";
            this.chkEnableLeftChannel.UseVisualStyleBackColor = true;
            this.chkEnableLeftChannel.CheckedChanged += new System.EventHandler(this.chkEnableLeftChannel_CheckedChanged);
            // 
            // cmbAmplifierOutputVoltageUnit
            // 
            this.cmbAmplifierOutputVoltageUnit.DisplayMember = "1";
            this.cmbAmplifierOutputVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmplifierOutputVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAmplifierOutputVoltageUnit.FormattingEnabled = true;
            this.cmbAmplifierOutputVoltageUnit.Location = new System.Drawing.Point(192, 122);
            this.cmbAmplifierOutputVoltageUnit.Name = "cmbAmplifierOutputVoltageUnit";
            this.cmbAmplifierOutputVoltageUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbAmplifierOutputVoltageUnit.TabIndex = 27;
            this.cmbAmplifierOutputVoltageUnit.SelectedIndexChanged += new System.EventHandler(this.cmbOutputVoltageUnit_SelectedIndexChanged);
            // 
            // lblAmplifierOutputVoltage
            // 
            this.lblAmplifierOutputVoltage.AutoSize = true;
            this.lblAmplifierOutputVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplifierOutputVoltage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmplifierOutputVoltage.Location = new System.Drawing.Point(14, 125);
            this.lblAmplifierOutputVoltage.Name = "lblAmplifierOutputVoltage";
            this.lblAmplifierOutputVoltage.Size = new System.Drawing.Size(78, 13);
            this.lblAmplifierOutputVoltage.TabIndex = 26;
            this.lblAmplifierOutputVoltage.Text = "Output Voltage";
            // 
            // txtAmplifierOutputVoltage
            // 
            this.txtAmplifierOutputVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmplifierOutputVoltage.Location = new System.Drawing.Point(128, 123);
            this.txtAmplifierOutputVoltage.Name = "txtAmplifierOutputVoltage";
            this.txtAmplifierOutputVoltage.Size = new System.Drawing.Size(58, 20);
            this.txtAmplifierOutputVoltage.TabIndex = 25;
            this.txtAmplifierOutputVoltage.TextChanged += new System.EventHandler(this.txtOutputVoltage_TextChanged);
            this.txtAmplifierOutputVoltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputVoltage_KeyPress);
            // 
            // udAverages
            // 
            this.udAverages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udAverages.Location = new System.Drawing.Point(128, 258);
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
            this.udAverages.Size = new System.Drawing.Size(59, 20);
            this.udAverages.TabIndex = 24;
            this.udAverages.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udAverages.ValueChanged += new System.EventHandler(this.udAverages_ValueChanged);
            // 
            // lblAverages
            // 
            this.lblAverages.AutoSize = true;
            this.lblAverages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAverages.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAverages.Location = new System.Drawing.Point(13, 260);
            this.lblAverages.Name = "lblAverages";
            this.lblAverages.Size = new System.Drawing.Size(52, 13);
            this.lblAverages.TabIndex = 23;
            this.lblAverages.Text = "Averages";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(193, 207);
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
            this.label2.Location = new System.Drawing.Point(193, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hz";
            // 
            // txtEndFrequency
            // 
            this.txtEndFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndFrequency.Location = new System.Drawing.Point(128, 204);
            this.txtEndFrequency.Name = "txtEndFrequency";
            this.txtEndFrequency.Size = new System.Drawing.Size(59, 20);
            this.txtEndFrequency.TabIndex = 20;
            this.txtEndFrequency.Text = "20000";
            this.txtEndFrequency.TextChanged += new System.EventHandler(this.txtEndFreq_TextChanged);
            this.txtEndFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEndFreq_KeyPress);
            // 
            // txtStartFrequency
            // 
            this.txtStartFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartFrequency.Location = new System.Drawing.Point(128, 178);
            this.txtStartFrequency.Name = "txtStartFrequency";
            this.txtStartFrequency.Size = new System.Drawing.Size(59, 20);
            this.txtStartFrequency.TabIndex = 19;
            this.txtStartFrequency.Text = "20";
            this.txtStartFrequency.TextChanged += new System.EventHandler(this.txtStartFreq_TextChanged);
            this.txtStartFrequency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartFreq_KeyPress);
            // 
            // lblAmplifierOutputPowerUnit
            // 
            this.lblAmplifierOutputPowerUnit.AutoSize = true;
            this.lblAmplifierOutputPowerUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplifierOutputPowerUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmplifierOutputPowerUnit.Location = new System.Drawing.Point(193, 100);
            this.lblAmplifierOutputPowerUnit.Name = "lblAmplifierOutputPowerUnit";
            this.lblAmplifierOutputPowerUnit.Size = new System.Drawing.Size(30, 13);
            this.lblAmplifierOutputPowerUnit.TabIndex = 18;
            this.lblAmplifierOutputPowerUnit.Text = "Watt";
            // 
            // lblAmplifierOutputPower
            // 
            this.lblAmplifierOutputPower.AutoSize = true;
            this.lblAmplifierOutputPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplifierOutputPower.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmplifierOutputPower.Location = new System.Drawing.Point(15, 100);
            this.lblAmplifierOutputPower.Name = "lblAmplifierOutputPower";
            this.lblAmplifierOutputPower.Size = new System.Drawing.Size(72, 13);
            this.lblAmplifierOutputPower.TabIndex = 17;
            this.lblAmplifierOutputPower.Text = "Output Power";
            // 
            // txtAmplifierOutputPower
            // 
            this.txtAmplifierOutputPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmplifierOutputPower.Location = new System.Drawing.Point(128, 97);
            this.txtAmplifierOutputPower.Name = "txtAmplifierOutputPower";
            this.txtAmplifierOutputPower.Size = new System.Drawing.Size(59, 20);
            this.txtAmplifierOutputPower.TabIndex = 16;
            this.txtAmplifierOutputPower.Text = "1";
            this.txtAmplifierOutputPower.TextChanged += new System.EventHandler(this.txtOutputPower_TextChanged);
            this.txtAmplifierOutputPower.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputPower_KeyPress);
            // 
            // lblAmplifierLoadUnit
            // 
            this.lblAmplifierLoadUnit.AutoSize = true;
            this.lblAmplifierLoadUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmplifierLoadUnit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmplifierLoadUnit.Location = new System.Drawing.Point(193, 74);
            this.lblAmplifierLoadUnit.Name = "lblAmplifierLoadUnit";
            this.lblAmplifierLoadUnit.Size = new System.Drawing.Size(16, 13);
            this.lblAmplifierLoadUnit.TabIndex = 15;
            this.lblAmplifierLoadUnit.Text = "Ω";
            // 
            // lblOutputLoad
            // 
            this.lblOutputLoad.AutoSize = true;
            this.lblOutputLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutputLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOutputLoad.Location = new System.Drawing.Point(15, 74);
            this.lblOutputLoad.Name = "lblOutputLoad";
            this.lblOutputLoad.Size = new System.Drawing.Size(73, 13);
            this.lblOutputLoad.TabIndex = 14;
            this.lblOutputLoad.Text = "Amplifier Load";
            // 
            // txtOutputLoad
            // 
            this.txtOutputLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputLoad.Location = new System.Drawing.Point(128, 71);
            this.txtOutputLoad.Name = "txtOutputLoad";
            this.txtOutputLoad.Size = new System.Drawing.Size(59, 20);
            this.txtOutputLoad.TabIndex = 13;
            this.txtOutputLoad.Text = "8";
            this.txtOutputLoad.TextChanged += new System.EventHandler(this.txtOutputLoad_TextChanged);
            this.txtOutputLoad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputLoad_KeyPress);
            // 
            // cmbGeneratorVoltageUnit
            // 
            this.cmbGeneratorVoltageUnit.DisplayMember = "1";
            this.cmbGeneratorVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneratorVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneratorVoltageUnit.FormattingEnabled = true;
            this.cmbGeneratorVoltageUnit.Location = new System.Drawing.Point(193, 44);
            this.cmbGeneratorVoltageUnit.Name = "cmbGeneratorVoltageUnit";
            this.cmbGeneratorVoltageUnit.Size = new System.Drawing.Size(48, 21);
            this.cmbGeneratorVoltageUnit.TabIndex = 12;
            this.cmbGeneratorVoltageUnit.SelectedIndexChanged += new System.EventHandler(this.cmbVoltageUnit_SelectedIndexChanged);
            // 
            // lblGeneratorVoltage
            // 
            this.lblGeneratorVoltage.AutoSize = true;
            this.lblGeneratorVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratorVoltage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGeneratorVoltage.Location = new System.Drawing.Point(15, 47);
            this.lblGeneratorVoltage.Name = "lblGeneratorVoltage";
            this.lblGeneratorVoltage.Size = new System.Drawing.Size(66, 13);
            this.lblGeneratorVoltage.TabIndex = 11;
            this.lblGeneratorVoltage.Text = "Gen Voltage";
            // 
            // txtGeneratorVoltage
            // 
            this.txtGeneratorVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGeneratorVoltage.Location = new System.Drawing.Point(128, 45);
            this.txtGeneratorVoltage.Name = "txtGeneratorVoltage";
            this.txtGeneratorVoltage.Size = new System.Drawing.Size(59, 20);
            this.txtGeneratorVoltage.TabIndex = 10;
            this.txtGeneratorVoltage.TextChanged += new System.EventHandler(this.txtGenVoltage_TextChanged);
            this.txtGeneratorVoltage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGenVoltage_KeyPress);
            // 
            // lblGeneratorType
            // 
            this.lblGeneratorType.AutoSize = true;
            this.lblGeneratorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratorType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblGeneratorType.Location = new System.Drawing.Point(15, 22);
            this.lblGeneratorType.Name = "lblGeneratorType";
            this.lblGeneratorType.Size = new System.Drawing.Size(85, 13);
            this.lblGeneratorType.TabIndex = 9;
            this.lblGeneratorType.Text = "Set generator by";
            // 
            // cmbGeneratorType
            // 
            this.cmbGeneratorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGeneratorType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGeneratorType.FormattingEnabled = true;
            this.cmbGeneratorType.Items.AddRange(new object[] {
            "Input voltage",
            "Output voltage",
            "Output power"});
            this.cmbGeneratorType.Location = new System.Drawing.Point(128, 19);
            this.cmbGeneratorType.Name = "cmbGeneratorType";
            this.cmbGeneratorType.Size = new System.Drawing.Size(113, 21);
            this.cmbGeneratorType.TabIndex = 8;
            this.cmbGeneratorType.SelectedIndexChanged += new System.EventHandler(this.cmbGenType_SelectedIndexChanged);
            // 
            // udStepsOctave
            // 
            this.udStepsOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.udStepsOctave.Location = new System.Drawing.Point(128, 231);
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
            // lblStepsPerOctave
            // 
            this.lblStepsPerOctave.AutoSize = true;
            this.lblStepsPerOctave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStepsPerOctave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStepsPerOctave.Location = new System.Drawing.Point(13, 233);
            this.lblStepsPerOctave.Name = "lblStepsPerOctave";
            this.lblStepsPerOctave.Size = new System.Drawing.Size(80, 13);
            this.lblStepsPerOctave.TabIndex = 4;
            this.lblStepsPerOctave.Text = "Steps / Octave";
            // 
            // lblThdFreq_EndFrequency
            // 
            this.lblThdFreq_EndFrequency.AutoSize = true;
            this.lblThdFreq_EndFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThdFreq_EndFrequency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblThdFreq_EndFrequency.Location = new System.Drawing.Point(13, 207);
            this.lblThdFreq_EndFrequency.Name = "lblThdFreq_EndFrequency";
            this.lblThdFreq_EndFrequency.Size = new System.Drawing.Size(79, 13);
            this.lblThdFreq_EndFrequency.TabIndex = 2;
            this.lblThdFreq_EndFrequency.Text = "End Frequency";
            // 
            // lblStartFrequency
            // 
            this.lblStartFrequency.AutoSize = true;
            this.lblStartFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartFrequency.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStartFrequency.Location = new System.Drawing.Point(13, 181);
            this.lblStartFrequency.Name = "lblStartFrequency";
            this.lblStartFrequency.Size = new System.Drawing.Size(82, 13);
            this.lblStartFrequency.TabIndex = 0;
            this.lblStartFrequency.Text = "Start Frequency";
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
            this.scGraphCursors.Panel2.Controls.Add(this.pnlCursorsRight);
            this.scGraphCursors.Panel2.Controls.Add(this.pnlCursorsLeft);
            this.scGraphCursors.Panel2.Controls.Add(this.label17);
            this.scGraphCursors.Panel2.Controls.Add(this.label16);
            this.scGraphCursors.Panel2.Controls.Add(this.label15);
            this.scGraphCursors.Panel2.Controls.Add(this.label14);
            this.scGraphCursors.Panel2.Controls.Add(this.label13);
            this.scGraphCursors.Panel2.Controls.Add(this.label12);
            this.scGraphCursors.Panel2.Controls.Add(this.label5);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursorMagnitude);
            this.scGraphCursors.Panel2.Controls.Add(this.label1);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_Frequency);
            this.scGraphCursors.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.scGraphCursors_Panel2_Paint);
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
            this.scGraphSettings.Panel2.Controls.Add(this.chkGraphShowRightChannel);
            this.scGraphSettings.Panel2.Controls.Add(this.chkGraphShowLeftChannel);
            this.scGraphSettings.Panel2.Controls.Add(this.chkShowDataPoints);
            this.scGraphSettings.Panel2.Controls.Add(this.chkThickLines);
            this.scGraphSettings.Panel2.Controls.Add(this.gbdB_Range);
            this.scGraphSettings.Panel2.Controls.Add(this.gbHarmonics);
            this.scGraphSettings.Panel2.Controls.Add(this.btnGraph_dB);
            this.scGraphSettings.Panel2.Controls.Add(this.btnGraph_D_Percent);
            this.scGraphSettings.Panel2.Controls.Add(this.gbFrequencyRange);
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
            // chkGraphShowRightChannel
            // 
            this.chkGraphShowRightChannel.AutoSize = true;
            this.chkGraphShowRightChannel.Checked = true;
            this.chkGraphShowRightChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGraphShowRightChannel.Location = new System.Drawing.Point(9, 685);
            this.chkGraphShowRightChannel.Name = "chkGraphShowRightChannel";
            this.chkGraphShowRightChannel.Size = new System.Drawing.Size(92, 17);
            this.chkGraphShowRightChannel.TabIndex = 46;
            this.chkGraphShowRightChannel.Text = "Right channel";
            this.chkGraphShowRightChannel.UseVisualStyleBackColor = true;
            this.chkGraphShowRightChannel.CheckedChanged += new System.EventHandler(this.chkGraphShowRightChannel_CheckedChanged);
            // 
            // chkGraphShowLeftChannel
            // 
            this.chkGraphShowLeftChannel.AutoSize = true;
            this.chkGraphShowLeftChannel.Checked = true;
            this.chkGraphShowLeftChannel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGraphShowLeftChannel.Location = new System.Drawing.Point(9, 664);
            this.chkGraphShowLeftChannel.Name = "chkGraphShowLeftChannel";
            this.chkGraphShowLeftChannel.Size = new System.Drawing.Size(85, 17);
            this.chkGraphShowLeftChannel.TabIndex = 46;
            this.chkGraphShowLeftChannel.Text = "Left channel";
            this.chkGraphShowLeftChannel.UseVisualStyleBackColor = true;
            this.chkGraphShowLeftChannel.CheckedChanged += new System.EventHandler(this.chkGraphShowLeftChannel_CheckedChanged);
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
            this.chkShowDataPoints.CheckedChanged += new System.EventHandler(this.chkShowDataPoints_CheckedChanged);
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
            this.chkThickLines.CheckedChanged += new System.EventHandler(this.chkThickLines_CheckedChanged);
            // 
            // gbdB_Range
            // 
            this.gbdB_Range.Controls.Add(this.ud_dB_Graph_Bottom);
            this.gbdB_Range.Controls.Add(this.ud_dB_Graph_Top);
            this.gbdB_Range.Controls.Add(this.label10);
            this.gbdB_Range.Controls.Add(this.label11);
            this.gbdB_Range.Controls.Add(this.btndB_FitGraphY);
            this.gbdB_Range.Location = new System.Drawing.Point(43, 20);
            this.gbdB_Range.Name = "gbdB_Range";
            this.gbdB_Range.Size = new System.Drawing.Size(113, 143);
            this.gbdB_Range.TabIndex = 30;
            this.gbdB_Range.TabStop = false;
            this.gbdB_Range.Text = "dB range";
            // 
            // ud_dB_Graph_Bottom
            // 
            this.ud_dB_Graph_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_dB_Graph_Bottom.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ud_dB_Graph_Bottom.Location = new System.Drawing.Point(8, 77);
            this.ud_dB_Graph_Bottom.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ud_dB_Graph_Bottom.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.ud_dB_Graph_Bottom.Name = "ud_dB_Graph_Bottom";
            this.ud_dB_Graph_Bottom.Size = new System.Drawing.Size(94, 20);
            this.ud_dB_Graph_Bottom.TabIndex = 31;
            this.ud_dB_Graph_Bottom.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ud_dB_Graph_Bottom.ValueChanged += new System.EventHandler(this.ud_dB_Graph_Bottom_ValueChanged);
            // 
            // ud_dB_Graph_Top
            // 
            this.ud_dB_Graph_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ud_dB_Graph_Top.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.ud_dB_Graph_Top.Location = new System.Drawing.Point(8, 36);
            this.ud_dB_Graph_Top.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.ud_dB_Graph_Top.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.ud_dB_Graph_Top.Name = "ud_dB_Graph_Top";
            this.ud_dB_Graph_Top.Size = new System.Drawing.Size(94, 20);
            this.ud_dB_Graph_Top.TabIndex = 30;
            this.ud_dB_Graph_Top.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ud_dB_Graph_Top.ValueChanged += new System.EventHandler(this.ud_dB_Graph_Top_ValueChanged);
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
            // btndB_FitGraphY
            // 
            this.btndB_FitGraphY.Location = new System.Drawing.Point(6, 109);
            this.btndB_FitGraphY.Name = "btndB_FitGraphY";
            this.btndB_FitGraphY.Size = new System.Drawing.Size(94, 23);
            this.btndB_FitGraphY.TabIndex = 25;
            this.btndB_FitGraphY.Text = "Autofit";
            this.btndB_FitGraphY.UseVisualStyleBackColor = true;
            this.btndB_FitGraphY.Click += new System.EventHandler(this.btnFitDbGraphY_Click);
            // 
            // gbHarmonics
            // 
            this.gbHarmonics.Controls.Add(this.chkShowMagnitude);
            this.gbHarmonics.Controls.Add(this.chkShowNoiseFloor);
            this.gbHarmonics.Controls.Add(this.chkShowD6);
            this.gbHarmonics.Controls.Add(this.chkShowD5);
            this.gbHarmonics.Controls.Add(this.chkShowD4);
            this.gbHarmonics.Controls.Add(this.chkShowD3);
            this.gbHarmonics.Controls.Add(this.chkShowD2);
            this.gbHarmonics.Controls.Add(this.chkShowThd);
            this.gbHarmonics.Location = new System.Drawing.Point(4, 363);
            this.gbHarmonics.Name = "gbHarmonics";
            this.gbHarmonics.Size = new System.Drawing.Size(111, 207);
            this.gbHarmonics.TabIndex = 29;
            this.gbHarmonics.TabStop = false;
            this.gbHarmonics.Text = "Graph data";
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
            this.chkShowMagnitude.CheckedChanged += new System.EventHandler(this.chkShowMagnitude_CheckedChanged);
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
            this.chkShowNoiseFloor.CheckedChanged += new System.EventHandler(this.chkShowNoiseFloor_CheckedChanged);
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
            this.chkShowD6.CheckedChanged += new System.EventHandler(this.chkShowD6_CheckedChanged);
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
            this.chkShowD5.CheckedChanged += new System.EventHandler(this.chkShowD5_CheckedChanged);
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
            this.chkShowD4.CheckedChanged += new System.EventHandler(this.chkShowD4_CheckedChanged);
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
            this.chkShowD3.CheckedChanged += new System.EventHandler(this.chkShowD3_CheckedChanged);
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
            this.chkShowD2.CheckedChanged += new System.EventHandler(this.chkShowD2_CheckedChanged);
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
            this.chkShowThd.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged_1);
            // 
            // btnGraph_dB
            // 
            this.btnGraph_dB.BackColor = System.Drawing.Color.Cornsilk;
            this.btnGraph_dB.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnGraph_dB.FlatAppearance.BorderSize = 2;
            this.btnGraph_dB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph_dB.Location = new System.Drawing.Point(9, 621);
            this.btnGraph_dB.Name = "btnGraph_dB";
            this.btnGraph_dB.Size = new System.Drawing.Size(52, 37);
            this.btnGraph_dB.TabIndex = 28;
            this.btnGraph_dB.Text = "D (dB)";
            this.btnGraph_dB.UseVisualStyleBackColor = false;
            this.btnGraph_dB.Click += new System.EventHandler(this.btnGraph_dB_Click);
            // 
            // btnGraph_D_Percent
            // 
            this.btnGraph_D_Percent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGraph_D_Percent.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnGraph_D_Percent.FlatAppearance.BorderSize = 2;
            this.btnGraph_D_Percent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph_D_Percent.Location = new System.Drawing.Point(67, 621);
            this.btnGraph_D_Percent.Name = "btnGraph_D_Percent";
            this.btnGraph_D_Percent.Size = new System.Drawing.Size(49, 37);
            this.btnGraph_D_Percent.TabIndex = 27;
            this.btnGraph_D_Percent.Text = "D (%)";
            this.btnGraph_D_Percent.UseVisualStyleBackColor = false;
            this.btnGraph_D_Percent.Click += new System.EventHandler(this.btnGraph_D_Click);
            // 
            // gbFrequencyRange
            // 
            this.gbFrequencyRange.Controls.Add(this.label8);
            this.gbFrequencyRange.Controls.Add(this.cmbGraph_FreqEnd);
            this.gbFrequencyRange.Controls.Add(this.label9);
            this.gbFrequencyRange.Controls.Add(this.cmbGraph_FreqStart);
            this.gbFrequencyRange.Controls.Add(this.btnFitGraphX);
            this.gbFrequencyRange.Location = new System.Drawing.Point(3, 195);
            this.gbFrequencyRange.Name = "gbFrequencyRange";
            this.gbFrequencyRange.Size = new System.Drawing.Size(112, 161);
            this.gbFrequencyRange.TabIndex = 26;
            this.gbFrequencyRange.TabStop = false;
            this.gbFrequencyRange.Text = "Frequency range";
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
            // cmbGraph_FreqEnd
            // 
            this.cmbGraph_FreqEnd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraph_FreqEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGraph_FreqEnd.FormattingEnabled = true;
            this.cmbGraph_FreqEnd.Location = new System.Drawing.Point(6, 82);
            this.cmbGraph_FreqEnd.Name = "cmbGraph_FreqEnd";
            this.cmbGraph_FreqEnd.Size = new System.Drawing.Size(94, 21);
            this.cmbGraph_FreqEnd.TabIndex = 33;
            this.cmbGraph_FreqEnd.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_FreqEnd_SelectedIndexChanged);
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
            // cmbGraph_FreqStart
            // 
            this.cmbGraph_FreqStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraph_FreqStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGraph_FreqStart.FormattingEnabled = true;
            this.cmbGraph_FreqStart.Location = new System.Drawing.Point(6, 38);
            this.cmbGraph_FreqStart.Name = "cmbGraph_FreqStart";
            this.cmbGraph_FreqStart.Size = new System.Drawing.Size(94, 21);
            this.cmbGraph_FreqStart.TabIndex = 31;
            this.cmbGraph_FreqStart.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_FreqStart_SelectedIndexChanged);
            // 
            // btnFitGraphX
            // 
            this.btnFitGraphX.Location = new System.Drawing.Point(6, 117);
            this.btnFitGraphX.Name = "btnFitGraphX";
            this.btnFitGraphX.Size = new System.Drawing.Size(94, 23);
            this.btnFitGraphX.TabIndex = 30;
            this.btnFitGraphX.Text = "Autofit";
            this.btnFitGraphX.UseVisualStyleBackColor = true;
            this.btnFitGraphX.Click += new System.EventHandler(this.btnFitGraphX_Click);
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
            this.cmbD_Graph_Bottom.Location = new System.Drawing.Point(6, 74);
            this.cmbD_Graph_Bottom.Name = "cmbD_Graph_Bottom";
            this.cmbD_Graph_Bottom.Size = new System.Drawing.Size(94, 21);
            this.cmbD_Graph_Bottom.TabIndex = 28;
            this.cmbD_Graph_Bottom.SelectedIndexChanged += new System.EventHandler(this.cmbD_Graph_Bottom_SelectedIndexChanged);
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
            this.cmbD_Graph_Top.Location = new System.Drawing.Point(6, 33);
            this.cmbD_Graph_Top.Name = "cmbD_Graph_Top";
            this.cmbD_Graph_Top.Size = new System.Drawing.Size(94, 21);
            this.cmbD_Graph_Top.TabIndex = 26;
            this.cmbD_Graph_Top.SelectedIndexChanged += new System.EventHandler(this.cmbD_Graph_Top_SelectedIndexChanged);
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
            // pnlCursorsRight
            // 
            this.pnlCursorsRight.Controls.Add(this.label28);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_Magnitude_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_NoiseFloor_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_THD_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_Power_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_D2_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_D6_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_D3_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_D5_R);
            this.pnlCursorsRight.Controls.Add(this.lblCursor_D4_R);
            this.pnlCursorsRight.Location = new System.Drawing.Point(46, 35);
            this.pnlCursorsRight.Name = "pnlCursorsRight";
            this.pnlCursorsRight.Size = new System.Drawing.Size(790, 16);
            this.pnlCursorsRight.TabIndex = 3;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(-1, 0);
            this.label28.MinimumSize = new System.Drawing.Size(50, 13);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(86, 13);
            this.label28.TabIndex = 40;
            this.label28.Text = "Right channel";
            // 
            // lblCursor_Magnitude_R
            // 
            this.lblCursor_Magnitude_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Magnitude_R.Location = new System.Drawing.Point(174, 0);
            this.lblCursor_Magnitude_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_Magnitude_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_Magnitude_R.Name = "lblCursor_Magnitude_R";
            this.lblCursor_Magnitude_R.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_Magnitude_R.TabIndex = 30;
            this.lblCursor_Magnitude_R.Text = "0.00 dB";
            // 
            // lblCursor_NoiseFloor_R
            // 
            this.lblCursor_NoiseFloor_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_NoiseFloor_R.Location = new System.Drawing.Point(716, 0);
            this.lblCursor_NoiseFloor_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_NoiseFloor_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_NoiseFloor_R.Name = "lblCursor_NoiseFloor_R";
            this.lblCursor_NoiseFloor_R.Size = new System.Drawing.Size(71, 13);
            this.lblCursor_NoiseFloor_R.TabIndex = 38;
            this.lblCursor_NoiseFloor_R.Text = "00.00 dB";
            // 
            // lblCursor_THD_R
            // 
            this.lblCursor_THD_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_THD_R.Location = new System.Drawing.Point(108, 0);
            this.lblCursor_THD_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_THD_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_THD_R.Name = "lblCursor_THD_R";
            this.lblCursor_THD_R.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_THD_R.TabIndex = 31;
            this.lblCursor_THD_R.Text = "0.00 %";
            // 
            // lblCursor_Power_R
            // 
            this.lblCursor_Power_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Power_R.Location = new System.Drawing.Point(630, 0);
            this.lblCursor_Power_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_Power_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_Power_R.Name = "lblCursor_Power_R";
            this.lblCursor_Power_R.Size = new System.Drawing.Size(82, 13);
            this.lblCursor_Power_R.TabIndex = 37;
            this.lblCursor_Power_R.Text = "0 mW";
            // 
            // lblCursor_D2_R
            // 
            this.lblCursor_D2_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D2_R.Location = new System.Drawing.Point(250, 0);
            this.lblCursor_D2_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D2_R.MinimumSize = new System.Drawing.Size(50, 13);
            this.lblCursor_D2_R.Name = "lblCursor_D2_R";
            this.lblCursor_D2_R.Size = new System.Drawing.Size(60, 14);
            this.lblCursor_D2_R.TabIndex = 32;
            this.lblCursor_D2_R.Text = "00.00 %";
            // 
            // lblCursor_D6_R
            // 
            this.lblCursor_D6_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D6_R.Location = new System.Drawing.Point(554, 0);
            this.lblCursor_D6_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D6_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D6_R.Name = "lblCursor_D6_R";
            this.lblCursor_D6_R.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D6_R.TabIndex = 36;
            this.lblCursor_D6_R.Text = "00.00 %";
            // 
            // lblCursor_D3_R
            // 
            this.lblCursor_D3_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D3_R.Location = new System.Drawing.Point(326, 0);
            this.lblCursor_D3_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D3_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D3_R.Name = "lblCursor_D3_R";
            this.lblCursor_D3_R.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D3_R.TabIndex = 33;
            this.lblCursor_D3_R.Text = "00.00 %";
            // 
            // lblCursor_D5_R
            // 
            this.lblCursor_D5_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D5_R.Location = new System.Drawing.Point(478, 0);
            this.lblCursor_D5_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D5_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D5_R.Name = "lblCursor_D5_R";
            this.lblCursor_D5_R.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D5_R.TabIndex = 35;
            this.lblCursor_D5_R.Text = "00.00 %";
            // 
            // lblCursor_D4_R
            // 
            this.lblCursor_D4_R.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D4_R.Location = new System.Drawing.Point(402, 0);
            this.lblCursor_D4_R.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D4_R.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D4_R.Name = "lblCursor_D4_R";
            this.lblCursor_D4_R.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D4_R.TabIndex = 34;
            this.lblCursor_D4_R.Text = "00.00 %";
            // 
            // pnlCursorsLeft
            // 
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_D5_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_Magnitude_L);
            this.pnlCursorsLeft.Controls.Add(this.label27);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_THD_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_D2_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_D3_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_D4_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_D6_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_Power_L);
            this.pnlCursorsLeft.Controls.Add(this.lblCursor_NoiseFloor_L);
            this.pnlCursorsLeft.Location = new System.Drawing.Point(44, 14);
            this.pnlCursorsLeft.Name = "pnlCursorsLeft";
            this.pnlCursorsLeft.Size = new System.Drawing.Size(790, 20);
            this.pnlCursorsLeft.TabIndex = 41;
            // 
            // lblCursor_D5_L
            // 
            this.lblCursor_D5_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D5_L.Location = new System.Drawing.Point(480, 2);
            this.lblCursor_D5_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D5_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D5_L.Name = "lblCursor_D5_L";
            this.lblCursor_D5_L.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D5_L.TabIndex = 16;
            this.lblCursor_D5_L.Text = "00.00 %";
            // 
            // lblCursor_Magnitude_L
            // 
            this.lblCursor_Magnitude_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Magnitude_L.Location = new System.Drawing.Point(176, 2);
            this.lblCursor_Magnitude_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_Magnitude_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_Magnitude_L.Name = "lblCursor_Magnitude_L";
            this.lblCursor_Magnitude_L.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_Magnitude_L.TabIndex = 11;
            this.lblCursor_Magnitude_L.Text = "0.00 dB";
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(0, 2);
            this.label27.MinimumSize = new System.Drawing.Size(50, 13);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 13);
            this.label27.TabIndex = 39;
            this.label27.Text = "Left channel";
            // 
            // lblCursor_THD_L
            // 
            this.lblCursor_THD_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_THD_L.Location = new System.Drawing.Point(110, 2);
            this.lblCursor_THD_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_THD_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_THD_L.Name = "lblCursor_THD_L";
            this.lblCursor_THD_L.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_THD_L.TabIndex = 12;
            this.lblCursor_THD_L.Text = "0.00 %";
            // 
            // lblCursor_D2_L
            // 
            this.lblCursor_D2_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D2_L.Location = new System.Drawing.Point(252, 2);
            this.lblCursor_D2_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D2_L.MinimumSize = new System.Drawing.Size(50, 13);
            this.lblCursor_D2_L.Name = "lblCursor_D2_L";
            this.lblCursor_D2_L.Size = new System.Drawing.Size(60, 14);
            this.lblCursor_D2_L.TabIndex = 13;
            this.lblCursor_D2_L.Text = "00.00 %";
            // 
            // lblCursor_D3_L
            // 
            this.lblCursor_D3_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D3_L.Location = new System.Drawing.Point(328, 2);
            this.lblCursor_D3_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D3_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D3_L.Name = "lblCursor_D3_L";
            this.lblCursor_D3_L.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D3_L.TabIndex = 14;
            this.lblCursor_D3_L.Text = "00.00 %";
            // 
            // lblCursor_D4_L
            // 
            this.lblCursor_D4_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D4_L.Location = new System.Drawing.Point(404, 2);
            this.lblCursor_D4_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D4_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D4_L.Name = "lblCursor_D4_L";
            this.lblCursor_D4_L.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D4_L.TabIndex = 15;
            this.lblCursor_D4_L.Text = "00.00 %";
            // 
            // lblCursor_D6_L
            // 
            this.lblCursor_D6_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_D6_L.Location = new System.Drawing.Point(556, 2);
            this.lblCursor_D6_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_D6_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_D6_L.Name = "lblCursor_D6_L";
            this.lblCursor_D6_L.Size = new System.Drawing.Size(60, 15);
            this.lblCursor_D6_L.TabIndex = 17;
            this.lblCursor_D6_L.Text = "00.00 %";
            // 
            // lblCursor_Power_L
            // 
            this.lblCursor_Power_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Power_L.Location = new System.Drawing.Point(632, 2);
            this.lblCursor_Power_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_Power_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_Power_L.Name = "lblCursor_Power_L";
            this.lblCursor_Power_L.Size = new System.Drawing.Size(80, 13);
            this.lblCursor_Power_L.TabIndex = 19;
            this.lblCursor_Power_L.Text = "0 mW";
            this.lblCursor_Power_L.Click += new System.EventHandler(this.lblCursor_Power_Click);
            // 
            // lblCursor_NoiseFloor_L
            // 
            this.lblCursor_NoiseFloor_L.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_NoiseFloor_L.Location = new System.Drawing.Point(718, 2);
            this.lblCursor_NoiseFloor_L.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_NoiseFloor_L.MinimumSize = new System.Drawing.Size(60, 13);
            this.lblCursor_NoiseFloor_L.Name = "lblCursor_NoiseFloor_L";
            this.lblCursor_NoiseFloor_L.Size = new System.Drawing.Size(71, 13);
            this.lblCursor_NoiseFloor_L.TabIndex = 20;
            this.lblCursor_NoiseFloor_L.Text = "00.00 dB";
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(761, -1);
            this.label17.MinimumSize = new System.Drawing.Size(50, 13);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 29;
            this.label17.Text = "Noise floor";
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(675, -1);
            this.label16.MinimumSize = new System.Drawing.Size(50, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(70, 13);
            this.label16.TabIndex = 28;
            this.label16.Text = "Power";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(599, -1);
            this.label15.MinimumSize = new System.Drawing.Size(50, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 27;
            this.label15.Text = "D6+";
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(523, -1);
            this.label14.MinimumSize = new System.Drawing.Size(50, 13);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "D5";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(447, -1);
            this.label13.MinimumSize = new System.Drawing.Size(50, 13);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "D4";
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(371, -1);
            this.label12.MinimumSize = new System.Drawing.Size(50, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(70, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "D3";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(295, 0);
            this.label5.MinimumSize = new System.Drawing.Size(50, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "D2";
            // 
            // lblCursorMagnitude
            // 
            this.lblCursorMagnitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursorMagnitude.Location = new System.Drawing.Point(219, -1);
            this.lblCursorMagnitude.MinimumSize = new System.Drawing.Size(50, 13);
            this.lblCursorMagnitude.Name = "lblCursorMagnitude";
            this.lblCursorMagnitude.Size = new System.Drawing.Size(70, 13);
            this.lblCursorMagnitude.TabIndex = 22;
            this.lblCursorMagnitude.Text = "Magnitude";
            this.lblCursorMagnitude.Click += new System.EventHandler(this.label4_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, -1);
            this.label1.MinimumSize = new System.Drawing.Size(50, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "THD";
            // 
            // lblCursor_Frequency
            // 
            this.lblCursor_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Frequency.Location = new System.Drawing.Point(44, 0);
            this.lblCursor_Frequency.Margin = new System.Windows.Forms.Padding(0);
            this.lblCursor_Frequency.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_Frequency.Name = "lblCursor_Frequency";
            this.lblCursor_Frequency.Size = new System.Drawing.Size(116, 15);
            this.lblCursor_Frequency.TabIndex = 10;
            this.lblCursor_Frequency.Text = "F: 00.00 Hz";
            // 
            // frmThdFrequency
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 765);
            this.Controls.Add(this.scThdVsFreq);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1100, 765);
            this.Name = "frmThdFrequency";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
            ((System.ComponentModel.ISupportInitialize)(this.scGraphCursors)).EndInit();
            this.scGraphCursors.ResumeLayout(false);
            this.scGraphSettings.Panel1.ResumeLayout(false);
            this.scGraphSettings.Panel2.ResumeLayout(false);
            this.scGraphSettings.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphSettings)).EndInit();
            this.scGraphSettings.ResumeLayout(false);
            this.gbdB_Range.ResumeLayout(false);
            this.gbdB_Range.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ud_dB_Graph_Bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ud_dB_Graph_Top)).EndInit();
            this.gbHarmonics.ResumeLayout(false);
            this.gbHarmonics.PerformLayout();
            this.gbFrequencyRange.ResumeLayout(false);
            this.gbFrequencyRange.PerformLayout();
            this.gbD_Range.ResumeLayout(false);
            this.gbD_Range.PerformLayout();
            this.pnlCursorsRight.ResumeLayout(false);
            this.pnlCursorsLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scThdVsFreq;
        private System.Windows.Forms.Button btnStopThdMeasurement;
        private ScottPlot.WinForms.FormsPlot graphFft;
        private System.Windows.Forms.Button btnStartThdMeasurement;
        private ScottPlot.WinForms.FormsPlot graphTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbAmplifierOutputVoltageUnit;
        private System.Windows.Forms.Label lblAmplifierOutputVoltage;
        private System.Windows.Forms.TextBox txtAmplifierOutputVoltage;
        private System.Windows.Forms.NumericUpDown udAverages;
        private System.Windows.Forms.Label lblAverages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEndFrequency;
        private System.Windows.Forms.TextBox txtStartFrequency;
        private System.Windows.Forms.Label lblAmplifierOutputPowerUnit;
        private System.Windows.Forms.Label lblAmplifierOutputPower;
        private System.Windows.Forms.TextBox txtAmplifierOutputPower;
        private System.Windows.Forms.Label lblAmplifierLoadUnit;
        private System.Windows.Forms.Label lblOutputLoad;
        private System.Windows.Forms.TextBox txtOutputLoad;
        private System.Windows.Forms.ComboBox cmbGeneratorVoltageUnit;
        private System.Windows.Forms.Label lblGeneratorVoltage;
        private System.Windows.Forms.TextBox txtGeneratorVoltage;
        private System.Windows.Forms.Label lblGeneratorType;
        private System.Windows.Forms.ComboBox cmbGeneratorType;
        private System.Windows.Forms.NumericUpDown udStepsOctave;
        private System.Windows.Forms.Label lblStepsPerOctave;
        private System.Windows.Forms.Label lblThdFreq_EndFrequency;
        private System.Windows.Forms.Label lblStartFrequency;
        private System.Windows.Forms.SplitContainer scGraphCursors;
        private System.Windows.Forms.SplitContainer scGraphSettings;
        private ScottPlot.WinForms.FormsPlot thdPlot;
        private System.Windows.Forms.CheckBox chkShowDataPoints;
        private System.Windows.Forms.CheckBox chkThickLines;
        private System.Windows.Forms.GroupBox gbdB_Range;
        private System.Windows.Forms.NumericUpDown ud_dB_Graph_Bottom;
        private System.Windows.Forms.NumericUpDown ud_dB_Graph_Top;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btndB_FitGraphY;
        private System.Windows.Forms.GroupBox gbHarmonics;
        private System.Windows.Forms.CheckBox chkShowMagnitude;
        private System.Windows.Forms.CheckBox chkShowNoiseFloor;
        private System.Windows.Forms.CheckBox chkShowD6;
        private System.Windows.Forms.CheckBox chkShowD5;
        private System.Windows.Forms.CheckBox chkShowD4;
        private System.Windows.Forms.CheckBox chkShowD3;
        private System.Windows.Forms.CheckBox chkShowD2;
        private System.Windows.Forms.CheckBox chkShowThd;
        private System.Windows.Forms.Button btnGraph_dB;
        private System.Windows.Forms.Button btnGraph_D_Percent;
        private System.Windows.Forms.GroupBox gbFrequencyRange;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbGraph_FreqEnd;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGraph_FreqStart;
        private System.Windows.Forms.Button btnFitGraphX;
        private System.Windows.Forms.GroupBox gbD_Range;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbD_Graph_Bottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbD_Graph_Top;
        private System.Windows.Forms.Button btnD_FitGraphY;
        private System.Windows.Forms.Label lblCursor_NoiseFloor_L;
        private System.Windows.Forms.Label lblCursor_Power_L;
        private System.Windows.Forms.Label lblCursor_D6_L;
        private System.Windows.Forms.Label lblCursor_D5_L;
        private System.Windows.Forms.Label lblCursor_D4_L;
        private System.Windows.Forms.Label lblCursor_D3_L;
        private System.Windows.Forms.Label lblCursor_D2_L;
        private System.Windows.Forms.Label lblCursor_THD_L;
        private System.Windows.Forms.Label lblCursor_Magnitude_L;
        private System.Windows.Forms.Label lblCursor_Frequency;
        private System.Windows.Forms.CheckBox chkEnableRightChannel;
        private System.Windows.Forms.CheckBox chkEnableLeftChannel;
        private System.Windows.Forms.CheckBox chkGraphShowRightChannel;
        private System.Windows.Forms.CheckBox chkGraphShowLeftChannel;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCursorMagnitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lblCursor_NoiseFloor_R;
        private System.Windows.Forms.Label lblCursor_Power_R;
        private System.Windows.Forms.Label lblCursor_D6_R;
        private System.Windows.Forms.Label lblCursor_D5_R;
        private System.Windows.Forms.Label lblCursor_D4_R;
        private System.Windows.Forms.Label lblCursor_D3_R;
        private System.Windows.Forms.Label lblCursor_D2_R;
        private System.Windows.Forms.Label lblCursor_THD_R;
        private System.Windows.Forms.Label lblCursor_Magnitude_R;
        private System.Windows.Forms.Panel pnlCursorsRight;
        private System.Windows.Forms.Panel pnlCursorsLeft;
    }
}