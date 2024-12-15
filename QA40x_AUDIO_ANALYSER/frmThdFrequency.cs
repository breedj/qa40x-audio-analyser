using QA402_AUDIO_ANALYSER;
using QA40x_AUDIO_ANALYSER.Properties;
using QaControl;
using ScottPlot;
using ScottPlot.Plottables;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SkiaSharp.HarfBuzz.SKShaper;


namespace QA40x_AUDIO_ANALYSER
{

    public partial class frmThdFrequency : Form
    {
        public ThdFrequencyMeasurementData Data { get; set; }       // Data used in this form instance
        public bool MeasurementBusy { get; set; }                   // Measurement busy state

        CancellationTokenSource ct;                                 // Measurement cancelation token

        /// <summary>
        /// Constructor
        /// </summary>
        public frmThdFrequency()
        {
            ct = new CancellationTokenSource();
            InitializeComponent();
            Program.MainForm.ClearMessage();
            InitSettings();
            SetThdvsFrequencyControls();
            InitializeMagnitudePlot();
            AttachThdFreqMouseEvent();
            QaLibrary.InitMiniFftPlot(graphFft, Data.Settings.StartFrequency, Data.Settings.EndFrequency, -150, 20);
            QaLibrary.InitTimePlot(graphTime, 0, 4, -1, 1);
        }

        /// <summary>
        /// Initialise Settings with default settings
        /// </summary>
        void InitSettings()
        {
            // Clear data and initialize with default settings
            Data = new();
            Data.Settings.StartFrequency = 20;
            Data.Settings.EndFrequency = 20000;
            Data.Settings.SampleRate = 192000;
            Data.Settings.FftSize = 65536 * 2;
            Data.Settings.WindowingFunction = Windowing.Hann;
            Data.Settings.StepsPerOctave = 2;
            Data.Settings.InputRange = 18;
            Data.Settings.GeneratorAmplitude = -5.5;
            Data.Settings.GeneratorAmplitudeUnit = E_VoltageUnit.dBV;
            Data.Settings.Averages = 1;
            Data.Settings.Load = 8;
            Data.Settings.AmpOutputPower = 1;
            Data.Settings.AmpOutputAmplitude = 9.03;
            Data.Settings.AmpOutputAmplitudeUnit = E_VoltageUnit.dBV;
        }

        /// <summary>
        /// Set initial control values
        /// </summary>
        void SetThdvsFrequencyControls()
        {
            gbdB_Range.Left = gbD_Range.Left;
            gbdB_Range.Top = gbD_Range.Top;
            gbdB_Range.Visible = true;
            gbD_Range.Visible = false;

            cmbGeneratorType.SelectedIndex = 2;               // Output power
            txtGeneratorVoltage.ReadOnly = true;
            txtGeneratorVoltage.Text = Data.Settings.GeneratorAmplitude.ToString("#0.0##");
            cmbGeneratorVoltageUnit.SelectedIndex = 2;
            txtAmplifierOutputVoltage.Text = Data.Settings.AmpOutputAmplitude.ToString("#0.0##");
            cmbAmplifierOutputVoltageUnit.SelectedIndex = 2;
            txtOutputLoad.Text = Data.Settings.Load.ToString();
            txtAmplifierOutputPower.Text = Data.Settings.AmpOutputPower.ToString();
            txtStartFrequency.Text = Data.Settings.StartFrequency.ToString();
            txtEndFrequency.Text = Data.Settings.EndFrequency.ToString();
            udStepsOctave.Value = Data.Settings.StepsPerOctave;
            udAverages.Value = Data.Settings.Averages;

            cmbD_Graph_Top.SelectedIndex = 2;
            cmbD_Graph_Bottom.SelectedIndex = 3;
            cmbdB_Graph_Top.Value = 40;
            cmbdB_Graph_Bottom.Value = -140;
            cmbGraph_From.SelectedIndex = 2;
            cmbGraph_To.SelectedIndex = 4;

            Program.MainForm.HideProgressBar();
        }

        /// <summary>
        /// Update the generator voltage in the textbox based on the selected unit.
        /// If the unit changes then the voltage will be converted
        /// </summary>
        void UpdateGeneratorVoltageDisplay()
        {
            switch (cmbGeneratorVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtGeneratorVoltage.Text = ((int)QaLibrary.ConvertVoltage(Data.Settings.GeneratorAmplitude, Data.Settings.GeneratorAmplitudeUnit, E_VoltageUnit.MilliVolt)).ToString("###0");
                    break;
                case 1: // V
                    txtGeneratorVoltage.Text = QaLibrary.ConvertVoltage(Data.Settings.GeneratorAmplitude, Data.Settings.GeneratorAmplitudeUnit, E_VoltageUnit.Volt).ToString("#0.0##");
                    break;
                case 2: // dB
                    txtGeneratorVoltage.Text = QaLibrary.ConvertVoltage(Data.Settings.GeneratorAmplitude, Data.Settings.GeneratorAmplitudeUnit, E_VoltageUnit.dBV).ToString("#0.0#");
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
                    txtAmplifierOutputVoltage.Text = ((int)QaLibrary.ConvertVoltage(Data.Settings.AmpOutputAmplitude, Data.Settings.AmpOutputAmplitudeUnit, E_VoltageUnit.MilliVolt)).ToString("###0");
                    break;
                case 1: // V
                    txtAmplifierOutputVoltage.Text = QaLibrary.ConvertVoltage(Data.Settings.AmpOutputAmplitude, Data.Settings.AmpOutputAmplitudeUnit, E_VoltageUnit.Volt).ToString("#0.0##");
                    break;
                case 2: // dB
                    txtAmplifierOutputVoltage.Text = QaLibrary.ConvertVoltage(Data.Settings.AmpOutputAmplitude, Data.Settings.AmpOutputAmplitudeUnit, E_VoltageUnit.dBV).ToString("#0.0#");
                    break;
            }
        }

        /// <summary>
        /// Generator type changed
        /// </summary>
        void ChangeThdFrqGenType()
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

