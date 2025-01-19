using QA402_AUDIO_ANALYSER;
using QA40x_AUDIO_ANALYSER;

namespace QaControl
{
    public class BodePlotMeasurementSettings
    {
        public uint SampleRate { get; set; }
        public uint FftSize { get; set; }
        public Windowing WindowingFunction { get; set; }
        public E_GeneratorType GeneratorType { get; set; }
        public double GeneratorAmplitude { get; set; }
        public E_VoltageUnit GeneratorAmplitudeUnit { get; set;}
        public uint StartFrequency { get; set; }
        public uint EndFrequency { get; set; }
        public uint StepsPerOctave { get; set; }


        public BodePlotMeasurementSettings Copy()
        {
            return (BodePlotMeasurementSettings)MemberwiseClone();
        }
    }
}           
    