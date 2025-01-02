using QA402_AUDIO_ANALYSER;
using QaControl;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace QA40x_AUDIO_ANALYSER
{
    public class FrequencyResponseMeasurementResult : IMeasurementResult
    {
        public string Title { get; set; }                                               // Measurement title
        public string Description { get; set; }                                         // Description
        public DateTime CreateDate { get; set; }                                        // Measurement date time
        public bool Show { get; set; }                                                  // Show in graph
        public bool Saved { get; set; }                                                 // Has been saved
        public LeftRightSeries FrequencyResponseData { get; set; }                      // Measurement data
        public double[] GainData { get; set; }                                          // Calculated gain over frequency
        public FrequencyResponseMeasurementSettings MeasurementSettings { get; set; }   //  Settings used for this measurement

        public FrequencyResponseMeasurementResult()
        {
            FrequencyResponseData = new();
            MeasurementSettings = new();
        }
    }
}
