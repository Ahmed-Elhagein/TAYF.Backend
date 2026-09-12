# Implementation Plan for Quantification + Alerts Endpoints

## Overview
This plan outlines the implementation of three new endpoints according to the TAYF specification:
1. GET /api/v1/alerts
2. GET /api/v1/analysis/energy-loss
3. GET /api/v1/analysis/financial-loss

We will follow Clean Architecture principles, using IApplicationDbContext and Application Services.

## Changes Required

### 1. Entity Modifications
#### Alert Entity (TAYF.Domain.Entities.Alert)
- Add property: `public decimal EnergyLossKwh { get; set; }`
  - Stores energy loss in kWh for the alert interval

#### AnalysisResult Entity (TAYF.Domain.Entities.AnalysisResult)
- Add properties:
  - `public decimal ExpectedEnergyKwh { get; set; }`
  - `public decimal ActualEnergyKwh { get; set; }`
  - Stores expected and actual energy in kWh for the interval

### 2. Data Transfer Objects (DTOs)
#### AlertDto (TAYF.Application.DTOs)
- string Severity
- string Asset (inverter serial number)
- string Problem
- string RootCause
- decimal EnergyLossKwh
- decimal FinancialLossEgp (financial loss in EGP, assuming plant currency is EGP)
- string RecommendedAction

#### EnergyLossAnalysisDto (TAYF.Application.DTOs)
- decimal ExpectedEnergyKwh
- decimal ActualEnergyKwh
- decimal EnergyLossKwh
- string PrimaryCause

