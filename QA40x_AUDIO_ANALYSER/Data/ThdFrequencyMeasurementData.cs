using System.Collections.Generic;
using System.Net.Security;
using System.Text.Json.Serialization;
using QA402_AUDIO_ANALYSER;

namespace QaControl
{

    public class ThdFrequencyMeasurementData
    {
        public ThdFrequencyMeasurementSettings Settings { get; set; }
        public List<FrequencyThdStep> StepData { get; set; }
        [JsonIgnore]
        public LeftRightSeries NoiseFloor { get; set; }


        public ThdFrequencyMeasurementData()
        {
            StepData = new List<FrequencyThdStep>();
            Settings = new ThdFrequencyMeasurementSettings();
        }
    }
}           
    