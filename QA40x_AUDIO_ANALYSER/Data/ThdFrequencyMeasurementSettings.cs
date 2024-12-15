using QA402_AUDIO_ANALYSER;

namespace QaControl
{
    public class ThdFrequencyMeasurementSettings
    {
        public uint SampleRate { get; set; }
        public uint FftSize { get; set; }
        public int InputRange { get; set; }
        public Windowing WindowingFunction { get; set; }
        public double StartFrequency { get; set; }
        public double EndFrequency { get; set; }
        public uint StepsPerOctave { get; set; }
        public double GeneratorAmplitude { get; set; }
        public E_VoltageUnit GeneratorAmplitudeUnit { get; set; }
        public int Averages { get; set; } = 1;
        public double Load { get; set; } = 8;                // 8 Ohm
        public double AmpOutputPower { get; set; } = 1;      // 1 Watt
        public double AmpOutputAmplitude { get; set; }      
        public E_VoltageUnit AmpOutputAmplitudeUnit { get; set; }
    }
}           
    