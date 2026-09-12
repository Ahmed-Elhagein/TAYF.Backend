using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TAYF.Domain.Enums;

namespace TAYF.Domain.Entities;

/// <summary>
/// Represents a solar power plant installation
/// </summary>
public class Plant
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(200)]
    public string Location { get; set; } = null!;

    [Required]
    public decimal CapacityKw { get; set; }

    [Required]
    public TariffType TariffType { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,4)")]
    public decimal TariffRate { get; set; }

    [Required]
    public Currency Currency { get; set; } = Currency.EGP;

    [Required]
    public DateTime InstallationDate { get; set; }

    public bool IsActive { get; set; } = true;

    // Navigation properties
    public virtual ICollection<Inverter> Inverters { get; set; } = new List<Inverter>();
    public virtual ICollection<Tariff> Tariffs { get; set; } = new List<Tariff>();
    public virtual ICollection<Telemetry> TelemetryRecords { get; set; } = new List<Telemetry>();
    public virtual ICollection<MaintenanceAction> MaintenanceActions { get; set; } = new List<MaintenanceAction>();
}