using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.Rentals.ReturnVehicle
{
    /// <summary>
    /// Input for return vehicle use case.
    /// </summary>
    public sealed class ReturnVehicleInput : IUseCaseInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnVehicleInput"/> class.
        /// </summary>
        /// <param name="rentalId">Rental identifier.</param>
        public ReturnVehicleInput(Guid rentalId)
        {
            RentalId = rentalId;
        }

        /// <summary>
        /// Gets rental identifier.
        /// </summary>
        public Guid RentalId { get; }
    }
}
