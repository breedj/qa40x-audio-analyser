using System;

namespace QA40x_AUDIO_ANALYSER
{
    public interface IMeasurementResult
    {
        DateTime CreateDate { get; set; }
        string Description { get; set; }
        bool Saved { get; set; }
        bool Show { get; set; }
        string Title { get; set; }
    }
}