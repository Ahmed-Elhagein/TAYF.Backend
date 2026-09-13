# TAYF.Backend Inventory and Gap Analysis Report

## 1. 📁 DTOs Found
| File | Properties |
|------|------------|
| TAYF.Application/DTOs/TelemetryDto.cs | PlantId (int), InverterId (int), Timestamp (string), AcPowerKw (double), DcPowerKw (double), Irradiance (double), AmbientTemperature (double), ModuleTemperature (double), DailyYield (int), TotalYield (long) |
| TAYF.Application/DTOs/RootCauseDiagnosisDto.cs | PlantId (int), InverterId (int), Timestamp (string), PrimaryCause (string), CauseProbabilities (Dictionary<string, double>), ConfidenceScore (double), Evidence (string) |
| TAYF.Application/DTOs/AlertDto.cs | Severity (string), Asset (string), Problem (string), RootCause (string), EnergyLossKwh (decimal), FinancialLossEgp (decimal), RecommendedAction (string) |
| TAYF.Application/DTOs/EnergyLossAnalysisDto.cs | ExpectedEnergyKwh (decimal), ActualEnergyKwh (decimal), EnergyLossKwh (decimal), PrimaryCause (string?) |
| TAYF.Application/DTOs/FinancialLossAnalysisDto.cs | EnergyLossKwh (decimal), TariffType (string), TariffRate (decimal), Currency (string), EstimatedLoss (decimal) |
| TAYF.Application/DTOs/InverterDto.cs | Id (int), PlantId (int), SerialNumber (string), Model (string), MaxPowerKw (decimal), InstallationDate (DateTime), IsActive (bool), Plant (PlantDto?), TelemetryRecords (ICollection<object>) |
| TAYF.Application/DTOs/PlantDto.cs | Id (int), Name (string), Location (string), CapacityKw (decimal), TariffType (TariffType), TariffRate (decimal), Currency (Currency), InstallationDate (DateTime), IsActive (bool), Inverters (ICollection<InverterDto>) |

## 2. 🔌 Interfaces Found
| File | Methods |
|------|---------|
| TAYF.Application/Interfaces/ITelemetryService.cs | Task<TelemetryDtoResponse> IngestTelemetry(TelemetryDto telemetryDto) |
| TAYF.Application/Interfaces/IAnomalyDetectionService.cs | bool IsAnomaly(double actualPowerKw, double expectedPowerKw); double CalculateDeviationPct(double actualPowerKw, double expectedPowerKw) |
| TAYF.Application/Interfaces/IPlantStatusService.cs | Task<PlantStatusDto> GetPlantStatusAsync(int plantId) |
| TAYF.Application/Interfaces/IRootCauseModelClient.cs | Task<Dictionary<string, double>> GetRootCauseProbabilitiesAsync(int plantId, int inverterId, DateTime timestamp) |
| TAYF.Application/Interfaces/IRootCauseService.cs | Task<RootCauseDiagnosisDto> GetRootCauseDiagnosisAsync(int plantId, int inverterId, DateTime timestamp) |
| TAYF.Application/Interfaces/IExpectedPowerService.cs | Task<double> CalculateExpectedPower(Inverter inverter, double irradiance); Task<double> CalculateExpectedPower(Inverter inverter, double irradiance, double moduleTemperature) |
| TAYF.Application/Interfaces/IAlertService.cs | Task<IEnumerable<AlertDto>> GetAlertsAsync() |
| TAYF.Application/Interfaces/IEnergyLossAnalysisService.cs | Task<EnergyLossAnalysisDto> GetEnergyLossAnalysisAsync(int plantId, int? inverterId, DateTime from, DateTime to) |
| TAYF.Application/Interfaces/IFinancialLossAnalysisService.cs | Task<FinancialLossAnalysisDto> GetFinancialLossAnalysisAsync(int plantId, string tariffType) |
| TAYF.Application/Interfaces/IApplicationDbContext.cs | DbSet<Plant> Plants; DbSet<Inverter> Inverters; DbSet<Telemetry> TelemetryRecords; DbSet<AnalysisResult> AnalysisResults; DbSet<Tariff> Tariffs; DbSet<Alert> Alerts; DbSet<MaintenanceAction> MaintenanceActions; DbSet<RepairVerification> RepairVerifications; DbSet<TelemetryProcessingCheckpoint> TelemetryProcessingCheckpoints; Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) |

