using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TelemetryController : ControllerBase
{
    private readonly ITelemetryService _telemetryService;

    public TelemetryController(ITelemetryService telemetryService)
    {
        _telemetryService = telemetryService;
    }

    // POST: api/v1/telemetry
    [HttpPost]
    public async Task<ActionResult<TelemetryDtoResponse>> PostTelemetry([FromBody] TelemetryDto telemetryDto)
    {
        var result = await _telemetryService.IngestTelemetry(telemetryDto);
        return Ok(result);
    }
}