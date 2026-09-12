using TAYF.Domain.Enums;

namespace TAYF.Application.DTOs;
/// <summary>
/// Data transfer object for financial loss analysis.
/// </summary>
public class FinancialLossAnalysisDto
{
    public decimal EnergyLossKwh { get; set; }
    public string TariffType { get; set; } = null!; // From parameter (NetMetering, NetBilling, Licensed)
    public decimal TariffRate { get; set; }
    public string Currency { get; set; } = null!; // From plant's tariff (EGP, USD)
    public decimal EstimatedLoss { get; set; } // EnergyLossKwh * TariffRate
}