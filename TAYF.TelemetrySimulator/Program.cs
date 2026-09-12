using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using TAYF.Application.DTOs;

namespace TAYF.TelemetrySimulator;

internal class Program
{
    private static readonly HttpClient _httpClient = new HttpClient();
    private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = false
    };

    private static bool _running = true;
    private static bool _underperformanceMode = false;
    private static readonly Random _random = new Random();
    private static readonly int[] _inverterIds = { 1, 2, 3, 4, 5 }; // 5 inverters as specified
    private static readonly int _plantId = 1; // 1 plant as specified
    private static readonly string _apiUrl = "http://localhost:5134/api/v1/telemetry";

    private static async Task Main(string[] args)
    {
        // Parse command line argument for mode
        if (args.Length > 0)
        {
            var mode = args[0].ToLowerInvariant();
            if (mode == "underperformance")
            {
                _underperformanceMode = true;
            }
            else if (mode == "normal")
            {
                _underperformanceMode = false;
            }
        }

        Console.WriteLine($"TAYF Telemetry Simulator - Started in {(_underperformanceMode ? "UNDERPERFORMANCE" : "NORMAL")} mode");
        Console.WriteLine("========================");
        Console.WriteLine("Press 'U' to toggle Underperformance mode");
        Console.WriteLine("Press 'N' to toggle Normal mode");
        Console.WriteLine("Press 'Q' to quit");
        Console.WriteLine();

        // Start the simulation directly (no thread needed)
        await SimulateTelemetry();

        // Handle user input (if console is available)
        while (_running)
        {
            try
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    switch (key)
                    {
                        case ConsoleKey.U:
                            _underperformanceMode = true;
                            Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}] Switched to UNDERPERFORMANCE mode");
                            break;
                        case ConsoleKey.N:
                            _underperformanceMode = false;
                            Console.WriteLine($"\n[{DateTime.Now:HH:mm:ss}] Switched to NORMAL mode");
                            break;
                        case ConsoleKey.Q:
                            _running = false;
                            Console.WriteLine("\nShutting down...");
                            break;
                    }
                }
            }
            catch (InvalidOperationException)
            {
                // Console is not available (e.g., when running as a background process)
                // Just continue with the simulation
            }
            await Task.Delay(100);
        }
    }

    private static async Task SimulateTelemetry()
    {
        int telemetryCounter = 1000; // Start from 1000 as mentioned in spec

        while (_running)
        {
            try
            {
                // Generate telemetry for each inverter
                foreach (var inverterId in _inverterIds)
                {
                    var telemetryDto = GenerateTelemetryDto(inverterId, telemetryCounter++);

                    // Send to API
                    var response = await _httpClient.PostAsJsonAsync(_apiUrl, telemetryDto, _jsonOptions);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<TelemetryDtoResponse>(_jsonOptions);
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Inverter {inverterId}: Telemetry {result?.TelemetryId} - Received: {result?.Received} - Mode: {(_underperformanceMode ? "UNDERPERFORMANCE" : "NORMAL")}");
                    }
                    else
                    {
                        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Error sending telemetry for inverter {inverterId}: {response.StatusCode}");
                    }
                }

                // Wait before next batch (simulate real-time data every 10 seconds)
                await Task.Delay(10000);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Simulation error: {ex.Message}");
                await Task.Delay(5000); // Wait longer on error
            }
        }
    }

    private static TelemetryDto GenerateTelemetryDto(int inverterId, int telemetryId)
    {
        // Base values for a 100kW inverter
        const double baseIrradiance = 800.0; // W/m2
        const double baseAmbientTemp = 30.0; // Celsius
        const double baseModuleTemp = 42.0; // Celsius
        const long baseTotalYield = 15230; // kWh from example

        // Add some random variation
        var irradiance = baseIrradiance + _random.NextDouble() * 100 - 50; // ±50 W/m2
        if (irradiance < 0) irradiance = 0;
        if (irradiance > 1100) irradiance = 1100;

        var ambientTemp = baseAmbientTemp + _random.NextDouble() * 5 - 2.5; // ±2.5°C
        var moduleTemp = baseModuleTemp + _random.NextDouble() * 5 - 2.5; // ±2.5°C

        // Calculate power based on irradiance (simplified solar panel efficiency)
        var efficiency = 0.85 + (irradiance / 1000) * 0.1; // Efficiency increases with irradiance up to a point
        var dcPower = (irradiance / 1000) * 100 * efficiency; // 100kW rated inverter
        var acPower = dcPower * 0.96; // Inverter efficiency

        // Apply underperformance mode if active
        if (_underperformanceMode)
        {
            // Reduce actual power by 15% as specified
            acPower *= 0.85;
            dcPower *= 0.85;
        }

        // Add some random noise to power values
        acPower += _random.NextDouble() * 5 - 2.5; // ±2.5 kW
        dcPower += _random.NextDouble() * 5 - 2.5; // ±2.5 kW
        if (acPower < 0) acPower = 0;
        if (dcPower < 0) dcPower = 0;

        // Calculate yields (simplified)
        var dailyYield = (int)(acPower * 24); // Simplified daily yield
        var totalYield = baseTotalYield + telemetryId * 100; // Incremental total yield

        return new TelemetryDto
        {
            PlantId = _plantId,
            InverterId = inverterId,
            Timestamp = DateTime.UtcNow.ToString("o"), // ISO 8601 format
            AcPowerKw = Math.Round(acPower, 2),
            DcPowerKw = Math.Round(dcPower, 2),
            Irradiance = Math.Round(irradiance, 1),
            AmbientTemperature = Math.Round(ambientTemp, 1),
            ModuleTemperature = Math.Round(moduleTemp, 1),
            DailyYield = dailyYield,
            TotalYield = totalYield
        };
    }
}

// Response DTO matching what the API returns
public class TelemetryDtoResponse
{
    public int TelemetryId { get; set; }
    public bool Received { get; set; }
}