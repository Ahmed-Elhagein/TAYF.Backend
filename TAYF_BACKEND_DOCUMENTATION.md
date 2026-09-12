# TAYF.Backend Documentation

## 1. Project Overview

### Solution/Projects
The solution consists of the following projects:
- **TAYF.Domain** – Contains domain entities, enums, and interfaces (no dependencies on other projects).
- **TAYF.Application** – Contains application services, DTOs, validators, and interfaces. It depends on TAYF.Domain and TAYF.Infrastructure.
- **TAYF.Infrastructure** – Contains the EF Core DbContext (`TayfDbContext`), migrations, and seed data. It depends only on TAYF.Domain.
- **TAYF.API** – ASP.NET Core API project with controllers, routing, and service registration. It depends on TAYF.Application, TAYF.Infrastructure, and TAYF.Domain.
- **TAYF.TelemetrySimulator** – A standalone console worker that simulates telemetry data and sends it to the API. It depends on TAYF.Application, TAYF.Domain, and TAYF.Infrastructure.

### Target Frameworks
All projects target .NET 8.0.

### Main Technologies/Packages Actually Used
- **Entity Framework Core 8** – For ORM and database operations (`Microsoft.EntityFrameworkCore.SqlServer`).
- **FluentValidation 12.1.1** – For request validation (e.g., `TelemetryDtoValidator`).
- **Microsoft.Extensions.Caching.Memory** – For in-memory caching (used in background service).
- **ASP.NET Core 8** – For web API framework.
- **System.Text.Json** – For JSON serialization.
- **Azure.Identity, Microsoft.Data.SqlClient, Microsoft.IdentityModel.JsonWebTokens, System.Formats.Asn1, System.IdentityModel.Tokens.Jwt** – Security-related packages (appears to be placeholder/vulnerability fixes).

### Actual Architecture
The solution follows a **layered (pragmatic) architecture**:
```
TAYF.Backend/
├── TAYF.Domain.csproj          # Domain layer
├── TAYF.Application.csproj     # Application layer (references Domain + Infrastructure)
├── TAYF.Infrastructure.csproj  # Infrastructure layer (references Domain)
├── TAYF.API.csproj             # API layer (references Application, Infrastructure, Domain)
└── TAYF.TelemetrySimulator.csproj # Worker (references Application, Infrastructure, Domain)
```

**Key points:**
- Domain layer has no dependencies on other layers.
- Application layer depends on Domain and Infrastructure (for EF Core DbContext).
- Infrastructure layer depends only on Domain.
- API layer depends on Application, Infrastructure, and Domain (to wire up services and controllers).
- The TelemetrySimulator is a separate worker that reuses application services and infrastructure.

### Project Dependencies
- **TAYF.Domain**: No project dependencies; references System.ComponentModel.Annotations and annotations packages.
- **TAYF.Application**: References TAYF.Domain and TAYF.Infrastructure; packages include FluentValidation, Microsoft.Extensions.Hosting.Abstractions, and various security packages.
- **TAYF.Infrastructure**: References TAYF.Domain; packages include Microsoft.EntityFrameworkCore (Design, SqlServer, Tools) and security packages.
- **TAYF.API**: References TAYF.Application, TAYF.Infrastructure, and TAYF.Domain; packages include Microsoft.EntityFrameworkCore.Design, Microsoft.Extensions.Hosting, and security packages.
- **TAYF.TelemetrySimulator**: References TAYF.Application, TAYF.Domain, and TAYF.Infrastructure; package includes System.Net.Http.Json.

## 2. Feature Inventory

