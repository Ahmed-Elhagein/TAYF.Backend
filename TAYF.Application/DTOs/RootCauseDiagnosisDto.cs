using System.Collections.Generic;

namespace TAYF.Application.DTOs;

/// <summary>
/// Data Transfer Object for root cause diagnosis response.
/// Matches API 06 contract from the specification.
/// </summary>
public class RootCauseDiagnosisDto
{
    public int PlantId { get; set; }
    public int InverterId { get; set; }
    public string Timestamp { get; set; } = null!;

    /// <summary>
    /// The primary cause (e.g., "Soiling", "Temperature", "ElectricalFault").
    /// </summary>
    public string PrimaryCause { get; set; } = null!;

    /// <summary>
    /// Probabilities for each cause (should sum to approximately 1.0).
    /// Example: { "Soiling": 0.7, "Temperature": 0.2, "ElectricalFault": 0.1 }
    /// </summary>
    public Dictionary<string, double> CauseProbabilities { get; set; } = new Dictionary<string, double>();

    /// <summary>
    /// Confidence score of the diagnosis (0.0 to 1.0).
    /// </summary>
    public double ConfidenceScore { get; set; }

    /// <summary>
    /// Generated evidence or explanation for the diagnosis.
    /// </summary>
    public string Evidence { get; set; } = null!;
}