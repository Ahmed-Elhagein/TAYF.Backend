using Microsoft.EntityFrameworkCore;
using TAYF.Domain.Entities;
using TAYF.Domain.Enums;

namespace TAYF.Infrastructure.Seed;
/// <summary>
/// Seed data for the TAYF solar decision intelligence system
/// </summary>
public static class TayfSeedData
{
    /// <summary>
    /// Seeds the database with initial data
    /// </summary>
    /// <param name="modelBuilder">The model builder</param>
    public static void Seed(ModelBuilder modelBuilder)
    {
        SeedPlants(modelBuilder);
        SeedInverters(modelBuilder);
        SeedTariffs(modelBuilder);
        SeedSampleTelemetry(modelBuilder);
    }

    private static void SeedPlants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>().HasData(
            new Plant
            {
                Id = 1,
                Name = "Solar Plant A - Cairo",
                Location = "Cairo, Egypt",
                CapacityKw = 500, // 500 kW plant
                TariffType = TariffType.NetMetering,
                TariffRate = 1.25m,
                Currency = Currency.EGP,
                InstallationDate = new DateTime(2023, 1, 15),
                IsActive = true
            }
        );
    }

    private static void SeedInverters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inverter>().HasData(
            // 5 Inverters for Plant A (Cairo)
            new Inverter
            {
                Id = 1,
                PlantId = 1,
                SerialNumber = "INV-CAIRO-001",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100,
                InstallationDate = new DateTime(2023, 2, 1),
                IsActive = true
            },
            new Inverter
            {
                Id = 2,
                PlantId = 1,
                SerialNumber = "INV-CAIRO-002",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100,
                InstallationDate = new DateTime(2023, 2, 1),
                IsActive = true
            },
            new Inverter
            {
                Id = 3,
                PlantId = 1,
                SerialNumber = "INV-CAIRO-003",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100,
                InstallationDate = new DateTime(2023, 2, 1),
                IsActive = true
            },
            new Inverter
            {
                Id = 4,
                PlantId = 1,
                SerialNumber = "INV-CAIRO-004",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100,
                InstallationDate = new DateTime(2023, 2, 1),
                IsActive = true
            },
            new Inverter
            {
                Id = 5,
                PlantId = 1,
                SerialNumber = "INV-CAIRO-005",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100,
                InstallationDate = new DateTime(2023, 2, 1),
                IsActive = true
            }
        );
    }

    private static void SeedTariffs(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tariff>().HasData(
            new Tariff
            {
                Id = 1,
                PlantId = 1,
                Type = TariffType.NetMetering,
                Rate = 1.25m,
                Currency = Currency.EGP
            }
        );
    }

    private static void SeedSampleTelemetry(ModelBuilder modelBuilder)
    {
        // Generate some sample telemetry data for the past 7 days for each inverter
        var telemetryList = new List<Telemetry>();
        int telemetryId = 1;

        var startDate = DateTime.UtcNow.AddDays(-7);
        var random = new Random();

        for (int day = 0; day < 7; day++)
        {
            var date = startDate.AddDays(day);
            // Generate 4 readings per day (every 6 hours)
            for (int hour = 0; hour < 24; hour += 6)
            {
                var timestamp = date.AddHours(hour);

                // Plant A inverters (1-5)
                foreach (var inverterId in new[] { 1, 2, 3, 4, 5 })
                {
                    // Simulate solar generation pattern
                    double baseIrradiance = 800; // Base irradiance in W/m2
                    double timeFactor = Math.Sin(Math.PI * (hour - 6) / 12); // Peak at noon
                    if (timeFactor < 0) timeFactor = 0; // No negative irradiance

                    int irradiance = (int)(baseIrradiance * timeFactor + random.Next(-50, 50));
                    if (irradiance < 0) irradiance = 0;
                    if (irradiance > 1100) irradiance = 1100; // Cap at realistic max

                    double tempBase = 30; // Base ambient temperature
                    double tempVariation = 10 * Math.Sin(Math.PI * (hour - 6) / 12); // Temp follows sun
                    double ambientTemp = tempBase + tempVariation + random.Next(-3, 3);
                    double moduleTemp = ambientTemp + (irradiance * 0.025); // Module temp rises with irradiance

                    // Power calculation (simplified)
                    double maxPower = 100; // For 100kW inverter
                    double efficiency = 0.92 - (0.0001 * Math.Max(0, irradiance - 500)); // Slight efficiency drop at high irradiance
                    double dcPower = (irradiance / 1000) * maxPower * efficiency; // DC power from panels
                    double acPower = dcPower * 0.96; // AC power after inversion losses

                    // Add some random variation
                    dcPower += random.NextDouble() * 10 - 5;
                    acPower += random.NextDouble() * 8 - 4;
                    if (dcPower < 0) dcPower = 0;
                    if (acPower < 0) acPower = 0;

                    int dailyYield = (int)(acPower * 6 * 1000); // Wh for 6 hours
                    long totalYield = (long)(telemetryId * 1000); // Simplified cumulative

                    telemetryList.Add(new Telemetry
                    {
                        Id = telemetryId++,
                        PlantId = 1,
                        InverterId = inverterId,
                        Timestamp = timestamp,
                        AcPowerKw = (decimal)Math.Round(acPower, 2),
                        DcPowerKw = (decimal)Math.Round(dcPower, 2),
                        Irradiance = irradiance,
                        AmbientTemperature = (decimal)Math.Round(ambientTemp, 2),
                        ModuleTemperature = (decimal)Math.Round(moduleTemp, 2),
                        DailyYield = dailyYield,
                        TotalYield = totalYield
                    });
                }
            }
        }

        modelBuilder.Entity<Telemetry>().HasData(telemetryList);
    }
}