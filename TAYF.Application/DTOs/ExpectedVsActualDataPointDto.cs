using System;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for a single data point in expected vs actual performance.
    /// </summary>
    public class ExpectedVsActualDataPointDto
    {
        /// <summary>
        /// Gets or sets the timestamp of the telemetry record.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the expected power in kW.
        /// </summary>
        public double ExpectedPowerKw { get; set; }

        /// <summary>
        /// Gets or sets the actual power in kW from telemetry.
        /// </summary>
        public double ActualPowerKw { get; set; }

        /// <summary>
        /// Gets or sets the deviation percentage: ((Actual - Expected) / Expected) * 100.
        /// </summary>
        public double DeviationPct { get; set; }

        /// <summary>
        /// Gets or sets whether this point is considered an anomaly (deviation <= -10%).
        /// </summary>
        public bool IsAnomaly { get; set; }
    }
}