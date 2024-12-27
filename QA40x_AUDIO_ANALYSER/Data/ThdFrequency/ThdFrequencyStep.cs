
using QA402_AUDIO_ANALYSER;
using System.Text.Json.Serialization;

namespace QaControl
{
    public class ThdFrequencyStep
    {
        public double FundamentalFrequency { get; set; }
        public double GeneratorVoltage { get; set; }
        public ThdFrequencyStepChannel Left {  get; set; }
        public ThdFrequencyStepChannel Right { get; set; }

        [JsonIgnore]
        public LeftRightFrequencySeries fftData { get; set; }
        [JsonIgnore]
        public LeftRightTimeSeries timeData { get; set; }

        public ThdFrequencyStep() {
            Left = new ThdFrequencyStepChannel();
            Right = new ThdFrequencyStepChannel();
        }
    }
}           
    