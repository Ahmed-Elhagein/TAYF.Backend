using System;

namespace TAYF.Application.Scada
{
    /// <summary>
    /// Query parameters for filtering SCADA data.
    /// </summary>
    public record ScadaQuery
    {
        /// <summary>
        /// Start timestamp for the data range (inclusive).
        /// </summary>
        public DateTime? From { get; init; }

        /// <summary>
        /// End timestamp for the data range (inclusive).
        /// </summary>
        public DateTime? To { get; init; }

        /// <summary>
        /// Filter by inverter identifier.
        /// </summary>
        public string? InverterId { get; init; }

        /// <summary>
        /// Filter by station identifier.
        /// </summary>
        public string? StationId { get; init; }
    }
}