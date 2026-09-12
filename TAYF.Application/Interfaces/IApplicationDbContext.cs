using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TAYF.Domain.Entities;

namespace TAYF.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Plant> Plants { get; }
        DbSet<Inverter> Inverters { get; }
        DbSet<Telemetry> TelemetryRecords { get; }
        DbSet<AnalysisResult> AnalysisResults { get; }
        DbSet<Tariff> Tariffs { get; }
        DbSet<Alert> Alerts { get; }
        DbSet<MaintenanceAction> MaintenanceActions { get; }
        DbSet<RepairVerification> RepairVerifications { get; }
        DbSet<TelemetryProcessingCheckpoint> TelemetryProcessingCheckpoints { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}