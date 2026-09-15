using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using TAYF.Application.Scada;
using TAYF.Application.Scada.Models;
using TAYF.Infrastructure.Scada.Options;

namespace TAYF.Infrastructure.Scada
{
    /// <summary>
    /// Background service that simulates SCADA data publishing at regular intervals.
    /// </summary>
    public class ScadaSimulationBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IScadaSimulationClock _scadaSimulationClock;
        private readonly IOptions<ScadaSimulationOptions> _scadaSimulationOptions;
        private readonly ILogger<ScadaSimulationBackgroundService> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaSimulationBackgroundService"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider for resolving scoped services.</param>
        /// <param name="scadaSimulationClock">The SCADA simulation clock.</param>
        /// <param name="scadaSimulationOptions">The SCADA simulation options.</param>
        /// <param name="logger">The logger for logging messages.</param>
        public ScadaSimulationBackgroundService(
            IServiceProvider serviceProvider,
            IScadaSimulationClock scadaSimulationClock,
            IOptions<ScadaSimulationOptions> scadaSimulationOptions,
            ILogger<ScadaSimulationBackgroundService> logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _scadaSimulationClock = scadaSimulationClock ?? throw new ArgumentNullException(nameof(scadaSimulationClock));
            _scadaSimulationOptions = scadaSimulationOptions ?? throw new ArgumentNullException(nameof(scadaSimulationOptions));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("SCADA simulation background service starting.");

            // Reset the simulation clock to the start time
            _scadaSimulationClock.Reset(_scadaSimulationOptions.Value.StartTime);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var now = _scadaSimulationClock.CurrentSimulatedTime;
                    var windowEnd = now.Add(_scadaSimulationClock.TickInterval);

                    _logger.LogDebug(
                        "SCADA simulation tick: {Now} to {WindowEnd}",
                        now,
                        windowEnd);

                    // Create a scope to resolve scoped services
                    using var scope = _serviceProvider.CreateScope();
                    var scadaDataSource = scope.ServiceProvider.GetRequiredService<IScadaDataSource>();
                    var scadaStreamPublisher = scope.ServiceProvider.GetRequiredService<IScadaStreamPublisher>();

                    // Process inverter readings
                    await ProcessReadingsAsync(
                        scadaDataSource.GetInverterReadingsAsync(
                            new ScadaQuery { From = now, To = windowEnd },
                            stoppingToken),
                        "Inverter",
                        stoppingToken,
                        scadaStreamPublisher);

                    // Process meteorological readings
                    await ProcessReadingsAsync(
                        scadaDataSource.GetMeteorologicalReadingsAsync(
                            new ScadaQuery { From = now, To = windowEnd },
                            stoppingToken),
                        "Meteorological",
                        stoppingToken,
                        scadaStreamPublisher);

                    // Process grid export readings
                    await ProcessReadingsAsync(
                        scadaDataSource.GetGridExportReadingsAsync(
                            new ScadaQuery { From = now, To = windowEnd },
                            stoppingToken),
                        "GridExport",
                        stoppingToken,
                        scadaStreamPublisher);

                    // Advance the simulation clock
                    _scadaSimulationClock.Advance();

                    // Calculate delay based on time acceleration factor
                    var delay = TimeSpan.FromSeconds(
                        _scadaSimulationClock.TickInterval.TotalSeconds /
                        _scadaSimulationOptions.Value.TimeAccelerationFactor);

                    _logger.LogDebug(
                        "SCADA simulation tick complete. Waiting {Delay} seconds until next tick.",
                        delay.TotalSeconds);

                    await Task.Delay(delay, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    // Handle cancellation gracefully
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error in SCADA simulation background service");
                    // Continue running despite errors
                    await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
                }
            }

            _logger.LogInformation("SCADA simulation background service stopping.");
        }

        private async Task ProcessReadingsAsync<T>(
            IAsyncEnumerable<T> readings,
            string typeName,
            CancellationToken ct,
            IScadaStreamPublisher publisher) where T : class
        {
            int count = 0;
            await foreach (var reading in readings.WithCancellation(ct))
            {
                await publisher.PublishAsync(reading, ct);
                count++;
            }

            if (count > 0)
            {
                _logger.LogDebug("Published {Count} {TypeName} readings", count, typeName);
            }
        }
    }
}