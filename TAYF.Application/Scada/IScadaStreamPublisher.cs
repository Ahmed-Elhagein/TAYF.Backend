using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace TAYF.Application.Scada
{
    /// <summary>
    /// Interface for publishing SCADA readings to subscribers.
    /// </summary>
    public interface IScadaStreamPublisher
    {
        /// <summary>
        /// Publishes a reading to all subscribers asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of the reading to publish.</typeparam>
        /// <param name="reading">The reading to publish.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>A task that completes when the reading has been published.</returns>
        Task PublishAsync<T>(T reading, CancellationToken ct = default) where T : class;

        /// <summary>
        /// Subscribes to readings of a specific type asynchronously.
        /// </summary>
        /// <typeparam name="T">The type of readings to subscribe to.</param>
        /// <param name="ct">Optional cancellation token.</param>
        /// <returns>An asynchronous enumerable of readings of the specified type.</returns>
        IAsyncEnumerable<T> SubscribeAsync<T>(CancellationToken ct = default) where T : class;
    }
}