| Feature | Status | What it Actually Does | Main Controllers | Main Services | Main Entities | Important Limitations |
|---------|--------|-----------------------|------------------|---------------|---------------|-----------------------|
| Plant Management | Implemented | Retrieve plant details including associated inverters. | `PlantsController` (GET `/api/Plants/{id}`) | None (direct DB context usage in controller) | `Plant`, `Inverter` | Only read operation (GET) available; no create/update/delete endpoints. |
| Inverter Management | Partial | Inverters are accessible via plant endpoints; inverter details are returned when fetching a plant. | `PlantsController` (includes inverters in GET response) | None | `Inverter` | No dedicated endpoints for inverter CRUD operations; inverters can only be retrieved as part of plant data. |
| Telemetry | Implemented | Ingest telemetry data from devices, validate, check for duplicates, and store in database. | `TelemetryController` (POST `/api/v1/telemetry`) | `TelemetryService` | `Telemetry` | Validation throws exceptions rather than returning detailed error responses; duplicate detection based on exact timestamp match. |
| Performance Monitoring | Implemented | Calculate actual vs expected power, detect anomalies, and provide plant status metrics. | `PlantStatusController` (GET `/api/v1/plant/status`) | `PlantStatusService`, `ExpectedPowerService`, `AnomalyDetectionService` | `AnalysisResult`, `PlantStatusDto` | Focuses on current status; no historical performance trends or reporting. |
| Expected vs Actual | Implemented | Compares actual power output with expected power calculated from irradiance and temperature using PVWatts model. | `PlantStatusController`, `TelemetryAnalysisBackgroundService` | `BaselineExpectedPowerService` | `AnalysisResult` | Expected power calculation uses simplified PVWatts; no advanced modeling or weather forecast integration. |
| Anomaly Detection | Implemented | Flags anomalies when actual power deviation is ≤ -10% of expected power. | Indirectly via background service and plant status | `AnomalyDetectionService` | `AnalysisResult` (IsAnomaly field) | Fixed threshold (-10%); no dynamic thresholding or learning-based anomaly detection. |
| Root Cause Analysis | Implemented | Determines likely root cause (Soiling, Temperature, ElectricalFault) for anomalous telemetry via simulated ML model. | `DiagnosisController` (GET `/api/v1/diagnosis/root-cause`) | `RootCauseService`, `MockRootCauseModelClient` | `RootCauseDiagnosisDto` | Uses mock ML model; probabilities are randomly generated based on timestamp; no actual ML model integration. |
| Alerts | Implemented | Generates alert records when anomalies are detected in background processing. | None (alerts created by background service) | `TelemetryAnalysisBackgroundService` | `Alert` | Alerts are stored in database but no endpoint to retrieve or manage them; no notification mechanism (email, SMS, etc.). |
| Financial Loss | Implemented | Calculates estimated financial loss based on energy loss and tariff rate when anomalies occur. | None (calculated in background service) | `TelemetryAnalysisBackgroundService` | `AnalysisResult` (EstimatedLoss), `Alert` (FinancialLoss) | Loss calculation assumes constant tariff rate; does not account for time-of-use tariffs or complex pricing models. |
| Weather | Not Found | No weather data integration or forecasting capabilities. | None | None | None | Telemetry includes irradiance and temperature (environmental sensors), but no external weather service or forecast data. |
| Soiling | Partial | Soiling is recognized as a root cause in the mock ML model; triggers cleaning recommendation. | None | `TelemetryAnalysisBackgroundService` (via `GenerateRecommendation`) | None (as standalone feature) | No dedicated soiling detection, quantification, or loss calculation; soiling is only one of three simulated root causes. |
| Cleaning Recommendation | Implemented | Provides specific cleaning advice when soiling is identified as the root cause. | None | `TelemetryAnalysisBackgroundService` (GenerateRecommendation method) | None | Recommendations are generic and based solely on root cause; no dynamic or location-specific advice. |
| Health Score | Not Found | No composite health score or performance index calculated. | None | None | None | Plant status includes anomaly counts and deviation percentage, but no normalized health score metric. |
| Repair Verification | Not Found | Entities exist (`MaintenanceAction`, `RepairVerification`) but no functionality to create, track, or verify repairs. | None | None | `MaintenanceAction`, `RepairVerification` | No endpoints or services for logging maintenance actions or verifying repair effectiveness. |
| AI integration | Implemented | Abstracted interface (`IRootCauseModelClient`) for external ML API; currently uses mock implementation for demonstration. | None | `MockRootCauseModelClient` (implements `IRootCauseModelClient`) | None | Integration point exists but no actual AI/ML model connected; mock returns random probabilities. |
| Dashboard | Implemented | Provides data suitable for a dashboard via plant status endpoint. | `PlantStatusController` (GET `/api/v1/plant/status`) | `PlantStatusService` | `PlantStatusDto` | No actual dashboard UI; only backend data endpoint available. |
| Predictive Maintenance | Not Found | No forecasting of maintenance needs or failure prediction. | None | None | None | Focus is on reactive anomaly detection and root cause analysis, not prediction. |
| Forecasting | Not Found | No power output, energy yield, or financial forecasting capabilities. | None | None | None | Expected power calculation is for current conditions only; no future forecasting. |
| Work Orders | Not Found | No automated work order generation or management system. | None | None | None | Maintenance actions can be stored but no workflow for creating, assigning, or tracking work orders. |
| Notifications | Not Found | No mechanism to send alerts or notifications to users (email, SMS, push). | None | None | None | Alerts are stored in database but no service to dispatch them externally. |
| Reporting | Not Found | No report generation, export, or analytical reporting features. | None | None | None | Data is stored but no tools for generating periodic reports, summaries, or exports. |