                    Data.Settings.AmpOutputPower = QaLibrary.ParseTextToDouble(txtAmplifierOutputPower.Text, Data.Settings.AmpOutputPower);
                    Data.Settings.Load = QaLibrary.ParseTextToDouble(txtOutputLoad.Text, Data.Settings.Load);
                    Data.Settings.AmpOutputAmplitude = Math.Sqrt(Data.Settings.AmpOutputPower * Data.Settings.Load);      // Expected output DUT amplitude in Volts
                    Data.Settings.AmpOutputAmplitudeUnit = E_VoltageUnit.Volt;                                           // Expected output DUT amplitude in dBV
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
            clearPlot();

            Data.StepData = [];

            markerIndex = -1;       // Reset marker

            // Init mini plots
            QaLibrary.InitMiniFftPlot(graphFft, Data.Settings.StartFrequency, Data.Settings.EndFrequency, -150, 20);
            QaLibrary.InitTimePlot(graphTime, 0, 4, -1, 1);

            // Check if webserver available and device connected
            if (await QaLibrary.CheckDeviceConnected() == false)
                return false;
           
            // ********************************************************************
            // Check connection
            // Load a settings file with the particulars we want
            await Qa40x.SetDefaults();
            await Qa40x.SetOutputSource(OutputSources.Off);            // We need to call this to make it turn on or off
            await Qa40x.SetSampleRate(Data.Settings.SampleRate);
            await Qa40x.SetBufferSize(Data.Settings.FftSize);
            await Qa40x.SetWindowing(Data.Settings.WindowingFunction);
            await Qa40x.SetRoundFrequencies(true);
            

            // ********************************************************************
            // Determine input level
            // ********************************************************************
            if (cmbGeneratorType.SelectedIndex == 1 || cmbGeneratorType.SelectedIndex == 2)     // Based on output
            {
                double amplifierOutputVoltagedBV = QaLibrary.ConvertVoltage(Data.Settings.AmpOutputAmplitude, Data.Settings.AmpOutputAmplitudeUnit, E_VoltageUnit.dBV);
                if (cmbGeneratorType.SelectedIndex == 1)
                    await Program.MainForm.ShowMessage($"Determining generator amplitude to get an output amplitude of {amplifierOutputVoltagedBV:0.00#} dBV.");
                else
                    await Program.MainForm.ShowMessage($"Determining generator amplitude to get an output power of {Data.Settings.AmpOutputPower:0.00#} W.");

                // Get input voltage based on desired output voltage
                Data.Settings.InputRange = QaLibrary.DetermineAttenuation(amplifierOutputVoltagedBV);
                double startAmplitude = -40;  // We start a measurement with a 10 mV signal.
                var result = await QaLibrary.DetermineGenAmplitudeByOutputAmplitude(startAmplitude, amplifierOutputVoltagedBV);
                Data.Settings.GeneratorAmplitude = result.Item1;
                Data.Settings.GeneratorAmplitudeUnit = E_VoltageUnit.dBV;
                QaLibrary.PlotMiniFftGraph(graphFft, result.Item2.FreqInput);                                             // Plot fft data in mini graph
                QaLibrary.PlotMiniTimeGraph(graphTime, result.Item2.TimeInput, 1000);                                      // Plot time data in mini graph
                if (Data.Settings.GeneratorAmplitude == -150)
                {
                    await Program.MainForm.ShowMessage($"Could not determine a valid generator amplitude. The amplitude would be {Data.Settings.GeneratorAmplitude:0.00#} dBV.");
                    return false;
                }

                // Check if cancel button pressed
                if (ct.IsCancellationRequested)
                    return false;

                // Check if amplitude found within the generator range
                if (Data.Settings.GeneratorAmplitude < 18)
                {
                    await Program.MainForm.ShowMessage($"Found an input amplitude of {Data.Settings.GeneratorAmplitude:0.00#} dBV. Doing second pass.");

                    // 2nd time for extra accuracy
                    result = await QaLibrary.DetermineGenAmplitudeByOutputAmplitude(Data.Settings.GeneratorAmplitude, amplifierOutputVoltagedBV);
                    Data.Settings.GeneratorAmplitude = result.Item1;
                    QaLibrary.PlotMiniFftGraph(graphFft, result.Item2.FreqInput);                                             // Plot fft data in mini graph
                    QaLibrary.PlotMiniTimeGraph(graphTime, result.Item2.TimeInput, 1000);                                      // Plot time data in mini graph
                    if (Data.Settings.GeneratorAmplitude == -150)
                    {
                        await Program.MainForm.ShowMessage($"Could not determine a valid generator amplitude. The amplitude would be {Data.Settings.GeneratorAmplitude:0.00#} dBV.");
                        return false;
                    }
                }
            
                UpdateGeneratorVoltageDisplay();

                await Program.MainForm.ShowMessage($"Found an input amplitude of {Data.Settings.GeneratorAmplitude:0.00#} dBV.");
            }
            else if (cmbGeneratorType.SelectedIndex == 0)                         // Based on input voltage
            {
                double amplifierOutputVoltagedBV = QaLibrary.ConvertVoltage(Data.Settings.AmpOutputAmplitude, Data.Settings.AmpOutputAmplitudeUnit, E_VoltageUnit.dBV);
                await Program.MainForm.ShowMessage($"Determining the best input attenuation for a generator voltage of {amplifierOutputVoltagedBV:0.00#} dBV.");

                // Determine correct input attenuation
                var result = await QaLibrary.DetermineAttenuationForGeneratorVoltage(amplifierOutputVoltagedBV, 1000, 42);
                Data.Settings.InputRange = result.Item1;
                QaLibrary.PlotMiniFftGraph(graphFft, result.Item3.FreqInput);
                QaLibrary.PlotMiniTimeGraph(graphTime, result.Item3.TimeInput, 1000);

                await Program.MainForm.ShowMessage($"Found correct input attenuation of {Data.Settings.InputRange:0} dBV for an amplfier amplitude of {result.Item2:0.00#} dBV.", 500);
            }
            // Set the new input range
            await Qa40x.SetInputRange(Data.Settings.InputRange);

