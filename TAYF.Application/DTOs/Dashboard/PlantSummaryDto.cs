namespace TAYF.Application.DTOs.Dashboard;

public class PlantSummaryDto
{
    public int PlantId { get; set; }
    public string PlantName { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
    public decimal CurrentPowerKw { get; set; }
    public decimal TodayEnergyKwh { get; set; }
    public decimal TodayExpectedKwh { get; set; }
    public decimal TodayDeviationPct { get; set; }
    public decimal PvSharePct { get; set; }
    public int ActiveAlerts { get; set; }
    public int CriticalAlerts { get; set; }
    public DateTime LastUpdated { get; set; }
}