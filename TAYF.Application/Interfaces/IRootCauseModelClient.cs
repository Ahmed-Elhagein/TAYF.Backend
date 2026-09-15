using TAYF.Application.DTOs;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TAYF.Application.Interfaces;

/// <summary>
/// Bridge/contract to the external Python ML API for root cause analysis.
/// </summary>
public interface IRootCauseModelClient
{
    /// <summary>
    /// Gets the root cause probabilities from the ML model.
    /// </summary>
    /// <param name="plantId">The plant identifier.</param>
    /// <param name="inverterId">The inverter identifier.</param>
    /// <param name="timestamp">The timestamp of the telemetry data.</param>
    /// <returns>A dictionary of cause probabilities.</returns>
    Task<Dictionary<string, double>> GetRootCauseProbabilitiesAsync(int plantId, int inverterId, DateTime timestamp);

    /// <summary>
    /// Input record for the PV Fault Dataset prediction.
    /// </summary>
    public record PvFaultInput(
        double Vdc1,
        double Vdc2,
        double Idc1,
        double Idc2,
        double Irradiance,
        double ModuleTemperature);

    /// <summary>
    /// Prediction result from the AI model.
    /// </summary>
    public record RootCausePrediction
    {
        public string TopClass { get; init; } = "";
        public Dictionary<string, double> Classification { get; init; } = new();
        public Dictionary<string, double> Causes { get; init; } = new();
        public double Confidence { get; init; }
        public string Status { get; init; } = "";
        public double PTotal { get; init; }
        public double PExpected { get; init; }
        public double Deviation { get; init; }
    }

    /// <summary>
    /// Predicts root cause from the PV Fault Dataset record.
    /// </summary>
    /// <param name="input">The input parameters from the dataset.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The root cause prediction.</returns>
    Task<RootCausePrediction> PredictFromDatasetAsync(PvFaultInput input, CancellationToken ct = default);
}