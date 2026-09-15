using System;
using Microsoft.Extensions.Options;
using TAYF.Application.Scada;
using TAYF.Infrastructure.Scada.Options;

namespace TAYF.Infrastructure.Scada
{
    /// <summary>
    /// Implementation of IScadaSimulationClock that simulates time for the SCADA simulation.
    /// </summary>
    public class ScadaSimulationClock : IScadaSimulationClock
    {
        private readonly ScadaSimulationOptions _options;
        private DateTime _currentTime;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScadaSimulationClock"/> class.
        /// </summary>
        /// <param name="options">The SCADA simulation options.</param>
        public ScadaSimulationClock(IOptions<ScadaSimulationOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException(nameof(options));
            _currentTime = _options.StartTime;
        }

        /// <inheritdoc/>
        public DateTime CurrentSimulatedTime => _currentTime;

        /// <inheritdoc/>
        public TimeSpan TickInterval => TimeSpan.FromMinutes(_options.TickIntervalMinutes);

        /// <inheritdoc/>
        public void Advance()
        {
            _currentTime = _currentTime.Add(TickInterval);
        }

        /// <inheritdoc/>
        public void Reset(DateTime start)
        {
            _currentTime = start;
        }
    }
}