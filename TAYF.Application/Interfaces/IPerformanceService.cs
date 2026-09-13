using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces
{
    /// <summary>
    /// Service for calculating expected vs actual performance.
    /// </summary>
    public interface IPerformanceService
    {
        /// <summary>
        /// Gets the expected vs actual performance analysis for a plant and optional inverter over a time range.
        /// </summary>
        /// <param name="plantId">The plant identifier.</param>
        /// <param name="inverterId">The inverter identifier (null to aggregate by plant).</param>
        /// <param name="from">The start date of the analysis period (UTC).</param>
        /// <param name="to">The end date of the analysis period (UTC).</param>
        /// <returns>The expected vs actual performance analysis.</returns>
        Task<ExpectedVsActualDto> GetExpectedVsActualAsync(int plantId, int? inverterId, DateTime from, DateTime to);
    }
}