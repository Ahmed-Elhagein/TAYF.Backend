using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;
/// <summary>
/// Service for calculating financial loss analysis.
/// </summary>
public interface IFinancialLossAnalysisService
{
    Task<FinancialLossAnalysisDto> GetFinancialLossAnalysisAsync(int plantId, string tariffType);
}