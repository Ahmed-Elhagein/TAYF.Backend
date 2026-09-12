namespace TAYF.Domain.Enums;

/// <summary>
/// Types of electricity tariff arrangements for solar plants
/// </summary>
public enum TariffType
{
    /// <summary>
    /// Net metering - excess energy sent to grid is credited at retail rate
    /// </summary>
    NetMetering = 1,

    /// <summary>
    /// Net billing - excess energy sold to grid at wholesale/avoided cost rate
    /// </summary>
    NetBilling = 2,

    /// <summary>
    /// Licensed - utility-scale plant selling all generation under PPA or market rates
    /// </summary>
    Licensed = 3
}