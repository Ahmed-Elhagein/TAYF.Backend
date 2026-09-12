using Microsoft.EntityFrameworkCore;
using TAYF.Application.DTOs;
using TAYF.Domain.Entities;
using TAYF.Application.Interfaces;

namespace TAYF.Application.Services;
/// <summary>
/// Orchestrates the root cause analysis logic.
/// </>
public class RootCauseService : IRootCauseService
{
    private readonly IApplicationDbContext _context;
    private readonly IRootCauseModelClient _modelClient;

    public RootCauseService(IApplicationDbContext context, IRootCauseModelClient modelClient)
    {
        _context = context;
        _modelClient = modelClient;
    }

    /// <summary>
    /// Generates a root cause diagnosis for the given telemetry data.
    /// </summary>
    /// <param name="plantId">The plant identifier.</param>
    /// <param name="inverterId">The inverter identifier.</param>
    /// <param name="timestamp">The timestamp of the telemetry data.</param>
    /// <returns>The root cause diagnosis.</returns>
    public async Task<RootCauseDiagnosisDto> GetRootCauseDiagnosisAsync(int plantId, int inverterId, DateTime timestamp)
    {
        // Validate that the plant and inverter exist and belong together
        var inverterExists = await _context.Inverters
            .AnyAsync(i => i.Id == inverterId && i.PlantId == plantId);

        if (!inverterExists)
        {
            throw new ArgumentException($"Inverter with ID {inverterId} does not exist or does not belong to plant {plantId}");
        }

        // Get the root cause probabilities from the ML model
        var causeProbabilities = await _modelClient.GetRootCauseProbabilitiesAsync(plantId, inverterId, timestamp);

        // Determine the primary cause (highest probability)
        var primaryCause = causeProbabilities
            .OrderByDescending(kvp => kvp.Value)
            .First()
            .Key;

        // Calculate confidence score (how much higher the primary cause is than the second highest)
        var sortedProbabilities = causeProbabilities
            .OrderByDescending(kvp => kvp.Value)
            .ToList();

        double confidenceScore = 0.0;
        if (sortedProbabilities.Count >= 2)
        {
            // Confidence is the difference between top two probabilities
            confidenceScore = sortedProbabilities[0].Value - sortedProbabilities[1].Value;
            // Normalize to 0-1 range (max difference is 1.0)
            confidenceScore = Math.Max(0.0, Math.Min(1.0, confidenceScore * 2)); // Scale up since max diff is 0.5 typically
        }
        else if (sortedProbabilities.Count == 1)
        {
            confidenceScore = sortedProbabilities[0].Value; // Only one cause
        }

        // Generate evidence/explanation
        var evidence = GenerateEvidence(primaryCause, causeProbabilities, timestamp);

        return new RootCauseDiagnosisDto
        {
            PlantId = plantId,
            InverterId = inverterId,
            Timestamp = timestamp.ToString("o"), // ISO 8601 format
            PrimaryCause = primaryCause,
            CauseProbabilities = causeProbabilities,
            ConfidenceScore = Math.Round(confidenceScore, 3),
            Evidence = evidence
        };
    }

    /// <summary>
    /// Generates evidence/explanation for the root cause diagnosis.
    /// </summary>
    private string GenerateEvidence(string primaryCause, Dictionary<string, double> probabilities, DateTime timestamp)
    {
        var sortedProbabilities = probabilities.OrderByDescending(kvp => kvp.Value).ToList();

        string evidence = $"Root cause analysis performed at {timestamp:HH:mm:ss}. ";
        evidence += $"Primary cause identified as '{primaryCause}' with {probabilities[primaryCause]:P0} confidence. ";

        if (sortedProbabilities.Count > 1)
        {
            evidence += $"Secondary cause: '{sortedProbabilities[1].Key}' ({sortedProbabilities[1].Value:P0}). ";
        }

        if (sortedProbabilities.Count > 2)
        {
            evidence += $"Tertiary cause: '{sortedProbabilities[2].Key}' ({sortedProbabilities[2].Value:P0}). ";
        }

        evidence += "Analysis based on PV Fault Dataset patterns and telemetry characteristics.";

        return evidence;
    }
}