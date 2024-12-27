﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QaControl
{
    public class ThdFrequencyStepChannel
    {
        public double Fundamental_V { get; set; }
        public double Fundamental_dBV { get; set; }
        public double Gain_dB { get; set; }
        public List<HarmonicData> Harmonics { get; set; }
        public double Thd_Percent { get; set; }
        public double Thd_dB { get; set; }
        //public double Thd_dBN { get; set; }
        public double D6Plus_dBV { get; set; }
        public double ThdPercent_D6plus { get; set; }
        public double ThdDbD6plus { get; set; }
        public double Power_Watt { get; set; }
        public double Average_NoiseFloor_V { get; set; }
        public double Average_NoiseFloor_dBV { get; set; }

        public ThdFrequencyStepChannel() {
            Harmonics = [];
        }
    }
}           
    