## 3. ⚙️ Services Found
| File | Purpose |
|------|---------|
| TAYF.Application/Services/AnomalyDetectionService.cs | Detects anomalies in telemetry data by comparing actual vs expected power and calculating deviation percentage. |
| TAYF.Application/Services/MockRootCauseModelClient.cs | Mock implementation of IRootCauseModelClient for testing or fallback. |
| TAYF.Application/Services/AlertService.cs | Retrieves alerts from the database. |
| TAYF.Application/Services/EnergyLossAnalysisService.cs | Calculates energy loss analysis for a plant/inverter over a time range. |
| TAYF.Application/Services/FinancialLossAnalysisService.cs | Calculates financial loss based on energy loss and tariff data. |
| TAYF.Application/Services/PlantStatusService.cs | Retrieves plant status including expected vs actual power, anomalies, etc. |
| TAYF.Application/Services/RootCauseService.cs | Uses IRootCauseModelClient to get root cause probabilities and forms a diagnosis. |
| TAYF.Application/Services/TelemetryService.cs | Ingests telemetry DTOs, validates them, and stores telemetry records. |
| TAYF.Application/Services/BaselineExpectedPowerService.cs | Calculates expected power for an inverter based on irradiance and temperature (baseline implementation). |
| TAYF.Application/Services/TelemetryAnalysisBackgroundService.cs | Background service that periodically processes telemetry data for analysis. |

## 4. 🎯 Controllers Found
| File | [Route] | HttpMethod | Method Route |
|------|---------|------------|--------------|
| TAYF.API/Controllers/TelemetryController.cs | api/v1/[controller] | POST | /telemetry (PostTelemetry) |
| TAYF.API/Controllers/PlantStatusController.cs | api/v1/plant | GET | /status (GetPlantStatus) |
| TAYF.API/Controllers/AlertsController.cs | api/v1/[controller] | GET | (GetAlerts) |
| TAYF.API/Controllers/EnergyLossAnalysisController.cs | api/v1/analysis/energy-loss | GET | (GetEnergyLossAnalysis) |
| TAYF.API/Controllers/FinancialLossAnalysisController.cs | api/v1/analysis/financial-loss | GET | (GetFinancialLossAnalysis) |
| TAYF.API/Controllers/DiagnosisController.cs | api/v1/[controller] | GET | /root-cause (GetRootCause) |
| TAYF.API/Controllers/PlantsController.cs | api/[controller] | GET | /{id} (GetPlant) |

## 5. 🎨 Enums Found
| Enum | Values |
|------|--------|
| TAYF.Domain.Enums.TariffType | NetMetering (1), NetBilling (2), Licensed (3) |
| TAYF.Domain.Enums.Severity | Low (1), Medium (2), High (3), Critical (4) |
| TAYF.Domain.Enums.ActionType | Cleaning (1), Inspection (2), Repair (3) |
| TAYF.Domain.Enums.Currency | EGP (1), USD (2) |

