using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAYF.Infrastructure;
using TAYF.Domain.Entities;
using TAYF.Application.DTOs;
using TAYF.Application.Interfaces;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlantsController : ControllerBase
{
    private readonly IApplicationDbContext _context;

    public PlantsController(IApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Plants/1 - Get plant with inverters for status endpoint
    [HttpGet("{id}")]
    public async Task<ActionResult<PlantDto>> GetPlant(int id)
    {
        var plant = await _context.Plants
            .Include(p => p.Inverters)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (plant == null)
        {
            return NotFound();
        }

        // Map Plant entity to PlantDto
        var plantDto = new PlantDto
        {
            Id = plant.Id,
            Name = plant.Name,
            Location = plant.Location,
            CapacityKw = plant.CapacityKw,
            TariffType = plant.TariffType,
            TariffRate = plant.TariffRate,
            Currency = plant.Currency,
            InstallationDate = plant.InstallationDate,
            IsActive = plant.IsActive,
            Inverters = plant.Inverters.Select(i => new InverterDto
            {
                Id = i.Id,
                PlantId = i.PlantId,
                SerialNumber = i.SerialNumber,
                Model = i.Model,
                MaxPowerKw = i.MaxPowerKw,
                InstallationDate = i.InstallationDate,
                IsActive = i.IsActive
            }).ToList()
        };

        return Ok(plantDto);
    }
}