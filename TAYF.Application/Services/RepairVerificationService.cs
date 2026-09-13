using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TAYF.Application.DTOs;
using TAYF.Domain.Entities;
using TAYF.Domain.Services;
using TAYF.Application.Interfaces;

namespace TAYF.Application.Services;

/// <summary>
/// Service for retrieving and creating repair verification data
/// </summary>
public class RepairVerificationService : IRepairVerificationService
{
    private readonly IApplicationDbContext _context;
    private readonly RepairVerificationSettings _settings;

    public RepairVerificationService(IApplicationDbContext context, IOptions<RepairVerificationSettings> settings)
    {
        _context = context;
        _settings = settings.Value;
    }

    /// <summary>
    /// Gets the repair verification for a specific maintenance action
    /// </summary>
    /// <param name="maintenanceActionId">The ID of the maintenance action</param>
    /// <returns>The repair verification DTO, or null if not found</returns>
    public async Task<RepairVerificationDto?> GetRepairVerificationAsync(int maintenanceActionId)
    {
        var verification = await _context.RepairVerifications
            .AsNoTracking()
            .FirstOrDefaultAsync(rv => rv.MaintenanceActionId == maintenanceActionId);

        if (verification == null)
        {
            return null;
        }

        return new RepairVerificationDto
        {
            MaintenanceActionId = verification.MaintenanceActionId,
            PerformanceBefore = verification.PerformanceBefore,
            PerformanceAfter = verification.PerformanceAfter,
            ExpectedPowerKw = verification.ExpectedPowerKw,
            RecoveryPct = verification.RecoveryPct,
            IsStable = verification.IsStable,
            Verified = verification.Verified,
            VerifiedAt = verification.VerifiedAt
        };
    }

    /// <summary>
    /// Creates a new repair verification for a maintenance action
    /// </summary>
    /// <param name="dto">The data transfer object containing the verification details</param>
    /// <returns>The created repair verification DTO</returns>
    public async Task<RepairVerificationDto> CreateRepairVerificationAsync(CreateRepairVerificationDto dto)
    {
        // Validate that the maintenance action exists
        var maintenanceActionExists = await _context.MaintenanceActions
            .AnyAsync(ma => ma.Id == dto.MaintenanceActionId);

        if (!maintenanceActionExists)
        {
            throw new ArgumentException($"Maintenance action with ID {dto.MaintenanceActionId} does not exist");
        }

        // Calculate the recovery rate
        var recoveryRate = RecoveryCalculator.CalculateRecoveryRate(
            dto.PerformanceBefore,
            dto.PerformanceAfter,
            dto.ExpectedPowerKw);

        // Determine if the repair is verified based on the threshold
        var isVerified = RecoveryCalculator.IsVerified(recoveryRate, _settings.SuccessThreshold);

        // Create the entity
        var verification = new RepairVerification
        {
            MaintenanceActionId = dto.MaintenanceActionId,
            PerformanceBefore = dto.PerformanceBefore,
            PerformanceAfter = dto.PerformanceAfter,
            ExpectedPowerKw = dto.ExpectedPowerKw,
            RecoveryPct = recoveryRate,
            IsStable = dto.IsStable,
            Verified = isVerified,
            VerifiedAt = DateTime.UtcNow
        };

        // Add to context and save
        _context.RepairVerifications.Add(verification);
        await _context.SaveChangesAsync();

        // Return the DTO
        return new RepairVerificationDto
        {
            MaintenanceActionId = verification.MaintenanceActionId,
            PerformanceBefore = verification.PerformanceBefore,
            PerformanceAfter = verification.PerformanceAfter,
            ExpectedPowerKw = verification.ExpectedPowerKw,
            RecoveryPct = verification.RecoveryPct,
            IsStable = verification.IsStable,
            Verified = verification.Verified,
            VerifiedAt = verification.VerifiedAt
        };
    }
}