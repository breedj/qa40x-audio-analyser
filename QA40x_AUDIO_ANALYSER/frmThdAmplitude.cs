using QA402_AUDIO_ANALYSER;
using QaControl;
using ScottPlot;
using ScottPlot.Plottables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QA40x_AUDIO_ANALYSER
{

    public partial class frmThdAmplitude : Form
    {
        ThdAmplitudeMeasurementData data;

        CancellationTokenSource ct;

        public frmThdAmplitude()
        {
            ct = new CancellationTokenSource();
            InitializeComponent();
            ClearMessage();
            InitThdFrequencySettings();
            SetThdvsFrequencyControls();
            InitializeMagnitudePlot();
            AttachThdFreqMouseEvent();
            InitFftPlot(data.Settings.StartFrequency, data.Settings.EndFrequency, -150, 20);
            InitTimePlot(0, 4, -1, 1);
        }


        void InitThdFrequencySettings()
        {
            data = new();
            data.Settings.StartFrequency = 20;
            data.Settings.EndFrequency = 20000;
            data.Settings.SampleRate = 192000;
            data.Settings.FftSize = 65536 * 2;
            data.Settings.Window = Windowing.Hann;
            data.Settings.StepsPerOctave = 2;
            data.Settings.InputRange = 18;
            data.Settings.GenAmplitudeDbV = -5.5;
            data.Settings.GenAmplitudeV = Math.Pow(10, data.Settings.GenAmplitudeDbV / 20);
            data.Settings.Averages = 1;
            data.Settings.Load = 8;
            data.Settings.AmpOutputPower = 1;
        }

        void SetThdvsFrequencyControls()
        {
            gbThdFreq_dBV_Range.Left = gbThdFreq_D_Range.Left;
            gbThdFreq_dBV_Range.Top = gbThdFreq_D_Range.Top;
            gbThdFreq_dBV_Range.Visible = true;
            gbThdFreq_D_Range.Visible = false;

            cmbThdFreq_GenType.SelectedIndex = 2;       // Output power
            txtThdFreq_GenVoltage.ReadOnly = true;


            txtThdFreq_GenVoltage.Text = data.Settings.GenAmplitudeDbV.ToString("#0.0##");
            cmbThdFreq_GenVoltageUnit.SelectedIndex = 2;   // dBV
            txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeV.ToString("#0.0##");
            cmbThdFreq_OutputVoltageUnit.SelectedIndex = 2;   // dBV
            txtThdFreq_OutputLoad.Text = data.Settings.Load.ToString();           // 8 Ohm
            txtThdFreq_OutputPower.Text = data.Settings.AmpOutputPower.ToString();          // 1 Watt
            txtThdFreq_StartFreq.Text = data.Settings.StartFrequency.ToString();
            txtThdFreq_EndFreq.Text = data.Settings.EndFrequency.ToString();
            udThdFreq_StepsOctave.Value = data.Settings.StepsPerOctave;
            udThdFreq_Averages.Value = data.Settings.Averages;

            cmbThdFreq_D_Graph_Top.SelectedIndex = 2;
            cmbThdFreq_D_Graph_Bottom.SelectedIndex = 3;
            cmbThdFreq_dBV_Graph_Top.Value = 40;
            cmbThdFreq_dBV_Graph_Bottom.Value = -140;
            cmbThdFreq_Graph_From.SelectedIndex = 2;
            cmbThdFreq_Graph_To.SelectedIndex = 4;
            
            Program.MainForm.HideProgressBar();
        }

        void ChangeGenVoltage()
        {
            try
            {
                // input voltage
                switch (cmbThdFreq_GenVoltageUnit.SelectedIndex)
                {
                    case 0: // mV
                        data.Settings.GenAmplitudeV = ParseTextToDouble(txtThdFreq_GenVoltage.Text, data.Settings.GenAmplitudeV) / 1000;
                        data.Settings.GenAmplitudeDbV = 20 * Math.Log10(data.Settings.GenAmplitudeV);
                        break;
                    case 1: // V
                        data.Settings.GenAmplitudeV = ParseTextToDouble(txtThdFreq_GenVoltage.Text, data.Settings.GenAmplitudeV);
                        data.Settings.GenAmplitudeDbV = 20 * Math.Log10(data.Settings.GenAmplitudeV);
                        break;
                    case 2: // dB
                        data.Settings.GenAmplitudeDbV = ParseTextToDouble(txtThdFreq_GenVoltage.Text, data.Settings.GenAmplitudeDbV);
                        data.Settings.GenAmplitudeV = Math.Pow(10, (data.Settings.GenAmplitudeDbV / 20));
                        break;
                }
            }
            catch { }
        }

        void ChangeGenVoltageUnit()
        {
            switch (cmbThdFreq_GenVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtThdFreq_GenVoltage.Text = (data.Settings.GenAmplitudeV * 1000).ToString("###0");
                    break;
                case 1: // V
                    txtThdFreq_GenVoltage.Text = data.Settings.GenAmplitudeV.ToString("#0.0##");
                    break;
                case 2: // dB
                    txtThdFreq_GenVoltage.Text = data.Settings.GenAmplitudeDbV.ToString("#0.0##");
                    break;
            }
        }

        void ChangeAmpOutputVoltage()
        {
            try
            {
                // Output voltage
                switch (cmbThdFreq_OutputVoltageUnit.SelectedIndex)
                {
                    case 0: // mV
                        data.Settings.AmpOutputAmplitudeV = ParseTextToDouble(txtThdFreq_OutputVoltage.Text, data.Settings.AmpOutputAmplitudeV) / 1000;
                        data.Settings.AmpOutputAmplitudeDbV = 20 * Math.Log10(data.Settings.AmpOutputAmplitudeV);
                        break;
                    case 1: // V
                        data.Settings.AmpOutputAmplitudeV = ParseTextToDouble(txtThdFreq_OutputVoltage.Text, data.Settings.AmpOutputAmplitudeV);
                        data.Settings.AmpOutputAmplitudeDbV = 20 * Math.Log10(data.Settings.AmpOutputAmplitudeV);
                        break;
                    case 2: // dB
                        data.Settings.AmpOutputAmplitudeDbV = ParseTextToDouble(txtThdFreq_OutputVoltage.Text, data.Settings.AmpOutputAmplitudeDbV);
                        data.Settings.AmpOutputAmplitudeV = Math.Pow(10, (data.Settings.AmpOutputAmplitudeDbV / 20));
                        break;
                }
            }
            catch { }

        }

        void ChangeAmpOutputVoltageUnit()
        {
            switch (cmbThdFreq_OutputVoltageUnit.SelectedIndex)
            {
                case 0: // mV
                    txtThdFreq_OutputVoltage.Text = (data.Settings.AmpOutputAmplitudeV * 1000).ToString("###0");
                    break;
                case 1: // V
                    txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeV.ToString("#0.0##");
                    break;
                case 2: // dB
                    txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeDbV.ToString("#0.0##");
                    break;
            }
        }

        void ChangeThdFrqGenType()
        {
            switch (cmbThdFreq_GenType.SelectedIndex)
            {
                case 0: // Input voltage
                    txtThdFreq_GenVoltage.ReadOnly = false;
                    txtThdFreq_OutputPower.ReadOnly = true;
                    txtThdFreq_OutputVoltage.ReadOnly = true;
                    switch (cmbThdFreq_GenVoltageUnit.SelectedIndex)
                    {
                        case 0: // mV
                            txtThdFreq_GenVoltage.Text = ((int)(data.Settings.GenAmplitudeV * 1000)).ToString("###0");
                            break;
                        case 1: // V
                            txtThdFreq_GenVoltage.Text = data.Settings.GenAmplitudeV.ToString("#0.0##");
                            break;
                        case 2: // dB
                            txtThdFreq_GenVoltage.Text = data.Settings.GenAmplitudeDbV.ToString("#0.0#");
                            break;
                    }
                    break;
                case 1: // Output voltage
                    txtThdFreq_GenVoltage.ReadOnly = true;
                    txtThdFreq_OutputPower.ReadOnly = true;
                    txtThdFreq_OutputVoltage.ReadOnly = false;
                    switch (cmbThdFreq_GenVoltageUnit.SelectedIndex)
                    {
                        case 0: // mV
                            txtThdFreq_OutputVoltage.Text = ((int)(data.Settings.AmpOutputAmplitudeV * 1000)).ToString("###0");
                            break;
                        case 1: // V
                            txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeV.ToString("#0.0##");
                            break;
                        case 2: // dB
                            txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeDbV.ToString("#0.0#");
                            break;
                    }
                    break;
                case 2: // Output power
                    txtThdFreq_GenVoltage.ReadOnly = true;
                    txtThdFreq_OutputPower.ReadOnly = false;
                    txtThdFreq_OutputVoltage.ReadOnly = true;

                    data.Settings.AmpOutputPower = ParseTextToDouble(txtThdFreq_OutputPower.Text, data.Settings.AmpOutputPower);
                    data.Settings.Load = ParseTextToDouble(txtThdFreq_OutputLoad.Text, data.Settings.Load);
                    data.Settings.AmpOutputAmplitudeV = Math.Sqrt(data.Settings.AmpOutputPower * data.Settings.Load);      // Expected output DUT amplitude in Volts
                    data.Settings.AmpOutputAmplitudeDbV = 20 * Math.Log10(data.Settings.AmpOutputAmplitudeV);     // Expected output DUT amplitude in dBV
                    switch (cmbThdFreq_GenVoltageUnit.SelectedIndex)
                    {
                        case 0: // mV
                            txtThdFreq_OutputVoltage.Text = ((int)(data.Settings.AmpOutputAmplitudeV * 1000)).ToString();
                            break;
                        case 1: // V
                            txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeV.ToString("#0.0##");
                            break;
                        case 2: // dB
                            txtThdFreq_OutputVoltage.Text = data.Settings.AmpOutputAmplitudeDbV.ToString("#0.0#");
                            break;
                    }
                    break;
            }
        }

        /// <summary>
        /// Show a message
        /// </summary>
        /// <param name="message"></param>
        void ShowMessage(string message)
        {
           Program.MainForm.ShowMessage(message);
        }

        /// <summary>
        /// Clear the message
        /// </summary>
        void ClearMessage()
        {
            Program.MainForm.ClearMessage();
        }

        /// <summary>
        /// Determine the generator voltage for the desired output voltage
        /// </summary>
        /// <param name="startGeneratorAmplitude">The amplitude to start with. Should be small but the output should be detectable</param>
        /// <param name="desiredOutputAmplitude">The desired output amplitude</param>
        /// <returns></returns>
        async Task<double> DetermineGenAmplitudeByOutputAmplitude(double startGeneratorAmplitude, double desiredOutputAmplitude)
        {
            await Qa40x.SetGen1(1000, startGeneratorAmplitude, true);           // Enable generator with start amplitude at 1 kHz
            await Qa40x.SetOutputSource(OutputSources.Sine);                    // Set sine wave
            LeftRightSeries as1 = await QaLibrary.DoAcquisitions(1);            // Do a single aqcuisition
            LeftRightPair plrp = await Qa40x.GetPeakDbv(995, 1005);             // Get peak amplitude around 1 kHz
            double leftPeakDbV = plrp.Left;                                     
            //double rightPeak = plrp.Right;
            PlotMiniFftGraph(as1.FreqInput);                                             // Plot fft data in mini graph
            PlotMiniTimeGraph(as1.TimeInput, 1000);                                      // Plot time data in mini graph
            double amplitude = startGeneratorAmplitude + (desiredOutputAmplitude - leftPeakDbV);    // Determine amplitude for desired output amplitude based on measurement
            // Check if amplitude not too high or too low.
            if (amplitude >= 18)
            {
                // Display a message box with OK and Cancel buttons
                DialogResult result = MessageBox.Show(
                    "The generator will be set to its maximum amplitude.\nDo you want to proceed?",          // Message
                    "Maximum generator amplitude",                    // Title
                    MessageBoxButtons.OKCancel,        // Buttons
                    MessageBoxIcon.Question            // Icon
                );

                // Check which button was clicked
                if (result == DialogResult.OK)
                {
                    return 18;
                }
                else if (result == DialogResult.Cancel)
                {
                    return -150;
                }
            }
            else if (amplitude <= -40)
            {
                MessageBox.Show("Check if the amplifier is connected and switched on.", "Could not determine amplitude", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return -150;
            }

            return amplitude;       // Return the new generator amplitude
        }



        private bool MeasurementBusy;

        async Task<bool> PerformMeasurementSteps(CancellationToken ct)
        {
            clearThdPlot();

            data.StepData = [];

            markerIndex = -1;       // Reset marker

            // Init mini plots
            InitFftPlot(data.Settings.StartFrequency, data.Settings.EndFrequency, -150, 20);
            InitTimePlot(0, 4, -1, 1);

            // Check if webserver available
            if (!IsServerRunning())
            {
                MessageBox.Show($"QA40X application is not running.\nPlease start the application first.", "Could not reach webserver", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // Check if device connected
            if (!await Qa40x.IsConnected())
            {
                MessageBox.Show($"QA40X analyser is not connected via USB.\nPlease connect the device first.", "QA40X not connected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            bool busy = await Qa40x.IsBusy();
            if (busy)
            {
                MessageBox.Show($"The QA40x seems to be already runnng. Stop the aqcuisition and generator in the QuantAsylum software manually.", "QA40X busy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // ********************************************************************
            // Check connection
            // Load a settings file with the particulars we want
            await Qa40x.SetDefaults();

            await Qa40x.SetGraphXAxis((uint)data.Settings.StartFrequency, (uint)data.Settings.EndFrequency);
            // Turn the generator off
            await Qa40x.SetOutputSource(OutputSources.Off);            // We need to call this to make it turn on or off

            await Qa40x.SetSampleRate(data.Settings.SampleRate);
            await Qa40x.SetBufferSize(data.Settings.FftSize);

            await Qa40x.SetWindowing(data.Settings.Window);
            await Qa40x.SetRoundFrequencies(true);
            // Muting of right channel


            // ********************************************************************
            // Determine input level
            // ********************************************************************
            if (cmbThdFreq_GenType.SelectedIndex == 1 || cmbThdFreq_GenType.SelectedIndex == 2)     // Based on output
            {
                if (cmbThdFreq_GenType.SelectedIndex == 1)
                    ShowMessage($"Determining generator amplitude to get an output amplitude of {data.Settings.AmpOutputAmplitudeDbV:0.00#} dBV.");
                else
                    ShowMessage($"Determining generator amplitude to get an output power of {data.Settings.AmpOutputPower:0.00#} W.");

                // Get input voltage based on desired output voltage
                data.Settings.InputRange = QaLibrary.DetermineAttenuation(data.Settings.AmpOutputAmplitudeDbV);
                double startAmplitude = -40;  // 10 mV
                data.Settings.GenAmplitudeDbV = await DetermineGenAmplitudeByOutputAmplitude(startAmplitude, data.Settings.AmpOutputAmplitudeDbV);
                if (data.Settings.GenAmplitudeDbV == -150)
                {
                    ShowMessage($"Could not determine a valid generator amplitude. The amplitude would be {data.Settings.AmpOutputAmplitudeDbV:0.00#} dBV.");
                    return false;
                }

                if (ct.IsCancellationRequested)
                    return false;

                if (data.Settings.GenAmplitudeDbV < 18)
                {
                    ShowMessage($"Found an input amplitude of {data.Settings.GenAmplitudeDbV:0.00#} dBV. Doing second pass.");

                    // 2nd time for extra accuracy
                    data.Settings.GenAmplitudeDbV = await DetermineGenAmplitudeByOutputAmplitude(data.Settings.GenAmplitudeDbV, data.Settings.AmpOutputAmplitudeDbV);
                    if (data.Settings.GenAmplitudeDbV == -150)
                    {
                        ShowMessage($"Could not determine a valid generator amplitude. The amplitude would be {data.Settings.AmpOutputAmplitudeDbV:0.00#} dBV.");
                        return false;
                    }
                }
            
                ChangeGenVoltageUnit();

                ShowMessage($"Found an input amplitude of {data.Settings.GenAmplitudeDbV:0.00#} dBV.");
            }
            else if (cmbThdFreq_GenType.SelectedIndex == 0)                         // Based on input voltage
            {
                ShowMessage($"Determining the best input attenuation for a generator voltage of {data.Settings.GenAmplitudeDbV:0.00#} dBV.");

                // Determine correct input attenuation
                await DetermineAttenuation();

                ShowMessage($"Found correct input attenuation of {data.Settings.InputRange:0} dBV for an amplfier amplitude of {data.Settings.AmpOutputAmplitudeDbV:0.00#} dBV.");
                await Task.Delay(500);
            }
            await Qa40x.SetInputRange(data.Settings.InputRange);

            if (ct.IsCancellationRequested)
                return false;

            // ********************************************************************
            var binSize = QaLibrary.CalcBinSize(data.Settings.SampleRate, data.Settings.FftSize);
            // Generate a list of frequencies
            var stepFrequencies = QaLibrary.GetLineairSpacedLogarithmicFrequenciesPerOctave(data.Settings.StartFrequency, data.Settings.EndFrequency, data.Settings.StepsPerOctave);
            // Translate the generated list to bin center frequncies
            var stepBins = QaLibrary.TranslateToBinFrequencies(stepFrequencies, data.Settings.SampleRate, data.Settings.FftSize);

            // ********************************************************************
            // Do noise floor measurement
            // ********************************************************************
            ShowMessage($"Determining noise floor.");
            await Qa40x.SetOutputSource(OutputSources.Off);
            await Qa40x.DoAcquisition();
            LeftRightSeries noiseFloor = await QaLibrary.DoAcquisitions(data.Settings.Averages);
            data.NoiseFloor = noiseFloor;

            Program.MainForm.SetupProgressBar(0, stepBins.Length);

            //await Qa40x.SetGraphXAxis((uint)data.Settings.StartFrequency, (uint)data.Settings.EndFrequency);  // Does not seem to work
            

            // ********************************************************************
            // Step through the list of frequencies
            // ********************************************************************
            for (int f = 0; f < stepBins.Length; f++)
            {
                ShowMessage($"Measuring step {f + 1} of {stepBins.Length}.");
                Program.MainForm.UpdateProgressBar(f+1);

                // Set the generator
                await Qa40x.SetGen1(stepBins[f], data.Settings.GenAmplitudeDbV, true);
                if (f == 0)
                    await Qa40x.SetOutputSource(OutputSources.Sine);            // We need to call this to make the averages reset
                                                                                //await Task.Delay(data.SettleTimeMs);                        // Wait for DUT to settle

                LeftRightSeries lrfs = await QaLibrary.DoAcquisitions(data.Settings.Averages);


                FrequencyThdStep step = new()
                {
                    FundamentalFrequency = stepBins[f],
                    fftData = lrfs.FreqInput,
                    timeData = lrfs.TimeInput,
                    DcComponent = lrfs.TimeInput.Left.Average()
                };

                uint fundamentalBin = QaLibrary.GetBinOfFrequency(step.FundamentalFrequency, binSize);
                if (fundamentalBin >= lrfs.FreqInput.Left.Length)               // Check in bin within range
                    break;

                step.AmplitudeVolts = lrfs.FreqInput.Left[fundamentalBin];
                step.AmplitudeDbV = 20 * Math.Log10(lrfs.FreqInput.Left[fundamentalBin]);
                step.MagnitudeDb = 20 * Math.Log10(step.AmplitudeVolts / Math.Pow(10, data.Settings.GenAmplitudeDbV / 20));
                step.NoiseFloorV = data.NoiseFloor.FreqInput.Left               // Average noise floor
                    .Select((v, i) => new { Index = i, Value = v })
                    .Where(p => p.Index > fundamentalBin)
                    .Select(v => v.Value)
                    .Average();
                step.NoiseFloorDbV = 20 * Math.Log10(step.NoiseFloorV);

                // Plot the mini graphs
                PlotMiniFftGraph(lrfs.FreqInput);
                PlotMiniTimeGraph(lrfs.TimeInput, step.FundamentalFrequency);

                double distortionSqrtTotal = 0;
                double distiortionD6plus = 0;

                // Loop through harmonics
                for (int h = 2; h <= 12; h++)                                   // For now up to 12 harmonics, start at 2nd
                {
                    HarmonicData harmonic = new()
                    {
                        HarmonicNr = h,
                        Frequency = stepBins[f] * h
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

                // Calculate D6+
                if (distiortionD6plus != 0)
                {
                    step.D6PlusDbV = 20 * Math.Log10(Math.Sqrt(distiortionD6plus));
                    step.ThdPercentD6plus = Math.Sqrt(distiortionD6plus / Math.Pow(step.AmplitudeVolts, 2)) * 100;
                    step.ThdDbD6plus = 20 * Math.Log10(step.ThdPercentD6plus / 100.0);
                }

                // If load not zero then calculate load power
                if (data.Settings.Load != 0)
                    step.PowerWatt = Math.Pow(step.AmplitudeVolts, 2) / data.Settings.Load;

                // Calculate THD+N      TODO: Check, I don't think this is correct.
                step.ThdDbN = lrfs.FreqInput.Left
                    .Select((v, i) => new { Index = i, Value = v })
                    .Where(p => p.Index != fundamentalBin && p.Index != fundamentalBin - 1 && p.Index != fundamentalBin + 1)
                    .Sum(v => Math.Pow(v.Value, 2));

                step.ThdDbN = (Math.Sqrt(step.ThdDbN) / lrfs.FreqInput.Left[fundamentalBin]) * 100;


                // Add step data to list
                data.StepData.Add(step);

                // Plot the data
                if (gbThdFreq_dBV_Range.Visible)
                {
                    // dBV plot is selected
                    PlotMagnitude(data);
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
                        , data.Settings.Load
                        );
                }
                else
                {
                    // Thd percent plot is selected
                    PlotThd(data);
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
                        , data.Settings.Load
                        );
                }

                if (ct.IsCancellationRequested)
                {
                    await Qa40x.SetOutputSource(OutputSources.Off);                                             // Be sure to switch gen off
                    return false;
                }
            }

            // Turn the generator off
            await Qa40x.SetOutputSource(OutputSources.Off);

            // Show message
            ShowMessage($"Measurment finished!");
            await Task.Delay(500);
            ClearMessage();

            // Hide progressbar
            Program.MainForm.HideProgressBar();

            return true;
        }

        /// <summary>
        ///  Determine the best attenuation for the output amplitude
        /// </summary>
        /// <returns></returns>
        private async Task DetermineAttenuation()
        {
            await Qa40x.SetInputRange(42);                                      // Set input range to safe range
            await Qa40x.SetGen1(1000, data.Settings.GenAmplitudeDbV, true);     // Enable generator at set voltage
            await Qa40x.SetOutputSource(OutputSources.Sine);
            LeftRightSeries as1 = await QaLibrary.DoAcquisitions(1);            // Do acquisition
            LeftRightPair plrp = await Qa40x.GetPeakDbv(995, 1005);             // Get peak value at 1 kHz
            data.Settings.AmpOutputAmplitudeDbV = plrp.Left;                    // Set settings
            data.Settings.InputRange = QaLibrary.DetermineAttenuation(data.Settings.AmpOutputAmplitudeDbV);     // Determine attenuation and set input range
            await Qa40x.SetOutputSource(OutputSources.Off);                     // Disable generator

            PlotMiniFftGraph(as1.FreqInput);                                    // Plot the data in the mini graph
            PlotMiniTimeGraph(as1.TimeInput, 1000);
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
            lblThdFreq_Frequency.Text = $"Frequency: {f:0.## Hz}";
            lblThdFreq_Magnitude.Text = $"Magn: {magnitude:0.## dB}";
            lblThdFreq_THD.Text = $"THD: {thd:0.0000# \\%}";

            lblThdFreq_D2.Text = $"D2: {D2:0.0000# \\%}";
            lblThdFreq_D3.Text = $"D3: {D3:0.0000# \\%}";
            lblThdFreq_D4.Text = $"D4: {D4:0.0000# \\%}";
            lblThdFreq_D5.Text = $"D5: {D5:0.0000# \\%}";
            lblThdFreq_D6.Text = $"D6+: {D6:0.0000# \\%}";
            lblThdFreq_DC.Text = $"DC: {dc * 1000:0.0# mV}";

            if (power < 1)
                lblThdFreq_Power.Text = $"Power: {power * 1000:0.0# mW} ({load:0.##} Ω)";
            else
                lblThdFreq_Power.Text = $"Power: {power:0.00# W} ({load:0.##} Ω)";

            lblThdFreq_NoiseFloor.Text = $"Noise floor: {noiseFloor:##0.0# dB}";

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
            lblThdFreq_Frequency.Text = $"Frequency: {f:0.## Hz}";
            lblThdFreq_Magnitude.Text = $"Magn: {magnitude:0.## dB}";
            lblThdFreq_THD.Text = $"THD: {thd:0.0# dB}";

            lblThdFreq_D2.Text = $"D2: {D2:##0.0# dB}";
            lblThdFreq_D3.Text = $"D3: {D3:##0.0# dB}";
            lblThdFreq_D4.Text = $"D4: {D4:##0.0# dB}";
            lblThdFreq_D5.Text = $"D5: {D5:##0.0# dB}";
            lblThdFreq_D6.Text = $"D6+: {D6:##0.0# dB}";
            lblThdFreq_DC.Text = $"DC: {dc * 1000:0.0# mV}";

            if (power < 1)
                lblThdFreq_Power.Text = $"Power: {power * 1000:0.0# mW} ({load:0.##} Ω)";
            else
                lblThdFreq_Power.Text = $"Power: {power:0.00# W} ({load:0.##} Ω)";

            lblThdFreq_NoiseFloor.Text = $"Noise floor: {noiseFloor:##0.0# dB}";
        }

        /// <summary>
        /// Initlialize the THD frequency plot
        /// </summary>
        /// <param name="startFrequency"></param>
        /// <param name="endFrequency"></param>
        /// <param name="minDbV"></param>
        /// <param name="maxDbV"></param>
        void InitFftPlot(double startFrequency, double endFrequency, double minDbV, double maxDbV)
        {
            graphFft.Plot.Clear();

            // create a minor tick generator that places log-distributed minor ticks
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGen = new()
            {
                Divisions = 1
            };

            // create a numeric tick generator that uses our custom minor tick generator
            ScottPlot.TickGenerators.NumericAutomatic tickGen = new()
            {
                MinorTickGenerator = minorTickGen
            };

            // create a custom tick formatter to set the label text for each tick
            //static string LogTickLabelFormatter(double y) => $"{Math.Pow(10, y):G}";

            // tell our major tick generator to only show major ticks that are whole integers
            //tickGen.IntegerTicksOnly = true;

            // tell our custom tick generator to use our new label formatter
            // tickGen.LabelFormatter = LogTickLabelFormatter;

            // tell the left axis to use our custom tick generator
            graphFft.Plot.Axes.Left.TickGenerator = tickGen;



            // create a minor tick generator that places log-distributed minor ticks
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGenX = new();

            // create a numeric tick generator that uses our custom minor tick generator
            //ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();
            //tickGenX.MinorTickGenerator = minorTickGenX;

            // create a manual tick generator and add ticks
            ScottPlot.TickGenerators.NumericManual tickGenX = new();

            // add major ticks with their labels
            tickGenX.AddMajor(Math.Log10(1), "1");
            tickGenX.AddMajor(Math.Log10(10), "10");
            tickGenX.AddMajor(Math.Log10(100), "100");
            tickGenX.AddMajor(Math.Log10(1000), "1k");
            tickGenX.AddMajor(Math.Log10(10000), "10k");
            tickGenX.AddMajor(Math.Log10(100000), "100k");

            graphFft.Plot.Axes.Bottom.TickGenerator = tickGenX;


            // show grid lines for minor ticks
            graphFft.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            graphFft.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.08);
            graphFft.Plot.Grid.MinorLineWidth = 1;

            graphFft.Plot.Axes.SetLimits((data.Settings.StartFrequency < 10 ? Math.Log10(1) : Math.Log10(10)), Math.Log10(100000), minDbV, maxDbV);
            graphFft.Plot.Title("dBV");
            graphFft.Plot.Axes.Title.Label.FontSize = 12;
            graphFft.Plot.Axes.Title.Label.OffsetY = 8;
            graphFft.Plot.Axes.Title.Label.Bold = false;

            graphFft.Plot.XLabel("Hz");
            graphFft.Plot.Axes.Bottom.Label.OffsetX = 85;
            graphFft.Plot.Axes.Bottom.Label.OffsetY = -5;
            graphFft.Plot.Axes.Bottom.Label.FontSize = 12;
            graphFft.Plot.Axes.Bottom.Label.Bold = false;
            graphFft.Plot.Axes.Bottom.Label.IsVisible = true;

            graphFft.Plot.Legend.IsVisible = false;

            graphFft.Refresh();

        }

        void PlotMiniFftGraph(LeftRightFrequencySeries fftData)
        {
            graphFft.Plot.Clear();

            List<double> freqX = [];
            List<double> dbVY = [];
            double frequency = 0;

            for (int f = 0; f < fftData.Left.Length; f++)
            {
                frequency += fftData.Df;
                freqX.Add(frequency);
                dbVY.Add(20 * Math.Log10(fftData.Left[f]));
            }

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();

            double[] logHTotY = dbVY.ToArray();
            var plotTot = graphFft.Plot.Add.Scatter(logFreqX, logHTotY);
            plotTot.LineWidth = 1;
            plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(1, 97, 170));
            plotTot.MarkerSize = 1;

            graphFft.Refresh();
        }




        void InitTimePlot(double startTime, double endTime, double minVoltage, double maxVoltage)
        {
            graphTime.Plot.Clear();

            ScottPlot.TickGenerators.EvenlySpacedMinorTickGenerator minorTickGenX = new(2);
            ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();
            tickGenX.TargetTickCount = 4;
            tickGenX.MinorTickGenerator = minorTickGenX;
            graphTime.Plot.Axes.Bottom.TickGenerator = tickGenX;

            ScottPlot.TickGenerators.EvenlySpacedMinorTickGenerator minorTickGenY = new(2);
            ScottPlot.TickGenerators.NumericAutomatic tickGenY = new();
            tickGenY.TargetTickCount = 4;
            tickGenY.MinorTickGenerator = minorTickGenY;
            graphTime.Plot.Axes.Left.TickGenerator = tickGenY;



            // show grid lines for minor ticks
            graphTime.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            graphTime.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.08);
            graphTime.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            graphTime.Plot.Axes.SetLimits(startTime, endTime, minVoltage, maxVoltage);
            graphTime.Plot.Title("V (input)");
            graphTime.Plot.Axes.Title.Label.FontSize = 12;
            graphTime.Plot.Axes.Title.Label.OffsetY = 8;
            graphTime.Plot.Axes.Title.Label.Bold = false;

            graphTime.Plot.XLabel("ms");
            graphTime.Plot.Axes.Bottom.Label.OffsetX = 90;
            graphTime.Plot.Axes.Bottom.Label.OffsetY = -5;
            graphTime.Plot.Axes.Bottom.Label.FontSize = 12;
            graphTime.Plot.Axes.Bottom.Label.Bold = false;


            graphTime.Plot.Legend.IsVisible = false;

            graphTime.Refresh();

        }


        void PlotMiniTimeGraph(LeftRightTimeSeries timeData, double frequency)
        {
            graphTime.Plot.Clear();

            List<double> timeX = [];
            List<double> voltY = [];
            double time = 0;

            double period = 1 / frequency;
            double displayTime = period * 1;
            if (period < 0.00005)
                displayTime = period * 4;
            else if (period < 0.0001)
                displayTime = period * 2;
            else if (period < 0.0002)
                displayTime = period * 1.5;

            // Get first zero-crossing
            int startStep = 0;
            for (int f = 1; f < timeData.Left.Length; f++)
            {
                if (timeData.Left[f - 1] < 0 && timeData.Left[f] >= 0)
                {
                    startStep = f;
                    break;
                }
            }

            // Determine start index of array at zero-crossing
            double displaySteps = (displayTime / timeData.dt) + startStep;
            if (displaySteps > timeData.Left.Length)
                displaySteps = timeData.Left.Length;

            double maxVolt = 0;
            for (int f = startStep; f < displaySteps; f++)
            {
                timeX.Add(time);
                voltY.Add(timeData.Left[f]);
                if (maxVolt < Math.Abs(timeData.Left[f]))
                    maxVolt = Math.Abs(timeData.Left[f]);
                time += timeData.dt * 1000;
            }

            maxVolt *= 1.1;
            if (maxVolt > 1)
                maxVolt = Math.Ceiling(maxVolt);
            else if (maxVolt > 0.1)
                maxVolt = Math.Ceiling(maxVolt * 10) / 10;
            else if (maxVolt > 0.01)
                maxVolt = Math.Ceiling(maxVolt * 100) / 100;
            else if (maxVolt > 0.001)
                maxVolt = Math.Ceiling(maxVolt * 1000) / 1000;
            else if (maxVolt > 0.0001)
                maxVolt = Math.Ceiling(maxVolt * 10000) / 10000;
            else if (maxVolt > 0.00001)
                maxVolt = Math.Ceiling(maxVolt * 100000) / 100000;

            // add a scatter plot to the plot
            var plotTot = graphTime.Plot.Add.Scatter(timeX, voltY);
            plotTot.LineWidth = 1;
            plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(1, 97, 170));
            plotTot.MarkerSize = 1;

            graphTime.Plot.Axes.SetLimits(0, time, -maxVolt, maxVolt);

            graphTime.Refresh();
        }


        void clearThdPlot()
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
            if (cmbThdFreq_Graph_From.SelectedIndex > -1 && cmbThdFreq_Graph_To.SelectedIndex > -1 && cmbThdFreq_D_Graph_Bottom.SelectedIndex > -1 && cmbThdFreq_D_Graph_Top.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbThdFreq_Graph_From.Text)), Math.Log10(Convert.ToDouble(cmbThdFreq_Graph_To.Text)), Math.Log10(Convert.ToDouble(cmbThdFreq_D_Graph_Bottom.Text)), Math.Log10(Convert.ToDouble(cmbThdFreq_D_Graph_Top.Text)));
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

        void PlotThd(ThdAmplitudeMeasurementData data)
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

                if (data.StepData[f].Harmonics.Count > 0 && chkThdFreq_ShowThd.Checked)
                    hTotY.Add(data.StepData[f].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 0 && chkThdFreq_ShowD2.Checked)
                    h2Y.Add(data.StepData[f].Harmonics[0].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 1 && chkThdFreq_ShowD3.Checked)
                    h3Y.Add(data.StepData[f].Harmonics[1].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 2 && chkThdFreq_ShowD4.Checked)
                    h4Y.Add(data.StepData[f].Harmonics[2].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 3 && chkThdFreq_ShowD5.Checked)
                    h5Y.Add(data.StepData[f].Harmonics[3].ThdPercent);
                if (data.StepData[f].Harmonics.Count > 4 && data.StepData[f].ThdPercentD6plus != 0 && chkThdFreq_ShowD6.Checked)
                    h6Y.Add(data.StepData[f].ThdPercentD6plus);        // D6+
                if (chkThdFreq_ShowNoiseFloor.Checked)
                    noiseY.Add((data.StepData[f].NoiseFloorV / data.StepData[f].AmplitudeVolts) * 100);
            }

            IPalette palette = new ScottPlot.Palettes.Category10();
            float lineWidth = 1;
            float markerSize = 1;
            if (chkThdFreq_ThickLines.Checked)
                lineWidth = 2;
            if (chkThdFreq_ShowMarkers.Checked)
                markerSize = lineWidth + 3;

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();

            if (chkThdFreq_ShowThd.Checked)
            {
                double[] logHTotY = hTotY.Select(Math.Log10).ToArray();
                var plotTot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                plotTot.LineWidth = lineWidth;
                plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Black);
                plotTot.MarkerSize = markerSize;
                plotTot.LegendText = "THD";
            }

            if (chkThdFreq_ShowD2.Checked)
            {
                double[] logH2Y = h2Y.Select(Math.Log10).ToArray();
                var plot1 = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                plot1.LineWidth = lineWidth;
                //plot1.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Orange);
                plot1.Color = palette.GetColor(0);
                plot1.MarkerSize = markerSize;
                plot1.LegendText = "D2";
            }

            if (chkThdFreq_ShowD3.Checked)
            {
                double[] logH3Y = h3Y.Select(Math.Log10).ToArray();
                var plot2 = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                plot2.LineWidth = lineWidth;
                //plot2.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
                plot2.Color = palette.GetColor(1);
                plot2.MarkerSize = markerSize;
                plot2.LegendText = "D3";
            }

            if (chkThdFreq_ShowD4.Checked)
            {
                double[] logH4Y = h4Y.Select(Math.Log10).ToArray();
                var plot3 = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                //plot3.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
                plot3.Color = palette.GetColor(2);
                plot3.LineWidth = lineWidth;
                plot3.MarkerSize = markerSize;
                plot3.LegendText = "D4";
            }

            if (chkThdFreq_ShowD5.Checked)
            {
                double[] logH5Y = h5Y.Select(Math.Log10).ToArray();
                var plot4 = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                plot4.LineWidth = lineWidth;
                //plot4.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Purple);
                plot4.Color = palette.GetColor(3);
                plot4.MarkerSize = markerSize;
                plot4.LegendText = "D5";
            }

            if (chkThdFreq_ShowD6.Checked)
            {
                double[] logH6Y = h6Y.Select(Math.Log10).ToArray();
                var plot5 = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                plot5.LineWidth = lineWidth;
                //plot5.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Brown);
                plot5.Color = palette.GetColor(4);
                plot5.MarkerSize = markerSize;
                plot5.LegendText = "D6+";
            }


            if (chkThdFreq_ShowNoiseFloor.Checked)
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
                PlotCursorMarker(1, LinePattern.Solid, markerDataPoint);

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
            if (cmbThdFreq_Graph_From.SelectedIndex > -1 && cmbThdFreq_Graph_To.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbThdFreq_Graph_From.Text)), Math.Log10(Convert.ToDouble(cmbThdFreq_Graph_To.Text)), Convert.ToDouble(cmbThdFreq_dBV_Graph_Bottom.Value), Convert.ToDouble(cmbThdFreq_dBV_Graph_Top.Value));
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



        void PlotMagnitude(ThdAmplitudeMeasurementData data)
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

                if (chkThdFreq_ShowMagnitude.Checked)
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
                if (data.StepData[f].D6PlusDbV != 0 && data.StepData[f].Harmonics.Count > 4 && chkThdFreq_ShowD6.Checked)
                    h6Y.Add(data.StepData[f].D6PlusDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
                if (chkThdFreq_ShowNoiseFloor.Checked)
                    noiseY.Add(data.StepData[f].NoiseFloorDbV - data.StepData[f].AmplitudeDbV + data.StepData[f].MagnitudeDb);
            }

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();
            float lineWidth = 1;
            float markerSize = 1;
            if (chkThdFreq_ThickLines.Checked)
                lineWidth = 2;
            if (chkThdFreq_ShowMarkers.Checked)
                markerSize = lineWidth + 3;

            IPalette palette = new ScottPlot.Palettes.Category10();

            if (chkThdFreq_ShowMagnitude.Checked)
            {
                double[] logMagnY = magnY.ToArray();
                var plot1 = thdPlot.Plot.Add.Scatter(logFreqX, logMagnY);
                plot1.LineWidth = lineWidth;
                plot1.LinePattern = LinePattern.DenselyDashed;
                plot1.Color = ScottPlot.Color.FromColor(System.Drawing.Color.DarkBlue);
                plot1.MarkerSize = markerSize;
                plot1.LegendText = "Magn";
            }

            if (chkThdFreq_ShowThd.Checked)
            {
                double[] logHTotY = hTotY.ToArray();
                var plotTot = thdPlot.Plot.Add.Scatter(logFreqX, logHTotY);
                plotTot.LineWidth = lineWidth;
                plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Black);
                plotTot.MarkerSize = markerSize;
                plotTot.LegendText = "THD";
            }

            if (chkThdFreq_ShowD2.Checked)
            {
                double[] logH2Y = h2Y.ToArray();
                var plot2 = thdPlot.Plot.Add.Scatter(logFreqX, logH2Y);
                plot2.LineWidth = lineWidth;
                //plot2.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Orange);
                plot2.Color = palette.GetColor(0);
                plot2.MarkerSize = markerSize;
                plot2.LegendText = "H2";
            }

            if (chkThdFreq_ShowD3.Checked)
            {
                double[] logH3Y = h3Y.ToArray();
                var plot3 = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                plot3.LineWidth = lineWidth;
                //plot3.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
                plot3.Color = palette.GetColor(1);
                plot3.MarkerSize = markerSize;
                plot3.LegendText = "H3";
            }

            if (chkThdFreq_ShowD4.Checked)
            {
                double[] logH4Y = h4Y.ToArray();
                var plot4 = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                plot4.LineWidth = lineWidth;
                //plot4.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
                plot4.Color = palette.GetColor(2);
                plot4.MarkerSize = markerSize;
                plot4.LegendText = "H4";
            }

            if (chkThdFreq_ShowD5.Checked)
            {
                double[] logH5Y = h5Y.ToArray();
                var plot5 = thdPlot.Plot.Add.Scatter(logFreqX, logH5Y);
                plot5.LineWidth = lineWidth;
                //plot5.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Purple);
                plot5.Color = palette.GetColor(3);
                plot5.MarkerSize = markerSize;
                plot5.LegendText = "H5";
            }

            if (chkThdFreq_ShowD6.Checked)
            {
                double[] logH6Y = h6Y.ToArray();
                var plot6 = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                plot6.LineWidth = lineWidth;
                //plot6.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Brown);
                plot6.Color = palette.GetColor(4);
                plot6.MarkerSize = markerSize;
                plot6.LegendText = "H6+";
            }

            if (chkThdFreq_ShowNoiseFloor.Checked)
            {
                double[] logNoiseY = noiseY.ToArray();
                var plot7 = thdPlot.Plot.Add.ScatterLine(logFreqX, logNoiseY);
                plot7.LineWidth = lineWidth;
                plot7.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Gray);
                //plot7.Color = palette.GetColor(6);
                plot7.MarkerSize = markerSize;
                plot7.LegendText = "Noise";
                plot7.LinePattern = LinePattern.Dotted;
            }

            if (markerIndex != -1)
            {
                PlotCursorMarker(1, LinePattern.Solid, markerDataPoint);
            }

            thdPlot.Refresh();
        }

        /// <summary>
        /// Attach mouse events to the main graph
        /// </summary>
        void AttachThdFreqMouseEvent()
        {

            thdPlot.MouseMove += (s, e) =>
            {

                ShowCursorMiniGraphs(s, e);
                SetCursorMarker(s, e, false);

            };

            thdPlot.MouseDown += (s, e) =>
            {
                SetCursorMarker(s, e, true);      // Set fixed marker
            };

            thdPlot.MouseLeave += (s, e) =>
            {
                // If clicked marker then show mini plots of that marker
                if (markerIndex >= 0)
                {
                    PlotMiniFftGraph(data.StepData[markerIndex].fftData);
                    PlotMiniTimeGraph(data.StepData[markerIndex].timeData, data.StepData[markerIndex].FundamentalFrequency);
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
            if (nearest1.IsReal)
            {
                PlotMiniFftGraph(data.StepData[nearest1.Index].fftData);
                PlotMiniTimeGraph(data.StepData[nearest1.Index].timeData, data.StepData[nearest1.Index].FundamentalFrequency);
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

                PlotCursorMarker(lineWidth, linePattern, nearest1);


                if (data.StepData.Count > nearest1.Index)
                {
                    FrequencyThdStep step = data.StepData[nearest1.Index];

                    if (gbThdFreq_dBV_Range.Visible)
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
                        , data.Settings.Load
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
                        , data.Settings.Load
                        );
                    }


                }

            }
        }

        void PlotCursorMarker(float lineWidth, LinePattern linePattern, DataPoint point)
        {
            thdPlot.Plot.Remove<Crosshair>();

            var myCrosshair = thdPlot.Plot.Add.Crosshair(point.Coordinates.X, point.Coordinates.Y);
            myCrosshair.IsVisible = true;
            myCrosshair.LineWidth = lineWidth;
            myCrosshair.LineColor = Colors.Magenta;
            myCrosshair.MarkerShape = MarkerShape.None;
            myCrosshair.MarkerSize = 1;
            myCrosshair.LinePattern = linePattern;
            myCrosshair.HorizontalLine.IsVisible = false;
            myCrosshair.Position = point.Coordinates;


            thdPlot.Refresh();
        }


        /// <summary>
        /// Function to allow only numeric input (integers or decimals)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="integersOnly"></param>
        public static void AllowNumericInput(object sender, KeyPressEventArgs e, bool integersOnly = false)
        {
            var textBox = sender as System.Windows.Forms.TextBox;

            // Allow control keys (e.g., backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Replace comma with decimal point
            if (e.KeyChar == ',')
            {
                e.KeyChar = '.';
            }

            // Check if the key is a decimal point
            if (e.KeyChar == '.')
            {
                // If there's already a decimal point, prevent input

                if (textBox.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }
            }

            // Handle negative sign
            if (e.KeyChar == '-')
            {
                // Allow the negative sign only at the beginning of the text
                if (textBox.SelectionStart != 0 || textBox.Text.Contains("-"))
                {
                    e.Handled = true; // Reject if not at the start or already present
                }
            }

            if (integersOnly && e.KeyChar == '.' && e.KeyChar != '-')
            {
                e.Handled = true; // Reject invalid characters
            }

            // Allow only digits and optionally the decimal separator
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true; // Reject invalid characters
            }
        }

        /// <summary>
        /// Function to check range and update text color
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="minimal"></param>
        /// <param name="maximum"></param>
        public static void CheckRangeAndUpdateColor(object sender, double minimal, double maximum)
        {
            // Get the TextBox object
            var textBox = sender as System.Windows.Forms.TextBox;
            if (textBox == null) return;

            // Determine the culture-specific decimal separator
            char decimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            // Replace ',' with '.' if applicable
            string text = textBox.Text.Replace(',', decimalSeparator).Replace('.', decimalSeparator);

            // Try to parse the text as a double
            if (double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out double value))
            {
                // Check if the value is within the range
                if (value >= minimal && value <= maximum)
                {
                    textBox.ForeColor = System.Drawing.Color.Black; // Valid input
                }
                else
                {
                    textBox.ForeColor = System.Drawing.Color.Red; // Out of range
                }
            }
            else
            {
                textBox.ForeColor = System.Drawing.Color.Red; // Invalid input
            }
        }

        private static double ParseTextToDouble(string text, double original)
        {

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out double val))
                return val;

            return original;

        }


        private async void btnStartThdMeasurement_Click(object sender, EventArgs e)
        {
            MeasurementBusy = true;
            btnStopThdMeasurement.Enabled = true;
            btnStopThdMeasurement.ForeColor = System.Drawing.Color.Black;
            btnStartThdMeasurement.Enabled = false;
            btnStartThdMeasurement.ForeColor = System.Drawing.Color.DimGray;
            ct = new();
            await PerformMeasurementSteps(ct.Token);
            MeasurementBusy = false;
            btnStopThdMeasurement.Enabled = false;
            btnStopThdMeasurement.ForeColor = System.Drawing.Color.DimGray;
            btnStartThdMeasurement.Enabled = true;
            btnStartThdMeasurement.ForeColor = System.Drawing.Color.Black;
        }


        private void btnCancelThdMeasurement_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }

        private void graphTime_Load(object sender, EventArgs e)
        {

        }

        private void cmbThdFreq_GenType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeThdFrqGenType();
        }

        private void cmbThdFreq_VoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeGenVoltageUnit();
        }

        private void txtThdFreq_GenVoltage_TextChanged(object sender, EventArgs e)
        {
            ChangeGenVoltage();

            if (cmbThdFreq_GenVoltageUnit.SelectedIndex == 0)
                CheckRangeAndUpdateColor(sender, 1, 7900);        // mV
            else if (cmbThdFreq_GenVoltageUnit.SelectedIndex == 1)
                CheckRangeAndUpdateColor(sender, 0.001, 7.9);     // V
            else if (cmbThdFreq_GenVoltageUnit.SelectedIndex == 2)
                CheckRangeAndUpdateColor(sender, -165, 18);       // dBV
        }

        private void txtThdFreq_GenVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumericInput(sender, e, false);
        }

        private void txtThdFreq_OutputLoad_TextChanged(object sender, EventArgs e)
        {
            ChangeThdFrqGenType();
            CheckRangeAndUpdateColor(sender, 0, 100000);
        }

        private void txtThdFreq_OutputPower_TextChanged(object sender, EventArgs e)
        {
            ChangeThdFrqGenType();
            CheckRangeAndUpdateColor(sender, 0, 1000);
        }



        private void udThdFreq_StepsOctave_ValueChanged(object sender, EventArgs e)
        {
            data.Settings.StepsPerOctave = Convert.ToUInt16(udThdFreq_StepsOctave.Value);
        }

        private void udThdFreq_Averages_ValueChanged(object sender, EventArgs e)
        {
            data.Settings.Averages = Convert.ToUInt16(udThdFreq_Averages.Value);
        }



        private void txtThdFreq_OutputVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumericInput(sender, e, false);
        }

        private void txtThdFreq_OutputVoltage_TextChanged(object sender, EventArgs e)
        {
            if (cmbThdFreq_OutputVoltageUnit.SelectedIndex == 0)
                CheckRangeAndUpdateColor(sender, 0.001, 40);      // V
            else if (cmbThdFreq_OutputVoltageUnit.SelectedIndex == 1)
                CheckRangeAndUpdateColor(sender, 1, 40000);       // mV
            else if (cmbThdFreq_OutputVoltageUnit.SelectedIndex == 2)
                CheckRangeAndUpdateColor(sender, -165, 32);       // dBV

        }

        private void txtThdFreq_StartFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumericInput(sender, e, true);
        }

        private void txtThdFreq_StartFreq_TextChanged(object sender, EventArgs e)
        {
            CheckRangeAndUpdateColor(sender, 5, 96000);
            data.Settings.StartFrequency = ParseTextToDouble(txtThdFreq_StartFreq.Text, data.Settings.StartFrequency);
        }

        private void txtThdFreq_EndFreq_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumericInput(sender, e, true);
        }

        private void txtThdFreq_EndFreq_TextChanged(object sender, EventArgs e)
        {
            CheckRangeAndUpdateColor(sender, 5, 96000);
            data.Settings.EndFrequency = ParseTextToDouble(txtThdFreq_EndFreq.Text, data.Settings.EndFrequency);
        }

        private void txtThdFreq_OutputLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumericInput(sender, e, false);
        }



        private void txtThdFreq_OutputPower_KeyPress(object sender, KeyPressEventArgs e)
        {
            AllowNumericInput(sender, e, false);
        }

        private void cmbThdFreq_OutputVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeAmpOutputVoltageUnit();
        }


        private void btnThdFreq_FitGraphX_Click(object sender, EventArgs e)
        {
            double startFreq = ParseTextToDouble(txtThdFreq_StartFreq.Text, 20);
            if (startFreq <= 5)
                cmbThdFreq_Graph_From.SelectedIndex = 0;
            else if (startFreq <= 10)
                cmbThdFreq_Graph_From.SelectedIndex = 1;
            else if (startFreq <= 20)
                cmbThdFreq_Graph_From.SelectedIndex = 2;
            else if (startFreq <= 50)
                cmbThdFreq_Graph_From.SelectedIndex = 3;
            else if (startFreq <= 100)
                cmbThdFreq_Graph_From.SelectedIndex = 4;
            else if (startFreq <= 200)
                cmbThdFreq_Graph_From.SelectedIndex = 5;
            else
                cmbThdFreq_Graph_From.SelectedIndex = 6;

            double endFreq = ParseTextToDouble(txtThdFreq_EndFreq.Text, 20000);
            if (endFreq <= 1000)
                cmbThdFreq_Graph_To.SelectedIndex = 0;
            else if (endFreq <= 2000)
                cmbThdFreq_Graph_To.SelectedIndex = 1;
            else if (endFreq <= 5000)
                cmbThdFreq_Graph_To.SelectedIndex = 2;
            else if (endFreq <= 10000)
                cmbThdFreq_Graph_To.SelectedIndex = 3;
            else if (endFreq <= 20000)
                cmbThdFreq_Graph_To.SelectedIndex = 4;
            else if (endFreq <= 50000)
                cmbThdFreq_Graph_To.SelectedIndex = 5;
            else
                cmbThdFreq_Graph_To.SelectedIndex = 6;



        }

        private void cmbThdFreq_Graph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gbThdFreq_D_Range.Visible)
            {
                initThdPlot();
                PlotThd(data);
            }
            else
            {
                InitializeMagnitudePlot();
                PlotMagnitude(data);
            }
        }



        private void chkThdFreq_ShowThd_CheckedChanged(object sender, EventArgs e)
        {
            if (gbThdFreq_D_Range.Visible)
            {
                initThdPlot();
                PlotThd(data);
            }
            else
            {
                InitializeMagnitudePlot();
                PlotMagnitude(data);
            }
        }

        private void btnFreqThd_Graph_dBV_Click(object sender, EventArgs e)
        {
            gbThdFreq_dBV_Range.Visible = true;
            btnFreqThd_Graph_dBV.BackColor = System.Drawing.Color.Cornsilk;
            gbThdFreq_D_Range.Visible = false;
            btnFreqThd_Graph_D.BackColor = System.Drawing.Color.WhiteSmoke;
            chkThdFreq_ShowMagnitude.Enabled = true;


            InitializeMagnitudePlot();
            PlotMagnitude(data);
        }

        private void btnFreqThd_Graph_D_Click(object sender, EventArgs e)
        {
            gbThdFreq_dBV_Range.Visible = false;
            btnFreqThd_Graph_dBV.BackColor = System.Drawing.Color.WhiteSmoke;
            gbThdFreq_D_Range.Visible = true;
            btnFreqThd_Graph_D.BackColor = System.Drawing.Color.Cornsilk;
            chkThdFreq_ShowMagnitude.Enabled = false;



            initThdPlot();
            PlotThd(data);
        }

        private void cmbThdFreq_dBV_Graph_Top_ValueChanged(object sender, EventArgs e)
        {
            InitializeMagnitudePlot();
            PlotMagnitude(data);
        }

        private void btnThdFreq_FitDGraphY_Click(object sender, EventArgs e)
        {
            if (data.StepData.Count == 0)
                return;

            // Determine top Y
            double maxThd = data.StepData.Max(d => d.ThdPercent);

            if (maxThd <= 1)
                cmbThdFreq_D_Graph_Top.SelectedIndex = 2;
            else if (maxThd <= 10)
                cmbThdFreq_D_Graph_Top.SelectedIndex = 1;
            else
                cmbThdFreq_D_Graph_Top.SelectedIndex = 0;


            // Determine bottom Y
            double minThd = (data.StepData.Min(d => (d.NoiseFloorV / d.AmplitudeVolts) * 100));
            if (minThd > 0.1)
                cmbThdFreq_D_Graph_Bottom.SelectedIndex = 0;
            else if (minThd > 0.01)
                cmbThdFreq_D_Graph_Bottom.SelectedIndex = 1;
            else if (minThd > 0.001)
                cmbThdFreq_D_Graph_Bottom.SelectedIndex = 2;
            else if (minThd > 0.0001)
                cmbThdFreq_D_Graph_Bottom.SelectedIndex = 3;
            else if (minThd > 0.00001)
                cmbThdFreq_D_Graph_Bottom.SelectedIndex = 4;
            else
                cmbThdFreq_D_Graph_Bottom.SelectedIndex = 5;

        }

        private void btnThdFreq_FitDbGraphY_Click(object sender, EventArgs e)
        {

            if (data.StepData.Count == 0)
                return;

            // Determine top Y

            double maxDb = data.StepData.Max(d => d.MagnitudeDb);
            if (maxDb >= 100)
                cmbThdFreq_dBV_Graph_Top.Value = Math.Ceiling((decimal)((int)(maxDb / 10) + 1) * 10);
            else if (maxDb >= 10)
                cmbThdFreq_dBV_Graph_Top.Value = (Math.Ceiling((decimal)((int)maxDb) / 10) * 10) + 10;
            else
                cmbThdFreq_dBV_Graph_Top.Value = Math.Ceiling((decimal)((int)(maxDb * 10) + 1) / 10);

            // Determine bottom Y
            double minDb = data.StepData.Min(d => d.NoiseFloorDbV) + data.StepData[0].MagnitudeDb;

            cmbThdFreq_dBV_Graph_Bottom.Value = Math.Ceiling((decimal)((int)(minDb / 10) - 2) * 10);
        }

        private bool IsServerRunning()
        {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                var result = socket.BeginConnect("localhost", 9402, null, null);

                // test the connection for 3 seconds
                bool success = result.AsyncWaitHandle.WaitOne(1000, false);

                var resturnVal = socket.Connected;
                if (socket.Connected)
                    socket.Disconnect(true);

                return resturnVal;
            }


        }

        private void btnStopThdMeasurement_Click(object sender, EventArgs e)
        {
            ct.Cancel();
        }
    }
}