            // Check if cancel button pressed
            if (ct.IsCancellationRequested)
                return false;

            // ********************************************************************
            // Calculate frequency steps to do
            // ********************************************************************
            var binSize = QaLibrary.CalcBinSize(Data.Settings.SampleRate, Data.Settings.FftSize);
            // Generate a list of frequencies
            var stepFrequencies = QaLibrary.GetLineairSpacedLogarithmicValuesPerOctave(Data.Settings.StartFrequency, Data.Settings.EndFrequency, Data.Settings.StepsPerOctave);
            // Translate the generated list to bin center frequncies
            var stepBins = QaLibrary.TranslateToBinFrequencies(stepFrequencies, Data.Settings.SampleRate, Data.Settings.FftSize);

            // ********************************************************************
            // Do noise floor measurement
            // ********************************************************************
            await Program.MainForm.ShowMessage($"Determining noise floor.");
            await Qa40x.SetOutputSource(OutputSources.Off);
            await Qa40x.DoAcquisition();
            LeftRightSeries noiseFloor = await QaLibrary.DoAcquisitions(Data.Settings.Averages);
            Data.NoiseFloor = noiseFloor;

            Program.MainForm.SetupProgressBar(0, stepBins.Length);

            // ********************************************************************
            // Step through the list of frequencies
            // ********************************************************************
            for (int f = 0; f < stepBins.Length; f++)
            {
                await Program.MainForm.ShowMessage($"Measuring step {f + 1} of {stepBins.Length}.");
                Program.MainForm.UpdateProgressBar(f+1);

                // Set the generator
                double amplitudeSetpointdBV = QaLibrary.ConvertVoltage(Data.Settings.GeneratorAmplitude, Data.Settings.GeneratorAmplitudeUnit, E_VoltageUnit.dBV);
                await Qa40x.SetGen1(stepBins[f], amplitudeSetpointdBV, true);
                if (f == 0)
                    await Qa40x.SetOutputSource(OutputSources.Sine);            // We need to call this to make the averages reset
                                                                               
                LeftRightSeries lrfs = await QaLibrary.DoAcquisitions(Data.Settings.Averages);

                FrequencyThdStep step = new()
                {
                    FundamentalFrequency = stepBins[f],
                    GeneratorVoltage = QaLibrary.ConvertVoltage(amplitudeSetpointdBV, E_VoltageUnit.dBV, E_VoltageUnit.Volt),
                    fftData = lrfs.FreqInput,
                    timeData = lrfs.TimeInput,
                    DcComponent = lrfs.TimeInput.Left.Average()
                };

                uint fundamentalBin = QaLibrary.GetBinOfFrequency(step.FundamentalFrequency, binSize);
                if (fundamentalBin >= lrfs.FreqInput.Left.Length)               // Check in bin within range
                    break;

                step.AmplitudeVolts = lrfs.FreqInput.Left[fundamentalBin];
                step.AmplitudeDbV = 20 * Math.Log10(lrfs.FreqInput.Left[fundamentalBin]);
                step.MagnitudeDb = 20 * Math.Log10(step.AmplitudeVolts / Math.Pow(10, amplitudeSetpointdBV / 20));
                // Calculate average noise floor 
                step.NoiseFloorV = Data.NoiseFloor.FreqInput.Left               // Store noise floor in V
                    .Select((v, i) => new { Index = i, Value = v })
                    .Where(p => p.Index > fundamentalBin)                       // Only higher frequencies. We do not have fundamentals in lower frequencies
                    .Select(v => v.Value)
                    .Average();
                step.NoiseFloorDbV = 20 * Math.Log10(step.NoiseFloorV);         // Store noise floor in dBV

                // Plot the mini graphs
                QaLibrary.PlotMiniFftGraph(graphFft, lrfs.FreqInput);
                QaLibrary.PlotMiniTimeGraph(graphTime, lrfs.TimeInput, step.FundamentalFrequency);

                // Reset harmonic distortion variables
                double distortionSqrtTotal = 0;
                double distiortionD6plus = 0;

                // Loop through harmonics up tot the 12th
                for (int h = 2; h <= 12; h++)                                   // For now up to 12 harmonics, start at 2nd
                {
                    var harmonicFrequency = stepBins[f] * h;
                    HarmonicData harmonic = new()
                    {
                        HarmonicNr = h,
                        Frequency = harmonicFrequency
                    };

                    uint bin = QaLibrary.GetBinOfFrequency(harmonic.Frequency, binSize);        // Calculate bin of the harmonic frequency
                    // Check if bin exists
                    if (bin < lrfs.FreqInput.Left.Length)
                    {
                        harmonic.NoiseAmplitudeVolt = noiseFloor.FreqInput.Left[bin];
                        harmonic.AmplitudeVolts = lrfs.FreqInput.Left[bin];
                        harmonic.AmplitudeDbV = 20 * Math.Log10(lrfs.FreqInput.Left[bin]);
                        harmonic.ThdPercent = (harmonic.AmplitudeVolts / step.AmplitudeVolts) * 100;
                        harmonic.ThdDb = 20 * Math.Log10(harmonic.ThdPercent / 100.0);

                        // The harmonics 6-12 will be added together and displayed as D6+
                        if (h >= 6)
                            distiortionD6plus += Math.Pow(harmonic.AmplitudeVolts, 2);          // Add to total distortion
                        // All harmonics together for THD
                        distortionSqrtTotal += Math.Pow(harmonic.AmplitudeVolts, 2);            // Add to total distortion
                    }
                    else
                        break;                                                                  // Invalid bin, skip harmonic

                    step.Harmonics.Add(harmonic);           
                }

                // Calculate THD
                if (distortionSqrtTotal != 0)
                {
                    step.ThdPercent = (Math.Sqrt(distortionSqrtTotal) / step.AmplitudeVolts) * 100;
                    step.ThdDb = 20 * Math.Log10(step.ThdPercent / 100.0);
                }

                // Calculate D6+ (D6 - D12)
                if (distiortionD6plus != 0)
                {
                    step.D6PlusDbV = 20 * Math.Log10(Math.Sqrt(distiortionD6plus));
                    step.ThdPercentD6plus = Math.Sqrt(distiortionD6plus / Math.Pow(step.AmplitudeVolts, 2)) * 100;
                    step.ThdDbD6plus = 20 * Math.Log10(step.ThdPercentD6plus / 100.0);
                }

                // If load not zero then calculate load power
                if (Data.Settings.Load != 0)
                    step.PowerWatt = Math.Pow(step.AmplitudeVolts, 2) / Data.Settings.Load;

                // Calculate THD+N      TODO: Check, I don't think this is correct.
                step.ThdDbN = lrfs.FreqInput.Left
                    .Select((v, i) => new { Index = i, Value = v })
                    .Where(p => p.Index != fundamentalBin && p.Index != fundamentalBin - 1 && p.Index != fundamentalBin + 1)
                    .Sum(v => Math.Pow(v.Value, 2));

                step.ThdDbN = (Math.Sqrt(step.ThdDbN) / lrfs.FreqInput.Left[fundamentalBin]) * 100;


                // Add step data to list
                Data.StepData.Add(step);

                PlotMeasurementData(step);
                
                // Check if cancel button pressed
                if (ct.IsCancellationRequested)
                {
                    await Qa40x.SetOutputSource(OutputSources.Off);                                             // Be sure to switch gen off
                    return false;
                }
            }

