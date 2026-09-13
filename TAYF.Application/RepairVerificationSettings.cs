namespace TAYF.Application;

/// <summary>
/// Settings for repair verification
/// </summary>
public class RepairVerificationSettings
{
    /// <summary>
    /// The threshold percentage for a repair to be considered verified (default: 90.0)
    /// </summary>
    public decimal SuccessThreshold { get; set; } = 90.0m;
}