## 3. API Inventory

| Method | Route | Controller | Purpose | Status |
| ------ | ----- | ---------- | ------- | ------ |
| GET | `/api/Plants/{id}` | PlantsController | Retrieve plant with its inverters | Implemented |
| POST | `/api/v1/telemetry` | TelemetryController | Ingest telemetry data (validate, deduplicate, store) | Implemented |
| GET | `/api/v1/plant/status` | PlantStatusController | Get current plant status (power metrics, anomaly counts) | Implemented |
| GET | `/api/v1/diagnosis/root-cause` | DiagnosisController | Get root cause diagnosis for specific telemetry timestamp | Implemented |

## 4. Current Capability Summary

| Capability | Status | Evidence |
| ---------- | ------ | -------- |
| Plant Management (basic read) | 🟢 | PlantsController GET endpoint returns plant with inverters |
| Inverter Management (access via plant) | 🟡 | Inverters included in plant response; no dedicated inverter endpoints |
| Telemetry Ingestion | 🟢 | TelemetryController POST endpoint with validation and deduplication |
| Performance Monitoring | 🟢 | PlantStatusController returns power metrics and anomaly counts |
| Expected vs Actual Power | 🟢 | AnalysisResult stores both values; deviation calculated |
| Anomaly Detection (static threshold) | 🟢 | AnomalyDetectionService; AnalysisResult.IsAnomaly field |
| Root Cause Analysis (mock ML) | 🟢 | DiagnosisController and RootCauseService with mock model |
| Alerts Generation | 🟢 | TelemetryAnalysisBackgroundService creates Alert records |
| Financial Loss Calculation | 🟢 | Background service computes EstimatedLoss and FinancialLoss |
| Weather Integration | 🔴 | No weather-related code or services |
| Soiling Detection | 🟡 | Soiling as root cause in mock model; triggers cleaning recommendation |
| Cleaning Recommendation | 🟢 | GenerateRecommendation method returns soiling-specific advice |
| Health Score | 🔴 | No health score metric in plant status or analysis |
| Repair Verification | 🔴 | Entities exist but no services or controllers use them |
| AI Integration (interface) | 🟢 | IRootCauseModelClient implemented with mock client |
| Dashboard Data Endpoint | 🟢 | PlantStatusController provides status data for dashboard |
| Predictive Maintenance | 🔴 | No predictive features or failure forecasting |
| Power/Energy Forecasting | 🔴 | Expected power is for current conditions only |
| Work Order Management | 🔴 | No workflow for creating or managing work orders |
| User Notifications | 🔴 | Alerts stored but no notification service (email/SMS/etc.) |
| Reporting Features | 🔴 | No report generation, export, or analytical tools |

### Current Backend Summary
The TAYF.Backend currently provides core solar telemetry processing capabilities: ingesting telemetry data, calculating expected power, detecting anomalies, performing root cause analysis (via a simulated ML model), generating alerts, and estimating financial losses. It offers basic plant and inverter data retrieval and provides status data suitable for a dashboard. However, several key features are missing or partial: weather integration, forecasting, predictive maintenance, work order management, user notifications, reporting, and health scoring. Inverter management is limited to read-only access via plant endpoints. While the system includes entities for maintenance and repair verification, no functionality exists to utilize them. The AI integration point exists but is currently backed by a mock implementation.