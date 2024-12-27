using QA402_AUDIO_ANALYSER;
using QaControl;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SkiaSharp.HarfBuzz.SKShaper;


namespace QA40x_AUDIO_ANALYSER
{

    public partial class frmThdFrequency : Form
    {
        public ThdFrequencyData Data { get; set; }                  // Data used in this form instance
        public bool MeasurementBusy { get; set; }                   // Measurement busy state

        private ThdFrequencyMeasurementSettings MeasurementSettings;
        private ThdFrequencyGraphSettings GraphSettings;
        private ThdFrequencyMeasurementResult MeasurementResult;    

        CancellationTokenSource ct;                                 // Measurement cancelation token

        /// <summary>
        /// Constructor
        /// </summary>
        public frmThdFrequency(ref ThdFrequencyData data)
        {
            Data = data;
            MeasurementResult = new(); // TODO. Add to list

            ct = new CancellationTokenSource();

            InitializeComponent();
            PopulateMeasurementSettingsComboBoxes();
            PopulateGraphSettingsComboBoxes();

            MeasurementSettings = new();
            SetDefaultMeasurementSettings(ref MeasurementSettings);
            MeasurementResult.MeasurementSettings = MeasurementSettings;
            SetDefaultGraphSettings(ref GraphSettings);
            
            SetMeasurementControls(MeasurementSettings);
            SetGraphControls(GraphSettings);

            

            // Show empty graphs
            QaLibrary.InitMiniFftPlot(graphFft, MeasurementSettings.StartFrequency, MeasurementSettings.EndFrequency, -150, 20);
            QaLibrary.InitMiniTimePlot(graphTime, 0, 4, -1, 1);


            // TODO: depends on graph settings which graph is shown
            if (data.Measurements.Count > 0 && data.Measurements[0].FrequencySteps.Count > 0)
            {
                UpdateGraph(true);
            }

            Program.MainForm.ClearMessage();
            Program.MainForm.HideProgressBar();
            AttachPlotMouseEvent();
        }


        void PopulateMeasurementSettingsComboBoxes()
        {
            var items = new List<KeyValuePair<double, string>>
            {
                new (0, "Input voltage"),
                new (1, "Output voltage"),
                new (2, "Output power")
            };
            ComboBoxHelper.PopulateComboBox(cmbGeneratorType, items);

            items = new List<KeyValuePair<double, string>>
            {
                new (0, "mV"),
                new (1, "V"),
                new (2, "dBV")
            };
            ComboBoxHelper.PopulateComboBox(cmbGeneratorVoltageUnit, items);
            ComboBoxHelper.PopulateComboBox(cmbAmplifierOutputVoltageUnit, items);
        }

        void PopulateGraphSettingsComboBoxes()
        {
            var items = new List<KeyValuePair<double, string>>
            {
                new (100, "100"),
                new (10, "10"),
                new (1, "1")
            };
            ComboBoxHelper.PopulateComboBox(cmbD_Graph_Top, items);

            items = new List<KeyValuePair<double, string>>
            {
                new (0.1, "0.1"),
                new (0.01, "0.01"),
                new (0.001, "0.001"),
                new (0.0001, "0.0001"),
                new (0.00001, "0.00001"),
                new (0.000001, "0.000001")
            };
            ComboBoxHelper.PopulateComboBox(cmbD_Graph_Bottom, items);

            items = new List<KeyValuePair<double, string>>
            {
                new (5, "5"),
                new (10, "10"),
                new (20, "20"),
                new (50, "50"),
                new (200, "200"),
                new (500, "500")
            };
            ComboBoxHelper.PopulateComboBox(cmbGraph_FreqStart, items);

            items = new List<KeyValuePair<double, string>>
            {
                new (1000, "1000"),
                new (2000, "2000"),
                new (5000, "5000"),
                new (10000, "10000"),
                new (20000, "20000"),
                new (50000, "50000"),
                new (50000, "100000")
            };
            ComboBoxHelper.PopulateComboBox(cmbGraph_FreqEnd, items);
        }

        /// <summary>
        /// Initialize Settings with default settings
        /// </summary>
        void SetDefaultMeasurementSettings(ref ThdFrequencyMeasurementSettings settings)
        {
            // Initialize with default measurement settings
            settings.StartFrequency = 20;
            settings.EndFrequency = 20000;
            settings.SampleRate = 192000;
            settings.FftSize = 65536 * 2;
            settings.WindowingFunction = Windowing.Hann;
            settings.InputRange = 18;
            settings.GeneratorType = E_GeneratorType.INPUT_VOLTAGE;         
            settings.GeneratorAmplitude = -25;
            settings.GeneratorAmplitudeUnit = E_VoltageUnit.dBV;
            settings.StepsPerOctave = 2;
            settings.Averages = 1;
            settings.Load = 8;                      // Amplifier load (Ohm)
            settings.AmpOutputPower = 1;            // Output power (Watt)
            settings.AmpOutputAmplitude = 9.03;     
            settings.AmpOutputAmplitudeUnit = E_VoltageUnit.dBV;
            settings.EnableLeftChannel = true;
            settings.EnableRightChannel = true;
        }

        /// <summary>
        /// Initializer with default graph settings
        /// </summary>
        void SetDefaultGraphSettings(ref ThdFrequencyGraphSettings settings)
        {
            settings = new()
            {
                DbRangeTop = 10,
                DbRangeBottom = -150,
                D_PercentTop = 10,
                D_PercentBottom = 0.0001,

                FrequencyRange_Start = 20,
                FrequencyRange_End = 20000,

                GraphType = E_ThdFreq_GraphType.DB,
                ShowMagnitude = true,
                ShowTHD = true,
                ShowD2 = true,
                ShowD3 = true,
                ShowD4 = true,
                ShowD5 = true,
                ShowD6 = true,
                ShowNoiseFloor = true,

                ThickLines = true,
                ShowDataPoints = false,

                ShowLeftChannel = true,
                ShowRightChannel = true
            };
        }

        /// <summary>
        /// Set initial control values
        /// </summary>
        void SetMeasurementControls(ThdFrequencyMeasurementSettings settings)
        {
            cmbGeneratorType.SelectedIndex = (int)settings.GeneratorType;                     
            txtGeneratorVoltage.ReadOnly = settings.GeneratorType  != 0;
            txtGeneratorVoltage.Text = settings.GeneratorAmplitude.ToString("#0.0##");
            cmbGeneratorVoltageUnit.SelectedIndex = (int)settings.GeneratorAmplitudeUnit;
            txtAmplifierOutputVoltage.Text = settings.AmpOutputAmplitude.ToString("#0.0##");
            cmbAmplifierOutputVoltageUnit.SelectedIndex = (int)settings.AmpOutputAmplitudeUnit;
            txtOutputLoad.Text = settings.Load.ToString();
            txtAmplifierOutputPower.Text = settings.AmpOutputPower.ToString();
            txtStartFrequency.Text = settings.StartFrequency.ToString();
            txtEndFrequency.Text = settings.EndFrequency.ToString();
            udStepsOctave.Value = settings.StepsPerOctave;
            udAverages.Value = settings.Averages;

            chkEnableLeftChannel.Checked = settings.EnableLeftChannel;
            chkEnableRightChannel.Checked = settings.EnableRightChannel;  
        }

        //private ThdFrequencyMeasurementSettings GetMeasurementSettings()
        //{
        //    ThdFrequencyMeasurementSettings settings = new()
        //    {
        //        GeneratorType = cmbGeneratorType.SelectedIndex,
        //        GeneratorAmplitude = QaLibrary.ParseTextToDouble(txtGeneratorVoltage.Text, -40),
        //        GeneratorAmplitudeUnit = (E_VoltageUnit)cmbGeneratorVoltageUnit.SelectedIndex,
        //        AmpOutputAmplitude = QaLibrary.ParseTextToDouble(txtAmplifierOutputVoltage.Text, 0),
        //        AmpOutputAmplitudeUnit = (E_VoltageUnit)cmbAmplifierOutputVoltageUnit.SelectedIndex,
        //        Load = QaLibrary.ParseTextToDouble(txtOutputLoad.Text, 8),
        //        AmpOutputPower = QaLibrary.ParseTextToDouble(txtAmplifierOutputPower.Text, 1),
        //        StartFrequency = QaLibrary.ParseTextToUint(txtStartFrequency.Text, 20),
        //        EndFrequency = QaLibrary.ParseTextToUint(txtEndFrequency.Text, 20000),
        //        StepsPerOctave = (uint)udStepsOctave.Value,
        //        Averages = (uint)udAverages.Value,

        //        EnableLeftChannel = chkEnableLeftChannel.Checked,
        //        EnableRightChannel = chkEnableRightChannel.Checked
        //    };
        //    return settings;
        //}

        void SetGraphControls(ThdFrequencyGraphSettings graphSettings)
        {
            // Align controls
            gbdB_Range.Left = gbD_Range.Left;
            gbdB_Range.Top = gbD_Range.Top;
            // Set correct groupbox visibility
            gbdB_Range.Visible = graphSettings.GraphType == E_ThdFreq_GraphType.DB;
            gbD_Range.Visible = graphSettings.GraphType == E_ThdFreq_GraphType.D_PERCENT;

            ComboBoxHelper.SelectNearestValue(cmbD_Graph_Top, graphSettings.D_PercentTop);
            ComboBoxHelper.SelectNearestValue(cmbD_Graph_Bottom, graphSettings.D_PercentBottom);
            ud_dB_Graph_Top.Value = (decimal)graphSettings.DbRangeTop;
            ud_dB_Graph_Bottom.Value = (decimal)graphSettings.DbRangeBottom;
            SetStartFrequencySelectedIndexByFrequency(graphSettings.FrequencyRange_Start);
            SetEndFrequencySelectedIndexByFrequency(graphSettings.FrequencyRange_End);

            chkShowMagnitude.Checked = graphSettings.ShowMagnitude;
            chkShowThd.Checked = graphSettings.ShowTHD;
            chkShowD2.Checked = graphSettings.ShowD2;
            chkShowD3.Checked = graphSettings.ShowD3;
            chkShowD4.Checked = graphSettings.ShowD4;
            chkShowD5.Checked = graphSettings.ShowD5;
            chkShowD6.Checked = graphSettings.ShowD6;
            chkShowNoiseFloor.Checked = graphSettings.ShowNoiseFloor;

            chkThickLines.Checked = graphSettings.ThickLines;
            chkShowDataPoints.Checked = graphSettings.ShowDataPoints;

            chkGraphShowLeftChannel.Checked = graphSettings.ShowLeftChannel;
            chkGraphShowLeftChannel.Visible = chkEnableLeftChannel.Checked;
            chkGraphShowRightChannel.Checked = graphSettings.ShowRightChannel;
            chkGraphShowRightChannel.Visible = chkEnableRightChannel.Checked;
        }

        //private ThdFrequencyGraphSettings GetGraphSettings()
        //{
        //    ThdFrequencyGraphSettings settings = new();
            
        //    if (cmbD_Graph_Top.SelectedIndex != -1)
        //        settings.D_PercentTop = (double)((KeyValuePair<double, string>)cmbD_Graph_Top.SelectedItem).Key;
        //    if (cmbD_Graph_Bottom.SelectedIndex != -1)
        //        settings.D_PercentBottom = (double)((KeyValuePair<double, string>)cmbD_Graph_Bottom.SelectedItem).Key;

        //    settings.DbRangeTop = (double)ud_dB_Graph_Top.Value;
        //    settings.DbRangeBottom = (double)ud_dB_Graph_Bottom.Value;
        //    if (cmbGraph_FreqStart.SelectedIndex != -1)
        //        settings.FrequencyRange_Start = (uint)((KeyValuePair<double, string>)cmbGraph_FreqStart.SelectedItem).Key;
        //    if (cmbGraph_FreqEnd.SelectedIndex != -1)
        //        settings.FrequencyRange_End = (uint)((KeyValuePair<double, string>)cmbGraph_FreqEnd.SelectedItem).Key;

