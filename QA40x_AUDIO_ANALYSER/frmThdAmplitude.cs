﻿using QA402_AUDIO_ANALYSER;
using QA40x_AUDIO_ANALYSER.Data.ThdAmplitude;
using QaControl;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace QA40x_AUDIO_ANALYSER
{

    public partial class frmThdAmplitude : Form
    {
        public ThdAmplitudeData Data { get; set; }       // Data used in this form instance
        public bool MeasurementBusy { get; set; }                   // Measurement busy state

        private ThdAmplitudeMeasurementSettings MeasurementSettings;
        private ThdAmplitudeGraphSettings GraphSettings;
        private ThdAmplitudeMeasurementResult MeasurementResult;

        CancellationTokenSource ct;                                 // Measurement cancelation token

        /// <summary>
        /// Constructor
        /// </summary>
        public frmThdAmplitude(ref ThdAmplitudeData data)
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
            QaLibrary.InitMiniFftPlot(graphFft, 10, 100000, -150, 20);
            QaLibrary.InitMiniTimePlot(graphTime, 0, 4, -1, 1);


            // TODO: depends on graph settings which graph is shown
            if (data.Measurements.Count > 0 && data.Measurements[0].AmplitudeSteps.Count > 0)
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
                new (0, "mV"),
                new (1, "V")
            };
            ComboBoxHelper.PopulateComboBox(cmbStartVoltageUnit, items);
            ComboBoxHelper.PopulateComboBox(cmbEndVoltageUnit, items);
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
                new (0.0001, "0.0001"),
                new (0.0002, "0.0002"),
                new (0.0005, "0.0005"),
                new (0.001, "0.001"),
                new (0.002, "0.002"),
                new (0.005, "0.005"),
                new (0.01, "0.01"),
                new (0.02, "0.02"),
                new (0.02, "0.05"),
                new (0.1, "0.1"),
                new (0.2, "0.2"),
                new (0.5, "0.5")
            };
            ComboBoxHelper.PopulateComboBox(cmbGraph_VoltageStart, items);

            items = new List<KeyValuePair<double, string>>
            {
                new (1, "1"),
                new (2, "2"),
                new (5, "5"),
                new (10, "10"),
                new (20, "20"),
                new (50, "50"),
                new (100, "100"),
                new (200, "200")
            };
            ComboBoxHelper.PopulateComboBox(cmbGraph_VoltageEnd, items);

            items = new List<KeyValuePair<double, string>>
            {
                new (0, "Output voltage"),
                new (1, "Output power"),
                new (2, "Input voltage")
            };
            ComboBoxHelper.PopulateComboBox(cmbXAxis, items);

        }

     
        /// <summary>
        /// Initialize Settings with default settings
        /// </summary>
        void SetDefaultMeasurementSettings(ref ThdAmplitudeMeasurementSettings settings)
        {
            // Initialize with default measurement settings
            settings.SampleRate = 192000;
            settings.FftSize = 65536 * 2;
            settings.WindowingFunction = Windowing.Hann;
            settings.StepsPerOctave = 5;
            settings.Averages = 1;
            settings.Load = 8;                      // Amplifier load (Ohm)
            settings.StartAmplitude = 0.001;           
            settings.StartAmplitudeUnit = E_VoltageUnit.Volt;
            settings.EndAmplitude = 1;
            settings.EndAmplitudeUnit = E_VoltageUnit.Volt;
            settings.EnableLeftChannel = true;
            settings.EnableRightChannel = true;
            settings.Frequency = 1000;
        }

        /// <summary>
        /// Initializer with default graph settings
        /// </summary>
        void SetDefaultGraphSettings(ref ThdAmplitudeGraphSettings settings)
        {
            settings = new()
            {
                DbRangeTop = 10,
                DbRangeBottom = -150,
                D_PercentTop = 10,
                D_PercentBottom = 0.0001,

                VoltageRange_Start = 0.001,
                VoltageRange_End = 10,

                GraphType = E_ThdAmplitude_GraphType.D_PERCENT,
                ShowMagnitude = true,
                ShowTHD = true,
                ShowD2 = true,
                ShowD3 = true,
                ShowD4 = true,
                ShowD5 = true,
                ShowD6 = true,
                ShowNoiseFloor = true,

                XAxisType = E_X_AxisType.OUTPUT_VOLTAGE,

                ThickLines = true,
                ShowDataPoints = false,

                ShowLeftChannel = true,
                ShowRightChannel = true
            };
        }


        /// <summary>
        /// Set initial control values
        /// </summary>
        void SetMeasurementControls(ThdAmplitudeMeasurementSettings settings)
        {
            txtStartVoltage.Text = settings.StartAmplitude.ToString("#0.0##");
            cmbStartVoltageUnit.SelectedIndex = (int)settings.StartAmplitudeUnit;
            txtEndVoltage.Text = settings.EndAmplitude.ToString("#0.0##");
            cmbEndVoltageUnit.SelectedIndex = (int)settings.EndAmplitudeUnit;
       
            txtOutputLoad.Text = settings.Load.ToString();
            txtFrequency.Text = settings.Frequency.ToString();

            udStepsOctave.Value = settings.StepsPerOctave;
            udAverages.Value = settings.Averages;

            chkEnableLeftChannel.Checked = settings.EnableLeftChannel;
            chkEnableRightChannel.Checked = settings.EnableRightChannel;
        }


        void SetGraphControls(ThdAmplitudeGraphSettings graphSettings)
        {
            // Align controls
            gbdB_Range.Left = gbD_Range.Left;
            gbdB_Range.Top = gbD_Range.Top;
            // Set correct groupbox visibility
            gbdB_Range.Visible = graphSettings.GraphType == E_ThdAmplitude_GraphType.DB;
            gbD_Range.Visible = graphSettings.GraphType == E_ThdAmplitude_GraphType.D_PERCENT;

            ComboBoxHelper.SelectNearestValue(cmbD_Graph_Top, graphSettings.D_PercentTop);
            ComboBoxHelper.SelectNearestValue(cmbD_Graph_Bottom, graphSettings.D_PercentBottom);
            ud_dB_Graph_Top.Value = (decimal)graphSettings.DbRangeTop;
            ud_dB_Graph_Bottom.Value = (decimal)graphSettings.DbRangeBottom;
            SetStartVoltageSelectedIndex(graphSettings.VoltageRange_Start);
            SetEndVoltageSelectedIndex(graphSettings.VoltageRange_End);

            chkShowMagnitude.Checked = graphSettings.ShowMagnitude;
            chkShowThd.Checked = graphSettings.ShowTHD;
            chkShowD2.Checked = graphSettings.ShowD2;
            chkShowD3.Checked = graphSettings.ShowD3;
            chkShowD4.Checked = graphSettings.ShowD4;
            chkShowD5.Checked = graphSettings.ShowD5;
            chkShowD6.Checked = graphSettings.ShowD6;
            chkShowNoiseFloor.Checked = graphSettings.ShowNoiseFloor;

            cmbXAxis.SelectedIndex = (int)GraphSettings.XAxisType;

            chkThickLines.Checked = graphSettings.ThickLines;
            chkShowDataPoints.Checked = graphSettings.ShowDataPoints;

            chkGraphShowLeftChannel.Checked = graphSettings.ShowLeftChannel;
            chkGraphShowLeftChannel.Visible = chkEnableLeftChannel.Checked;
            chkGraphShowRightChannel.Checked = graphSettings.ShowRightChannel;
            chkGraphShowRightChannel.Visible = chkEnableRightChannel.Checked;
        }


        private void SetStartVoltageSelectedIndex(double startVoltage)
        {
            if (startVoltage < 0.0001)
                cmbGraph_VoltageStart.SelectedIndex = 0;
            else if (startVoltage < 0.0002)
                cmbGraph_VoltageStart.SelectedIndex = 1;
            else if (startVoltage < 0.0005)
                cmbGraph_VoltageStart.SelectedIndex = 2;
            else if (startVoltage < 0.001)
                cmbGraph_VoltageStart.SelectedIndex = 3;
            else if (startVoltage < 0.002)
                cmbGraph_VoltageStart.SelectedIndex = 4;
            else if (startVoltage < 0.005)
                cmbGraph_VoltageStart.SelectedIndex = 5;
            else if (startVoltage < 0.01)
                cmbGraph_VoltageStart.SelectedIndex = 6;
            else if (startVoltage < 0.02)
                cmbGraph_VoltageStart.SelectedIndex = 7;
            else if (startVoltage < 0.05)
                cmbGraph_VoltageStart.SelectedIndex = 8;
            else if (startVoltage < 0.1)
                cmbGraph_VoltageStart.SelectedIndex = 9;
            else if (startVoltage < 0.2)
                cmbGraph_VoltageStart.SelectedIndex = 10;
            else 
                cmbGraph_VoltageStart.SelectedIndex = 11;
           
            GraphSettings.VoltageRange_Start = (double)((KeyValuePair<double, string>)cmbGraph_VoltageStart.SelectedItem).Key;
        }

        private void SetEndVoltageSelectedIndex(double endVoltage)
        {
            if (endVoltage <= 1)
                cmbGraph_VoltageEnd.SelectedIndex = 0;
            else if (endVoltage <= 2)
                cmbGraph_VoltageEnd.SelectedIndex = 1;
            else if (endVoltage <= 5)
                cmbGraph_VoltageEnd.SelectedIndex = 2;
            else if (endVoltage <= 10)
                cmbGraph_VoltageEnd.SelectedIndex = 3;
            else if (endVoltage <= 20)
                cmbGraph_VoltageEnd.SelectedIndex = 4;
            else if (endVoltage <= 50)
                cmbGraph_VoltageEnd.SelectedIndex = 5;
            else if (endVoltage <= 100)
                cmbGraph_VoltageEnd.SelectedIndex = 6;
            else
                cmbGraph_VoltageEnd.SelectedIndex = 7;

            GraphSettings.VoltageRange_End = (double)((KeyValuePair<double, string>)cmbGraph_VoltageEnd.SelectedItem).Key;
        }



        /// <summary>
        /// Update the start voltage in the textbox based on the selected unit.
        /// If the unit changes then the voltage will be converted
        /// </summary>
        void UpdateStartVoltageDisplay()
        {
            switch (cmbStartVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtStartVoltage.Text = ((int)QaLibrary.ConvertVoltage(MeasurementSettings.StartAmplitude, MeasurementSettings.StartAmplitudeUnit, E_VoltageUnit.MilliVolt)).ToString("###0"); // Whole numbers onyl, so cast to integer
                    break;
                case 1: // V
                    txtStartVoltage.Text = QaLibrary.ConvertVoltage(MeasurementSettings.StartAmplitude, MeasurementSettings.StartAmplitudeUnit, E_VoltageUnit.Volt).ToString("#0.0##");
                    break;
            }
        }

        /// <summary>
        /// Update the end voltage in the textbox based on the selected unit.
        /// If the unit changes then the voltage will be converted
        /// </summary>
        void UpdateEndVoltageDisplay()
        {
            switch (cmbEndVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtEndVoltage.Text = ((int)QaLibrary.ConvertVoltage(MeasurementSettings.EndAmplitude, MeasurementSettings.EndAmplitudeUnit, E_VoltageUnit.MilliVolt)).ToString("###0"); // Whole numbers onyl, so cast to integer
                    break;
                case 1: // V
                    txtEndVoltage.Text = QaLibrary.ConvertVoltage(MeasurementSettings.EndAmplitude, MeasurementSettings.EndAmplitudeUnit, E_VoltageUnit.Volt).ToString("#0.0##");
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

            ClearPlot();
            ClearCursorTexts();
            UpdateGraph(true);

            var _measurementSettings = MeasurementSettings.Copy();             // Create snapshot so it is not changed during measuring

            // Clear measurement result
            MeasurementResult = new()
            {
                CreateDate = DateTime.Now,
                Show = true,                                      // Show in graph
                MeasurementSettings = _measurementSettings       // Copy measurment settings to measurement results
            };

            // For now clear measurements to allow only one until we have a UI to manage them.
            Data.Measurements.Clear();

            // Add to list
            Data.Measurements.Add(MeasurementResult);

            UpdateGraphChannelSelectors();

            markerIndex = -1;       // Reset marker

            // Init mini plots
            QaLibrary.InitMiniFftPlot(graphFft, 10, 100000, -150, 20);
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


            // ********************************************************************
            // Determine attenuation level
            // ********************************************************************
            double generatorAmplitudedBV = QaLibrary.ConvertVoltage(_measurementSettings.StartAmplitude, _measurementSettings.StartAmplitudeUnit, E_VoltageUnit.dBV);
            await Program.MainForm.ShowMessage($"Determining the best input attenuation for a generator voltage of {generatorAmplitudedBV:0.00#} dBV.");

            double testFrequency = QaLibrary.GetNearestBinFrequency(_measurementSettings.Frequency, _measurementSettings.SampleRate, _measurementSettings.FftSize);
            // Determine correct input attenuation
            var result = await QaLibrary.DetermineAttenuationForGeneratorVoltageWithChirp(generatorAmplitudedBV, 42, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel, ct);
            if (ct.IsCancellationRequested)
                return false;
            QaLibrary.PlotMiniFftGraph(graphFft, result.Item3.FreqInput, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel);
            QaLibrary.PlotMiniTimeGraph(graphTime, result.Item3.TimeInput, testFrequency, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel, true);
            var prevInputAmplitudedBV = result.Item2;
            

            // Set attenuation
            await Qa40x.SetInputRange(result.Item1);

            await Program.MainForm.ShowMessage($"Found correct input attenuation of {result.Item1:0} dBV for an amplifier amplitude of {result.Item2:0.00#} dBV.", 500);
          
            if (ct.IsCancellationRequested)
                return false;

            // ********************************************************************
            // Generate a list of voltages evenly spaced in log scale
            // ********************************************************************
            var startAmplitudeV = QaLibrary.ConvertVoltage(_measurementSettings.StartAmplitude, _measurementSettings.StartAmplitudeUnit, E_VoltageUnit.Volt);
            var prevGeneratorVoltagedBV = QaLibrary.ConvertVoltage(_measurementSettings.StartAmplitude, _measurementSettings.StartAmplitudeUnit, E_VoltageUnit.dBV);
            var endAmplitudeV = QaLibrary.ConvertVoltage(_measurementSettings.EndAmplitude, _measurementSettings.EndAmplitudeUnit, E_VoltageUnit.Volt);
            var stepVoltages = QaLibrary.GetLineairSpacedLogarithmicValuesPerOctave(startAmplitudeV, endAmplitudeV, _measurementSettings.StepsPerOctave);

            // ********************************************************************
            // Do noise floor measurement
            // ********************************************************************
            await Program.MainForm.ShowMessage($"Determining noise floor.");
            await Qa40x.SetOutputSource(OutputSources.Off);
            MeasurementResult.NoiseFloor = await QaLibrary.DoAcquisitions(_measurementSettings.Averages, ct);
            if (ct.IsCancellationRequested)
                return false;
            QaLibrary.PlotMiniFftGraph(graphFft, MeasurementResult.NoiseFloor.FreqInput, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel);
            QaLibrary.PlotMiniTimeGraph(graphTime, MeasurementResult.NoiseFloor.TimeInput, testFrequency, _measurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, _measurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);

            Program.MainForm.SetupProgressBar(0, stepVoltages.Length);

            var binSize = QaLibrary.CalcBinSize(_measurementSettings.SampleRate, _measurementSettings.FftSize);
            uint fundamentalBin = QaLibrary.GetBinOfFrequency(testFrequency, binSize);

            var newAttenuation = 0;
            var prevAttenuation = 0;
            // ********************************************************************
            // Step through the list of voltages
            // ********************************************************************
            for (int i = 0; i < stepVoltages.Length; i++)
            {
                await Program.MainForm.ShowMessage($"Measuring step {i + 1} of {stepVoltages.Length}.");
                Program.MainForm.UpdateProgressBar(i+1);

                // Convert generator voltage from V to dBV
                var generatorVoltageV = stepVoltages[i];
                var generatorVoltagedBV = QaLibrary.ConvertVoltage(generatorVoltageV, E_VoltageUnit.Volt, E_VoltageUnit.dBV);   // Convert to dBV

                // Determine attanuation needed
                var voltageDiffdBV = generatorVoltagedBV - prevGeneratorVoltagedBV;             // Calculate voltage rise of amplifier output
                var predictedAttenuation = QaLibrary.DetermineAttenuation(prevInputAmplitudedBV + voltageDiffdBV); // Predict attenuation
                newAttenuation = predictedAttenuation > newAttenuation ? predictedAttenuation : newAttenuation;
                await Qa40x.SetInputRange(newAttenuation);                          // Set attenuation
                prevGeneratorVoltagedBV = generatorVoltagedBV;
                if (newAttenuation > prevAttenuation && newAttenuation == 24)
                {
                    // Attenuation changed. Get new noise floor
                    await Program.MainForm.ShowMessage($"Attenuation changed. Measuring new noise floor.");
                    await Qa40x.SetOutputSource(OutputSources.Off);
                    MeasurementResult.NoiseFloor = await QaLibrary.DoAcquisitions(_measurementSettings.Averages, ct);
                    if (ct.IsCancellationRequested)
                        return false;
                    QaLibrary.PlotMiniFftGraph(graphFft, MeasurementResult.NoiseFloor.FreqInput, _measurementSettings.EnableLeftChannel, _measurementSettings.EnableRightChannel);
                    QaLibrary.PlotMiniTimeGraph(graphTime, MeasurementResult.NoiseFloor.TimeInput, testFrequency, _measurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, _measurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);
                    await Qa40x.SetOutputSource(OutputSources.Sine);
                }
                prevAttenuation = newAttenuation;

                // Set generator
                await Qa40x.SetGen1(testFrequency, generatorVoltagedBV, true);      // Set the generator in dBV
                if (i == 0)
                    await Qa40x.SetOutputSource(OutputSources.Sine);                // We need to call this the first time

                LeftRightSeries lrfs = null;
                do
                {
                    try
                    {
                        lrfs = await QaLibrary.DoAcquisitions(_measurementSettings.Averages, ct);  // Do acquisitions
                        if (ct.IsCancellationRequested)
                            return false;
                    }
                    catch (HttpRequestException ex)
                    {
                        if (ex.Message.Contains("400 (Acquisition Overload)"))
                        {
                            // Detected overload. Increase attenuation to next step.
                            newAttenuation += 6;
                            if (newAttenuation > 42)
                            {
                                MessageBox.Show($"Maximum attenuation reached.\nMeasurements are stopped", "Maximum attenuation reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                await Qa40x.SetOutputSource(OutputSources.Off);
                                return false;
                            }
                            await Qa40x.SetInputRange(newAttenuation);
                            
                            if (newAttenuation == 24)
                            {
                                // Attenuation changed. Get new noise floor
                                await Program.MainForm.ShowMessage($"Attenuation changed. Measuring new noise floor.");
                                await Qa40x.SetOutputSource(OutputSources.Off);
                                MeasurementResult.NoiseFloor = await QaLibrary.DoAcquisitions(_measurementSettings.Averages, ct);
                                if (ct.IsCancellationRequested)
                                    return false;
                                
                                await Qa40x.SetOutputSource(OutputSources.Sine);
                            }
                        }
                    }
                } while (lrfs == null);     // Loop until we have an acquisition result

                if (fundamentalBin >= lrfs.FreqInput.Left.Length)                   // Check if bin within array bounds
                    break;

                ThdAmplitudeStep step = new()
                {
                    FundamentalFrequency = testFrequency,
                    GeneratorVoltage = generatorVoltageV,
                    fftData = lrfs.FreqInput,
                    timeData = lrfs.TimeInput
                };

                // Plot the mini graphs
                QaLibrary.PlotMiniFftGraph(graphFft, lrfs.FreqInput, _measurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, _measurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);
                QaLibrary.PlotMiniTimeGraph(graphTime, lrfs.TimeInput, step.FundamentalFrequency, _measurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, _measurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);

                step.Left = ChannelCalculations(binSize, step.FundamentalFrequency, generatorVoltagedBV, lrfs.FreqInput.Left, MeasurementResult.NoiseFloor.FreqInput.Left, _measurementSettings.Load);
                step.Right = ChannelCalculations(binSize, step.FundamentalFrequency, generatorVoltagedBV, lrfs.FreqInput.Right, MeasurementResult.NoiseFloor.FreqInput.Right, _measurementSettings.Load);

                // Add step data to list
                MeasurementResult.AmplitudeSteps.Add(step);

                UpdateGraph(false);
                ShowLastMeasurementCursorTexts();

                // Check if cancel button pressed
                if (ct.IsCancellationRequested)
                {
                    await Qa40x.SetOutputSource(OutputSources.Off);                                             // Be sure to switch gen off
                    return false;
                }

                // Get maximum signal for attenuation prediction of next step
                prevInputAmplitudedBV = 20 * Math.Log10(lrfs.FreqInput.Left.Max());    
                prevInputAmplitudedBV = Math.Max(prevInputAmplitudedBV, 20 * Math.Log10(lrfs.FreqInput.Left.Max()));    
            }

            // Turn the generator off
            await Qa40x.SetOutputSource(OutputSources.Off);

            // Show message
            await Program.MainForm.ShowMessage($"Measurement finished!", 500);
          
            return true;
        }



        private ThdFrequencyStepChannel ChannelCalculations(double binSize, double fundamentalFrequency, double generatorAmplitudeDbv, double[] fftData, double[] noiseFloorFftData, double load)
        {
            uint fundamentalBin = QaLibrary.GetBinOfFrequency(fundamentalFrequency, binSize);

            // Get and store step data
            ThdFrequencyStepChannel channelData = new()
            {
                Fundamental_V = fftData[fundamentalBin],
                Fundamental_dBV = 20 * Math.Log10(fftData[fundamentalBin]),
                Gain_dB = 20 * Math.Log10(fftData[fundamentalBin] / Math.Pow(10, generatorAmplitudeDbv / 20))
            };

            // Calculate average noise floor
            channelData.Average_NoiseFloor_V = noiseFloorFftData
                .Skip((int)fundamentalBin + 1)
                .Average();
            channelData.Average_NoiseFloor_dBV = 20 * Math.Log10(channelData.Average_NoiseFloor_V);

            // Reset harmonic distortion variables
            double distortionSqrtTotal = 0;
            double distiortionD6plus = 0;

            // Loop through harmonics up to the 12th
            for (int h = 2; h <= 12; h++)
            {
                var harmonicFrequency = fundamentalFrequency * h;
                uint bin = QaLibrary.GetBinOfFrequency(harmonicFrequency, binSize);

                if (bin >= fftData.Length)
                    break;

                HarmonicData harmonic = new()
                {
                    HarmonicNr = h,
                    Frequency = harmonicFrequency,
                    NoiseAmplitude_V = noiseFloorFftData[bin],
                    Amplitude_V = fftData[bin],
                    Amplitude_dBV = 20 * Math.Log10(fftData[bin]),
                    Thd_Percent = (fftData[bin] / channelData.Fundamental_V) * 100,
                    Thd_dB = 20 * Math.Log10((fftData[bin] / channelData.Fundamental_V) * 100 / 100.0)
                };

                if (h >= 6)
                    distiortionD6plus += Math.Pow(harmonic.Amplitude_V, 2);

                distortionSqrtTotal += Math.Pow(harmonic.Amplitude_V, 2);
                channelData.Harmonics.Add(harmonic);
            }

            // Calculate THD of current step
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
            if (MeasurementResult == null || MeasurementResult.AmplitudeSteps.Count == 0)
                return;

            ThdAmplitudeStep step = MeasurementResult.AmplitudeSteps.Last();

            if (GraphSettings.GraphType == E_ThdAmplitude_GraphType.DB)
            {
                // Plot current measurement texts
                WriteCursorTexts_dB_L(step.GeneratorVoltage
                        , step.Left.Fundamental_V
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

                WriteCursorTexts_dB_R(step.GeneratorVoltage
                        , step.Right.Fundamental_V
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
                WriteCursorTexts_Dpercent_L(step.GeneratorVoltage
                        , step.Left.Fundamental_V
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

                WriteCursorTexts_Dpercent_R(step.GeneratorVoltage
                        , step.Right.Fundamental_V
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
        void WriteCursorTexts_Dpercent_L(double Vin, double Vout, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(out)";
                lblCursor_Vout_L.Text = $"{Vout:##0.000 V}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_POWER)
            {
                lblCursor_X_Axis.Text = "P(out)";
                lblCursor_Vout_L.Text = $"{power:##0.000 W}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.INPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(in)";
                lblCursor_Vout_L.Text = $"V(in): {Vin:##0.000 V}";
            }

            lblCursor_Magnitude_L.Text = $"{magnitude:0.## dB}";

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

            lblCursor_NoiseFloor_L.Text = $"{noiseFloor:0.000000 \\%}";
            scGraphCursors.Panel2.Refresh();
        }

        void WriteCursorTexts_Dpercent_R(double Vin, double Vout, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(out)";
                lblCursor_Vout_R.Text = $"{Vout:##0.000 V}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_POWER)
            {
                lblCursor_X_Axis.Text = "P(out)";
                lblCursor_Vout_R.Text = $"{power:##0.000 W}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.INPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(in)";
                lblCursor_Vout_R.Text = $"V(in): {Vin:##0.000 V}";
            }
            lblCursor_Magnitude_R.Text = $"{magnitude:0.## dB}";

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

            lblCursor_NoiseFloor_R.Text = $"{noiseFloor:0.000000 \\%}";
            scGraphCursors.Panel2.Refresh();
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
        void WriteCursorTexts_dB_L(double Vin, double Vout, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(out)";
                lblCursor_Vout_L.Text = $"{Vout:##0.000 V}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_POWER)
            {
                lblCursor_X_Axis.Text = "P(out)";
                lblCursor_Vout_L.Text = $"{power:##0.000 W}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.INPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(in)";
                lblCursor_Vout_L.Text = $"V(in): {Vin:##0.000 V}";
            }

            lblCursor_Magnitude_L.Text = $"{magnitude:0.## dB}";
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
            scGraphCursors.Panel2.Refresh();
        }


        void WriteCursorTexts_dB_R(double Vin, double Vout, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double power, double noiseFloor, double load)
        {
            if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(out)";
                lblCursor_Vout_R.Text = $"{Vout:##0.000 V}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.OUTPUT_POWER)
            {
                lblCursor_X_Axis.Text = "P(out)";
                lblCursor_Vout_R.Text = $"{power:##0.000 W}";
            }
            else if (GraphSettings.XAxisType == E_X_AxisType.INPUT_VOLTAGE)
            {
                lblCursor_X_Axis.Text = "V(in)";
                lblCursor_Vout_R.Text = $"V(in): {Vin:##0.000 V}";
            }

            lblCursor_Magnitude_R.Text = $"{magnitude:0.## dB}";
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
            scGraphCursors.Panel2.Refresh();
        }

        void ClearCursorTexts()
        {
            if (GraphSettings.GraphType == E_ThdAmplitude_GraphType.DB)
            {
                WriteCursorTexts_dB_L(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                WriteCursorTexts_dB_R(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
            else
            {
                WriteCursorTexts_Dpercent_L(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                WriteCursorTexts_Dpercent_R(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
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
        /// Initialize the THD % plot
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
            ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();

            minorTickGenX.Divisions = 10;
            tickGenX.MinorTickGenerator = minorTickGenX;

            tickGenX.TargetTickCount = 25;
            // tell our major tick generator to only show major ticks that are whole integers
            tickGenX.IntegerTicksOnly = true;
            // tell our custom tick generator to use our new label formatter
            tickGenX.LabelFormatter = LogTickLabelFormatter;
            thdPlot.Plot.Axes.Bottom.TickGenerator = tickGenX;


            // show grid lines for minor ticks
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.10);
            thdPlot.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            if (cmbGraph_VoltageStart.SelectedIndex > -1 && cmbGraph_VoltageEnd.SelectedIndex > -1 && cmbD_Graph_Bottom.SelectedIndex > -1 && cmbD_Graph_Top.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(GraphSettings.VoltageRange_Start), Math.Log10(GraphSettings.VoltageRange_End), Math.Log10(GraphSettings.D_PercentBottom), Math.Log10(GraphSettings.D_PercentTop));
           
            thdPlot.Plot.Title($"Distortion (%) - Frequency: {MeasurementSettings.Frequency} Hz - Load: {MeasurementSettings.Load} Ω");

            thdPlot.Plot.Axes.Title.Label.FontSize = 17;

            if (cmbXAxis.SelectedIndex == (int)E_X_AxisType.OUTPUT_VOLTAGE)
                thdPlot.Plot.XLabel("Output voltage (Vrms)");
            else if (cmbXAxis.SelectedIndex == (int)E_X_AxisType.OUTPUT_POWER)
                thdPlot.Plot.XLabel("Output power (W)");
            else if (cmbXAxis.SelectedIndex == (int)E_X_AxisType.INPUT_VOLTAGE)
                thdPlot.Plot.XLabel("Input voltage (Vrms)");

            thdPlot.Plot.Axes.Bottom.Label.OffsetX = 330;
            thdPlot.Plot.Axes.Bottom.Label.FontSize = 15;
            thdPlot.Plot.Axes.Bottom.Label.Bold = false;


            thdPlot.Plot.Legend.IsVisible = true;
            thdPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
            thdPlot.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;
            thdPlot.Plot.ShowLegend();

            ScottPlot.AxisRules.MaximumBoundary rule = new(
                xAxis: thdPlot.Plot.Axes.Bottom,
                yAxis: thdPlot.Plot.Axes.Left,
                limits: new AxisLimits(Math.Log10(0), Math.Log10(100), -200, 100)
                );

            thdPlot.Plot.Axes.Rules.Clear();
            thdPlot.Plot.Axes.Rules.Add(rule);

            thdPlot.Refresh();


        }

        /// <summary>
        /// Plot the THD % data
        /// </summary>
        /// <param name="data"></param>
        void PlotThd(ThdAmplitudeMeasurementResult measurementResult, int measurementNr, bool showLeftChannel, bool showRightChannel)
        {
            var freqX = new List<double>();
            var hTotY_left = new List<double>();
            var h2Y_left = new List<double>();
            var h3Y_left = new List<double>();
            var h4Y_left = new List<double>();
            var h5Y_left = new List<double>();
            var h6Y_left = new List<double>();
            var noiseY_left = new List<double>();

            var hTotY_right = new List<double>();
            var h2Y_right = new List<double>();
            var h3Y_right = new List<double>();
            var h4Y_right = new List<double>();
            var h5Y_right = new List<double>();
            var h6Y_right = new List<double>();
            var noiseY_right = new List<double>();

            foreach (var step in measurementResult.AmplitudeSteps)
            {
                double xValue = cmbXAxis.SelectedIndex switch
                {
                    (int)E_X_AxisType.OUTPUT_VOLTAGE => step.Left.Fundamental_V,
                    (int)E_X_AxisType.OUTPUT_POWER => step.Left.Power_Watt,
                    _ => step.GeneratorVoltage
                };
                freqX.Add(xValue);

                if (showLeftChannel && measurementResult.MeasurementSettings.EnableLeftChannel)
                {
                    if (step.Left.Harmonics.Count > 0 && GraphSettings.ShowTHD)
                        hTotY_left.Add(step.Left.Thd_Percent);
                    if (step.Left.Harmonics.Count > 0 && GraphSettings.ShowD2)
                        h2Y_left.Add(step.Left.Harmonics[0].Thd_Percent);
                    if (step.Left.Harmonics.Count > 1 && GraphSettings.ShowD3)
                        h3Y_left.Add(step.Left.Harmonics[1].Thd_Percent);
                    if (step.Left.Harmonics.Count > 2 && GraphSettings.ShowD4)
                        h4Y_left.Add(step.Left.Harmonics[2].Thd_Percent);
                    if (step.Left.Harmonics.Count > 3 && GraphSettings.ShowD5)
                        h5Y_left.Add(step.Left.Harmonics[3].Thd_Percent);
                    if (step.Left.Harmonics.Count > 4 && step.Left.ThdPercent_D6plus != 0 && GraphSettings.ShowD6)
                        h6Y_left.Add(step.Left.ThdPercent_D6plus);        // D6+
                    if (GraphSettings.ShowNoiseFloor)
                        noiseY_left.Add((step.Left.Average_NoiseFloor_V / step.Left.Fundamental_V) * 100);
                }

                if (showRightChannel && measurementResult.MeasurementSettings.EnableRightChannel)
                {
                    if (step.Right.Harmonics.Count > 0 && GraphSettings.ShowTHD)
                        hTotY_right.Add(step.Right.Thd_Percent);
                    if (step.Right.Harmonics.Count > 0 && GraphSettings.ShowD2)
                        h2Y_right.Add(step.Right.Harmonics[0].Thd_Percent);
                    if (step.Right.Harmonics.Count > 1 && GraphSettings.ShowD3)
                        h3Y_right.Add(step.Right.Harmonics[1].Thd_Percent);
                    if (step.Right.Harmonics.Count > 2 && GraphSettings.ShowD4)
                        h4Y_right.Add(step.Right.Harmonics[2].Thd_Percent);
                    if (step.Right.Harmonics.Count > 3 && GraphSettings.ShowD5)
                        h5Y_right.Add(step.Right.Harmonics[3].Thd_Percent);
                    if (step.Right.Harmonics.Count > 4 && step.Right.ThdPercent_D6plus != 0 && GraphSettings.ShowD6)
                        h6Y_right.Add(step.Right.ThdPercent_D6plus);        // D6+
                    if (GraphSettings.ShowNoiseFloor)
                        noiseY_right.Add((step.Right.Average_NoiseFloor_V / step.Right.Fundamental_V) * 100);
                }
            }

            var colors = new GraphColors();
            float lineWidth = GraphSettings.ThickLines ? 1.6f : 1;
            float markerSize = GraphSettings.ShowDataPoints ? lineWidth + 3 : 1;

            double[] logFreqX = freqX.Select(Math.Log10).ToArray();
            int color = measurementNr * 2;

            void AddPlot(List<double> yValues, int colorIndex, string legendText, LinePattern linePattern)
            {
                if (yValues.Count == 0) return;
                double[] logYValues = yValues.Select(Math.Log10).ToArray();
                var plot = thdPlot.Plot.Add.Scatter(logFreqX, logYValues);
                plot.LineWidth = lineWidth;
                plot.Color = colors.GetColor(colorIndex, color);
                plot.MarkerSize = markerSize;
                plot.LegendText = legendText;
                plot.LinePattern = linePattern;
            }

            if (showLeftChannel)
            {
                if (GraphSettings.ShowTHD) AddPlot(hTotY_left, 8, showRightChannel ? "THD-L" : "THD", LinePattern.Solid);
                if (GraphSettings.ShowD2) AddPlot(h2Y_left, 0, showRightChannel ? "D2-L" : "D2", LinePattern.Solid);
                if (GraphSettings.ShowD3) AddPlot(h3Y_left, 1, showRightChannel ? "D3-L" : "D3", LinePattern.Solid);
                if (GraphSettings.ShowD4) AddPlot(h4Y_left, 2, showRightChannel ? "D4-L" : "D4", LinePattern.Solid);
                if (GraphSettings.ShowD5) AddPlot(h5Y_left, 3, showRightChannel ? "D5-L" : "D5", LinePattern.Solid);
                if (GraphSettings.ShowD6) AddPlot(h6Y_left, 4, showRightChannel ? "D6+-L" : "D6+", LinePattern.Solid);
                if (GraphSettings.ShowNoiseFloor) AddPlot(noiseY_left, 9, showRightChannel ? "Noise-L" : "Noise", showRightChannel ? LinePattern.Solid : LinePattern.Dotted);
            }

            if (showRightChannel)
            {
                if (GraphSettings.ShowTHD) AddPlot(hTotY_right, 8, showLeftChannel ? "THD-R" : "THD", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD2) AddPlot(h2Y_right, 0, showLeftChannel ? "D2-R" : "D2", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD3) AddPlot(h3Y_right, 1, showLeftChannel ? "D3-R" : "D3", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD4) AddPlot(h4Y_right, 2, showLeftChannel ? "D4-R" : "D4", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD5) AddPlot(h5Y_right, 3, showLeftChannel ? "D5-R" : "D5", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD6) AddPlot(h6Y_right, 4, showLeftChannel ? "D6+-R" : "D6+", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowNoiseFloor) AddPlot(noiseY_right, 9, showLeftChannel ? "Noise-R" : "Noise", LinePattern.Dotted);
            }

            if (markerIndex != -1)
                QaLibrary.PlotCursorMarker(thdPlot, lineWidth, LinePattern.Solid, markerDataPoint);

            thdPlot.Refresh();
        }


        /// <summary>
        /// Initialize the THD magnitude (dB) plot
        /// </summary>
        void InitializeMagnitudePlot()
        {
            thdPlot.Plot.Clear();

            // Y - axis
            // create a numeric tick generator that uses our custom minor tick generator
            ScottPlot.TickGenerators.EvenlySpacedMinorTickGenerator minorTickGen = new(1);
            // create a numeric tick generator that uses our custom minor tick generator
            ScottPlot.TickGenerators.NumericAutomatic tickGenY = new();
            tickGenY.TargetTickCount = 15;
            tickGenY.MinorTickGenerator = minorTickGen;

            // tell the left axis to use our custom tick generator
            thdPlot.Plot.Axes.Left.TickGenerator = tickGenY;

            // X - axis
            // create a minor tick generator that places log-distributed minor ticks
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGenX = new();
            // create a numeric tick generator that uses our custom minor tick generator
            ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();
            minorTickGenX.Divisions = 10;
            tickGenX.MinorTickGenerator = minorTickGenX;
            tickGenX.TargetTickCount = 25;
            // tell our major tick generator to only show major ticks that are whole integers
            tickGenX.IntegerTicksOnly = true;
            // tell our custom tick generator to use our new label formatter
            static string LogTickLabelFormatter(double y) => $"{Math.Pow(10, Math.Round(y, 10)):#0.######}";
            tickGenX.LabelFormatter = LogTickLabelFormatter;
            thdPlot.Plot.Axes.Bottom.TickGenerator = tickGenX;


            // show grid lines for minor ticks
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.10);
            thdPlot.Plot.Grid.MinorLineWidth = 1;

            if (cmbGraph_VoltageStart.SelectedIndex > -1 && cmbGraph_VoltageEnd.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(GraphSettings.VoltageRange_Start), Math.Log10(GraphSettings.VoltageRange_End), Convert.ToDouble(ud_dB_Graph_Bottom.Value), Convert.ToDouble(ud_dB_Graph_Top.Value));
            
            thdPlot.Plot.Title("Magnitude (dB)");
            thdPlot.Plot.Axes.Title.Label.FontSize = 17;

            if (cmbXAxis.SelectedIndex == (int)E_X_AxisType.OUTPUT_VOLTAGE)
                thdPlot.Plot.XLabel("Output voltage (Vrms)");
            else if (cmbXAxis.SelectedIndex == (int)E_X_AxisType.OUTPUT_POWER)
                thdPlot.Plot.XLabel("Output power (W)");
            else if (cmbXAxis.SelectedIndex == (int)E_X_AxisType.INPUT_VOLTAGE)
                thdPlot.Plot.XLabel("Input voltage (Vrms)");
            thdPlot.Plot.Axes.Bottom.Label.OffsetX = 330;
            thdPlot.Plot.Axes.Bottom.Label.FontSize = 15;
            thdPlot.Plot.Axes.Bottom.Label.Bold = false;

            // Lengend
            thdPlot.Plot.Legend.IsVisible = true;
            thdPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
            thdPlot.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;
            thdPlot.Plot.ShowLegend();

            ScottPlot.AxisRules.MaximumBoundary rule = new(
                xAxis: thdPlot.Plot.Axes.Bottom,
                yAxis: thdPlot.Plot.Axes.Left,
                limits: new AxisLimits(Math.Log10(0.0001), Math.Log10(100), -200, 100)
                );

            thdPlot.Plot.Axes.Rules.Clear();
            thdPlot.Plot.Axes.Rules.Add(rule);

            thdPlot.Refresh();
        }


        /// <summary>
        /// Plot the  THD magnitude (dB) data
        /// </summary>
        /// <param name="data">The data to plot</param>
        void PlotMagnitude(ThdAmplitudeMeasurementResult measurementResult, int measurementNr, bool showLeftChannel, bool showRightChannel)
        {
            // Create lists for line data
            var amplitudeX_L = new List<double>();
            var amplitudeX_R = new List<double>();
            var magnY_left = new List<double>();
            var hTotY_left = new List<double>();
            var h2Y_left = new List<double>();
            var h3Y_left = new List<double>();
            var h4Y_left = new List<double>();
            var h5Y_left = new List<double>();
            var h6Y_left = new List<double>();
            var noiseY_left = new List<double>();

            var magnY_right = new List<double>();
            var hTotY_right = new List<double>();
            var h2Y_right = new List<double>();
            var h3Y_right = new List<double>();
            var h4Y_right = new List<double>();
            var h5Y_right = new List<double>();
            var h6Y_right = new List<double>();
            var noiseY_right = new List<double>();

            // Add data to the line lists
            foreach (var step in measurementResult.AmplitudeSteps)
            {
                double xValue_L = GraphSettings.XAxisType switch
                {
                    E_X_AxisType.OUTPUT_VOLTAGE => step.Left.Fundamental_V,
                    E_X_AxisType.OUTPUT_POWER => step.Left.Power_Watt,
                    _ => step.GeneratorVoltage
                };
                amplitudeX_L.Add(xValue_L);

                double xValue_R = GraphSettings.XAxisType switch
                {
                    E_X_AxisType.OUTPUT_VOLTAGE => step.Right.Fundamental_V,
                    E_X_AxisType.OUTPUT_POWER => step.Right.Power_Watt,
                    _ => step.GeneratorVoltage
                };
                amplitudeX_R.Add(xValue_R);

                if (showLeftChannel && measurementResult.MeasurementSettings.EnableLeftChannel)
                {
                    if (GraphSettings.ShowMagnitude)
                        magnY_left.Add(step.Left.Gain_dB);

                    if (step.Left.Harmonics.Count > 0)
                    {
                        hTotY_left.Add(step.Left.Thd_dB + step.Left.Gain_dB);
                        h2Y_left.Add(step.Left.Harmonics[0].Amplitude_dBV - step.Left.Fundamental_dBV + step.Left.Gain_dB);
                    }
                    if (step.Left.Harmonics.Count > 1)
                        h3Y_left.Add(step.Left.Harmonics[1].Amplitude_dBV - step.Left.Fundamental_dBV + step.Left.Gain_dB);
                    if (step.Left.Harmonics.Count > 2)
                        h4Y_left.Add(step.Left.Harmonics[2].Amplitude_dBV - step.Left.Fundamental_dBV + step.Left.Gain_dB);
                    if (step.Left.Harmonics.Count > 3)
                        h5Y_left.Add(step.Left.Harmonics[3].Amplitude_dBV - step.Left.Fundamental_dBV + step.Left.Gain_dB);
                    if (step.Left.D6Plus_dBV != 0 && step.Left.Harmonics.Count > 4 && GraphSettings.ShowD6)
                        h6Y_left.Add(step.Left.D6Plus_dBV - step.Left.Fundamental_dBV + step.Left.Gain_dB);
                    if (GraphSettings.ShowNoiseFloor)
                        noiseY_left.Add(step.Left.Average_NoiseFloor_dBV - step.Left.Fundamental_dBV + step.Left.Gain_dB);
                }

                if (showRightChannel && measurementResult.MeasurementSettings.EnableRightChannel)
                {
                    if (GraphSettings.ShowMagnitude)
                        magnY_right.Add(step.Right.Gain_dB);

                    if (step.Right.Harmonics.Count > 0)
                    {
                        hTotY_right.Add(step.Right.Thd_dB + step.Right.Gain_dB);
                        h2Y_right.Add(step.Right.Harmonics[0].Amplitude_dBV - step.Right.Fundamental_dBV + step.Right.Gain_dB);
                    }
                    if (step.Right.Harmonics.Count > 1)
                        h3Y_right.Add(step.Right.Harmonics[1].Amplitude_dBV - step.Right.Fundamental_dBV + step.Right.Gain_dB);
                    if (step.Right.Harmonics.Count > 2)
                        h4Y_right.Add(step.Right.Harmonics[2].Amplitude_dBV - step.Right.Fundamental_dBV + step.Right.Gain_dB);
                    if (step.Right.Harmonics.Count > 3)
                        h5Y_right.Add(step.Right.Harmonics[3].Amplitude_dBV - step.Right.Fundamental_dBV + step.Right.Gain_dB);
                    if (step.Right.D6Plus_dBV != 0 && step.Right.Harmonics.Count > 4 && GraphSettings.ShowD6)
                        h6Y_right.Add(step.Right.D6Plus_dBV - step.Right.Fundamental_dBV + step.Right.Gain_dB);
                    if (GraphSettings.ShowNoiseFloor)
                        noiseY_right.Add(step.Right.Average_NoiseFloor_dBV - step.Right.Fundamental_dBV + step.Right.Gain_dB);
                }
            }

            // add a scatter plot to the plot
            double[] logAmplitudeX_L = amplitudeX_L.Select(Math.Log10).ToArray();
            double[] logAmplitudeX_R = amplitudeX_R.Select(Math.Log10).ToArray();
            float lineWidth = GraphSettings.ThickLines ? 1.6f : 1;
            float markerSize = GraphSettings.ShowDataPoints ? lineWidth + 3 : 1;

            var colors = new GraphColors();
            int color = measurementNr * 2;

            void AddPlot(double[] xValues, List<double> yValues, int colorIndex, string legendText, LinePattern linePattern)
            {
                if (yValues.Count == 0) return;
                
                var plot = thdPlot.Plot.Add.Scatter(xValues, yValues.ToArray());
                plot.LineWidth = lineWidth;
                plot.Color = colors.GetColor(colorIndex, color);
                plot.MarkerSize = markerSize;
                plot.LegendText = legendText;
                plot.LinePattern = linePattern;
            }

            if (showLeftChannel)
            {
                if (GraphSettings.ShowMagnitude) AddPlot(logAmplitudeX_L, magnY_left, 9, showRightChannel ? "Magn-L" : "Magn", LinePattern.DenselyDashed);
                if (GraphSettings.ShowTHD) AddPlot(logAmplitudeX_L, hTotY_left, 8, showRightChannel ? "THD-L" : "THD", LinePattern.Solid);
                if (GraphSettings.ShowD2) AddPlot(logAmplitudeX_L, h2Y_left, 0, showRightChannel ? "H2-L" : "H2", LinePattern.Solid);
                if (GraphSettings.ShowD3) AddPlot(logAmplitudeX_L, h3Y_left, 1, showRightChannel ? "H3-L" : "H3", LinePattern.Solid);
                if (GraphSettings.ShowD4) AddPlot(logAmplitudeX_L, h4Y_left, 2, showRightChannel ? "H4-L" : "H4", LinePattern.Solid);
                if (GraphSettings.ShowD5) AddPlot(logAmplitudeX_L, h5Y_left, 3, showRightChannel ? "H5-L" : "H5", LinePattern.Solid);
                if (GraphSettings.ShowD6) AddPlot(logAmplitudeX_L, h6Y_left, 4, showRightChannel ? "H6+-L" : "H6+", LinePattern.Solid);
                if (GraphSettings.ShowNoiseFloor) AddPlot(logAmplitudeX_L, noiseY_left, 9, showRightChannel ? "Noise-L" : "Noise", showRightChannel ? LinePattern.Solid : LinePattern.Dotted);
            }

            if (showRightChannel)
            {
                if (GraphSettings.ShowMagnitude) AddPlot(logAmplitudeX_R, magnY_right, 9, showLeftChannel ? "Magn-R" : "Magn", showLeftChannel ? LinePattern.Dotted : LinePattern.DenselyDashed);
                if (GraphSettings.ShowTHD) AddPlot(logAmplitudeX_R, hTotY_right, 8, showLeftChannel ? "THD-R" : "THD", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD2) AddPlot(logAmplitudeX_R, h2Y_right, 0, showLeftChannel ? "H2-R" : "H2", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD3) AddPlot(logAmplitudeX_R, h3Y_right, 1, showLeftChannel ? "H3-R" : "H3", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD4) AddPlot(logAmplitudeX_R, h4Y_right, 2, showLeftChannel ? "H4-R" : "H4", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD5) AddPlot(logAmplitudeX_R, h5Y_right, 3, showLeftChannel ? "H5-R" : "H5", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowD6) AddPlot(logAmplitudeX_R, h6Y_right, 4, showLeftChannel ? "H6+-R" : "H6+", showLeftChannel ? LinePattern.DenselyDashed : LinePattern.Solid);
                if (GraphSettings.ShowNoiseFloor) AddPlot(logAmplitudeX_R, noiseY_right, 9, showLeftChannel ? "Noise-R" : "Noise", LinePattern.Dotted);
            }

            // If marker selected draw marker line
            if (markerIndex != -1)
                QaLibrary.PlotCursorMarker(thdPlot, lineWidth, LinePattern.Solid, markerDataPoint);

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
                SetCursorMarker(s, e, true);      // Set persistent marker
            };

            // Mouse is leaving the graph
            thdPlot.SKControl.MouseLeave += (s, e) =>
            {
                // If persistent marker set then show mini plots of that marker
                if (markerIndex >= 0)
                {
                    QaLibrary.PlotMiniFftGraph(graphFft, MeasurementResult.AmplitudeSteps[markerIndex].fftData, MeasurementResult.MeasurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, MeasurementResult.MeasurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);
                    QaLibrary.PlotMiniTimeGraph(graphTime, MeasurementResult.AmplitudeSteps[markerIndex].timeData, MeasurementResult.AmplitudeSteps[markerIndex].FundamentalFrequency, MeasurementResult.MeasurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, MeasurementResult.MeasurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);
                }
            };

        }

        /// <summary>
        /// Show the mini graphs fot the frequency where the mouse cursor is pointing to
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
            if (nearest1.IsReal && MeasurementResult.AmplitudeSteps.Count > nearest1.Index)
            {
                QaLibrary.PlotMiniFftGraph(graphFft, MeasurementResult.AmplitudeSteps[nearest1.Index].fftData, MeasurementResult.MeasurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, MeasurementResult.MeasurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);
                QaLibrary.PlotMiniTimeGraph(graphTime, MeasurementResult.AmplitudeSteps[nearest1.Index].timeData, MeasurementResult.AmplitudeSteps[nearest1.Index].FundamentalFrequency, MeasurementResult.MeasurementSettings.EnableLeftChannel && GraphSettings.ShowLeftChannel, MeasurementResult.MeasurementSettings.EnableRightChannel && GraphSettings.ShowRightChannel);
            }
        }


        int markerIndex = -1;
        DataPoint markerDataPoint;

        /// <summary>
        /// Set a cursor marker
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        /// <param name="isClick"></param>
        void SetCursorMarker(object s, MouseEventArgs e, bool isClick)
        {
            if (MeasurementBusy)            // Do not show marker when measurement is still busy
                return;

            // determine where the mouse is and get the nearest point
            Pixel mousePixel = new(e.Location.X, e.Location.Y);
            Coordinates mouseLocation = thdPlot.Plot.GetCoordinates(mousePixel);
            if (thdPlot.Plot.GetPlottables<Scatter>().Count() == 0) 
                return;                     // Nothing plotted

            // Get nearest x-location in plot
            DataPoint nearest1 = new();

            for (int i = 0; i < thdPlot.Plot.GetPlottables<Scatter>().Count(); i++)
            {
                nearest1 = thdPlot.Plot.GetPlottables<Scatter>().ToList()[i].Data.GetNearestX(mouseLocation, thdPlot.Plot.LastRender);
                if (nearest1.IsReal)
                    break;
            }

            // place the crosshair over the highlighted point
            if (nearest1.IsReal)
            {
                float lineWidth = (GraphSettings.ThickLines ? 1.6f : 1);
                LinePattern linePattern = LinePattern.DenselyDashed;

                if (isClick)
                {
                    // Mouse click
                    if (nearest1.Index == markerIndex)          // Clicked point is currently marked
                    {
                        // Remove marker
                        markerIndex = -1;
                        thdPlot.Plot.Remove<Crosshair>();
                        return;
                    }
                    else
                    {
                        // Add solid marker line
                        markerIndex = nearest1.Index;           // Remember marker
                        markerDataPoint = nearest1;
                        linePattern = LinePattern.Solid;
                    }
                }
                else
                {
                    // Mouse hoover
                    if (markerIndex != -1)
                        return;                                 // Do not show new marker. There is already a clicked marker
                }

                QaLibrary.PlotCursorMarker(thdPlot, lineWidth, linePattern, nearest1);

                // Check if index in StepData array
                if (MeasurementResult.AmplitudeSteps.Count > nearest1.Index)
                {
                    var xAxisValue = Math.Pow(10, nearest1.X);
                    //var step_l = MeasurementResult.AmplitudeSteps[nearest1.Index];

                    //var step_l = MeasurementResult.AmplitudeSteps.Where(n => n.Left.Fundamental_V >= xAxisValue * 0.9 && n.Left.Fundamental_V <= xAxisValue * 1.1).FirstOrDefault();
                    //var step_r = MeasurementResult.AmplitudeSteps.Where(n => n.Right.Fundamental_V >= xAxisValue * 0.9 && n.Right.Fundamental_V <= xAxisValue * 1.1).FirstOrDefault();

                    ThdAmplitudeStep step_l = null;
                    ThdAmplitudeStep step_r = null;

                    var minSelection_l = MeasurementResult.AmplitudeSteps.Where(n => n.Left.Fundamental_V >= xAxisValue * 0.9 && n.Left.Fundamental_V <= xAxisValue * 1.1);
                    if (minSelection_l.Any())
                    {
                        var minDistance_l = minSelection_l.Min(n => Math.Abs(xAxisValue - n.Left.Fundamental_V));
                        step_l = MeasurementResult.AmplitudeSteps.First(n => Math.Abs(xAxisValue - n.Left.Fundamental_V) == minDistance_l);
                    }

                    var minSelection_r = MeasurementResult.AmplitudeSteps.Where(n => n.Right.Fundamental_V >= xAxisValue * 0.9 && n.Right.Fundamental_V <= xAxisValue * 1.1);
                    if (minSelection_r.Any())
                    {
                        var minDistance_r = minSelection_r.Min(n => Math.Abs(xAxisValue - n.Right.Fundamental_V));
                        step_r = MeasurementResult.AmplitudeSteps.First(n => Math.Abs(xAxisValue - n.Right.Fundamental_V) == minDistance_r);
                    }

                    // Write cursor texts based in plot type
                    if (GraphSettings.GraphType == E_ThdAmplitude_GraphType.DB)
                    {
                        if (step_l != null)
                        {
                            WriteCursorTexts_dB_L(step_l.GeneratorVoltage
                            , step_l.Left.Fundamental_V
                            , step_l.Left.Gain_dB
                            , step_l.Left.Thd_dB - step_l.Left.Fundamental_dBV
                            , (step_l.Left.Harmonics.Count > 0 ? step_l.Left.Harmonics[0].Amplitude_dBV - step_l.Left.Fundamental_dBV : 0)   // 2nd harmonic
                            , (step_l.Left.Harmonics.Count > 1 ? step_l.Left.Harmonics[1].Amplitude_dBV - step_l.Left.Fundamental_dBV : 0)
                            , (step_l.Left.Harmonics.Count > 2 ? step_l.Left.Harmonics[2].Amplitude_dBV - step_l.Left.Fundamental_dBV : 0)
                            , (step_l.Left.Harmonics.Count > 3 ? step_l.Left.Harmonics[3].Amplitude_dBV - step_l.Left.Fundamental_dBV : 0)
                            , (step_l.Left.Harmonics.Count > 4 ? step_l.Left.D6Plus_dBV - step_l.Left.Fundamental_dBV : 0)                   // 6+ harmonics
                            , step_l.Left.Power_Watt
                            , step_l.Left.Average_NoiseFloor_dBV - step_l.Left.Fundamental_dBV
                            , MeasurementResult.MeasurementSettings.Load
                            );
                        }
                        else
                            WriteCursorTexts_dB_L(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                        if (step_r != null)
                        {
                            WriteCursorTexts_dB_R(step_r.GeneratorVoltage
                            , step_r.Right.Fundamental_V
                            , step_r.Right.Gain_dB
                            , step_r.Right.Thd_dB - step_r.Right.Fundamental_dBV
                            , (step_r.Right.Harmonics.Count > 0 ? step_r.Right.Harmonics[0].Amplitude_dBV - step_r.Right.Fundamental_dBV : 0)   // 2nd harmonic
                            , (step_r.Right.Harmonics.Count > 1 ? step_r.Right.Harmonics[1].Amplitude_dBV - step_r.Right.Fundamental_dBV : 0)
                            , (step_r.Right.Harmonics.Count > 2 ? step_r.Right.Harmonics[2].Amplitude_dBV - step_r.Right.Fundamental_dBV : 0)
                            , (step_r.Right.Harmonics.Count > 3 ? step_r.Right.Harmonics[3].Amplitude_dBV - step_r.Right.Fundamental_dBV : 0)
                            , (step_r.Right.Harmonics.Count > 4 ? step_r.Right.D6Plus_dBV - step_r.Right.Fundamental_dBV : 0)                   // 6+ harmonics
                            , step_r.Right.Power_Watt
                            , step_r.Right.Average_NoiseFloor_dBV - step_r.Right.Fundamental_dBV
                            , MeasurementResult.MeasurementSettings.Load
                            );
                        }
                        else
                            WriteCursorTexts_dB_R(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    }
                    else
                    {
                        if (step_l != null)
                        {
                            WriteCursorTexts_Dpercent_L(step_l.GeneratorVoltage
                            , step_l.Left.Fundamental_V
                            , step_l.Left.Gain_dB
                            , step_l.Left.Thd_Percent
                            , (step_l.Left.Harmonics.Count > 0 ? step_l.Left.Harmonics[0].Thd_Percent : 0)     // 2nd harmonic
                            , (step_l.Left.Harmonics.Count > 1 ? step_l.Left.Harmonics[1].Thd_Percent : 0)
                            , (step_l.Left.Harmonics.Count > 2 ? step_l.Left.Harmonics[2].Thd_Percent : 0)
                            , (step_l.Left.Harmonics.Count > 3 ? step_l.Left.Harmonics[3].Thd_Percent : 0)
                            , (step_l.Left.Harmonics.Count > 4 ? step_l.Left.ThdPercent_D6plus : 0)                   // 6+ harmonics
                            , step_l.Left.Power_Watt
                            , (step_l.Left.Average_NoiseFloor_V / step_l.Left.Fundamental_V) * 100
                            , MeasurementResult.MeasurementSettings.Load
                            );
                        }
                        else
                            WriteCursorTexts_dB_L(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

                        if (step_r != null)
                        {
                            WriteCursorTexts_Dpercent_R(step_r.GeneratorVoltage
                            , step_r.Right.Fundamental_V
                            , step_r.Right.Gain_dB
                            , step_r.Right.Thd_Percent
                            , (step_r.Right.Harmonics.Count > 0 ? step_r.Right.Harmonics[0].Thd_Percent : 0)     // 2nd harmonic
                            , (step_r.Right.Harmonics.Count > 1 ? step_r.Right.Harmonics[1].Thd_Percent : 0)
                            , (step_r.Right.Harmonics.Count > 2 ? step_r.Right.Harmonics[2].Thd_Percent : 0)
                            , (step_r.Right.Harmonics.Count > 3 ? step_r.Right.Harmonics[3].Thd_Percent : 0)
                            , (step_r.Right.Harmonics.Count > 4 ? step_r.Right.ThdPercent_D6plus : 0)                   // 6+ harmonics
                            , step_r.Right.Power_Watt
                            , (step_r.Right.Average_NoiseFloor_V / step_r.Right.Fundamental_V) * 100
                            , MeasurementResult.MeasurementSettings.Load
                            );
                        }
                        else
                            WriteCursorTexts_dB_R(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                    }
                }

            }
        }

        

        /// <summary>
        /// Start measurement button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnStartThdMeasurement_Click(object sender, EventArgs e)
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
        /// Start voltage unit is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbStartVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EndAmplitudeUnit = (E_VoltageUnit)cmbStartVoltageUnit.SelectedIndex;
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        private void cmbEndVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EndAmplitudeUnit = (E_VoltageUnit)cmbEndVoltageUnit.SelectedIndex;
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        
        private void txtStartVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Text has been changed by user typing. Remember unit
            MeasurementSettings.StartAmplitudeUnit = (E_VoltageUnit)cmbStartVoltageUnit.SelectedIndex;
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        private void txtEndVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Text has been changed by user typing. Remember unit
            MeasurementSettings.EndAmplitudeUnit = (E_VoltageUnit)cmbEndVoltageUnit.SelectedIndex;
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        private void txtStartVoltage_TextChanged(object sender, EventArgs e)
        {
            MeasurementSettings.StartAmplitude = QaLibrary.ParseTextToDouble(txtStartVoltage.Text, MeasurementSettings.StartAmplitude);
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        private void txtEndVoltage_TextChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EndAmplitude = QaLibrary.ParseTextToDouble(txtEndVoltage.Text, MeasurementSettings.EndAmplitude);
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        /// <summary>
        /// Chcek if the start voltage is lower then the end voltage and within the device measurement range
        /// </summary>
        /// <param name="sender"></param>
        private void ValidateStartVoltage(object sender)
        {
            if (cmbStartVoltageUnit.SelectedIndex == (int)E_VoltageUnit.MilliVolt)
            {
                double endVoltageMv = QaLibrary.ConvertVoltage(MeasurementSettings.EndAmplitude, MeasurementSettings.EndAmplitudeUnit, E_VoltageUnit.MilliVolt); // Convert to mV
                endVoltageMv = (endVoltageMv > QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV ? QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV : endVoltageMv);
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV, endVoltageMv);        // mV
            }
            else
            {
                double endVoltageV = QaLibrary.ConvertVoltage(MeasurementSettings.EndAmplitude, MeasurementSettings.EndAmplitudeUnit, E_VoltageUnit.Volt); // Convert to V
                endVoltageV = (endVoltageV > QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_V ? QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_V : endVoltageV);
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V, endVoltageV);     // V 
            }
        }


        /// <summary>
        /// Chcek if the end voltage is higher then the start voltage and within the device measurement range
        /// </summary>
        /// <param name="sender"></param>
        private void ValidateEndVoltage(object sender)
        {
            if (cmbEndVoltageUnit.SelectedIndex == (int)E_VoltageUnit.MilliVolt)
            {
                double startVoltageMv = QaLibrary.ConvertVoltage(MeasurementSettings.StartAmplitude, MeasurementSettings.StartAmplitudeUnit, E_VoltageUnit.MilliVolt); // Convert to mV
                startVoltageMv = (startVoltageMv < QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV ? QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV : startVoltageMv);
                QaLibrary.ValidateRangeAdorner(sender, startVoltageMv, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV);        // mV
            }
            else
            {
                double startVoltageV = QaLibrary.ConvertVoltage(MeasurementSettings.StartAmplitude, MeasurementSettings.StartAmplitudeUnit, E_VoltageUnit.Volt); // Convert to V
                startVoltageV = (startVoltageV < QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V ? QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V : startVoltageV);
                QaLibrary.ValidateRangeAdorner(sender, startVoltageV, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_V);     // V 
            }
        }



        private void txtOutputLoad_TextChanged(object sender, EventArgs e)
        {
            MeasurementSettings.Load = QaLibrary.ParseTextToDouble(txtOutputLoad.Text, MeasurementSettings.Load);
            QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_LOAD, QaLibrary.MAXIMUM_LOAD);
        }


        private void udStepsOctave_ValueChanged(object sender, EventArgs e)
        {
            MeasurementSettings.StepsPerOctave = Convert.ToUInt16(udStepsOctave.Value);
        }

        private void udAverages_ValueChanged(object sender, EventArgs e)
        {
            MeasurementSettings.Averages = Convert.ToUInt16(udAverages.Value);
        }

        private void txtOutputVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        private void txtStartFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, true);
        }

     
        private void txtFrequency_TextChanged(object sender, EventArgs e)
        {
            QaLibrary.ValidateRangeAdorner(sender, 5, 96000);
            MeasurementSettings.Frequency = QaLibrary.ParseTextToDouble(txtFrequency.Text, MeasurementSettings.Frequency);
        }

        private void txtOutputLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }


        private void btnGraph_dB_Click(object sender, EventArgs e)
        {
            GraphSettings.GraphType = E_ThdAmplitude_GraphType.DB;
            ClearCursorTexts();
            UpdateGraph(true);
        }

        private void btnGraph_D_Click(object sender, EventArgs e)
        {
            GraphSettings.GraphType = E_ThdAmplitude_GraphType.D_PERCENT;
            ClearCursorTexts();
            UpdateGraph(true);
        }



        private void UpdateGraph(bool settingsChanged)
        {
            thdPlot.Plot.Remove<Scatter>();             // Remove all current lines
            int resultNr = 0;

            if (GraphSettings.GraphType == E_ThdAmplitude_GraphType.DB)
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


        private void btnFitDGraphY_Click(object sender, EventArgs e)
        {
            if (MeasurementResult.AmplitudeSteps.Count == 0)
                return;

            // Determine top Y
            double maxThd_left = MeasurementResult.AmplitudeSteps.Max(d => d.Left.Thd_Percent);
            double maxThd_right = MeasurementResult.AmplitudeSteps.Max(d => d.Right.Thd_Percent);
            double max = Math.Max(maxThd_left, maxThd_right);

            if (max <= 1)
                cmbD_Graph_Top.SelectedIndex = 2;
            else if (max <= 10)
                cmbD_Graph_Top.SelectedIndex = 1;
            else
                cmbD_Graph_Top.SelectedIndex = 0;


            // Determine bottom Y
            double minThd_left = MeasurementResult.AmplitudeSteps.Min(d => (d.Left.Average_NoiseFloor_V / d.Left.Fundamental_V) * 100);
            double minD2_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 1).Min(d => (d.Left.Harmonics[0].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD3_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 2).Min(d => (d.Left.Harmonics[1].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD4_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 3).Min(d => (d.Left.Harmonics[2].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD5_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 4).Min(d => (d.Left.Harmonics[3].Amplitude_V / d.Left.Fundamental_V) * 100);
            double minD6_left = MeasurementResult.AmplitudeSteps.Min(d => d.Left.ThdPercent_D6plus);

            double min = Math.Min(minThd_left, minD2_left);
            min = Math.Min(min, minD3_left);
            min = Math.Min(min, minD4_left);
            min = Math.Min(min, minD5_left);

            double minThd_right = MeasurementResult.AmplitudeSteps.Min(d => (d.Right.Average_NoiseFloor_V / d.Right.Fundamental_V) * 100);
            double minD2_right = MeasurementResult.AmplitudeSteps.Where(d => d.Right.Harmonics.Count >= 1).Min(d => (d.Right.Harmonics[0].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD3_right = MeasurementResult.AmplitudeSteps.Where(d => d.Right.Harmonics.Count >= 2).Min(d => (d.Right.Harmonics[1].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD4_right = MeasurementResult.AmplitudeSteps.Where(d => d.Right.Harmonics.Count >= 3).Min(d => (d.Right.Harmonics[2].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD5_right = MeasurementResult.AmplitudeSteps.Where(d => d.Right.Harmonics.Count >= 4).Min(d => (d.Right.Harmonics[3].Amplitude_V / d.Right.Fundamental_V) * 100);
            double minD6_right = MeasurementResult.AmplitudeSteps.Min(d => d.Right.ThdPercent_D6plus);

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

        private void btnFitDbGraphY_Click(object sender, EventArgs e)
        {

            if (MeasurementResult.AmplitudeSteps.Count == 0)
                return;

            // Determine top Y
            double maxGain_left = MeasurementResult.AmplitudeSteps.Max(d => d.Left.Gain_dB);
            double maxGain_right = MeasurementResult.AmplitudeSteps.Max(d => d.Right.Gain_dB);
            double max = Math.Max(maxGain_left, maxGain_right);
            ud_dB_Graph_Top.Value = (Math.Ceiling((decimal)((int)max) / 10) * 10) + 20;


            // Determine bottom Y
            double minDb_left = MeasurementResult.AmplitudeSteps.Min(d => d.Left.Average_NoiseFloor_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD2_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 1).Min(d => d.Left.Harmonics[0].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD3_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 2).Min(d => d.Left.Harmonics[1].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD4_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 3).Min(d => d.Left.Harmonics[2].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD5_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 4).Min(d => d.Left.Harmonics[3].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD6_left = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 5).Min(d => d.Left.Harmonics[4].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;

            double min = Math.Min(minDb_left, minD2_left);
            min = Math.Min(min, minD3_left);
            min = Math.Min(min, minD4_left);
            min = Math.Min(min, minD5_left);

            double minDb_right = MeasurementResult.AmplitudeSteps.Min(d => d.Left.Average_NoiseFloor_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD2_right = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 1).Min(d => d.Left.Harmonics[0].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD3_right = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 2).Min(d => d.Left.Harmonics[1].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD4_right = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 3).Min(d => d.Left.Harmonics[2].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD5_right = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 4).Min(d => d.Left.Harmonics[3].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;
            double minD6_right = MeasurementResult.AmplitudeSteps.Where(d => d.Left.Harmonics.Count >= 5).Min(d => d.Left.Harmonics[4].Amplitude_dBV) - MeasurementResult.AmplitudeSteps.Average(d => d.Left.Fundamental_dBV) + MeasurementResult.AmplitudeSteps[0].Left.Gain_dB;

            min = Math.Min(min, minDb_right);
            min = Math.Min(min, minD2_right);
            min = Math.Min(min, minD3_right);
            min = Math.Min(min, minD4_right);
            min = Math.Min(min, minD5_right);

            ud_dB_Graph_Bottom.Value = Math.Ceiling((decimal)((int)(min / 10) - 1) * 10);        // Round to 10, subtract 10
        }

        
        /// <summary>
        /// Measurement cancel button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopThdMeasurement_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        private void lblThdFreq_GenVoltage_Click(object sender, EventArgs e)
        {

        }

        private void btnAutoFitX_Click(object sender, EventArgs e)
        {
            double min = 0, max = 0;
            double min_left = 0, max_left = 0;
            double min_right = 0, max_right = 0;

            if (MeasurementResult.AmplitudeSteps.Count == 0)
                return;

            switch ((int)GraphSettings.XAxisType)
            {
                case 0:
                    min_left = MeasurementResult.AmplitudeSteps.Min(v => v.Left.Fundamental_V);
                    max_left = MeasurementResult.AmplitudeSteps.Max(v => v.Left.Fundamental_V);
                    min_right = MeasurementResult.AmplitudeSteps.Min(v => v.Right.Fundamental_V);
                    max_right = MeasurementResult.AmplitudeSteps.Max(v => v.Right.Fundamental_V);
                    break;
                case 1:
                    min_left = MeasurementResult.AmplitudeSteps.Min(v => v.Left.Power_Watt);
                    max_left = MeasurementResult.AmplitudeSteps.Max(v => v.Left.Power_Watt);
                    min_right = MeasurementResult.AmplitudeSteps.Min(v => v.Right.Power_Watt);
                    max_right = MeasurementResult.AmplitudeSteps.Max(v => v.Right.Power_Watt);
                    break;
                case 2:
                    min_left = MeasurementResult.AmplitudeSteps.Min(v => v.GeneratorVoltage);
                    max_left = MeasurementResult.AmplitudeSteps.Max(v => v.GeneratorVoltage);
                    break;
            }
            min = Math.Min(min_left, min_right);
            max = Math.Max(max_left, max_right);


            if (min < 0.0002)
                cmbGraph_VoltageStart.SelectedIndex = 0;
            else if (min < 0.0005)
                cmbGraph_VoltageStart.SelectedIndex = 1;
            else if (min < 0.001)
                cmbGraph_VoltageStart.SelectedIndex = 2;
            else if (min < 0.002)
                cmbGraph_VoltageStart.SelectedIndex = 3;
            else if (min < 0.005)
                cmbGraph_VoltageStart.SelectedIndex = 6;
            else if (min < 0.01)
                cmbGraph_VoltageStart.SelectedIndex = 5;
            else if (min < 0.02)
                cmbGraph_VoltageStart.SelectedIndex = 6;
            else if (min < 0.05)
                cmbGraph_VoltageStart.SelectedIndex = 7;
            else if (min < 0.1)
                cmbGraph_VoltageStart.SelectedIndex = 8;
            else if (min < 0.2)
                cmbGraph_VoltageStart.SelectedIndex = 9;
            else if (min < 0.5)
                cmbGraph_VoltageStart.SelectedIndex = 10;
            else
                cmbGraph_VoltageStart.SelectedIndex = 11;



            if (max <= 1)
                cmbGraph_VoltageEnd.SelectedIndex = 0;
            else if (max <= 2)
                cmbGraph_VoltageEnd.SelectedIndex = 1;
            else if (max <= 5)
                cmbGraph_VoltageEnd.SelectedIndex = 2;
            else if (max <= 10)
                cmbGraph_VoltageEnd.SelectedIndex = 3;
            else if (max <= 20)
                cmbGraph_VoltageEnd.SelectedIndex = 4;
            else if (max <= 50)
                cmbGraph_VoltageEnd.SelectedIndex = 5;
            else if (max <= 100)
                cmbGraph_VoltageEnd.SelectedIndex = 6;
            else
                cmbGraph_VoltageEnd.SelectedIndex = 7;
        }

        private void cmbXAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            switch (cmbXAxis.SelectedIndex)
            {
                case 0:
                case 2:
                    gbXAxisRange.Text = "Voltage range";
                    break;
                case 1:
                    gbXAxisRange.Text = "Power range";
                    break;
            }
            GraphSettings.XAxisType = (E_X_AxisType)cmbXAxis.SelectedIndex;

            UpdateGraph(true);
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
            // Prevent top lower than bottom
            if (ud_dB_Graph_Top.Value - ud_dB_Graph_Bottom.Value < 1)
            {
                ud_dB_Graph_Top.Value = ud_dB_Graph_Bottom.Value + 1;
            }

            // Change increment when top and bottom closer together
            GraphSettings.DbRangeTop = (double)ud_dB_Graph_Top.Value;
            if (GraphSettings.DbRangeTop - GraphSettings.DbRangeBottom < 20)
            {
                ud_dB_Graph_Top.Increment = 1;
                ud_dB_Graph_Bottom.Increment = 1;
            }
            else if (GraphSettings.DbRangeTop - GraphSettings.DbRangeBottom < 50)
            {
                ud_dB_Graph_Top.Increment = 5;
                ud_dB_Graph_Bottom.Increment = 5;
            }
            else
            {
                ud_dB_Graph_Top.Increment = 10;
                ud_dB_Graph_Bottom.Increment = 10;
            }
            UpdateGraph(true);
        }

        private void ud_dB_Graph_Bottom_ValueChanged(object sender, EventArgs e)
        {
            // Prevent bottom higher than top
            if (ud_dB_Graph_Top.Value - ud_dB_Graph_Bottom.Value < 1)
            {
                ud_dB_Graph_Bottom.Value = ud_dB_Graph_Top.Value - 1;
            }

            // Change increment when top and bottom closer together
            GraphSettings.DbRangeBottom = (double)ud_dB_Graph_Bottom.Value;
            if (GraphSettings.DbRangeTop - GraphSettings.DbRangeBottom < 20)
            {
                ud_dB_Graph_Top.Increment = 1;
                ud_dB_Graph_Bottom.Increment = 1;
            }
            else if (GraphSettings.DbRangeTop - GraphSettings.DbRangeBottom < 50)
            {
                ud_dB_Graph_Top.Increment = 5;
                ud_dB_Graph_Bottom.Increment = 5;
            }
            else
            {
                ud_dB_Graph_Top.Increment = 10;
                ud_dB_Graph_Bottom.Increment = 10;
            }
            UpdateGraph(true);
        }

        private void cmbGraph_VoltageStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGraph_VoltageStart.SelectedIndex != -1)
                GraphSettings.VoltageRange_Start = (double)((KeyValuePair<double, string>)cmbGraph_VoltageStart.SelectedItem).Key;
            UpdateGraph(true);
        }

        private void cmbGraph_VoltageEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGraph_VoltageEnd.SelectedIndex != -1)
                GraphSettings.VoltageRange_End = (double)((KeyValuePair<double, string>)cmbGraph_VoltageEnd.SelectedItem).Key;
            UpdateGraph(true);
        }

        private void chkShowMagnitude_CheckedChanged(object sender, EventArgs e)
        {
            GraphSettings.ShowMagnitude = chkShowMagnitude.Checked;
            UpdateGraph(true);
        }

        private void chkShowThd_CheckedChanged(object sender, EventArgs e)
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

        private void chkEnableLeftChannel_CheckedChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EnableLeftChannel = chkEnableLeftChannel.Checked;
        }

        private void chkEnableRightChannel_CheckedChanged(object sender, EventArgs e)
        {
            MeasurementSettings.EnableRightChannel = chkEnableRightChannel.Checked;
        }

        private void scGraphCursors_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
