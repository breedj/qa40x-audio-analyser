﻿using QA402_AUDIO_ANALYSER;
using QA40x_AUDIO_ANALYSER;
using QA40x_AUDIO_ANALYSER.Data.ThdAmplitude;

namespace QaControl
{
    public class FrequencyResponseGraphSettings
    {
        public E_FrequencyResponse_GraphType GraphType { get; set; }         
        public bool ShowLeftChannel { get; set; }
        public bool ShowRightChannel { get; set; }
        public bool ThickLines { get; set; }
        public bool ShowDataPoints { get; set; }
        public double YRangeTop { get; set; }
        public double YRangeBottom { get; set; }
        public uint FrequencyRange_Start { get; set; }
        public uint FrequencyRange_End { get; set; }
        public bool Show3dBBandwidth_L { get; set; }
        public bool Show1dBBandwidth_L { get; set; }
        public bool Show3dBBandwidth_R { get; set; }
        public bool Show1dBBandwidth_R { get; set; }
    }
}           
    