using QA402_AUDIO_ANALYSER;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;


namespace QaControl
{
    public class ThdAmplitudeStep
    {
        public double FundamentalFrequency { get; set; }
        public double GeneratorVoltage { get; set; }
        public ThdFrequencyStepChannel Left { get; set; }
        public ThdFrequencyStepChannel Right { get; set; }

        [JsonIgnore]
        public LeftRightFrequencySeries fftData { get; set; }
        [JsonIgnore]
        public LeftRightTimeSeries timeData { get; set; }

        public ThdAmplitudeStep()
        {
            Left = new ThdFrequencyStepChannel();
            Right = new ThdFrequencyStepChannel();
        }
    }
}