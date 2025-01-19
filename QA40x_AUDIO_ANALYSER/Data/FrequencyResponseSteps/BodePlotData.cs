using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Text.Json.Serialization;
using QA40x_AUDIO_ANALYSER;

namespace QaControl
{

    public class BodePlotData
    {
        public string MeasurementType { get; } = "FREQUENCY_RESPONSE_STEPS";            // To identify the data type in json 

        public string Title { get; set; }
        public DateTime CreateDate { get; set; }

        public BodePlotMeasurementSettings MeasurementSettings { get; set; }
        public BodePlotGraphSettings GraphSettings { get; set; }
        public List<BodePlotMeasurementResult> Measurements { get; set; }


        public BodePlotData()
        {
            Measurements = [];
            MeasurementSettings = new();
            GraphSettings = new();
        }
    }
}           
    