using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;
/// <summary>
/// Service for retrieving alerts.
/// </summary>
public class AlertService : IAlertService
{
    private readonly IApplicationDbContext _context;

    public AlertService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AlertDto>> GetAlertsAsync()
    {
        var alerts = await _context.Alerts
            .Include(a => a.Inverter) // To get the inverter's serial number
            .ToListAsync();

        return alerts.Select(a => new AlertDto
        {
            Severity = a.Severity.ToString(),
            Asset = a.Inverter.SerialNumber,
            Problem = a.Problem,
            RootCause = a.RootCause,
            EnergyLossKwh = a.EnergyLossKwh,
            FinancialLossEgp = a.FinancialLoss, // Assuming the financial loss is already in EGP (as per the Currency property)
            RecommendedAction = a.RecommendedAction
        });
    }
}