namespace TAYF.Application.DTOs;
/// <summary>
/// Data transfer object for energy loss analysis.
/// </summary>
public class EnergyLossAnalysisDto
{
    public decimal ExpectedEnergyKwh { get; set; }
    public decimal ActualEnergyKwh { get; set; }
    public decimal EnergyLossKwh { get; set; }
    public string? PrimaryCause { get; set; } // Can be null if no data
}