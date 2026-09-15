using TAYF.Application.DTOs.Dashboard;

namespace TAYF.Application.Interfaces;

public interface IPlantDashboardService
{
    Task<PlantSummaryDto> GetSummaryAsync(int plantId, CancellationToken ct = default);
    Task<IReadOnlyList<TelemetryPointDto>> GetLatestTelemetryAsync(int plantId, int count, CancellationToken ct = default);
    Task<PerformanceTrendDto> GetPerformanceTrendAsync(int plantId, int days, CancellationToken ct = default);
    Task<SoilingStatusDto> GetSoilingStatusAsync(int plantId, CancellationToken ct = default);
}