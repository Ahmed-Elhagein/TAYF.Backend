using System;

namespace TAYF.Infrastructure.Scada.Options
{
    /// <summary>
    /// Configuration options for the CSV SCADA data source.
    /// </summary>
    public class ScadaCsvOptions
    {
        /// <summary>
        /// The configuration section name for these options.
        /// </summary>
        public const string SectionName = "Scada:Csv";

        /// <summary>
        /// Base path for SCADA CSV files (relative to content root).
        /// </summary>
        public string BasePath { get; set; } = "../TAYF.Infrastructure/Seed/pv_scada";

        /// <summary>
        /// File name for inverter SCADA data CSV.
        /// </summary>
        public string InverterFile { get; set; } = "Inverter SCADA.csv";

        /// <summary>
        /// File name for meteorological data CSV.
        /// </summary>
        public string MeteorologicalFile { get; set; } = "Meteorological data.csv";

        /// <summary>
        /// File name for grid export data CSV.
        /// </summary>
        public string GridExportFile { get; set; } = "Grid export data.csv";
    }

    /// <summary>
    /// Configuration options for the SCADA simulation.
    /// </summary>
    public class ScadaSimulationOptions
    {
        /// <summary>
        /// The configuration section name for these options.
        /// </summary>
        public const string SectionName = "Scada:Simulation";

        /// <summary>
        /// Start time for the simulation.
        /// </summary>
        public DateTime StartTime { get; set; } = new DateTime(2025, 4, 1);

        /// <summary>
        /// Tick interval in minutes (how often to publish new readings).
        /// </summary>
        public int TickIntervalMinutes { get; set; } = 30;

        /// <summary>
        /// Time acceleration factor (1 second real = X minutes simulated).
        /// For example, 1440 means 1 second real = 1 day simulated.
        /// </summary>
        public int TimeAccelerationFactor { get; set; } = 1440;
    }
}