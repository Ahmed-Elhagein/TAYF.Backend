using System;

namespace TAYF.Application.DTOs
{
    /// <summary>
    /// Data transfer object for tariff information.
    /// </summary>
    public class TariffInfoDto
    {
        /// <summary>
        /// Gets or sets the tariff rate.
        /// </summary>
        public decimal TariffRate { get; set; }

        /// <summary>
        /// Gets or sets the currency (as string, e.g., "EGP").
        /// </summary>
        public string Currency { get; set; } = string.Empty;
    }
}