# TAYF Solar Decision Intelligence Backend - Project State & Technical Documentation

## 📊 Project Overview

**Project Name**: TAYF Solar Decision Intelligence Backend  
**Version**: 1.0.0 (Phase 2 Complete)  
**Last Updated**: 2026-09-10  
**Architecture**: Clean Architecture with .NET 8.0  
**Target Framework**: net8.0  
**Database**: SQL Server (LocalDB) with EF Core 8.0  

## 🎯 Current Status

✅ **Phase 1 - Foundation**: COMPLETE  
✅ **Phase 2 - First Vertical Slice (Telemetry Ingestion & Basic Analysis)**: COMPLETE  
⏳ **Phase 3+**: PENDING  

## 🏗️ Architecture Layers

### 1. TAYF.Domain
- **Purpose**: Enterprise business logic - contains entities, enums, and domain events
- **Dependencies**: None (independent layer)
- **Key Components**:
  - Entities: Plant, Inverter, Telemetry, AnalysisResult, Tariff, MaintenanceAction, RepairVerification, Alert
  - Enums: TariffType, Severity, ActionType

### 2. TAYF.Application
- **Purpose**: Application business logic - use cases, DTOs, interfaces, and services
- **Dependencies**: TAYF.Domain
- **Key Components**:
  - DTOs: TelemetryDto, TelemetryDtoResponse, PlantStatusDto
  - Validators: TelemetryDtoValidator (FluentValidation)
  - Interfaces: ITelemetryService, IExpectedPowerService, IAnomalyDetectionService, IPlantStatusService
  - Services: TelemetryService, BaselineExpectedPowerService, AnomalyDetectionService, PlantStatusService

### 3. TAYF.Infrastructure
- **Purpose**: Infrastructure concerns - data access, external services
- **Dependencies**: TAYF.Domain
- **Key Components**:
  - TayfDbContext: EF Core DbContext with all DbSets and configurations
  - Seed Data: 1 Plant, 5 Inverters, Tariffs, and sample telemetry data
  - Entity Configurations: Fluent API configurations, indexes, relationships

### 4. TAYF.API
- **Purpose**: Presentation layer - RESTful API endpoints
- **Dependencies**: TAYF.Application, TAYF.Infrastructure
- **Key Components**:
  - TelemetryController: POST /api/v1/telemetry
  - PlantStatusController: GET /api/v1/plant/status?plantId=1
  - PlantsController: GET /api/v1/plants/{id} (minimal for plant lookup)
  - Program.cs: Dependency injection setup, middleware configuration

### 5. TAYF.TelemetrySimulator
- **Purpose**: External demonstration tool - generates synthetic telemetry data
- **Dependencies**: TAYF.Application (DTOs only)
- **Key Features**:
  - Simulates 5 inverters for 1 plant
  - Toggles between Normal and Underperformance modes (-15% actual power)
  - Sends POST requests every 10 seconds
  - Interactive console control (U/N/Q keys)

## 🔧 Technical Specifications

### Frameworks & Packages
- **.NET SDK**: 8.0.x
- **Language**: C# 12.0
- **Entity Framework Core**: 8.0.0
- **FluentValidation**: 12.1.1
- **System.Net.Http.Json**: 10.0.12 (Telemetry Simulator)

### Database Design
- **Provider**: Microsoft SQL Server (LocalDB)
- **Connection String**: `Server=(localdb)\\mssqllocaldb;Database=TayfDb;Trusted_Connection=True;MultipleActiveResultSets=true`
- **Tables**: Plants, Inverters, Telemetry, AnalysisResults, Tariffs, MaintenanceActions, RepairVerifications, Alerts
- **Indexes**: 
  - IX_Telemetry_PlantId_Timestamp
  - IX_Telemetry_InverterId_Timestamp
  - IX_AnalysisResult_PlantId_Timestamp
  - IX_AnalysisResult_InverterId_Timestamp
  - IX_AnalysisResult_IsAnomaly

### Seed Data Summary
- **Plants**: 1 (Solar Plant A - Cairo, 500kW, NetMetering)
- **Inverters**: 5 (All 100kW SUN2000-100KTL models)
- **Tariffs**: 1 (NetMetering @ 1.25 EGP/kWh)
- **Telemetry**: ~336 records (7 days × 4 readings/day × 5 inverters + historical)

## 🌐 API Endpoints

