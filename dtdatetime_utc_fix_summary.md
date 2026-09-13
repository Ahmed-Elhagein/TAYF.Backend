# DateTime UTC Handling Fix Summary

## Problem
Telemetry timestamps came out without the `Z` UTC indicator:
"timestamp": "2026-09-04T19:19:35.646611"

Should be:
"timestamp": "2026-09-04T19:19:35.646611Z"

## Root Cause
EF Core returns DateTime with Kind=Unspecified when reading from SQL Server 
datetime2 columns. System.Text.Json only appends `Z` when Kind=Utc.

## Solution Implemented

### 1. Modified TAYF.Infrastructure/Data/TayfDbContext.cs
- Added `using Microsoft.EntityFrameworkCore.Storage.ValueConversion;`
- Added value converter at the end of OnModelCreating method to convert all DateTime properties to UTC

### 2. Modified TAYF.Application/Services/TelemetryService.cs
- Updated TelemetryService.IngestTelemetry to ensure Timestamp is stored as UTC
- Applied the same UTC conversion logic when creating the Telemetry entity

## Files Modified

### TAYF.Infrastructure/Data/TayfDbContext.cs
```diff
+using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
 using TAYF.Domain.Enums;
 using TAYF.Domain.Entities;
 using TAYF.Application.Interfaces;

 namespace TAYF.Infrastructure.Data;
 /// <summary>
 /// Database context for the TAYF solar decision intelligence system
 /// </summary>
 public class TayfDbContext : DbContext, IApplicationDbContext
 {
     public TayfDbContext(DbContextOptions<TayfDbContext> options)
         : base(options)
     {
     }

     // DbSets for all entities
     public DbSet<Plant> Plants { get; set; } = null!;
     public DbSet<Inverter> Inverters { get; set; } = null!;
     public DbSet<Telemetry> TelemetryRecords { get; set; } = null!;
     public DbSet<AnalysisResult> AnalysisResults { get; set; } = null!;
     public DbSet<Tariff> Tariffs { get; set; } = null!;
     public DbSet<Alert> Alerts { get; set; } = null!;
     public DbSet<MaintenanceAction> MaintenanceActions { get; set; } = null!;
     public DbSet<RepairVerification> RepairVerifications { get; set; } = null!;
     public DbSet<TelemetryProcessingCheckpoint> TelemetryProcessingCheckpoints { get; set; }

     protected override void OnModelCreating(ModelBuilder modelBuilder)
     {
         base.OnModelCreating(modelBuilder);

         // Apply configurations
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(TayfDbContext).Assembly);

         // Additional model configuration if needed
         ConfigurePlantEntity(modelBuilder);
         ConfigureInverterEntity(modelBuilder);
         ConfigureTelemetryEntity(modelBuilder);
         ConfigureAnalysisResultEntity(modelBuilder);
         ConfigureTariffEntity(modelBuilder);
         ConfigureMaintenanceActionEntity(modelBuilder);
         ConfigureRepairVerificationEntity(modelBuilder);
         ConfigureTelemetryProcessingCheckpointEntity(modelBuilder);

         // Apply UTC DateTime value converter to all DateTime properties
         foreach (var entityType in modelBuilder.Model.GetEntityTypes())
         {
             foreach (var property in entityType.GetProperties())
             {
                 if (property.ClrType == typeof(DateTime))
                 {
                     property.SetValueConverter(new ValueConverter<DateTime, DateTime>(
                         v => v.Kind == DateTimeKind.Utc ? v : v.ToUniversalTime(),
                         v => DateTime.SpecifyKind(v, DateTimeKind.Utc)));
                 }
                 else if (property.ClrType == typeof(DateTime?))
                 {
                     property.SetValueConverter(new ValueConverter<DateTime?, DateTime?>(
                         v => v.HasValue
                             ? (v.Value.Kind == DateTimeKind.Utc ? v.Value : v.Value.ToUniversalTime())
                             : v,
                         v => v.HasValue
                             ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc)
                             : v));
                 }
             }
         }
     }
 }
```

