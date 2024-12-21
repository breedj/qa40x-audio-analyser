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
            this.chkShowMarkers = new System.Windows.Forms.CheckBox();
            this.chkThickLines = new System.Windows.Forms.CheckBox();
            this.gbdB_Range = new System.Windows.Forms.GroupBox();
            this.cmbdB_Graph_Bottom = new System.Windows.Forms.NumericUpDown();
            this.cmbdB_Graph_Top = new System.Windows.Forms.NumericUpDown();
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
            this.cmbGraph_To = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbGraph_From = new System.Windows.Forms.ComboBox();
            this.btnFitGraphX = new System.Windows.Forms.Button();
            this.gbD_Range = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbD_Graph_Bottom = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbD_Graph_Top = new System.Windows.Forms.ComboBox();
            this.btnD_FitGraphY = new System.Windows.Forms.Button();
            this.lblCuror_NoiseFloor = new System.Windows.Forms.Label();
            this.lblCuror_Power = new System.Windows.Forms.Label();
            this.lblCuror_D6 = new System.Windows.Forms.Label();
            this.lblCuror_D5 = new System.Windows.Forms.Label();
            this.lblCuror_D4 = new System.Windows.Forms.Label();
            this.lblCuror_D3 = new System.Windows.Forms.Label();
            this.lblCuror_D2 = new System.Windows.Forms.Label();
            this.lblCuror_THD = new System.Windows.Forms.Label();
            this.lblCursor_Magnitude = new System.Windows.Forms.Label();
            this.lblCuror_Frequency = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.cmbdB_Graph_Bottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdB_Graph_Top)).BeginInit();
            this.gbHarmonics.SuspendLayout();
            this.gbFrequencyRange.SuspendLayout();
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
            this.btnStopThdMeasurement.Click += new System.EventHandler(this.btnStopMeasurement_Click);
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
            this.btnStartThdMeasurement.Click += new System.EventHandler(this.btnStartMeasurement_Click);
            // 
            // graphTime
            // 
            this.graphTime.DisplayScale = 0F;
            this.graphTime.Location = new System.Drawing.Point(3, 539);
            this.graphTime.Name = "graphTime";
            this.graphTime.Size = new System.Drawing.Size(254, 183);
            this.graphTime.TabIndex = 3;
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(254, 293);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Measurement Settings";
            // 
            // cmbAmplifierOutputVoltageUnit
            // 
            this.cmbAmplifierOutputVoltageUnit.DisplayMember = "1";
            this.cmbAmplifierOutputVoltageUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmplifierOutputVoltageUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAmplifierOutputVoltageUnit.FormattingEnabled = true;
            this.cmbAmplifierOutputVoltageUnit.Items.AddRange(new object[] {
            "mV",
            "V",
            "dBV"});
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
            this.udAverages.Location = new System.Drawing.Point(128, 259);
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
            this.lblAverages.Location = new System.Drawing.Point(13, 261);
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
            this.label3.Location = new System.Drawing.Point(193, 208);
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
            this.label2.Location = new System.Drawing.Point(193, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Hz";
            // 
            // txtEndFrequency
            // 
            this.txtEndFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEndFrequency.Location = new System.Drawing.Point(128, 205);
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
            this.txtStartFrequency.Location = new System.Drawing.Point(128, 179);
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
            this.cmbGeneratorVoltageUnit.Items.AddRange(new object[] {
            "mV",
            "V",
            "dBV"});
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
            this.lblGeneratorType.Size = new System.Drawing.Size(73, 13);
            this.lblGeneratorType.TabIndex = 9;
            this.lblGeneratorType.Text = "Set Generator";
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
            this.udStepsOctave.Location = new System.Drawing.Point(128, 232);
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
            this.lblStepsPerOctave.Location = new System.Drawing.Point(13, 234);
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
            this.lblThdFreq_EndFrequency.Location = new System.Drawing.Point(13, 208);
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
            this.lblStartFrequency.Location = new System.Drawing.Point(13, 182);
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
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_NoiseFloor);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_Power);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_D6);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_D5);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_D4);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_D3);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_D2);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_THD);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCursor_Magnitude);
            this.scGraphCursors.Panel2.Controls.Add(this.lblCuror_Frequency);
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
            this.scGraphSettings.Panel2.Controls.Add(this.chkShowMarkers);
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
            // chkShowMarkers
            // 
            this.chkShowMarkers.AutoSize = true;
            this.chkShowMarkers.Location = new System.Drawing.Point(12, 596);
            this.chkShowMarkers.Name = "chkShowMarkers";
            this.chkShowMarkers.Size = new System.Drawing.Size(108, 17);
            this.chkShowMarkers.TabIndex = 45;
            this.chkShowMarkers.Text = "Show data points";
            this.chkShowMarkers.UseVisualStyleBackColor = true;
            this.chkShowMarkers.CheckedChanged += new System.EventHandler(this.chkShowThd_CheckedChanged);
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
            // gbdB_Range
            // 
            this.gbdB_Range.Controls.Add(this.cmbdB_Graph_Bottom);
            this.gbdB_Range.Controls.Add(this.cmbdB_Graph_Top);
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
            // cmbdB_Graph_Bottom
            // 
            this.cmbdB_Graph_Bottom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdB_Graph_Bottom.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbdB_Graph_Bottom.Location = new System.Drawing.Point(8, 77);
            this.cmbdB_Graph_Bottom.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cmbdB_Graph_Bottom.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.cmbdB_Graph_Bottom.Name = "cmbdB_Graph_Bottom";
            this.cmbdB_Graph_Bottom.Size = new System.Drawing.Size(94, 20);
            this.cmbdB_Graph_Bottom.TabIndex = 31;
            this.cmbdB_Graph_Bottom.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cmbdB_Graph_Bottom.ValueChanged += new System.EventHandler(this.cmb_dBV_Graph_Top_ValueChanged);
            // 
            // cmbdB_Graph_Top
            // 
            this.cmbdB_Graph_Top.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbdB_Graph_Top.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.cmbdB_Graph_Top.Location = new System.Drawing.Point(8, 36);
            this.cmbdB_Graph_Top.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.cmbdB_Graph_Top.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.cmbdB_Graph_Top.Name = "cmbdB_Graph_Top";
            this.cmbdB_Graph_Top.Size = new System.Drawing.Size(94, 20);
            this.cmbdB_Graph_Top.TabIndex = 30;
            this.cmbdB_Graph_Top.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.cmbdB_Graph_Top.ValueChanged += new System.EventHandler(this.cmb_dBV_Graph_Top_ValueChanged);
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
            // btnGraph_dB
            // 
            this.btnGraph_dB.BackColor = System.Drawing.Color.Cornsilk;
            this.btnGraph_dB.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnGraph_dB.FlatAppearance.BorderSize = 2;
            this.btnGraph_dB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph_dB.Location = new System.Drawing.Point(9, 626);
            this.btnGraph_dB.Name = "btnGraph_dB";
            this.btnGraph_dB.Size = new System.Drawing.Size(52, 37);
            this.btnGraph_dB.TabIndex = 28;
            this.btnGraph_dB.Text = "D (dB)";
            this.btnGraph_dB.UseVisualStyleBackColor = false;
            this.btnGraph_dB.Click += new System.EventHandler(this.btnGraph_dBV_Click);
            // 
            // btnGraph_D_Percent
            // 
            this.btnGraph_D_Percent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGraph_D_Percent.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.btnGraph_D_Percent.FlatAppearance.BorderSize = 2;
            this.btnGraph_D_Percent.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGraph_D_Percent.Location = new System.Drawing.Point(67, 626);
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
            this.gbFrequencyRange.Controls.Add(this.cmbGraph_To);
            this.gbFrequencyRange.Controls.Add(this.label9);
            this.gbFrequencyRange.Controls.Add(this.cmbGraph_From);
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
            // cmbGraph_To
            // 
            this.cmbGraph_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraph_To.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGraph_To.FormattingEnabled = true;
            this.cmbGraph_To.Items.AddRange(new object[] {
            "1000",
            "2000",
            "5000",
            "10000",
            "20000",
            "50000",
            "100000"});
            this.cmbGraph_To.Location = new System.Drawing.Point(6, 82);
            this.cmbGraph_To.Name = "cmbGraph_To";
            this.cmbGraph_To.Size = new System.Drawing.Size(94, 21);
            this.cmbGraph_To.TabIndex = 33;
            this.cmbGraph_To.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_SelectedIndexChanged);
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
            // cmbGraph_From
            // 
            this.cmbGraph_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGraph_From.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGraph_From.FormattingEnabled = true;
            this.cmbGraph_From.Items.AddRange(new object[] {
            "5",
            "10",
            "20",
            "50",
            "100",
            "200",
            "500"});
            this.cmbGraph_From.Location = new System.Drawing.Point(6, 38);
            this.cmbGraph_From.Name = "cmbGraph_From";
            this.cmbGraph_From.Size = new System.Drawing.Size(94, 21);
            this.cmbGraph_From.TabIndex = 31;
            this.cmbGraph_From.SelectedIndexChanged += new System.EventHandler(this.cmbGraph_SelectedIndexChanged);
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
            // lblCuror_NoiseFloor
            // 
            this.lblCuror_NoiseFloor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_NoiseFloor.Location = new System.Drawing.Point(654, 29);
            this.lblCuror_NoiseFloor.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_NoiseFloor.Name = "lblCuror_NoiseFloor";
            this.lblCuror_NoiseFloor.Size = new System.Drawing.Size(178, 19);
            this.lblCuror_NoiseFloor.TabIndex = 20;
            this.lblCuror_NoiseFloor.Text = "Noise floor: 00.00 dB";
            // 
            // lblCuror_Power
            // 
            this.lblCuror_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_Power.Location = new System.Drawing.Point(341, 3);
            this.lblCuror_Power.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_Power.Name = "lblCuror_Power";
            this.lblCuror_Power.Size = new System.Drawing.Size(178, 15);
            this.lblCuror_Power.TabIndex = 19;
            this.lblCuror_Power.Text = "Power: 0 mW";
            this.lblCuror_Power.Click += new System.EventHandler(this.lblCuror_Power_Click);
            // 
            // lblCuror_D6
            // 
            this.lblCuror_D6.AutoSize = true;
            this.lblCuror_D6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_D6.Location = new System.Drawing.Point(525, 29);
            this.lblCuror_D6.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_D6.Name = "lblCuror_D6";
            this.lblCuror_D6.Size = new System.Drawing.Size(100, 15);
            this.lblCuror_D6.TabIndex = 17;
            this.lblCuror_D6.Text = "D6+: 00.00 %";
            // 
            // lblCuror_D5
            // 
            this.lblCuror_D5.AutoSize = true;
            this.lblCuror_D5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_D5.Location = new System.Drawing.Point(404, 29);
            this.lblCuror_D5.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_D5.Name = "lblCuror_D5";
            this.lblCuror_D5.Size = new System.Drawing.Size(100, 15);
            this.lblCuror_D5.TabIndex = 16;
            this.lblCuror_D5.Text = "D5: 00.00 %";
            // 
            // lblCuror_D4
            // 
            this.lblCuror_D4.AutoSize = true;
            this.lblCuror_D4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_D4.Location = new System.Drawing.Point(282, 29);
            this.lblCuror_D4.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_D4.Name = "lblCuror_D4";
            this.lblCuror_D4.Size = new System.Drawing.Size(100, 15);
            this.lblCuror_D4.TabIndex = 15;
            this.lblCuror_D4.Text = "D4: 00.00 %";
            // 
            // lblCuror_D3
            // 
            this.lblCuror_D3.AutoSize = true;
            this.lblCuror_D3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_D3.Location = new System.Drawing.Point(161, 29);
            this.lblCuror_D3.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_D3.Name = "lblCuror_D3";
            this.lblCuror_D3.Size = new System.Drawing.Size(100, 15);
            this.lblCuror_D3.TabIndex = 14;
            this.lblCuror_D3.Text = "D3: 00.00 %";
            // 
            // lblCuror_D2
            // 
            this.lblCuror_D2.AutoSize = true;
            this.lblCuror_D2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_D2.Location = new System.Drawing.Point(41, 29);
            this.lblCuror_D2.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_D2.Name = "lblCuror_D2";
            this.lblCuror_D2.Size = new System.Drawing.Size(100, 15);
            this.lblCuror_D2.TabIndex = 13;
            this.lblCuror_D2.Text = "D2: 00.00 %";
            // 
            // lblCuror_THD
            // 
            this.lblCuror_THD.AutoSize = true;
            this.lblCuror_THD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_THD.Location = new System.Drawing.Point(219, 3);
            this.lblCuror_THD.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_THD.Name = "lblCuror_THD";
            this.lblCuror_THD.Size = new System.Drawing.Size(100, 15);
            this.lblCuror_THD.TabIndex = 12;
            this.lblCuror_THD.Text = "THD: 0.00 %";
            // 
            // lblCursor_Magnitude
            // 
            this.lblCursor_Magnitude.AutoSize = true;
            this.lblCursor_Magnitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCursor_Magnitude.Location = new System.Drawing.Point(525, 3);
            this.lblCursor_Magnitude.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCursor_Magnitude.Name = "lblCursor_Magnitude";
            this.lblCursor_Magnitude.Size = new System.Drawing.Size(100, 15);
            this.lblCursor_Magnitude.TabIndex = 11;
            this.lblCursor_Magnitude.Text = "Magn: 0.00 dB";
            // 
            // lblCuror_Frequency
            // 
            this.lblCuror_Frequency.AutoSize = true;
            this.lblCuror_Frequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCuror_Frequency.Location = new System.Drawing.Point(41, 3);
            this.lblCuror_Frequency.MinimumSize = new System.Drawing.Size(100, 13);
            this.lblCuror_Frequency.Name = "lblCuror_Frequency";
            this.lblCuror_Frequency.Size = new System.Drawing.Size(138, 15);
            this.lblCuror_Frequency.TabIndex = 10;
            this.lblCuror_Frequency.Text = "Frequency: 00.00 Hz";
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
            this.scGraphCursors.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphCursors)).EndInit();
            this.scGraphCursors.ResumeLayout(false);
            this.scGraphSettings.Panel1.ResumeLayout(false);
            this.scGraphSettings.Panel2.ResumeLayout(false);
            this.scGraphSettings.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scGraphSettings)).EndInit();
            this.scGraphSettings.ResumeLayout(false);
            this.gbdB_Range.ResumeLayout(false);
            this.gbdB_Range.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdB_Graph_Bottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbdB_Graph_Top)).EndInit();
            this.gbHarmonics.ResumeLayout(false);
            this.gbHarmonics.PerformLayout();
            this.gbFrequencyRange.ResumeLayout(false);
            this.gbFrequencyRange.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkShowMarkers;
        private System.Windows.Forms.CheckBox chkThickLines;
        private System.Windows.Forms.GroupBox gbdB_Range;
        private System.Windows.Forms.NumericUpDown cmbdB_Graph_Bottom;
        private System.Windows.Forms.NumericUpDown cmbdB_Graph_Top;
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
        private System.Windows.Forms.ComboBox cmbGraph_To;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbGraph_From;
        private System.Windows.Forms.Button btnFitGraphX;
        private System.Windows.Forms.GroupBox gbD_Range;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbD_Graph_Bottom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbD_Graph_Top;
        private System.Windows.Forms.Button btnD_FitGraphY;
        private System.Windows.Forms.Label lblCuror_NoiseFloor;
        private System.Windows.Forms.Label lblCuror_Power;
        private System.Windows.Forms.Label lblCuror_D6;
        private System.Windows.Forms.Label lblCuror_D5;
        private System.Windows.Forms.Label lblCuror_D4;
        private System.Windows.Forms.Label lblCuror_D3;
        private System.Windows.Forms.Label lblCuror_D2;
        private System.Windows.Forms.Label lblCuror_THD;
        private System.Windows.Forms.Label lblCursor_Magnitude;
        private System.Windows.Forms.Label lblCuror_Frequency;
    }
}