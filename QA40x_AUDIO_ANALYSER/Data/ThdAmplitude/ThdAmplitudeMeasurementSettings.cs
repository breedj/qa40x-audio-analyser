﻿using QA402_AUDIO_ANALYSER;

namespace QaControl
{
    public class ThdAmplitudeMeasurementSettings
    {
        public uint SampleRate { get; set; }
        public uint FftSize { get; set; }
        public Windowing WindowingFunction { get; set; }
        public double Frequency { get; set; }
        public uint StepsPerOctave { get; set; }
        public double StartAmplitude { get; set; }
        public E_VoltageUnit StartAmplitudeUnit { get; set;}
        public double EndAmplitude { get; set; }
        public E_VoltageUnit EndAmplitudeUnit { get; set; }
        public uint Averages { get; set; } = 1;
        public double Load { get; set; } = 8;                // 8 Ohm
        public bool EnableLeftChannel { get; set; } = true;
        public bool EnableRightChannel { get; set; } = true;

        public ThdAmplitudeMeasurementSettings Copy()
        {
            return (ThdAmplitudeMeasurementSettings)MemberwiseClone();
        }
    }
}           
    