### Telemetry Ingestion
```
POST /api/v1/telemetry
Content-Type: application/json

Request Body:
{
  "plantId": 1,
  "inverterId": 1,
  "timestamp": "2026-09-10T10:15:00Z",
  "acPowerKw": 69.0,
  "dcPowerKw": 72.0,
  "irradiance": 850.0,
  "ambientTemperature": 30.0,
  "moduleTemperature": 42.0,
  "dailyYield": 520,
  "totalYield": 15230
}

Response:
{
  "telemetryId": 1001,
  "received": true
}

// Duplicate detection:
{
  "telemetryId": 1001,
  "received": false
}
```

### Plant Status Dashboard
```
GET /api/v1/plant/status?plantId=1

Response:
{
  "plantId": 1,
  "plantName": "Solar Plant A - Cairo",
  "totalInverters": 5,
  "activeInverters": 5,
  "anomalyCount": 0,
  "totalActualPowerKw": 345.2,
  "totalExpectedPowerKw": 348.7,
  "overallDeviationPct": -1.0,
  "hasCriticalAnomalies": false,
  "lastUpdated": "2026-09-10T18:45:00Z"
}
```

### Plant Lookup (Minimal)
```
GET /api/v1/plants/1

Response:
{
  "id": 1,
  "name": "Solar Plant A - Cairo",
  "location": "Cairo, Egypt",
  "capacityKw": 500,
  "tariffType": 1,
  "tariffRateEgpPerKwh": 1.25,
  "installationDate": "2023-01-15T00:00:00Z",
  "isActive": true,
  "inverters": [...],
  "tariffs": [...]
}
```

## ⚙️ Configuration

### appsettings.json (TAYF.API)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=TayfDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### Launch Settings
- **Application URL**: http://localhost:5134
- **Environment**: Development
- **HTTPS**: Disabled for simplicity (per tech lead guidance)

## 🚀 How to Run

### 1. Start the API
```bash
cd /c/Users/Compu/source/TAYF.Backend/TAYF.API
dotnet run
```
Output: "Now listening on: http://localhost:5134"

### 2. Start the Telemetry Simulator
```bash
cd /c/Users/Compu/source/TAYF.Backend/TAYF.TelemetrySimulator
dotnet run [mode]
```
Where `[mode]` is optional:
- `normal` (default): Expected ≈ Actual power
- `underperformance`: Actual power reduced by 15%

**Interactive Controls** (while running):
- `U`: Switch to Underperformance mode
- `N`: Switch to Normal mode
- `Q`: Quit simulator

### 3. Verify Operation
- **API Health**: Visit http://localhost:5134/api/v1/plants/1
- **Telemetry Ingestion**: Watch simulator console for POST success/failure
- **Dashboard**: Visit http://localhost:5134/api/v1/plant/status?plantId=1
- **Duplicate Detection**: After first cycle, simulator shows "received: false"

## 🔍 Key Implementation Details

### Duplicate Protection
- **Location**: TelemetryService.IngestTelemetry()
- **Logic**: Checks for existing telemetry with same PlantId, InverterId, and Timestamp
- **Response**: Returns received=false for duplicates (does not create new record)

### Expected Power Calculation
- **Formula**: ExpectedPower = Inverter.MaxPowerKw × (Irradiance / 1000)
- **Service**: BaselineExpectedPowerService
- **Notes**: Uses MaxPowerKw from inverter entity as rated power proxy

### Anomaly Detection
- **Threshold**: DeviationPct ≤ -10% → Anomaly
- **Calculation**: ((Actual - Expected) / Expected) × 100
- **Service**: AnomalyDetectionService
- **Edge Cases**: Handles zero expected power to prevent division by zero

### Plant Status Aggregation
- **Service**: PlantStatusService
- **Logic**:
  1. Gets plant with active inverters
  2. For each inverter, fetches latest telemetry
  3. Calculates expected power using IExpectedPowerService
  4. Detects anomalies using IAnomalyDetectionService
  5. Aggregates totals and calculates overall deviation
  6. Returns PlantStatusDto with summary metrics

## 📁 Project Structure

