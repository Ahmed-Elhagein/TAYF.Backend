using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers;

/// <summary>
/// Controller for repair verification endpoints
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class RepairVerificationController : ControllerBase
{
    private readonly IRepairVerificationService _repairVerificationService;

    public RepairVerificationController(IRepairVerificationService repairVerificationService)
    {
        _repairVerificationService = repairVerificationService;
    }

    /// <summary>
    /// Gets the repair verification for a specific maintenance action
    /// </summary>
    /// <param name="maintenanceActionId">The ID of the maintenance action</param>
    /// <returns>The repair verification DTO, or 404 if not found</returns>
    [HttpGet("{maintenanceActionId:int}")]
    public async Task<ActionResult<RepairVerificationDto>> GetRepairVerification(int maintenanceActionId)
    {
        var verification = await _repairVerificationService.GetRepairVerificationAsync(maintenanceActionId);

        if (verification == null)
        {
            return NotFound();
        }

        return Ok(verification);
    }

    /// <summary>
    /// Creates a new repair verification for a maintenance action
    /// </summary>
    /// <param name="dto">The data transfer object containing the verification details</param>
    /// <returns>The created repair verification DTO</returns>
    [HttpPost]
    public async Task<ActionResult<RepairVerificationDto>> CreateRepairVerification([FromBody] CreateRepairVerificationDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var verification = await _repairVerificationService.CreateRepairVerificationAsync(dto);
            return CreatedAtAction(nameof(GetRepairVerification), new { maintenanceActionId = verification.MaintenanceActionId }, verification);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}