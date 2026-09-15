using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TAYF.Application.Scada.Models;

namespace TAYF.Application.Scada
{
    /// <summary>
    /// Interface for SCADA data sources that provide access to historical SCADA data.
    /// </summary>
    public interface IScadaDataSource
    {
        /// <summary>
        /// Gets inverter SCADA readings asynchronously based on the provided query.
        /// </summary>
        /// <param name="query">The query parameters for filtering readings.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>An asynchronous enumerable of inverter SCADA readings.</returns>
        IAsyncEnumerable<InverterScadaReading> GetInverterReadingsAsync(
            ScadaQuery query, CancellationToken ct = default);

        /// <summary>
        /// Gets meteorological readings asynchronously based on the provided query.
        /// </summary>
        /// <param name="query">The query parameters for filtering readings.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>An asynchronous enumerable of meteorological readings.</returns>
        IAsyncEnumerable<MeteorologicalReading> GetMeteorologicalReadingsAsync(
            ScadaQuery query, CancellationToken ct = default);

        /// <summary>
        /// Gets grid export readings asynchronously based on the provided query.
        /// </summary>
        /// <param name="query">The query parameters for filtering readings.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>An asynchronous enumerable of grid export readings.</returns>
        IAsyncEnumerable<GridExportReading> GetGridExportReadingsAsync(
            ScadaQuery query, CancellationToken ct = default);
    }
}