using System.Collections.Generic;
using System.Net.Security;
using System.Text.Json.Serialization;
using QA402_AUDIO_ANALYSER;

namespace QaControl
{

    public class ThdAmplitudeMeasurementData
    {
        public ThdAmplitudeMeasurementSettings Settings { get; set; }
        public List<ThdFrequencyStep> StepData { get; set; }

        [JsonIgnore]
        public LeftRightSeries NoiseFloor { get; set; }


        public ThdAmplitudeMeasurementData()
        {
            StepData = new List<ThdFrequencyStep>();
            Settings = new ThdAmplitudeMeasurementSettings();
        }
    }
}           
    