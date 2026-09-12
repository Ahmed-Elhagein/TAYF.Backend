using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers
{
    [ApiController]
    [Route("api/v1/analysis/financial-loss")]
    public class FinancialLossAnalysisController : ControllerBase
    {
        private readonly IFinancialLossAnalysisService _financialLossAnalysisService;

        public FinancialLossAnalysisController(IFinancialLossAnalysisService financialLossAnalysisService)
        {
            _financialLossAnalysisService = financialLossAnalysisService;
        }

        [HttpGet]
        public async Task<ActionResult<FinancialLossAnalysisDto>> GetFinancialLossAnalysis(
            int plantId,
            string tariffType)
        {
            var result = await _financialLossAnalysisService.GetFinancialLossAnalysisAsync(plantId, tariffType);
            return Ok(result);
        }
    }
}