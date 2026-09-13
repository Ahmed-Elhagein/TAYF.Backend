using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers
{
    [ApiController]
    [Route("api/v1/performance")]
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _performanceService;

        public PerformanceController(IPerformanceService performanceService)
        {
            _performanceService = performanceService;
        }

        [HttpGet("expected-vs-actual")]
        public async Task<ActionResult<ExpectedVsActualDto>> GetExpectedVsActual(
            [FromQuery] int plantId,
            [FromQuery] int? inverterId,
            [FromQuery] DateTime? from,
            [FromQuery] DateTime? to)
        {
            var start = from ?? DateTime.UtcNow.AddDays(-7);
            var end = to ?? DateTime.UtcNow;

            var result = await _performanceService.GetExpectedVsActualAsync(plantId, inverterId, start, end);
            return Ok(result);
        }
    }
}