            // Turn the generator off
            await Qa40x.SetOutputSource(OutputSources.Off);

            // Show message
            await Program.MainForm.ShowMessage($"Measurment finished!", 500);

            return true;
        }

       
        private void PlotMeasurementData(FrequencyThdStep step)
        {
            // Plot the data depending on selected graph
            if (gbdB_Range.Visible)
            {
                // dBV plot is selected
                PlotMagnitude(Data);
                // Plot current measurement texts
                WriteCursorTextsdB(step.FundamentalFrequency
                    , step.MagnitudeDb
                    , step.ThdDb - step.AmplitudeDbV
                    , (step.Harmonics.Count > 0 ? step.Harmonics[0].AmplitudeDbV - step.AmplitudeDbV : 0)   // 2nd harmonic
                    , (step.Harmonics.Count > 1 ? step.Harmonics[1].AmplitudeDbV - step.AmplitudeDbV : 0)
                    , (step.Harmonics.Count > 3 ? step.Harmonics[2].AmplitudeDbV - step.AmplitudeDbV : 0)
                    , (step.Harmonics.Count > 4 ? step.Harmonics[3].AmplitudeDbV - step.AmplitudeDbV : 0)
                    , (step.Harmonics.Count > 5 ? step.D6PlusDbV - step.AmplitudeDbV : 0)                   // 6+ harmonics
                    , step.DcComponent
                    , step.PowerWatt
                    , step.NoiseFloorDbV - step.AmplitudeDbV
                    , Data.Settings.Load
                    );
            }
            else
            {
                // Thd percent plot is selected
                PlotThd(Data);
                // Plot current measurement texts
                WriteCursorTextsD(step.FundamentalFrequency
                    , step.MagnitudeDb
                    , step.ThdPercent
                    , (step.Harmonics.Count > 0 ? step.Harmonics[0].ThdPercent : 0)                         // 2nd harmonic
                    , (step.Harmonics.Count > 1 ? step.Harmonics[1].ThdPercent : 0)
                    , (step.Harmonics.Count > 3 ? step.Harmonics[2].ThdPercent : 0)
                    , (step.Harmonics.Count > 4 ? step.Harmonics[3].ThdPercent : 0)
                    , (step.Harmonics.Count > 5 ? step.ThdPercentD6plus : 0)                                // 6+ harmonics
                    , step.DcComponent
                    , step.PowerWatt
                    , (step.NoiseFloorV / step.AmplitudeVolts) % 100
                    , Data.Settings.Load
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
        void WriteCursorTextsD(double f, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double dc, double power, double noiseFloor, double load)
        {
            lblCuror_Frequency.Text = $"Frequency: {f:0.## Hz}";
            lblCuror_Magnitude.Text = $"Magn: {magnitude:0.## dB}";
            lblCuror_THD.Text = $"THD: {thd:0.0000# \\%}";

            lblCuror_D2.Text = $"D2: {D2:0.0000# \\%}";
            lblCuror_D3.Text = $"D3: {D3:0.0000# \\%}";
            lblCuror_D4.Text = $"D4: {D4:0.0000# \\%}";
            lblCuror_D5.Text = $"D5: {D5:0.0000# \\%}";
            lblCuror_D6.Text = $"D6+: {D6:0.0000# \\%}";
            lblCuror_DC.Text = $"DC: {dc * 1000:0.0# mV}";

            if (power < 1)
                lblCuror_Power.Text = $"Power: {power * 1000:0.0# mW} ({load:0.##} Ω)";
            else
                lblCuror_Power.Text = $"Power: {power:0.00# W} ({load:0.##} Ω)";

            lblCuror_NoiseFloor.Text = $"Noise floor: {noiseFloor:##0.0# dB}";

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
        void WriteCursorTextsdB(double f, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double dc, double power, double noiseFloor, double load)
        {
            lblCuror_Frequency.Text = $"Frequency: {f:0.## Hz}";
            lblCuror_Magnitude.Text = $"Magn: {magnitude:0.## dB}";
            lblCuror_THD.Text = $"THD: {thd:0.0# dB}";

            lblCuror_D2.Text = $"D2: {D2:##0.0# dB}";
            lblCuror_D3.Text = $"D3: {D3:##0.0# dB}";
            lblCuror_D4.Text = $"D4: {D4:##0.0# dB}";
            lblCuror_D5.Text = $"D5: {D5:##0.0# dB}";
            lblCuror_D6.Text = $"D6+: {D6:##0.0# dB}";
            lblCuror_DC.Text = $"DC: {dc * 1000:0.0# mV}";

            if (power < 1)
                lblCuror_Power.Text = $"Power: {power * 1000:0.0# mW} ({load:0.##} Ω)";
            else
                lblCuror_Power.Text = $"Power: {power:0.00# W} ({load:0.##} Ω)";

            lblCuror_NoiseFloor.Text = $"Noise floor: {noiseFloor:##0.0# dB}";
        }

       
        






        void clearPlot()
        {
            thdPlot.Plot.Clear();
            thdPlot.Refresh();
        }


        void initThdPlot()
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
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.10);
            thdPlot.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            if (cmbGraph_From.SelectedIndex > -1 && cmbGraph_To.SelectedIndex > -1 && cmbD_Graph_Bottom.SelectedIndex > -1 && cmbD_Graph_Top.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbGraph_From.Text)), Math.Log10(Convert.ToDouble(cmbGraph_To.Text)), Math.Log10(Convert.ToDouble(cmbD_Graph_Bottom.Text)), Math.Log10(Convert.ToDouble(cmbD_Graph_Top.Text)));
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

        void PlotThd(ThdFrequencyMeasurementData data)
        {
            thdPlot.Plot.Remove<Scatter>();

            List<double> freqX = new List<double>();
            List<double> hTotY = new List<double>();
            List<double> h2Y = new List<double>();
            List<double> h3Y = new List<double>();
            List<double> h4Y = new List<double>();
            List<double> h5Y = new List<double>();
            List<double> h6Y = new List<double>();
            List<double> noiseY = new List<double>();

            for (int f = 0; f < data.StepData.Count; f++)
            {
                freqX.Add(data.StepData[f].FundamentalFrequency);

                if (data.StepData[f].Harmonics.Count > 0 && chkShowThd.Checked)
                    hTotY.Add(data.StepData[f].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 0 && chkShowD2.Checked)
                    h2Y.Add(data.StepData[f].Harmonics[0].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 1 && chkShowD3.Checked)
                    h3Y.Add(data.StepData[f].Harmonics[1].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 2 && chkShowD4.Checked)
                    h4Y.Add(data.StepData[f].Harmonics[2].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 3 && chkShowD5.Checked)
                    h5Y.Add(data.StepData[f].Harmonics[3].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 4 && data.StepData[f].ThdPercentD6plus != 0 && chkShowD6.Checked)
                    h6Y.Add(data.StepData[f].ThdPercentD6plus);        // D6+
                if (chkShowNoiseFloor.Checked)
                    noiseY.Add((data.StepData[f].NoiseFloorV / data.StepData[f].AmplitudeVolts) * 100);
            }

            IPalette palette = new ScottPlot.Palettes.Category10();
            float lineWidth = 1;
            float markerSize = 1;
            if (chkThickLines.Checked)
                lineWidth = 2;
            if (chkShowMarkers.Checked)
                markerSize = lineWidth + 3;

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();

            if (chkShowThd.Checked)
            {
                double[] logHTotY = hTotY.Select(Math.Log10).ToArray();
                var plotTot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                plotTot.LineWidth = lineWidth;
                plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Black);
                plotTot.MarkerSize = markerSize;
                plotTot.LegendText = "THD";
            }

            if (chkShowD2.Checked)
            {
                double[] logH2Y = h2Y.Select(Math.Log10).ToArray();
                var plot1 = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                plot1.LineWidth = lineWidth;
                plot1.Color = palette.GetColor(0);
                plot1.MarkerSize = markerSize;
                plot1.LegendText = "D2";
            }

            if (chkShowD3.Checked)
            {
                double[] logH3Y = h3Y.Select(Math.Log10).ToArray();
                var plot2 = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                plot2.LineWidth = lineWidth;
                plot2.Color = palette.GetColor(1);
                plot2.MarkerSize = markerSize;
                plot2.LegendText = "D3";
            }

            if (chkShowD4.Checked)
            {
                double[] logH4Y = h4Y.Select(Math.Log10).ToArray();
                var plot3 = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                plot3.Color = palette.GetColor(2);
                plot3.LineWidth = lineWidth;
                plot3.MarkerSize = markerSize;
                plot3.LegendText = "D4";
            }

            if (chkShowD5.Checked)
            {
                double[] logH5Y = h5Y.Select(Math.Log10).ToArray();
                var plot4 = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                plot4.LineWidth = lineWidth;
                plot4.Color = palette.GetColor(3);
                plot4.MarkerSize = markerSize;
                plot4.LegendText = "D5";
            }

            if (chkShowD6.Checked)
            {
                double[] logH6Y = h6Y.Select(Math.Log10).ToArray();
                var plot5 = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                plot5.LineWidth = lineWidth;
                plot5.Color = palette.GetColor(4);
                plot5.MarkerSize = markerSize;
                plot5.LegendText = "D6+";
            }


            if (chkShowNoiseFloor.Checked)
            {
                double[] logNoiseY = noiseY.Select(Math.Log10).ToArray();
                var plot5 = thdPlot.Plot.Add.Scatter(logFreqX, logNoiseY);
                plot5.LineWidth = lineWidth;
                plot5.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Gray);
                plot5.MarkerSize = markerSize;
                plot5.LegendText = "noise";
                plot5.LinePattern = LinePattern.Dotted;
            }