#### FinancialLossAnalysisDto (TAYF.Application.DTOs)
- decimal EnergyLossKwh
- string TariffType (from parameter)
- decimal TariffRate (from plant's tariff)
- string Currency (from plant's tariff)
- decimal EstimatedLoss (energyLossKwh * tariffRate)

### 3. Application Services
#### IAlertService (TAYF.Application.Interfaces)
- Task<IEnumerable<AlertDto>> GetAlertsAsync()

#### AlertService (TAYF.Application.Services)
- Depends on: IApplicationDbContext
- Implementation:
  - Query Alerts with Include(a => a.Inverter) to get serial number
  - Map each Alert to AlertDto:
    - Severity: alert.Severity.ToString()
    - Asset: alert.Inverter.SerialNumber
    - Problem: alert.Problem
    - RootCause: alert.RootCause
    - EnergyLossKwh: alert.EnergyLossKwh
    - FinancialLossEgp: alert.FinancialLoss (assuming EGP currency)
    - RecommendedAction: alert.RecommendedAction

#### IEnergyLossAnalysisService (TAYF.Application.Interfaces)
- Task<EnergyLossAnalysisDto> GetEnergyLossAnalysisAsync(int plantId, int? inverterId, DateTime from, DateTime to)

#### EnergyLossAnalysisService (TAYF.Application.Services)
- Depends on: IApplicationDbContext
- Implementation:
  - Query AnalysisResult for plantId, optional inverterId, and timestamp between @from and @to
  - Calculate sums:
    - ExpectedEnergyKwh = sum of ExpectedEnergyKwh
    - ActualEnergyKwh = sum of ActualEnergyKwh
    - EnergyLossKwh = sum of EnergyLossKwh (or ExpectedEnergyKwh - ActualEnergyKwh)
  - Determine PrimaryCause:
    - Find the AnalysisResult with the highest EnergyLossKwh in the result set
    - PrimaryCause = that record's PrimaryCause (or null if no records)
  - Return new EnergyLossAnalysisDto with the calculated values

#### IFinancialLossAnalysisService (TAYF.Application.Interfaces)
- Task<FinancialLossAnalysisDto> GetFinancialLossAnalysisAsync(int plantId, string tariffType)

#### FinancialLossAnalysisService (TAYF.Application.Services)
- Depends on: IApplicationDbContext
- Implementation:
  - Get plant by plantId (include Tariffs)
  - Get first tariff from plant.Tariffs (assume one tariff per plant)
  - Calculate total energy loss for plant (all time):
    - Sum EnergyLossKwh from AnalysisResult where PlantId = plantId
  - Calculate:
    - EnergyLossKwh = total energy loss
    - TariffType = input parameter (returned as-is)
    - TariffRate = tariff.Rate
    - Currency = tariff.Currency.ToString()
    - EstimatedLoss = EnergyLossKwh * (decimal)tariffRate
  - Return new FinancialLossAnalysisDto with these values

### 4. Controllers
#### AlertsController (TAYF.API.Controllers)
- [ApiController]
- [Route("api/v1/alerts")]
- Constructor: takes IAlertService
- [HttpGet]
- public async Task<ActionResult<IEnumerable<AlertDto>>> GetAlerts()
  - Returns: await _alertService.GetAlertsAsync()

#### AnalysisController (TAYF.API.Controllers)
- [ApiController]
- [Route("api/v1/analysis")]
- Constructor: takes IEnergyLossAnalysisService, IFinancialLossAnalysisService
- [HttpGet("energy-loss")]
- public async Task<ActionResult<EnergyLossAnalysisDto>> GetEnergyLoss(int plantId, int? inverterId, DateTime from, DateTime to)
  - Returns: await _energyLossService.GetEnergyLossAnalysisAsync(plantId, inverterId, from, to)
- [HttpGet("financial-loss")]
- public async Task<ActionResult<FinancialLossAnalysisDto>> GetFinancialLoss(int plantId, string tariffType)
  - Returns: await _financialLossService.GetFinancialLossAnalysisAsync(plantId, tariffType)

### 5. Background Service Updates
#### TelemetryAnalysisBackgroundService (TAYF.Application.Services)
- When creating AnalysisResult:
  - Calculate:
    - double expectedEnergyKwh = expectedPowerKw * hoursSincePrevious;
    - double actualEnergyKwh = telemetry.AcPowerKw * hoursSincePrevious;
  - Set:
    - analysisResult.ExpectedEnergyKwh = (decimal)expectedEnergyKwh;
    - analysisResult.ActualEnergyKwh = (decimal)actualEnergyKwh;
    - analysisResult.EnergyLossKwh = (decimal)energyLossKwh; (already exists)
- When creating Alert:
  - Set alert.EnergyLossKwh = (decimal)energyLossKwh; (new property)

### 6. Database Migration
- Add migration for the new entity properties:
  - Alert.EnergyLossKwh
  - AnalysisResult.ExpectedEnergyKwh
  - AnalysisResult.ActualEnergyKwh

### 7. Dependency Registration
- Update TAYF.API/Program.cs to register the new services:
  - services.AddScoped<IAlertService, AlertService>();
  - services.AddScoped<IEnergyLossAnalysisService, EnergyLossAnalysisService>();
  - services.AddScoped<IFinancialLossAnalysisService, FinancialLossAnalysisService>();

## Assumptions and Notes
1. Currency Handling:
   - For Alerts endpoint, we return financial loss in EGP (field name FinancialLossEgp) assuming plant currency is EGP.
   - If a plant uses USD, the financial loss will be incorrectly labeled as EGP (known limitation).
   - Ideal solution would require an exchange rate service, which is out of scope.

2. Tariff Handling:
   - For Financial Loss endpoint, we use the first tariff from the plant's Tariffs collection.
   - The tariffType parameter is returned in the response but not used to select the tariff (we assume the plant's tariff matches the requested type).

3. Time Periods:
   - Alerts endpoint returns all alerts (no time filtering).
   - Energy Loss endpoint requires explicit from/to parameters.
   - Financial Loss endpoint calculates loss for all time (no time filtering).

4. Primary Cause Calculation:
   - For Energy Loss endpoint, primary cause is taken from the AnalysisResult with the highest energy loss in the period.

5. Null Handling:
   - If no analysis records are found for Energy Loss endpoint, returns zeros and null primary cause.
   - If plant has no tariff for Financial Loss endpoint, throws appropriate exception.

## Files to Create/Modify
1. TAYF.Domain.Entities/Alert.cs
2. TAYF.Domain.Entities/AnalysisResult.cs
3. TAYF.Application.DTOs/AlertDto.cs
4. TAYF.Application.DTOs/EnergyLossAnalysisDto.cs
5. TAYF.Application.DTOs/FinancialLossAnalysisDto.cs
6. TAYF.Application.Interfaces/IAlertService.cs
7. TAYF.Application.Services/AlertService.cs
8. TAYF.Application.Interfaces/IEnergyLossAnalysisService.cs
9. TAYF.Application.Services/EnergyLossAnalysisService.cs
10. TAYF.Application.Interfaces/IFinancialLossAnalysisService.cs
11. TAYF.Application.Services/FinancialLossAnalysisService.cs
12. TAYF.API.Controllers/AlertsController.cs
13. TAYF.API.Controllers/AnalysisController.cs
14. TAYF.Application.Services/TelemetryAnalysisBackgroundService.cs (update)
15. TAYF.API/Program.cs (add service registrations)
16. Migration files (to be generated)

## Next Steps
Upon approval of this plan, we will proceed with implementation in the following order:
1. Entity modifications
2. DTO creation
3. Service interfaces and implementations
4. Controller creation
5. Background service updates
6. Database migration
7. Service registration