        //    settings.ShowMagnitude = chkShowMagnitude.Checked;
        //    settings.ShowTHD = chkShowThd.Checked;
        //    settings.ShowD2 = chkShowD2.Checked;
        //    settings.ShowD3 = chkShowD3.Checked;
        //    settings.ShowD4 = chkShowD4.Checked;
        //    settings.ShowD5 = chkShowD5.Checked;
        //    settings.ShowD6 = chkShowD6.Checked;
        //    settings.ShowNoiseFloor = chkShowNoiseFloor.Checked;

        //    settings.ThickLines = chkThickLines.Checked;
        //    settings.ShowDataPoints = chkShowDataPoints.Checked;
        //    settings.ShowLeftChannel = chkGraphShowLeftChannel.Checked;
        //    settings.ShowRightChannel = chkGraphShowRightChannel.Checked;

        //    return settings;
        //}

        /// <summary>
        /// Update the generator voltage in the textbox based on the selected unit.
        /// If the unit changes then the voltage will be converted
        /// </summary>
        void UpdateGeneratorVoltageDisplay()
        { 
            switch (cmbGeneratorVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtGeneratorVoltage.Text = ((int)QaLibrary.ConvertVoltage(MeasurementSettings.GeneratorAmplitude, MeasurementSettings.GeneratorAmplitudeUnit, E_VoltageUnit.MilliVolt)).ToString("###0"); // Whole numbers onyl, so cast to integer
                    break;
                case 1: // V
                    txtGeneratorVoltage.Text = QaLibrary.ConvertVoltage(MeasurementSettings.GeneratorAmplitude, MeasurementSettings.GeneratorAmplitudeUnit, E_VoltageUnit.Volt).ToString("#0.0##");
                    break;
                case 2: // dB
                    txtGeneratorVoltage.Text = QaLibrary.ConvertVoltage(MeasurementSettings.GeneratorAmplitude, MeasurementSettings.GeneratorAmplitudeUnit, E_VoltageUnit.dBV).ToString("#0.0#");
                    break;
            }
        }

        /// <summary>
        /// Update the amplifier output voltage in the textbox based on the selected unit.
        /// If the unit changes then the voltage will be converted
        /// </summary>
        void UpdateAmpOutputVoltageDisplay()
        {
           switch (cmbAmplifierOutputVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtAmplifierOutputVoltage.Text = ((int)QaLibrary.ConvertVoltage(MeasurementSettings.AmpOutputAmplitude, MeasurementSettings.AmpOutputAmplitudeUnit, E_VoltageUnit.MilliVolt)).ToString("###0");
                    break;
                case 1: // V
                    txtAmplifierOutputVoltage.Text = QaLibrary.ConvertVoltage(MeasurementSettings.AmpOutputAmplitude, MeasurementSettings.AmpOutputAmplitudeUnit, E_VoltageUnit.Volt).ToString("#0.0##");
                    break;
                case 2: // dB
                    txtAmplifierOutputVoltage.Text = QaLibrary.ConvertVoltage(MeasurementSettings.AmpOutputAmplitude, MeasurementSettings.AmpOutputAmplitudeUnit, E_VoltageUnit.dBV).ToString("#0.0#");
                    break;
            }
        }

        /// <summary>
        /// Generator type changed
        /// </summary>
        void UpdateGeneratorParameters()
        {
            switch (cmbGeneratorType.SelectedIndex)
            {
                case 0: // Input voltage
                    txtGeneratorVoltage.ReadOnly = false;
                    txtAmplifierOutputPower.ReadOnly = true;
                    txtAmplifierOutputVoltage.ReadOnly = true;
                    UpdateGeneratorVoltageDisplay();
                    break;
                case 1: // Output voltage
                    txtGeneratorVoltage.ReadOnly = true;
                    txtAmplifierOutputPower.ReadOnly = true;
                    txtAmplifierOutputVoltage.ReadOnly = false;
                    UpdateGeneratorVoltageDisplay();
                    break;
                case 2: // Output power
                    txtGeneratorVoltage.ReadOnly = true;
                    txtAmplifierOutputPower.ReadOnly = false;
                    txtAmplifierOutputVoltage.ReadOnly = true;

                    MeasurementSettings.AmpOutputPower = QaLibrary.ParseTextToDouble(txtAmplifierOutputPower.Text, MeasurementSettings.AmpOutputPower);
                    MeasurementSettings.Load = QaLibrary.ParseTextToDouble(txtOutputLoad.Text, MeasurementSettings.Load);
                    MeasurementSettings.AmpOutputAmplitude = Math.Sqrt(MeasurementSettings.AmpOutputPower * MeasurementSettings.Load);      // Expected output DUT amplitude in Volts
                    MeasurementSettings.AmpOutputAmplitudeUnit = E_VoltageUnit.Volt;                                           // Expected output DUT amplitude in dBV
                    UpdateAmpOutputVoltageDisplay();
                    break;
            }
        }


