using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TAYF.Application.DTOs;

namespace TAYF.API.Controllers;

/// <summary>
/// Health check endpoint
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class HealthController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    /// <summary>
    ///
    /// </summary>
    /// <param name="env"></param>
    public HealthController(IWebHostEnvironment env)
    {
        _env = env;
    }

    /// <summary>
    /// Returns the health status of the API
    /// </summary>
    /// <returns>Health status information</returns>
    [HttpGet]
    public ActionResult<HealthDto> Get()
    {
        var healthDto = new HealthDto
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0", // Could be read from AssemblyInformationalVersionAttribute
            Environment = _env.EnvironmentName
        };

        return Ok(healthDto);
    }
}