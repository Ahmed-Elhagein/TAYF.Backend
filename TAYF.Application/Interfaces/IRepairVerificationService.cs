using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Service for retrieving and creating repair verification data
/// </summary>
public interface IRepairVerificationService
{
    /// <summary>
    /// Gets the repair verification for a specific maintenance action
    /// </summary>
    /// <param name="maintenanceActionId">The ID of the maintenance action</param>
    /// <returns>The repair verification DTO, or null if not found</returns>
    Task<RepairVerificationDto?> GetRepairVerificationAsync(int maintenanceActionId);

    /// <summary>
    /// Creates a new repair verification for a maintenance action
    /// </summary>
    /// <param name="dto">The data transfer object containing the verification details</param>
    /// <returns>The created repair verification DTO</returns>
    Task<RepairVerificationDto> CreateRepairVerificationAsync(CreateRepairVerificationDto dto);
}