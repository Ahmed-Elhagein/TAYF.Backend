using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;
/// <summary>
/// Service for calculating financial loss analysis.
/// </summary>
public interface IFinancialLossAnalysisService
{
    Task<FinancialLossAnalysisDto> GetFinancialLossAnalysisAsync(int plantId, string tariffType);

    /// <summary>
    /// Gets the tariff information (rate and currency) for a plant.
    /// </summary>
    /// <param name="plantId">The plant identifier.</param>
    /// <param name="tariffType">Optional tariff type to override the plant's tariff.</param>
    /// <returns>The tariff information.</returns>
    Task<TariffInfoDto> GetTariffInfoAsync(int plantId, string? tariffType);
}