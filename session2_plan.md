# TAYF.Backend — Session 2: Implementation Plan

## Endpoint 1: GET /api/v1/health (LOW)
- **New DTO**: HealthDto
  - Status (string)
  - Timestamp (DateTime)
  - Version (string)
  - Environment (string)
- **Service changes**: None needed
- **Controller**: HealthController
  - Route: [Route("api/v1/health")]
  - Method: GET with [HttpGet]
  - Return: HealthDto
- **Query parameters**: None
- **Expected response shape**:
  ```json
  {
    "status": "Healthy",
    "timestamp": "2026-09-13T10:30:00Z",
    "version": "1.0.0",
    "environment": "Development"
  }
  ```
- **Acceptance criteria**:
  - Returns 200 OK
  - Returns valid JSON with all four fields
  - Timestamp is recent (within last minute)
  - Status is "Healthy"
  - Environment matches current environment

## Endpoint 2: GET /api/v1/telemetry (MEDIUM) — historical data with filters
- **New DTOs**:
  - TelemetryQueryDto
    - PlantId (int?)
    - InverterId (int?)
    - From (DateTime?)
    - To (DateTime?)
    - Page (int, default 1)
    - PageSize (int, default 50)
  - TelemetryHistoryDto
    - Id (int)
    - PlantId (int)
    - InverterId (int)
    - Timestamp (DateTime)
    - AcPowerKw (decimal)
    - DcPowerKw (decimal)
    - Irradiance (int)
    - AmbientTemperature (decimal)
    - ModuleTemperature (decimal)
    - DailyYield (int)
    - TotalYield (long)
  - PagedResult<T> (generic)
    - Items (IEnumerable<T>)
    - PageNumber (int)
    - PageSize (int)
    - TotalCount (int)
    - TotalPages (int)
    - HasPreviousPage (bool)
    - HasNextPage (bool)
- **Service changes**:
  - Extend ITelemetryService with:
    `Task<PagedResult<TelemetryHistoryDto>> GetTelemetryHistoryAsync(TelemetryQueryDto query)`
  - Implement in TelemetryService
- **Controller**: TelemetryController
  - Add GET method with [HttpGet] (no route attribute, will be at base controller route)
  - Parameters: [FromQuery] TelemetryQueryDto query
  - Return: ActionResult<PagedResult<TelemetryHistoryDto>>
- **Expected response shape**:
  ```json
  {
    "items": [
      {
        "id": 1,
        "plantId": 1,
        "inverterId": 1,
        "timestamp": "2026-09-13T10:00:00Z",
        "acPowerKw": 5.5,
        "dcPowerKw": 6.2,
        "irradiance": 800,
        "ambientTemperature": 25.5,
        "moduleTemperature": 35.2,
        "dailyYield": 2500,
        "totalYield": 150000
      }
    ],
    "pageNumber": 1,
    "pageSize": 50,
    "totalCount": 1,
    "totalPages": 1,
    "hasPreviousPage": false,
    "hasNextPage": false
  }
  ```
- **Acceptance criteria**:
  - Returns 200 OK
  - Returns valid JSON with paged result structure
  - Filters work correctly (plantId, inverterId, date range)
  - Pagination works correctly
  - Returns only the DTO fields (no navigation properties)

## Endpoint 3: GET /api/v1/repair/verification (LOW)
- **New DTO**: RepairVerificationDto
  - MaintenanceActionId (int)
  - PerformanceBefore (decimal)
  - PerformanceAfter (decimal)
  - RecoveryPct (decimal)
  - IsStable (bool)
  - Verified (bool)
  - VerifiedAt (DateTime)
- **Service changes**:
  - Create new IRepairVerificationService with method:
    `Task<RepairVerificationDto> GetRepairVerificationAsync(int maintenanceActionId)`
  - Implement in RepairVerificationService
- **Controller**: RepairVerificationController
  - Route: [Route("api/v1/repair/verification")]
  - Method: GET with [HttpGet]
  - Parameter: [FromQuery] int maintenanceActionId
  - Return: ActionResult<RepairVerificationDto>
- **Expected response shape**:
  ```json
  {
    "maintenanceActionId": 1,
    "performanceBefore": 45.5,
    "performanceAfter": 85.2,
    "recoveryPct": 87.3,
    "isStable": true,
    "verified": true,
    "verifiedAt": "2026-09-13T10:30:00Z"
  }
  ```
- **Acceptance criteria**:
  - Returns 200 OK when repair verification exists
  - Returns 404 Not Found when repair verification doesn't exist
  - Returns valid JSON with all fields
  - RecoveryPct is calculated correctly or matches stored value
  - Dates are properly formatted