using Microsoft.EntityFrameworkCore;
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
    }

    private void ConfigurePlantEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Plant>(entity =>
        {
            entity.ToTable("Plants");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            entity.Property(e => e.CapacityKw)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.TariffType)
                .IsRequired();

            entity.Property(e => e.TariffRate)
                .IsRequired()
                .HasColumnType("decimal(18,4)");

            entity.Property(e => e.Currency)
                .IsRequired()
                .HasDefaultValue(Currency.EGP)
                .HasColumnType("int");

            entity.Property(e => e.InstallationDate)
                .IsRequired()
                .HasColumnType("datetime2");

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                .HasColumnType("bit");

            entity.HasData(
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
                });
        });
    }

    private void ConfigureInverterEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inverter>(entity =>
        {
            entity.ToTable("Inverters");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.SerialNumber)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("nvarchar(100)");

            entity.Property(e => e.MaxPowerKw)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.InstallationDate)
                .HasColumnType("datetime2");

            entity.Property(e => e.IsActive)
                .HasColumnType("bit")
                .HasDefaultValue(true);

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.HasIndex(e => e.PlantId);

            entity.HasOne(d => d.Plant)
                .WithMany(p => p.Inverters)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasData(
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
        });
    }

    private void ConfigureTelemetryEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Telemetry>(entity =>
        {
            entity.ToTable("Telemetry");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.DcPowerKw)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.AcPowerKw)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.DailyYield)
                .HasColumnType("int");

            entity.Property(e => e.TotalYield)
                .HasColumnType("bigint");

            entity.Property(e => e.AmbientTemperature)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.ModuleTemperature)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.Irradiance)
                .HasColumnType("int");

            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime2");

            entity.Property(e => e.InverterId)
                .HasColumnType("int");

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.HasIndex(e => new { e.InverterId, e.Timestamp })
                .HasDatabaseName("IX_Telemetry_InverterId_Timestamp");

            entity.HasIndex(e => new { e.PlantId, e.Timestamp })
                .HasDatabaseName("IX_Telemetry_PlantId_Timestamp");

            entity.HasOne(d => d.Inverter)
                .WithMany(p => p.TelemetryRecords)
                .HasForeignKey(d => d.InverterId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Plant)
                .WithMany(p => p.TelemetryRecords)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasData(
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
                });
        });
    }

    private void ConfigureAnalysisResultEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnalysisResult>(entity =>
        {
            entity.ToTable("AnalysisResults");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.ExpectedPowerKw)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.ActualPowerKw)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.DeviationPct)
                .HasColumnType("decimal(18,4)");

            entity.Property(e => e.EnergyLossKwh)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.EstimatedLoss)
                .HasColumnType("decimal(18,2)");

            entity.Property(e => e.AnomalyScore)
                .HasColumnType("decimal(5,4)");

            entity.Property(e => e.ConfidenceScore)
                .HasColumnType("decimal(5,4)");

            entity.Property(e => e.PrimaryCause)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("nvarchar(200)");

            entity.Property(e => e.CauseProbabilities)
                .IsRequired()
                .HasColumnType("TEXT");

            entity.Property(e => e.Timestamp)
                .HasColumnType("datetime2");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime2");

            entity.Property(e => e.InverterId)
                .HasColumnType("int");

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.Property(e => e.Severity)
                .HasColumnType("int");

            entity.Property(e => e.IsAnomaly)
                .HasColumnType("bit");

            entity.Property(e => e.Currency)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValue(1)
                .HasColumnType("int");

            entity.HasIndex(e => e.IsAnomaly)
                .HasDatabaseName("IX_AnalysisResult_IsAnomaly");

            entity.HasIndex(e => new { e.InverterId, e.Timestamp })
                .HasDatabaseName("IX_AnalysisResult_InverterId_Timestamp");

            entity.HasIndex(e => new { e.PlantId, e.Timestamp })
                .HasDatabaseName("IX_AnalysisResult_PlantId_Timestamp");

            entity.HasOne(d => d.Inverter)
                .WithMany(p => p.AnalysisResults)
                .HasForeignKey(d => d.InverterId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasOne(d => d.Plant)
                .WithMany()
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });
    }

    private void ConfigureTariffEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tariff>(entity =>
        {
            entity.ToTable("Tariffs");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.Rate)
                .HasColumnType("decimal(18,4)");

            entity.Property(e => e.Type)
                .HasColumnType("int");

            entity.Property(e => e.Currency)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasDefaultValue(1);

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.HasIndex(e => e.PlantId);

            entity.HasOne(d => d.Plant)
                .WithMany(p => p.Tariffs)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            entity.HasData(
                new Tariff
                {
                    Id = 1,
                    Rate = 1.25m,
                    Type = TAYF.Domain.Enums.TariffType.NetMetering,
                    Currency = TAYF.Domain.Enums.Currency.EGP,
                    PlantId = 1
                });
        });
    }

    private void ConfigureMaintenanceActionEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaintenanceAction>(entity =>
        {
            entity.ToTable("MaintenanceActions");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.ActionType)
                .HasColumnType("int");

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("nvarchar(500)");

            entity.Property(e => e.StartedAt)
                .HasColumnType("datetime2");

            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime2");

            entity.Property(e => e.InverterId)
                .HasColumnType("int");

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.HasIndex(e => e.InverterId);

            entity.HasIndex(e => e.PlantId);

            entity.HasOne(d => d.Inverter)
                .WithMany(p => p.MaintenanceActions)
                .HasForeignKey(d => d.InverterId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.Plant)
                .WithMany(p => p.MaintenanceActions)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });
    }

    private void ConfigureRepairVerificationEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RepairVerification>(entity =>
        {
            entity.ToTable("RepairVerifications");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.MaintenanceActionId)
                .HasColumnType("int");

            entity.Property(e => e.PerformanceBefore)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.PerformanceAfter)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.RecoveryPct)
                .HasColumnType("decimal(5,2)");

            entity.Property(e => e.IsStable)
                .HasColumnType("bit");

            entity.Property(e => e.Verified)
                .HasColumnType("bit");

            entity.Property(e => e.VerifiedAt)
                .HasColumnType("datetime2");

            entity.HasIndex(e => e.MaintenanceActionId);

            entity.HasOne(d => d.MaintenanceAction)
                .WithMany(p => p.RepairVerifications)
                .HasForeignKey(d => d.MaintenanceActionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });
    }

    private void ConfigureTelemetryProcessingCheckpointEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TelemetryProcessingCheckpoint>(entity =>
        {
            entity.ToTable("TelemetryProcessingCheckpoints");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            entity.Property(e => e.InverterId)
                .HasColumnType("int");

            entity.Property(e => e.LastProcessedUtc)
                .HasColumnType("datetime2");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime2")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            entity.HasIndex(e => e.InverterId)
                .IsUnique();

            entity.HasOne(d => d.Inverter)
                .WithMany()
                .HasForeignKey(d => d.InverterId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });
    }
}