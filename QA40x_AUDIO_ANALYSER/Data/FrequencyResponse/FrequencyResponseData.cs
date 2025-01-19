using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text.Json.Serialization;
using QA40x_AUDIO_ANALYSER;

namespace QaControl
{

    public class FrequencyResponseData
    {
        public string MeasurementType { get; } = "FREQUENCY_RESPONSE_CHIRP";            // To identify the data type in json 

        public string Title { get; set; }
        public DateTime CreateDate { get; set; }

        public FrequencyResponseMeasurementSettings MeasurementSettings { get; set; }
        public FrequencyResponseGraphSettings GraphSettings { get; set; }
        public List<FrequencyResponseMeasurementResult> Measurements { get; set; }


        public FrequencyResponseData()
        {
            Measurements = [];
            MeasurementSettings = new();
            GraphSettings = new();
        }
    }
}           
    