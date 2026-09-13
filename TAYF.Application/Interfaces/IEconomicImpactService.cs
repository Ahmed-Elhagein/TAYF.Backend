using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;
/// <summary>
/// Service for calculating economic impact analysis.
/// </summary>
public interface IEconomicImpactService
{
    Task<EconomicImpactDto> GetEconomicImpactAsync(
        int plantId,
        DateTime? from,
        DateTime? to,
        string? tariffType);
}