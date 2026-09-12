using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using TAYF.Domain.Enums;

namespace TAYF.Application.DTOs;

/// <summary>
/// Data Transfer Object for Plant data
/// </summary>
public class PlantDto
{
    [Required]
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
    public decimal TariffRate { get; set; }

    [Required]
    public Currency Currency { get; set; } = Currency.EGP;

    [Required]
    public DateTime InstallationDate { get; set; }

    public bool IsActive { get; set; } = true;

    // DTO for related inverters (avoid circular references)
    public virtual ICollection<InverterDto> Inverters { get; set; } = new List<InverterDto>();
}