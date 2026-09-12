using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers
{
    [ApiController]
    [Route("api/v1/analysis/energy-loss")]
    public class EnergyLossAnalysisController : ControllerBase
    {
        private readonly IEnergyLossAnalysisService _energyLossAnalysisService;

        public EnergyLossAnalysisController(IEnergyLossAnalysisService energyLossAnalysisService)
        {
            _energyLossAnalysisService = energyLossAnalysisService;
        }

        [HttpGet]
        public async Task<ActionResult<EnergyLossAnalysisDto>> GetEnergyLossAnalysis(
            int plantId,
            int? inverterId,
            DateTime from,
            DateTime to)
        {
            var result = await _energyLossAnalysisService.GetEnergyLossAnalysisAsync(plantId, inverterId, from, to);
            return Ok(result);
        }
    }
}