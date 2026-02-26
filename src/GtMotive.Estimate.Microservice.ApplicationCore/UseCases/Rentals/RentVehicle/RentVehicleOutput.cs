using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Output for rent vehicle use case.
    /// </summary>
    public sealed class RentVehicleOutput : IUseCaseOutput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleOutput"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        /// <param name="startDateUtc">Start date in UTC.</param>
        public RentVehicleOutput(Guid rentalId, Guid vehicleId, Guid personId, DateTime startDateUtc)
        {
            RentalId = rentalId;
            VehicleId = vehicleId;
            PersonId = personId;
            StartDateUtc = startDateUtc;
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
        /// Gets person identifier.
        /// </summary>
        public Guid PersonId { get; }

        /// <summary>
        /// Gets rental start date in UTC.
        /// </summary>
        public DateTime StartDateUtc { get; }
    }
}
