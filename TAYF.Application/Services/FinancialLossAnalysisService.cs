using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;
/// <summary>
/// Service for calculating financial loss analysis.
/// </summary>
public class FinancialLossAnalysisService : IFinancialLossAnalysisService
{
    private readonly IApplicationDbContext _context;

    public FinancialLossAnalysisService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<FinancialLossAnalysisDto> GetFinancialLossAnalysisAsync(int plantId, string tariffType)
    {
        // Get the plant with its tariffs
        var plant = await _context.Plants
            .Include(p => p.Tariffs)
            .FirstOrDefaultAsync(p => p.Id == plantId);

        if (plant == null)
        {
            throw new ArgumentException($"Plant with ID {plantId} not found.");
        }

        if (!plant.Tariffs.Any())
        {
            throw new InvalidOperationException($"Plant with ID {plantId} has no tariffs defined.");
        }

        // Use the first tariff (assuming one tariff per plant)
        var tariff = plant.Tariffs.First();

        // Calculate total energy loss for the plant (all time)
        var totalEnergyLossKwh = await _context.AnalysisResults
            .Where(r => r.PlantId == plantId)
            .SumAsync(r => (double?)r.EnergyLossKwh) ?? 0;

        // Calculate estimated loss: energy loss (kWh) * tariff rate
        var estimatedLoss = (decimal)totalEnergyLossKwh * tariff.Rate;

        return new FinancialLossAnalysisDto
        {
            EnergyLossKwh = (decimal)totalEnergyLossKwh,
            TariffType = tariffType, // Return the provided tariff type
            TariffRate = tariff.Rate,
            Currency = tariff.Currency.ToString(),
            EstimatedLoss = estimatedLoss
        };
    }

    public async Task<TariffInfoDto> GetTariffInfoAsync(int plantId, string? tariffType)
    {
        // Get the plant with its tariffs
        var plant = await _context.Plants
            .Include(p => p.Tariffs)
            .FirstOrDefaultAsync(p => p.Id == plantId);

        if (plant == null)
        {
            throw new ArgumentException($"Plant with ID {plantId} not found.");
        }

        if (!plant.Tariffs.Any())
        {
            throw new InvalidOperationException($"Plant with ID {plantId} has no tariffs defined.");
        }

        // Use the first tariff (assuming one tariff per plant)
        var tariff = plant.Tariffs.First();

        // If a tariff type is provided, we would normally look for a matching tariff.
        // However, the current model assumes one tariff per plant, so we ignore the override for simplicity.
        // In a more complex scenario, we would filter by tariff type.

        return new TariffInfoDto
        {
            TariffRate = tariff.Rate,
            Currency = tariff.Currency.ToString()
        };
    }
}