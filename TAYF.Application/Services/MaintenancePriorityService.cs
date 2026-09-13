using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;
using TAYF.Domain.Enums;

namespace TAYF.Application.Services
{
    /// <summary>
    /// Service for calculating maintenance priority.
    /// </summary>
    public class MaintenancePriorityService : IMaintenancePriorityService
    {
        private readonly IApplicationDbContext _context;

        public MaintenancePriorityService(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MaintenancePriorityDto> GetMaintenancePriorityAsync(int plantId, CancellationToken cancellationToken = default)
        {
            // Get the plant to verify existence and get currency
            var plant = await _context.Plants
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == plantId, cancellationToken);

            if (plant == null)
            {
                throw new ArgumentException($"Plant with ID {plantId} not found.");
            }

            string currency = plant.Currency.ToString();

            // Get alerts for the plant
            var alerts = await _context.Alerts
                .AsNoTracking()
                .Where(a => a.PlantId == plantId)
                .Select(a => new
                {
                    a.InverterId,
                    FinancialLoss = a.FinancialLoss,
                    EnergyLossKwh = a.EnergyLossKwh,
                    Severity = a.Severity
                })
                .ToListAsync(cancellationToken);

            // Get analysis results for the plant
            var analysisResults = await _context.AnalysisResults
                .AsNoTracking()
                .Where(ar => ar.PlantId == plantId)
                .Select(ar => new
                {
                    ar.InverterId,
                    FinancialLoss = ar.EstimatedLoss, // EstimatedLoss is the financial loss
                    EnergyLossKwh = ar.EnergyLossKwh,
                    Severity = ar.Severity
                })
                .ToListAsync(cancellationToken);

            // Get inverters for the plant to get the serial number (Asset)
            var inverters = await _context.Inverters
                .AsNoTracking()
                .Where(i => i.PlantId == plantId)
                .Select(i => new { i.Id, i.SerialNumber })
                .ToListAsync(cancellationToken);

            // Create a dictionary for quick lookup of inverter serial number
            var inverterSerialNumbers = inverters.ToDictionary(i => i.Id, i => i.SerialNumber);

            // Group by InverterId and aggregate
            var inverterGroups = alerts
                .Concat(analysisResults)
                .GroupBy(x => x.InverterId)
                .Select(g => new
                {
                    InverterId = g.Key,
                    FinancialLoss = g.Sum(x => x.FinancialLoss),
                    EnergyLossKwh = g.Sum(x => x.EnergyLossKwh),
                    // Get the highest severity (by enum value)
                    SeverityValue = g.Max(x => (int)x.Severity)
                })
                .ToList();

            // Build the list of maintenance priority items
            var items = new List<MaintenancePriorityItemDto>();

            foreach (var group in inverterGroups)
            {
                // Only include if we have the inverter serial number (should always be present if there are alerts/results)
                if (inverterSerialNumbers.TryGetValue(group.InverterId, out var serialNumber))
                {
                    items.Add(new MaintenancePriorityItemDto
                    {
                        InverterId = group.InverterId,
                        Asset = serialNumber,
                        FinancialLoss = group.FinancialLoss,
                        EnergyLossKwh = group.EnergyLossKwh,
                        Severity = ((Severity)group.SeverityValue).ToString(),
                        Currency = currency
                    });
                }
            }

            // Sort by: FinancialLoss DESC, EnergyLossKwh DESC, Severity DESC (by enum value)
            var sortedItems = items
                .OrderByDescending(item => item.FinancialLoss)
                .ThenByDescending(item => item.EnergyLossKwh)
                .ThenByDescending(item =>
                {
                    // Convert severity string back to enum for sorting
                    if (Enum.TryParse<Severity>(item.Severity, out var severity))
                    {
                        return (int)severity;
                    }
                    return 0; // default to lowest if parse fails
                })
                .ToList();

            // Assign priority starting from 1
            for (int i = 0; i < sortedItems.Count; i++)
            {
                sortedItems[i].Priority = i + 1;
            }

            return new MaintenancePriorityDto
            {
                Assets = sortedItems
            };
        }
    }
}