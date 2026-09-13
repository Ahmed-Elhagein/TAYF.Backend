using System;

namespace TAYF.Application.DTOs;

/// <summary>
/// Query parameters for filtering telemetry history
/// </summary>
public class TelemetryQueryDto
{
    /// <summary>
    /// Plant ID filter
    /// </summary>
    public int? PlantId { get; set; }

    /// <summary>
    /// Inverter ID filter
    /// </summary>
    public int? InverterId { get; set; }

    /// <summary>
    /// Start timestamp filter (inclusive)
    /// </summary>
    public DateTime? From { get; set; }

    /// <summary>
    /// End timestamp filter (inclusive)
    /// </summary>
    public DateTime? To { get; set; }

    /// <summary>
    /// Page number (1-based)
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Page size (number of items per page)
    /// </summary>
    public int PageSize { get; set; } = 50;
}