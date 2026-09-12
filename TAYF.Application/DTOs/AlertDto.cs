using TAYF.Domain.Enums;

namespace TAYF.Application.DTOs;
/// <summary>
/// Data transfer object for alert information.
/// </summary>
public class AlertDto
{
    public string Severity { get; set; } = null!;
    public string Asset { get; set; } = null!; // Inverter serial number
    public string Problem { get; set; } = null!;
    public string RootCause { get; set; } = null!;
    public decimal EnergyLossKwh { get; set; }
    public decimal FinancialLossEgp { get; set; } // Financial loss in EGP
    public string RecommendedAction { get; set; } = null!;
}