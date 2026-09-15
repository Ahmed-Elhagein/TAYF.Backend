namespace TAYF.Application.DTOs;

public class CleaningDecisionRequestDto
{
    public int PlantId { get; set; }
    public int? InverterId { get; set; }
    public decimal CleaningCost { get; set; }
}