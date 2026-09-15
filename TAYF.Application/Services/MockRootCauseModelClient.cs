using System.Collections.Generic;
using System.Threading.Tasks;
using TAYF.Application.Interfaces;

namespace TAYF.Application.Services;

/// <summary>
/// Mock implementation of the root cause model client.
/// Returns simulated probabilities matching the API 06 contract.
/// </summary>
public class MockRootCauseModelClient : IRootCauseModelClient
{
    /// <summary>
    /// Gets the root cause probabilities from the ML model.
    /// For demonstration, returns varying probabilities based on the timestamp.
    /// In a real implementation, this would call an external Python ML API.
    /// </summary>
    /// <param name="plantId">The plant identifier.</param>
    /// <param name="inverterId">The inverter identifier.</param>
    /// <param name="timestamp">The timestamp of the telemetry data.</param>
    /// <returns>A dictionary of cause probabilities.</returns>
    public Task<Dictionary<string, double>> GetRootCauseProbabilitiesAsync(int plantId, int inverterId, DateTime timestamp)
    {
        // Use the timestamp to generate deterministic but varying probabilities
        // This simulates different root causes being detected at different times
        int seed = timestamp.GetHashCode();
        var random = new Random(seed);

        // Define the possible root causes from the PV Fault Dataset context
        var causes = new List<string> { "Soiling", "Temperature", "ElectricalFault" };

        // Generate random probabilities that sum to 1.0
        double soiling = random.NextDouble() * 0.6 + 0.2; // 0.2 to 0.8
        double temperature = random.NextDouble() * (0.8 - soiling) + 0.1; // Remaining range
        double electricalFault = 1.0 - soiling - temperature; // Ensure sum = 1.0

        // Adjust ranges to make some causes more likely at times
        double timeFactor = (timestamp.Second / 60.0); // 0.0 to 1.0 based on second of minute

        // Modify probabilities based on time to simulate different conditions
        if (timeFactor < 0.3)
        {
            // First 20 seconds: favor Soiling
            soiling = 0.6 + random.NextDouble() * 0.3; // 0.6 to 0.9
            temperature = 0.2 + random.NextDouble() * 0.2; // 0.2 to 0.4
            electricalFault = 1.0 - soiling - temperature;
        }
        else if (timeFactor < 0.6)
        {
            // Middle 20 seconds: favor Temperature
            soiling = 0.1 + random.NextDouble() * 0.2; // 0.1 to 0.3
            temperature = 0.6 + random.NextDouble() * 0.3; // 0.6 to 0.9
            electricalFault = 1.0 - soiling - temperature;
        }
        else
        {
            // Last 20 seconds: favor ElectricalFault
            soiling = 0.1 + random.NextDouble() * 0.2; // 0.1 to 0.3
            temperature = 0.2 + random.NextDouble() * 0.2; // 0.2 to 0.4
            electricalFault = 0.5 + random.NextDouble() * 0.4; // 0.5 to 0.9
            // Renormalize
            double totalSum = soiling + temperature + electricalFault;
            soiling /= totalSum;
            temperature /= totalSum;
            electricalFault /= totalSum;
        }

        // Ensure no negative values and proper normalization
        soiling = Math.Max(0.0, Math.Min(1.0, soiling));
        temperature = Math.Max(0.0, Math.Min(1.0, temperature));
        electricalFault = Math.Max(0.0, Math.Min(1.0, electricalFault));

        double totalSum2 = soiling + temperature + electricalFault;
        if (totalSum2 > 0)
        {
            soiling /= totalSum2;
            temperature /= totalSum2;
            electricalFault /= totalSum2;
        }

        var probabilities = new Dictionary<string, double>
        {
            ["Soiling"] = Math.Round(soiling, 3),
            ["Temperature"] = Math.Round(temperature, 3),
            ["ElectricalFault"] = Math.Round(electricalFault, 3)
        };

        return Task.FromResult(probabilities);
    }

    public Task<IRootCauseModelClient.RootCausePrediction> PredictFromDatasetAsync(
        IRootCauseModelClient.PvFaultInput input,
        CancellationToken ct = default)
    {
        // Mock response — deterministic based on input
        var hasFault = input.Vdc1 < 100 || input.Vdc2 < 100
                    || input.Idc1 < 1 || input.Idc2 < 1;

        if (hasFault)
        {
            return Task.FromResult(new IRootCauseModelClient.RootCausePrediction
            {
                TopClass = "Open Circuit",
                Classification = new Dictionary<string, double>
                {
                    { "Normal", 5.0 },
                    { "Short-Circuit", 10.0 },
                    { "Degradation", 5.0 },
                    { "Open Circuit", 75.0 },
                    { "Shadowing", 5.0 }
                },
                Causes = new Dictionary<string, double>
                {
                    { "Soiling", 5.0 },
                    { "Module Temperature", 10.0 },
                    { "String/MC4 Fault", 80.0 },
                    { "Inverter Thermal Derating", 5.0 }
                },
                Confidence = 75.0,
                Status = "Open Circuit Detected",
                PTotal = (input.Vdc1 + input.Vdc2) * (input.Idc1 + input.Idc2) / 2,
                PExpected = 4000,
                Deviation = -0.5
            });
        }

        return Task.FromResult(new IRootCauseModelClient.RootCausePrediction
        {
            TopClass = "Normal",
            Classification = new Dictionary<string, double>
            {
                { "Normal", 95.67 },
                { "Short-Circuit", 0.0 },
                { "Degradation", 0.0 },
                { "Open Circuit", 0.0 },
                { "Shadowing", 4.33 }
            },
            Causes = new Dictionary<string, double>
            {
                { "Soiling", 8.0 },
                { "Module Temperature", 49.7 },
                { "String/MC4 Fault", 0.0 },
                { "Inverter Thermal Derating", 42.3 }
            },
            Confidence = 95.7,
            Status = "Normal Operation",
            PTotal = 6069.83,
            PExpected = 4095.61,
            Deviation = 0.482
        });
    }
}