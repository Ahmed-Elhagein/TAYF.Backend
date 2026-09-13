using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers
{
    /// <summary>
    /// Controller for maintenance-related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/v1/maintenance")]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMaintenancePriorityService _maintenancePriorityService;

        public MaintenanceController(IMaintenancePriorityService maintenancePriorityService)
        {
            _maintenancePriorityService = maintenancePriorityService;
        }

        /// <summary>
        /// Gets the maintenance priority for inverters in a plant.
        /// </summary>
        /// <param name="plantId">The plant identifier.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>The maintenance priority data.</returns>
        [HttpGet("priority")]
        [ProducesResponseType(typeof(MaintenancePriorityDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<MaintenancePriorityDto>> GetPriority(
            [FromQuery] int plantId,
            CancellationToken cancellationToken = default)
        {
            var result = await _maintenancePriorityService.GetMaintenancePriorityAsync(plantId, cancellationToken);
            return Ok(result);
        }
    }
}