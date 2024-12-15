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
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;


namespace QA40x_AUDIO_ANALYSER
{

    public partial class frmThdAmplitude : Form
    {
        public ThdAmplitudeMeasurementData Data { get; set; }       // Data used in this form instance
        public bool MeasurementBusy { get; set; }                   // Measurement busy state

        CancellationTokenSource ct;                                 // Measurement cancelation token

        /// <summary>
        /// Constructor
        /// </summary>
        public frmThdAmplitude()
        {
            ct = new CancellationTokenSource();
            InitializeComponent();
            Program.MainForm.ClearMessage();
            InitSettings();
            SetThdvsFrequencyControls();
            InitializeMagnitudePlot();
            AttachThdFreqMouseEvent();
            QaLibrary.InitMiniFftPlot(graphFft, 10, 100000, -150, 20);
            InitMiniTimePlot(0, 4, -1, 1);
        }

        /// <summary>
        /// Initialise Settings with default settings
        /// </summary>
        void InitSettings()
        {
            Data = new();
            Data.Settings.Frequency = 1000;
            Data.Settings.SampleRate = 192000;
            Data.Settings.FftSize = 65536 * 2;
            Data.Settings.WindowingFunction = Windowing.Hann;
            Data.Settings.StepsPerOctave = 5;
            Data.Settings.StartAmplitude = 0.01;
            Data.Settings.StartAmplitudeUnit = E_VoltageUnit.Volt;
            Data.Settings.EndAmplitude = 1;
            Data.Settings.EndAmplitudeUnit = E_VoltageUnit.Volt;
            Data.Settings.Averages = 1;
            Data.Settings.Load = 8;
        }

