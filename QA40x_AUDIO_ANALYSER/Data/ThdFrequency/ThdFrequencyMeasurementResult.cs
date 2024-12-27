using QA402_AUDIO_ANALYSER;
using QaControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QA40x_AUDIO_ANALYSER
{
    public class ThdFrequencyMeasurementResult : IMeasurementResult
    {
        public string Title { get; set; }                                               // Measurement title
        public string Description { get; set; }                                         // Description
        public DateTime CreateDate { get; set; }                                        // Measurement date time
        public bool Show { get; set; }                                                  // Show in graph
        public bool Saved { get; set; }                                                 // Has been saved
        public List<ThdFrequencyStep> FrequencySteps { get; set; }                      // Measurement data
        public ThdFrequencyMeasurementSettings MeasurementSettings { get; set; }        //  Settings used for this measurement

        [JsonIgnore]
        public LeftRightSeries NoiseFloor { get; set; }                                 // Noise floor measurement

        public ThdFrequencyMeasurementResult()
        {
            FrequencySteps = [];
            MeasurementSettings = new();
        }
    }
}
