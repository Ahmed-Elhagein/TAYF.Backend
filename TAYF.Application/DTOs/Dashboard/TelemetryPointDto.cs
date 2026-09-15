namespace TAYF.Application.DTOs.Dashboard;

public class TelemetryPointDto
{
    public DateTime Timestamp { get; set; }
    public decimal AcPowerKw { get; set; }
    public int Irradiance { get; set; }
    public decimal ModuleTemp { get; set; }
}