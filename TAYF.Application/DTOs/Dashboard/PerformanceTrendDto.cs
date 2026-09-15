namespace TAYF.Application.DTOs.Dashboard;

public class PerformanceTrendDto
{
    public int PlantId { get; set; }
    public List<PerformanceTrendDayDto> Days { get; set; } = new();
}

public class PerformanceTrendDayDto
{
    public DateTime Date { get; set; }
    public decimal ExpectedKwh { get; set; }
    public decimal ActualKwh { get; set; }
    public decimal DeviationPct { get; set; }
}