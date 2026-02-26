using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Output for return vehicle use case.
    /// </summary>
    public sealed class ReturnVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="endDateUtc">Return date in UTC.</param>
        public ReturnVehicleOutput(Guid rentalId, Guid vehicleId, DateTime endDateUtc)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            EndDateUtc = endDateUtc;
        }

        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        public Guid RentalId { get; }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets return date in UTC.
        /// </summary>
        public DateTime EndDateUtc { get; }
    }
}