## 6. 💰 Entities Found
| Entity | Properties |
|--------|------------|
| Telemetry | Id (int), PlantId (int), InverterId (int), Timestamp (DateTime), AcPowerKw (decimal), DcPowerKw (decimal), Irradiance (int), AmbientTemperature (decimal), ModuleTemperature (decimal), DailyYield (int), TotalYield (long), Plant (Plant), Inverter (Inverter) |
| AnalysisResult | Id (int), PlantId (int), InverterId (int), Timestamp (DateTime), ActualPowerKw (decimal), ExpectedPowerKw (decimal), DeviationPct (decimal), IsAnomaly (bool), Severity (Severity), AnomalyScore (decimal), PrimaryCause (string), CauseProbabilities (string), ConfidenceScore (decimal), EnergyLossKwh (decimal), ExpectedEnergyKwh (decimal), ActualEnergyKwh (decimal), EstimatedLoss (decimal), Currency (Currency), CreatedAt (DateTime), Plant (Plant), Inverter (Inverter) |
| Alert | Id (int), PlantId (int), InverterId (int), Severity (Severity), Problem (string), RootCause (string), FinancialLoss (decimal), EnergyLossKwh (decimal), Currency (Currency), RecommendedAction (string), CreatedAt (DateTime), IsResolved (bool), Plant (Plant), Inverter (Inverter) |
| Tariff | Id (int), PlantId (int), Type (TariffType), Rate (decimal), Currency (Currency), Plant (Plant) |
| Plant | Id (int), Name (string), Location (string), CapacityKw (decimal), TariffType (TariffType), TariffRate (decimal), Currency (Currency), InstallationDate (DateTime), IsActive (bool), Inverters (ICollection<Inverter>), Tariffs (ICollection<Tariff>), TelemetryRecords (ICollection<Telemetry>), MaintenanceActions (ICollection<MaintenanceAction>) |
| Inverter | Id (int), PlantId (int), SerialNumber (string), Model (string), MaxPowerKw (decimal), InstallationDate (DateTime), IsActive (bool), Plant (Plant), TelemetryRecords (ICollection<Telemetry>), AnalysisResults (ICollection<AnalysisResult>), Alerts (ICollection<Alert>), MaintenanceActions (ICollection<MaintenanceAction>), RepairVerifications (ICollection<RepairVerification>) |
| MaintenanceAction | Id (int), PlantId (int), InverterId (int?), ActionType (ActionType), StartedAt (DateTime), CompletedAt (DateTime?), Description (string), Plant (Plant), Inverter (Inverter?), RepairVerifications (ICollection<RepairVerification>) |
| RepairVerification | Id (int), MaintenanceActionId (int), PerformanceBefore (decimal), PerformanceAfter (decimal), RecoveryPct (decimal), IsStable (bool), Verified (bool), VerifiedAt (DateTime), MaintenanceAction (MaintenanceAction) |

## 7. 🗄️ DbContext Summary
- DbSets: Plants, Inverters, TelemetryRecords, AnalysisResults, Tariffs, Alerts, MaintenanceActions, RepairVerifications, TelemetryProcessingCheckpoints
- Special configs: 
  - Configured Plant entity with table name "Plants", primary key, required fields, default values, and seed data for Plant Id=1.
  - Configured Inverter entity with table name "Inverters", foreign key to Plant, seed data for 5 inverters.
  - Configured Telemetry entity with table name "Telemetry", composite indexes, foreign keys to Inverter and Plant, seed data for 5 telemetry records.
  - Configured AnalysisResult entity with table name "AnalysisResults", indexes, foreign keys to Inverter and Plant.
  - Configured Tariff entity with table name "Tariffs", foreign key to Plant, seed data for Tariff Id=1.
  - Configured MaintenanceAction entity with table name "MaintenanceActions", foreign keys to Inverter and Plant.
  - Configured RepairVerification entity with table name "RepairVerifications", foreign key to MaintenanceAction.
  - Configured TelemetryProcessingCheckpoint entity with table name "TelemetryProcessingCheckpoints", unique index on InverterId.

## 8. 🚨 Gap Analysis
| # | Target Route | Status | Current Location | Action |
|---|--------------|--------|------------------|--------|
| 01 | POST /api/v1/telemetry | EXISTS | TAYF.API/Controllers/TelemetryController.cs (PostTelemetry) | None |
| 02 | GET /api/v1/telemetry | MISSING | - | Need to implement |
| 03 | GET /api/v1/plant/status | EXISTS | TAYF.API/Controllers/PlantStatusController.cs (GetPlantStatus) | None |
| 04 | GET /api/v1/performance/expected-vs-actual | MISSING | - | Need to implement |
| 05 | GET /api/v1/diagnosis/root-cause | EXISTS | TAYF.API/Controllers/DiagnosisController.cs (GetRootCause) | None |
| 06 | GET /api/v1/economic-impact | MISSING | - | Need to implement |
| 07 | GET /api/v1/maintenance/priority | MISSING | - | Need to implement |
| 08 | POST /api/v1/simulate/what-if | MISSING | - | Need to implement |
| 09 | GET /api/v1/repair/verification | MISSING | - | Need to implement |
| 10 | GET /api/v1/alerts | EXISTS | TAYF.API/Controllers/AlertsController.cs (GetAlerts) | None |
| 11 | POST /api/v1/demo/scenario | MISSING | - | Need to implement |
| 12 | GET /api/v1/soiling/estimate | MISSING | - | Need to implement |
| 13 | GET /api/v1/health | MISSING | - | Need to implement |

