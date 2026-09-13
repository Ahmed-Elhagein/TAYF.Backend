using System.Threading;
using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces
{
    /// <summary>
    /// Service for calculating maintenance priority.
    /// </summary>
    public interface IMaintenancePriorityService
    {
        /// <summary>
        /// Gets the maintenance priority for inverters in a plant.
        /// </summary>
        /// <param name="plantId">The plant identifier.</param>
        /// <param name="cancellationToken">Optional cancellation token.</param>
        /// <returns>The maintenance priority data.</returns>
        Task<MaintenancePriorityDto> GetMaintenancePriorityAsync(int plantId, CancellationToken cancellationToken = default);
    }
}