using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.IO;

namespace TAYF.Infrastructure.Seed;

public class PvFaultDatasetReader
{
    private readonly string _csvPath;

    public PvFaultDatasetReader(string csvPath)
    {
        _csvPath = csvPath;
    }

    public List<PvFaultRow> ReadAll()
    {
        if (!File.Exists(_csvPath))
            throw new FileNotFoundException($"Dataset not found: {_csvPath}");

        using var reader = new StreamReader(_csvPath);
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            MissingFieldFound = null,
            HeaderValidated = null,
            BadDataFound = null
        };
        using var csv = new CsvReader(reader, config);
        return csv.GetRecords<PvFaultRow>().ToList();
    }
}

public class PvFaultRow
{
    [Name("vdc1")] public double Vdc1 { get; set; }
    [Name("vdc2")] public double Vdc2 { get; set; }
    [Name("idc1")] public double Idc1 { get; set; }
    [Name("idc2")] public double Idc2 { get; set; }
    [Name("irr")] public double Irr { get; set; }
    [Name("pvt")] public double Pvt { get; set; }
    [Name("f_nv")] public int FaultLabel { get; set; }
}