namespace TAYF.Application.DTOs;

public class CleaningDecisionResponseDto
{
    public decimal ExpectedRecoveryKwh { get; set; }
    public decimal ExpectedRecoveryValue { get; set; }
    public decimal CleaningCost { get; set; }
    public decimal NetBenefit { get; set; }
    public string Currency { get; set; } = "EGP";
    public string Recommendation { get; set; } = "Wait";
}