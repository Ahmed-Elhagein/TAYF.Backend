using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/plant")]
public class PlantStatusController : ControllerBase
{
    private readonly IPlantStatusService _plantStatusService;

    public PlantStatusController(IPlantStatusService plantStatusService)
    {
        _plantStatusService = plantStatusService;
    }

    // GET: api/v1/plant/status?plantId=1
    [HttpGet("status")]
    public async Task<ActionResult<PlantStatusDto>> GetPlantStatus([FromQuery] int plantId)
    {
        var status = await _plantStatusService.GetPlantStatusAsync(plantId);
        return Ok(status);
    }
}