        /// <summary>
        /// Perform the measurement
        /// </summary>
        /// <param name="ct">Cancellation token</param>
        /// <returns>result. false if cancelled</returns>
        async Task<bool> PerformMeasurementSteps(CancellationToken ct)
        {
            //ClearPlot();
            ClearCursorTexts();
                        
            var _measurementSettings = MeasurementSettings.Copy();             // Create snapshot so it is not changed during measuring

            // Clear measurement result
            MeasurementResult = new();
            MeasurementResult.CreateDate = DateTime.Now;
            MeasurementResult.Show = true;                                      // Show in graph
            MeasurementResult.MeasurementSettings = _measurementSettings;       // Copy measurment settings to measurement results

            // For now clear measurements to allow only one until we have a UI to manage them.
            Data.Measurements.Clear();

            // Add to list
            Data.Measurements.Add(MeasurementResult);

            UpdateGraphChannelSelectors();

            markerIndex = -1;       // Reset marker

            // Init mini plots
            QaLibrary.InitMiniFftPlot(graphFft, _measurementSettings.StartFrequency, _measurementSettings.EndFrequency, -150, 20);
            QaLibrary.InitMiniTimePlot(graphTime, 0, 4, -1, 1);

            // Check if webserver available and device connected
            if (await QaLibrary.CheckDeviceConnected() == false)
                return false;
           
            // ********************************************************************
            // Check connection
            // Load a settings file with the particulars we want
            await Qa40x.SetDefaults();
            await Qa40x.SetOutputSource(OutputSources.Off);            // We need to call this to make it turn on or off
            await Qa40x.SetSampleRate(_measurementSettings.SampleRate);
            await Qa40x.SetBufferSize(_measurementSettings.FftSize);
            await Qa40x.SetWindowing(_measurementSettings.WindowingFunction);
            await Qa40x.SetRoundFrequencies(true);

            try
            {
                // ********************************************************************
                // Determine input level
                // ********************************************************************
                double testFrequency = QaLibrary.GetNearestBinFrequency(1000, _measurementSettings.SampleRate, _measurementSettings.FftSize);
                if (_measurementSettings.GeneratorType == E_GeneratorType.OUTPUT_VOLTAGE || _measurementSettings.GeneratorType == E_GeneratorType.OUTPUT_POWER)     // Based on output
                {
                    double amplifierOutputVoltagedBV = QaLibrary.ConvertVoltage(_measurementSettings.AmpOutputAmplitude, _measurementSettings.AmpOutputAmplitudeUnit, E_VoltageUnit.dBV);
                    if (cmbGeneratorType.SelectedIndex == 1)
                        await Program.MainForm.ShowMessage($"Determining generator amplitude to get an output amplitude of {amplifierOutputVoltagedBV:0.00#} dBV.");
                    else
                        await Program.MainForm.ShowMessage($"Determining generator amplitude to get an output power of {_measurementSettings.AmpOutputPower:0.00#} W.");

                    // Get input voltage based on desired output voltage
                    _measurementSettings.InputRange = QaLibrary.DetermineAttenuation(amplifierOutputVoltagedBV);
                    double startAmplitude = -40;  // We start a measurement with a 10 mV signal.
                    var result = await QaLibrary.DetermineGenAmplitudeByOutputAmplitude(testFrequency, startAmplitude, amplifierOutputVoltagedBV, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel, ct);
                    if (ct.IsCancellationRequested)
                        return false;
                    _measurementSettings.GeneratorAmplitude = result.Item1;
                    _measurementSettings.GeneratorAmplitudeUnit = E_VoltageUnit.dBV;
                    QaLibrary.PlotMiniFftGraph(graphFft, result.Item2.FreqInput, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);                                             // Plot fft data in mini graph
                    QaLibrary.PlotMiniTimeGraph(graphTime, result.Item2.TimeInput, testFrequency, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);                                      // Plot time data in mini graph
                    if (_measurementSettings.GeneratorAmplitude == -150)
                    {
                        await Program.MainForm.ShowMessage($"Could not determine a valid generator amplitude. The amplitude would be {_measurementSettings.GeneratorAmplitude:0.00#} dBV.");
                        return false;
                    }

                    // Check if cancel button pressed
                    if (ct.IsCancellationRequested)
                        return false;

                    // Check if amplitude found within the generator range
                    if (_measurementSettings.GeneratorAmplitude < 18)
                    {
                        await Program.MainForm.ShowMessage($"Found an input amplitude of {_measurementSettings.GeneratorAmplitude:0.00#} dBV. Doing second pass.");

                        // 2nd time for extra accuracy
                        result = await QaLibrary.DetermineGenAmplitudeByOutputAmplitude(testFrequency, _measurementSettings.GeneratorAmplitude, amplifierOutputVoltagedBV, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel, ct);
                        if (ct.IsCancellationRequested)
                            return false;
                        _measurementSettings.GeneratorAmplitude = result.Item1;
                        QaLibrary.PlotMiniFftGraph(graphFft, result.Item2.FreqInput, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);                                             // Plot fft data in mini graph
                        QaLibrary.PlotMiniTimeGraph(graphTime, result.Item2.TimeInput, testFrequency, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);                                      // Plot time data in mini graph
                        if (_measurementSettings.GeneratorAmplitude == -150)
                        {
                            await Program.MainForm.ShowMessage($"Could not determine a valid generator amplitude. The amplitude would be {_measurementSettings.GeneratorAmplitude:0.00#} dBV.");
                            return false;
                        }
                    }

                    UpdateGeneratorVoltageDisplay();

                    await Program.MainForm.ShowMessage($"Found an input amplitude of {_measurementSettings.GeneratorAmplitude:0.00#} dBV.");
                }
                else if (_measurementSettings.GeneratorType == E_GeneratorType.INPUT_VOLTAGE)                         // Based on input voltage
                {
                    double genVoltagedBV = QaLibrary.ConvertVoltage(_measurementSettings.GeneratorAmplitude, _measurementSettings.GeneratorAmplitudeUnit, E_VoltageUnit.dBV);
                    await Program.MainForm.ShowMessage($"Determining the best input attenuation for a generator voltage of {genVoltagedBV:0.00#} dBV.");

                    // Determine correct input attenuation
                    var result = await QaLibrary.DetermineAttenuationForGeneratorVoltage(genVoltagedBV, testFrequency, QaLibrary.MAXIMUM_DEVICE_ATTENUATION, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel, ct);
                    if (ct.IsCancellationRequested)
                        return false;
                    _measurementSettings.InputRange = result.Item1;
                    QaLibrary.PlotMiniFftGraph(graphFft, result.Item3.FreqInput, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel);
                    QaLibrary.PlotMiniTimeGraph(graphTime, result.Item3.TimeInput, testFrequency, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);

                    await Program.MainForm.ShowMessage($"Found correct input attenuation of {_measurementSettings.InputRange:0} dBV for an amplfier amplitude of {result.Item2:0.00#} dBV.", 500);
                }

                // Set the new input range
                await Qa40x.SetInputRange(_measurementSettings.InputRange);

                // Check if cancel button pressed
                if (ct.IsCancellationRequested)
                    return false;

                // ********************************************************************
                // Calculate frequency steps to do
                // ********************************************************************
                var binSize = QaLibrary.CalcBinSize(_measurementSettings.SampleRate, _measurementSettings.FftSize);
                // Generate a list of frequencies
                var stepFrequencies = QaLibrary.GetLineairSpacedLogarithmicValuesPerOctave(_measurementSettings.StartFrequency, _measurementSettings.EndFrequency, _measurementSettings.StepsPerOctave);
                // Translate the generated list to bin center frequncies
                var stepBins = QaLibrary.TranslateToBinFrequencies(stepFrequencies, _measurementSettings.SampleRate, _measurementSettings.FftSize);

                // ********************************************************************
                // Do noise floor measurement
                // ********************************************************************
                await Program.MainForm.ShowMessage($"Determining noise floor.");
                await Qa40x.SetOutputSource(OutputSources.Off);
                await Qa40x.DoAcquisition();
                MeasurementResult.NoiseFloor = await QaLibrary.DoAcquisitions(_measurementSettings.Averages, ct);
                if (ct.IsCancellationRequested)
                    return false;

                Program.MainForm.SetupProgressBar(0, stepBins.Length);

                // ********************************************************************
                // Step through the list of frequencies
                // ********************************************************************
                for (int f = 0; f < stepBins.Length; f++)
                {
                    await Program.MainForm.ShowMessage($"Measuring step {f + 1} of {stepBins.Length}.");
                    Program.MainForm.UpdateProgressBar(f + 1);

                    // Set the generator
                    double amplitudeSetpointdBV = QaLibrary.ConvertVoltage(_measurementSettings.GeneratorAmplitude, _measurementSettings.GeneratorAmplitudeUnit, E_VoltageUnit.dBV);
                    await Qa40x.SetGen1(stepBins[f], amplitudeSetpointdBV, true);
                    if (f == 0)
                        await Qa40x.SetOutputSource(OutputSources.Sine);            // We need to call this to make the averages reset

                    LeftRightSeries lrfs = await QaLibrary.DoAcquisitions(_measurementSettings.Averages, ct);
                    if (ct.IsCancellationRequested)
                        return false;

                    ThdFrequencyStep step = new()
                    {
                        FundamentalFrequency = stepBins[f],
                        GeneratorVoltage = QaLibrary.ConvertVoltage(amplitudeSetpointdBV, E_VoltageUnit.dBV, E_VoltageUnit.Volt),
                        fftData = lrfs.FreqInput,
                        timeData = lrfs.TimeInput
                    };

                    uint fundamentalBin = QaLibrary.GetBinOfFrequency(step.FundamentalFrequency, binSize);
                    if (fundamentalBin >= lrfs.FreqInput.Left.Length)               // Check in bin within range
                        break;

                    // Plot the mini graphs
                    QaLibrary.PlotMiniFftGraph(graphFft, lrfs.FreqInput, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);
                    QaLibrary.PlotMiniTimeGraph(graphTime, lrfs.TimeInput, step.FundamentalFrequency, _measurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, _measurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);

                    step.Left = ChannelCalculations(binSize, step.FundamentalFrequency, amplitudeSetpointdBV, lrfs.FreqInput.Left, MeasurementResult.NoiseFloor.FreqInput.Left, _measurementSettings.Load);
                    step.Right = ChannelCalculations(binSize, step.FundamentalFrequency, amplitudeSetpointdBV, lrfs.FreqInput.Right, MeasurementResult.NoiseFloor.FreqInput.Right, _measurementSettings.Load);

                    // Add step data to list
                    MeasurementResult.FrequencySteps.Add(step);

                    UpdateGraph(false);
                    ShowLastMeasurementCursorTexts();

                    // Check if cancel button pressed
                    if (ct.IsCancellationRequested)
                    {
                        await Qa40x.SetOutputSource(OutputSources.Off);                                             // Be sure to switch gen off
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occured", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Turn the generator off
            await Qa40x.SetOutputSource(OutputSources.Off);

            // Show message
            await Program.MainForm.ShowMessage($"Measurment finished!", 500);

            return true;
        }

        /// <summary>
        /// Perform the calculations of a single channel (left or right)
        /// </summary>
        /// <param name="binSize"></param>
        /// <param name="fundamentalFrequency"></param>
        /// <param name="generatorAmplitudeDbv"></param>
        /// <param name="fftData"></param>
        /// <param name="noiseFloorFftData"></param>
        /// <returns></returns>
        private ThdFrequencyStepChannel ChannelCalculations(double binSize, double fundamentalFrequency, double generatorAmplitudeDbv, double[] fftData, double[] noiseFloorFftData, double load)
        {
            uint fundamentalBin = QaLibrary.GetBinOfFrequency(fundamentalFrequency, binSize);

            ThdFrequencyStepChannel channelData = new();
            channelData.Fundamental_V = fftData[fundamentalBin];
            channelData.Fundamental_dBV = 20 * Math.Log10(fftData[fundamentalBin]);
            channelData.Gain_dB = 20 * Math.Log10(channelData.Fundamental_V / Math.Pow(10, generatorAmplitudeDbv / 20));

            // Calculate average noise floor 
            channelData.Average_NoiseFloor_V = noiseFloorFftData               // Store noise floor in V
                .Select((v, i) => new { Index = i, Value = v })
                .Where(p => p.Index > fundamentalBin)                       // Only higher frequencies. We do not have fundamentals in lower frequencies
                .Select(v => v.Value)
                .Average();
            channelData.Average_NoiseFloor_dBV = 20 * Math.Log10(channelData.Average_NoiseFloor_V);         // Store noise floor in dBV

            // Reset harmonic distortion variables
            double distortionSqrtTotal = 0;
            double distiortionD6plus = 0;

            // Loop through harmonics up tot the 12th
            for (int h = 2; h <= 12; h++)                                   // For now up to 12 harmonics, start at 2nd
            {
                var harmonicFrequency = fundamentalFrequency * h;
                HarmonicData harmonic = new()
                {
                    HarmonicNr = h,
                    Frequency = harmonicFrequency
                };

                uint bin = QaLibrary.GetBinOfFrequency(harmonic.Frequency, binSize);        // Calculate bin of the harmonic frequency
                                                                                            // Check if bin exists
                if (bin < fftData.Length)
                {
                    harmonic.NoiseAmplitude_V = noiseFloorFftData[bin];
                    harmonic.Amplitude_V = fftData[bin];
                    harmonic.Amplitude_dBV = 20 * Math.Log10(fftData[bin]);
                    harmonic.Thd_Percent = (harmonic.Amplitude_V / channelData.Fundamental_V) * 100;
                    harmonic.Thd_dB = 20 * Math.Log10(harmonic.Thd_Percent / 100.0);

                    // The harmonics 6-12 will be added together and displayed as D6+
                    if (h >= 6)
                        distiortionD6plus += Math.Pow(harmonic.Amplitude_V, 2);          // Add to total distortion
                                                                                            // All harmonics together for THD
                    distortionSqrtTotal += Math.Pow(harmonic.Amplitude_V, 2);            // Add to total distortion
                }
                else
                    break;                                                                  // Invalid bin, skip harmonic

                channelData.Harmonics.Add(harmonic);
            }

            // Calculate THD
            if (distortionSqrtTotal != 0)
            {
                channelData.Thd_Percent = (Math.Sqrt(distortionSqrtTotal) / channelData.Fundamental_V) * 100;
                channelData.Thd_dB = 20 * Math.Log10(channelData.Thd_Percent / 100.0);
            }

            // Calculate D6+ (D6 - D12)
            if (distiortionD6plus != 0)
            {
                channelData.D6Plus_dBV = 20 * Math.Log10(Math.Sqrt(distiortionD6plus));
                channelData.ThdPercent_D6plus = Math.Sqrt(distiortionD6plus / Math.Pow(channelData.Fundamental_V, 2)) * 100;
                channelData.ThdDbD6plus = 20 * Math.Log10(channelData.ThdPercent_D6plus / 100.0);
            }

            // If load not zero then calculate load power
            if (load != 0)
                channelData.Power_Watt = Math.Pow(channelData.Fundamental_V, 2) / load;

         

            return channelData;
        }


    


        void ShowLastMeasurementCursorTexts()
        {
            if (MeasurementResult == null || MeasurementResult.FrequencySteps.Count == 0) 
                return;

            ThdFrequencyStep step = MeasurementResult.FrequencySteps.Last();

            if (GraphSettings.GraphType == E_ThdFreq_GraphType.DB)
            {
                // Plot current measurement texts
                WriteCursorTexts_dB_L(step.FundamentalFrequency
                    , step.Left.Gain_dB
                    , step.Left.Thd_dB - step.Left.Fundamental_dBV
                    , (step.Left.Harmonics.Count > 0 ? step.Left.Harmonics[0].Amplitude_dBV - step.Left.Fundamental_dBV : 0)   // 2nd harmonic
                    , (step.Left.Harmonics.Count > 1 ? step.Left.Harmonics[1].Amplitude_dBV - step.Left.Fundamental_dBV : 0)
                    , (step.Left.Harmonics.Count > 3 ? step.Left.Harmonics[2].Amplitude_dBV - step.Left.Fundamental_dBV : 0)
                    , (step.Left.Harmonics.Count > 4 ? step.Left.Harmonics[3].Amplitude_dBV - step.Left.Fundamental_dBV : 0)
                    , (step.Left.Harmonics.Count > 5 ? step.Left.D6Plus_dBV - step.Left.Fundamental_dBV : 0)                   // 6+ harmonics
                    , step.Left.Power_Watt
                    , step.Left.Average_NoiseFloor_dBV - step.Left.Fundamental_dBV
                    , MeasurementResult.MeasurementSettings.Load
                    );

                WriteCursorTexts_dB_R(step.FundamentalFrequency
                    , step.Right.Gain_dB
                    , step.Right.Thd_dB - step.Right.Fundamental_dBV
                    , (step.Right.Harmonics.Count > 0 ? step.Right.Harmonics[0].Amplitude_dBV - step.Right.Fundamental_dBV : 0)   // 2nd harmonic
                    , (step.Right.Harmonics.Count > 1 ? step.Right.Harmonics[1].Amplitude_dBV - step.Right.Fundamental_dBV : 0)
                    , (step.Right.Harmonics.Count > 3 ? step.Right.Harmonics[2].Amplitude_dBV - step.Right.Fundamental_dBV : 0)
                    , (step.Right.Harmonics.Count > 4 ? step.Right.Harmonics[3].Amplitude_dBV - step.Right.Fundamental_dBV : 0)
                    , (step.Right.Harmonics.Count > 5 ? step.Right.D6Plus_dBV - step.Right.Fundamental_dBV : 0)                   // 6+ harmonics
                    , step.Right.Power_Watt
                    , step.Right.Average_NoiseFloor_dBV - step.Right.Fundamental_dBV
                    , MeasurementResult.MeasurementSettings.Load
                    );
            }
            else
            {
                // Plot current measurement texts
                WriteCursorTexts_Dpercent_L(step.FundamentalFrequency
                    , step.Left.Gain_dB
                    , step.Left.Thd_Percent
                    , (step.Left.Harmonics.Count > 0 ? step.Left.Harmonics[0].Thd_Percent : 0)                         // 2nd harmonic
                    , (step.Left.Harmonics.Count > 1 ? step.Left.Harmonics[1].Thd_Percent : 0)
                    , (step.Left.Harmonics.Count > 3 ? step.Left.Harmonics[2].Thd_Percent : 0)
                    , (step.Left.Harmonics.Count > 4 ? step.Left.Harmonics[3].Thd_Percent : 0)
                    , (step.Left.Harmonics.Count > 5 ? step.Left.ThdPercent_D6plus : 0)                                // 6+ harmonics
                    , step.Left.Power_Watt
                    , (step.Left.Average_NoiseFloor_V / step.Left.Fundamental_V) * 100
                    , MeasurementResult.MeasurementSettings.Load
                    );

                WriteCursorTexts_Dpercent_R(step.FundamentalFrequency
                    , step.Right.Gain_dB
                    , step.Right.Thd_Percent
                    , (step.Right.Harmonics.Count > 0 ? step.Right.Harmonics[0].Thd_Percent : 0)                         // 2nd harmonic
                    , (step.Right.Harmonics.Count > 1 ? step.Right.Harmonics[1].Thd_Percent : 0)
                    , (step.Right.Harmonics.Count > 3 ? step.Right.Harmonics[2].Thd_Percent : 0)
                    , (step.Right.Harmonics.Count > 4 ? step.Right.Harmonics[3].Thd_Percent : 0)
                    , (step.Right.Harmonics.Count > 5 ? step.Right.ThdPercent_D6plus : 0)                                // 6+ harmonics
                    , step.Right.Power_Watt
                    , (step.Right.Average_NoiseFloor_V / step.Right.Fundamental_V) * 100
                    , MeasurementResult.MeasurementSettings.Load
                    );
            }
        }


        /// <summary>
        /// Write thd percent cursor values to labels
        /// </summary>
        /// <param name="f">Fundamental frequency</param>
        /// <param name="magnitude">Magnitude</param>
        /// <param name="thd">Total harmonic distortion</param>
        /// <param name="D2">Distortion of 2nd harmonic</param>
        /// <param name="D3">Distortion of 3rd harmonic</param>
        /// <param name="D4">Distortion of 4th harmonic</param>
        /// <param name="D5">Distortion of 5th harmonic</param>
        /// <param name="D6">Distortion of 6th harmonic</param>
        /// <param name="dc">The dc component</param>
        /// <param name="power">Amount of power in Watt</param>
        /// <param name="noiseFloor">The noise floor in dB</param>
        /// <param name="load">The amplifier load</param>
        void WriteCursorTexts_Dpercent_L(double f, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            lblCursor_Frequency.Text = $"F: {f:0.0 Hz}";
            lblCursor_Magnitude_L.Text = $"{magnitude:0.0# dB}";
            lblCursor_THD_L.Text = $"{thd:0.0000 \\%}";

            lblCursor_D2_L.Text = $"{D2:0.0000 \\%}";
            lblCursor_D3_L.Text = $"{D3:0.0000 \\%}";
            lblCursor_D4_L.Text = $"{D4:0.0000 \\%}";
            lblCursor_D5_L.Text = $"{D5:0.0000 \\%}";
            lblCursor_D6_L.Text = $"{D6:0.0000 \\%}";

            if (power < 1)
                lblCursor_Power_L.Text = $"{power * 1000:0 mW} ({load:0.##} Ω)";
            else
                lblCursor_Power_L.Text = $"{power:0.00# W} ({load:0.##} Ω)";

            lblCursor_NoiseFloor_L.Text = $"{noiseFloor:0.00000 \\%}";

            lblCursor_Frequency.Refresh();
            pnlCursorsLeft.Refresh();
        }

        void WriteCursorTexts_Dpercent_R(double f, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            lblCursor_Frequency.Text = $"F: {f:0.0 Hz}";
            lblCursor_Magnitude_R.Text = $"{magnitude:0.0# dB}";
            lblCursor_THD_R.Text = $"{thd:0.0000 \\%}";

            lblCursor_D2_R.Text = $"{D2:0.0000 \\%}";
            lblCursor_D3_R.Text = $"{D3:0.0000 \\%}";
            lblCursor_D4_R.Text = $"{D4:0.0000 \\%}";
            lblCursor_D5_R.Text = $"{D5:0.0000 \\%}";
            lblCursor_D6_R.Text = $"{D6:0.0000 \\%}";

            if (power < 1)
                lblCursor_Power_R.Text = $"{power * 1000:0 mW} ({load:0.##} Ω)";
            else
                lblCursor_Power_R.Text = $"{power:0.00# W} ({load:0.##} Ω)";

            lblCursor_NoiseFloor_R.Text = $"{noiseFloor:0.00000 \\%}";

            lblCursor_Frequency.Refresh();
            pnlCursorsRight.Refresh();
        }

        /// <summary>
        /// Write thd dB cursor values to labels
        /// </summary>
        /// <param name="f">Fundamental frequency</param>
        /// <param name="magnitude">Magnitude</param>
        /// <param name="thd">Total harmonic distortion</param>
        /// <param name="D2">Distortion of 2nd harmonic</param>
        /// <param name="D3">Distortion of 3rd harmonic</param>
        /// <param name="D4">Distortion of 4th harmonic</param>
        /// <param name="D5">Distortion of 5th harmonic</param>
        /// <param name="D6">Distortion of 6th harmonic</param>
        /// <param name="dc">The dc component</param>
        /// <param name="power">Amount of power in Watt</param>
        /// <param name="noiseFloor">The noise floor in dB</param>
        /// <param name="load">The amplifier load</param>
        void WriteCursorTexts_dB_L(double f, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            lblCursor_Frequency.Text = $"F: {f:0.0 Hz}";
            lblCursor_Magnitude_L.Text = $"{magnitude:0.0# dB}";
            lblCursor_THD_L.Text = $"{thd:0.0# dB}";

            lblCursor_D2_L.Text = $"{D2:0.0# dB}";
            lblCursor_D3_L.Text = $"{D3:0.0# dB}";
            lblCursor_D4_L.Text = $"{D4:0.0# dB}";
            lblCursor_D5_L.Text = $"{D5:0.0# dB}";
            lblCursor_D6_L.Text = $"{D6:0.0# dB}";

            if (power < 1)
                lblCursor_Power_L.Text = $"{power * 1000:0 mW} ({load:0.##} Ω)";
            else
                lblCursor_Power_L.Text = $"{power:0.00# W} ({load:0.##} Ω)";

            lblCursor_NoiseFloor_L.Text = $"{noiseFloor:0.0# dB}";

            lblCursor_Frequency.Refresh();
            pnlCursorsLeft.Refresh();
        }

        void WriteCursorTexts_dB_R(double f, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            lblCursor_Frequency.Text = $"F: {f:0.0 Hz}";
            lblCursor_Magnitude_R.Text = $"{magnitude:0.0# dB}";
            lblCursor_THD_R.Text = $"{thd:0.0# dB}";

            lblCursor_D2_R.Text = $"{D2:0.0# dB}";
            lblCursor_D3_R.Text = $"{D3:0.0# dB}";
            lblCursor_D4_R.Text = $"{D4:0.0# dB}";
            lblCursor_D5_R.Text = $"{D5:0.0# dB}";
            lblCursor_D6_R.Text = $"{D6:0.0# dB}";

            if (power < 1)
                lblCursor_Power_R.Text = $"{power * 1000:0 mW} ({load:0.##} Ω)";
            else
                lblCursor_Power_R.Text = $"{power:0.00# W} ({load:0.##} Ω)";

            lblCursor_NoiseFloor_R.Text = $"{noiseFloor:0.0# dB}";

            lblCursor_Frequency.Refresh();
            pnlCursorsRight.Refresh();
        }

        void ClearCursorTexts()
        {
            if (GraphSettings.GraphType == E_ThdFreq_GraphType.DB)
            {
                WriteCursorTexts_dB_L(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                WriteCursorTexts_dB_R(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                WriteCursorTexts_Dpercent_L(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                WriteCursorTexts_Dpercent_R(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
        }

             

        /// <summary>
        /// Clear the plot
        /// </summary>
        void ClearPlot()
        {
            thdPlot.Plot.Clear();
            thdPlot.Refresh();
        }

        /// <summary>
        /// Ititialize the THD % plot
        /// </summary>
        void InitializeThdPlot()
        {
            thdPlot.Plot.Clear();


            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGenY = new();
            minorTickGenY.Divisions = 10;

            // create a numeric tick generator that uses our custom minor tick generator
            ScottPlot.TickGenerators.NumericAutomatic tickGenY = new();
            tickGenY.MinorTickGenerator = minorTickGenY;

            // create a custom tick formatter to set the label text for each tick
            static string LogTickLabelFormatter(double y) => $"{Math.Pow(10, Math.Round(y, 10)):#0.######}";

            // tell our major tick generator to only show major ticks that are whole integers
            tickGenY.IntegerTicksOnly = true;

            // tell our custom tick generator to use our new label formatter
            tickGenY.LabelFormatter = LogTickLabelFormatter;

            // tell the left axis to use our custom tick generator
            thdPlot.Plot.Axes.Left.TickGenerator = tickGenY;

            // ******* y-ticks ****
            // create a minor tick generator that places log-distributed minor ticks
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGen = new();
            minorTickGen.Divisions = 10;




            // create a minor tick generator that places log-distributed minor ticks
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGenX = new();

            // create a numeric tick generator that uses our custom minor tick generator
            //ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();
            //tickGenX.MinorTickGenerator = minorTickGenX;

            // create a manual tick generator and add ticks
            ScottPlot.TickGenerators.NumericManual tickGenX = new();

            // add major ticks with their labels
            tickGenX.AddMajor(Math.Log10(1), "1");
            tickGenX.AddMajor(Math.Log10(2), "2");
            tickGenX.AddMajor(Math.Log10(5), "5");
            tickGenX.AddMajor(Math.Log10(10), "10");
            tickGenX.AddMajor(Math.Log10(20), "20");
            tickGenX.AddMajor(Math.Log10(50), "50");
            tickGenX.AddMajor(Math.Log10(100), "100");
            tickGenX.AddMajor(Math.Log10(200), "200");
            tickGenX.AddMajor(Math.Log10(500), "500");
            tickGenX.AddMajor(Math.Log10(1000), "1k");
            tickGenX.AddMajor(Math.Log10(2000), "2k");
            tickGenX.AddMajor(Math.Log10(5000), "5k");
            tickGenX.AddMajor(Math.Log10(10000), "10k");
            tickGenX.AddMajor(Math.Log10(20000), "20k");
            tickGenX.AddMajor(Math.Log10(50000), "50k");
            tickGenX.AddMajor(Math.Log10(100000), "100k");


            // tell our custom tick generator to use our new label formatter
            //    tickGenX.LabelFormatter = LogTickLabelFormatterX;
            thdPlot.Plot.Axes.Bottom.TickGenerator = tickGenX;


            // show grid lines for minor ticks
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.35);
            thdPlot.Plot.Grid.MajorLineWidth = 1;
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.15);
            thdPlot.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            if (cmbGraph_FreqStart.SelectedIndex > -1 && cmbGraph_FreqEnd.SelectedIndex > -1 && cmbD_Graph_Bottom.SelectedIndex > -1 && cmbD_Graph_Top.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbGraph_FreqStart.Text)), Math.Log10(Convert.ToDouble(cmbGraph_FreqEnd.Text)), Math.Log10(Convert.ToDouble(cmbD_Graph_Bottom.Text)) - 0.000001, Math.Log10(Convert.ToDouble(cmbD_Graph_Top.Text)));  // - 0.000001 to force showing label
            thdPlot.Plot.Title("Distortion (%)");
            thdPlot.Plot.Axes.Title.Label.FontSize = 17;

            thdPlot.Plot.XLabel("Frequency (Hz)");
            thdPlot.Plot.Axes.Bottom.Label.OffsetX = 330;
            thdPlot.Plot.Axes.Bottom.Label.FontSize = 15;
            thdPlot.Plot.Axes.Bottom.Label.Bold = false;


            thdPlot.Plot.Legend.IsVisible = true;
            thdPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
            thdPlot.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;
            thdPlot.Plot.ShowLegend();
            thdPlot.Refresh();
        }

        /// <summary>
        /// Plot the THD % graph
        /// </summary>
        /// <param name="data"></param>
        void PlotThd(ThdFrequencyMeasurementResult measurementResult, int measurementNr, bool showLeftChannel, bool showRightChannel)
        { 
            List<double> freqX = [];

            List<double> hTotY_left = [];
            List<double> h2Y_left = [];
            List<double> h3Y_left = [];
            List<double> h4Y_left = [];
            List<double> h5Y_left = [];
            List<double> h6Y_left = [];
            List<double> noiseY_left = [];

            List<double> hTotY_right = [];
            List<double> h2Y_right = [];
            List<double> h3Y_right = [];
            List<double> h4Y_right = [];
            List<double> h5Y_right = [];
            List<double> h6Y_right = [];
            List<double> noiseY_right = [];

            for (int f = 0; f < measurementResult.FrequencySteps.Count; f++)
            {
                freqX.Add(measurementResult.FrequencySteps[f].FundamentalFrequency);

                if (showLeftChannel && measurementResult.MeasurementSettings.EnableLeftChannel)
                {
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 0 && GraphSettings.ShowTHD)
                        hTotY_left.Add(measurementResult.FrequencySteps[f].Left.Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 0 && GraphSettings.ShowD2)
                        h2Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[0].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 1 && GraphSettings.ShowD3)
                        h3Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[1].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 2 && GraphSettings.ShowD4)
                        h4Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[2].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 3 && GraphSettings.ShowD5)
                        h5Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[3].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 4 && measurementResult.FrequencySteps[f].Left.Thd_Percent != 0 && GraphSettings.ShowD6)
                        h6Y_left.Add(measurementResult.FrequencySteps[f].Left.ThdPercent_D6plus);        // D6+
                    if (GraphSettings.ShowNoiseFloor)
                        noiseY_left.Add((measurementResult.FrequencySteps[f].Left.Average_NoiseFloor_V / measurementResult.FrequencySteps[f].Left.Fundamental_V) * 100);
                }

                if (showRightChannel && measurementResult.MeasurementSettings.EnableRightChannel)
                {
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 0 && GraphSettings.ShowTHD)
                        hTotY_right.Add(measurementResult.FrequencySteps[f].Right.Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 0 && GraphSettings.ShowD2)
                        h2Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[0].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 1 && GraphSettings.ShowD3)
                        h3Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[1].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 2 && GraphSettings.ShowD4)
                        h4Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[2].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 3 && GraphSettings.ShowD5)
                        h5Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[3].Thd_Percent);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 4 && measurementResult.FrequencySteps[f].Right.ThdPercent_D6plus != 0 && GraphSettings.ShowD6)
                        h6Y_right.Add(measurementResult.FrequencySteps[f].Right.ThdPercent_D6plus);        // D6+
                    if (GraphSettings.ShowNoiseFloor)
                        noiseY_right.Add((measurementResult.FrequencySteps[f].Right.Average_NoiseFloor_V / measurementResult.FrequencySteps[f].Right.Fundamental_V) * 100);
                }
            }

            GraphColors colors = new GraphColors();
            float lineWidth = 1;
            float markerSize = 1;
            if (chkThickLines.Checked)
                lineWidth = 1.5f;
            if (chkShowDataPoints.Checked)
                markerSize = lineWidth + 3;

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();
            int color = measurementNr * 2;              // Skip color each measurement for better visibility

            if (showLeftChannel)
            {
                if (GraphSettings.ShowTHD)
                {
                    double[] logHTotY = hTotY_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(8, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "THD-L" : "THD";
                }

                if (GraphSettings.ShowD2)
                {
                    double[] logH2Y = h2Y_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(0, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "D2-L" : "D2";
                }

                if (GraphSettings.ShowD3)
                {
                    double[] logH3Y = h3Y_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(1, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "D3-L" : "D3";
                }

                if (GraphSettings.ShowD4)
                {
                    double[] logH4Y = h4Y_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                    plot.Color = colors.GetColor(2, color);
                    plot.LineWidth = lineWidth;
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "D4-L" : "D4";
                }

                if (GraphSettings.ShowD5)
                {
                    double[] logH5Y = h5Y_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(3, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "D5-L" : "D5";
                }

                if (GraphSettings.ShowD6)
                {
                    double[] logH6Y = h6Y_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(4, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "D6+-L" : "D6+";
                }


                if (GraphSettings.ShowNoiseFloor)
                {
                    double[] logNoiseY = noiseY_left.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logNoiseY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(9, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "Noise-L" : "Noise";
                    plot.LinePattern = showRightChannel ? LinePattern.Solid : LinePattern.Dotted;
                }
            }

            if (showRightChannel)
            {
                if (GraphSettings.ShowTHD)
                {
                    double[] logHTotY = hTotY_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(8, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "THD-R" : "THD";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD2)
                {
                    double[] logH2Y = h2Y_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(0, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "D2-R" : "D2";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD3)
                {
                    double[] logH3Y = h3Y_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(1, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "D3-R" : "D3";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD4)
                {
                    double[] logH4Y = h4Y_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                    plot.Color = colors.GetColor(2, color);
                    plot.LineWidth = lineWidth;
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "D4-R" : "D4";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD5)
                {
                    double[] logH5Y = h5Y_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(3, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "D5-R" : "D5";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD5)
                {
                    double[] logH6Y = h6Y_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(4, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "D6+-R" : "D6+";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }


                if (GraphSettings.ShowNoiseFloor)
                {
                    double[] logNoiseY = noiseY_right.Select(Math.Log10).ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logNoiseY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(9, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "Noise-R" : "Noise";
                    plot.LinePattern = LinePattern.Dotted;
                }
            }


            if (markerIndex != -1)
                QaLibrary.PlotCursorMarker(thdPlot, 1, LinePattern.Solid, markerDataPoint);

            thdPlot.Refresh();
        }



        /// <summary>
        /// Initialize the magnitude plot
        /// </summary>
        void InitializeMagnitudePlot()
        {
            thdPlot.Plot.Clear();

            // create a minor tick generator that places log-distributed minor ticks
            //ScottPlot.TickGenerators. minorTickGen = new();
            //minorTickGen.Divisions = 1;

            // create a numeric tick generator that uses our custom minor tick generator
            ScottPlot.TickGenerators.EvenlySpacedMinorTickGenerator minorTickGen = new(1);

            ScottPlot.TickGenerators.NumericAutomatic tickGenY = new();
            tickGenY.TargetTickCount = 15;
            tickGenY.MinorTickGenerator = minorTickGen;

            // tell the left axis to use our custom tick generator
            thdPlot.Plot.Axes.Left.TickGenerator = tickGenY;

            // create a minor tick generator that places log-distributed minor ticks
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGenX = new();

            // create a numeric tick generator that uses our custom minor tick generator
            //ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();
            //tickGenX.MinorTickGenerator = minorTickGenX;

            // create a manual tick generator and add ticks
            ScottPlot.TickGenerators.NumericManual tickGenX = new();

            // add major ticks with their labels
            tickGenX.AddMajor(Math.Log10(1), "1");
            tickGenX.AddMajor(Math.Log10(2), "2");
            tickGenX.AddMajor(Math.Log10(5), "5");
            tickGenX.AddMajor(Math.Log10(10), "10");
            tickGenX.AddMajor(Math.Log10(20), "20");
            tickGenX.AddMajor(Math.Log10(50), "50");
            tickGenX.AddMajor(Math.Log10(100), "100");
            tickGenX.AddMajor(Math.Log10(200), "200");
            tickGenX.AddMajor(Math.Log10(500), "500");
            tickGenX.AddMajor(Math.Log10(1000), "1k");
            tickGenX.AddMajor(Math.Log10(2000), "2k");
            tickGenX.AddMajor(Math.Log10(5000), "5k");
            tickGenX.AddMajor(Math.Log10(10000), "10k");
            tickGenX.AddMajor(Math.Log10(20000), "20k");
            tickGenX.AddMajor(Math.Log10(50000), "50k");
            tickGenX.AddMajor(Math.Log10(100000), "100k");

            thdPlot.Plot.Axes.Bottom.TickGenerator = tickGenX;

            // show grid lines for major ticks
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.35);
            thdPlot.Plot.Grid.MajorLineWidth = 1;
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.15);
            thdPlot.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            if (cmbGraph_FreqStart.SelectedIndex > -1 && cmbGraph_FreqEnd.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbGraph_FreqStart.Text)), Math.Log10(Convert.ToDouble(cmbGraph_FreqEnd.Text)), Convert.ToDouble(ud_dB_Graph_Bottom.Value), Convert.ToDouble(ud_dB_Graph_Top.Value));
            thdPlot.Plot.Title("Magnitude (dB)");
            thdPlot.Plot.Axes.Title.Label.FontSize = 17;

            thdPlot.Plot.XLabel("Frequency (Hz)");
            thdPlot.Plot.Axes.Bottom.Label.OffsetX = 330;
            thdPlot.Plot.Axes.Bottom.Label.FontSize = 15;
            thdPlot.Plot.Axes.Bottom.Label.Bold = false;


            thdPlot.Plot.Legend.IsVisible = true;
            thdPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
            thdPlot.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;

            thdPlot.Refresh();
        }


        /// <summary>
        /// Plot the magnitude graph
        /// </summary>
        /// <param name="measurementResult">Data to plot</param>
        void PlotMagnitude(ThdFrequencyMeasurementResult measurementResult, int measurementNr, bool showLeftChannel, bool showRightChannel)
        {
            List<double> freqX = [];

            List<double> magnY_left = [];
            List<double> hTotY_left = [];
            List<double> h2Y_left = [];
            List<double> h3Y_left = [];
            List<double> h4Y_left = [];
            List<double> h5Y_left = [];
            List<double> h6Y_left = [];
            List<double> noiseY_left = [];

            List<double> magnY_right = [];
            List<double> hTotY_right = [];
            List<double> h2Y_right = [];
            List<double> h3Y_right = [];
            List<double> h4Y_right = [];
            List<double> h5Y_right = [];
            List<double> h6Y_right = [];
            List<double> noiseY_right = [];

            for (int f = 0; f < measurementResult.FrequencySteps.Count; f++)
            {
                freqX.Add(measurementResult.FrequencySteps[f].FundamentalFrequency);
                if (showLeftChannel && measurementResult.MeasurementSettings.EnableLeftChannel)
                {
                    if (GraphSettings.ShowMagnitude)
                        magnY_left.Add(measurementResult.FrequencySteps[f].Left.Gain_dB);

                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 0)
                    {
                        hTotY_left.Add(measurementResult.FrequencySteps[f].Left.Thd_dB + measurementResult.FrequencySteps[f].Left.Gain_dB);
                        h2Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[0].Amplitude_dBV - measurementResult.FrequencySteps[f].Left.Fundamental_dBV + measurementResult.FrequencySteps[f].Left.Gain_dB);
                    }
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 1)
                        h3Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[1].Amplitude_dBV - measurementResult.FrequencySteps[f].Left.Fundamental_dBV + measurementResult.FrequencySteps[f].Left.Gain_dB);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 2)
                        h4Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[2].Amplitude_dBV - measurementResult.FrequencySteps[f].Left.Fundamental_dBV + measurementResult.FrequencySteps[f].Left.Gain_dB);
                    if (measurementResult.FrequencySteps[f].Left.Harmonics.Count > 3)
                        h5Y_left.Add(measurementResult.FrequencySteps[f].Left.Harmonics[3].Amplitude_dBV - measurementResult.FrequencySteps[f].Left.Fundamental_dBV + measurementResult.FrequencySteps[f].Left.Gain_dB);
                    if (measurementResult.FrequencySteps[f].Left.D6Plus_dBV != 0 && measurementResult.FrequencySteps[f].Left.Harmonics.Count > 4 && chkShowD6.Checked)
                        h6Y_left.Add(measurementResult.FrequencySteps[f].Left.D6Plus_dBV - measurementResult.FrequencySteps[f].Left.Fundamental_dBV + measurementResult.FrequencySteps[f].Left.Gain_dB);
                    if (chkShowNoiseFloor.Checked)
                        noiseY_left.Add(measurementResult.FrequencySteps[f].Left.Average_NoiseFloor_dBV - measurementResult.FrequencySteps[f].Left.Fundamental_dBV + measurementResult.FrequencySteps[f].Left.Gain_dB);
                }

                if (showRightChannel && measurementResult.MeasurementSettings.EnableRightChannel)
                {
                    if (GraphSettings.ShowMagnitude)
                        magnY_right.Add(measurementResult.FrequencySteps[f].Right.Gain_dB);

                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 0)
                    {
                        hTotY_right.Add(measurementResult.FrequencySteps[f].Right.Thd_dB + measurementResult.FrequencySteps[f].Right.Gain_dB);
                        h2Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[0].Amplitude_dBV - measurementResult.FrequencySteps[f].Right.Fundamental_dBV + measurementResult.FrequencySteps[f].Right.Gain_dB);
                    }
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 1)
                        h3Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[1].Amplitude_dBV - measurementResult.FrequencySteps[f].Right.Fundamental_dBV + measurementResult.FrequencySteps[f].Right.Gain_dB);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 2)
                        h4Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[2].Amplitude_dBV - measurementResult.FrequencySteps[f].Right.Fundamental_dBV + measurementResult.FrequencySteps[f].Right.Gain_dB);
                    if (measurementResult.FrequencySteps[f].Right.Harmonics.Count > 3)
                        h5Y_right.Add(measurementResult.FrequencySteps[f].Right.Harmonics[3].Amplitude_dBV - measurementResult.FrequencySteps[f].Right.Fundamental_dBV + measurementResult.FrequencySteps[f].Right.Gain_dB);
                    if (measurementResult.FrequencySteps[f].Right.D6Plus_dBV != 0 && measurementResult.FrequencySteps[f].Right.Harmonics.Count > 4 && chkShowD6.Checked)
                        h6Y_right.Add(measurementResult.FrequencySteps[f].Right.D6Plus_dBV - measurementResult.FrequencySteps[f].Right.Fundamental_dBV + measurementResult.FrequencySteps[f].Right.Gain_dB);
                    if (chkShowNoiseFloor.Checked)
                        noiseY_right.Add(measurementResult.FrequencySteps[f].Right.Average_NoiseFloor_dBV - measurementResult.FrequencySteps[f].Right.Fundamental_dBV + measurementResult.FrequencySteps[f].Right.Gain_dB);
                }
            }

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();
            float lineWidth = 1;
            float markerSize = 1;
            if (GraphSettings.ThickLines)
                lineWidth = 2;
            if (GraphSettings.ShowDataPoints)
                markerSize = lineWidth + 3;

            GraphColors colors = new GraphColors();
            int color = measurementNr * 2;

            if (showLeftChannel && measurementResult.MeasurementSettings.EnableLeftChannel)
            {
                if (GraphSettings.ShowMagnitude)
                {
                    double[] logMagnY = magnY_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logMagnY);
                    plot.LineWidth = lineWidth;
                    plot.LinePattern = showRightChannel ? LinePattern.Solid : LinePattern.DenselyDashed;
                    plot.Color = colors.GetColor(9, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "Magn-L" : "Magn";
                }

                if (GraphSettings.ShowTHD)
                {
                    double[] logHTotY = hTotY_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(8, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "THD-L" : "THD";
                }

                if (GraphSettings.ShowD2)
                {
                    double[] logH2Y = h2Y_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(0, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "H2-L" : "H2";
                }

                if (GraphSettings.ShowD3)
                {
                    double[] logH3Y = h3Y_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(1, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "H3-L" : "H3";
                }

                if (GraphSettings.ShowD4)
                {
                    double[] logH4Y = h4Y_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(2, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "H4-L" : "H4";
                }

                if (GraphSettings.ShowD5)
                {
                    double[] logH5Y = h5Y_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(3, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "H5-L" : "H5";
                }

                if (GraphSettings.ShowD6)
                {
                    double[] logH6Y = h6Y_left.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(4, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "H6+-L" : "H6+";
                }

                if (GraphSettings.ShowNoiseFloor)
                {
                    double[] logNoiseY = noiseY_left.ToArray();
                    var plot = thdPlot.Plot.Add.ScatterLine(logFreqX, logNoiseY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(9, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showRightChannel ? "Noise-L" : "Noise";
                    plot.LinePattern = showRightChannel ? LinePattern.Solid : LinePattern.Dotted;
                }
            }

            if (showRightChannel && measurementResult.MeasurementSettings.EnableRightChannel)
            {
                if (GraphSettings.ShowMagnitude)
                {
                    double[] logMagnY = magnY_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logMagnY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(9, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "Magn-R" : "Magn";
                    plot.LinePattern = showLeftChannel ? LinePattern.Dotted : LinePattern.DenselyDashed;
                }

                if (GraphSettings.ShowTHD)
                {
                    double[] logHTotY = hTotY_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(8, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "THD-R" : "THD";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD2)
                {
                    double[] logH2Y = h2Y_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(0, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "H2-R" : "H2";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD3)
                {
                    double[] logH3Y = h3Y_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(1, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "H3-R" : "H3";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD4)
                {
                    double[] logH4Y = h4Y_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(2, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "H4-R" : "H4";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD5)
                {
                    double[] logH5Y = h5Y_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(3, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "H5-R" : "H5";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowD6)
                {
                    double[] logH6Y = h6Y_right.ToArray();
                    var plot = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(4, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "H6+-R" : "H6+";
                    plot.LinePattern = showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid;
                }

                if (GraphSettings.ShowNoiseFloor)
                {
                    double[] logNoiseY = noiseY_right.ToArray();
                    var plot = thdPlot.Plot.Add.ScatterLine(logFreqX, logNoiseY);
                    plot.LineWidth = lineWidth;
                    plot.Color = colors.GetColor(9, color);
                    plot.MarkerSize = markerSize;
                    plot.LegendText = showLeftChannel ? "Noise-R" : "Noise";
                    plot.LinePattern = LinePattern.Dotted;
                }
            }

            if (markerIndex != -1)      // Check if there is a persistent marker
                QaLibrary.PlotCursorMarker(thdPlot, 1, LinePattern.Solid, markerDataPoint);
            
            thdPlot.Refresh();
        }

        void UpdateGraphChannelSelectors()
        {
            if (MeasurementSettings.EnableLeftChannel && !MeasurementSettings.EnableRightChannel)
            {
                // Only single channel. Enable
                chkGraphShowLeftChannel.Checked = true;
                chkGraphShowRightChannel.Checked = false;
                GraphSettings.ShowLeftChannel = true;
                GraphSettings.ShowRightChannel = false;
            }
            if (MeasurementSettings.EnableRightChannel && !MeasurementSettings.EnableLeftChannel)
            {
                chkGraphShowLeftChannel.Checked = false;
                chkGraphShowRightChannel.Checked = true;
                GraphSettings.ShowLeftChannel = false;
                GraphSettings.ShowRightChannel = true;
            }
            chkGraphShowLeftChannel.Enabled = MeasurementSettings.EnableLeftChannel && MeasurementSettings.EnableRightChannel;
            chkGraphShowRightChannel.Enabled = MeasurementSettings.EnableLeftChannel && MeasurementSettings.EnableRightChannel;
            pnlCursorsLeft.Visible = GraphSettings.ShowLeftChannel;
            pnlCursorsRight.Visible = GraphSettings.ShowRightChannel;
        }

        /// <summary>
        /// Attach mouse events to the main graph
        /// </summary>
        void AttachPlotMouseEvent()
        {
            // Attach the mouse move event
            thdPlot.MouseMove += (s, e) =>
            {
                ShowCursorMiniGraphs(s, e);
                SetCursorMarker(s, e, false);
            };

            // Mouse is clicked
            thdPlot.MouseDown += (s, e) =>
            {
                SetCursorMarker(s, e, true);      // Set fixed marker
            };

            // Mouse is leaving the graph
            thdPlot.MouseLeave += (s, e) =>
            {
                // If persistent marker set then show mini plots of that marker
                if (markerIndex >= 0)
                {
                    QaLibrary.PlotMiniFftGraph(graphFft, MeasurementResult.FrequencySteps[markerIndex].fftData, MeasurementResult.MeasurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, MeasurementResult.MeasurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);
                    QaLibrary.PlotMiniTimeGraph(graphTime, MeasurementResult.FrequencySteps[markerIndex].timeData, MeasurementResult.FrequencySteps[markerIndex].FundamentalFrequency, MeasurementResult.MeasurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, MeasurementResult.MeasurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);
                }
            };
        }

        /// <summary>
        /// Show the mini graphs for the frequency where the mouse cursor is pointing to
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        void ShowCursorMiniGraphs(object s, MouseEventArgs e)
        {
            if (MeasurementBusy)
                return;         // Still busy

            // determine where the mouse is and get the nearest point
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = thdPlot.Plot.GetCoordinates(mousePixel);
            if (thdPlot.Plot.GetPlottables<Scatter>().Count() == 0)
                return;

            DataPoint nearest1 = thdPlot.Plot.GetPlottables<Scatter>().First().Data.GetNearestX(mouseLocation, thdPlot.Plot.LastRender);

            // place the crosshair over the highlighted point
            if (nearest1.IsReal)
            {
                QaLibrary.PlotMiniFftGraph(graphFft, MeasurementResult.FrequencySteps[nearest1.Index].fftData, MeasurementResult.MeasurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, MeasurementResult.MeasurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);
                QaLibrary.PlotMiniTimeGraph(graphTime, MeasurementResult.FrequencySteps[nearest1.Index].timeData, MeasurementResult.FrequencySteps[nearest1.Index].FundamentalFrequency, MeasurementResult.MeasurementSettings.EnableLeftChannel && chkGraphShowLeftChannel.Checked, MeasurementResult.MeasurementSettings.EnableRightChannel && chkGraphShowRightChannel.Checked);
            }
        }


        int markerIndex = -1;
        DataPoint markerDataPoint;

        /// <summary>
        /// Draw a cursor marker and update cursor texts
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <param name="isClick"></param>
        void SetCursorMarker(object s, MouseEventArgs e, bool isClick)
        {

            if (MeasurementBusy)
                return;

            // determine where the mouse is and get the nearest point
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = thdPlot.Plot.GetCoordinates(mousePixel);
            if (thdPlot.Plot.GetPlottables<Scatter>().Count() == 0)
                return;
            DataPoint nearest1 = thdPlot.Plot.GetPlottables<Scatter>().First().Data.GetNearestX(mouseLocation, thdPlot.Plot.LastRender);

            // place the crosshair over the highlighted point
            if (nearest1.IsReal)
            {
                float lineWidth = 1;// (chkThdFreq_ThickLines.Checked ? 2 : 1);
                LinePattern linePattern = LinePattern.DenselyDashed;

                if (isClick)
                {
                    // Mouse click
                    if (nearest1.Index == markerIndex)
                    {
                        // Remove marker
                        markerIndex = -1;
                        thdPlot.Plot.Remove<Crosshair>();
                        return;
                    }
                    else
                    {
                        markerIndex = nearest1.Index;
                        markerDataPoint = nearest1;
                        linePattern = LinePattern.Solid;
                    }
                }
                else
                {
                    // Mouse hoover
                    if (markerIndex != -1)
                        return;                     // Do not show new marker. There is already a clicked marker
                }

                QaLibrary.PlotCursorMarker(thdPlot, lineWidth, linePattern, nearest1);


                if (MeasurementResult.FrequencySteps.Count > nearest1.Index)
                {
                    ThdFrequencyStep step = MeasurementResult.FrequencySteps[nearest1.Index];

                    if (GraphSettings.GraphType == E_ThdFreq_GraphType.DB)
                    {
                        WriteCursorTexts_dB_L(step.FundamentalFrequency
                        , step.Left.Gain_dB
                        , step.Left.Thd_dB - step.Left.Fundamental_dBV
                        , (step.Left.Harmonics.Count > 0 ? step.Left.Harmonics[0].Amplitude_dBV - step.Left.Fundamental_dBV : 0)   // 2nd harmonic
                        , (step.Left.Harmonics.Count > 1 ? step.Left.Harmonics[1].Amplitude_dBV - step.Left.Fundamental_dBV : 0)
                        , (step.Left.Harmonics.Count > 2 ? step.Left.Harmonics[2].Amplitude_dBV - step.Left.Fundamental_dBV : 0)
                        , (step.Left.Harmonics.Count > 3 ? step.Left.Harmonics[3].Amplitude_dBV - step.Left.Fundamental_dBV : 0)
                        , (step.Left.Harmonics.Count > 4 ? step.Left.D6Plus_dBV - step.Left.Fundamental_dBV : 0)                   // 6+ harmonics
                        , step.Left.Power_Watt
                        , step.Left.Average_NoiseFloor_dBV - step.Left.Fundamental_dBV
                        , MeasurementResult.MeasurementSettings.Load
                        );

                        WriteCursorTexts_dB_R(step.FundamentalFrequency
                        , step.Right.Gain_dB
                        , step.Right.Thd_dB - step.Right.Fundamental_dBV
                        , (step.Right.Harmonics.Count > 0 ? step.Right.Harmonics[0].Amplitude_dBV - step.Right.Fundamental_dBV : 0)   // 2nd harmonic
                        , (step.Right.Harmonics.Count > 1 ? step.Right.Harmonics[1].Amplitude_dBV - step.Right.Fundamental_dBV : 0)
                        , (step.Right.Harmonics.Count > 2 ? step.Right.Harmonics[2].Amplitude_dBV - step.Right.Fundamental_dBV : 0)
                        , (step.Right.Harmonics.Count > 3 ? step.Right.Harmonics[3].Amplitude_dBV - step.Right.Fundamental_dBV : 0)
                        , (step.Right.Harmonics.Count > 4 ? step.Right.D6Plus_dBV - step.Right.Fundamental_dBV : 0)                   // 6+ harmonics
                        , step.Right.Power_Watt
                        , step.Right.Average_NoiseFloor_dBV - step.Right.Fundamental_dBV
                        , MeasurementResult.MeasurementSettings.Load
                        );
                    }
                    else
                    {
                        WriteCursorTexts_Dpercent_L(step.FundamentalFrequency
                        , step.Left.Gain_dB
                        , step.Left.Thd_Percent
                        , (step.Left.Harmonics.Count > 0 ? step.Left.Harmonics[0].Thd_Percent : 0)     // 2nd harmonic
                        , (step.Left.Harmonics.Count > 1 ? step.Left.Harmonics[1].Thd_Percent : 0)
                        , (step.Left.Harmonics.Count > 2 ? step.Left.Harmonics[2].Thd_Percent : 0)
                        , (step.Left.Harmonics.Count > 3 ? step.Left.Harmonics[3].Thd_Percent : 0)
                        , (step.Left.Harmonics.Count > 4 ? step.Left.ThdPercent_D6plus : 0)                   // 6+ harmonics
                        , step.Left.Power_Watt
                        , (step.Left.Average_NoiseFloor_V / step.Left.Fundamental_V) * 100
                        , MeasurementResult.MeasurementSettings.Load
                        );

                        WriteCursorTexts_Dpercent_R(step.FundamentalFrequency
                        , step.Right.Gain_dB
                        , step.Right.Thd_Percent
                        , (step.Right.Harmonics.Count > 0 ? step.Right.Harmonics[0].Thd_Percent : 0)     // 2nd harmonic
                        , (step.Right.Harmonics.Count > 1 ? step.Right.Harmonics[1].Thd_Percent : 0)
                        , (step.Right.Harmonics.Count > 2 ? step.Right.Harmonics[2].Thd_Percent : 0)
                        , (step.Right.Harmonics.Count > 3 ? step.Right.Harmonics[3].Thd_Percent : 0)
                        , (step.Right.Harmonics.Count > 4 ? step.Right.ThdPercent_D6plus : 0)                   // 6+ harmonics
                        , step.Right.Power_Watt
                        , (step.Right.Average_NoiseFloor_V / step.Right.Fundamental_V) * 100
                        , MeasurementResult.MeasurementSettings.Load
                        );
                    }


                }

            }
        }


        /// <summary>
        ///  Start measurement button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStartMeasurement_Click(object sender, EventArgs e)
        {
            MeasurementBusy = true;
            btnStopThdMeasurement.Enabled = true;
            btnStopThdMeasurement.ForeColor = System.Drawing.Color.Black;
            btnStartThdMeasurement.Enabled = false;
            btnStartThdMeasurement.ForeColor = System.Drawing.Color.DimGray;
            ct = new();
            await PerformMeasurementSteps(ct.Token);
            Program.MainForm.ClearMessage();
            Program.MainForm.HideProgressBar();
            MeasurementBusy = false;
            btnStopThdMeasurement.Enabled = false;
            btnStopThdMeasurement.ForeColor = System.Drawing.Color.DimGray;
            btnStartThdMeasurement.Enabled = true;
            btnStartThdMeasurement.ForeColor = System.Drawing.Color.Black;
        }


        /// <summary>
        /// Generator type changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasurementSettings.GeneratorType = (E_GeneratorType)cmbGeneratorType.SelectedIndex;
            UpdateGeneratorParameters();
        }

        /// <summary>
        /// Voltage unit changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGeneratorVoltageDisplay();
        }

        /// <summary>
        /// Generator voltage change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGenVoltage_TextChanged(object sender, EventArgs e)
        {
            if (txtGeneratorVoltage.Focused)
            {
                MeasurementSettings.GeneratorAmplitude = QaLibrary.ParseTextToDouble(txtGeneratorVoltage.Text, MeasurementSettings.GeneratorAmplitude);
                MeasurementSettings.GeneratorAmplitudeUnit = (E_VoltageUnit)cmbGeneratorVoltageUnit.SelectedIndex;
            }
            ValidateGeneratorAmplitude(sender);
        }

        /// <summary>
        /// Validate the generator voltage and show red text if invalid
        /// </summary>
        /// <param name="sender"></param>
        private void ValidateGeneratorAmplitude(object sender)
        {
            if (cmbGeneratorVoltageUnit.SelectedIndex == (int)E_VoltageUnit.MilliVolt)
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV);        // mV
            else if (cmbGeneratorVoltageUnit.SelectedIndex == (int)E_VoltageUnit.Volt)
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_V);     // V
            else
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_DBV, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_DBV);       // dBV
        }

        /// <summary>
        /// Generator voltage keypress event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGenVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        /// <summary>
        /// Output load change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputLoad_TextChanged(object sender, EventArgs e)
        {
            MeasurementSettings.Load = QaLibrary.ParseTextToDouble(txtOutputLoad.Text, MeasurementSettings.Load);
            UpdateGeneratorParameters();
            QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_LOAD, QaLibrary.MAXIMUM_LOAD);
        }

        /// <summary>
        /// Output power change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputPower_TextChanged(object sender, EventArgs e)
        {
            MeasurementSettings.AmpOutputPower = QaLibrary.ParseTextToDouble(txtAmplifierOutputPower.Text, MeasurementSettings.AmpOutputPower);
            UpdateGeneratorParameters();
            QaLibrary.ValidateRangeAdorner(sender, 0, 1000);
        }


        /// <summary>
        /// Amount of steps per octave change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void udStepsOctave_ValueChanged(object sender, EventArgs e)
        {
            MeasurementSettings.StepsPerOctave = Convert.ToUInt16(udStepsOctave.Value);
        }

        /// <summary>
        /// Amount of averages change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void udAverages_ValueChanged(object sender, EventArgs e)
        {
            MeasurementSettings.Averages = Convert.ToUInt16(udAverages.Value);
        }


        /// <summary>
        /// Key press event of output voltage textbox.
        /// Check if value is numeric. Else prevent editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        /// <summary>
        /// Output voltage has been changed.
        /// This event is also fired when text is changed by code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputVoltage_TextChanged(object sender, EventArgs e)
        {
            if (txtAmplifierOutputVoltage.Focused)
            {
                // Event fired by user input
                MeasurementSettings.AmpOutputAmplitude = QaLibrary.ParseTextToDouble(txtAmplifierOutputVoltage.Text, MeasurementSettings.AmpOutputAmplitude);
                MeasurementSettings.AmpOutputAmplitudeUnit = (E_VoltageUnit)cmbAmplifierOutputVoltageUnit.SelectedIndex;
            }
            ValidateAmplifierOutputAmplitude(sender);
        }

        /// <summary>
        /// Validate the amplifier output voltage in the textbox. Show text in red when value invalid.
        /// </summary>
        /// <param name="sender"></param>
        private void ValidateAmplifierOutputAmplitude(object sender)
        {
            if (cmbAmplifierOutputVoltageUnit.SelectedIndex == (int)E_VoltageUnit.MilliVolt)
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_DEVICE_INPUT_VOLTAGE_MV, QaLibrary.MAXIMUM_DEVICE_INPUT_VOLTAGE_MV);      // V
            else if (cmbAmplifierOutputVoltageUnit.SelectedIndex == (int)E_VoltageUnit.Volt)
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_DEVICE_INPUT_VOLTAGE_V, QaLibrary.MAXIMUM_DEVICE_INPUT_VOLTAGE_V);       // mV
            else
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_DEVICE_INPUT_VOLTAGE_DBV, QaLibrary.MAXIMUM_DEVICE_INPUT_VOLTAGE_DBV);       // dBV
        }

        /// <summary>
        /// Start frequency key press.
        /// Allow integers only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStartFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, true);
        }

        /// <summary>
        /// Start frequency changed.
        /// Show text in red when value invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtStartFreq_TextChanged(object sender, EventArgs e)
        {
            QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_FREQUENCY_HZ, QaLibrary.MAXIMUM_GENERATOR_FREQUENCY_HZ);
            MeasurementSettings.StartFrequency = QaLibrary.ParseTextToUint(txtStartFrequency.Text, MeasurementSettings.StartFrequency);
        }

        /// <summary>
        /// End frequency key press.
        /// Allow integers only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, true);
        }

        /// <summary>
        /// End frequency changed.
        /// Show text in red when value invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtEndFreq_TextChanged(object sender, EventArgs e)
        {
            QaLibrary.ValidateRangeAdorner(sender, 5, 96000);
            MeasurementSettings.EndFrequency = QaLibrary.ParseTextToUint(txtEndFrequency.Text, MeasurementSettings.EndFrequency);
        }

        /// <summary>
        /// Load key press.
        /// Allow decimals only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }


        /// <summary>
        /// Output power key press
        /// Allow decimals only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOutputPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        /// <summary>
        /// Output voltage display unit changed.
        /// Convert voltage to new unit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbOutputVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAmpOutputVoltageDisplay();
        }

        /// <summary>
        /// Set graph x axis to data range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFitGraphX_Click(object sender, EventArgs e)
        {
            SetStartFrequencySelectedIndexByFrequency(MeasurementSettings.StartFrequency);
            SetEndFrequencySelectedIndexByFrequency(MeasurementSettings.EndFrequency);
        }

        private void SetStartFrequencySelectedIndexByFrequency(uint startfrequency)
        {
            if (startfrequency < 10)
                 cmbGraph_FreqStart.SelectedIndex = 0;
            else if (startfrequency < 20)
                cmbGraph_FreqStart.SelectedIndex = 1;
            else if (startfrequency < 50)
                cmbGraph_FreqStart.SelectedIndex = 2;
            else if (startfrequency < 100)
                cmbGraph_FreqStart.SelectedIndex = 3;
            else if (startfrequency < 200)
                cmbGraph_FreqStart.SelectedIndex = 4;
            else if (startfrequency < 500)
                cmbGraph_FreqStart.SelectedIndex = 4;
            else
                cmbGraph_FreqStart.SelectedIndex = 6;

            GraphSettings.FrequencyRange_Start = (uint)((KeyValuePair<double, string>)cmbGraph_FreqStart.SelectedItem).Key;
        }

        private void SetEndFrequencySelectedIndexByFrequency(uint endfrequency)
        {
            if (endfrequency <= 1000)
                cmbGraph_FreqEnd.SelectedIndex = 0;
            else if (endfrequency <= 2000)
                cmbGraph_FreqEnd.SelectedIndex = 1;
            else if (endfrequency <= 5000)
                cmbGraph_FreqEnd.SelectedIndex = 2;
            else if (endfrequency <= 10000)
                cmbGraph_FreqEnd.SelectedIndex = 3;
            else if (endfrequency <= 20000)
                cmbGraph_FreqEnd.SelectedIndex = 4;
            else if (endfrequency <= 50000)
                cmbGraph_FreqEnd.SelectedIndex = 5;
            else
                cmbGraph_FreqEnd.SelectedIndex = 6;

            GraphSettings.FrequencyRange_End = (uint)((KeyValuePair<double, string>)cmbGraph_FreqEnd.SelectedItem).Key;
        }

        private void UpdateGraph(bool settingsChanged)
        {
            thdPlot.Plot.Remove<Scatter>();             // Remove all current lines
            int resultNr = 0;

            if (GraphSettings.GraphType == E_ThdFreq_GraphType.DB)
            {
                if (settingsChanged)
                {
                    gbdB_Range.Visible = true;
                    btnGraph_dB.BackColor = System.Drawing.Color.Cornsilk;
                    gbD_Range.Visible = false;
                    btnGraph_D_Percent.BackColor = System.Drawing.Color.WhiteSmoke;
                    chkShowMagnitude.Enabled = true;
                    lblCursorMagnitude.Visible = true;
                    lblCursor_Magnitude_L.Visible = true;
                    lblCursor_Magnitude_R.Visible = true;

                    InitializeMagnitudePlot();
                }
               
                foreach (var result in Data.Measurements.Where(m => m.Show))
                {
                    PlotMagnitude(result, resultNr++, GraphSettings.ShowLeftChannel, GraphSettings.ShowRightChannel);
                }
            }
            else
            {
                if (settingsChanged)
                {
                    gbdB_Range.Visible = false;
                    btnGraph_dB.BackColor = System.Drawing.Color.WhiteSmoke;
                    gbD_Range.Visible = true;
                    btnGraph_D_Percent.BackColor = System.Drawing.Color.Cornsilk;
                    chkShowMagnitude.Enabled = false;
                    lblCursorMagnitude.Visible = false;
                    lblCursor_Magnitude_L.Visible = false;
                    lblCursor_Magnitude_R.Visible = false;

                    InitializeThdPlot();
                }
          
                foreach (var result in Data.Measurements.Where(m => m.Show))
                {
                    PlotThd(result, resultNr++, GraphSettings.ShowLeftChannel, GraphSettings.ShowRightChannel);
                }
            }
        }

 
        /// <summary>
        /// THD % y axis fit click request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFitDGraphY_Click(object sender, EventArgs e)
        {
            if (MeasurementResult.FrequencySteps.Count == 0)
                return;

            // Determine top Y
            double maxThd_left = MeasurementResult.FrequencySteps.Max(d => d.Left.Thd_Percent);
            double maxThd_right = MeasurementResult.FrequencySteps.Max(d => d.Right.Thd_Percent);
            double max = Math.Max(maxThd_left, maxThd_right);

            if (max <= 1)
                cmbD_Graph_Top.SelectedIndex = 2;
            else if (max <= 10)
                cmbD_Graph_Top.SelectedIndex = 1;
            else
                cmbD_Graph_Top.SelectedIndex = 0;


            // Determine bottom Y
            double minThd_left = MeasurementResult.FrequencySteps.Min(d => (d.Left.Average_NoiseFloor_V / d.Left.Fundamental_V) * 100);
            double minD2_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 1).Min(d => (d.Left.Harmonics[0].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD3_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 2).Min(d => (d.Left.Harmonics[1].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD4_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 3).Min(d => (d.Left.Harmonics[2].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD5_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 4).Min(d => (d.Left.Harmonics[3].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD6_left = MeasurementResult.FrequencySteps.Min(d => d.Left.ThdPercent_D6plus);

            double min = Math.Min(minThd_left, minD2_left);
            min = Math.Min(min, minD3_left);
            min = Math.Min(min, minD4_left);
            min = Math.Min(min, minD5_left);

            double minThd_right = MeasurementResult.FrequencySteps.Min(d => (d.Right.Average_NoiseFloor_V / d.Right.Fundamental_V) * 100);
            double minD2_right = MeasurementResult.FrequencySteps.Where(d => d.Right.Harmonics.Count >= 1).Min(d => (d.Right.Harmonics[0].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD3_right = MeasurementResult.FrequencySteps.Where(d => d.Right.Harmonics.Count >= 2).Min(d => (d.Right.Harmonics[1].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD4_right = MeasurementResult.FrequencySteps.Where(d => d.Right.Harmonics.Count >= 3).Min(d => (d.Right.Harmonics[2].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD5_right = MeasurementResult.FrequencySteps.Where(d => d.Right.Harmonics.Count >= 4).Min(d => (d.Right.Harmonics[3].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD6_right = MeasurementResult.FrequencySteps.Min(d => d.Right.ThdPercent_D6plus);

            min = Math.Min(min, minThd_right);
            min = Math.Min(min, minD2_right);
            min = Math.Min(min, minD3_right);
            min = Math.Min(min, minD4_right);
            min = Math.Min(min, minD5_right);

            if (min > 0.1)
                cmbD_Graph_Bottom.SelectedIndex = 0;
            else if (min > 0.01)
                cmbD_Graph_Bottom.SelectedIndex = 1;
            else if (min > 0.001)
                cmbD_Graph_Bottom.SelectedIndex = 2;
            else if (min > 0.0001)
                cmbD_Graph_Bottom.SelectedIndex = 3;
            else if (min > 0.00001)
                cmbD_Graph_Bottom.SelectedIndex = 4;
            else
                cmbD_Graph_Bottom.SelectedIndex = 5;
        }

        /// <summary>
        /// Magnitude y axis fit click request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFitDbGraphY_Click(object sender, EventArgs e)
        {

            if (MeasurementResult.FrequencySteps.Count == 0)
                return;

            // Determine top Y
            double maxGain_left = MeasurementResult.FrequencySteps.Max(d => d.Left.Gain_dB);
            double maxGain_right = MeasurementResult.FrequencySteps.Max(d => d.Right.Gain_dB);
            double max = Math.Max(maxGain_left, maxGain_right);
            ud_dB_Graph_Top.Value = (Math.Ceiling((decimal)((int)max) / 10) * 10) + 20;


            // Determine bottom Y
            double minDb_left = MeasurementResult.FrequencySteps.Min(d => d.Left.Average_NoiseFloor_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD2_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 1).Min(d => d.Left.Harmonics[0].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD3_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 2).Min(d => d.Left.Harmonics[1].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD4_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 3).Min(d => d.Left.Harmonics[2].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD5_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 4).Min(d => d.Left.Harmonics[3].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD6_left = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 5).Min(d => d.Left.Harmonics[4].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            
            double min = Math.Min(minDb_left, minD2_left);
            min = Math.Min(min, minD3_left);
            min = Math.Min(min, minD4_left);
            min = Math.Min(min, minD5_left);

            double minDb_right = MeasurementResult.FrequencySteps.Min(d => d.Left.Average_NoiseFloor_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD2_right = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 1).Min(d => d.Left.Harmonics[0].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD3_right = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 2).Min(d => d.Left.Harmonics[1].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD4_right = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 3).Min(d => d.Left.Harmonics[2].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD5_right = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 4).Min(d => d.Left.Harmonics[3].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double minD6_right = MeasurementResult.FrequencySteps.Where(d => d.Left.Harmonics.Count >= 5).Min(d => d.Left.Harmonics[4].Amplitude_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;

            min = Math.Min(min, minDb_right);
            min = Math.Min(min, minD2_right);
            min = Math.Min(min, minD3_right);
            min = Math.Min(min, minD4_right);
            min = Math.Min(min, minD5_right);

            ud_dB_Graph_Bottom.Value = Math.Ceiling((decimal)((int)(min / 10) - 1) * 10);        // Round to 10, subtract 10
            
            /*
            double min_left = MeasurementResult.FrequencySteps.Min(d => d.Left.Average_NoiseFloor_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Left.Gain_dB;
            double min_right = MeasurementResult.FrequencySteps.Min(d => d.Left.Average_NoiseFloor_dBV) - MeasurementResult.FrequencySteps.Average(d => d.Right.Fundamental_dBV) + MeasurementResult.FrequencySteps[0].Right.Gain_dB;
            double min = Math.Min(min_left, min_right);
            ud_dB_Graph_Bottom.Value = Math.Ceiling(( (decimal)(int)(min / 10) - 1) * 10);        // Round to 10, subtract 10
            */
        }

        /// <summary>
        ///  Cancel measurement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopMeasurement_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        private void lblCursor_Power_Click(object sender, EventArgs e)
        {

        }

        private void chkEnableLeftChannel_CheckedChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EnableLeftChannel = chkEnableLeftChannel.Checked;
        }

        private void chkEnableRightChannel_CheckedChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EnableRightChannel = chkEnableRightChannel.Checked;
        }

        private void cmbD_Graph_Top_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbD_Graph_Top.SelectedIndex != -1)
                GraphSettings.D_PercentTop = (double)((KeyValuePair<double, string>)cmbD_Graph_Top.SelectedItem).Key;
            UpdateGraph(true);
        }

        private void cmbD_Graph_Bottom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbD_Graph_Bottom.SelectedIndex != -1)
                GraphSettings.D_PercentBottom = (double)((KeyValuePair<double, string>)cmbD_Graph_Bottom.SelectedItem).Key;
            UpdateGraph(true);
        }

        private void ud_dB_Graph_Top_ValueChanged(object sender, EventArgs e)
        {
            GraphSettings.DbRangeTop = (double)ud_dB_Graph_Top.Value;
            UpdateGraph(true);
        }

        private void ud_dB_Graph_Bottom_ValueChanged(object sender, EventArgs e)
        {
            GraphSettings.DbRangeBottom = (double)ud_dB_Graph_Bottom.Value;
            UpdateGraph(true);
        }

        private void cmbGraph_FreqStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGraph_FreqStart.SelectedIndex != -1)
                GraphSettings.FrequencyRange_Start = (uint)((KeyValuePair<double, string>)cmbGraph_FreqStart.SelectedItem).Key;
            UpdateGraph(true);
        }

        private void cmbGraph_FreqEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGraph_FreqEnd.SelectedIndex != -1)
                GraphSettings.FrequencyRange_End = (uint)((KeyValuePair<double, string>)cmbGraph_FreqEnd.SelectedItem).Key;
            UpdateGraph(true);
        }

        private void chkShowMagnitude_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowMagnitude = chkShowMagnitude.Checked;
            UpdateGraph(true);
        }

        private void chkShowThd_CheckedChanged_1(object sender, EventArgs e)
        {
            GraphSettings.ShowTHD = chkShowThd.Checked;
            UpdateGraph(true);
        }

        private void chkShowD2_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowD2 = chkShowD2.Checked;
            UpdateGraph(true);
        }

        private void chkShowD3_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowD3 = chkShowD3.Checked;
            UpdateGraph(true);
        }

        private void chkShowD4_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowD4 = chkShowD4.Checked;
            UpdateGraph(true);
        }

        private void chkShowD5_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowD5 = chkShowD5.Checked;
            UpdateGraph(true);
        }

        private void chkShowD6_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowD6 = chkShowD6.Checked;
            UpdateGraph(true);
        }

        private void chkShowNoiseFloor_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowNoiseFloor = chkShowNoiseFloor.Checked;
            UpdateGraph(true);
        }

        private void chkThickLines_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ThickLines = chkThickLines.Checked;
            UpdateGraph(true);
        }

        private void chkShowDataPoints_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowDataPoints = chkShowDataPoints.Checked;
            UpdateGraph(true);
        }

        /// <summary>
        /// Magnitude graph button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGraph_dB_Click(object sender, EventArgs e)
        {
            GraphSettings.GraphType = E_ThdFreq_GraphType.DB;
            ClearCursorTexts();
            UpdateGraph(true);
        }

        /// <summary>
        /// THD % graph button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGraph_D_Click(object sender, EventArgs e)
        {
            GraphSettings.GraphType = E_ThdFreq_GraphType.D_PERCENT;
            ClearCursorTexts();
            UpdateGraph(true);
        }

        private void chkGraphShowLeftChannel_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowLeftChannel = chkGraphShowLeftChannel.Checked;
            UpdateGraphChannelSelectors();
            UpdateGraph(true);
        }

        private void chkGraphShowRightChannel_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowRightChannel = chkGraphShowRightChannel.Checked;
            UpdateGraphChannelSelectors();
            UpdateGraph(true);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void scGraphCursors_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
