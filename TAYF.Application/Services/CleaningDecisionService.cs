using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services
{
    public class CleaningDecisionService : ICleaningDecisionService
    {
        private readonly IApplicationDbContext _context;

        public CleaningDecisionService(IApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CleaningDecisionResponseDto> GetCleaningDecisionAsync(
            CleaningDecisionRequestDto request,
            CancellationToken ct = default)
        {
            // Validate plant exists
            var plant = await _context.Plants
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.PlantId, ct);

            if (plant == null)
            {
                throw new KeyNotFoundException($"Plant with Id {request.PlantId} not found.");
            }

            // If inverterId provided, validate it belongs to the plant
            if (request.InverterId.HasValue)
            {
                var inverter = await _context.Inverters
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id == request.InverterId.Value && i.PlantId == request.PlantId, ct);

                if (inverter == null)
                {
                    throw new KeyNotFoundException($"Inverter with Id {request.InverterId.Value} not found for plant {request.PlantId}.");
                }
            }

            // Get the latest soiling analysis result for the target (plant or inverter)
            // We'll look for AnalysisResult where PrimaryCause contains "soiling" (case-insensitive)
            // and that matches the plant and optionally the inverter.
            IQueryable<AnalysisResult> query = _context.AnalysisResults
                .AsNoTracking()
                .Where(a => a.PlantId == request.PlantId &&
                            a.PrimaryCause.ToLower().Contains("soiling"));

            if (request.InverterId.HasValue)
            {
                query = query.Where(a => a.InverterId == request.InverterId.Value);
            }

            var latestSoiling = await query
                .OrderByDescending(a => a.Timestamp)
                .FirstOrDefaultAsync(ct);

            if (latestSoiling == null)
            {
                throw new InvalidOperationException("No soiling analysis found for the specified plant and inverter.");
            }

            // Expected recovery in kWh is the energy loss from the soiling analysis
            decimal expectedRecoveryKwh = latestSoiling.EnergyLossKwh;

            // Get the tariff rate and currency from the plant
            decimal tariffRate = plant.TariffRate;
            string currency = plant.Currency.ToString();

            // Expected recovery value
            decimal expectedRecoveryValue = expectedRecoveryKwh * (decimal)tariffRate;

            // Net benefit
            decimal netBenefit = expectedRecoveryValue - request.CleaningCost;

            // Recommendation
            string recommendation = netBenefit > 0 ? "CleanNow" : "Wait";

            return new CleaningDecisionResponseDto
            {
                ExpectedRecoveryKwh = expectedRecoveryKwh,
                ExpectedRecoveryValue = expectedRecoveryValue,
                CleaningCost = request.CleaningCost,
                NetBenefit = netBenefit,
                Currency = currency,
                Recommendation = recommendation
            };
        }
    }
}