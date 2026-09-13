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
        SeedMaintenanceActions(modelBuilder);
        SeedRepairVerifications(modelBuilder);
        SeedAnalysisResults(modelBuilder);
        SeedAlerts(modelBuilder);
    }

    private static void SeedPlants(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>().HasData(
            new Plant
            {
                Id = 1,
                Name = "Solar Plant A - Cairo",
                Location = "Cairo, Egypt",
                CapacityKw = 500m,
                TariffType = TAYF.Domain.Enums.TariffType.NetMetering,
                TariffRate = 1.25m,
                Currency = TAYF.Domain.Enums.Currency.EGP,
                InstallationDate = new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                IsActive = true
            }
        );
    }

    private static void SeedInverters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inverter>().HasData(
            new Inverter
            {
                Id = 1,
                SerialNumber = "INV-CAIRO-001",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100m,
                InstallationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                IsActive = true,
                PlantId = 1
            },
            new Inverter
            {
                Id = 2,
                SerialNumber = "INV-CAIRO-002",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100m,
                InstallationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                IsActive = true,
                PlantId = 1
            },
            new Inverter
            {
                Id = 3,
                SerialNumber = "INV-CAIRO-003",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100m,
                InstallationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                IsActive = true,
                PlantId = 1
            },
            new Inverter
            {
                Id = 4,
                SerialNumber = "INV-CAIRO-004",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100m,
                InstallationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                IsActive = true,
                PlantId = 1
            },
            new Inverter
            {
                Id = 5,
                SerialNumber = "INV-CAIRO-005",
                Model = "SUN2000-100KTL",
                MaxPowerKw = 100m,
                InstallationDate = new DateTime(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                IsActive = true,
                PlantId = 1
            });
    }

    private static void SeedTariffs(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tariff>().HasData(
            new Tariff
            {
                Id = 1,
                Rate = 1.25m,
                Type = TAYF.Domain.Enums.TariffType.NetMetering,
                Currency = TAYF.Domain.Enums.Currency.EGP,
                PlantId = 1
            });
    }

    private static void SeedSampleTelemetry(ModelBuilder modelBuilder)
    {
        {
            // Preserve existing 5 records exactly as-is
            var existing = new List<Telemetry>
            {
                new Telemetry
                {
                    Id = 1,
                    DcPowerKw = 0m,
                    AcPowerKw = 0.03m,
                    DailyYield = 164,
                    TotalYield = 1000L,
                    AmbientTemperature = 22m,
                    ModuleTemperature = 22m,
                    Irradiance = 0,
                    Timestamp = new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110),
                    InverterId = 1,
                    PlantId = 1
                },
                new Telemetry
                {
                    Id = 2,
                    DcPowerKw = 0m,
                    AcPowerKw = 0.1m,
                    DailyYield = 624,
                    TotalYield = 2000L,
                    AmbientTemperature = 21m,
                    ModuleTemperature = 22.22m,
                    Irradiance = 49,
                    Timestamp = new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110),
                    InverterId = 2,
                    PlantId = 1
                },
                new Telemetry
                {
                    Id = 3,
                    DcPowerKw = 0m,
                    AcPowerKw = 2.85m,
                    DailyYield = 17098,
                    TotalYield = 3000L,
                    AmbientTemperature = 19m,
                    ModuleTemperature = 19m,
                    Irradiance = 0,
                    Timestamp = new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110),
                    InverterId = 3,
                    PlantId = 1
                },
                new Telemetry
                {
                    Id = 4,
                    DcPowerKw = 1.62m,
                    AcPowerKw = 0m,
                    DailyYield = 0,
                    TotalYield = 4000L,
                    AmbientTemperature = 21m,
                    ModuleTemperature = 21m,
                    Irradiance = 0,
                    Timestamp = new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110),
                    InverterId = 4,
                    PlantId = 1
                },
                new Telemetry
                {
                    Id = 5,
                    DcPowerKw = 0m,
                    AcPowerKw = 2.95m,
                    DailyYield = 17687,
                    TotalYield = 5000L,
                    AmbientTemperature = 17m,
                    ModuleTemperature = 17m,
                    Irradiance = 0,
                    Timestamp = new DateTime(2026, 9, 4, 19, 19, 35, 646, DateTimeKind.Utc).AddTicks(6110),
                    InverterId = 5,
                    PlantId = 1
                }
            };

            // Generate 140 more records (IDs 6-145): 7 days x 4 slots x 5 inverters
            var generated = new List<Telemetry>();
            var startDate = new DateTime(2026, 8, 28, 0, 0, 0, DateTimeKind.Utc);
            int id = 6;

            for (int day = 0; day < 7; day++)
            {
                for (int slot = 0; slot < 4; slot++)
                {
                    int hour = 6 + (slot * 3);   // 6h, 9h, 12h, 15h
                    var ts = startDate.AddDays(day).AddHours(hour);

                    for (int inv = 1; inv <= 5; inv++)
                    {
                        int irradiance = slot switch
                        {
                            0 => 200 + (inv * 10),
                            1 => 600 + (inv * 15),
                            2 => 850 + (inv * 5),
                            _ => 500 + (inv * 20)
                        };

                        decimal acPower = (irradiance / 100m) * 5m;
                        decimal dcPower = acPower * 1.05m;
                        decimal ambientTemp = 20m + (slot * 3m) + (inv % 2);
                        decimal moduleTemp = ambientTemp + (irradiance / 100m);

                        generated.Add(new Telemetry
                        {
                            Id = id++,
                            PlantId = 1,
                            InverterId = inv,
                            Timestamp = ts,
                            AcPowerKw = Math.Round(acPower, 2),
                            DcPowerKw = Math.Round(dcPower, 2),
                            Irradiance = irradiance,
                            AmbientTemperature = Math.Round(ambientTemp, 2),
                            ModuleTemperature = Math.Round(moduleTemp, 2),
                            DailyYield = (int)(acPower * 10),
                            TotalYield = (day * 5L + inv) * 5000L
                        });
                    }
                }
            }

            var all = new List<Telemetry>(existing);
            all.AddRange(generated);

            modelBuilder.Entity<Telemetry>().HasData(all);
        }
        }

        private static void SeedMaintenanceActions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaintenanceAction>().HasData(
                new MaintenanceAction
                {
                    Id = 1,
                    PlantId = 1,
                    InverterId = 1,
                    ActionType = ActionType.Repair,
                    StartedAt = new DateTime(2026, 8, 25, 10, 0, 0, DateTimeKind.Utc),
                    CompletedAt = new DateTime(2026, 8, 27, 14, 30, 0, DateTimeKind.Utc),
                    Description = "Inverter 1 repair - underperformance fix"
                },
                new MaintenanceAction
                {
                    Id = 2,
                    PlantId = 1,
                    InverterId = 2,
                    ActionType = ActionType.Inspection,
                    StartedAt = new DateTime(2026, 8, 28, 9, 0, 0, DateTimeKind.Utc),
                    CompletedAt = null,
                    Description = "Inverter 2 scheduled inspection"
                },
                new MaintenanceAction
                {
                    Id = 3,
                    PlantId = 1,
                    InverterId = 3,
                    ActionType = ActionType.Cleaning,
                    StartedAt = new DateTime(2026, 9, 1, 7, 0, 0, DateTimeKind.Utc),
                    CompletedAt = new DateTime(2026, 9, 1, 11, 30, 0, DateTimeKind.Utc),
                    Description = "Panel cleaning - inverter 3"
                }
            );
        }

        private static void SeedRepairVerifications(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepairVerification>().HasData(
                new RepairVerification
                {
                    Id = 1,
                    MaintenanceActionId = 1,
                    PerformanceBefore = 2800m,
                    PerformanceAfter = 4300m,
                    ExpectedPowerKw = 4500m,
                    RecoveryPct = 88.24m,
                    IsStable = true,
                    Verified = false,
                    VerifiedAt = new DateTime(2026, 8, 28, 10, 0, 0, DateTimeKind.Utc)
                }
            );
        }

        private static void SeedAnalysisResults(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnalysisResult>().HasData(
                new AnalysisResult
                {
                    Id = 1,
                    PlantId = 1,
                    InverterId = 1,
                    Timestamp = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc),
                    ActualPowerKw = 82m,
                    ExpectedPowerKw = 85m,
                    DeviationPct = -3.5m,
                    IsAnomaly = false,
                    Severity = Severity.Low,
                    AnomalyScore = 0.15m,
                    PrimaryCause = "Normal",
                    CauseProbabilities = "{}",
                    ConfidenceScore = 0.9m,
                    EnergyLossKwh = 12m,
                    ExpectedEnergyKwh = 300m,
                    ActualEnergyKwh = 288m,
                    EstimatedLoss = 156m,
                    Currency = Currency.EGP,
                    CreatedAt = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new AnalysisResult
                {
                    Id = 2,
                    PlantId = 1,
                    InverterId = 2,
                    Timestamp = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc),
                    ActualPowerKw = 75m,
                    ExpectedPowerKw = 85m,
                    DeviationPct = -11.8m,
                    IsAnomaly = true,
                    Severity = Severity.Medium,
                    AnomalyScore = 0.65m,
                    PrimaryCause = "Soiling",
                    CauseProbabilities = "{\"Soiling\":0.7,\"Shading\":0.2,\"Degradation\":0.1}",
                    ConfidenceScore = 0.8m,
                    EnergyLossKwh = 28m,
                    ExpectedEnergyKwh = 300m,
                    ActualEnergyKwh = 272m,
                    EstimatedLoss = 364m,
                    Currency = Currency.EGP,
                    CreatedAt = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new AnalysisResult
                {
                    Id = 3,
                    PlantId = 1,
                    InverterId = 3,
                    Timestamp = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc),
                    ActualPowerKw = 68m,
                    ExpectedPowerKw = 85m,
                    DeviationPct = -20.0m,
                    IsAnomaly = true,
                    Severity = Severity.High,
                    AnomalyScore = 0.85m,
                    PrimaryCause = "Electrical Issue",
                    CauseProbabilities = "{\"Electrical Issue\":0.8,\"Shading\":0.15,\"Connection\":0.05}",
                    ConfidenceScore = 0.75m,
                    EnergyLossKwh = 42m,
                    ExpectedEnergyKwh = 300m,
                    ActualEnergyKwh = 258m,
                    EstimatedLoss = 546m,
                    Currency = Currency.EGP,
                    CreatedAt = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new AnalysisResult
                {
                    Id = 4,
                    PlantId = 1,
                    InverterId = 4,
                    Timestamp = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc),
                    ActualPowerKw = 60m,
                    ExpectedPowerKw = 80m,
                    DeviationPct = -25.0m,
                    IsAnomaly = true,
                    Severity = Severity.Critical,
                    AnomalyScore = 0.92m,
                    PrimaryCause = "Inverter Fault",
                    CauseProbabilities = "{\"Inverter Fault\":0.85,\"Wiring\":0.1,\"Other\":0.05}",
                    ConfidenceScore = 0.88m,
                    EnergyLossKwh = 50m,
                    ExpectedEnergyKwh = 320m,
                    ActualEnergyKwh = 270m,
                    EstimatedLoss = 650m,
                    Currency = Currency.EGP,
                    CreatedAt = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc)
                },
                new AnalysisResult
                {
                    Id = 5,
                    PlantId = 1,
                    InverterId = 5,
                    Timestamp = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc),
                    ActualPowerKw = 88m,
                    ExpectedPowerKw = 90m,
                    DeviationPct = -2.2m,
                    IsAnomaly = false,
                    Severity = Severity.Low,
                    AnomalyScore = 0.12m,
                    PrimaryCause = "Normal",
                    CauseProbabilities = "{}",
                    ConfidenceScore = 0.92m,
                    EnergyLossKwh = 8m,
                    ExpectedEnergyKwh = 320m,
                    ActualEnergyKwh = 312m,
                    EstimatedLoss = 104m,
                    Currency = Currency.EGP,
                    CreatedAt = new DateTime(2026, 9, 1, 12, 0, 0, DateTimeKind.Utc)
                }
            );
        }

        private static void SeedAlerts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alert>().HasData(
                new Alert
                {
                    Id = 1,
                    PlantId = 1,
                    InverterId = 2,
                    Severity = Severity.Medium,
                    Problem = "Underperformance detected",
                    RootCause = "Soiling",
                    EnergyLossKwh = 320m,
                    FinancialLoss = 4160m,
                    Currency = Currency.EGP,
                    RecommendedAction = "Schedule cleaning",
                    CreatedAt = new DateTime(2026, 9, 2, 8, 0, 0, DateTimeKind.Utc),
                    IsResolved = false
                },
                new Alert
                {
                    Id = 2,
                    PlantId = 1,
                    InverterId = 3,
                    Severity = Severity.High,
                    Problem = "Significant underperformance",
                    RootCause = "Electrical issue detected",
                    EnergyLossKwh = 480m,
                    FinancialLoss = 6240m,
                    Currency = Currency.EGP,
                    RecommendedAction = "Inspect wiring and connections",
                    CreatedAt = new DateTime(2026, 9, 2, 9, 0, 0, DateTimeKind.Utc),
                    IsResolved = false
                },
                new Alert
                {
                    Id = 3,
                    PlantId = 1,
                    InverterId = 4,
                    Severity = Severity.Critical,
                    Problem = "Critical inverter fault",
                    RootCause = "Inverter failure imminent",
                    EnergyLossKwh = 640m,
                    FinancialLoss = 8320m,
                    Currency = Currency.EGP,
                    RecommendedAction = "Replace inverter immediately",
                    CreatedAt = new DateTime(2026, 9, 2, 10, 0, 0, DateTimeKind.Utc),
                    IsResolved = false
                }
            );
        }
    }