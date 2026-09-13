using System;
using System.Threading.Tasks;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.Application.Services;
/// <summary>
/// Service for calculating economic impact analysis.
/// </summary>
public class EconomicImpactService : IEconomicImpactService
{
    private readonly IEnergyLossAnalysisService _energyLossAnalysisService;
    private readonly IFinancialLossAnalysisService _financialLossAnalysisService;

    public EconomicImpactService(
        IEnergyLossAnalysisService energyLossAnalysisService,
        IFinancialLossAnalysisService financialLossAnalysisService)
    {
        _energyLossAnalysisService = energyLossAnalysisService;
        _financialLossAnalysisService = financialLossAnalysisService;
    }

    public async Task<EconomicImpactDto> GetEconomicImpactAsync(
        int plantId,
        DateTime? from,
        DateTime? to,
        string? tariffType)
    {
        // Set default date range: last 30 days to now if not provided
        var now = DateTime.UtcNow;
        var startDate = from ?? now.AddDays(-30);
        var endDate = to ?? now;

        // Ensure from is before to
        if (startDate > endDate)
        {
            var temp = startDate;
            startDate = endDate;
            endDate = temp;
        }

        // Get energy loss for the specified date range
        // Note: We don't have inverterId for economic impact, so we pass null
        var energyLossResult = await _energyLossAnalysisService.GetEnergyLossAnalysisAsync(
            plantId,
            inverterId: null,
            from: startDate,
            to: endDate);

        // Get tariff information (rate and currency)
        var tariffInfo = await _financialLossAnalysisService.GetTariffInfoAsync(
            plantId,
            tariffType);

        // Calculate estimated loss: energy loss (kWh) * tariff rate
        var estimatedLoss = energyLossResult.EnergyLossKwh * tariffInfo.TariffRate;

        return new EconomicImpactDto
        {
            PlantId = plantId,
            From = startDate,
            To = endDate,
            EnergyLossKwh = energyLossResult.EnergyLossKwh,
            TariffRate = tariffInfo.TariffRate,
            Currency = tariffInfo.Currency,
            EstimatedLoss = estimatedLoss
        };
    }
}