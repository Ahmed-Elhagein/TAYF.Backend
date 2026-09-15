using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/demo")]
[Produces("application/json")]
public class DemoScenarioController : ControllerBase
{
    private readonly IDemoScenarioService _service;

    public DemoScenarioController(IDemoScenarioService service)
    {
        _service = service;
    }

    /// <summary>
    /// Apply a Golden Demo scenario for a specific inverter.
    /// Supported: Normal, Underperformance, Soiling, InverterFault, Recovery.
    /// </summary>
    [HttpPost("scenario")]
    [ProducesResponseType(typeof(DemoScenarioResponseDto), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    public async Task<ActionResult<DemoScenarioResponseDto>> ApplyScenario(
        [FromBody] DemoScenarioRequestDto request,
        CancellationToken ct)
    {
        var result = await _service.ApplyScenarioAsync(request, ct);
        return Ok(result);
    }
}