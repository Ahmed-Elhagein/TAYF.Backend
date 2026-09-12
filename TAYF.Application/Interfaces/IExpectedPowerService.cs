using TAYF.Domain.Entities;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Calculates expected power for solar inverters.
/// </summary>
public interface IExpectedPowerService
{
    /// <summary>
    /// Calculates the expected power based on irradiance and inverter specifications.
    /// Formula: ExpectedPower = Inverter.RatedPowerKw * (Irradiance / 1000)
    /// If RatedPowerKw is null, return actual power to avoid breaking.
    /// </summary>
    /// <param name="inverter">The inverter to calculate expected power for.</param>
    /// <param name="irradiance">The current irradiance in W/m².</param>
    /// <returns>The expected power in kW.</returns>
    Task<double> CalculateExpectedPower(Inverter inverter, double irradiance);

    /// <summary>
    /// Calculates the expected power using the PVWatts model with module temperature correction.
    /// Formula: ExpectedPower = MaxPowerKw * (Irradiance / 1000) * [1 + γ * (ModuleTemperature - 25)]
    /// </summary>
    /// <param name="inverter">The inverter to calculate expected power for.</param>
    /// <param name="irradiance">The current irradiance in W/m².</param>
    /// <param name="moduleTemperature">The module temperature in °C.</param>
    /// <returns>The expected power in kW.</returns>
    Task<double> CalculateExpectedPower(Inverter inverter, double irradiance, double moduleTemperature);
}