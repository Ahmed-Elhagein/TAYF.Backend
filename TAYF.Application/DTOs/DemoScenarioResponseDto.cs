namespace TAYF.Application.DTOs;

public class DemoScenarioResponseDto
{
    public int PlantId { get; set; }
    public int InverterId { get; set; }
    public string Scenario { get; set; } = string.Empty;
    public bool Applied { get; set; }
    public string Message { get; set; } = string.Empty;
}