```
/TAYF.Backend
├── /TAYF.API                          # ASP.NET Core Web API
│   ├── Controllers/
│   │   ├── TelemetryController.cs     # POST /api/v1/telemetry
│   │   ├── PlantStatusController.cs   # GET /api/v1/plant/status
│   │   └── PlantsController.cs        # GET /api/v1/plants/{id}
│   ├── Program.cs                     # DI setup, middleware
│   ├── appsettings.json               # Configuration
│   └── TAYF.API.csproj
│
├── /TAYF.Application                  # Application layer
│   ├── DTOs/
│   │   ├── TelemetryDto.cs
│   │   └── TelemetryDtoResponse.cs
│   ├── Interfaces/
│   │   ├── ITelemetryService.cs
│   │   ├── IExpectedPowerService.cs
│   │   ├── IAnomalyDetectionService.cs
│   │   └── IPlantStatusService.cs
│   ├── Services/
│   │   ├── TelemetryService.cs
│   │   ├── BaselineExpectedPowerService.cs
│   │   ├── AnomalyDetectionService.cs
│   │   └── PlantStatusService.cs
│   ├── Validators/
│   │   └── TelemetryDtoValidator.cs
│   └── TAYF.Application.csproj
│
├── /TAYF.Domain                       # Domain layer
│   ├── Entities/
│   │   ├── Plant.cs
│   │   ├── Inverter.cs
│   │   ├── Telemetry.cs
│   │   ├── AnalysisResult.cs
│   │   ├── Tariff.cs
│   │   ├── MaintenanceAction.cs
│   │   ├── RepairVerification.cs
│   │   └── Alert.cs
│   ├── Enums/
│   │   ├── TariffType.cs
│   │   ├── Severity.cs
│   │   └── ActionType.cs
│   └── TAYF.Domain.csproj
│
├── /TAYF.Infrastructure               # Infrastructure layer
│   ├── Data/
│   │   └── TayfDbContext.cs           # EF Core context + configurations
│   ├── Seed/
│   │   └── TayfSeedData.cs            # Seed data (1 Plant, 5 Inverters)
│   └── TAYF.Infrastructure.csproj
│
├── /TAYF.TelemetrySimulator           # Demo console app
│   └── Program.cs                     # Interactive telemetry generator
│   └── TAYF.TelemetrySimulator.csproj
│
├── /TAYF.Backend.sln                  # Solution file
├── PHASE_1_SUMMARY.md                 # Phase 1 completion summary
├── PHASE_2_COMPLETION_SUMMARY.md      # Phase 2 completion summary
└── PROJECT_STATE_TECHNICAL_DOCUMENTATION.md  # This document
```

## ✅ Verification Checklist

### Phase 1 Foundation
- [x] Solution structure: TAYF.API, TAYF.Application, TAYF.Domain, TAYF.Infrastructure
- [x] All domain entities and enums created
- [x] DbContext with entity configurations and indexes
- [x] Seed data implemented
- [x] Initial API controllers (refined per tech lead feedback)
- [x] Solution builds with 0 errors, 0 warnings

### Phase 2 First Vertical Slice
- [x] DTOs and Validation (TAYF.Application)
  - [x] TelemetryDto matching API Contract
  - [x] FluentValidation for required fields and ranges
  - [x] PlantId/InverterId existence validation in service
- [x] Application Interfaces (TAYF.Application)
  - [x] ITelemetryService with duplicate protection
  - [x] IExpectedPowerService with BaselineExpectedPowerService
  - [x] IAnomalyDetectionService with ≤ -10% anomaly rule
  - [x] IPlantStatusService for dashboard aggregation
- [x] API Controllers (TAYF.API)
  - [x] POST /api/v1/telemetry returning {telemetryId, received}
  - [x] GET /api/v1/plant/status?plantId=1 returning dashboard status
  - [x] Dependency injection of all services
- [x] Telemetry Simulator (TAYF.TelemetrySimulator)
  - [x] External console application
  - [x] Generates synthetic telemetry for 5 inverters
  - [x] HTTP POST to http://localhost:5134/api/v1/telemetry
  - [x] Toggle between Normal and Underperformance modes
  - [x] Interactive user controls
- [x] Definition of Done Verified:
  - [x] API runs successfully
  - [x] Telemetry Simulator runs and posts data
  - [x] Duplicates are blocked (received=false after first cycle)
  - [x] Plant status changes when simulator toggles modes

## 📈 Sample Output

