using System;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for economic impact analysis.
    /// </summary>
    public class EconomicImpactDto
    {
        /// <summary>
        /// Gets or sets the plant identifier.
        /// </summary>
        public int PlantId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the analysis period (UTC).
        /// </summary>
        public DateTime From { get; set; }

        /// <summary>
        /// Gets or sets the end date of the analysis period (UTC).
        /// </summary>
        public DateTime To { get; set; }

        /// <summary>
        /// Gets or sets the total energy loss in kilowatt-hours.
        /// </summary>
        public decimal EnergyLossKwh { get; set; }

        /// <summary>
        /// Gets or sets the tariff rate (currency per kWh).
        /// </summary>
        public decimal TariffRate { get; set; }

        /// <summary>
        /// Gets or sets the currency (as string, e.g., "EGP").
        /// </summary>
        public string Currency { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the estimated financial loss (in the currency).
        /// </summary>
        public decimal EstimatedLoss { get; set; }
    }
}