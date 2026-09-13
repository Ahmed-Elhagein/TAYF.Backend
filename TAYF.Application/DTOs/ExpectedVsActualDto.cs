using System;
using System.Collections.Generic;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for expected vs actual performance analysis.
    /// </summary>
    public class ExpectedVsActualDto
    {
        /// <summary>
        /// Gets or sets the plant identifier.
        /// </summary>
        public int PlantId { get; set; }

        /// <summary>
        /// Gets or sets the inverter identifier (null when aggregating by plant).
        /// </summary>
        public int? InverterId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the analysis period (UTC).
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the end date of the analysis period (UTC).
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the average expected power in kW across all data points.
        /// </summary>
        public double OverallExpectedPowerKw { get; set; }

        /// <summary>
        /// Gets or sets the average actual power in kW across all data points.
        /// </summary>
        public double OverallActualPowerKw { get; set; }

        /// <summary>
        /// Gets or sets the overall deviation percentage from expected to actual.
        /// </summary>
        public double OverallDeviationPct { get; set; }

        /// <summary>
        /// Gets or sets whether the overall performance is considered underperforming (deviation <= -10%).
        /// </summary>
        public bool IsUnderperforming { get; set; }

        /// <summary>
        /// Gets or sets the list of data points for each telemetry record.
        /// </summary>
        public List<ExpectedVsActualDataPointDto> DataPoints { get; set; } = new();
    }
}