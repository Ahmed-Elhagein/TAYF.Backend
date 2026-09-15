using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;

public interface ICleaningDecisionService
{
    Task<CleaningDecisionResponseDto> GetCleaningDecisionAsync(
        CleaningDecisionRequestDto request,
        CancellationToken ct = default);
}