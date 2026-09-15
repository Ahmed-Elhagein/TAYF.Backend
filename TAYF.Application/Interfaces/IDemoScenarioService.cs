using TAYF.Application.DTOs;

namespace TAYF.Application.Interfaces;

public interface IDemoScenarioService
{
    Task<DemoScenarioResponseDto> ApplyScenarioAsync(
        DemoScenarioRequestDto request,
        CancellationToken ct = default);
}