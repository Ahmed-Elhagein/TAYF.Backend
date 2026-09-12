using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Validators;
using TAYF.Domain.Entities;
using TAYF.Application.Interfaces;

namespace TAYF.Application.Services;

/// <summary>
/// Handles telemetry ingestion and duplicate protection.
/// </summary>
public class TelemetryService : ITelemetryService
{
    private readonly IApplicationDbContext _context;
    private readonly TelemetryDtoValidator _validator;

    public TelemetryService(IApplicationDbContext context, TelemetryDtoValidator validator)
    {
        _context = context;
        _validator = validator;
    }

    /// <summary>
    /// Ingests telemetry data, checks for duplicates, and saves to database.
    /// </summary>
    /// <param name="telemetryDto">The telemetry data to ingest.</param>
    /// <returns>A response indicating the telemetry ID and whether it was received.</returns>
    public async Task<TelemetryDtoResponse> IngestTelemetry(TelemetryDto telemetryDto)
    {
        // Validate the DTO
        var validationResult = await _validator.ValidateAsync(telemetryDto);
        if (!validationResult.IsValid)
        {
            // In a real application, we might want to return validation errors
            // For now, we'll just throw an exception or handle it appropriately
            throw new ValidationException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
        }

        // Parse timestamp
        if (!DateTime.TryParse(telemetryDto.Timestamp, out DateTime timestamp))
        {
            throw new ArgumentException("Invalid timestamp format");
        }

        // Check for duplicate telemetry (same plant, inverter, and timestamp)
        var existingTelemetry = await _context.TelemetryRecords
            .FirstOrDefaultAsync(t =>
                t.PlantId == telemetryDto.PlantId &&
                t.InverterId == telemetryDto.InverterId &&
                t.Timestamp == timestamp);

        if (existingTelemetry != null)
        {
            // Duplicate detected - return the existing telemetry ID but indicate it wasn't received as new
            return new TelemetryDtoResponse
            {
                TelemetryId = existingTelemetry.Id,
                Received = false // Indicates it was a duplicate
            };
        }

        // Validate that PlantId and InverterId exist
        var plantExists = await _context.Plants.AnyAsync(p => p.Id == telemetryDto.PlantId);
        if (!plantExists)
        {
            throw new ArgumentException($"Plant with ID {telemetryDto.PlantId} does not exist");
        }

        var inverterExists = await _context.Inverters.AnyAsync(i => i.Id == telemetryDto.InverterId && i.PlantId == telemetryDto.PlantId);
        if (!inverterExists)
        {
            throw new ArgumentException($"Inverter with ID {telemetryDto.InverterId} does not exist or does not belong to plant {telemetryDto.PlantId}");
        }

        // Create new telemetry entity
        var telemetry = new Telemetry
        {
            PlantId = telemetryDto.PlantId,
            InverterId = telemetryDto.InverterId,
            Timestamp = timestamp,
            AcPowerKw = (decimal)telemetryDto.AcPowerKw,
            DcPowerKw = (decimal)telemetryDto.DcPowerKw,
            Irradiance = (int)telemetryDto.Irradiance, // Assuming irradiance is stored as integer
            AmbientTemperature = (decimal)telemetryDto.AmbientTemperature,
            ModuleTemperature = (decimal)telemetryDto.ModuleTemperature,
            DailyYield = telemetryDto.DailyYield,
            TotalYield = telemetryDto.TotalYield
        };

        // Save to database
        _context.TelemetryRecords.Add(telemetry);
        await _context.SaveChangesAsync();

        // Return success response
        return new TelemetryDtoResponse
        {
            TelemetryId = telemetry.Id,
            Received = true
        };
    }
}

// Custom exception for validation errors
public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}