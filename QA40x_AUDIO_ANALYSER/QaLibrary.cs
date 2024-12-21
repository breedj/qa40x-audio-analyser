using System;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using QA402_AUDIO_ANALYSER;
using ScottPlot.Plottables;
using ScottPlot;
using ScottPlot.WinForms;
using QA40x_AUDIO_ANALYSER;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace QaControl
{

    public class QaLibrary
    {
        public static double MINIMUM_GENERATOR_VOLTAGE_V = 0.001;
        public static double MAXIMUM_GENERATOR_VOLTAGE_V = 7.9;
        public static double MINIMUM_GENERATOR_VOLTAGE_MV = 1;
        public static double MAXIMUM_GENERATOR_VOLTAGE_MV = 7900;
        public static double MINIMUM_GENERATOR_VOLTAGE_DBV = -165;
        public static double MAXIMUM_GENERATOR_VOLTAGE_DBV = 18;

        public static double MINIMUM_GENERATOR_FREQUENCY_HZ = 5;
        public static double MAXIMUM_GENERATOR_FREQUENCY_HZ = 96000;

        public static double MINIMUM_LOAD = 0;
        public static double MAXIMUM_LOAD = 100000;

        public static double MINIMUM_DEVICE_INPUT_VOLTAGE_DBV = -120;
        public static double MAXIMUM_DEVICE_INPUT_VOLTAGE_DBV = 32;
        public static double MINIMUM_DEVICE_INPUT_VOLTAGE_V = 1E-6;
        public static double MAXIMUM_DEVICE_INPUT_VOLTAGE_V = 40;
        public static double MINIMUM_DEVICE_INPUT_VOLTAGE_MV = 1E-3;
        public static double MAXIMUM_DEVICE_INPUT_VOLTAGE_MV = 40000;

        /// <summary>
        /// Calculates fft bin size in Hz
        /// </summary>
        /// <param name="sampleRate">Sample rate in samples per second</param>
        /// <param name="fftSize">fft buffer size</param>
        /// <returns>The frequency span of a bin</returns>
        static public double CalcBinSize(uint sampleRate, uint fftSize)
        {
            return (double)sampleRate / (double)fftSize;
        }


        /// <summary>
        /// Calculates in which bin the supplied frequency is
        /// </summary>
        /// <param name="frequency">The frequency to query</param>
        /// <param name="sampleRate">Sample rate in samples per second</param>
        /// <param name="fftSize">The fft buffer size</param>
        /// <returns>The bin containing the frequncy</returns>
        static public uint GetBinOfFrequency(double frequency, uint sampleRate, uint fftSize)
        {
            double binSize = CalcBinSize(sampleRate, fftSize);
            uint binNumber = (uint)Math.Round(frequency / binSize);
            if (binNumber > fftSize)
                throw new ArgumentOutOfRangeException();                    // Frequency does not exist in the fft
            return binNumber;
        }

        /// <summary>
        /// Calculates in which bin the supplied frequency is
        /// </summary>
        /// <param name="frequency">The frequency to query</param>
        /// <param name="binSize">Frequency span of a single bin</param>
        /// <returns>The bin containing the frequncy</returns>
        static public uint GetBinOfFrequency(double frequency, double binSize)
        {
            return (uint)Math.Round(frequency / binSize);
        }

        /// <summary>
        /// Get the actual generator frequency when 'round to eliminate leakage' is enabled
        /// </summary>
        /// <param name="bin">The fft bin of the frequency</param>
        /// <param name="binSize">The fft binsize</param>
        /// <returns></returns>
        static public double GetBinFrequency(uint bin, double binSize)
        {
            return bin * binSize; 
        }

        /// <summary>
        /// Get the actual generator frequency when 'round to eliminate leakage' is enabled
        /// </summary>
        /// <param name="setFrequency">The frequency to query</param>
        /// <param name="sampleRate">Sample rate in samples per second</param>
        /// <param name="fftSize">The fft buffer size</param>
        /// <returns>The center frequency of the nearest bin</returns>
        static public double GetNearestBinFrequency(double setFrequency, uint sampleRate, uint fftSize)
        {
            uint binOfFreq = GetBinOfFrequency(setFrequency, sampleRate, fftSize);
            double binSize = CalcBinSize(sampleRate, fftSize);

            return binOfFreq * binSize;
        }


        /// <summary>
        /// Get the start and end frequency to use with PeakDbv for measuring a harmonic.
        /// </summary>
        /// <param name="fundamental">The fundamental frequency in [Hz] i.e. 1000 Hz</param>
        /// <param name="harmonic">The harmonic to measure. i.e. 2 for second harminic</param>
        /// <param name="binSize">The current bin size</param>
        /// <param name="fftSize">The current fft buffer size</param>
        /// <returns></returns>
        static public StartEndFrequencyPair PeakSearchFrequencySpan(double fundamental, int harmonic, float binSize, uint fftSize)
        {
            double harmonicFrequency = fundamental * harmonic;

            uint harmonicBin = GetBinOfFrequency(harmonicFrequency, binSize);

            StartEndFrequencyPair result = new StartEndFrequencyPair();
            result.StartFrequency = (double)((harmonicBin - 1.1) * binSize);
            result.EndFrequency = (double)((harmonicBin + 1.1) * binSize);
            return result;
        }

        /// <summary>
        /// Get a list of x frequencies per decade between a start and stop frequency in a way that they are spaced equally on a graph with logarithmic scale.
        /// </summary>
        /// <param name="startFrequency">Start frequency</param>
        /// <param name="stopFrequency">Stop frequency</param>
        /// <param name="stepsPerDecade">Stepe per decade</param>
        /// <returns></returns>
        public static double[] GetLineairSpacedLogarithmicValuesPerDecade(double start, double stop, int stepsPerDecade)
        {
            // Calculate the logarithmic start and stop values
            double logStart = Math.Log10(start);
            double logStop = Math.Log10(stop);

            // Calculate the number of total steps based on the steps per decade
            int totalSteps = (int)(stepsPerDecade * (logStop - logStart));

            // Calculate the increment in logarithmic space
            double logStep = (logStop - logStart) / totalSteps;

            // Generate the frequencies array
            double[] values = new double[totalSteps + 1];
            for (int i = 0; i <= totalSteps; i++)
            {
                // Calculate the frequency by raising 10 to the power of the current log position
                values[i] = Math.Pow(10, logStart + i * logStep);
            }

            return values;
        }


        /// <summary>
        /// Get a list of x frequencies per octave between a start and stop frequency in a way that they are spaced equally on a graph with logarithmic scale.
        /// </summary>
        /// <param name="startFrequency">Start frequency</param>
        /// <param name="stopFrequency">Stop frequency</param>
        /// <param name="stepsPerOctave">Steps per octave</param>
        /// <returns></returns>
        public static double[] GetLineairSpacedLogarithmicValuesPerOctave(double start, double stop, uint stepsPerOctave)
        {
            // Calculate the number of octaves between start and stop frequencies
            double octaves = Math.Log(stop / start, 2);

            // Calculate the total number of steps based on steps per octave
            int totalSteps = (int)(stepsPerOctave * octaves);

            // Calculate the increment in logarithmic space (base 2)
            double logStep = octaves / totalSteps;

            // Generate the frequencies array
            double[] values = new double[totalSteps + 1];
            for (int i = 0; i <= totalSteps; i++)
            {
                // Calculate the frequency by raising 2 to the power of the current log position
                values[i] =  start * Math.Pow(2, i * logStep);
            }

            return values;
        }

        /// <summary>
        /// Changes all frequencies in an array to center frequencies of a bin.
        /// </summary>
        /// <param name="frequencies">List of frequencies to translate</param>
        /// <param name="sampleRate">Sample rate</param>
        /// <param name="fftSize">fft size</param>
        /// <returns>A list of frequencies</returns>
        public static double[] TranslateToBinFrequencies(double[] frequencies, uint sampleRate, uint fftSize)
        {
            double[] binnedFrequencies = new double[frequencies.Length];
            for (int i = 0; i < frequencies.Length; i++) {
                binnedFrequencies[i] = GetNearestBinFrequency(frequencies[i], sampleRate, fftSize);
            }

            return binnedFrequencies;
        }

        static public async Task<LeftRightSeries> DoAcquisitions(int averages, CancellationToken ct)
        {
            LeftRightSeries leftRightSeries = new LeftRightSeries();

            await Qa40x.DoAcquisition();
            if (ct.IsCancellationRequested)
                return null;
            leftRightSeries.FreqInput = await Qa40x.GetInputFrequencySeries();
            if (ct.IsCancellationRequested)
                return null;
            leftRightSeries.TimeInput = await Qa40x.GetInputTimeSeries();
            if (ct.IsCancellationRequested)
                return null;

            if (averages <= 1)
                return leftRightSeries;        // Only one measurement

            for (int i = 1; i < averages; i++)
            {
                await Qa40x.DoAcquisition();
                if (ct.IsCancellationRequested)
                    return null;
                LeftRightSeries leftRightSeries2 = new LeftRightSeries();
                leftRightSeries2.FreqInput = await Qa40x.GetInputFrequencySeries();
      
                for (int j = 0; j < leftRightSeries2.FreqInput.Left.Length; j++)
                {
                    leftRightSeries.FreqInput.Left[j] += leftRightSeries2.FreqInput.Left[j];
                    leftRightSeries.FreqInput.Right[j] += leftRightSeries2.FreqInput.Right[j];
                }
            }

            for (int j = 0; j < leftRightSeries.FreqInput.Left.Length; j++)
            {
                leftRightSeries.FreqInput.Left[j] = leftRightSeries.FreqInput.Left[j] / averages;
                leftRightSeries.FreqInput.Right[j] = leftRightSeries.FreqInput.Right[j] / averages;
            }

            return leftRightSeries;
        }

        /// <summary>
        /// Determine the attenuation needed for the input signal to be in the range of the hardware
        /// </summary>
        /// <param name="dBV">The maximum level in dBV</param>
        /// <returns>The attenuation in dB</returns>
        public static int DetermineAttenuation(double dBV)
        {
            int attenuation = 42;
            double testdBV = dBV + 5;       // Add 5 dBV extra for better thd measurement
            // Determine attenuation needed
            if (testdBV <= 0)
                attenuation = 0;
            else if (testdBV <= 6)
                attenuation = 6;
            else if (testdBV <= 12)
                attenuation = 12;
            else if (testdBV <= 18)
                attenuation = 18;
            else if (testdBV <= 24)
                attenuation = 24;
            else if (testdBV <= 30)
                attenuation = 30;
            else if (testdBV <= 36)
                attenuation = 36;
            else
                attenuation = 42;

            return attenuation;
        }


        public static bool IsServerRunning()
        {
            using (Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
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

        static public async Task<bool> CheckDeviceConnected()
        {
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

            return true;
        }


        /// <summary>
        /// Determine the best attenuation for the input amplitude
        /// </summary>
        /// <param name="voltageDbv">The generator voltage</param>
        /// <param name="testFrequency">The generator frequency</param>
        /// <param name="testAttenuation">The test attenuation</param>
        /// <returns>The attanuation determined by the test</returns>
        public static async Task<(int, double, LeftRightSeries)> DetermineAttenuationForGeneratorVoltage(double voltageDbv, double testFrequency, int testAttenuation, CancellationToken ct)
        {
            await Qa40x.SetInputRange(testAttenuation);                         // Set input range to initial range
            await Qa40x.SetGen1(testFrequency, voltageDbv, true);               // Enable generator at set voltage
            await Qa40x.SetOutputSource(OutputSources.Sine);
            LeftRightSeries acqData = await DoAcquisitions(1, ct);        // Do acquisition
            LeftRightPair plrp = await Qa40x.GetPeakDbv(testFrequency - 5, testFrequency + 5);        // Get peak value at 1 kHz
            var attenuation = DetermineAttenuation(plrp.Left);         // Determine attenuation and set input range
            await Qa40x.SetOutputSource(OutputSources.Off);                     // Disable generator

            return (attenuation, plrp.Left, acqData);       // Return attenuation, measured amplitude and acquisition data
        }


        /// <summary>
        /// Determine the generator voltage in dBV for the desired output voltage
        /// </summary>
        /// <param name="startGeneratorAmplitude">The amplitude to start with. Should be small but the output should be detectable</param>
        /// <param name="desiredOutputAmplitude">The desired output amplitude</param>
        /// <returns>Generator amplitude in dBV</returns>
        public static async Task<(double, LeftRightSeries)> DetermineGenAmplitudeByOutputAmplitude(double testFrequency, double startGeneratorAmplitude, double desiredOutputAmplitude, CancellationToken ct)
        {
            await Qa40x.SetGen1(testFrequency, startGeneratorAmplitude, true);           // Enable generator with start amplitude at 1 kHz
            await Qa40x.SetOutputSource(OutputSources.Sine);                    // Set sine wave
            LeftRightSeries acqData = await DoAcquisitions(1, ct);            // Do a single aqcuisition
            LeftRightPair plrp = await Qa40x.GetPeakDbv(testFrequency - 5, testFrequency + 5);             // Get peak amplitude around 1 kHz
            double leftPeakDbV = plrp.Left;
            //double rightPeak = plrp.Right;
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
                    return (18, acqData);
                }
                else if (result == DialogResult.Cancel)
                {
                    return (-150, acqData);
                }
            }
            else if (amplitude <= -40)
            {
                MessageBox.Show("Check if the amplifier is connected and switched on.", "Could not determine amplitude", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return (-150, acqData);
            }

            return (amplitude, acqData);       // Return the new generator amplitude and acquisition data
        }


        public static double ConvertVoltage(double voltage, E_VoltageUnit fromUnit, E_VoltageUnit toUnit)
        {
            if (fromUnit == E_VoltageUnit.MilliVolt)
            {
                if (toUnit == E_VoltageUnit.MilliVolt)
                    return voltage;
                else if (toUnit == E_VoltageUnit.Volt)
                    return voltage / 1000.0;
                else
                    return 20 * Math.Log10(voltage / 1000.0);
            }
            else if (fromUnit == E_VoltageUnit.Volt)
            {
                if (toUnit == E_VoltageUnit.MilliVolt)
                    return voltage * 1000;
                else if (toUnit == E_VoltageUnit.Volt)
                    return voltage;
                else
                    return 20 * Math.Log10(voltage);
            }
            else
            {   // dBV
                if (toUnit == E_VoltageUnit.MilliVolt)
                    return Math.Pow(10, voltage / 20) * 1000;
                else if (toUnit == E_VoltageUnit.Volt)
                    return Math.Pow(10, voltage / 20);
                else
                    return voltage;
            }

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
        public static void ValidateRangeAdorner(object sender, double minimal, double maximum)
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

        /// <summary>
        /// Parse text to double. Return fallback texts if failed
        /// </summary>
        /// <param name="text">Text to parse</param>
        /// <param name="fallback">Fallback text</param>
        /// <returns></returns>
        public static double ParseTextToDouble(string text, double fallback)
        {

            if (double.TryParse(text, NumberStyles.Any, CultureInfo.CurrentCulture, out double value))
                return value;     // return parsed value

            return fallback;
        }

        /// <summary>
        /// Plots a vertical cursor marker line 
        /// </summary>
        /// <param name="lineWidth">Line width of the marker</param>
        /// <param name="linePattern">Pattern of the line</param>
        /// <param name="point">Data point to draw the line at</param>
        public static void PlotCursorMarker(FormsPlot plot, float lineWidth, LinePattern linePattern, DataPoint point)
        {
            plot.Plot.Remove<Crosshair>();               // Remove any current marker

            var myCrosshair = plot.Plot.Add.Crosshair(point.Coordinates.X, point.Coordinates.Y);
            myCrosshair.IsVisible = true;
            myCrosshair.LineWidth = lineWidth;
            myCrosshair.LineColor = Colors.Magenta;
            myCrosshair.MarkerShape = MarkerShape.None;
            myCrosshair.MarkerSize = 1;
            myCrosshair.LinePattern = linePattern;
            myCrosshair.HorizontalLine.IsVisible = false;
            myCrosshair.Position = point.Coordinates;

            plot.Refresh();
        }


        /// <summary>
        /// Initlialize the THD frequency plot
        /// </summary>
        /// <param name="startFrequency"></param>
        /// <param name="endFrequency"></param>
        /// <param name="minDbV"></param>
        /// <param name="maxDbV"></param>
        public static void InitMiniFftPlot(FormsPlot plot, double startFrequency, double endFrequency, double minDbV, double maxDbV)
        {
            plot.Plot.Clear();

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
            plot.Plot.Axes.Left.TickGenerator = tickGen;



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

            plot.Plot.Axes.Bottom.TickGenerator = tickGenX;


            // show grid lines for minor ticks
            plot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            plot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.08);
            plot.Plot.Grid.MinorLineWidth = 1;

            plot.Plot.Axes.SetLimits(startFrequency < 10 ? Math.Log10(1) : Math.Log10(10), Math.Log10(100000), minDbV, maxDbV);
            plot.Plot.Title("dBV (output)");
            plot.Plot.Axes.Title.Label.FontSize = 12;
            plot.Plot.Axes.Title.Label.OffsetY = 8;
            plot.Plot.Axes.Title.Label.Bold = false;

            plot.Plot.XLabel("Hz");
            plot.Plot.Axes.Bottom.Label.OffsetX = 85;
            plot.Plot.Axes.Bottom.Label.OffsetY = -5;
            plot.Plot.Axes.Bottom.Label.FontSize = 12;
            plot.Plot.Axes.Bottom.Label.Bold = false;
            plot.Plot.Axes.Bottom.Label.IsVisible = true;

            plot.Plot.Legend.IsVisible = false;

            plot.Refresh();

        }

        public static void PlotMiniFftGraph(FormsPlot plot, LeftRightFrequencySeries fftData)
        {
            plot.Plot.Clear();

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
            var plotTot = plot.Plot.Add.Scatter(logFreqX, logHTotY);
            plotTot.LineWidth = 1;
            plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(1, 97, 170));
            plotTot.MarkerSize = 1;

            var limitY = plot.Plot.Axes.GetLimits().YRange.Max;
            if (dbVY.Max(f => f) + 10 > limitY)
            {
                limitY += 10;
                plot.Plot.Axes.SetLimits(Math.Log10(10), Math.Log10(100000), -150, limitY);
            }

            plot.Refresh();
        }




        public static void InitMiniTimePlot(FormsPlot plot, double startTime, double endTime, double minVoltage, double maxVoltage)
        {
            plot.Plot.Clear();

            ScottPlot.TickGenerators.EvenlySpacedMinorTickGenerator minorTickGenX = new(2);
            ScottPlot.TickGenerators.NumericAutomatic tickGenX = new();
            tickGenX.TargetTickCount = 4;
            tickGenX.MinorTickGenerator = minorTickGenX;
            plot.Plot.Axes.Bottom.TickGenerator = tickGenX;

            ScottPlot.TickGenerators.EvenlySpacedMinorTickGenerator minorTickGenY = new(2);
            ScottPlot.TickGenerators.NumericAutomatic tickGenY = new();
            tickGenY.TargetTickCount = 4;
            tickGenY.MinorTickGenerator = minorTickGenY;
            plot.Plot.Axes.Left.TickGenerator = tickGenY;



            // show grid lines for minor ticks
            plot.Plot.Grid.MajorLineColor = Colors.Black.WithOpacity(.25);
            plot.Plot.Grid.MinorLineColor = Colors.Black.WithOpacity(.08);
            plot.Plot.Grid.MinorLineWidth = 1;


            //thdPlot.Plot.Axes.AutoScale();
            plot.Plot.Axes.SetLimits(startTime, endTime, minVoltage, maxVoltage);
            plot.Plot.Title("V (output)");
            plot.Plot.Axes.Title.Label.FontSize = 12;
            plot.Plot.Axes.Title.Label.OffsetY = 8;
            plot.Plot.Axes.Title.Label.Bold = false;

            plot.Plot.XLabel("ms");
            plot.Plot.Axes.Bottom.Label.OffsetX = 90;
            plot.Plot.Axes.Bottom.Label.OffsetY = -5;
            plot.Plot.Axes.Bottom.Label.FontSize = 12;
            plot.Plot.Axes.Bottom.Label.Bold = false;


            plot.Plot.Legend.IsVisible = false;

            plot.Refresh();

        }


        public static void PlotMiniTimeGraph(FormsPlot plot, LeftRightTimeSeries timeData, double frequency)
        {
            plot.Plot.Clear();

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
            var plotTot = plot.Plot.Add.Scatter(timeX, voltY);
            plotTot.LineWidth = 1;
            plotTot.Color = ScottPlot.Color.FromColor(System.Drawing.Color.FromArgb(1, 97, 170));
            plotTot.MarkerSize = 1;

            plot.Plot.Axes.SetLimits(0, time, -maxVolt, maxVolt);

            plot.Refresh();
        }


        public static System.Drawing.Image CopyControlToImage(Control theControl)
        {
            // Copy the whole control to a clicp board
            Bitmap bm = new Bitmap(theControl.Width, theControl.Height);
            theControl.DrawToBitmap(bm, new System.Drawing.Rectangle(0, 0, theControl.Width, theControl.Height));
            return bm;
        }

        public static void BitmapToClipboard(System.Drawing.Image bm)
        {
            Clipboard.SetImage(bm);
        }
    }
}           
    