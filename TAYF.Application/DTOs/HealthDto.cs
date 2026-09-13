using System;

namespace TAYF.Application.DTOs;

/// <summary>
/// Health check response DTO
/// </summary>
public class HealthDto
{
    /// <summary>
    /// Health status
    /// </summary>
    public string Status { get; set; } = "Healthy";

    /// <summary>
    /// Timestamp of the health check
    /// </summary>
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Application version
    /// </summary>
    public string Version { get; set; } = "1.0.0";

    /// <summary>
    /// Current environment
    /// </summary>
    public string Environment { get; set; } = "Development";
}