### TAYF.Application/Services/TelemetryService.cs
```diff
 using Microsoft.EntityFrameworkCore;
 using TAYF.Application.DTOs;
 using TAYF.Application.Validators;
 using TAYF.Domain.Entities;
 using TAYF.Application.Interfaces;

 namespace TAYF.Application.Services;

 /// <summary>
 /// Handles telemetry ingestion and duplicate protection.
 /// </summary>
 public class TelemetryService : ITelemetryService
 {
     private readonly IApplicationDbContext _context;
     private readonly TelemetryDtoValidator _validator;

     public TelemetryService(IApplicationDbContext context, TelemetryDtoValidator validator)
     {
         _context = context;
         _validator = validator;
     }

     /// <summary>
     /// Ingests telemetry data, checks for duplicates, and saves to database.
     /// </summary>
     /// <param name="telemetryDto">The telemetry data to ingest.</param>
     /// <returns>A response indicating the telemetry ID and whether it was received.</returns>
     public async Task<TelemetryDtoResponse> IngestTelemetry(TelemetryDto telemetryDto)
     {
         // Validate the DTO
         var validationResult = await _validator.ValidateAsync(telemetryDto);
         if (!validationResult.IsValid)
         {
             // In a real application, we might want to return validation errors
             // For now, we'll just throw an exception or handle it appropriately
             throw new ValidationException(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage)));
         }

         // Parse timestamp
         if (!DateTime.TryParse(telemetryDto.Timestamp, out DateTime timestamp))
         {
             throw new ArgumentException("Invalid timestamp format");
         }

         // Check for duplicate telemetry (same plant, inverter, and timestamp)
         var existingTelemetry = await _context.TelemetryRecords
             .FirstOrDefaultAsync(t =>
                 t.PlantId == telemetryDto.PlantId &&
                 t.InverterId == telemetryDto.InverterId &&
                 t.Timestamp == timestamp);

         if (existingTelemetry != null)
         {
             // Duplicate detected - return the existing telemetry ID but indicate it wasn't received as new
             return new TelemetryDtoResponse
             {
                 TelemetryId = existingTelemetry.Id,
                 Received = false // Indicates it was a duplicate
             };
         }

         // Validate that PlantId and InverterId exist
         var plantExists = await _context.Plants.AnyAsync(p => p.Id == telemetryDto.PlantId);
         if (!plantExists)
         {
             throw new ArgumentException($"Plant with ID {telemetryDto.PlantId} does not exist");
         }

         var inverterExists = await _context.Inverters.AnyAsync(i => i.Id == telemetryDto.InverterId && i.PlantId == telemetryDto.PlantId);
         if (!inverterExists)
         {
             throw new ArgumentException($"Inverter with ID {telemetryDto.InverterId} does not exist or does not belong to plant {telemetryDto.PlantId}");
         }

         // Create new telemetry entity
         var telemetry = new Telemetry
         {
             PlantId = telemetryDto.PlantId,
             InverterId = telemetryDto.InverterId,
-            Timestamp = timestamp,
+            Timestamp = timestamp.Kind == DateTimeKind.Utc
+                ? timestamp
+                : DateTime.SpecifyKind(timestamp.ToUniversalTime(), DateTimeKind.Utc),
             AcPowerKw = (decimal)telemetryDto.AcPowerKw,
             DcPowerKw = (decimal)telemetryDto.DcPowerKw,
             Irradiance = (int)telemetryDto.Irradiance, // Assuming irradiance is stored as integer
             AmbientTemperature = (decimal)telemetryDto.AmbientTemperature,
             ModuleTemperature = (decimal)telemetryDto.ModuleTemperature,
             DailyYield = telemetryDto.DailyYield,
             TotalYield = telemetryDto.TotalYield
         };

         // Save to database
         _context.TelemetryRecords.Add(telemetry);
         await _context.SaveChangesAsync();

         // Return success response
         return new TelemetryDtoResponse
         {
             TelemetryId = telemetry.Id,
             Received = true
         };
     }
 
     // ... existing GetTelemetryHistoryAsync method ...
 }
 
 // Custom exception for validation errors
 public class ValidationException : Exception
 {
     public ValidationException(string message) : base(message) { }
 }
```

## Build Result
- ✅ `dotnet build` succeeded
- 0 errors, 0 warnings
- 6 projects compiled successfully

## Verification
After implementing the fix, I tested the API:

### Example curl command and response showing `Z` suffix:
```bash
curl -s "http://localhost:5134/api/v1/telemetry"
```

Response:
```json
{
  "items":[
    {
      "id":1,
      "plantId":1,
      "inverterId":1,
      "timestamp":"2026-09-04T19:19:35.646611Z",
      "acPowerKw":0.03,
      "dcPowerKw":0.00,
      "irradiance":0,
      "ambientTemperature":22.00,
      "moduleTemperature":22.00,
      "dailyYield":164,
      "totalYield":1000
    },
    {
      "id":2,
      "plantId":1,
      "inverterId":2,
      "timestamp":"2026-09-04T19:19:35.646611Z",
      "acPowerKw":0.10,
      "dcPowerKw":0.00,
      "irradiance":49,
      "ambientTemperature":21.00,
      "moduleTemperature":22.22,
      "dailyYield":624,
      "totalYield":2000
    }
    // ... more items with Z suffix
  ],
  "pageNumber":1,
  "pageSize":50,
  "totalCount":5,
  "totalPages":1,
  "hasPreviousPage":false,
  "hasNextPage":false
}
```

### Filtering still works correctly:
```bash
curl -s "http://localhost:5134/api/v1/telemetry?inverterId=2"
```
Response:
```json
{
  "items":[
    {
      "id":2,
      "plantId":1,
      "inverterId":2,
      "timestamp":"2026-09-04T19:19:35.646611Z",
      "acPowerKw":0.10,
      "dcPowerKw":0.00,
      "irradiance":49,
      "ambientTemperature":21.00,
      "moduleTemperature":22.22,
      "dailyYield":624,
      "totalYield":2000
    }
  ],
  "pageNumber":1,
  "pageSize":50,
  "totalCount":1,
  "totalPages":1,
  "hasPreviousPage":false,
  "hasNextPage":false
}
```

## Acceptance Criteria Met
- [x] All DateTime properties in the database are now stored and retrieved as UTC (Kind=Utc)
- [x] System.Text.Json serializes DateTime with Kind=Utc as ISO 8601 with 'Z' suffix
- [x] Telemetry timestamps now end with 'Z' (e.g., "2026-09-04T19:19:35.646611Z")
- [x] No changes to DTO structures (as required)
- [x] No changes to controllers (as required)
- [x] No migrations added or required
- [x] Value Converter works transparently - no changes needed to existing code logic
- [x] Build succeeds with 0 errors and 0 warnings
- [x] Existing functionality preserved (filtering, pagination, etc. still work)