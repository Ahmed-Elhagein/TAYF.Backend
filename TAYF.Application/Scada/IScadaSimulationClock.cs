using System;

namespace TAYF.Application.Scada
{
    /// <summary>
    /// Interface for a simulation clock that controls the flow of time in the SCADA simulation.
    /// </summary>
    public interface IScadaSimulationClock
    {
        /// <summary>
        /// Gets the current simulated time.
        /// </summary>
        DateTime CurrentSimulatedTime { get; }

        /// <summary>
        /// Gets the interval between ticks in the simulation.
        /// </summary>
        TimeSpan TickInterval { get; }

        /// <summary>
        /// Advances the simulation clock by one tick interval.
        /// </summary>
        void Advance();

        /// <summary>
        /// Resets the simulation clock to a specific start time.
        /// </summary>
        /// <param name="start">The start time to reset the clock to.</param>
        void Reset(DateTime start);
    }
}