### Telemetry Simulator Console (Normal Mode)
```
TAYF Telemetry Simulator - Started in NORMAL mode
========================
Press 'U' to toggle Underperformance mode
Press 'N' to toggle Normal mode
Press 'Q' to quit

[18:45:00] Inverter 1: Telemetry 1000 - Received: True - Mode: NORMAL
[18:45:00] Inverter 2: Telemetry 1001 - Received: True - Mode: NORMAL
[18:45:00] Inverter 3: Telemetry 1002 - Received: True - Mode: NORMAL
[18:45:00] Inverter 4: Telemetry 1003 - Received: True - Mode: NORMAL
[18:45:00] Inverter 5: Telemetry 1004 - Received: True - Mode: NORMAL
[18:45:10] Inverter 1: Telemetry 1005 - Received: False - Mode: NORMAL  # Duplicate
```

### Telemetry Simulator Console (Underperformance Mode)
```
[18:50:00] Inverter 1: Telemetry 1050 - Received: True - Mode: UNDERPERFORMANCE
[18:50:00] Inverter 2: Telemetry 1051 - Received: True - Mode: UNDERPERFORMANCE
[18:50:10] Inverter 1: Telemetry 1055 - Received: False - Mode: UNDERPERFORMANCE
```

### Plant Status API Response (Underperformance Detected)
```json
{
  "plantId": 1,
  "plantName": "Solar Plant A - Cairo",
  "totalInverters": 5,
  "activeInverters": 5,
  "anomalyCount": 3,
  "totalActualPowerKw": 293.4,
  "totalExpectedPowerKw": 345.2,
  "overallDeviationPct": -15.0,
  "hasCriticalAnomalies": true,
  "lastUpdated": "2026-09-10T18:50:00Z"
}
```

## 🛡️ Security & Quality Considerations

### Input Validation
- All API inputs validated via FluentValidation
- Range checks for power values (≥ 0)
- Required field validation
- Existence checks for foreign keys

### Error Handling
- Proper HTTP status codes:
  - 200 OK: Successful operations
  - 400 Bad Request: Validation failures
  - 404 Not Found: Missing resources
  - 500 Internal Server Error: Unexpected errors
- Exception handling in service layer

### Data Integrity
- Foreign key constraints via EF Core relationships
- Cascade delete rules configured appropriately
- Prevents orphaned records
- UTC timestamps for consistency

### Performance
- Database indexes on frequently queried columns
- Asynchronous database operations
- Efficient entity loading with Includes
- Pagination considerations in list endpoints

## 🔮 Future Enhancement Areas

### Phase 3+ Candidates
1. **Enhanced Expected Power Models**
   - Machine learning-based expected power calculation
   - Weather forecasting integration
   - Historical performance baselines

2. **Alerting System**
   - Automatic alert generation from anomalies
   - Alert deduplication and escalation
   - Notification channels (email, SMS, webhook)

3. **Maintenance Integration**
   - Work order creation from alerts
   - Maintenance scheduling and tracking
   - Repair verification workflow

4. **Historical Analytics**
   - Trend analysis and reporting
   - Performance comparison over time
   - Energy loss calculation and reporting

5. **Frontend Integration**
   - Flutter client consuming APIs
   - Real-time dashboard with charts
   - Mobile-responsive design

6. **Operational Excellence**
   - API versioning
   - Comprehensive logging and monitoring
   - Health checks and metrics endpoints
   - Automated testing suite
   - CI/CD pipeline

## 📞 Support & Maintenance

### Running Locally
1. Ensure SQL Server LocalDB is installed
2. Update connection string in appsettings.json if needed
3. Run database migrations: `dotnet ef database update` (if schema changes)
4. Start API: `dotnet run` in TAYF.API directory
5. Start simulator: `dotnet run` in TAYF.TelemetrySimulator directory

### Troubleshooting
- **Port Already in Use**: Kill existing processes on port 5134
- **Database Connection Errors**: Verify SQL Server LocalDB instance
- **Missing Dependencies**: Run `dotnet restore` in each project directory
- **Startup Failures**: Check API logs for detailed error messages

### Directory Locations
- **Source Code**: C:\Users\Compu\source\TAYF.Backend\
- **API Logs**: C:\Users\Compu\source\TAYF.Backend\TAYF.API\api.log
- **Simulator Logs**: C:\Users\Compu\source\TAYF.Backend\TAYF.TelemetrySimulator\simulator.log
- **Database File**: C:\Users\Compu\mssqllocaldb\TayfDb.mdf

---
*Document generated: 2026-09-10*  
*TAYF Solar Decision Intelligence Backend - Technical Documentation*  
*For internal team use and stakeholder review*