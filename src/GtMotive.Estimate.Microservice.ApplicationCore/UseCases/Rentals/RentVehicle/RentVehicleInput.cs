using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.RentVehicle
{
    /// <summary>
    /// Input for rent vehicle use case.
    /// </summary>
    public sealed class RentVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RentVehicleInput"/> class.
        /// </summary>
        /// <param name="vehicleId">Vehicle identifier.</param>
        /// <param name="personId">Person identifier.</param>
        public RentVehicleInput(Guid vehicleId, Guid personId)
        {
            VehicleId = vehicleId;
            PersonId = personId;
        }

        /// <summary>
        /// Gets vehicle identifier.
        /// </summary>
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets person identifier.
        /// </summary>
        public Guid PersonId { get; }
    }
}
