using QA402_AUDIO_ANALYSER;

namespace QaControl
{
    public class ThdAmplitudeMeasurementSettings
    {
        public uint SampleRate { get; set; }
        public uint FftSize { get; set; }
        public int InputRange { get; set; }
        public Windowing Window { get; set; }
        public double StartFrequency { get; set; }
        public double EndFrequency { get; set; }
        public uint StepsPerOctave { get; set; }
        public double GenAmplitudeDbV { get; set; }
        public double GenAmplitudeV { get; set; }
        public int Averages { get; set; } = 1;
        public double Load { get; set; } = 8;                // 8 Ohm
        public double AmpOutputPower { get; set; } = 1;      // 1 Watt
        public double AmpOutputAmplitudeV { get; set; }      // V
        public double AmpOutputAmplitudeDbV { get; set; }
    }
}           
    