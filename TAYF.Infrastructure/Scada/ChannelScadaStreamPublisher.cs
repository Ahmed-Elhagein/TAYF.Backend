using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TAYF.Application.Scada;

namespace TAYF.Infrastructure.Scada
{
    /// <summary>
    /// Implementation of IScadaStreamPublisher that uses channels to publish SCADA readings.
    /// </summary>
    public class ChannelScadaStreamPublisher : IScadaStreamPublisher
    {
        private readonly ILogger<ChannelScadaStreamPublisher> _logger;
        // Stores channels for each type T
        private readonly ConcurrentDictionary<Type, object> _channels = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ChannelScadaStreamPublisher"/> class.
        /// </summary>
        /// <param name="logger">The logger for logging messages.</param>
        public ChannelScadaStreamPublisher(ILogger<ChannelScadaStreamPublisher> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task PublishAsync<T>(T reading, CancellationToken ct = default) where T : class
        {
            if (reading == null)
            {
                throw new ArgumentNullException(nameof(reading));
            }

            var channel = GetOrCreateChannel<T>();
            await channel.Writer.WriteAsync(reading, ct);
        }

        /// <inheritdoc/>
        public IAsyncEnumerable<T> SubscribeAsync<T>(CancellationToken ct = default) where T : class
        {
            var channel = GetOrCreateChannel<T>();
            return channel.Reader.ReadAllAsync(ct);
        }

        private Channel<T> GetOrCreateChannel<T>() where T : class
        {
            return (Channel<T>)_channels.GetOrAdd(typeof(T), _ => CreateUnboundedChannel<T>());
        }

        private static Channel<T> CreateUnboundedChannel<T>()
        {
            return Channel.CreateUnbounded<T>(new UnboundedChannelOptions
            {
                SingleReader = false,
                SingleWriter = false
            });
        }
    }
}