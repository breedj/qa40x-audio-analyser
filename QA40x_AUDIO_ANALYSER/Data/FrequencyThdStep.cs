using System.Collections.Generic;
using System.Text.Json.Serialization;
using QA402_AUDIO_ANALYSER;

namespace QaControl
{
    public class FrequencyThdStep
    {
        public double FundamentalFrequency { get; set; }
        public double GeneratorVoltage { get; set; }
        public double AmplitudeVolts { get; set; }
        public double AmplitudeDbV { get; set; }
        public double MagnitudeDb { get; set; }
        public List<HarmonicData> Harmonics { get; set; }
        public double ThdPercent { get; set; }
        public double ThdDb { get; set; }
        public double ThdDbN { get; set; }
        [JsonIgnore]
        public LeftRightFrequencySeries fftData { get; set; }
        [JsonIgnore]
        public LeftRightTimeSeries timeData { get; set; }
        public double DcComponent { get; set; }
        public double D6PlusDbV { get; set; }
        public double ThdPercentD6plus { get; set; }
        public double ThdDbD6plus { get; set; }
        public double PowerWatt { get; set; }
        public double NoiseFloorV { get; set; }
        public double NoiseFloorDbV { get; set; }

        public FrequencyThdStep() {
            Harmonics = new List<HarmonicData>();
        }
    }
}           
    