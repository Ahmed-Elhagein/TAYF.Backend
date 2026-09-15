namespace TAYF.Application.DTOs;

public class DemoScenarioRequestDto
{
    public int PlantId { get; set; }
    public int InverterId { get; set; }
    public string Scenario { get; set; } = "Normal";
}