using Microsoft.EntityFrameworkCore;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;
/// <summary>
/// Creates Expected Power using the PVWatts model:
/// ExpectedPower = MaxPowerKw * (Irradiance / 1000) * [1 + γ * (ModuleTemperature - 25)]
/// </summary>
public class BaselineExpectedPowerService : IExpectedPowerService
{
    private readonly IApplicationDbContext _context;

    // Temperature coefficient for standard silicon panels (%/°C converted to decimal)
    // Typical value for silicon is -0.004 /°C (-0.4%/°C)
    private const double TemperatureCoefficientGamma = -0.004;

    public BaselineExpectedPowerService(IApplicationDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Calculates the expected power based on irradiance, module temperature, and inverter specifications.
    /// Uses the PVWatts model: ExpectedPower = MaxPowerKw * (Irradiance / 1000) * [1 + γ * (ModuleTemperature - 25)]
    /// </summary>
    /// <param name="inverter">The inverter to calculate expected power for.</param>
    /// <param name="irradiance">The current irradiance in W/m².</param>
    /// <param name="moduleTemperature">The module temperature in °C. If unavailable, ambient temperature can be used as fallback.</param>
    /// <returns>The expected power in kW.</returns>
    public Task<double> CalculateExpectedPower(Inverter inverter, double irradiance, double moduleTemperature)
    {
        // Use the inverter's MaxPowerKw as the rated power at STC
        double ratedPowerKw = (double)inverter.MaxPowerKw;

        // Handle edge case: if rated power is invalid, return 0
        if (ratedPowerKw <= 0)
        {
            return Task.FromResult(0.0);
        }

        // Handle edge case: if irradiance is negative or zero, expected power is zero
        if (irradiance <= 0)
        {
            return Task.FromResult(0.0);
        }

        // PVWatts formula: ExpectedPower = MaxPowerKw * (Irradiance / 1000) * [1 + γ * (ModuleTemperature - 25)]
        double temperatureCorrection = 1.0 + (TemperatureCoefficientGamma * (moduleTemperature - 25.0));
        double expectedPower = ratedPowerKw * (irradiance / 1000.0) * temperatureCorrection;

        // Ensure expected power is not negative (though it shouldn't be with normal parameters)
        expectedPower = Math.Max(0, expectedPower);

        return Task.FromResult(expectedPower);
    }

    /// <summary>
    /// Calculates the expected power based on irradiance and inverter specifications.
    /// This overload maintains backward compatibility with the existing interface.
    /// Estimates module temperature from ambient temperature if needed.
    /// </summary>
    /// <param name="inverter">The inverter to calculate expected power for.</param>
    /// <param name="irradiance">The current irradiance in W/m².</param>
    /// <returns>The expected power in kW.</returns>
    public Task<double> CalculateExpectedPower(Inverter inverter, double irradiance)
    {
        // For backward compatibility, we need to estimate module temperature
        // Since we don't have access to ambient temperature here, we'll use a simplified approach
        // In a real implementation, we might need to modify the interface or retrieve ambient temp from DB

        // Use a default module temperature estimate (this is a limitation of the current interface)
        // A better approach would be to update the interface, but we're instructed to keep it intact
        double estimatedModuleTemperature = 25.0; // Default to STC conditions

        // Delegate to the main implementation
        return CalculateExpectedPower(inverter, irradiance, estimatedModuleTemperature);
    }
}