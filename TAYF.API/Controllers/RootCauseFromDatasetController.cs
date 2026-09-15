using Microsoft.AspNetCore.Mvc;
using TAYF.Application.Interfaces;
using TAYF.Infrastructure.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace TAYF.API.Controllers;

[ApiController]
[Route("api/v1/diagnosis")]
[Produces("application/json")]
public class RootCauseFromDatasetController : ControllerBase
{
    private readonly IRootCauseModelClient _aiClient;
    private readonly IWebHostEnvironment _env;
    private readonly ILogger<RootCauseFromDatasetController> _logger;

    private static List<PvFaultRow>? _cachedRows;

    public RootCauseFromDatasetController(
        IRootCauseModelClient aiClient,
        IWebHostEnvironment env,
        ILogger<RootCauseFromDatasetController> logger)
    {
        _aiClient = aiClient;
        _env = env;
        _logger = logger;
    }

    private string ResolveCsvPath()
    {
        var candidates = new[]
        {
            // 1. Output directory (where .csproj copies it)
            Path.Combine(System.AppContext.BaseDirectory, "Seed", "pv_fault", "pv_fault_dataset.csv"),
            // 2. Content root (source dir, in case it exists)
            Path.Combine(_env.ContentRootPath, "Seed", "pv_fault", "pv_fault_dataset.csv"),
            // 3. Infrastructure source folder (dev fallback)
            Path.Combine(_env.ContentRootPath, "..", "TAYF.Infrastructure", "Seed", "pv_fault", "pv_fault_dataset.csv"),
        };

        foreach (var path in candidates)
        {
            var full = Path.GetFullPath(path);
            if (System.IO.File.Exists(full))
            {
                _logger.LogInformation("Found dataset at: {Path}", full);
                return full;
            }
        }

        throw new FileNotFoundException(
            $"Dataset not found. Tried: {string.Join(", ", candidates)}");
    }

    private List<PvFaultRow> GetRows()
    {
        if (_cachedRows != null) return _cachedRows;

        var path = ResolveCsvPath();
        _logger.LogInformation("Loading pv_fault_dataset from {Path}", path);
        var reader = new PvFaultDatasetReader(path);
        _cachedRows = reader.ReadAll();
        _logger.LogInformation("Loaded {Count} rows", _cachedRows.Count);
        return _cachedRows;
    }

    [HttpGet("root-cause-from-dataset")]
    [ProducesResponseType(typeof(object), 200)]
    public async Task<ActionResult> GetRootCauseFromDataset(
        [FromQuery] int rowIndex = 0,
        CancellationToken ct = default)
    {
        var rows = GetRows();

        if (rowIndex < 0 || rowIndex >= rows.Count)
            return BadRequest(new { message = $"rowIndex must be 0..{rows.Count - 1}" });

        var row = rows[rowIndex];

        var input = new IRootCauseModelClient.PvFaultInput(
            row.Vdc1, row.Vdc2, row.Idc1, row.Idc2, row.Irr, row.Pvt);

        var prediction = await _aiClient.PredictFromDatasetAsync(input, ct);

        return Ok(new
        {
            rowIndex,
            input = new
            {
                row.Vdc1, row.Vdc2, row.Idc1, row.Idc2,
                row.Irr, row.Pvt,
                expectedFaultLabel = row.FaultLabel
            },
            prediction
        });
    }

    [HttpGet("dataset-info")]
    public ActionResult GetDatasetInfo()
    {
        var rows = GetRows();
        return Ok(new
        {
            totalRows = rows.Count,
            columns = new[] { "vdc1", "vdc2", "idc1", "idc2", "irr", "pvt", "f_nv" },
            faultLabels = new Dictionary<int, string>
            {
                { 0, "Normal" },
                { 1, "Short-Circuit" },
                { 2, "Degradation" },
                { 3, "Open Circuit" },
                { 4, "Shadowing" }
            }
        });
    }
}