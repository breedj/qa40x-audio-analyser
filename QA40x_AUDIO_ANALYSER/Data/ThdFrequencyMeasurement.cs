using System.Collections.Generic;
using System.Net.Security;
using System.Text.Json.Serialization;
using QA402_AUDIO_ANALYSER;

namespace QaControl
{

    public class ThdFrequencyMeasurement
    {
        public ThdFrequencyMeasurementSettings Settings { get; set; }
        public List<FrequencyThdStep> StepData { get; set; }
        [JsonIgnore]
        public LeftRightSeries NoiseFloor { get; set; }


        public ThdFrequencyMeasurement()
        {
            StepData = new List<FrequencyThdStep>();
            Settings = new ThdFrequencyMeasurementSettings();
        }
    }
}           
    