using TAYF.Application.DTOs;
using TAYF.Domain.Entities;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Handles telemetry ingestion and duplicate protection.
/// </summary>
public interface ITelemetryService
{
    /// <summary>
    /// Ingests telemetry data, checks for duplicates, and saves to database.
    /// </summary>
    /// <param name="telemetryDto">The telemetry data to ingest.</param>
    /// <returns>A response indicating the telemetry ID and whether it was received.</returns>
    Task<TelemetryDtoResponse> IngestTelemetry(TelemetryDto telemetryDto);

    /// <summary>
    /// Retrieves historical telemetry data with filtering and pagination.
    /// </summary>
    /// <param name="query">The query parameters for filtering and pagination.</param>
    /// <returns>A paged result of telemetry history DTOs.</returns>
    Task<PagedResult<TelemetryHistoryDto>> GetTelemetryHistoryAsync(TelemetryQueryDto query);
}