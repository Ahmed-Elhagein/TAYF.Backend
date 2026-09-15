using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TAYF.Domain.Enums;
using TAYF.Domain.Entities;
using TAYF.Application.Interfaces;
using TAYF.Infrastructure.Seed;

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
        TayfSeedData.Seed(modelBuilder);
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
                ;

            entity.Property(e => e.Location)
                .IsRequired()
                .HasMaxLength(200)
                ;

            entity.Property(e => e.CapacityKw)
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.TariffType)
                .IsRequired();

            entity.Property(e => e.TariffRate)
                .IsRequired()
                .HasColumnType("numeric(18,4)");

            entity.Property(e => e.Currency)
                .IsRequired()
                .HasDefaultValue(Currency.EGP)
                .HasColumnType("int");

            entity.Property(e => e.InstallationDate)
                .IsRequired()
                .HasColumnType("timestamp with time zone");

            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValue(true)
                ;

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
                ;

            entity.Property(e => e.Model)
                .IsRequired()
                .HasMaxLength(100)
                ;

            entity.Property(e => e.MaxPowerKw)
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.InstallationDate)
                .HasColumnType("timestamp with time zone");

            entity.Property(e => e.IsActive)
                
                .HasDefaultValue(true);

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.HasIndex(e => e.PlantId);

            entity.HasOne(d => d.Plant)
                .WithMany(p => p.Inverters)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

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
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.AcPowerKw)
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.DailyYield)
                .HasColumnType("int");

            entity.Property(e => e.TotalYield)
                .HasColumnType("bigint");

            entity.Property(e => e.AmbientTemperature)
                .HasColumnType("numeric(5,2)");

            entity.Property(e => e.ModuleTemperature)
                .HasColumnType("numeric(5,2)");

            entity.Property(e => e.Irradiance)
                .HasColumnType("int");

            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp with time zone");

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
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.ActualPowerKw)
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.DeviationPct)
                .HasColumnType("numeric(18,4)");

            entity.Property(e => e.EnergyLossKwh)
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.EstimatedLoss)
                .HasColumnType("numeric(18,2)");

            entity.Property(e => e.AnomalyScore)
                .HasColumnType("numeric(5,4)");

            entity.Property(e => e.ConfidenceScore)
                .HasColumnType("numeric(5,4)");

            entity.Property(e => e.PrimaryCause)
                .IsRequired()
                .HasMaxLength(200)
                ;

            entity.Property(e => e.CauseProbabilities)
                .IsRequired()
                .HasColumnType("TEXT");

            entity.Property(e => e.Timestamp)
                .HasColumnType("timestamp with time zone");

            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp with time zone");

            entity.Property(e => e.InverterId)
                .HasColumnType("int");

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.Property(e => e.Severity)
                .HasColumnType("int");

            entity.Property(e => e.IsAnomaly)
                ;

            entity.Property(e => e.Currency)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasDefaultValue(Currency.EGP)
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
                .HasColumnType("numeric(18,4)");

            entity.Property(e => e.Type)
                .HasColumnType("int");

            entity.Property(e => e.Currency)
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .HasDefaultValue(Currency.EGP);

            entity.Property(e => e.PlantId)
                .HasColumnType("int");

            entity.HasIndex(e => e.PlantId);

            entity.HasOne(d => d.Plant)
                .WithMany(p => p.Tariffs)
                .HasForeignKey(d => d.PlantId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

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
                ;

            entity.Property(e => e.StartedAt)
                .HasColumnType("timestamp with time zone");

            entity.Property(e => e.CompletedAt)
                .HasColumnType("timestamp with time zone");

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

            entity.Property(e => e.PerformanceBefore).HasColumnType("numeric(18,2)");
            entity.Property(e => e.PerformanceAfter).HasColumnType("numeric(18,2)");

            entity.Property(e => e.ExpectedPowerKw)
                .HasColumnType("numeric(18,2)")
                .HasDefaultValue(0m);

            entity.Property(e => e.RecoveryPct)
                .HasColumnType("numeric(5,2)");

            entity.Property(e => e.IsStable)
                ;

            entity.Property(e => e.Verified)
                ;

            entity.Property(e => e.VerifiedAt)
                .HasColumnType("timestamp with time zone");

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
                .HasColumnType("timestamp with time zone");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp with time zone")
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("NOW() AT TIME ZONE 'utc'");

            entity.HasIndex(e => e.InverterId)
                .IsUnique();

            entity.HasOne(d => d.Inverter)
                .WithMany()
                .HasForeignKey(d => d.InverterId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

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
