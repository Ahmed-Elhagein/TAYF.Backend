using System.Net.Http.Json;
using Microsoft.Extensions.Logging;
using TAYF.Application.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TAYF.Infrastructure.Ai;

public class AiRootCauseModelClient : IRootCauseModelClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<AiRootCauseModelClient> _logger;

    public AiRootCauseModelClient(HttpClient httpClient, ILogger<AiRootCauseModelClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<Dictionary<string, double>> GetRootCauseProbabilitiesAsync(int plantId, int inverterId, DateTime timestamp)
    {
        // This method is not supported by the AI endpoint. We return a dummy dictionary.
        _logger.LogWarning("GetRootCauseProbabilitiesAsync is not implemented for AI client. Returning dummy probabilities.");
        return new Dictionary<string, double> { { "Unknown", 1.0 } };
    }

    public async Task<IRootCauseModelClient.RootCausePrediction> PredictFromDatasetAsync(IRootCauseModelClient.PvFaultInput input, CancellationToken ct = default)
    {
        var request = new
        {
            vdc1 = input.Vdc1,
            vdc2 = input.Vdc2,
            idc1 = input.Idc1,
            idc2 = input.Idc2,
            irr = input.Irradiance,
            pvt = input.ModuleTemperature
        };

        _logger.LogInformation("Calling AI: {@Request}", request);

        var response = await _httpClient.PostAsJsonAsync("/predict", request, ct);
        response.EnsureSuccessStatusCode();

        var ai = await response.Content.ReadFromJsonAsync<AiResponse>(ct)
            ?? throw new InvalidOperationException("AI returned null");

        return new IRootCauseModelClient.RootCausePrediction
        {
            TopClass = ai.TopClass,
            Classification = ai.Classification,
            Causes = ai.Diagnosis?.Causes ?? new(),
            Confidence = ai.Diagnosis?.Confidence ?? 0,
            Status = ai.Diagnosis?.Status ?? "",
            PTotal = ai.Computed?.PTotal ?? 0,
            PExpected = ai.Computed?.PExpected ?? 0,
            Deviation = ai.Computed?.Deviation ?? 0
        };
    }

    private class AiResponse
    {
        [JsonPropertyName("top_class")]
        public string TopClass { get; set; } = "";

        [JsonPropertyName("classification")]
        public Dictionary<string, double> Classification { get; set; } = new();

        [JsonPropertyName("diagnosis")]
        public DiagnosisInfo? Diagnosis { get; set; }

        [JsonPropertyName("computed")]
        public ComputedInfo? Computed { get; set; }
    }

    private class DiagnosisInfo
    {
        [JsonPropertyName("causes")]
        public Dictionary<string, double> Causes { get; set; } = new();

        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }

    private class ComputedInfo
    {
        [JsonPropertyName("p_total")]
        public double PTotal { get; set; }

        [JsonPropertyName("p_expected")]
        public double PExpected { get; set; }

        [JsonPropertyName("deviation")]
        public double Deviation { get; set; }
    }
}