namespace TAYF.Application.DTOs.Dashboard;

public class SoilingStatusDto
{
    public int PlantId { get; set; }
    public decimal CurrentSoilingLossPct { get; set; }
    public int DaysSinceLastCleaning { get; set; }
    public decimal EstimatedRecoveryKwh { get; set; }
    public DateTime? LastCleaningDate { get; set; }
    public string Recommendation { get; set; } = "Unknown";
}