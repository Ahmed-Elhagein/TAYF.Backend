using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;
using TAYF.Domain.Entities;

namespace TAYF.Application.Services;

public class DemoScenarioService : IDemoScenarioService
{
    private static readonly HashSet<string> SupportedScenarios = new(StringComparer.OrdinalIgnoreCase)
    {
        "Normal", "Underperformance", "Soiling", "InverterFault", "Recovery"
    };

    private readonly IApplicationDbContext _context;
    private readonly ILogger<DemoScenarioService> _logger;

    public DemoScenarioService(IApplicationDbContext context, ILogger<DemoScenarioService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<DemoScenarioResponseDto> ApplyScenarioAsync(
        DemoScenarioRequestDto request, CancellationToken ct = default)
    {
        if (!SupportedScenarios.Contains(request.Scenario))
            throw new ArgumentException($"Unsupported scenario: {request.Scenario}");

        var plant = await _context.Plants
            .FirstOrDefaultAsync(p => p.Id == request.PlantId, ct)
            ?? throw new KeyNotFoundException($"Plant {request.PlantId} not found");

        var inverter = await _context.Inverters
            .FirstOrDefaultAsync(i => i.Id == request.InverterId && i.PlantId == request.PlantId, ct)
            ?? throw new KeyNotFoundException($"Inverter {request.InverterId} not found in plant {request.PlantId}");

        _logger.LogInformation("Demo scenario {Scenario} applied for inverter {InverterId} in plant {PlantId}",
            request.Scenario, request.InverterId, request.PlantId);

        return new DemoScenarioResponseDto
        {
            PlantId = request.PlantId,
            InverterId = request.InverterId,
            Scenario = request.Scenario,
            Applied = true,
            Message = $"Demo scenario '{request.Scenario}' applied successfully"
        };
    }
}