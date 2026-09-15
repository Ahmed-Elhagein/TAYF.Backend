using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs.Dashboard;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/plant")]
public class PlantDashboardController : ControllerBase
{
    private readonly IPlantDashboardService _dashboardService;

    public PlantDashboardController(IPlantDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("summary")]
    public async Task<ActionResult<PlantSummaryDto>> GetSummary(int plantId, CancellationToken ct = default)
    {
        var summary = await _dashboardService.GetSummaryAsync(plantId, ct);
        return Ok(summary);
    }

    [HttpGet("telemetry/latest")]
    public async Task<ActionResult<IReadOnlyList<TelemetryPointDto>>> GetLatestTelemetry(int plantId, int count = 20, CancellationToken ct = default)
    {
        var telemetry = await _dashboardService.GetLatestTelemetryAsync(plantId, count, ct);
        return Ok(telemetry);
    }

    [HttpGet("performance/trend")]
    public async Task<ActionResult<PerformanceTrendDto>> GetPerformanceTrend(int plantId, int days = 7, CancellationToken ct = default)
    {
        var trend = await _dashboardService.GetPerformanceTrendAsync(plantId, days, ct);
        return Ok(trend);
    }

    [HttpGet("soiling/status")]
    public async Task<ActionResult<SoilingStatusDto>> GetSoilingStatus(int plantId, CancellationToken ct = default)
    {
        var status = await _dashboardService.GetSoilingStatusAsync(plantId, ct);
        return Ok(status);
    }
}