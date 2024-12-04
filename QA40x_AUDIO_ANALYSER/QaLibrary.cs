using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using QA402_AUDIO_ANALYSER;

namespace QaControl
{

    public class QaLibrary
    {
        

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
        public static double[] GetLineairSpacedLogarithmicFrequenciesPerDecade(double startFrequency, double stopFrequency, int stepsPerDecade)
        {
            // Calculate the logarithmic start and stop values
            double logStart = Math.Log10(startFrequency);
            double logStop = Math.Log10(stopFrequency);

            // Calculate the number of total steps based on the steps per decade
            int totalSteps = (int)(stepsPerDecade * (logStop - logStart));

            // Calculate the increment in logarithmic space
            double logStep = (logStop - logStart) / totalSteps;

            // Generate the frequencies array
            double[] frequencies = new double[totalSteps + 1];
            for (int i = 0; i <= totalSteps; i++)
            {
                // Calculate the frequency by raising 10 to the power of the current log position
                frequencies[i] = Math.Pow(10, logStart + i * logStep);
            }

            return frequencies;
        }


        /// <summary>
        /// Get a list of x frequencies per octave between a start and stop frequency in a way that they are spaced equally on a graph with logarithmic scale.
        /// </summary>
        /// <param name="startFrequency">Start frequency</param>
        /// <param name="stopFrequency">Stop frequency</param>
        /// <param name="stepsPerOctave">Steps per octave</param>
        /// <returns></returns>
        public static double[] GetLineairSpacedLogarithmicFrequenciesPerOctave(double startFrequency, double stopFrequency, uint stepsPerOctave)
        {
            // Calculate the number of octaves between start and stop frequencies
            double octaves = Math.Log(stopFrequency / startFrequency, 2);

            // Calculate the total number of steps based on steps per octave
            int totalSteps = (int)(stepsPerOctave * octaves);

            // Calculate the increment in logarithmic space (base 2)
            double logStep = octaves / totalSteps;

            // Generate the frequencies array
            double[] frequencies = new double[totalSteps + 1];
            for (int i = 0; i <= totalSteps; i++)
            {
                // Calculate the frequency by raising 2 to the power of the current log position
                frequencies[i] =  startFrequency * Math.Pow(2, i * logStep);
            }

            return frequencies;
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

        static public async Task<LeftRightSeries> DoAcquisitions(int averages)
        {
            LeftRightSeries leftRightSeries = new LeftRightSeries();

            await Qa40x.DoAcquisition();
            leftRightSeries.FreqInput = await Qa40x.GetInputFrequencySeries();
            leftRightSeries.TimeInput = await Qa40x.GetInputTimeSeries();

            if (averages <= 1)
                return leftRightSeries;        // Only one measurement

            for (int i = 1; i < averages; i++)
            {
                await Qa40x.DoAcquisition();
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

    }
}           
    