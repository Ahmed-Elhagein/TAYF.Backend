using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;
/// <summary>
/// Service for calculating energy loss analysis.
/// </summary>
public interface IEnergyLossAnalysisService
{
    Task<EnergyLossAnalysisDto> GetEnergyLossAnalysisAsync(int plantId, int? inverterId, DateTime from, DateTime to);
}