        /// <summary>
        /// Set initial control values
        /// </summary>
        void SetThdvsFrequencyControls()
        {
            gbDbv_Range.Left = gbD_Range.Left;
            gbDbv_Range.Top = gbD_Range.Top;
            gbDbv_Range.Visible = true;
            gbD_Range.Visible = false;  

            txtStartVoltage.Text = Data.Settings.StartAmplitude.ToString("#0.0##");
            cmbStartVoltageUnit.SelectedIndex = 1;
            txtEndVoltage.Text = Data.Settings.EndAmplitude.ToString("#0.0##");
            cmbEndVoltageUnit.SelectedIndex = 1;

            txtOutputLoad.Text = Data.Settings.Load.ToString();                 
            txtFrequency.Text = Data.Settings.Frequency.ToString();
            udStepsOctave.Value = Data.Settings.StepsPerOctave;
            udAverages.Value = Data.Settings.Averages;

            cmbD_Graph_Top.SelectedIndex = 2;
            cmbD_Graph_Bottom.SelectedIndex = 3;
            cmbDbV_Graph_Top.Value = 40;
            cmbDbV_Graph_Bottom.Value = -140;
            cmbVoltageGraph_From.SelectedIndex = 6;
            cmbVoltageGraph_To.SelectedIndex = 3;
            
            Program.MainForm.HideProgressBar();
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
            QaLibrary.InitMiniFftPlot(graphFft, 10, 100000, -150, 20);
            InitMiniTimePlot(0, 4, -1, 1);

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
            // Determine attenuation level
            // ********************************************************************
            double generatorAmplitudedBV = QaLibrary.ConvertVoltage(Data.Settings.StartAmplitude, Data.Settings.StartAmplitudeUnit, E_VoltageUnit.dBV);
            await Program.MainForm.ShowMessage($"Determining the best input attenuation for a generator voltage of {generatorAmplitudedBV:0.00#} dBV.");

            double testFrequency = QaLibrary.GetNearestBinFrequency(Data.Settings.Frequency, Data.Settings.SampleRate, Data.Settings.FftSize);
            // Determine correct input attenuation
            var result = await QaLibrary.DetermineAttenuationForGeneratorVoltage(generatorAmplitudedBV, testFrequency, 42);
            QaLibrary.PlotMiniFftGraph(graphFft, result.Item3.FreqInput);
            PlotMiniTimeGraph(result.Item3.TimeInput, testFrequency);
            //var startAttenuationdBV = data.Settings.InputRange;
            var startInputAmplitudedBV = result.Item2;

            // Set attenuation
            await Qa40x.SetInputRange(result.Item1);

            await Program.MainForm.ShowMessage($"Found correct input attenuation of {result.Item1:0} dBV for an amplifier amplitude of {result.Item2:0.00#} dBV.");
            await Task.Delay(500);

            if (ct.IsCancellationRequested)
                return false;

            // ********************************************************************
            // Generate a list of voltages evenly spaced in log scale
            // ********************************************************************
            var startAmplitudeV = QaLibrary.ConvertVoltage(Data.Settings.StartAmplitude, Data.Settings.StartAmplitudeUnit, E_VoltageUnit.Volt);
            var startAmplitudedBV = QaLibrary.ConvertVoltage(Data.Settings.StartAmplitude, Data.Settings.StartAmplitudeUnit, E_VoltageUnit.dBV);
            var endAmplitudeV = QaLibrary.ConvertVoltage(Data.Settings.EndAmplitude, Data.Settings.EndAmplitudeUnit, E_VoltageUnit.Volt);
            var stepVoltages = QaLibrary.GetLineairSpacedLogarithmicValuesPerOctave(startAmplitudeV, endAmplitudeV, Data.Settings.StepsPerOctave);

            // ********************************************************************
            // Do noise floor measurement
            // ********************************************************************
            await Program.MainForm.ShowMessage($"Determining noise floor.");
            await Qa40x.SetOutputSource(OutputSources.Off);
            await Qa40x.DoAcquisition();
            LeftRightSeries noiseFloor = await QaLibrary.DoAcquisitions(Data.Settings.Averages);
            Data.NoiseFloor = noiseFloor;

            Program.MainForm.SetupProgressBar(0, stepVoltages.Length);

            var binSize = QaLibrary.CalcBinSize(Data.Settings.SampleRate, Data.Settings.FftSize);
            uint fundamentalBin = QaLibrary.GetBinOfFrequency(testFrequency, binSize);

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
                var voltageDiffdBV = generatorVoltagedBV - startAmplitudedBV;
                var newAttenuation = QaLibrary.DetermineAttenuation(startInputAmplitudedBV + voltageDiffdBV);
                await Qa40x.SetInputRange(newAttenuation);

                // Set generator
                await Qa40x.SetGen1(testFrequency, generatorVoltagedBV, true);    // Set the generator in dBV
                if (i == 0)
                    await Qa40x.SetOutputSource(OutputSources.Sine);            // We need to call this to make the averages in QA40x software reset

                LeftRightSeries lrfs = await QaLibrary.DoAcquisitions(Data.Settings.Averages);  // Do acquisitions
            
                FrequencyThdStep step = new()
                {
                    FundamentalFrequency = testFrequency,
                    GeneratorVoltage = generatorVoltageV,
                    fftData = lrfs.FreqInput,
                    timeData = lrfs.TimeInput,
                    DcComponent = lrfs.TimeInput.Left.Average()
                };
              
                if (fundamentalBin >= lrfs.FreqInput.Left.Length)               // Check if bin within array bounds
                    break;

                // Get and store step data
                step.AmplitudeVolts = lrfs.FreqInput.Left[fundamentalBin];
                step.AmplitudeDbV = 20 * Math.Log10(lrfs.FreqInput.Left[fundamentalBin]);
                step.MagnitudeDb = 20 * Math.Log10(step.AmplitudeVolts / generatorVoltageV);
                // Calculate average noise floor 
                step.NoiseFloorV = Data.NoiseFloor.FreqInput.Left               // Store noise floor in V
                    .Select((v, i) => new { Index = i, Value = v })
                    .Where(p => p.Index > fundamentalBin)                       // Only higher frequencies. We do not have fundamentals in lower frequencies
                    .Select(v => v.Value)
                    .Average();
                step.NoiseFloorDbV = 20 * Math.Log10(step.NoiseFloorV);         // Store noise floor in dBV

                // Plot the mini graphs
                //InitMiniFftPlot(10, 100000, -150, step.AmplitudeDbV);
                QaLibrary.PlotMiniFftGraph(graphFft, lrfs.FreqInput);
                PlotMiniTimeGraph(lrfs.TimeInput, step.FundamentalFrequency);

                // Reset harmonic distortion variables
                double distortionSqrtTotal = 0;
                double distiortionD6plus = 0;

                // Loop through harmonics up tot the 12th
                for (int h = 2; h <= 12; h++)                                   // For now up to 12 harmonics, start at 2nd
                {
                    var harmonicFrequency = testFrequency * h;
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

                // Calculate THD of current step
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
            await Program.MainForm.ShowMessage($"Measurement finished!", 500);
          
            return true;
        }

        /// <summary>
        /// Plot the measurement step in the graph and the cursor text.
        /// </summary>
        /// <param name="step"></param>
        private void PlotMeasurementData(FrequencyThdStep step)
        {
            // Plot the data depending on selected graph
            if (gbDbv_Range.Visible)
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
        void WriteCursorTextsD(double amplitudeV, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double dc, double power, double noiseFloor, double load)
        {
            lblCursor_Voltage.Text = $"Amplitude: {amplitudeV:##0.000 V}";
            lblCursor_Magnitude.Text = $"Magn: {magnitude:0.## dB}";
            lblCursor_THD.Text = $"THD: {thd:0.0000# \\%}";

            lblCursor_D2.Text = $"D2: {D2:0.0000# \\%}";
            lblCursor_D3.Text = $"D3: {D3:0.0000# \\%}";
            lblCursor_D4.Text = $"D4: {D4:0.0000# \\%}";
            lblCursor_D5.Text = $"D5: {D5:0.0000# \\%}";
            lblCursor_D6.Text = $"D6+: {D6:0.0000# \\%}";
            lblCursor_DC.Text = $"DC: {dc * 1000:0.0# mV}";

            if (power < 1)
                lblCursor_Power.Text = $"Power: {power * 1000:0.0# mW} ({load:0.##} Ω)";
            else
                lblCursor_Power.Text = $"Power: {power:0.00# W} ({load:0.##} Ω)";

            lblCursor_NoiseFloor.Text = $"Noise floor: {noiseFloor:##0.0# dB}";

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
        void WriteCursorTextsdB(double amplitudeV, double magnitude, double thd, double D2, double D3, double D4, double D5, double D6, double dc, double power, double noiseFloor, double load)
        {
            lblCursor_Voltage.Text = $"Amplitude: {amplitudeV:##0.000 V}";
            lblCursor_Magnitude.Text = $"Magn: {magnitude:0.## dB}";
            lblCursor_THD.Text = $"THD: {thd:0.0# dB}";

            lblCursor_D2.Text = $"D2: {D2:##0.0# dB}";
            lblCursor_D3.Text = $"D3: {D3:##0.0# dB}";
            lblCursor_D4.Text = $"D4: {D4:##0.0# dB}";
            lblCursor_D5.Text = $"D5: {D5:##0.0# dB}";
            lblCursor_D6.Text = $"D6+: {D6:##0.0# dB}";
            lblCursor_DC.Text = $"DC: {dc * 1000:0.0# mV}";

            if (power < 1)
                lblCursor_Power.Text = $"Power: {power * 1000:0.0# mW} ({load:0.##} Ω)";
            else
                lblCursor_Power.Text = $"Power: {power:0.00# W} ({load:0.##} Ω)";

            lblCursor_NoiseFloor.Text = $"Noise floor: {noiseFloor:##0.0# dB}";
        }

       
        void InitMiniTimePlot(double startTime, double endTime, double minVoltage, double maxVoltage)
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

        /// <summary>
        /// Clear the plot
        /// </summary>
        void clearPlot()
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
            if (cmbVoltageGraph_From.SelectedIndex > -1 && cmbVoltageGraph_To.SelectedIndex > -1 && cmbD_Graph_Bottom.SelectedIndex > -1 && cmbD_Graph_Top.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbVoltageGraph_From.Text)), Math.Log10(Convert.ToDouble(cmbVoltageGraph_To.Text)), Math.Log10(Convert.ToDouble(cmbD_Graph_Bottom.Text)), Math.Log10(Convert.ToDouble(cmbD_Graph_Top.Text)));
            thdPlot.Plot.Title("Distortion (%)");
            thdPlot.Plot.Axes.Title.Label.FontSize = 17;

            thdPlot.Plot.XLabel("Amplitude (Vrms)");
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
        /// Plot the THD % data
        /// </summary>
        /// <param name="data"></param>
        void PlotThd(ThdAmplitudeMeasurementData data)
        {
            thdPlot.Plot.Remove<Scatter>();

            List<double> freqX = [];
            List<double> hTotY = [];
            List<double> h2Y = [];
            List<double> h3Y = [];
            List<double> h4Y = [];
            List<double> h5Y = [];
            List<double> h6Y = [];
            List<double> noiseY = [];

            for (int i = 0; i < data.StepData.Count; i++)
            {
                freqX.Add(data.StepData[i].AmplitudeVolts);

                if (data.StepData[i].Harmonics.Count > 0 && chkShowThd.Checked)
                    hTotY.Add(data.StepData[i].ThdPercent);
                if (data.StepData[i].Harmonics.Count > 0 && chkShowD2.Checked)
                    h2Y.Add(data.StepData[i].Harmonics[0].ThdPercent);
                if (data.StepData[i].Harmonics.Count > 1 && chkShowD3.Checked)
                    h3Y.Add(data.StepData[i].Harmonics[1].ThdPercent);
                if (data.StepData[i].Harmonics.Count > 2 && chkShowD4.Checked)
                    h4Y.Add(data.StepData[i].Harmonics[2].ThdPercent);
                if (data.StepData[i].Harmonics.Count > 3 && chkShowD5.Checked)
                    h5Y.Add(data.StepData[i].Harmonics[3].ThdPercent);
                if (data.StepData[i].Harmonics.Count > 4 && data.StepData[i].ThdPercentD6plus != 0 && chkShowD6.Checked)
                    h6Y.Add(data.StepData[i].ThdPercentD6plus);        // D6+
                if (chkShowNoiseFloor.Checked)
                    noiseY.Add((data.StepData[i].NoiseFloorV / data.StepData[i].AmplitudeVolts) * 100);
            }

            IPalette palette = new ScottPlot.Palettes.Category10();
            float lineWidth = 1;
            float markerSize = 1;
            if (chkThickLines.Checked)
                lineWidth = 2;
            if (chkShowDataPoints.Checked)
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
                //plot1.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Orange);
                plot1.Color = palette.GetColor(0);
                plot1.MarkerSize = markerSize;
                plot1.LegendText = "D2";
            }

            if (chkShowD3.Checked)
            {
                double[] logH3Y = h3Y.Select(Math.Log10).ToArray();
                var plot2 = thdPlot.Plot.Add.Scatter(logFreqX, logH3Y);
                plot2.LineWidth = lineWidth;
                //plot2.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Green);
                plot2.Color = palette.GetColor(1);
                plot2.MarkerSize = markerSize;
                plot2.LegendText = "D3";
            }

            if (chkShowD4.Checked)
            {
                double[] logH4Y = h4Y.Select(Math.Log10).ToArray();
                var plot3 = thdPlot.Plot.Add.Scatter(logFreqX, logH4Y);
                //plot3.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Red);
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
                //plot4.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Purple);
                plot4.Color = palette.GetColor(3);
                plot4.MarkerSize = markerSize;
                plot4.LegendText = "D5";
            }

            if (chkShowD6.Checked)
            {
                double[] logH6Y = h6Y.Select(Math.Log10).ToArray();
                var plot5 = thdPlot.Plot.Add.Scatter(logFreqX, logH6Y);
                plot5.LineWidth = lineWidth;
                //plot5.Color = ScottPlot.Color.FromColor(System.Drawing.Color.Brown);
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

            if (cmbVoltageGraph_From.SelectedIndex > -1 && cmbVoltageGraph_To.SelectedIndex > -1)
                thdPlot.Plot.Axes.SetLimits(Math.Log10(Convert.ToDouble(cmbVoltageGraph_From.Text)), Math.Log10(Convert.ToDouble(cmbVoltageGraph_To.Text)), Convert.ToDouble(cmbDbV_Graph_Bottom.Value), Convert.ToDouble(cmbDbV_Graph_Top.Value));
            
            thdPlot.Plot.Title("Magnitude (dB)");
            thdPlot.Plot.Axes.Title.Label.FontSize = 17;

            thdPlot.Plot.XLabel("Amplitude (Vrms)");
            thdPlot.Plot.Axes.Bottom.Label.OffsetX = 330;
            thdPlot.Plot.Axes.Bottom.Label.FontSize = 15;
            thdPlot.Plot.Axes.Bottom.Label.Bold = false;

            // Lengend
            thdPlot.Plot.Legend.IsVisible = true;
            thdPlot.Plot.Legend.Orientation = ScottPlot.Orientation.Horizontal;
            thdPlot.Plot.Legend.Alignment = ScottPlot.Alignment.UpperRight;
            thdPlot.Plot.ShowLegend();
            thdPlot.Refresh();
        }


        /// <summary>
        /// Plot the  THD magnitude (dB) data
        /// </summary>
        /// <param name="data">The data to plot</param>
        void PlotMagnitude(ThdAmplitudeMeasurementData data)
        {
            thdPlot.Plot.Remove<Scatter>();             // Remove Scatter plots
            // Create lists for line data
            List<double> freqX = [];
            List<double> magnY = [];
            List<double> hTotY = [];
            List<double> h2Y = [];
            List<double> h3Y = [];
            List<double> h4Y = [];
            List<double> h5Y = [];
            List<double> h6Y = [];
            List<double> noiseY = [];

            // Add data to the line lists
            for (int i = 0; i < data.StepData.Count; i++)
            {
                freqX.Add(data.StepData[i].AmplitudeVolts);

                if (chkShowMagnitude.Checked)
                    magnY.Add(data.StepData[i].MagnitudeDb);

                if (data.StepData[i].Harmonics.Count > 0)
                {
                    hTotY.Add(data.StepData[i].ThdDb + data.StepData[i].MagnitudeDb);
                    h2Y.Add(data.StepData[i].Harmonics[0].AmplitudeDbV - data.StepData[i].AmplitudeDbV + data.StepData[i].MagnitudeDb);
                }
                if (data.StepData[i].Harmonics.Count > 1)
                    h3Y.Add(data.StepData[i].Harmonics[1].AmplitudeDbV - data.StepData[i].AmplitudeDbV + data.StepData[i].MagnitudeDb);
                if (data.StepData[i].Harmonics.Count > 2)
                    h4Y.Add(data.StepData[i].Harmonics[2].AmplitudeDbV - data.StepData[i].AmplitudeDbV + data.StepData[i].MagnitudeDb);
                if (data.StepData[i].Harmonics.Count > 3)
                    h5Y.Add(data.StepData[i].Harmonics[3].AmplitudeDbV - data.StepData[i].AmplitudeDbV + data.StepData[i].MagnitudeDb);
                if (data.StepData[i].D6PlusDbV != 0 && data.StepData[i].Harmonics.Count > 4 && chkShowD6.Checked)
                    h6Y.Add(data.StepData[i].D6PlusDbV - data.StepData[i].AmplitudeDbV + data.StepData[i].MagnitudeDb);
                if (chkShowNoiseFloor.Checked)
                    noiseY.Add(data.StepData[i].NoiseFloorDbV - data.StepData[i].AmplitudeDbV + data.StepData[i].MagnitudeDb);
            }

            // add a scatter plot to the plot
            double[] logFreqX = freqX.Select(Math.Log10).ToArray();
            float lineWidth = (chkThickLines.Checked ? 2 : 1);
            float markerSize = (chkShowDataPoints.Checked ? lineWidth + 3 : 1);
           

            IPalette palette = new ScottPlot.Palettes.Category10();     // Use certain color pallet

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

            // If marker selected draw marker line
            if (markerIndex != -1)
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
                SetCursorMarker(s, e, true);      // Set persistent marker
            };

            // Mouse is leaving the graph
            thdPlot.MouseLeave += (s, e) =>
            {
                // If persistent marker set then show mini plots of that marker
                if (markerIndex >= 0)
                {
                    QaLibrary.PlotMiniFftGraph(graphFft, Data.StepData[markerIndex].fftData);
                    PlotMiniTimeGraph(Data.StepData[markerIndex].timeData, Data.StepData[markerIndex].FundamentalFrequency);
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
                QaLibrary.PlotMiniFftGraph(graphFft, Data.StepData[nearest1.Index].fftData);
                PlotMiniTimeGraph(Data.StepData[nearest1.Index].timeData, Data.StepData[nearest1.Index].FundamentalFrequency);
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

            // Get nearest x-location in plotr
            DataPoint nearest1 = thdPlot.Plot.GetPlottables<Scatter>().First().Data.GetNearestX(mouseLocation, thdPlot.Plot.LastRender);

            // place the crosshair over the highlighted point
            if (nearest1.IsReal)
            {
                float lineWidth = 1;// (chkThdFreq_ThickLines.Checked ? 2 : 1);
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
                        return;                     // Do not show new marker. There is already a clicked marker
                }

                QaLibrary.PlotCursorMarker(thdPlot, lineWidth, linePattern, nearest1);

                // Check if index in StepData array
                if (Data.StepData.Count > nearest1.Index)
                {
                    FrequencyThdStep step = Data.StepData[nearest1.Index];

                    // Write cursor texts based in plot type
                    if (gbDbv_Range.Visible)
                    {
                        WriteCursorTextsdB(step.AmplitudeVolts
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
                        WriteCursorTextsD(step.AmplitudeVolts
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
            Data.Settings.StartAmplitudeUnit = (E_VoltageUnit)cmbStartVoltageUnit.SelectedIndex;
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        private void cmbEndVoltageUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Data.Settings.EndAmplitudeUnit = (E_VoltageUnit)cmbEndVoltageUnit.SelectedIndex;
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        
        private void txtStartVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Text has been changed by user typing. Remember unit
            Data.Settings.StartAmplitudeUnit = (E_VoltageUnit)cmbStartVoltageUnit.SelectedIndex;
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        private void txtEndVoltage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Text has been changed by user typing. Remember unit
            Data.Settings.EndAmplitudeUnit = (E_VoltageUnit)cmbEndVoltageUnit.SelectedIndex;
            QaLibrary.AllowNumericInput(sender, e, false);
        }

        private void txtStartVoltage_TextChanged(object sender, EventArgs e)
        {
            Data.Settings.StartAmplitude = QaLibrary.ParseTextToDouble(txtStartVoltage.Text, Data.Settings.StartAmplitude);
            ValidateStartVoltage(txtStartVoltage);
            ValidateEndVoltage(txtEndVoltage);
        }

        private void txtEndVoltage_TextChanged(object sender, EventArgs e)
        {
            Data.Settings.EndAmplitude = QaLibrary.ParseTextToDouble(txtEndVoltage.Text, Data.Settings.EndAmplitude);
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
                double endVoltageMv = QaLibrary.ConvertVoltage(Data.Settings.EndAmplitude, Data.Settings.EndAmplitudeUnit, E_VoltageUnit.MilliVolt); // Convert to mV
                endVoltageMv = (endVoltageMv > QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV ? QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV : endVoltageMv);
                QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV, endVoltageMv);        // mV
            }
            else
            {
                double endVoltageV = QaLibrary.ConvertVoltage(Data.Settings.EndAmplitude, Data.Settings.EndAmplitudeUnit, E_VoltageUnit.Volt); // Convert to V
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
                double startVoltageMv = QaLibrary.ConvertVoltage(Data.Settings.StartAmplitude, Data.Settings.StartAmplitudeUnit, E_VoltageUnit.MilliVolt); // Convert to mV
                startVoltageMv = (startVoltageMv < QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV ? QaLibrary.MINIMUM_GENERATOR_VOLTAGE_MV : startVoltageMv);
                QaLibrary.ValidateRangeAdorner(sender, startVoltageMv, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_MV);        // mV
            }
            else
            {
                double startVoltageV = QaLibrary.ConvertVoltage(Data.Settings.StartAmplitude, Data.Settings.StartAmplitudeUnit, E_VoltageUnit.Volt); // Convert to V
                startVoltageV = (startVoltageV < QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V ? QaLibrary.MINIMUM_GENERATOR_VOLTAGE_V : startVoltageV);
                QaLibrary.ValidateRangeAdorner(sender, startVoltageV, QaLibrary.MAXIMUM_GENERATOR_VOLTAGE_V);     // V 
            }
        }



        private void txtOutputLoad_TextChanged(object sender, EventArgs e)
        {
            QaLibrary.ValidateRangeAdorner(sender, QaLibrary.MINIMUM_LOAD, QaLibrary.MAXIMUM_LOAD);
        }


        private void udStepsOctave_ValueChanged(object sender, EventArgs e)
        {
            Data.Settings.StepsPerOctave = Convert.ToUInt16(udStepsOctave.Value);
        }

        private void udAverages_ValueChanged(object sender, EventArgs e)
        {
            Data.Settings.Averages = Convert.ToUInt16(udAverages.Value);
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
            Data.Settings.Frequency = QaLibrary.ParseTextToDouble(txtFrequency.Text, Data.Settings.Frequency);
        }

        private void txtOutputLoad_KeyPress(object sender, KeyPressEventArgs e)
        {
            QaLibrary.AllowNumericInput(sender, e, false);
        }


        private void cmbGraph_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gbD_Range.Visible)
            {
                InitializeThdPlot();
                PlotThd(Data);
            }
            else
            {
                InitializeMagnitudePlot();
                PlotMagnitude(Data);
            }
        }


        private void chkShowThd_CheckedChanged(object sender, EventArgs e)
        {
            if (gbD_Range.Visible)
            {
                InitializeThdPlot();
                PlotThd(Data);
            }
            else
            {
                InitializeMagnitudePlot();
                PlotMagnitude(Data);
            }
        }

        private void btnGraph_dBV_Click(object sender, EventArgs e)
        {
            gbDbv_Range.Visible = true;
            btnGraph_dBV.BackColor = System.Drawing.Color.Cornsilk;
            gbD_Range.Visible = false;
            btnGraph_D.BackColor = System.Drawing.Color.WhiteSmoke;
            chkShowMagnitude.Enabled = true;

            InitializeMagnitudePlot();
            PlotMagnitude(Data);
        }

        private void btnGraph_D_Click(object sender, EventArgs e)
        {
            gbDbv_Range.Visible = false;
            btnGraph_dBV.BackColor = System.Drawing.Color.WhiteSmoke;
            gbD_Range.Visible = true;
            btnGraph_D.BackColor = System.Drawing.Color.Cornsilk;
            chkShowMagnitude.Enabled = false;


            InitializeThdPlot();
            PlotThd(Data);
        }

        private void cmbDbv_Graph_Top_ValueChanged(object sender, EventArgs e)
        {
            InitializeMagnitudePlot();
            PlotMagnitude(Data);
        }

        private void btnFitDGraphY_Click(object sender, EventArgs e)
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

        private void btnFitDbGraphY_Click(object sender, EventArgs e)
        {

            if (Data.StepData.Count == 0)
                return;

            // Determine top Y

            double maxDb = Data.StepData.Max(d => d.MagnitudeDb);
            if (maxDb >= 100)
                cmbDbV_Graph_Top.Value = Math.Ceiling((decimal)((int)(maxDb / 10) + 1) * 10);
            else if (maxDb >= 10)
                cmbDbV_Graph_Top.Value = (Math.Ceiling((decimal)((int)maxDb) / 10) * 10) + 10;
            else
                cmbDbV_Graph_Top.Value = Math.Ceiling((decimal)((int)(maxDb * 10) + 1) / 10);

            // Determine bottom Y
            double minDb = Data.StepData.Min(d => d.NoiseFloorDbV) + Data.StepData[0].MagnitudeDb;

            cmbDbV_Graph_Bottom.Value = Math.Ceiling((decimal)((int)(minDb / 10) - 2) * 10);
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
    }
}
