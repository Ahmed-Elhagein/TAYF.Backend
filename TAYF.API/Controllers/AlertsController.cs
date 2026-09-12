using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertService _alertService;

        public AlertsController(IAlertService alertService)
        {
            _alertService = alertService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlertDto>>> GetAlerts()
        {
            var alerts = await _alertService.GetAlertsAsync();
            return Ok(alerts);
        }
    }
}