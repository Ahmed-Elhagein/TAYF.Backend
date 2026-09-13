using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;
/// <summary>
/// Service for calculating energy loss analysis.
/// </summary>
public class EnergyLossAnalysisService : IEnergyLossAnalysisService
{
    private readonly IApplicationDbContext _context;

    public EnergyLossAnalysisService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<EnergyLossAnalysisDto> GetEnergyLossAnalysisAsync(int plantId, int? inverterId, DateTime from, DateTime to)
    {
        // Ensure from is before to
        if (from > to)
        {
            var temp = from;
            from = to;
            to = temp;
        }

        var query = _context.AnalysisResults
            .Where(r => r.PlantId == plantId
                        && r.Timestamp >= from
                        && r.Timestamp <= to);

        if (inverterId.HasValue)
        {
            query = query.Where(r => r.InverterId == inverterId.Value);
        }

        var results = await query.ToListAsync();

        if (!results.Any())
        {
            return new EnergyLossAnalysisDto
            {
                ExpectedEnergyKwh = 0,
                ActualEnergyKwh = 0,
                EnergyLossKwh = 0,
                PrimaryCause = null
            };
        }

        var expectedEnergyKwh = results.Sum(r => r.ExpectedEnergyKwh);
        var actualEnergyKwh = results.Sum(r => r.ActualEnergyKwh);
        var energyLossKwh = results.Sum(r => r.EnergyLossKwh);

        // Find the record with the highest energy loss to get the primary cause
        var primaryCauseRecord = results.OrderByDescending(r => r.EnergyLossKwh).FirstOrDefault();
        var primaryCause = primaryCauseRecord?.PrimaryCause;

        return new EnergyLossAnalysisDto
        {
            ExpectedEnergyKwh = expectedEnergyKwh,
            ActualEnergyKwh = actualEnergyKwh,
            EnergyLossKwh = energyLossKwh,
            PrimaryCause = primaryCause
        };
    }
}