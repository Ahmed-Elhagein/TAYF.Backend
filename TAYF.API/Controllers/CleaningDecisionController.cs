using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/decision")]
public class CleaningDecisionController : ControllerBase
{
    private readonly ICleaningDecisionService _service;

    public CleaningDecisionController(ICleaningDecisionService service)
    {
        _service = service;
    }

    [HttpPost("cleaning")]
    public async Task<ActionResult<CleaningDecisionResponseDto>> GetCleaningDecision(
        [FromBody] CleaningDecisionRequestDto request,
        CancellationToken ct)
    {
        var result = await _service.GetCleaningDecisionAsync(request, ct);
        return Ok(result);
    }
}