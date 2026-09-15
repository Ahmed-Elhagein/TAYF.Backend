using System.Text.Json;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Scada;
using TAYF.Application.Scada.Models;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/scada")]
[Produces("application/json")]
public class ScadaController : ControllerBase
{
    private readonly IScadaDataSource _dataSource;
    private readonly IScadaStreamPublisher _publisher;

    public ScadaController(IScadaDataSource dataSource, IScadaStreamPublisher publisher)
    {
        _dataSource = dataSource;
        _publisher = publisher;
    }

    [HttpGet("inverter")]
    public IAsyncEnumerable<InverterScadaReading> GetInverterReadings(
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to,
        [FromQuery] string? inverterId = null,
        CancellationToken ct = default)
    {
        var query = new ScadaQuery
        {
            From = from ?? DateTime.UtcNow.AddDays(-7),
            To = to ?? DateTime.UtcNow,
            InverterId = inverterId
        };
        return _dataSource.GetInverterReadingsAsync(query, ct);
    }

    [HttpGet("meteorological")]
    public IAsyncEnumerable<MeteorologicalReading> GetMeteorologicalReadings(
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to,
        [FromQuery] string? stationId = null,
        CancellationToken ct = default)
    {
        var query = new ScadaQuery
        {
            From = from ?? DateTime.UtcNow.AddDays(-7),
            To = to ?? DateTime.UtcNow,
            StationId = stationId
        };
        return _dataSource.GetMeteorologicalReadingsAsync(query, ct);
    }

    [HttpGet("grid-export")]
    public IAsyncEnumerable<GridExportReading> GetGridExportReadings(
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to,
        [FromQuery] string? inverterId = null,
        CancellationToken ct = default)
    {
        var query = new ScadaQuery
        {
            From = from ?? DateTime.UtcNow.AddDays(-7),
            To = to ?? DateTime.UtcNow,
            InverterId = inverterId
        };
        return _dataSource.GetGridExportReadingsAsync(query, ct);
    }

    [HttpGet("inverter/stream")]
    public async Task StreamInverterReadings(CancellationToken ct)
    {
        Response.Headers.Append("Content-Type", "text/event-stream");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("X-Accel-Buffering", "no");

        await foreach (var reading in _publisher.SubscribeAsync<InverterScadaReading>(ct))
        {
            var json = JsonSerializer.Serialize(reading);
            await Response.WriteAsync($"data: {json}\n\n", ct);
            await Response.Body.FlushAsync(ct);
        }
    }

    [HttpGet("meteorological/stream")]
    public async Task StreamMeteorologicalReadings(CancellationToken ct)
    {
        Response.Headers.Append("Content-Type", "text/event-stream");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("X-Accel-Buffering", "no");

        await foreach (var reading in _publisher.SubscribeAsync<MeteorologicalReading>(ct))
        {
            var json = JsonSerializer.Serialize(reading);
            await Response.WriteAsync($"data: {json}\n\n", ct);
            await Response.Body.FlushAsync(ct);
        }
    }

    [HttpGet("grid-export/stream")]
    public async Task StreamGridExportReadings(CancellationToken ct)
    {
        Response.Headers.Append("Content-Type", "text/event-stream");
        Response.Headers.Append("Cache-Control", "no-cache");
        Response.Headers.Append("X-Accel-Buffering", "no");

        await foreach (var reading in _publisher.SubscribeAsync<GridExportReading>(ct))
        {
            var json = JsonSerializer.Serialize(reading);
            await Response.WriteAsync($"data: {json}\n\n", ct);
            await Response.Body.FlushAsync(ct);
        }
    }
}