            if (markerIndex != -1)
                QaLibrary.PlotCursorMarker(thdPlot, 1, LinePattern.Solid, markerDataPoint);

            thdPlot.Refresh();
        }





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


            // show grid lines for minor ticks
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.10);
            thdPlot.Plot.Grid.MinorLineWidth = 1;


            // show grid lines for minor ticks
            thdPlot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            thdPlot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.10);
            thdPlot.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            if (cmbGraph_From.SelectedIndex > -1 && cmbGraph_To.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbGraph_From.Text)), Math.Log10(Convert.ToDouble(cmbGraph_To.Text)), Convert.ToDouble(cmbdB_Graph_Bottom.Value), Convert.ToDouble(cmbdB_Graph_Top.Value));
            thdPlot.Plot.Title("Magnitude (dB)");
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



        void PlotMagnitude(ThdFrequencyMeasurementData data)
        {
            thdPlot.Plot.Remove<Scatter>();

            List<double> freqX = new List<double>();
            List<double> magnY = new List<double>();
            List<double> hTotY = new List<double>();
            List<double> h2Y = new List<double>();
            List<double> h3Y = new List<double>();
            List<double> h4Y = new List<double>();
            List<double> h5Y = new List<double>();
            List<double> h6Y = new List<double>();
            List<double> noiseY = new List<double>();

            for (int f = 0; f < data.StepData.Count; f++)
            {
                freqX.Add(data.StepData[f].FundamentalFrequency);

                if (chkShowMagnitude.Checked)
                    magnY.Add(data.StepData[f].MagnitudeDb);

                if (data.StepData[f].Harmonics.Count > 0)
                {
                    hTotY.Add(data.StepData[f].ThdDb + data.StepData[f].MagnitudeDb);
                    h2Y.Add(data.StepData[f].Harmonics[0].AmplitudeDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
                }
                if (data.StepData[f].Harmonics.Count > 1)
                    h3Y.Add(data.StepData[f].Harmonics[1].AmplitudeDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
                if (data.StepData[f].Harmonics.Count > 2)
                    h4Y.Add(data.StepData[f].Harmonics[2].AmplitudeDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
                if (data.StepData[f].Harmonics.Count > 3)
                    h5Y.Add(data.StepData[f].Harmonics[3].AmplitudeDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
                if (data.StepData[f].D6PlusDbV != 0 && data.StepData[f].Harmonics.Count > 4 && chkShowD6.Checked)
                    h6Y.Add(data.StepData[f].D6PlusDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
                if (chkShowNoiseFloor.Checked)
                    noiseY.Add(data.StepData[f].NoiseFloorDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
            }

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();
            float lineWidth = 1;
            float markerSize = 1;
            if (chkThickLines.Checked)
                lineWidth = 2;
            if (chkShowMarkers.Checked)
                markerSize = lineWidth + 3;

            IPalette palette = new ScottPlot.Palettes.Category10();

            if (chkShowMagnitude.Checked)
            {
                double[] logMagnY = magnY.ToArray();
                var plot1 = thdPlot.Plot.Add.Scatter(logFreqX, logMagnY);
                plot1.LineWidth = lineWidth;
                plot1.LinePattern = LinePattern.DenselyDashed;
                plot1.Color = ScottPlot.Color.FromColor(System.Drawing.Color.DarkBlue);
                plot1.MarkerSize = markerSize;
                plot1.LegendText = "Magn";
            }

            if (chkShowThd.Checked)
            {
                double[] logHTotY = hTotY.ToArray();
                var plotTot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                plotTot.LineWidth = lineWidth;
                plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Black);
                plotTot.MarkerSize = markerSize;
                plotTot.LegendText = "THD";
            }

            if (chkShowD2.Checked)
            {
                double[] logH2Y = h2Y.ToArray();
                var plot2 = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                plot2.LineWidth = lineWidth;
                plot2.Color = palette.GetColor(0);
                plot2.MarkerSize = markerSize;
                plot2.LegendText = "H2";
            }

            if (chkShowD3.Checked)
            {
                double[] logH3Y = h3Y.ToArray();
                var plot3 = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                plot3.LineWidth = lineWidth;
                plot3.Color = palette.GetColor(1);
                plot3.MarkerSize = markerSize;
                plot3.LegendText = "H3";
            }

            if (chkShowD4.Checked)
            {
                double[] logH4Y = h4Y.ToArray();
                var plot4 = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                plot4.LineWidth = lineWidth;
                plot4.Color = palette.GetColor(2);
                plot4.MarkerSize = markerSize;
                plot4.LegendText = "H4";
            }

            if (chkShowD5.Checked)
            {
                double[] logH5Y = h5Y.ToArray();
                var plot5 = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                plot5.LineWidth = lineWidth;
                plot5.Color = palette.GetColor(3);
                plot5.MarkerSize = markerSize;
                plot5.LegendText = "H5";
            }

            if (chkShowD6.Checked)
            {
                double[] logH6Y = h6Y.ToArray();
                var plot6 = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                plot6.LineWidth = lineWidth;
                plot6.Color = palette.GetColor(4);
                plot6.MarkerSize = markerSize;
                plot6.LegendText = "H6+";
            }

            if (chkShowNoiseFloor.Checked)
            {
                double[] logNoiseY = noiseY.ToArray();
                var plot7 = thdPlot.Plot.Add.ScatterLine(logFreqX, logNoiseY);
                plot7.LineWidth = lineWidth;
                plot7.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Gray);
                plot7.MarkerSize = markerSize;
                plot7.LegendText = "Noise";
                plot7.LinePattern = LinePattern.Dotted;
            }

            if (markerIndex != -1)      // Check if no persistent marker
                QaLibrary.PlotCursorMarker(thdPlot, 1, LinePattern.Solid, markerDataPoint);
            

            thdPlot.Refresh();
        }

        /// <summary>
        /// Attach mouse events to the main graph
        /// </summary>
        void AttachThdFreqMouseEvent()
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
                    QaLibrary.PlotMiniFftGraph(graphFft, Data.StepData[markerIndex].fftData);
                    QaLibrary.PlotMiniTimeGraph(graphTime, Data.StepData[markerIndex].timeData, Data.StepData[markerIndex].FundamentalFrequency);
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
                QaLibrary.PlotMiniFftGraph(graphFft, Data.StepData[nearest1.Index].fftData);
                QaLibrary.PlotMiniTimeGraph(graphTime, Data.StepData[nearest1.Index].timeData, Data.StepData[nearest1.Index].FundamentalFrequency);
            }
        }


        int markerIndex = -1;
        DataPoint markerDataPoint;

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


                if (Data.StepData.Count > nearest1.Index)
                {
                    FrequencyThdStep step = Data.StepData[nearest1.Index];

                    if (gbdB_Range.Visible)
                    {
                        WriteCursorTextsdB(step.FundamentalFrequency
                        , step.MagnitudeDb
                        , step.ThdDb - step.AmplitudeDbV
                        , (step.Harmonics.Count > 0 ? step.Harmonics[0].AmplitudeDbV - step.AmplitudeDbV : 0)   // 2nd harmonic
                        , (step.Harmonics.Count > 1 ? step.Harmonics[1].AmplitudeDbV - step.AmplitudeDbV : 0)
                        , (step.Harmonics.Count > 2 ? step.Harmonics[2].AmplitudeDbV - step.AmplitudeDbV : 0)
                        , (step.Harmonics.Count > 3 ? step.Harmonics[3].AmplitudeDbV - step.AmplitudeDbV : 0)
                        , (step.Harmonics.Count > 4 ? step.D6PlusDbV - step.AmplitudeDbV : 0)                   // 6+ harmonics
                        , step.DcComponent
                        , step.PowerWatt
                        , step.NoiseFloorDbV - step.AmplitudeDbV
                        , Data.Settings.Load
                        );
                    }
                    else
                    {
                        WriteCursorTextsD(step.FundamentalFrequency
                        , step.MagnitudeDb
                        , step.ThdPercent
                        , (step.Harmonics.Count > 0 ? step.Harmonics[0].ThdPercent : 0)     // 2nd harmonic
                        , (step.Harmonics.Count > 1 ? step.Harmonics[1].ThdPercent : 0)
                        , (step.Harmonics.Count > 3 ? step.Harmonics[2].ThdPercent : 0)
                        , (step.Harmonics.Count > 4 ? step.Harmonics[3].ThdPercent : 0)
                        , (step.Harmonics.Count > 5 ? step.ThdPercentD6plus : 0)                   // 6+ harmonics
                        , step.DcComponent
                        , step.PowerWatt
                        , (step.NoiseFloorV / step.AmplitudeVolts) % 100
                        , Data.Settings.Load
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


        private void cmbThdFreq_GenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeThdFrqGenType();
        }

        private void cmbThdFreq_VoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateGeneratorVoltageDisplay();
        }

        private void txtThdFreq_GenVoltage_TextChanged(object sender, EventArgs e)
        {
            if (txtGeneratorVoltage.Focused)
            {
                Data.Settings.GeneratorAmplitude = QaLibrary.ParseTextToDouble(txtGeneratorVoltage.Text, Data.Settings.GeneratorAmplitude);
                Data.Settings.GeneratorAmplitudeUnit = (E_VoltageUnit)cmbGeneratorVoltageUnit.SelectedIndex;
            }
            ValidateGeneratorAmplitude(sender);
        }

        private void ValidateGeneratorAmplitude(object sender)
        {
            if (cmbGeneratorVoltageUnit.SelectedIndex == (int)E_VoltageUnit.MilliVolt)
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV);        // mV
            else if (cmbGeneratorVoltageUnit.SelectedIndex == (int)E_VoltageUnit.Volt)
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_V);     // V
            else
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_DBV, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_DBV);       // dBV
        }

        private void txtThdFreq_GenVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        private void txtThdFreq_OutputLoad_TextChanged(object sender, EventArgs e)
        {
            ChangeThdFrqGenType();
            QaLibrary.ValidateRangeAdorner(sender, 0, 100000);
        }

        private void txtThdFreq_OutputPower_TextChanged(object sender, EventArgs e)
        {
            Data.Settings.AmpOutputPower = QaLibrary.ParseTextToDouble(txtAmplifierOutputPower.Text, Data.Settings.AmpOutputPower);
            ChangeThdFrqGenType();
            QaLibrary.ValidateRangeAdorner(sender, 0, 1000);
        }



        private void udThdFreq_StepsOctave_ValueChanged(object sender, EventArgs e)
        {
            Data.Settings.StepsPerOctave = Convert.ToUInt16(udStepsOctave.Value);
        }

        private void udThdFreq_Averages_ValueChanged(object sender, EventArgs e)
        {
            Data.Settings.Averages = Convert.ToUInt16(udAverages.Value);
        }


        /// <summary>
        /// Key press event of output voltage textbox.
        /// Check if value is numeric. Else prevent editing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_OutputVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        /// <summary>
        /// Output voltage has been changed.
        /// This event is also fired when text is changed by code.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_OutputVoltage_TextChanged(object sender, EventArgs e)
        {
            if (txtAmplifierOutputVoltage.Focused)
            {
                // Event fired by user input
                Data.Settings.AmpOutputAmplitude = QaLibrary.ParseTextToDouble(txtAmplifierOutputVoltage.Text, Data.Settings.AmpOutputAmplitude);
                Data.Settings.AmpOutputAmplitudeUnit = (E_VoltageUnit)cmbAmplifierOutputVoltageUnit.SelectedIndex;
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
        private void txtThdFreq_StartFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, true);
        }

        /// <summary>
        /// Start frequency changed.
        /// Show text in red when value invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_StartFreq_TextChanged(object sender, EventArgs e)
        {
            QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_FREQUENCY_HZ, QaLibrary.MAXIMUM_GENERATOR_FREQUENCY_HZ);
            Data.Settings.StartFrequency = QaLibrary.ParseTextToDouble(txtStartFrequency.Text, Data.Settings.StartFrequency);
        }

        /// <summary>
        /// End frequency key press.
        /// Allow integers only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_EndFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, true);
        }

        /// <summary>
        /// End frequency changed.
        /// Show text in red when value invalid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_EndFreq_TextChanged(object sender, EventArgs e)
        {
            QaLibrary.ValidateRangeAdorner(sender, 5, 96000);
            Data.Settings.EndFrequency = QaLibrary.ParseTextToDouble(txtEndFrequency.Text, Data.Settings.EndFrequency);
        }

        /// <summary>
        /// Load key press.
        /// Allow decimals only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_OutputLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }


        /// <summary>
        /// Output power key press
        /// Allow decimals only
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtThdFreq_OutputPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        /// <summary>
        /// Output voltage display unit changed.
        /// Convert voltage to new unit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbThdFreq_OutputVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAmpOutputVoltageDisplay();
        }

        /// <summary>
        /// Set graph x axis to data range
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThdFreq_FitGraphX_Click(object sender, EventArgs e)
        {
            double startFreq = QaLibrary.ParseTextToDouble(txtStartFrequency.Text, 20);
            if (startFreq <= 5)
                cmbGraph_From.SelectedIndex = 0;
            else if (startFreq <= 10)
                cmbGraph_From.SelectedIndex = 1;
            else if (startFreq <= 20)
                cmbGraph_From.SelectedIndex = 2;
            else if (startFreq <= 50)
                cmbGraph_From.SelectedIndex = 3;
            else if (startFreq <= 100)
                cmbGraph_From.SelectedIndex = 4;
            else if (startFreq <= 200)
                cmbGraph_From.SelectedIndex = 5;
            else
                cmbGraph_From.SelectedIndex = 6;

            double endFreq = QaLibrary.ParseTextToDouble(txtEndFrequency.Text, 20000);
            if (endFreq <= 1000)
                cmbGraph_To.SelectedIndex = 0;
            else if (endFreq <= 2000)
                cmbGraph_To.SelectedIndex = 1;
            else if (endFreq <= 5000)
                cmbGraph_To.SelectedIndex = 2;
            else if (endFreq <= 10000)
                cmbGraph_To.SelectedIndex = 3;
            else if (endFreq <= 20000)
                cmbGraph_To.SelectedIndex = 4;
            else if (endFreq <= 50000)
                cmbGraph_To.SelectedIndex = 5;
            else
                cmbGraph_To.SelectedIndex = 6;
        }

        /// <summary>
        /// Graph axis change event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbThdFreq_Graph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gbD_Range.Visible)
            {
                initThdPlot();
                PlotThd(Data);
            }
            else
            {
                InitializeMagnitudePlot();
                PlotMagnitude(Data);
            }
        }


        /// <summary>
        /// Graph checkbox clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkThdFreq_ShowThd_CheckedChanged(object sender, EventArgs e)
        {
            if (gbD_Range.Visible)
            {
                initThdPlot();
                PlotThd(Data);
            }
            else
            {
                InitializeMagnitudePlot();
                PlotMagnitude(Data);
            }
        }

        /// <summary>
        /// Magnitude graph button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFreqThd_Graph_dBV_Click(object sender, EventArgs e)
        {
            gbdB_Range.Visible = true;
            btnGraph_dB.BackColor = System.Drawing.Color.Cornsilk;
            gbD_Range.Visible = false;
            btnGraph_D_Percent.BackColor = System.Drawing.Color.WhiteSmoke;
            chkShowMagnitude.Enabled = true;

            InitializeMagnitudePlot();
            PlotMagnitude(Data);
        }

        /// <summary>
        /// THD % graph button click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFreqThd_Graph_D_Click(object sender, EventArgs e)
        {
            gbdB_Range.Visible = false;
            btnGraph_dB.BackColor = System.Drawing.Color.WhiteSmoke;
            gbD_Range.Visible = true;
            btnGraph_D_Percent.BackColor = System.Drawing.Color.Cornsilk;
            chkShowMagnitude.Enabled = false;

            initThdPlot();
            PlotThd(Data);
        }

        /// <summary>
        /// Graph y axis high value changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbThdFreq_dBV_Graph_Top_ValueChanged(object sender, EventArgs e)
        {
            InitializeMagnitudePlot();
            PlotMagnitude(Data);
        }

        /// <summary>
        /// THD % y axis fit click request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThdFreq_FitDGraphY_Click(object sender, EventArgs e)
        {
            if (Data.StepData.Count == 0)
                return;

            // Determine top Y
            double maxThd = Data.StepData.Max(d => d.ThdPercent);

            if (maxThd <= 1)
                cmbD_Graph_Top.SelectedIndex = 2;
            else if (maxThd <= 10)
                cmbD_Graph_Top.SelectedIndex = 1;
            else
                cmbD_Graph_Top.SelectedIndex = 0;


            // Determine bottom Y
            double minThd = (Data.StepData.Min(d => (d.NoiseFloorV / d.AmplitudeVolts) * 100));
            if (minThd > 0.1)
                cmbD_Graph_Bottom.SelectedIndex = 0;
            else if (minThd > 0.01)
                cmbD_Graph_Bottom.SelectedIndex = 1;
            else if (minThd > 0.001)
                cmbD_Graph_Bottom.SelectedIndex = 2;
            else if (minThd > 0.0001)
                cmbD_Graph_Bottom.SelectedIndex = 3;
            else if (minThd > 0.00001)
                cmbD_Graph_Bottom.SelectedIndex = 4;
            else
                cmbD_Graph_Bottom.SelectedIndex = 5;

        }

        /// <summary>
        /// Magnitude y axis fit click request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnThdFreq_FitDbGraphY_Click(object sender, EventArgs e)
        {

            if (Data.StepData.Count == 0)
                return;

            // Determine top Y

            double maxDb = Data.StepData.Max(d => d.MagnitudeDb);
            if (maxDb >= 100)
                cmbdB_Graph_Top.Value = Math.Ceiling((decimal)((int)(maxDb / 10) + 1) * 10);
            else if (maxDb >= 10)
                cmbdB_Graph_Top.Value = (Math.Ceiling((decimal)((int)maxDb) / 10) * 10) + 10;
            else
                cmbdB_Graph_Top.Value = Math.Ceiling((decimal)((int)(maxDb * 10) + 1) / 10);

            // Determine bottom Y
            double minDb = Data.StepData.Min(d => d.NoiseFloorDbV) + Data.StepData[0].MagnitudeDb;

            cmbdB_Graph_Bottom.Value = Math.Ceiling((decimal)((int)(minDb / 10) - 2) * 10);
        }


        private void btnStopMeasurement_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