## 9. 🗺️ Implementation Plan (for MISSING endpoints)
| Endpoint | DTOs Needed | Service Needed | Controller Action | Complexity |
|----------|-------------|----------------|-------------------|------------|
| GET /api/v1/telemetry | TelemetryQueryDto (for filters), TelemetryDtoResponse (paginated) | ITelemetryService (add GetTelemetryHistory) | TelemetryController.GetTelemetryHistory | MEDIUM |
| GET /api/v1/performance/expected-vs-actual | ExpectedVsActualDto (plantId, timeRange, list of {timestamp, expected, actual, deviation}) | IExpectedPowerService, ITelemetryService (or new IPerformanceAnalysisService) | New controller or PlantStatusController.GetPerformanceComparison | MEDIUM |
| GET /api/v1/economic-impact | EconomicImpactDto (plantId, timeRange, energyLoss, financialLoss, currency) | IFinancialLossAnalysisService, ITelemetryService | New controller or FinancialLossAnalysisController.GetEconomicImpact | MEDIUM |
| GET /api/v1/maintenance/priority | MaintenancePriorityDto (list of actions with priority score) | IMaintenanceService (new) or reuse MaintenanceAction analysis | New controller MaintenancePriorityController.GetPriorityRanking | MEDIUM |
| POST /api/v1/simulate/what-if | WhatIfSimulationDto (plantId, inverterId, changes, timeRange), WhatIfResultDto | ISimulationService (new) | New controller SimulationController.RunWhatIf | HIGH |
| GET /api/v1/repair/verification | RepairVerificationDto (maintenanceActionId, verification details) | IRepairVerificationService (new) or extend existing | New controller RepairVerificationController.GetVerification | LOW |
| POST /api/v1/demo/scenario | DemoScenarioDto (scenarioId, parameters), DemoResultDto | IDemoService (new) | New controller DemoController.RunScenario | MEDIUM |
| GET /api/v1/soiling/estimate | SoilingEstimateDto (plantId, inverterId, estimate) | ISoilingService (new) | New controller SoilingController.GetEstimate | MEDIUM |
| GET /api/v1/health | HealthDto (status, timestamp, version, checks) | None (simple controller) | New controller HealthController.Get | LOW |

## 10. ⚠️ Risks
- Missing entities/fields: No DTO for telemetry history query; need to create TelemetryQueryDto.
- Ambiguous requirements: 
  - "Historical data" for GET /api/v1/telemetry: unclear what filters (plantId, inverterId, time range, pagination) are expected.
  - "Performance comparison": needs clarification on what metrics (power, energy, yield) and aggregation.
  - "Economic impact": depends on tariff data and currency conversion; current FinancialLossAnalysisDto uses tariffType string but Tariff entity has Type enum.
  - "Maintenance priority": algorithm for ranking not defined.
  - "Cleaning simulation": requires domain-specific simulation logic.
  - "Soiling estimate": environmental factors needed.
- Files that may conflict: 
  - Adding new controllers may conflict with existing routing if not careful.
  - New services may duplicate existing logic (e.g., energy loss calculation already in EnergyLossAnalysisService).
  - Database context already includes all needed entities; no new entities required.

## 11. 📊 Recommended Session Split
Group the 13 endpoints into 4-5 sessions:

**Session 1: Core Telemetry & Alerts (LOW effort)**
- GET /api/v1/telemetry (historical data)
- GET /api/v1/alerts (already exists, but may need enhancement)
- GET /api/v1/health (simple)

**Session 2: Performance & Economics (MEDIUM effort)**
- GET /api/v1/performance/expected-vs-actual
- GET /api/v1/economic-impact
- GET /api/v1/soiling/estimate

**Session 3: Maintenance & Simulation (MEDIUM-HIGH effort)**
- GET /api/v1/maintenance/priority
- POST /api/v1/simulate/what-if
- GET /api/v1/repair/verification

**Session 4: Demo & Refining (LOW effort)**
- POST /api/v1/demo/scenario
- Review and refine all endpoints

Alternatively, 5 sessions:
1. Telemetry History & Health
2. Plant Status & Performance (enhance existing plant/status)
3. Economic Analysis (energy/financial loss, soiling)
4. Maintenance & Simulation
5. Demo & Final Review

Each session should include endpoint implementation, DTO creation, service updates/additions, and controller actions.