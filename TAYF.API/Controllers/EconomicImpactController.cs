using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers
{
    [ApiController]
    [Route("api/v1/economic-impact")]
    public class EconomicImpactController : ControllerBase
    {
        private readonly IEconomicImpactService _economicImpactService;

        public EconomicImpactController(IEconomicImpactService economicImpactService)
        {
            _economicImpactService = economicImpactService;
        }

        [HttpGet]
        public async Task<ActionResult<EconomicImpactDto>> GetEconomicImpact(
            int plantId,
            DateTime? from,
            DateTime? to,
            string? tariffType)
        {
            var result = await _economicImpactService.GetEconomicImpactAsync(plantId, from, to, tariffType);
            return Ok(result);
        }
    }
}