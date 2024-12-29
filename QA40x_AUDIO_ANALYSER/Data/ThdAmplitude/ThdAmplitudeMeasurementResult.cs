using QA402_AUDIO_ANALYSER;
using QaControl;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace QA40x_AUDIO_ANALYSER
{
    public class ThdAmplitudeMeasurementResult : IMeasurementResult
    {
        public string Title { get; set; }                                               // Measurement title
        public string Description { get; set; }                                         // Description
        public DateTime CreateDate { get; set; }                                        // Measurement date time
        public bool Show { get; set; }                                                  // Show in graph
        public bool Saved { get; set; }                                                 // Has been saved
        public List<ThdAmplitudeStep> AmplitudeSteps { get; set; }                      // Measurement data
        public ThdAmplitudeMeasurementSettings MeasurementSettings { get; set; }        //  Settings used for this measurement

        [JsonIgnore]
        public LeftRightSeries NoiseFloor { get; set; }                                 // Noise floor measurement

        public ThdAmplitudeMeasurementResult()
        {
            AmplitudeSteps = [];
            MeasurementSettings = new();
        }
    }
}
