using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Vehicles.ListAvailableVehicles
{
    /// <summary>
    /// Output for available vehicles list.
    /// </summary>
    public sealed class ListAvailableVehiclesOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListAvailableVehiclesOutput"/> class.
        /// </summary>
        /// <param name="vehicles">Available vehicles.</param>
        public ListAvailableVehiclesOutput(IReadOnlyCollection<AvailableVehicleOutputItem> vehicles)
        {
            Vehicles = vehicles;
        }

        /// <summary>
        /// Gets available vehicles.
        /// </summary>
        public IReadOnlyCollection<AvailableVehicleOutputItem> Vehicles { get; }
    }
}
