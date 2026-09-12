using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class DiagnosisController : ControllerBase
{
    private readonly IRootCauseService _rootCauseService;
    private readonly ILogger<DiagnosisController> _logger;

    public DiagnosisController(IRootCauseService rootCauseService, ILogger<DiagnosisController> logger)
    {
        _rootCauseService = rootCauseService;
        _logger = logger;
    }

    // GET: api/v1/diagnosis/root-cause?plantId=1&inverterId=1&timestamp=2026-09-10T10:15:00Z
    [HttpGet("root-cause")]
    public async Task<ActionResult<RootCauseDiagnosisDto>> GetRootCause(
        [FromQuery] int plantId,
        [FromQuery] int inverterId,
        [FromQuery] string timestamp)
    {
        // Parse the timestamp
        if (!DateTime.TryParse(timestamp, out DateTime parsedTimestamp))
        {
            return BadRequest("Invalid timestamp format. Use ISO 8601 format (e.g., 2026-09-10T10:15:00Z)");
        }

        try
        {
            var diagnosis = await _rootCauseService.GetRootCauseDiagnosisAsync(
                plantId,
                inverterId,
                parsedTimestamp);

            return Ok(diagnosis);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while processing the request.");
            return StatusCode(500, "An error occurred while processing the request.");
        }
    }
}