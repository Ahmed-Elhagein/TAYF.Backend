using System;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for a maintenance priority item (per inverter).
    /// </summary>
    public class MaintenancePriorityItemDto
    {
        /// <summary>
        /// Gets or sets the inverter identifier.
        /// </summary>
        public int InverterId { get; set; }

        /// <summary>
        /// Gets or sets the asset identifier (inverter serial number).
        /// </summary>
        public string Asset { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the priority (1 = highest priority).
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Gets or sets the total financial loss (in the currency).
        /// </summary>
        public decimal FinancialLoss { get; set; }

        /// <summary>
        /// Gets or sets the total energy loss in kWh.
        /// </summary>
        public decimal EnergyLossKwh { get; set; }

        /// <summary>
        /// Gets or sets the highest severity level.
        /// </summary>
        public string Severity { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the currency (e.g., "EGP").
        /// </summary>
        public string Currency { get; set; } = string.Empty;
    }
}